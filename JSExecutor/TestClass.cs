using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace JSExecutorQAA
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;




        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }


        [Test]
        public void TestJSExecutor()
        {
            string enterText = "введеный текст";

            PageHelper page = new PageHelper(driver);
            page.GoToPageGoogle();
            TestContext.Out.WriteLine("\r\nШирина поискового поля: " + 
                page.GetSearchInputWidth() + " пикселя(ей)");
            Assert.True(!page.IsScrollPresent());
            page.InputText(enterText);
            page.DeleteFocus();
            page.PressEnterSearchAndWaitDownloadPage();
            Assert.True(page.IsScrollPresent());
        }
    }
}