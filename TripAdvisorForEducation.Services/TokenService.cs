using System.Security.Cryptography;
using System.Text;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(int size)
        {
            var charSet = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var chars = charSet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();

            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);

            var result = new StringBuilder(size);

            foreach (var b in data)
                result.Append(chars[b % (chars.Length)]);

            return result.ToString();
        }
    }
}
