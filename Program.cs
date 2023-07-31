using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;

namespace SpanishPointAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.spanishpoint.ie/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(2000);




            driver.SwitchTo().DefaultContent();

            IWebElement selectone = driver.FindElement(By.LinkText("Reject"));
            selectone.Click();

            Thread.Sleep(2000);

            var elementfrsoln = driver.FindElement(By.XPath("/html/body/div[1]/div/div/ul/li[1]/a/span"));
            elementfrsoln.Click();
            Thread.Sleep(2000);

            var elementfrsoln1 = driver.FindElement(By.LinkText("Modern Work"));
            elementfrsoln1.Click();

            Thread.Sleep(2000);



            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(50,600)");

            Thread.Sleep(2000);

            var contentCollaborationTab = driver.FindElement(By.LinkText("Content & Collaboration"));
            contentCollaborationTab.Click();

            try
            {

                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                IWebElement header = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[1]/section/section/div[3]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/div[2]")));

                IWebElement paragraph = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/section/section/div[3]/div/div/div/div[2]/div/div[2]/div/div[2]/div[2]/div/div[2]/div/div/div[1]/div/p"));
                string paragraphText = paragraph.Text;
                string expectedStartText = "Spanish Point customers tell us that people are their most important asset";

                if (paragraphText.StartsWith(expectedStartText))
                {
                    Console.WriteLine("Assertion: SUCCESSFUL");
                }
                else
                {
                    Console.WriteLine("Assertion: FAILED");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                
                driver.Quit();
            }
        }
    }
}