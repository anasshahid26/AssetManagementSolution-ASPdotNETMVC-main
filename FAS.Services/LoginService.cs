using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;
namespace FAS.Services
{
    public class LoginService : ILoginService
    {
        LoginAdapter loginAdapter;

        public LoginService()
        {
            loginAdapter = new LoginAdapter();
        }

        public LoginViewModel Authenticate(LoginViewModel loginViewModel)
        {
            return loginAdapter.Aunthenticate(loginViewModel);
        }

        public void Logout(LoginViewModel loginViewModel)
        {
            loginAdapter.Logout(loginViewModel);
        }
    }

    public interface ILoginService
    {
        void Logout(LoginViewModel loginViewModel);
        LoginViewModel Authenticate(LoginViewModel loginViewModel);
    }
}
