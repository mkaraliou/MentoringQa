using PageObjects.Interfaces;

namespace Test.UI
{
    [TestFixture]
    public class LoggingTests : BaseUiTest
    {
        private ILoginPage _loginPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            _loginPage = TestCore.Container.GetInstance<ILoginPage>();
        }

        [Test]
        public void CorrectLoginTest()
        {
            _loginPage.Login.EnterText(TestConfiguration.Login);
            _loginPage.Password.EnterText(TestConfiguration.Password);

            _loginPage.LoginButton.Click();
        }

        [TestCase("skfslkdjflks")]
        [TestCase("dsisdgudfg")]
        public void Logging_IncorrectLogin(string login)
        {
            // Act
            _loginPage.Login.EnterText(login);
            _loginPage.Password.EnterText(TestConfiguration.Password);

            _loginPage.LoginButton.Click();

            // Assert
            Assert.IsTrue(_loginPage.TextError.Enabled(), "Error message is incorrect.");
        }
    }
}
