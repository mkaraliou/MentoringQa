﻿using Models.ResponseModels;
using Newtonsoft.Json;
using Tests.API.Helpers;

namespace Tests.API
{
    [TestFixture]
    public class DashboardTests : BaseApiTest
    {
        private const string ErrorMessage = "Dashboard with ID '{0}' not found on project";
        private const string DeletingMessage = "Dashboard with ID = '{0}' successfully deleted.";

        private List<string> _ids;
        private string _id;

        [SetUp]
        public void OneTimeSetUp()
        {
            var name = Faker.Name.First();
            var dashboardModel = CreateDataHelper.CreateRandomDashboardModel(name);

            _id = DashboardServiceHelper.CreateDashboard(dashboardModel)?.Id;

            _ids = new List<string>()
            {
                _id
            };
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            foreach (var id in _ids)
            {
                DashboardServiceHelper.DeleteDashboardById(id);
            }
        }

        [Test]
        public void GetDashboard()
        {
            var dashboard = DashboardServiceHelper.GetById(_id);

            Assert.IsNotNull(dashboard, "Dashboard should be found.");
        }

        [Test]
        public void CreateDashboard()
        {
            var name = Faker.Name.First();
            var dashboardModel = CreateDataHelper.CreateRandomDashboardModel(name);

            var id = DashboardServiceHelper.CreateDashboard(dashboardModel)?.Id;

            Assert.IsNotNull(id, "Id should be returned.");

            _ids.Add(id);
        }

        [Test]
        public void DeleteDashboard()
        {
            var responseMessage = DashboardServiceHelper.DeleteDashboardById(_id);

            Assert.IsNotNull(responseMessage, "Message should be returned.");

            var expectedMessage = string.Format(DeletingMessage, _id);
            Assert.That(responseMessage, Is.EqualTo(expectedMessage), "Response message is incorrect.");

            var responseErrorMessage = GetMessageIncorrectGetResponse();

            var errorMessageWithId = string.Format(ErrorMessage, _id);

            Assert.IsNotNull(responseErrorMessage, "Error message should be returned.");
            Assert.IsTrue(responseErrorMessage.StartsWith(errorMessageWithId), "Error message is incorrect.");
        }

        private string GetMessageIncorrectGetResponse()
        {
            var response = DashboardService.GetById(_id);

            return JsonConvert.DeserializeObject<DashboardResponse>(response.Content).Message;
        }
    }
}
