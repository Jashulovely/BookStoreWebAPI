using ModelLayer;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IUserBusiness
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
