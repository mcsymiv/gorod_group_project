using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorodGroupProject.POM_Modules.AfishaPOM
{
    class AfishaPOM
    {
        IWebDriver chrome;

        public AfishaPOM(IWebDriver chrome)
        {
            this.chrome = chrome;
        }

        By _titleMovieInBodyPage = By.CssSelector("#content > div.content-row > div.contentbox > div:nth-child(6) > div > div:nth-child(1)");

        By _dafyMultiplex = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(2) > a");
        By _karavan = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(5) > a");
        By _neoPlaza = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(7) > a");
        By _mostKino = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(9) > a");
        By _planetaKino = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(11) > a");
        By _pravdaKino = By.CssSelector("#content > div.content-row > div.contentbox2 > ul:nth-child(2) > li:nth-child(13) > a");
        By _linkAllMovie = By.XPath("/html/body/div[2]/div[6]/div[1]/div[1]/div[2]/a[2]");
        By _titleAllMovie = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > h1");

        By _movie = By.CssSelector("#content > div.content-row > div.contentbox > div:nth-child(6) > div > div:nth-child(2) > div:nth-child(3) > span.title120 > a");
        By _titleMovieInDescriptoins = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > div:nth-child(1) > h1");

        By _firstMovie = By.CssSelector("#content > div.content-row > div.contentbox > div:nth-child(6) > div > div:nth-child(2) > div:nth-child(1) > span.title120 > a");
        By _searchField = By.CssSelector("#content > div.content-row > div.contentbox > table > tbody > tr > td:nth-child(1) > input");
        By _searchButton = By.CssSelector("#content > div.content-row > div.contentbox > table > tbody > tr > td:nth-child(4) > input[type=image]");
        By _afterSearchMovie = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > div:nth-child(3) > h3");

        By _adressText = By.CssSelector("body > div.container > div:nth-child(8) > div.contentbox > table > tbody > tr:nth-child(1) > td.norm9");
        public string TitleMovieInBodyPage()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_titleMovieInBodyPage).Text;
            return text;
        }
        public string GetAdressText()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_adressText).Text;
            return text;
        }

        public AfishaPOM ClickLinkMovie()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_linkAllMovie).Click();
            return this;
        }

        public void DafyLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_dafyMultiplex).Click();

        }
        public AfishaPOM KaravanLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_karavan).Click();
            return this;
        }
        public AfishaPOM NeoPlazaLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_neoPlaza).Click();
            return this;
        }
        public AfishaPOM MostKinoLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_mostKino).Click();
            return this;
        }
        public AfishaPOM PlanetaKinoLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_planetaKino).Click();
            return this;
        }
        public AfishaPOM PravdaKinoLinkCinema()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_pravdaKino).Click();
            return this;
        }
        public string TextTitle()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_titleAllMovie).Text;
            return text;
        }

        public AfishaPOM ClickMovie()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            chrome.FindElement(_movie).Click();
            return this;
        }


        public string TitleMovieInList()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_movie).Text;
            return text;
        }

        public string TitleMovieDescriptions()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_titleMovieInDescriptoins).Text;
            return text;
        }

        public string FirstMovieText()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            string text = chrome.FindElement(_firstMovie).Text;
            return text;
        }

        public string InputTextInSearchField()
        {
            string text = FirstMovieText();
            chrome.FindElement(_searchField).SendKeys(text);
            return text;
        }

        public AfishaPOM ClickSearchButton()
        {
            chrome.FindElement(_searchButton).Click();
            return this;
        }

        public string FindMovieText()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            string text = chrome.FindElement(_afterSearchMovie).Text;
            return text;
        }

    }
}
