namespace Core.Configuration
{
    public class TestSettings
    {
        public string BaseUrl { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string AccessToken { get; set; }

        public string BaseApiUrl { get; set; }

        public string BrowserType { get; set; }

        public int DefaultTimeOutMs { get; set; }

        public int IterationDelayMs { get; set; }

        public bool IsHeadlessDriver { get; set; }

        public string GridUrl { get; set; }
    }
}
