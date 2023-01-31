using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AI.Finder.BE.Service.Features.User.Authatication;
public class AuthenticationManager{
    public Boolean IsPasswordVerified(string salt, string hash, string password){
        string passwordHash = hash;
        byte[] Salt = Convert.FromBase64String(salt);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        if (hashed == passwordHash)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
