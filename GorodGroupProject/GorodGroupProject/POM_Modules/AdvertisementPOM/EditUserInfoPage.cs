using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua.POMs
{
    public class EditUserInfoPage
    {
        IWebDriver _driver;
        public EditUserInfoPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        By _userAd = By.LinkText("Мои объявления");
        By _userProfile = By.LinkText("Мой профиль");
        By _userPhoneField = By.CssSelector("input[name='phone']");
        By _submitButton = By.CssSelector("input[type='submit']");
        By _adPageLink = By.CssSelector("a[href='/gazeta/']");
        By _userPrefilledPhone = By.CssSelector("input[name='phone']");

        public EditUserInfoPage GoToUserAdPage()
        {
            _driver.FindElement(_userAd).Click();
            return this;
        }
        public EditUserInfoPage GoToUserProfile()
        {
            _driver.FindElement(_userProfile).Click();
            return this;
        }
        public string OldPhoneNumber()
        {
            return _driver.FindElement(_userPhoneField).Text;
        }
        public EditUserInfoPage UserPhoneChangeTo(string newPhoneNumber)
        {
            _driver.FindElement(_userPhoneField).Clear();
            _driver.FindElement(_userPhoneField).SendKeys(newPhoneNumber);
            return this;
        }
        public EditUserInfoPage SubmitChange()
        {
            _driver.FindElement(_submitButton).Click();
            return this;
        }
        public EditUserInfoPage GoToAds()
        {
            _driver.FindElement(_adPageLink).Click();
            return this;
        }
        public string GetNewPhoneText()
        {
            return _driver.FindElement(_userPrefilledPhone).Text;
        }
    }
}
