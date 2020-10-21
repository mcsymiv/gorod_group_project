using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua.POMs
{
    public class AdFormPage
    {
        IWebDriver _driver;
        public AdFormPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        By _operationType = By.CssSelector("input[name='otherkind']");
        By _autoYear = By.CssSelector("input[name='auto_year']");
        By _autoMiles = By.CssSelector("input[name='auto_mileage']");
        By _price = By.CssSelector("input[name='auto_price']");
        By _adDescription = By.CssSelector("textarea[name='text']");
        By _submitButton = By.CssSelector("input[name='Submit']");

        public AdFormPage FillNecessaryFieldsAd(string operationType, string autoYear, string autoMiles, string price, string description)
        {
            _driver.FindElement(_operationType).SendKeys(operationType);
            _driver.FindElement(_autoYear).SendKeys(autoYear);
            _driver.FindElement(_autoMiles).SendKeys(autoMiles);
            _driver.FindElement(_price).SendKeys(price);
            _driver.FindElement(_adDescription).SendKeys(description);
            return this;
        }
        public AdFormPage OperationFieldInput(string operationType)
        {
            _driver.FindElement(_operationType).SendKeys(operationType);
            return this;
        }
        public AdFormPage AutoYearFieldInput(string autoYear)
        {
            _driver.FindElement(_autoYear).SendKeys(autoYear);
            return this;
        }
        public AdFormPage AutoMilesFieldInput(string autoMiles)
        {
            _driver.FindElement(_autoMiles).SendKeys(autoMiles);
            return this;
        }
        public AdFormPage PriceFieldInput(string price)
        {
            _driver.FindElement(_price).SendKeys(price);
            return this;
        }
        public AdFormPage DescriptionFieldInput(string description)
        {
            _driver.FindElement(_adDescription).SendKeys(description);
            return this;
        }
        public AdFormPage SubmitAdForm()
        {
            _driver.FindElement(_submitButton).Click();
            return this;
        }
    }
}
