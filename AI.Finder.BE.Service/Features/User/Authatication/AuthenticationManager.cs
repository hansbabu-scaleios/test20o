using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AI.Finder.BE.Service.Features.User.Authatication;
    public class AuthenticationManager
    {
        //private readonly FinderDbContext _context;
        public Boolean IsPasswordVerified(/*string userId, string salt,*/UserModel user, string password){
            //var user = _context.Users.Where(e => e.UserId == userId).FirstOrDefault();
            string passwordHash = user.PasswordHash;
            byte[] Salt = Convert.FromBase64String(user.PassowrdSalt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: Salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
            Boolean match;
            if(hashed == passwordHash){
                match = true;
            }else{
                match = false;
            }
            return match;
    }
    }
