using Microsoft.AspNetCore.Identity;
using school_diary.api.Model;
using school_diary.api.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace school_diary.api.Service
{
    public class accountService : IAccountService
    {
        private readonly DiaryDbContext diaryDbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IPasswordHasher<Login> passwordHasherLogin;
        private readonly authSettings auth;

        public accountService(DiaryDbContext diaryDbContext, IPasswordHasher<User> passwordHasher, IPasswordHasher<Login> passwordHasherLogin, authSettings auth)
        {
            this.diaryDbContext = diaryDbContext;
            this.passwordHasher = passwordHasher;
            this.passwordHasherLogin = passwordHasherLogin;
            this.auth = auth;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await diaryDbContext.user.ToListAsync();

            return users;
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

            Guid uuid = Guid.NewGuid();

            var role = new UserRole()
            {
                FK_RoleId = 1,
                FK_UserId = uuid
            };

            user.uuid = uuid;
            user.hashPassword = passwordHasher.HashPassword(user, user.password);
            user.password = String.Empty;  

            await diaryDbContext.AddAsync(role);
            await diaryDbContext.AddAsync(user);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task<string> Login(Login userModel)
        {
            var user = await diaryDbContext.user
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.email == userModel.email);

            if (user is null)
            {
                throw new Exception("Invalid login or password");
            }

            var checkPassword = passwordHasherLogin.VerifyHashedPassword(userModel, user.hashPassword, userModel.password);

            if (checkPassword == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid login or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.uuid.ToString()),
                new Claim(ClaimTypes.Name, user.email)
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

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
