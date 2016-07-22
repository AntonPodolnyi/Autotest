using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;

namespace Mercury.Autotest.Pages.MainPage
{
    public class MainPage : BasePage<MainPageMap, MainPageProcessing>
    {

        string CurrentDate_id;

        public MainPage()
        {
        }

        public void Navigate(string url)
        {
            try
            {
                this.Map.Navigate(url);
                extentTest.Log(LogStatus.Pass, "Переход на "+ url + " выполнен");
            }
            catch(Exception ex)
            {
                extentTest.Log(LogStatus.Fatal, "Не удалось перейти на " + url + " Причина: " + ex.Message);
            }
        }

        public void MaximizeWindow()
        {
            try
            {
                this.Map.Maximize();
                extentTest.Log(LogStatus.Pass, "Окно браузера развернуто на весь экран");
            }
            catch(Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось развернуть окно браузера на весь экран. Причина: " + ex.Message);
                
            }
        }

        public void ChooseCity(string city)
        {
            try
            {
                this.Map.City.SendKeys(city);
                this.Map.WaitForAutosearch();
                this.Map.City.SendKeys(Keys.Escape);
                extentTest.Log(LogStatus.Pass, "Выбран город: " + city);
            }
            catch(Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать город: " + city + " Причина: " + ex.Message);
            }

        }

        public void ChooseCheckInDate()
        {
            try
            {
                this.Map.CheckInDate.Click();
                CurrentDate_id = this.Map.CalendarCurrentDay.GetAttribute("data-id");
                this.Map.CalendarCurrentDay.Click();
                extentTest.Log(LogStatus.Pass, "Дата заезда выбрана: " + this.Map.CheckInDateString.Text);
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать дату заезда. Причина: " + ex.Message);
            }

        }

        public void ChooseCheckOutDate(int daysToStay)
        {
            try
            {
                long i = long.Parse(CurrentDate_id) + daysToStay * 86400000;
                this.Map.CheckOutDate.Click();
                this.Map.CalendarCheckOutDate(i).Click();
                extentTest.Log(LogStatus.Pass, "Дата отъезда выбрана: " + this.Map.CheckOutDateString.Text);
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать дату отъезда. Причина:" + ex.Message);
            }
        }

        public void ChooseRoomsQuantity(int rooms)
        {
            try
            {
                var select = new SelectElement(this.Map.Rooms);
                select.SelectByText(rooms.ToString());
                extentTest.Log(LogStatus.Pass, "Количество номеров выбрано: " + rooms);
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать количество номеров: " +rooms + " Причина: " + ex.Message);
            }
        }

        public void ChooseAdultsQuantity(int adults)
        {
            try
            {
                var select = new SelectElement(this.Map.Adults);
                select.SelectByText(adults.ToString());
                extentTest.Log(LogStatus.Pass, "Количество взрослых выбрано: " + adults);
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось выбрать количество взрослых: " + adults + " Причина: " + ex.Message);
            }
        }

        public void ClickSubmitButton()
        {
            try
            {
                this.Map.Submit.Click();
                extentTest.Log(LogStatus.Pass, "Кнопка 'Узнать цены' нажата");
            }
            catch (Exception ex)
            {
                extentTest.Log(LogStatus.Fail, "Не удалось нажать кнопку 'Узнать цены'. Причина: " + ex.Message);
            }
        }

    }
}
