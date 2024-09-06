using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel;
using FAS.Data;
using System.Text.RegularExpressions;

namespace FAS.Adapter
{
    public class UserAdapter
    {
        private IUserRepository userRepsoitory;
        private IUserCompanyRepository userCompanyRepository;
        private IUserRoleRepository userRoleRepository;
        private IAssetPermissionsRepository assetPermissionRepository;
        private IUnityOfWork unityOfWork;

        public UserAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            userRepsoitory = new UserRepository(unityOfWork.instance);
            userCompanyRepository = new UserCompanyRepository(unityOfWork.instance);
            userRoleRepository = new UserRoleRepository(unityOfWork.instance);
            assetPermissionRepository = new AssetPermissionsRepository(unityOfWork.instance);
        }



        public void CreateUser(UserViewModel userViewModel)
        {
            User user = new User()
            {
                UserName = userViewModel.UserName,
                Password = userViewModel.Password,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email,
                Note = userViewModel.Note,
                Active = userViewModel.Active,
                CreatedOn = DateTime.Now,
                CreatedBy = userViewModel.CreatedBy
            };
            userRepsoitory.Add(user);
            unityOfWork.Commit();

            userViewModel.UserID = user.UserID;
            var roleID = 2;
            foreach (var item in userViewModel.Permissions)
            {

                string[] perm = item.PermissionName.Split(',');
                int permissionID = Convert.ToInt16(perm[0]);
                string permissionValue = perm[1];

                if (permissionValue == "edit")
                {

                    if (permissionID == 12 || permissionID == 13)
                    {
                        roleID = 4;
                    }
                    bool edit = true;
                    UserRole userRole = new UserRole()
                    {
                        UserID = userViewModel.UserID,
                        RoleID = roleID,
                        PermissionID = permissionID,
                        IsEdit = edit,
                        IsView = true
                    };
                    userRoleRepository.Add(userRole);
                    unityOfWork.Commit();
                }
                else
                {
                    bool edit = false;
                    UserRole userRole = new UserRole()
                    {
                        UserID = userViewModel.UserID,
                        RoleID = roleID,
                        PermissionID = permissionID,
                        IsEdit = edit,
                        IsView = true
                    };
                    userRoleRepository.Add(userRole);
                    unityOfWork.Commit();
                }
            }

            CreateUserCompany(userViewModel);
        }

        public void CreateUserCompany(UserViewModel userViewModel)
        {
            string[] locations = Regex.Split(userViewModel.L1LocCode, ",");

            foreach (var item in locations)
            {
                UserCompany userCompany = new UserCompany()
                {
                    UserID = userViewModel.UserID,
                    CompanyID = userViewModel.CompanyID,
                    L1LocCode = item
                };
                userCompanyRepository.Add(userCompany);
            }
            unityOfWork.Commit();
        }

        public IEnumerable<PermissionSharedModel> GetPermissions(UserViewModel collection)
        {
            //select USERID, ap.PermissionID, ap.PermissionName, ur.IsEdit from UserRoles ur inner join AssetPermissions ap on ur.PermissionID = ap.PermissionID where USERID = 98;
            var getPermissions = (from ur in unityOfWork.db.UserRoles join ap in unityOfWork.db.AssetPermissions on ur.PermissionID equals ap.PermissionID where ur.UserID == collection.UserID select ur).ToList();
            List<PermissionSharedModel> ps = new List<PermissionSharedModel>();
            foreach (var item in getPermissions)
            {
                ps.Add(new PermissionSharedModel
                {
                    PermissionID = item.PermissionID,
                    PermissionName = item.AssetPermission.PermissionName,
                    Permission = item.IsEdit.ToString()
                });
            }
            return ps;
        }

        public IEnumerable<UserViewModel> GetUser(UserViewModel collection)
        {
            var users = (from user in unityOfWork.db.UserCompanies
                         join userInfo in unityOfWork.db.Users
                         on user.UserID equals userInfo.UserID
                         where user.CompanyID == collection.CompanyID && user.L1LocCode == collection.L1LocCode
                         select userInfo).ToList();
            if (users.Count == 0)
            {
                users = (from user
                         in unityOfWork.db.UserCompanies
                         join userInfo
                         in unityOfWork.db.Users
                         on user.UserID
                         equals userInfo.UserID
                         where user.CompanyID == collection.CompanyID && user.L1LocCode == null
                         select userInfo).ToList();

                List<UserViewModel> userList = new List<UserViewModel>();

                foreach (var item in users)
                {
                    userList.Add(new UserViewModel
                    {
                        UserID = item.UserID,
                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email
                    });
                }
                return userList;
            }
            else
            {
                List<UserViewModel> userList = new List<UserViewModel>();

                foreach (var item in users)
                {
                    userList.Add(new UserViewModel
                    {
                        UserID = item.UserID,
                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email
                    });
                }
                return userList;
            }
        }

