using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectASP2023.JWT
{
    public class JwtManager
    {
        private BlogContext _blogContext;
        public JwtManager(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public string MakeToken(string username, string password)
        {
            var user = _blogContext.Users.Include(x => x.Role).ThenInclude(x=>x.RoleUseCases)
                .FirstOrDefault(x => x.Username == username && x.IsActive==true);
            if(user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var verified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (user == null || !verified)
            {
                throw new UnauthorizedAccessException();
            }

            //var useCases = _context.UserUseCase.Where(x => x.UserId == user.UserId).Select(x => x.UseCaseId);
            List<int> useCases = user.Role.RoleUseCases.Select(x => x.UseCaseId).ToList();
            var actor = new JwtUser
            {
                Id = user.Id,
                UseCaseIds = useCases,
                Identity = user.Username,
                Username = user.Username
            };

            var issuer = "AspIspit";
            var secret = "123ASDjfipoawopriqwop123124";

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)),
                new Claim("Username", user.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(10000),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
