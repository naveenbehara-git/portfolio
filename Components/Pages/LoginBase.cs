using Microsoft.AspNetCore.Components;
using MyPortfolio.Model;
using MyPortfolio.Model.DTOs;
using MyPortfolio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Components.Pages
{
    public class LoginBase : ComponentBase
    {
        public LoginModel loginModel = new LoginModel();
        public string errorMessage;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserAuthClient userClient { get; set; }

        public async Task HandleLogin()
        {
            if (loginModel.Username != null && loginModel.SecretKey != null)
            {
                var login = await userClient.Login(new LoginRequest() {UserName = loginModel.Username,Password = loginModel.SecretKey, OrgId = 1 });
                if (login != null && !string.IsNullOrEmpty(login.accessToken) && !string.IsNullOrEmpty(login.refreshToken))
                {
                    NavigationManager.NavigateTo("/profile");
                }
                else
                {
                    errorMessage = "Invalid credentials..!";
                }
            }
            else
                errorMessage = "please enter username and password..!";
        }

    }
}
