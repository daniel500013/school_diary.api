using Microsoft.AspNetCore.Identity;
using school_diary.api.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace school_diary.api.Service
{
    public class accountService
    {
        private readonly DiaryDbContext diaryDbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly authSettings auth;

        public accountService(DiaryDbContext diaryDbContext, IPasswordHasher<User> passwordHasher, authSettings auth)
        {
            this.diaryDbContext = diaryDbContext;
            this.passwordHasher = passwordHasher;
            this.auth = auth;
        }

        public async Task Register(User user)
        {
            if (user is null)
            {
                throw new Exception("Invalid login or password");
            }

            var emailValidation = new EmailAddressAttribute().IsValid(user.email);

            if (!emailValidation)
            {
                throw new Exception("Invalid login");
            }

            user.uuid = Guid.NewGuid();
            user.hashPassword = passwordHasher.HashPassword(user, user.password);
            user.password = String.Empty;

            await diaryDbContext.AddAsync(user);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task<string> Login(User userModel)
        {
            var user = await diaryDbContext.user
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.email == userModel.email);

            if (user is null)
            {
                throw new Exception("Invalid login or password");
            }

            var checkPassword = passwordHasher.VerifyHashedPassword(userModel, user.hashPassword, userModel.password);

            if (checkPassword == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid login or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.uuid.ToString()),
                new Claim(ClaimTypes.Name, user.email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(10);

            var token = new JwtSecurityToken(auth.Issuer,
                auth.Issuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
