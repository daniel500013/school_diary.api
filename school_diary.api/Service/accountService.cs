using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

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

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(auth.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.uuid.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
