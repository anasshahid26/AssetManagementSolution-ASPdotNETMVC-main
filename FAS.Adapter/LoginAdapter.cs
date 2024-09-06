using FAS.Infrastructure.Repository;
using FAS.Infrastructure.Common;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using FAS.Data;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Adapter
{
    public class LoginAdapter
    {
        
        private IUserRepository UserRepository;
        private IActivityLogRepository ActivityLogRepository;
        private IUnityOfWork unitOfWork;

        public LoginAdapter()
        {
            unitOfWork = new UnityOfWork(new DatabaseFactory());
            UserRepository = new UserRepository(unitOfWork.instance);
            
            ActivityLogRepository = new ActivityLogRepository(unitOfWork.instance);

        }

        public void Logout(LoginViewModel loginViewModel)
        {
            User_Activity Activity = new User_Activity()
            {
                UserID = loginViewModel.UserID,
                Activity = "Logged Out",
                ActivityTime = DateTime.Now
            };
            ActivityLogRepository.Add(Activity);
            unitOfWork.Commit();
        }

        public LoginViewModel Aunthenticate(LoginViewModel loginViewModel)
        {
            //SELECT u.UserName, u.Password, u.Email, u.Company_Name, ar.RoleName, uc.L1LocCode, uc.CompanyID FROM Users u INNER JOIN UserRoles ur on u.UserID = ur.UserID INNER JOIN AssetRoles ar on ur.RoleID = ar.RoleID inner join UserCompany uc on u.UserID = uc.UserID where u.UserName = 'shahraiz.k' AND u.Password = '123'
            var result1 = (from users in unitOfWork.db.Users
                           join userRoles in unitOfWork.db.UserRoles on users.UserID equals userRoles.UserID
                           join assetRoles in unitOfWork.db.AssetRoles on userRoles.RoleID equals assetRoles.RoleID
                           join userCompany in unitOfWork.db.UserCompanies on users.UserID equals userCompany.UserID
                           where users.UserName == loginViewModel.UserName && users.Password == loginViewModel.Password
                           select users).ToList();

            var result2 = (from users in unitOfWork.db.Users
                           join userRoles in unitOfWork.db.UserRoles on users.UserID equals userRoles.UserID
                           where users.UserName == loginViewModel.UserName && users.Password == loginViewModel.Password
                           select users).ToList();

            //var result = (from users in unitOfWork.db.Users
            //              where users.UserName == loginViewModel.UserName && users.Password == loginViewModel.Password
            //              select users).ToList();
            if (result1.Count > 0)
            {
                var model = result1.FirstOrDefault();

                if (model.UserCompanies.FirstOrDefault().L1LocCode == null)
                {
                    var permissions = (from userperm in unitOfWork.db.UserRoles where userperm.UserID == model.UserID select userperm).ToList();
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
                    LoginViewModel viewmodel = new LoginViewModel()
                    {
                        UserID = model.UserID,
                        UserName = model.UserName,
                        Password = model.Password,
                        Email = model.Email,
                        L1LocCode = model.UserCompanies.FirstOrDefault().L1LocCode,
                        L1LocName = "All Locations",
                        CompanyID = model.UserCompanies.FirstOrDefault().CompanyID,
                        CompanyActive = model.UserCompanies.FirstOrDefault().AssetCompany.Active,
                        LocationActive = model.UserCompanies.FirstOrDefault().AssetLocation.Active,
                        Active = model.Active,
                        Role = model.UserRoles.FirstOrDefault().AssetRole.RoleName,
                        CompanyName = model.UserCompanies.FirstOrDefault().AssetCompany.CompanyName,
                        Permissions = per
                    };
                    User_Activity Activity = new User_Activity()
                    {
                        UserID = model.UserID,
                        Activity = "Logged In",
                        ActivityTime = DateTime.Now
                    };
                    ActivityLogRepository.Add(Activity);
                    unitOfWork.Commit();
                    return viewmodel;
                }
                else
                {
                    var permissions = (from userperm in unitOfWork.db.UserRoles where userperm.UserID == model.UserID select userperm).ToList();
                    List<PermissionSharedModel> per = new List<PermissionSharedModel>();
                    foreach (var perms in permissions)
                    {
                        //var permisionid = Convert.ToString(perms.PermissionID);
                        var permisionedit = Convert.ToString(perms.IsEdit);
                        per.Add(new PermissionSharedModel
                        {

                            PermissionName = (permisionedit),
                            PermissionID = (perms.PermissionID),
                            Permission = perms.AssetPermission.PermissionName
                        });
                    }
                    LoginViewModel viewmodel = new LoginViewModel()
                    {
                        UserID = model.UserID,
                        UserName = model.UserName,
                        Password = model.Password,
                        Email = model.Email,
                        L1LocCode = model.UserCompanies.FirstOrDefault().L1LocCode,
                        L1LocName = model.UserCompanies.FirstOrDefault().AssetLocation.L1LocName,
                        CompanyID = model.UserCompanies.FirstOrDefault().CompanyID,
                        CompanyActive = model.UserCompanies.FirstOrDefault().AssetCompany.Active,
                        LocationActive = model.UserCompanies.FirstOrDefault().AssetLocation.Active,
                        Active = model.Active,
                        Role = model.UserRoles.LastOrDefault().AssetRole.RoleName,
                        CompanyName = model.UserCompanies.FirstOrDefault().AssetCompany.CompanyName,
                        Permissions = per
                    };
                    User_Activity Activity = new User_Activity()
                    {
                        UserID = model.UserID,
                        Activity = "Logged In",
                        ActivityTime = DateTime.Now
                    };
                    ActivityLogRepository.Add(Activity);
                    unitOfWork.Commit();
                    return viewmodel;
                }
            }
            else if (result2.Count > 0)
            {
                var model = result2.FirstOrDefault();

                LoginViewModel viewmodel = new LoginViewModel()
                {
                    UserID = model.UserID,
                    UserName = model.UserName,
                    Password = model.Password,
                    Email = model.Email,
                    Role = model.UserRoles.FirstOrDefault().AssetRole.RoleName
                };
                User_Activity Activity = new User_Activity()
                {
                    UserID = model.UserID,
                    Activity = "Logged In",
                    ActivityTime = DateTime.Now
                };
                ActivityLogRepository.Add(Activity);
                unitOfWork.Commit();
                return viewmodel;
            }
            else
            {
                return loginViewModel;
            }
        }
    }
}
