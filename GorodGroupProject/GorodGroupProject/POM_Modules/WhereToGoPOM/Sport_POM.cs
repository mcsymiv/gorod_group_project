using OpenQA.Selenium;

namespace gorod.dp.ua.POMs
{
    class Sport_POM
    {
        IWebDriver chrome;

        By _pageNumber = By.XPath("/html/body/div[2]/div[8]/div[2]/center/table[4]/tbody/tr/td[2]/b[1]");
        By _nextPageBtn = By.CssSelector("body > div.container > div:nth-child(9) > div.contentbox > center > table:nth-child(10) > tbody > tr > td.norm8 > b:nth-child(4) > a");
        By _searchBtn = By.CssSelector("input[type='image']");
        By _searchTitle = By.CssSelector(".head1");


        public Sport_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public string GetPageNumber()
        {
            string pageNum = chrome.FindElement(_pageNumber).Text;
            return pageNum;
        }

        public Sport_POM GoToNextPage()
        {
            chrome.FindElement(_nextPageBtn).Click();
            return this;
        }
    }
}
