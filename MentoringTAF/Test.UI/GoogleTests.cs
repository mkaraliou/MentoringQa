using OpenQA.Selenium;
using PageObjects.Interfaces;
using Serilog;

namespace Test.UI
{
    public class GoogleTests : BaseUiTest
    {
        private IGoogleMain _googleMainPage;
        private string _googleUrl = "https://www.google.by/";

        [SetUp]
        public void SetUp()
        {
            Log.Logger.Information($"SetUp google test: {TestContext.CurrentContext.Test.MethodName}");

            _googleMainPage = TestCore.Container.GetInstance<IGoogleMain>();

            Driver.Navigate().GoToUrl(_googleUrl);
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Log.Logger.Information($"OneTimeSetup google test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [TearDown]
        public void Teardown()
        {
            Log.Logger.Information($"Teardown google test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Log.Logger.Information($"OneTimeTearDown google test: {TestContext.CurrentContext.Test.MethodName}");
        }

        [Test]
        public void CheckGoogleImage()
        {
            Log.Logger.Information($"Test: {TestContext.CurrentContext.Test.MethodName}");

            Thread.Sleep(2000);

            Assert.IsTrue(_googleMainPage.GoogleImage.Enabled());
        }

        [TestCase("dota 2 liquipedia", "Liquipedia Dota 2 Wiki")]
        [TestCase("cinematic marvel universe", "Marvel Cinematic Universe - Wikipedia")]
        public void CheckGoogleUiRequest(string enteredText, string expectedResult)
        {
            Log.Logger.Information($"Test: {TestContext.CurrentContext.Test.MethodName}");

            Thread.Sleep(500);

            //_googleMainPage.GoogleFind.WebElement.Click();
            _googleMainPage.GoogleFind.EnterText(enteredText, false);
            _googleMainPage.GoogleFind.EnterText(Keys.Enter, false);

            Thread.Sleep(1000);

            Assert.AreEqual(expectedResult, _googleMainPage.FirstLink.Text);
        }
    }
}
