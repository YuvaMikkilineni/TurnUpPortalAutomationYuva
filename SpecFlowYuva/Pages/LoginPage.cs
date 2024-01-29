using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecFlowYuva.Utilities;


namespace SpecFlowYuva.Pages
{
    public class LoginPage : CommonDriver
    {
        //[FindsBy(How = How.Name , Using = "UserName")]
        //IWebElement usernameTextBox;

        //[FindsBy(How = How.Name , Using = "Password")]
        //[CacheLookup]
        //IWebElement passwordTextBox;

        public void LoginActions(IWebDriver driver, string username, string password) 
        {
           
            //Maximize the browser
            driver.Manage().Window.Maximize();
                        
            try
            {
                //Launch TurnUp Portal and navigate to login page (http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f)
                driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

                //identify username textbox and enter valid username
                IWebElement usernameTextBox = driver.FindElement(By.Id("UserName"));
                usernameTextBox.SendKeys(username);

                
                //identify password textbox and enter valid username
                IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
                passwordTextBox.SendKeys(password);

                //identify the login button and click on the button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
                loginButton.Click();
            }
            catch (Exception ex) 
            {
                Assert.Fail("TurnUp Portal didn't launch" + ex.Message);
            }
        }
    }
}
