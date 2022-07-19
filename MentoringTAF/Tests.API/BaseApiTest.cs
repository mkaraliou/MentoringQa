using Core;
using Core.Api;
using Core.Api.ServiceHelpers;
using Core.Api.Services;

namespace Tests.API
{
    public abstract class BaseApiTest : BaseTest
    {
        protected SessionManager SessionManager { get; private set; }

        protected DashboardServiceHelper DashboardServiceHelper { get; private set; }

        protected DashboardService DashboardService { get; private set; }

        [SetUp]
        public void SettingServiceHelpers()
        {
            SessionManager = new Lazy<SessionManager>(() => new SessionManager(TestConfiguration)).Value;
            DashboardServiceHelper = new Lazy<DashboardServiceHelper>(() => new DashboardServiceHelper(SessionManager)).Value;
            DashboardService = new Lazy<DashboardService>(() => new DashboardService(SessionManager)).Value;
        }
    }
}
