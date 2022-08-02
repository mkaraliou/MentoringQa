using PageObjects.Interfaces;
using Serilog;

namespace Test.UI
{
    [Parallelizable]
    [TestFixture]
    public class LoggingTests : BaseUiTest
    {
        private ILoginPage _loginPage;

        [SetUp]
        public void SetUp()
        {
            Log.Logger.Information($"SetUp logging test: {TestContext.CurrentContext.Test.MethodName}");
            _loginPage = TestCore.Container.GetInstance<ILoginPage>();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Log.Logger.Information($"OneTimeSetup logging test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [TearDown]
        public void Teardown()
        {
            Log.Logger.Information($"Teardown logging test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Log.Logger.Information($"OneTimeTearDown logging test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [Test]
        public void CorrectLoginTest()
        {
            Log.Logger.Information($"Start: {TestContext.CurrentContext.Test.MethodName}");
            _loginPage.Login.EnterText(TestConfiguration.Login);
            _loginPage.Password.EnterText(TestConfiguration.Password);

            _loginPage.LoginButton.Click();

            Log.Logger.Information($"Finish: {TestContext.CurrentContext.Test.MethodName}");

        }

        [TestCase("skfslkdjflks")]
        [TestCase("dsisdgudfg")]
        public void Logging_IncorrectLogin(string login)
        {
            Log.Logger.Information($"Start: {TestContext.CurrentContext.Test.MethodName}");

            // Act
            _loginPage.Login.EnterText(login);
            _loginPage.Password.EnterText(TestConfiguration.Password);

            _loginPage.LoginButton.Click();

            Thread.Sleep(1000);

            // Assert
            Assert.IsTrue(_loginPage.TextError.Enabled(), "Error message is incorrect.");

            Log.Logger.Information($"Finish: {TestContext.CurrentContext.Test.MethodName}");

        }
    }
}
