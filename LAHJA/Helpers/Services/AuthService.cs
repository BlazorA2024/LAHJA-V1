using ApexCharts;
using Blazorise.Extensions;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;

namespace LAHJA.Helpers.Services
{
  
    public class AuthService
    {
        private readonly TokenService tokenService;

        public AuthService(TokenService tokenService)
        {

            this.tokenService = tokenService;
            //this.PSession = pSession;

        }

    
        public async Task<bool> isAuth()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> isMyself()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task DeleteLoginAsync()
        {
            await tokenService.RemoveAllTokensAsync();
            await tokenService.DeleteTokenFromSessionAsync();
        }

        public async Task SaveLoginAsync(LoginResponse response)
        {
            if (response != null)
            {
                //await tokenService.RemoveAllTokensAsync();
                await tokenService.SaveAllTokensAsync(response.accessToken,
                                                     response.refreshToken,
                                                    response.expiresIn,
                                                    response.tokenType);

                await tokenService.SaveTokenInSessionAsync(response.accessToken);
               
            }
        }


    }
}
