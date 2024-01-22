using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalAutomationYuva.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            try
            {
                //Navigate to Time and Material Module
                IWebElement adminstrationDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                adminstrationDropDown.Click();

                IWebElement TMoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                TMoption.Click();
            }
            catch (Exception ex) 
            {
                Assert.Fail("TM page not loaded sucessfully.. " + ex.Message);
            }
        }

        public void VerifyHomePage(IWebDriver driver)
        {
            //Check if user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            Assert.That(helloHari.Text == "Hello hari!", "User has logged in...");

            //if (helloHari.Text == "Hello hari!")
            //{
            //    Console.WriteLine("User has logged in successfully");
            //}
            //else
            //{
            //    Console.WriteLine("User hasn't ben logged in...");
            //}
        }
    }
}
