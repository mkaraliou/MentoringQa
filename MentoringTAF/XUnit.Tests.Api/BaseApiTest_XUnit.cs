using Core.Api;
using Core.Api.ServiceHelpers;
using Core.Api.Services;
using Core.Configuration;

namespace XUnit.Tests.Api
{
    public class BaseApiTest_XUnit
    {
        protected SessionManager SessionManager { get; private set; }

        protected DashboardServiceHelper DashboardServiceHelper { get; private set; }

        protected DashboardService DashboardService { get; private set; }

        public static TestSettings TestConfiguration => ConfigurationHelper.GetApplicationConfiguration<TestSettings>();

        public BaseApiTest_XUnit()
        {
            SessionManager = new Lazy<SessionManager>(() => new SessionManager(TestConfiguration)).Value;
            DashboardServiceHelper = new Lazy<DashboardServiceHelper>(() => new DashboardServiceHelper(SessionManager)).Value;
            DashboardService = new Lazy<DashboardService>(() => new DashboardService(SessionManager)).Value;
        }
    }
}
