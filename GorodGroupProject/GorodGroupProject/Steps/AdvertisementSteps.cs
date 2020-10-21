using gorod.dp.ua.POMs;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace gorod.dp.ua
{
    [Binding]
    public class AdvertisementSteps
    {
        IWebDriver chrome;
        AdvertisementPageObject ad_page;
        AdFormPage form_page;
        EditAdPage editAd_page;
        DeleteAdPage delete_page;
        EditUserInfoPage edit_profile_page;
        AdPreviewPage preview_page;


        [Given(@"I on the ad page")]
        public void GivenIOnTheAdPage()
        {
            chrome = new ChromeDriver(@"C:\Users\mcsymiv\Desktop\git\chromedriver_win32");
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/gazeta/");
            chrome.Manage().Window.Maximize();
            ad_page = new AdvertisementPageObject(chrome);
            form_page = new AdFormPage(chrome);
            editAd_page = new EditAdPage(chrome);
            delete_page = new DeleteAdPage(chrome);
            edit_profile_page = new EditUserInfoPage(chrome);
            preview_page = new AdPreviewPage(chrome);
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [When(@"I want to login to my account with my (.*) (.*)")]
        public void WhenIWantToLoginToMyAccountWithMy(string login, string password)
        {
            ad_page.UserAuthorize(login, password);
        }

        [Given(@"I want to add my ad")]
        public void GivenIWantToAddMyAd()
        {
            ad_page.OpenCarAdForm();
        }

        [When(@"I fill in all necessary fields")]
        public void WhenIFillInAllNecessaryFields()
        {
            form_page.OperationFieldInput("продать")
                .AutoYearFieldInput("2000")
                .AutoMilesFieldInput("30000")
                .PriceFieldInput("2000")
                .DescriptionFieldInput("Отличное состояние");
        }

        [When(@"I click on add ad")]
        public void WhenIClickOnAddAd()
        {
            form_page.SubmitAdForm();
        }

        [Then(@"I see thank you message on the page")]
        public void ThenISeeThankYouMessageOnThePage()
        {
            string msg = ad_page.ThankYouMessage();
            Assert.IsTrue(msg.Contains("добавлено и открыто после проверки администратором"));
            chrome.Quit();
        }

        [Given(@"Ad form is open")]
        public void GivenAdFormIsOpen()
        {
            ad_page.OpenCarAdForm();
        }

        [When(@"User leaves necessary field empty")]
        public void WhenUserLeavesNecessaryFieldEmpty()
        {
            form_page.OperationFieldInput("продать")
                .AutoYearFieldInput("2000")
                .AutoMilesFieldInput("30000")
                .DescriptionFieldInput("Отличное состояние")
                .SubmitAdForm();
        }

        [Then(@"User see red error message")]
        public void ThenUserSeeRedErrorMessage()
        {
            string errorMsg = ad_page.ErrorMessage();
            Assert.IsTrue(errorMsg.Contains("Ошибка"));
            chrome.Quit();
        }

        [Given(@"One ad is created by user")]
        public void GivenOneAdIsCreatedByUser()
        {
            ad_page.OpenCarAdForm();
            form_page.OperationFieldInput("продать")
                .AutoYearFieldInput("2000")
                .AutoMilesFieldInput("30000")
                .PriceFieldInput("2000")
                .DescriptionFieldInput("Отличное состояние")
                .SubmitAdForm();
        }

        [When(@"User delete this specific ad")]
        public void WhenUserDeleteThisSpecificAd()
        {
            delete_page.OpenUserAdsPage()
                .DeleteAd()
                .AlertConfirm();
        }

        [Then(@"User ad count is zero")]
        public void ThenUserAdCountIsZero()
        {
            string adCount = delete_page.AdCountNumber();
            Regex rgx = new Regex("^[0-9]+$");
            Assert.IsFalse(rgx.IsMatch(adCount));
            chrome.Quit();
        }

        [When(@"I go to page my ads")]
        public void WhenIGoToPageMyAds()
        {
            editAd_page.ClickOnTheMyAds();
        }

        [Then(@"I see title on the page my ads")]
        public void ThenISeeTitleOnThePageMyAds()
        {
            string actualResult = editAd_page.TitleMyAds();
            Assert.AreEqual("ОБЪЯВЛЕНИЯ", actualResult);
            chrome.Quit();
        }

        [When(@"I click on the edit button")]
        public void WhenIClickOnTheEditButton()
        {
            editAd_page.ClickEditFirstAd();
        }

        [Then(@"I see title placing a new ad")]
        public void ThenISeeTitlePlacingANewAd()
        {
            string actualResult = editAd_page.TitleMyAdsAcc();
            Assert.AreEqual("Размещение нового объявления", actualResult);
            chrome.Quit();
        }

        [When(@"I edit text and the address of an ad")]
        public void WhenIEditTextAndTheAddressOfAnAd()
        {
            editAd_page.EditTextAd()
                .EditAddressAd();
        }

        [When(@"I click on the share ad")]
        public void WhenIClickOnTheShareAd()
        {
            editAd_page.ClickPublishAd();
        }

        [Then(@"I see text information like please wait admin accepting")]
        public void ThenISeeTextInformationLikePleaseWaitAdminAccepting()
        {
            string actualResult = editAd_page.TextInTheEnd();
            Assert.AreEqual("Спасибо!", actualResult);
            chrome.Quit();
        }

        [Given(@"User is on profile page")]
        public void GivenUserIsOnProfilePage()
        {
            edit_profile_page.GoToUserAdPage()
                .GoToUserProfile();
        }
        string OldPhone;
        [When(@"User updates their phone number")]
        public void WhenUserUpdatesTheirPhoneNumber()
        {
            OldPhone = edit_profile_page.OldPhoneNumber();
            edit_profile_page.UserPhoneChangeTo("987654321")
                .SubmitChange();
        }

        [When(@"User opens ad form for creation")]
        public void WhenUserOpensAdFormForCreation()
        {
            edit_profile_page.GoToAds();
            ad_page.OpenCarAdForm();
        }

        [Then(@"Phone field is pre-filled with updated data")]
        public void ThenPhoneFieldIsPre_FilledWithUpdatedData()
        {
            string newPhone = edit_profile_page.GetNewPhoneText();
            Assert.AreEqual(newPhone, OldPhone);
            chrome.Quit();
        }

        [Given(@"ad form is prefilled with user data")]
        public void GivenAdFormIsPrefilledWithUserData()
        {
            ad_page.OpenCarAdForm();
            form_page.OperationFieldInput("продать")
                .AutoYearFieldInput("2000")
                .AutoMilesFieldInput("30000")
                .PriceFieldInput("2000")
                .DescriptionFieldInput("Отличное состояние");
        }

        [When(@"User click on preview button")]
        public void WhenUserClickOnPreviewButton()
        {
            preview_page.PreviewButtonCLick();
        }

        [Then(@"User's ad is shown on the page")]
        public void ThenUserSAdIsShownOnThePage()
        {
            string previewTitle = preview_page.GetAdPreviewTitle();
            Assert.IsTrue(previewTitle.Contains("продать".ToUpper()));
            chrome.Quit();
        }
    }
}
