using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System.IO;

namespace Mercury.Autotest
{
    public class BasePageElementMap
    {
        protected IWebDriver browser;
        protected WebDriverWait browserWait;
        public ExtentTest extentTest;

        public BasePageElementMap()
        {
            this.browser = Driver.Browser;
            this.browserWait = Driver.BrowserWait;
            this.extentTest = ExtentReportManager.ExtentTest;
        }

        public void SwitchToWindow(int i)
        {
            this.browser.SwitchTo().Window(browser.WindowHandles[i]);
        }

        public void TakeScreenshot(string scrName)
        {
            ITakesScreenshot screenshotDriver = this.browser as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string pathFileString = Path.Combine(ExtentReportManager.path, scrName);
            screenshot.SaveAsFile(pathFileString, System.Drawing.Imaging.ImageFormat.Jpeg);
            
        }
    }
}
