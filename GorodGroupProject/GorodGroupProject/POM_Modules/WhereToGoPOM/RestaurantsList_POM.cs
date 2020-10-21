using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorodGroupProject.POM_Modules.WhereToGoPOM
{
    class RestaurantsList_POM
    {
        IWebDriver chrome;

        By _cousinSelector = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox2 > div:nth-child(4) > table > tbody > tr:nth-child(2) > td > select");
        By _searchTitle = By.CssSelector(".head1");
        By _firstListItem = By.XPath("/html/body/div[2]/div[7]/div[2]/center/div/table[3]/tbody/tr/td[1]/h3/a");
        By _dropDownPath = By.Name("select");
        By _filterA = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > center > div > table:nth-child(4) > tbody > tr > td > font > a:nth-child(2) > b");
        By _lastItem = By.XPath("/html/body/div[2]/div[7]/div[2]/center/div/table[3]/tbody/tr[10]/td[1]/h3/a");
        By _filterB = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > center > div > table:nth-child(4) > tbody > tr > td > font > a:nth-child(3) > b");
        By _filterV = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > center > div > table:nth-child(4) > tbody > tr > td > font > a:nth-child(4) > b");
        By _filterH = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > center > div > table:nth-child(4) > tbody > tr > td > font > a:nth-child(5) > b");

        public RestaurantsList_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public RestaurantsList_POM ChooseCousine(int number)
        {
            chrome.FindElement(_cousinSelector).Click();
            IWebElement dropDown = chrome.FindElement(_dropDownPath);
            SelectElement selectElement = new SelectElement(dropDown);
            selectElement.SelectByIndex(number);
            return this;
        }

        public RestaurantsList_POM GoToTheRestaurant()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            chrome.FindElement(_firstListItem).Click();
            return this;
        }

        public string LookForKey()
        {
            string searcPhrase = chrome.FindElement(_searchTitle).Text;
            return searcPhrase;
        }

        public string GetItemFirsLetter(string element)
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            By path = _firstListItem;
            if (element == "last")
            {
                path = _lastItem;
            }
            string title = chrome.FindElement(path).Text;
            string letter = title.Substring(0, 1);
            return letter;
        }

        public RestaurantsList_POM ChooseFilter(string key)
        {
            By path = _filterA;
            switch (key)
            {
                case "Б":
                    path = _filterB;
                    break;
                case "В":
                    path = _filterV;
                    break;
                case "Г":
                    path = _filterH;
                    break;
                default:
                    break;
            }
            chrome.FindElement(path).Click();
            return this;
        }
    }
}
