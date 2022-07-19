using Core.Api.Services;
using Models;
using Models.ResponseModels;
using Newtonsoft.Json;

namespace Core.Api.ServiceHelpers
{
    public class DashboardServiceHelper : BaseServiceHelper
    {
        private readonly DashboardService _dashboardService;

        public DashboardServiceHelper(SessionManager sessionManager)
            : base(sessionManager)
        {
            _dashboardService = new DashboardService(sessionManager);
        }

        public DashboardModel GetById(string id)
        {
            var response = _dashboardService.GetById(id);

            return JsonConvert.DeserializeObject<DashboardModel>(response.Content);
        }

        public CreateDashboardResponse CreateDashboard(DashboardModel dashboardModel)
        {
            var dashboardJson = JsonConvert.SerializeObject(dashboardModel);

            var response = _dashboardService.Create(dashboardJson);

            return JsonConvert.DeserializeObject<CreateDashboardResponse>(response.Content);
        }

        public string DeleteDashboardById(string id)
        {
            var response = _dashboardService.DeleteById(id);

            return JsonConvert.DeserializeObject<DashboardResponse>(response.Content).Message;
        }
    }
}