        public UserViewModel EditUser(int UserID)
        {
            var getUser = (from user in unityOfWork.db.Users join userComp in unityOfWork.db.UserCompanies on user.UserID equals userComp.UserID where user.UserID == UserID select user);
            //var getUser = userRepsoitory.GetById(UserID);
            var permissions = (from userperm in unityOfWork.db.UserRoles where userperm.UserID == UserID select userperm).ToList();
            List<PermissionSharedModel> per = new List<PermissionSharedModel>();
            foreach (var perms in permissions)
            {
                //var permisionid = Convert.ToString(perms.PermissionID);
                var permisionedit = Convert.ToString(perms.IsEdit);
                per.Add(new PermissionSharedModel
                {

                    PermissionName = (permisionedit),
                    PermissionID = (perms.PermissionID)
                });
            }

            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (var loc in getUser.FirstOrDefault().UserCompanies)
            {
                locations.Add(new LocationViewModel
                {
                    L1LocCode = loc.L1LocCode
                });
            }

            UserViewModel userInfo = new UserViewModel();
            userInfo.UserID = getUser.FirstOrDefault().UserID;
            userInfo.UserName = getUser.FirstOrDefault().UserName;
            userInfo.FirstName = getUser.FirstOrDefault().FirstName;
            userInfo.LastName = getUser.FirstOrDefault().LastName;
            userInfo.Email = getUser.FirstOrDefault().Email;
            userInfo.Password = getUser.FirstOrDefault().Password;
            userInfo.Note = getUser.FirstOrDefault().Note;
            userInfo.Active = getUser.FirstOrDefault().Active;
            userInfo.Permissions = per;
            userInfo.CompanyID = getUser.FirstOrDefault().UserCompanies.FirstOrDefault().CompanyID;
            userInfo.Locations = locations;

            return userInfo;
        }

