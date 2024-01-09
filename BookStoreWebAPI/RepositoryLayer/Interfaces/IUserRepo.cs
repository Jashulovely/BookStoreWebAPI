using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepo
    {
        public UserModel UserRegistration(UserModel user);
        public IEnumerable<UserModel> GetAllUsers();
        public string UpdateUser(UserModel user);
        public string DeleteUser(int id);
        public string UserLogin(UserLoginModel login);
        public bool IsRegisteredAlready(string email);
        public string ForgetPassword(string EmailId);
        public string ResetNewPassword(string Email, string password, string confirmPassword);

    }
}
