using OpenQA.Selenium;

namespace JSExecutorQAA
{
    class JSExecutor
    {
        private IJavaScriptExecutor javaScriptExecutor;

        public JSExecutor(IWebDriver driver)
        {
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }

        public string GetWebElementWidth(IWebElement webElement)
        {
            return javaScriptExecutor.ExecuteScript("return arguments[0].clientWidth;", webElement).ToString();
        }

        public void DeleteFocus()
        {
            javaScriptExecutor.ExecuteScript("document.activeElement.blur()");
        }

        public bool GetPageScrollPresence()
        {
            return bool.Parse(javaScriptExecutor.ExecuteScript("return (document.body.offsetHeight > window.innerHeight)").ToString());
        }
    }
}
