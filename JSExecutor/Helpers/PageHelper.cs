using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace JSExecutorQAA
{
    class PageHelper
    {
        private IWebDriver driver;
        private JSExecutor jsExecutor;
        private const string URL_GOOGLE = @"https://www.google.ru/";
        private By searchInput = By.Id("lst-ib");
        private By checkDowloadResultSearch = By.ClassName("g");

        public PageHelper(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            jsExecutor = new JSExecutor(driver);
            this.driver = driver;
        }

        public bool IsScrollPresent()
        {
            return jsExecutor.GetPageScrollPresence();
        }

        public void InputText(string text)
        {
            driver.FindElement(searchInput).SendKeys(text);
        }

        public void PressEnterSearchAndWaitDownloadPage()
        {
            driver.FindElement(searchInput).SendKeys(Keys.Enter);
            try
            {
                driver.FindElement(checkDowloadResultSearch);
            }
            catch
            {
                TestContext.Out.WriteLine("\r\nне загружаются результаты поиска");
            }
        }

        public void DeleteFocus()
        {
            jsExecutor.DeleteFocus();
        }

        public void GoToPageGoogle()
        {
            driver.Navigate().GoToUrl(URL_GOOGLE);
        }

        public string GetSearchInputWidth()
        {
            return jsExecutor.GetWebElementWidth(driver.FindElement(searchInput));
        }
    }
}
