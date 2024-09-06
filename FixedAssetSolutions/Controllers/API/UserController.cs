using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
using FAS.SharedModel;
using FAS.Services;
using FAS.Data;

namespace FixedAssetSolutions.Controllers.API
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserService userService;
        private ILoginService loginService;
        public UserController()
            : this(new UserService(), new LoginService())
        {

        }
        public UserController(IUserService userService, ILoginService loginService)
        {
            this.userService = userService;
            this.loginService = loginService;
        }

        [HttpPost]
        public ResponseObject CreateUser(UserViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            userService.CreateUser(collection);
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetUsers(UserViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var AllUsers = userService.GetUser(collection);
            responseObject.Data = AllUsers;
            responseObject.Message = "All Users With respect to Country and Location";
            return responseObject;
        }
        [HttpPost]
        public ResponseObject Edit (UserViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            int UserID = collection.UserID;
            var editUserInfo = userService.EditUser(UserID);
            responseObject.Data = editUserInfo;
            responseObject.Message = "Edit Info";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject UpdateUser (UserViewModel collection)
        {
            ResponseObject responseObejct = new ResponseObject();
            userService.EditUser(collection);
            responseObejct.Data = null;
            responseObejct.Message = "User Updated Successfully";
            return responseObejct;
        }

        [HttpGet]
        public ResponseObject GetAllPermissions(PermissionSharedModel collection)
        {
            ResponseObject responseObejct = new ResponseObject();
            var permission = userService.GetAllPermission(collection);
            responseObejct.Data = permission ;
            responseObejct.Message = "All Permissions";
            return responseObejct;
        }

        [HttpPost]
        public ResponseObject GetUserLog(UserViewModel userViewModel)
        {
            var UserLog = userService.GetUserLog(userViewModel);
            ResponseObject UserActivityLog = new ResponseObject();
            UserActivityLog.Message = "User Log";
            UserActivityLog.Data =  UserLog;
            return UserActivityLog;
        }

        [HttpPost]
        public ResponseObject IsUserExsist(UserViewModel userViewModel)
        {
            var UserCode = userService.UsernameExsist(userViewModel);
            ResponseObject userCodeExsist = new ResponseObject();
            userCodeExsist.Message = UserCode;
            userCodeExsist.Data = null;
            return userCodeExsist;
        }

        [HttpPost]
        public ResponseObject ChangePassword(PasswordViewModel collection)
        {
            var Password = userService.ChangePassword(collection);
            ResponseObject ChangePassword = new ResponseObject();
            ChangePassword.Message = Password;
            ChangePassword.Data = null;
            return ChangePassword;
        }
        [HttpPost]
        public ResponseObject UserAuthentication(LoginViewModel collection)
        {
            var Authentication = loginService.Authenticate(collection);
            ResponseObject result = new ResponseObject();
            result.Message = "User Authentication";
            result.Data = Authentication;
            return result;
        }
    }
}
