using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua.POMs
{
    public class DeleteAdPage
    {
        IWebDriver _driver;
        public DeleteAdPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        By _userAds = By.LinkText("Мои объявления");
        By _deleteButtonIcon = By.CssSelector("a[href*='https://gorod.dp.ua/gazeta/nove.php?del&id=']");
        public DeleteAdPage OpenUserAdsPage()
        {
            _driver.FindElement(_userAds).Click();
            return this;
        }
        public DeleteAdPage DeleteAd()
        {
            _driver.FindElement(_deleteButtonIcon).Click();
            return this;
        }
        public DeleteAdPage AlertConfirm()
        {
            var confirm = _driver.SwitchTo().Alert();
            confirm.Accept();
            return this;
        }
        public string AdCountNumber()
        {
            return _driver.FindElement(_userAds).Text;
        }
    }
}
