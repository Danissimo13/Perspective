using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Perspective.Managers;
using Perspective.Storage.Models;
using Perspective.ViewModels;
using System;
using System.Threading.Tasks;


namespace Perspective.Pages
{
    [AllowAnonymous]
    [Route("/reg")]
    public partial class Registration
    {
        private readonly RegistrationViewModel _registrationData;
        private readonly RegistrationResult _registrationResult;

        public Registration()
        {
            _registrationData = new RegistrationViewModel();
            _registrationResult = new RegistrationResult();
        }

        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private NavigationManager NavManager { get; set; }
        [Inject] private IUserManager UserManager { get; set; }
        [Inject] private ILogger<Registration> Logger { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                Uri uri = NavManager.ToAbsoluteUri(NavManager.Uri);
                if(QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var returnUrl))
                {
                    NavManager.NavigateTo(returnUrl);
                }
                else
                {
                    NavManager.NavigateTo("/");
                }
            }

            await base.OnInitializedAsync();
        }

        private async Task RegistrationAsync()
        {
            var newUser = new User()
            {
                FirstName = _registrationData.FirstName,
                LastName = _registrationData.LastName,
                Email = _registrationData.Email
            };

            bool registered = await UserManager.TryRegistrationAsync(newUser, _registrationData.Password);
            if(registered) 
            {
                _registrationResult.Message = "User has been successfully registered.";
                _registrationResult.CssClass = "success";

                Logger.LogInformation("Registration for {email}", _registrationData.Email);
            }
            else
            {
                _registrationResult.Message = $"User with email: {_registrationData.Email} already registered.";
                _registrationResult.CssClass = "error";
            }
        }
    }

    internal class RegistrationResult
    {
        public string Message { get; set; }

        public string CssClass { get; set; }
    }
}
