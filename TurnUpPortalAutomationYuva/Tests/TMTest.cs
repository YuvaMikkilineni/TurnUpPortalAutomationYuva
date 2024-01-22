using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnUpPortalAutomationYuva.Pages;
using TurnUpPortalAutomationYuva.Utilities;

namespace TurnUpPortalAutomationYuva.Tests
{
    [TestFixture]
    public class TMTest : CommonDriver
    {

      [SetUp]
      public void SetUpTM() 
        {
            //Open Chrome Browser
            driver = new ChromeDriver();

            LoginPage loginPage = new LoginPage();
            loginPage.LoginActions(driver);

            HomePage homePage = new HomePage();
            homePage.VerifyHomePage(driver);
            homePage.GoToTMPage(driver);
        }

        [Test]
      public void TestCreateTimeRecord()
        {
            TMPage tMPage = new TMPage();
            tMPage.CreateTimeRecord(driver);
        }

        [Test]
        public void TestEditTimeRecord() 
        {
            TMPage tMPage = new TMPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            tMPage.EditTimeRecord(driver);
        }

        [Test]
        public void TestDeleteTimeRecord() 
        {
            TMPage tMPage = new TMPage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            tMPage.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun() 
        {
            driver.Quit();
        }

    }
}
