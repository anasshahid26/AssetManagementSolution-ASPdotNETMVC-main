using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;

namespace FAS.Services
{
    public class UserService : IUserService
    {
        UserAdapter userAdapter;

        public UserService()
        {
            userAdapter = new UserAdapter();
        }

        public IEnumerable<UserViewModel> GetUser(UserViewModel collection)
        {
            return userAdapter.GetUser(collection);
        }

        public void CreateUser(UserViewModel userViewModel)
        {
            userAdapter.CreateUser(userViewModel);
        }

        public UserViewModel EditUser(int UserID)
        {
            return userAdapter.EditUser(UserID);
        }

        public void EditUser(UserViewModel collection)
        {
            userAdapter.EditUser(collection);
        }

        public IEnumerable<PermissionSharedModel> GetAllPermission(PermissionSharedModel collection)
        {
            return userAdapter.GetAllPermissions(collection);
        }

        public void DeleteUser(int UserID)
        {
            userAdapter.DeleteUser(UserID);
        }

        public IEnumerable<PermissionSharedModel> GetPermissions(UserViewModel collection)
        {
            return userAdapter.GetPermissions(collection);
        }
        
        public UserViewModel ForgetPassword (UserViewModel collection)
        {
            return userAdapter.ForgetPassword(collection);
        }

        public string UsernameExsist(UserViewModel userViewModel)
        {
            return userAdapter.IsUserExsist(userViewModel);
        }

        public IEnumerable<UserActivityViewModel> GetUserLog(UserViewModel userViewModel)
        {
            return userAdapter.GetUserLog(userViewModel);
        }

        public string ChangePassword(PasswordViewModel collection)
        {
            return userAdapter.ChangePassword(collection);
        }
    }

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetUser(UserViewModel collection);
        void CreateUser(UserViewModel userViewModel);
        UserViewModel EditUser(int UserID);
        void EditUser(UserViewModel collection);
        void DeleteUser(int UserID);
        IEnumerable<PermissionSharedModel> GetAllPermission(PermissionSharedModel collection);
        IEnumerable<PermissionSharedModel> GetPermissions(UserViewModel collection);
        UserViewModel ForgetPassword(UserViewModel collection);
        string UsernameExsist(UserViewModel userViewModel);
        IEnumerable<UserActivityViewModel> GetUserLog(UserViewModel userViewModel);
        string ChangePassword(PasswordViewModel collection);
    }
}
