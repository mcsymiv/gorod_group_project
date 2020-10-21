using GorodGroupProject.POM_Modules.AfishaPOM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GorodGroupProject.Steps
{
    [Binding]
    public class AfishaSteps
    {
        public IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\GherkinSelenuim\packages\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\driver\win32\");
        AfishaPOM afisha;

        //Check the adress of cinemas
        [Given(@"Open afisha page")]
        public void GivenOpenAfishaPage()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }

        [When(@"Click on cinema")]
        public void WhenClickOnCinema()
        {
            afisha.DafyLinkCinema();
        }

        [Then(@"Adress is actual")]
        public void ThenAdressIsActual()
        {
            Assert.IsTrue(afisha.GetAdressText().Contains("бул. Звездный, 1-А, ТРЦ Дафи"));
        }

        //Go to the cinema 
        [Given(@"the page is open")]
        public void GivenThePageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }

        [When(@"click on the movie button")]
        public void WhenClickOnTheMovieButton()
        {
            afisha.ClickLinkMovie();
        }


        [Then(@"find test")]
        public void ThenFindTest()
        {
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Кино", afisha.TextTitle());
        }

        //Movie titles converge
        string name;


        [Given(@"afisha page is open")]
        public void GivenAfishaPageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }

        [When(@"click on the name of movie")]
        public void WhenClickOnTheNameOfMovie()
        {
            name = afisha.TitleMovieInList();
            afisha.ClickMovie();
        }

        [Then(@"find name of movie")]
        public void ThenFindNameOfMovie()
        {
            Assert.AreEqual(name, afisha.TitleMovieDescriptions());
        }

        //Search the movie
        [Given(@"The afisha page is open")]
        public void GivenTheAfishaPageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }

        [When(@"Set first movie in the movie list")]
        public void WhenSetFirstMovieInTheMovieList()
        {
            name = afisha.FirstMovieText();
        }

        [When(@"Enter the movie name in search field")]
        public void WhenEnterTheMovieNameInSearchField()
        {
            afisha.InputTextInSearchField();
        }

        [When(@"Click search button")]
        public void WhenClickSearchButton()
        {
            afisha.ClickSearchButton();
        }

        [Then(@"Search movie name equals find movie name")]
        public void ThenSearchMovieNameEqualsFindMovieName()
        {
            Assert.AreEqual(name, afisha.FindMovieText());
        }


        [AfterScenario]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }
}
