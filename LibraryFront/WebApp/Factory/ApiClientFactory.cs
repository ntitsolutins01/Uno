using WebApp.ApiClient;
using WebApp.Utility;

namespace WebApp.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        private static string token;

        private static Lazy<LibraryApiClient> restClient = new Lazy<LibraryApiClient>(
            () => new LibraryApiClient(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
        }

        public static LibraryApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }

        public static LibraryApiClient InstanceAuthenticated
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
