using System.Security.Cryptography;
using Mapster;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AI.Finder.BE.Service.Features.User;
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase{
        private readonly FinderDbContext _context;
        public UserController(FinderDbContext context){
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id){
            try{
                var user = await _context.Users
                    .Where(e => e.Id == id)
                    .ProjectToType<UserResponseDTO>()
                    .FirstOrDefaultAsync();
                if(user == null){
                return BadRequest();
                }
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        /*
        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId){
            try{
                var user = await _context.Users
                    .Where(e => e.UserId == userId)
                    .ProjectToType<UserResponseDTO>()
                    .FirstOrDefaultAsync();
                if(user == null){
                return BadRequest();
                }
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        [HttpGet("emailId/{emailId}")]
        public async Task<IActionResult> GetByMail(string emailId){
            try{
                var user = await _context.Users
                    .Where(e => e.EmailId == emailId)
                    .ProjectToType<UserResponseDTO>()
                    .FirstOrDefaultAsync();
                if(user == null){
                return BadRequest();
                }
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        [HttpGet("phoneNumber/{phoneNo}")]
        public async Task<IActionResult> GetByMail(long phoneNo){
            try{
                var user = await _context.Users
                    .Where(e => e.PhoneNumber == phoneNo)
                    .ProjectToType<UserResponseDTO>()
                    .FirstOrDefaultAsync();
                if(user == null){
                return BadRequest();
                }
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        */
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTO userRequestDTO){
            try{
                string password = userRequestDTO.Password;
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                string Salt = Convert.ToBase64String(salt);
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                var user = new UserModel{
                UserId = userRequestDTO.UserId,
                EmailId = userRequestDTO.EmailId,
                PhoneNumber = userRequestDTO.PhoneNumber,
                PasswordHash = hashed,
                PassowrdSalt = Salt,
                /*
                EmailConfirmationToken = userRequestDTO.EmailConfirmationToken,
                EmailTokenGeneratedTimestamp = userRequestDTO.EmailTokenGeneratedTimestamp,
                PhoneConfirmationToken = userRequestDTO.PhoneConfirmationToken,
                PhoneTokenGeneratedTimestamp = userRequestDTO.PhoneTokenGeneratedTimestamp
                */
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByUserId(long id, UserRequestDTO userRequestDTO){
            string password = userRequestDTO.Password;
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                string Salt = Convert.ToBase64String(salt);
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
           var user = await _context.Users
                        .Where(e => e.Id == id)
                        .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
            }
            user.UserId = userRequestDTO.UserId;
            user.EmailId = userRequestDTO.EmailId;
            user.PhoneNumber = userRequestDTO.PhoneNumber;
            user.PasswordHash = hashed;
            user.PassowrdSalt = Salt;
            /*
            user.EmailConfirmationToken = userRequestDTO.EmailConfirmationToken;
            user.EmailTokenGeneratedTimestamp = userRequestDTO.EmailTokenGeneratedTimestamp;
            user.PhoneConfirmationToken = userRequestDTO.PhoneConfirmationToken;
            user.PhoneTokenGeneratedTimestamp = userRequestDTO.PhoneTokenGeneratedTimestamp;
            */
            try{
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                return BadRequest(ex);
            }
            return Ok();
        }
        /*
        [HttpPut("userId/{userId}")]
        public async Task<IActionResult> UpdateByUserId(string userId, UserRequestDTO userRequestDTO){
           var user = await _context.Users
                        .Where(e => e.UserId == userId)
                        .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
            }
            user.UserId = userRequestDTO.UserId;
            user.EmailId = userRequestDTO.EmailId;
            user.PhoneNumber = userRequestDTO.PhoneNumber;
            user.PasswordHash = userRequestDTO.PasswordHash;
            user.PassowrdSalt = userRequestDTO.PassowrdSalt;
            user.EmailConfirmationToken = userRequestDTO.EmailConfirmationToken;
            user.EmailTokenGeneratedTimestamp = userRequestDTO.EmailTokenGeneratedTimestamp;
            user.PhoneConfirmationToken = userRequestDTO.PhoneConfirmationToken;
            user.PhoneTokenGeneratedTimestamp = userRequestDTO.PhoneTokenGeneratedTimestamp;
            try{
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpPut("emailId/{emailId}")]
        public async Task<IActionResult> UpdateByEmailId(string emailId, UserRequestDTO userRequestDTO){
           var user = await _context.Users
                        .Where(e => e.EmailId == emailId)
                        .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
            }
            user.UserId = userRequestDTO.UserId;
            user.EmailId = userRequestDTO.EmailId;
            user.PhoneNumber = userRequestDTO.PhoneNumber;
            user.PasswordHash = userRequestDTO.PasswordHash;
            user.PassowrdSalt = userRequestDTO.PassowrdSalt;
            user.EmailConfirmationToken = userRequestDTO.EmailConfirmationToken;
            user.EmailTokenGeneratedTimestamp = userRequestDTO.EmailTokenGeneratedTimestamp;
            user.PhoneConfirmationToken = userRequestDTO.PhoneConfirmationToken;
            user.PhoneTokenGeneratedTimestamp = userRequestDTO.PhoneTokenGeneratedTimestamp;
            try{
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                return BadRequest(ex);
            }
            return Ok();
        }
        [HttpPut("phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> UpdateByEmailId(long phoneNumber, UserRequestDTO userRequestDTO){
           var user = await _context.Users
                        .Where(e => e.PhoneNumber == phoneNumber)
                        .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
            }
            user.UserId = userRequestDTO.UserId;
            user.EmailId = userRequestDTO.EmailId;
            user.PhoneNumber = userRequestDTO.PhoneNumber;
            user.PasswordHash = userRequestDTO.PasswordHash;
            user.PassowrdSalt = userRequestDTO.PassowrdSalt;
            user.EmailConfirmationToken = userRequestDTO.EmailConfirmationToken;
            user.EmailTokenGeneratedTimestamp = userRequestDTO.EmailTokenGeneratedTimestamp;
            user.PhoneConfirmationToken = userRequestDTO.PhoneConfirmationToken;
            user.PhoneTokenGeneratedTimestamp = userRequestDTO.PhoneTokenGeneratedTimestamp;
            try{
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                return BadRequest(ex);
            }
            return Ok();
        }
        */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(long id){
            try{
            var user = await _context.Users
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
                }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }
        /*
        [HttpDelete("userId/{userId}")]
        public async Task<IActionResult> DeleteById(string userId){
            try{
            var user = await _context.Users
                .Where(e => e.UserId == userId)
                .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
                }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        [HttpDelete("emailId/{emailId}")]
        public async Task<IActionResult> DeleteByEmailId(string emailId){
            try{
            var user = await _context.Users
                .Where(e => e.EmailId == emailId)
                .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
                }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        [HttpDelete("phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> DeleteByPhoneNumber(long phoneNumber){
            try{
            var user = await _context.Users
                .Where(e => e.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
            if(user == null){
                return BadRequest();
                }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        */
    }
