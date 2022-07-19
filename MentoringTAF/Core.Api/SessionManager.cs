using Core.Configuration;
using RestSharp;

namespace Core.Api
{
    public class SessionManager
    {
        private readonly TestSettings _testSettings;

        public SessionManager(TestSettings testSettings)
        {
            _testSettings = testSettings;
        }

        public IRestClient RestClient
        {
            get
            {
                var client = new RestClient(_testSettings.BaseApiUrl)
                {
                    Timeout = 60000,
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslpolicyErrors) => true
                };
                return client;
            }
        }

        public IRestRequest RestRequest
        {
            get
            {
                var request = new RestRequest
                {
                    Timeout = 60000
                };

                request.AddHeader("authorization", "Bearer " + _testSettings.AccessToken);

                return request;
            }
        }
    }
}
