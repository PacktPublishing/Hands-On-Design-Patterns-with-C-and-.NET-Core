using System.Collections.Generic;
using SimpleLogin.Models;

namespace SimpleLogin.Persistance
{
    public interface IUserManager
    {
        bool Add(User user, string userPassword);
        bool Login(LoginViewModel authRequest);
        User GetBy(string userId);
        User FindBy(LoginViewModel authRequest);
        IEnumerable<User> Get(string searchTerm, bool isActive = true);
        IEnumerable<Role> GetRoles();
        IEnumerable<Role> GetRolesBy(string userId);
        string RoleNamesBy(string userId);
    }
}