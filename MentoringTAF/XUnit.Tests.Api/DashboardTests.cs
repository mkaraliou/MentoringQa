using Tests.API.Helpers;

namespace XUnit.Tests.Api
{
    public class DashboardTests : BaseApiTest_XUnit
    {
        private const string ErrorMessage = "Dashboard with ID '{0}' not found on project";
        private const string DeletingMessage = "Dashboard with ID = '{0}' successfully deleted.";

        private List<string> _ids;
        private string _id;

        public DashboardTests()
        {
            var name = Faker.Name.First();
            var dashboardModel = CreateDataHelper.CreateRandomDashboardModel(name);

            _id = DashboardServiceHelper.CreateDashboard(dashboardModel)?.Id;

            _ids = new List<string>()
            {
                _id
            };
        }

        ~DashboardTests()
        {
            foreach (var id in _ids)
            {
                DashboardServiceHelper.DeleteDashboardById(id);
            }
        }

        [Fact]
        public void GetDashboard_XUnit()
        {
            var dashboard = DashboardServiceHelper.GetById(_id);

            Assert.NotNull(dashboard);
        }
    }
}