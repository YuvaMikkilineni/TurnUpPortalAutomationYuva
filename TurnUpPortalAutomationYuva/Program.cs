using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//Open Chrome Browser
IWebDriver driver = new ChromeDriver();

//Maximize the browser
driver.Manage().Window.Maximize();

//Launch TurnUp Portal and navigate to login page (http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f)
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//identify username textbox and enter valid username
IWebElement usernnameTextBox = driver.FindElement(By.Id("UserName"));
usernnameTextBox.SendKeys("hari");

//identify password textbox and enter valid username
IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
passwordTextBox.SendKeys("123123");

//identify the login button and click on the button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();

//Check if user has logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));


if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't ben logged in...");
}




//Navigate to Time and Material Module
IWebElement adminstrationDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
adminstrationDropDown.Click();

IWebElement TMoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
TMoption.Click();

//Click on Create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

//Select Time from TypeCode
IWebElement typeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
typeDropDown.Click();

IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
timeOption.Click();

//Input Code
IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
codeTextBox.SendKeys("January2024-Y");

//Input Description
IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
descriptionTextBox.SendKeys("January2024-Y");

//Identify the Price TextBox and enter
IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextBox.SendKeys("100");

//Click on Save Button
IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
Thread.Sleep(2000);

//Click on Last Page button
IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPage.Click();
Thread.Sleep(2000);

//Check if record is present
IWebElement actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


if  (actualCode.Text == "January2024-Y")
{
    Console.WriteLine("The Record Created Successfully");
}else
{
    Console.WriteLine("Record Not Created");
}

//Edit the Record January2024-Y
IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();

descriptionTextBox = driver.FindElement(By.Id("Description"));
descriptionTextBox.Clear();
descriptionTextBox.SendKeys("Automation Testing- Yuva");

saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
Thread.Sleep(2000);

goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPage.Click();
Thread.Sleep(2000);

actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

if (actualCode.Text == "Automation Testing- Yuva")
{
    Console.WriteLine("Updated successfull");
}else
{
    Console.WriteLine("Record Not Updated");
}

//Delete the Record January2024-Y
IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

IAlert deleteAlert = driver.SwitchTo().Alert();

//string text = deleteAlert.Text;
deleteAlert.Accept();

actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()-1]/td[1]"));

if (actualCode.Text != "January2024-Y")
{
    Console.WriteLine("Deleted successfull");
}
else
{
    Console.WriteLine("Record Not Deleted");
}
