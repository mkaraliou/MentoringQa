using Models;

namespace Tests.API.Helpers
{
    public class CreateDataHelper
    {
        public static DashboardModel CreateRandomDashboardModel(string name)
        {
            return new DashboardModel
            {
                Description = Faker.Lorem.GetFirstWord(),
                Name = name,
                Owner = Faker.Name.First(),
                Share = true
            };
        }
    }
}
