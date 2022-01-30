using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Perspective.Pages
{
    [Route("/denied")]
    public partial class Denied
    {
        [Inject] private NavigationManager NavManager { get; set; }

        private string _message;

        protected async override Task OnInitializedAsync()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("message", out var message))
            {
                _message = message.ToString();
            }

            await base.OnInitializedAsync();
        }
    }
}
