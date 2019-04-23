using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SimpleLogin.Contexts;
using SimpleLogin.Models;

namespace SimpleLogin.Persistance
{
    public class UserManager : IUserManager
    {
        private readonly InventoryContext _context;

        public UserManager(InventoryContext context) => _context = context;

        public bool Add(User user, string userPassword)
        {
            var newUser = CreateUser(user, userPassword);
            _context.Users.Add(newUser);
            return _context.SaveChanges() > 0;
        }

        public bool Login(LoginViewModel authRequest) => FindBy(authRequest) != null;

        public User GetBy(string userId) => _context.Users.Find(userId);

        public User FindBy(LoginViewModel authRequest)
        {
            var user = Get(authRequest.Username).FirstOrDefault();
            if (user == null) return null;//throw new ArgumentException("You are not registered with us.");
            return VerifyPasswordHash(authRequest.Password, user.PasswordHash, user.PasswordSalt) ? user : null;
            //throw new ArgumentException("Incorrect username or password.");
        }
        public IEnumerable<User> Get(string searchTerm, bool isActive = true)
        {
            return _context.Users.Where(x =>
                x.UserName == searchTerm.ToLower() || x.Mobile == searchTerm ||
                x.EmailId == searchTerm.ToLower() && x.IsActive == isActive);
        }
        
        private User CreateUser(User userModel, string userPassword)
        {
            var userName = CreateUserName(userModel.FirstName, userModel.LastName);
            var password = CreatePasswordHash(userPassword);
            userModel.UserName = userName;
            userModel.PasswordHash = password.Item1;
            userModel.PasswordSalt = password.Item2;
            userModel.SecretKey = string.Empty;
            //Generate OTP and set their expiration time
            userModel.EmailToken = GenerateOTP();
            userModel.EmailTokenDateTime = DateTime.UtcNow.AddMinutes(7);
            userModel.OTP = GenerateOTP(true);
            userModel.OtpDateTime = DateTime.UtcNow.AddMinutes(7);

            userModel.IsEmailVerified = false;
            userModel.IsMobileVerified = false;
            userModel.IsActive = true; //activate account on registration
            return userModel;
        }

        private Tuple<byte[], byte[]> CreatePasswordHash(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            byte[] passwordSalt;
            byte[] passwordHash;
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
        }

        private string CreateUserName(string firstName, string lastName)
        {
            //refine thie logic
            var userName = $"{lastName}{firstName.Substring(0, 1)}";
            var user = GetUserBy(userName);
            var enumerable = user.ToList();
            return enumerable.Any() ? $"{userName}{enumerable.Count}" : userName;
        }

        private IEnumerable<User> GetUserBy(string userName)
        {
            return _context.Users.Where(x =>
                string.Equals(x.UserName, userName, StringComparison.CurrentCultureIgnoreCase));
        }

        private string GenerateOTP(bool tokenForEmail = false)
        {
            var rn = new Random();
            return tokenForEmail ? rn.Next(8).ToString() : rn.Next(6).ToString();
        }


        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            if (passwordHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).",
                    nameof(passwordHash));
            if (passwordSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).",
                    nameof(passwordSalt));

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (computedHash.Where((t, i) => t != passwordHash[i]).Any()) return false;
            }

            return true;
        }
    }
}