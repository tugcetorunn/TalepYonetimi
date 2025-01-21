using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Abstractions;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Concretes
{
    public class TokenHandler : ITokenHandler
    {
        // jwt 4. adım token üretme fonksiyonu
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        public TokenHandler(IConfiguration _configuration, UserManager<ApplicationUser> _userManager)
        {
            configuration = _configuration;
            userManager = _userManager;
        }
        public async Task<Token> CreateJWTToken(int hours, string email, int userId)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:SecurityKey").Get<string>())); // securityKey in simetriğini alıyoruz.

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256); // şifrelenmiş kimliği oluşturuyoruz.

            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim> // her biri bir data tutar.
            {
                new Claim("userId", userId.ToString()), // Kullanıcı ID'sini ekledik. controller dan id ye erişmek için
                new Claim(JwtRegisteredClaimNames.Email, email), // token ın hangi email e ait olduğunu belirtmek için kullanılır. sub, email vs bu paketin kendi claimleri. biz de kendi claim imizi tanım layabiliriz.
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // token ları benzersiz yapan mekanizma (jti), her token için farklı bir jti değeri oluşturur.
                // new Claim("CompanyId", "110") // kendi claim lerimizi oluşturabiliriz.
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role))); // rolleri claim lere ekliyoruz.

            Token token = new();
            token.Expiration = DateTime.Now.AddHours(hours); // token oluşturulurken süresi verilecek.

            // token ayarlamaları, program.cs de verilen değerlerle uymalı.
            JwtSecurityToken securityToken = new(
                audience: configuration.GetSection("JWT:Audience").Get<string>(),
                issuer: configuration.GetSection("JWT:Issuer").Get<string>(),
                expires: token.Expiration,
                claims: claims,
                notBefore: DateTime.Now, // üretildiği anda kullanılabilsin
                signingCredentials: signingCredentials);

            // token oluşturma
            JwtSecurityTokenHandler handler = new();
            token.JWTToken = handler.WriteToken(securityToken);
            return token;
        }
    }
}
