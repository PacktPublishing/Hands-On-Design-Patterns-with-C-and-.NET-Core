using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLogin.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string SecretKey { get; set; }
        public string Mobile { get; set; }
        public string EmailToken { get; set; }
        public DateTime EmailTokenDateTime { get; set; }
        public string OTP { get; set; }
        public DateTime OtpDateTime { get; set; }
        public bool IsMobileVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string Roles { get; set; }//comma separated RoleIds
    }

    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
