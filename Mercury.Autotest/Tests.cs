using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.IO;

namespace Mercury.Autotest
{
    [TestFixture]
    public class Tests
    {
        ExtentReports extent;
        string path = @"C:\_TestReports";
        string currentTimeString = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

        [SetUp]
        public void SetupTest()
        {          
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
           
            string pathFileString = Path.Combine(path, "test_"+currentTimeString + ".html");
            extent = new ExtentReports(pathFileString);

            Driver.StartBrowser(BrowserTypes.Firefox);
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }

        [Test]
        public void BookingUnitTestScenario()
        {    
            var test = extent.StartTest("Тестовый сценарий 1", "Сценарий-проверка для сайта booking.com");
            ExtentReportManager.StartManager(test, path);

            test.Log(LogStatus.Info, "Старт сценария");

            string mainUrl = "http://www.booking.com/";
            string city = "Самара";
            int daysToStay = 4;
            int rooms = 1;
            int adults = 2;
            int priceCategory = 2;
            int maxPrice = 6900;
            string scrName = "test_" + currentTimeString + "_pic_01.jpeg";

            new TestFacade().BookingUnitTest(mainUrl, city, daysToStay, rooms, adults, priceCategory, maxPrice, scrName);

            test.Log(LogStatus.Info, "Завершение сценария");

            extent.EndTest(test);
            extent.Flush();
            extent.Close();

            Console.WriteLine("Выполнение сценария завершено. Отчет и скриншот сохранены в каталоге: " + path);
        }
    }
}
