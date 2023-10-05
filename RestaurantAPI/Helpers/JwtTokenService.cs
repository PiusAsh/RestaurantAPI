using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Entity;
using System.Security.Cryptography;

public class JwtTokenService
{
    private readonly byte[] _key;

    public JwtTokenService()
    {
        // Generate a random key on class initialization
        _key = GenerateRandomKey(32); // 256 bits / 32 bytes
    }

    private byte[] GenerateRandomKey(int size)
    {
        byte[] key = new byte[size];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
        }
        return key;
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Email), // You can include other claims here
            }),
            Expires = DateTime.UtcNow.AddHours(24), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
