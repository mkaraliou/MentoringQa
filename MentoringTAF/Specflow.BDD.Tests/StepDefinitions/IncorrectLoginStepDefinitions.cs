using Core;
using Core.UI.Browser;
using NUnit.Framework;
using PageObjects.Interfaces;

namespace Specflow.BDD.Tests.StepDefinitions
{
    [Binding]
    public class IncorrectLoginStepDefinitions : BaseTest
    {
        private ILoginPage _loginPage;
        public IBrowser Driver => BrowserPool.CurrentBrowser;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _loginPage = TestCore.Container.GetInstance<ILoginPage>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

        [Given(@"I go to login page of Report Portal")]
        public void GivenIGoToLoginPageOfReportPortal()
        {
            var driver = BrowserFactory.Instance.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            BrowserPool.RegisterAndMakeCurrentBrowser(TestContext.CurrentContext.Test.Name, driver);

            Driver.Navigate().GoToUrl(TestConfiguration.BaseUrl);
        }

        [Given(@"I enter login '([^']*)'")]
        public void GivenIEnterLogin(string login)
        {
            _loginPage.Login.EnterText(login);
        }

        [Given(@"I enter password '([^']*)'")]
        public void GivenIEnterPassword(string password)
        {
            _loginPage.Password.EnterText(password);
        }

        [When(@"I click button Login")]
        public void WhenIClickButtonLogin()
        {
            _loginPage.LoginButton.Click();
        }

        [Then(@"Error message are appeared")]
        public void ThenErrorMessageAreAppeared()
        {
            Assert.IsTrue(_loginPage.TextError.Enabled(), "Error message is incorrect.");
        }
    }
}
