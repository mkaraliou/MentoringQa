using RestSharp;

namespace Core.Api.Services
{
    public class DashboardService : BaseService
    {
        public DashboardService(SessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public IRestResponse Create(string body)
        {
            IRestClient client = SessionManager.RestClient;
            IRestRequest request = SessionManager.RestRequest;

            request.Method = Method.POST;
            request.Resource = $"/v1/{ProjectName}/dashboard";

            request.AddHeader("Accept", "*/*");

            request.AddJsonBody(body);

            return client.Execute(request);
        }

        public IRestResponse GetById(string id)
        {
            IRestClient client = SessionManager.RestClient;
            IRestRequest request = SessionManager.RestRequest;

            request.Method = Method.GET;
            request.Resource = $"/v1/{ProjectName}/dashboard/{id}";

            request.AddHeader("Accept", "*/*");

            return client.Execute(request);
        }

        public IRestResponse DeleteById(string id)
        {
            IRestClient client = SessionManager.RestClient;
            IRestRequest request = SessionManager.RestRequest;

            request.Method = Method.DELETE;
            request.Resource = $"/v1/{ProjectName}/dashboard/{id}";

            request.AddHeader("Accept", "*/*");

            return client.Execute(request);
        }
    }
}
