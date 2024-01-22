using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras;
using TurnUpPortalAutomationYuva.Utilities;
using SeleniumExtras.PageObjects;
using NUnit.Framework.Constraints;

namespace TurnUpPortalAutomationYuva.Pages
{
    public class TMPage : CommonDriver
    {
        private IWebElement typeDropDown;
        private IWebElement timeOption;
        private IWebElement codeTextBox;
        private IWebElement descriptionTextBox;
        private IWebElement priceTextBox;
        private IWebElement saveButton;
        //[FindsBy(How.XPath, "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span")]
        private IWebElement goToLastPage;
        string actualCode;


        public IWebElement TypeDropDown { get => typeDropDown; set => typeDropDown = value; }

        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select Time from TypeCode
            typeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeDropDown.Click();
            Thread.Sleep(1000);
            timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Input Code
            codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("January2024-Y");

            //Input Description
            descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("January2024-Y");

            //Identify the Price TextBox and enter
            priceTextBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextBox.SendKeys("100");

            //Click on Save Button
            saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);


            //Click on Last Page button
            goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
             
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //Check if record is present
           actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Text;

            Assert.That(actualCode == "January2024-Y", "The Record Created Successfully");
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            //IList<IWebElement> pagination = driver.FindElements(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/span[2]"));
            //int size = pagination.Count;

            //Console.WriteLine("Pagination : " + pagination.ToString + " , Size is  : " + size);
            try
            {
                do
                {

                    IList rows = driver.FindElements(By.XPath("//table/tbody/tr"));
                    int rowSize = rows.Count;
                    //Console.WriteLine(rowSize);
                    for (int i = 1; i <= rowSize; i++)
                    {

                        String firstNames = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text;
                        //Console.WriteLine(firstNames);
                        // Now click the checkBox where first Name would be Will
                        if (firstNames.Equals("January2024-Y"))
                        {
                            Console.WriteLine(firstNames);
                            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[5]/a[1]"));
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                            editButton.Click();

                            typeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
                            typeDropDown.Click();
                            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[1]", 5);
                            timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
                            timeOption.Click();

                            codeTextBox = driver.FindElement(By.Id("Code"));
                            codeTextBox.Clear();
                            codeTextBox.SendKeys("January2024-Yuva");

                            descriptionTextBox = driver.FindElement(By.Id("Description"));
                            descriptionTextBox.Clear();
                            descriptionTextBox.SendKeys("Automation Testing- Yuva");

                            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
                            priceTag.Click();

                            priceTextBox = driver.FindElement(By.Id("Price"));
                            priceTextBox.Clear();

                            priceTag.Click();

                            priceTextBox.SendKeys("50");

                            saveButton = driver.FindElement(By.Id("SaveButton"));
                            saveButton.Click();

                            break;
                        }
                    }
                    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]")).Click();
                } while (!driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]")).GetAttribute("class").EndsWith("disabled"));


                Thread.Sleep(2000);

                goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPage.Click();
                Thread.Sleep(2000);

                IWebElement editCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

                Assert.That(editCode.Text != actualCode, "The Record Updated Successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Error Message in Catch ..." + ex.Message);
            }

            //if (editCode.Text != testActual)
            //{
            //    Console.WriteLine("Updated successfull");
            //}
            //else
            //{
            //    Console.WriteLine("Record Not Updated");
            //}
        }


        public void DeleteTimeRecord(IWebDriver driver)
        {

            goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage.Click();
            Thread.Sleep(2000);

            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (deleteCode.Text.Equals("January2024-Y"))
            {

                //Delete the Record January2024-Yuva
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                deleteButton.Click();

                IAlert deleteAlert = driver.SwitchTo().Alert();
                deleteAlert.Accept();

                actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()-1]/td[1]")).Text;

                Assert.That(actualCode != "January2024-Y", "Record Deleted successfully");

                //if (actualCode.Text != "January2024-Y")
                //{
                //    Console.WriteLine("Deleted successfull");
                //}
                //else
                //{
                //    Console.WriteLine("Record Not Deleted");
                //}
            }
        }

    }
}
