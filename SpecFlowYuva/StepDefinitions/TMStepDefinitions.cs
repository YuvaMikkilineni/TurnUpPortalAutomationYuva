using SpecFlowYuva.Pages;
using SpecFlowYuva.Utilities;
using System;
using TechTalk.SpecFlow;

using SpecFlowYuva.Pages;
using OpenQA.Selenium.Chrome;

namespace SpecFlowYuva.StepDefinitions
{
    [Binding]
    public class TMStepDefinitions : CommonDriver
    {
        
        LoginPage loginPage = new LoginPage();
        TMPage tmPage = new TMPage();
        HomePage homePage = new HomePage();

        [BeforeScenario] public void BeforeScenario()
        {
            driver = new ChromeDriver();
        }

        [Given(@"user logs into turnup portal '([^']*)' '([^']*)'")]
        public void GivenUserLogsIntoTurnupPortal(string username, string password)
        {
            loginPage.LoginActions(driver,username,password);
        }

        //[Given(@"user logs into turnup portal")]
        //public void GivenUserLogsIntoTurnupPortal()
        //{
        //    loginPage.LoginActions(driver);
        //}

        [When(@"user navigates to TM page")]
        public void WhenUserNavigatesToTMPage()
        {
            homePage.GoToTMPage(driver);
        }


        [When(@"user creates a new TM record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewTMRecord(string code, string desc, string price)
        {
            tmPage.CreateTimeRecord(driver,code, desc, price);
        }

        //[When(@"user creates a new TM record")]
        //public void WhenUserCreatesANewTMRecord()
        //{
        //    tmPage.CreateTimeRecord(driver);
        //}

        [Then(@"TM record should be saved")]
        public void ThenTMRecordShouldBeSaved()
        {
            tmPage.AssertCreateTMRecord(driver);
        }

        [When(@"user edits a TM record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsATMRecord(string code, string description, string price)
        {
            tmPage.EditTimeRecord(driver, code, description, price);
        }

        [Then(@"TM record should be Edited")]
        public void ThenTMRecordShouldBeEdited()
        {
            tmPage.AssertEditedTimeRecord(driver);
        }


        [Given(@"user deletes a  TM record")]
        public void GivenUserDeletesATMRecord()
        {
            tmPage.DeleteTimeRecord(driver);
        }

        [Then(@"TM record should be deleted")]
        public void ThenTMRecordShouldBeDeleted()
        {
            throw new PendingStepException();
        }

        [AfterScenario]
        public void tearDown()
        {
            driver.Quit();
        }
        
    }
}
