using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AI.Finder.BE.Service.Features.User.Authentication;
public class AuthenticationManager
{
    public static Boolean IsPasswordVerified(string passowrdSalt,string passwordHash, string password)
    {
        byte[] Salt = Convert.FromBase64String(passowrdSalt);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        Boolean match;
        if (hashed == passwordHash) {
            match = true;
        }
        else
        {
            match = false;
        }
        return match;
    }
}
