using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace Mercury.Autotest.Pages.HotelListPage
{
    public class HotelListPageProcessing : BasePageProcessing<HotelListPageMap>
    {
        public void CheckPricesForNight(int maxPrice, int daysToStay)
        {
            this.Map.WaitForAjaxWorking();

            extentTest.Log(LogStatus.Info, "Проверка цен за ночь...");

            double daily_price;
            string priceText;
            bool passed = true;
            List<IWebElement> hotels = this.Map.GetAllHotels();

            foreach (IWebElement hotel in hotels)
            {
                priceText = FindPriceText(hotel);

                if (priceText != String.Empty)
                {
                    priceText = ParseString(priceText);
                    try
                    {
                        daily_price = Double.Parse(priceText) / daysToStay;

                        if (daily_price <= maxPrice)
                        {
                            extentTest.Log(LogStatus.Pass, "Цена за ночь OK: " + daily_price + " руб. - " + this.Map.GetHotelLink(hotel).Text);
                        }
                        else
                        {
                            extentTest.Log(LogStatus.Fail, "Цена за ночь завышена: " + daily_price + " руб. - " + this.Map.GetHotelLink(hotel).Text);
                            passed = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        extentTest.Log(LogStatus.Info, "Не удалось определить цену за ночь: " + this.Map.GetHotelLink(hotel).Text + " Причина: " + ex.Message);
                    }
                }
                else
                {
                    extentTest.Log(LogStatus.Info, "Цена отсутствует: " +  this.Map.GetHotelLink(hotel).Text);
                }
            }

            if (passed)
            {
                extentTest.Log(LogStatus.Pass, "Все цена за ночь успешно проверены");
            }
            else
            {
                extentTest.Log(LogStatus.Fail, "В ценах за ночь найдено превышение!");
            }
        }

        private string FindPriceText(IWebElement hotel)
        {
            string priceText = string.Empty;
            try
            {
                priceText = this.Map.GetHotelPrice(hotel).Text;
            }
            catch (Exception ex)
            { }

            return priceText;
        }

        private string ParseString(string str)
        {
            char[] massive = str.ToCharArray();
            string str_short = String.Empty;

            foreach (char x in massive)
            {
                if (char.IsDigit(x) || x == ',')
                {
                    str_short += x;
                }
            }
            return str_short;
        }

        private string FindRatingText(IWebElement hotel)
        {
            string ratingText = string.Empty;
            try
            {
                ratingText = this.Map.GetHotelRating(hotel).Text;
            }
            catch (Exception ex)
            { }

            return ratingText;
        }

        public IWebElement GetTheBestRatingHotel()
        {
            IWebElement bestHotel = null;
            double bestRating = 0;
            double currentRating_double;
            string currentRating_string;

            List<IWebElement> hotels = this.Map.GetAllHotels();

            foreach (IWebElement hotel in hotels)
            {
                if (FindPriceText(hotel) != String.Empty)
                {
                    currentRating_string = FindRatingText(hotel);
                    if (currentRating_string != String.Empty)
                    {
                        currentRating_string = ParseString(currentRating_string);
                        try
                        {
                            currentRating_double = Double.Parse(currentRating_string);
                            if (currentRating_double > bestRating)
                            {
                                bestRating = currentRating_double;
                                bestHotel = hotel;
                            }
                        }
                        catch (Exception ex)
                        { 
                        }
                    }
                }
            }
            if (bestHotel != null)
            {
                bestHotel = this.Map.GetHotelLink(bestHotel);
                extentTest.Log(LogStatus.Pass, "Найден отель с лучшим рейтингом: " + bestRating + " - " + bestHotel.Text);
            }
            else
            {
                extentTest.Log(LogStatus.Fail, "Не удалось найти отель с лучшим рейтингом.");
            }
            return bestHotel;
        }
    }
}
