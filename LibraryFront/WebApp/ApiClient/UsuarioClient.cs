using WebApp.Dto;
using WebApp.Models;

namespace WebApp.ApiClient
{
	public partial class LibraryApiClient
    {
        private const string ResourceUser = "Users";

        #region Main Methods

        public async Task<UsuarioModel.LoginUsuarioRequest?> LoginUser(UsuarioModel.LoginUsuarioRequest request)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"{ResourceUser}/login"), "useCookies=true&useSessionCookies=true");
            return await PostWithResponseBody(requestUrl, request);
        }

        #endregion


    }
}