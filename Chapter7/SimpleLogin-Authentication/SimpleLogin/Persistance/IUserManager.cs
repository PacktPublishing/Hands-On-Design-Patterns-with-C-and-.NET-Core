using System.Collections.Generic;
using SimpleLogin.Models;

namespace SimpleLogin.Persistance
{
    public interface IUserManager
    {
        bool Add(User user, string userPassword);
        bool Login(LoginViewModel authRequest);
        User FindBy(LoginViewModel authRequest);
        IEnumerable<User> Get(string searchTerm, bool isActive = true);
        User GetBy(string userId);
    }
}