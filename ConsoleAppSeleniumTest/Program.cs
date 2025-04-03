using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ConsoleAppSeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Selenium!");
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(@"http://127.0.0.1:5500");

            System.Console.WriteLine("driver url:" + driver.Url);

            //documentation for finding elements : https://www.selenium.dev/documentation/webdriver/locating_elements/

            IWebElement Inputelement1 = driver.FindElement(By.Id("input1"));


            //find element by id 
            IWebElement buttonElement = driver.FindElement(By.Id("testButton1"));

            //print out the text for the button in the console
            Console.WriteLine("Button text: " + buttonElement.Text);
            //print out the class attribute for the button in the console
            Console.WriteLine("class :" + buttonElement.GetAttribute("class"));
            
            for (int i = 0; i < 3; i++)
            {
                //send input to the input field
                Inputelement1.SendKeys("hello from selenium");
                //wait 500 ms
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            }

            //click the button
            buttonElement.Click();

            //find element by id 
            IWebElement button2Element = driver.FindElement(By.Id("testButton2"));
            button2Element.Click();

            //press the button five times
            for (int i = 0; i < 5; i++)
            {
                //send input to the input field
                button2Element.Click();
                //wait
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
                Console.WriteLine("i: "+i);
            }

            //find an element by id and the find an element inside this with tagname
            IWebElement element2 = driver.FindElement(By.Id("app")).FindElement(By.TagName("Button"));
            Console.WriteLine("text: " + element2.Text);
            Console.WriteLine("END!");


            Console.WriteLine("press to quit driver");
            Console.ReadLine();



            driver.Quit();

        }
    }
}
