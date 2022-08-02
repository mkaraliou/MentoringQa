using Models.ResponseModels;
using Newtonsoft.Json;
using Serilog;
using Tests.API.Helpers;

namespace XUnit.Tests.Api
{
    public class DashboardTests : BaseApiTest_XUnit, IDisposable
    {
        private const string ErrorMessage = "Dashboard with ID '{0}' not found on project";
        private const string DeletingMessage = "Dashboard with ID = '{0}' successfully deleted.";

        private List<string> _ids;
        private string _id;

        public DashboardTests()
        {
            Log.Logger.Information("Setup DashboardTests");

            var name = Faker.Name.First();
            var dashboardModel = CreateDataHelper.CreateRandomDashboardModel(name);

            _id = DashboardServiceHelper.CreateDashboard(dashboardModel)?.Id;

            _ids = new List<string>()
            {
                _id
            };
        }

        public void Dispose()
        {
            Log.Logger.Information("TearDown DashboardTests");


            foreach (var id in _ids)
            {
                DashboardServiceHelper.DeleteDashboardById(id);
            }
        }

        [Fact]
        public void GetDashboard_XUnit()
        {
            Log.Logger.Information("Start GetDashboard_XUnit");

            var dashboard = DashboardServiceHelper.GetById(_id);

            Assert.NotNull(dashboard);
        }

        [Fact]
        public void CreateDashboard()
        {
            Log.Logger.Information("Start CreateDashboard");


            var name = Faker.Name.First();
            var dashboardModel = CreateDataHelper.CreateRandomDashboardModel(name);

            var id = DashboardServiceHelper.CreateDashboard(dashboardModel)?.Id;

            Assert.NotNull(id);

            _ids.Add(id);
        }

        [Fact]
        public void DeleteDashboard()
        {
            Log.Logger.Information("Start DeleteDashboard");

            var responseMessage = DashboardServiceHelper.DeleteDashboardById(_id);

            Assert.NotNull(responseMessage);

            var expectedMessage = string.Format(DeletingMessage, _id);
            Assert.Equal(responseMessage, expectedMessage);

            var responseErrorMessage = GetMessageIncorrectGetResponse();

            var errorMessageWithId = string.Format(ErrorMessage, _id);

            Assert.NotNull(responseErrorMessage);
            Assert.True(responseErrorMessage.StartsWith(errorMessageWithId), "Error message is incorrect.");
        }

        private string GetMessageIncorrectGetResponse()
        {
            var response = DashboardService.GetById(_id);

            return JsonConvert.DeserializeObject<DashboardResponse>(response.Content).Message;
        }
    }
}