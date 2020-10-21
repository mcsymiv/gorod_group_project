using OpenQA.Selenium;

namespace gorod.dp.ua.POMs
{
    public class Restaurant_POM
    {
        IWebDriver chrome;

        By _placesAmount = By.CssSelector(".koris");
        By _searchForm = By.CssSelector("body > div.container > div:nth-child(9) > div.contentbox > center > div:nth-child(1) > div > form > input.sf");
        By _searchBtn = By.CssSelector("input[type='image']");
        By _searchTitle = By.CssSelector(".head1");


        public Restaurant_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public Restaurant_POM FillSearchInput(string text)
        {
            chrome.FindElement(_searchForm).SendKeys(text);
            return this;
        }

        public Restaurant_POM PressSearchBtn()
        {
            chrome.FindElement(_searchBtn).Click();
            return this;
        }

        public string LookForKey()
        {
            string searcPhrase = chrome.FindElement(_searchTitle).Text;
            return searcPhrase;
        }
    }
}
