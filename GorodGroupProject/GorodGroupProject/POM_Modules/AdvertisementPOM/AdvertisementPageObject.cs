using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua
{
    class AdvertisementPageObject
    {
        IWebDriver _driver;
        public AdvertisementPageObject(IWebDriver driver)
        {
            this._driver = driver;
        }
        By _loginInput = By.CssSelector("input[name='username']");
        By _passwordInput = By.CssSelector("input[name='password']");
        By _cookieButton = By.Id("cookieButton");
        By _mainLoginButton = By.CssSelector("a[href='/user/login.php']");
        By _loginForm = By.CssSelector("form[action='https://gorod.dp.ua/user/login.php']");
        By _addButton = By.CssSelector("a[href='https://gorod.dp.ua/gazeta/nove.php']");
        By _carAdLink = By.CssSelector("a['href=https://gorod.dp.ua/gazeta/nove.php?type=auto&cat_id=2']");
        By _thankYouMessage = By.CssSelector("div[class='block_norm']");
        By _errorMessage = By.CssSelector("div.content-row:nth-child(10) > div:nth-child(1) > table:nth-child(5) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > font:nth-child(2) > b:nth-child(1)");

        public AdvertisementPageObject UserAuthorize(string login, string password)
        {
            _driver.FindElement(_cookieButton).Click();
            _driver.FindElement(_mainLoginButton).Click();
            _driver.FindElement(_loginInput).SendKeys(login);
            _driver.FindElement(_passwordInput).SendKeys(password);
            _driver.FindElement(_loginForm).Submit();
            return this;
        }
        public AdvertisementPageObject OpenCarAdForm()
        {
            _driver.FindElement(_addButton).Click();
            _driver.FindElement(By.LinkText("Авто и транспорт")).Click();
            _driver.FindElement(By.LinkText("Автомобили легковые")).Click();
            return this;
        }
        public string ThankYouMessage()
        {
            return _driver.FindElement(_thankYouMessage).Text;
        }
        public string ErrorMessage()
        {
            return _driver.FindElement(_errorMessage).Text;
        }

    }
}
