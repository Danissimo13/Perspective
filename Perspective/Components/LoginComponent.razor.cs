using Microsoft.AspNetCore.Components;
using Perspective.ViewModels;
using System.Web;

namespace Perspective.Components
{
    public partial class LoginComponent
    {
        private readonly LoginViewModel _loginData;

        private string cssClass;

        public LoginComponent()
        {
            _loginData = new LoginViewModel();
        }

        [Inject] private NavigationManager NavManager { get; set; }

        private static string Encode(string param)
        {
            return HttpUtility.UrlEncode(param);
        }
    }
}
