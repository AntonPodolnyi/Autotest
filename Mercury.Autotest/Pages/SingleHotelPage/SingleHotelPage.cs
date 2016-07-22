using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace Mercury.Autotest.Pages.SingleHotelPage
{
    public class SingleHotelPage : BasePage<SingleHotelPageMap, SingleHotelPageProcessing>
    {
        public void TakeScreenshot(string scrName)
        {
            try
            {
                this.Map.TakeScreenshot(scrName);
                extentTest.Log(LogStatus.Pass, "Скриншот успешно сохранен " + extentTest.AddScreenCapture(Path.Combine(ExtentReportManager.path, scrName)));
            }
            catch(Exception ex)
            {
                extentTest.Log(LogStatus.Pass, "Не удалось сохранить скриншот. Причина: " + ex.Message);
            }
        }
    }
}