using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;

namespace Mercury.Autotest.Pages.HotelListPage
{
    public class HotelListPage : BasePage<HotelListPageMap, HotelListPageProcessing>
    {
        public HotelListPage()
        {
        }

        public void ChoosePriceCategory(int priceCategory)
        {
            try
            {
                this.Map.PriceCategory(priceCategory).Click();
                extentTest.Log(LogStatus.Pass, "Выбрана ценовая категория: " + priceCategory);
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать ценовую категорию: " + priceCategory + " Причина: " + ex.Message);
            }
        }

        public void ChooseBestRatingHotel()
        {
            extentTest.Log(LogStatus.Info, "Поиск отеля с высшим рейтингом...");
            try
            {
                this.Process().GetTheBestRatingHotel().Click();
                this.Map.SwitchToWindow(1);
                extentTest.Log(LogStatus.Pass, "Выполнен переход к лучшему отелю");
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось перейти к лучшему отелю. Причина: " + ex.Message);
            }
        }
    }
}
