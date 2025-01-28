using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var signingKey = "abcdefghijklmnopqrstuvwxyz1234567890";// Use the signing key value from JWT Settings page.
var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

var claims = new List<Claim>
{
    new Claim("sub", "420c5d51-1754-4a9b-b4b5-d5bfebb21b0f"), // Required
    new Claim("email", "john.doe@example.com"), // Required
    new Claim("first_name", "John"), // Required
    new Claim("last_name", "Doe"), // Optional
    new Claim("phone", "1234567890") // Optional
};

var token = new JwtSecurityToken(claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

Console.WriteLine(new JwtSecurityTokenHandler().WriteToken(token));

Console.ReadKey();