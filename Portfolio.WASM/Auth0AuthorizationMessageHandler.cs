using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace Portfolio.WASM
{
    public class Auth0AuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public Auth0AuthorizationMessageHandler(IAccessTokenProvider tokenProvider, NavigationManager navigationManager, IConfiguration config) : base(tokenProvider, navigationManager)
        {
            this.ConfigureHandler(authorizedUrls: new[] { config["BaseUrl"], "http://localhost:5005", "https://djbportfolio.herokuapp.com/, https://api2.com" });
        }
    }
}
