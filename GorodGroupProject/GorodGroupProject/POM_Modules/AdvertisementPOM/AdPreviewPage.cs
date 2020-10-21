using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gorod.dp.ua.POMs
{
    public class AdPreviewPage
    {
        IWebDriver _driver;
        public AdPreviewPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        By _previewButton = By.CssSelector("input[name='Preview']");
        By _previweTitleLink = By.CssSelector("a[href='obyava.php?id=']");

        public AdPreviewPage PreviewButtonCLick()
        {
            _driver.FindElement(_previewButton).Click();
            return this;
        }
        public string GetAdPreviewTitle()
        {
            return _driver.FindElement(_previweTitleLink).Text;
        }
    }
}
