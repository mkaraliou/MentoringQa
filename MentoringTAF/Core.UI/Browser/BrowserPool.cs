using System.Collections.Concurrent;

namespace Core.UI.Browser
{
    public sealed class BrowserPool
    {
        private static readonly ConcurrentDictionary<string, IBrowser> BrowserList = new ConcurrentDictionary<string, IBrowser>();

        private static readonly Lazy<BrowserPool> Lazy = new Lazy<BrowserPool>(() => new BrowserPool());

        public static BrowserPool Instance => Lazy.Value;

        public static IBrowser CurrentBrowser
        {
            get
            {
                string browserName = CurrentBrowserName;

                if (string.IsNullOrWhiteSpace(browserName))
                {
                    throw new InvalidOperationException("No browser exists to be considered as current.");
                }

                return BrowserList[browserName];
            }
        }

        public static string CurrentBrowserName { get; private set; }

        public static void MakeCurrentBrowser(string browserName)
        {
            browserName = browserName.Trim();

            if (BrowserList.ContainsKey(browserName))
            {
                CurrentBrowserName = browserName;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    nameof(browserName),
                    $"No browser with reference name '{browserName}' is available");
            }
        }

        public static void RegisterBrowser(string browserName, IBrowser newBrowser)
        {
            browserName = browserName.Trim();

            if (!BrowserList.ContainsKey(browserName))
            {
                BrowserList.TryAdd(browserName, newBrowser);
            }
        }

        public static void RegisterAndMakeCurrentBrowser(string browserName, IBrowser newBrowser)
        {
            RegisterBrowser(browserName, newBrowser);
            MakeCurrentBrowser(browserName);
        }

        public static void CloseBrowser(string browserName)
        {
            if (BrowserList.ContainsKey(browserName))
            {
                BrowserList.TryRemove(browserName, out var driver);
                driver?.Quit();
                CurrentBrowserName = string.Empty;
            }
        }
    }
}
