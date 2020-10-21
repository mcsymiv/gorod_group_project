using OpenQA.Selenium;

namespace gorod.dp.ua.POMs
{
    class KydaPoyti_POM
    {
        IWebDriver chrome;
        By _pageLogo = By.CssSelector("body > div.container > div.brandbox > div.logo > a > img");
        By _pageRestoran = By.XPath("/html/body/div[2]/div[7]/div[3]/ul/li[4]/a");
        By _headerKydaPoyti = By.CssSelector("#navbarNav > ul > li:nth-child(3) > a");
        By _pagrRestoranBody = By.XPath("/html/body/div[2]/div[7]/div[2]/table/tbody/tr[1]/td[2]/a/h4");

        public KydaPoyti_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public KydaPoyti_POM ClickButtonRestoran()
        {
            chrome.FindElement(_pageRestoran).Click();
            return this;
        }

        public KydaPoyti_POM ClickHeaderKydaPoyti()
        {
            chrome.FindElement(_headerKydaPoyti).Click();
            return this;
        }
        public KydaPoyti_POM ClickButtonRestoranBody()
        {
            chrome.FindElement(_pagrRestoranBody).Click();
            return this;
        }
        public string Add()
        {
            return chrome.Title;
        }

    }
}