        public void EditUser(UserViewModel collection)
        {
            try
            {
                var UserID = collection.UserID;
                var getUser = userRepsoitory.GetById(UserID);
                getUser.UserID = collection.UserID;
                getUser.UserName = collection.UserName;
                getUser.FirstName = collection.FirstName;
                getUser.LastName = collection.LastName;
                getUser.Email = collection.Email;
                getUser.Password = collection.Password;
                getUser.Note = collection.Note;
                getUser.Active = collection.Active;

                userCompanyRepository.Delete(x => x.UserID == collection.UserID);

                string[] locations = Regex.Split(collection.L1LocCode, ",");

                foreach (var item in locations)
                {
                    UserCompany userCompany = new UserCompany()
                    {
                        UserID = collection.UserID,
                        CompanyID = collection.CompanyID,
                        L1LocCode = item
                    };
                    userCompanyRepository.Add(userCompany);
                }
                //unityOfWork.Commit();
                foreach (var itemPermissionID in collection.Permissions)
                {
                    string[] perm = itemPermissionID.PermissionName.Split(',');
                    int permissionID = Convert.ToInt16(perm[0]);

                    var query =
                        (from ur in unityOfWork.db.UserRoles
                         where ur.UserID == UserID
                         && ur.PermissionID == permissionID
                         select ur).ToList();

                    if (query.Count == 0)
                    {
                        #region Commit

                        UserRole ur = new UserRole();

                        ur.UserID = UserID;
                        ur.PermissionID = permissionID;
                        ur.RoleID = 2;
                        ur.IsEdit = false;
                        ur.IsView = true;

                        try
                        {
                            userRoleRepository.Add(ur);
                            unityOfWork.Commit();
                            //unityOfWork.Commit();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        #endregion


                    }



                }
                //UserRole userViewModel = new UserRole();

                //userViewModel.UserID = UserID;
                //var roleID = 2;
                //foreach (var item in collection.Permissions)
                //{

                //    string[] perm = item.PermissionName.Split(',');
                //    int permissionID = Convert.ToInt16(perm[0]);
                //    string permissionValue = perm[1];

                //    if (permissionValue == "edit")
                //    {

                //        if (permissionID == 12 || permissionID == 13)
                //        {
                //            roleID = 4;
                //        }
                //        bool edit = true;
                //        UserRole userRole = new UserRole()
                //        {
                //            UserID = userViewModel.UserID,
                //            RoleID = roleID,
                //            PermissionID = permissionID,
                //            IsEdit = edit,
                //            IsView = true
                //        };
                //        userRoleRepository.Add(userRole);
                //        unityOfWork.Commit();
                //    }
                //    else
                //    {
                //        bool edit = false;
                //        UserRole userRole = new UserRole()
                //        {
                //            UserID = userViewModel.UserID,
                //            RoleID = roleID,
                //            PermissionID = permissionID,
                //            IsEdit = edit,
                //            IsView = true
                //        };
                //        userRoleRepository.Add(userRole);
                //        unityOfWork.Commit();
                //    }
                //}


                var getUserpermissions = (from ur in unityOfWork.db.UserRoles where ur.UserID == UserID select ur).ToList();
                foreach (var items in getUserpermissions)
                {
                    foreach (var item in collection.Permissions)
                    {
                        string[] perm = item.PermissionName.Split(',');
                        int permissionID = Convert.ToInt16(perm[0]);
                        string permissionValue = perm[1];
                        if (items.PermissionID == permissionID)
                        {
                            if (permissionValue == "edit")
                            {
                                items.IsEdit = true;
                                items.IsView = false;
                            }
                            else
                            {
                                items.IsEdit = false;
                                items.IsView = true;
                            }

                        }
                    }
                }
                userRepsoitory.Update(getUser);
                unityOfWork.Commit();
            }
            catch (Exception ex)
            {

            }
        }

        public IEnumerable<PermissionSharedModel> GetAllPermissions(PermissionSharedModel permissionViewModel)
        {
            var permissions = assetPermissionRepository.GetAll().OrderBy(x => x.SortOrder).ToList();
            List<PermissionSharedModel> result = new List<PermissionSharedModel>();            

            foreach (var item in permissions)
            {
                result.Add(new PermissionSharedModel
                {
                    PermissionID = item.PermissionID,
                    PermissionName = item.PermissionName
                });
            }
            return result;
        }

        public UserViewModel ForgetPassword(UserViewModel userViewModel)
        {
            var user = userRepsoitory.Get(x => x.Email == userViewModel.Email);
            if (user != null)
            {
                UserViewModel userPassword = new UserViewModel();
                userPassword.UserName = user.UserName;
                userPassword.Email = user.Email;
                userPassword.Password = user.Password;
                return userPassword;
            }
            return userViewModel;
        }

        public string IsUserExsist(UserViewModel userViewModel)
        {
            var userName = (from user in unityOfWork.db.Users where user.UserName == userViewModel.UserName select user.UserName).ToList();
            if (userName.Count > 0)
            {
                return "Username Exsist";
            }
            else
            {
                return "Username does not Exsist";
            }
        }

        public IEnumerable<UserActivityViewModel> GetUserLog(UserViewModel userViewModel)
        {
            var userLog = (from userlog in unityOfWork.db.User_Activity where userlog.UserID == userViewModel.UserID select userlog).ToList();
            List<UserActivityViewModel> Log = new List<UserActivityViewModel>();

            if (userLog.Count > 0)
            {
                Char delimeter = ' ';
                foreach (var item in userLog)
                {
                    string DateTime = item.ActivityTime.ToString();
                    String[] substrings = DateTime.Split(delimeter);
                    Log.Add(new UserActivityViewModel
                    {
                        UserName = item.User.UserName,
                        Activity = item.Activity,
                        Date = substrings[0],
                        Time = substrings[1] + substrings[2]
                    });
                }
                return Log;
            }
            return Log;
        }

        public string ChangePassword(PasswordViewModel collection)
        {
            var user = userRepsoitory.GetById(collection.UserID);

            if (user.Password == collection.OldPassword)
            {
                user.Password = collection.Password;
                userRepsoitory.Update(user);
                unityOfWork.Commit();
                return "Password Changed Successfully";
            }
            else
            {
                return "Password Does Not Match";
            }
        }

        public void DeleteUser(int UserID)
        {
            userRepsoitory.Delete(userRepsoitory.GetById(UserID));
            unityOfWork.Commit();
        }

    }
}
