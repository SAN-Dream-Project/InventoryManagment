using Inventory.Application.Shared.Authentications;
using Inventory.Application.Shared.Authentications.Dto;
using Inventory.EntityFramwork.Abstract.UserAndRoles.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Authentications
{
   public class Auth : IJwtAuth
        {
         private readonly string username = "nitingodase";
         private readonly string password = "123qwe";
         private readonly string key; 
         private readonly IUserRepository _userRepository;
         public Auth(string key)
         {
            this.key = key;
         }
         public TokenOutputDto Authentication(string username, string password)
         {
            TokenOutputDto tokenOutput =new TokenOutputDto();
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
               Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
               Expires = DateTime.UtcNow.AddHours(1),
               SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            tokenOutput.ExpireTime = tokenDescriptor.Expires;
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            tokenOutput.Token = tokenString;
            // 5. Return Token from method
            return tokenOutput;
         }
      }
   }
