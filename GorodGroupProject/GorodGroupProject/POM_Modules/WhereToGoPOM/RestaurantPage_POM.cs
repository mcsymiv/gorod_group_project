using OpenQA.Selenium;

namespace gorod.dp.ua.POMs
{
    class RestaurantPage_POM
    {
        IWebDriver chrome;

        By _placesAmount = By.CssSelector(".koris");
        By _cusine = By.XPath("/html/body/div[2]/div[7]/div[2]/table/tbody/tr[4]/td[2]/a[1]");

        public RestaurantPage_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public RestaurantPage_POM FillSearchInput(string text)
        {
            chrome.FindElement(_cusine).SendKeys(text);
            return this;
        }

        public string ReadCusine()
        {
            string cusine = chrome.FindElement(_cusine).Text;
            return cusine;
        }
    }
}
