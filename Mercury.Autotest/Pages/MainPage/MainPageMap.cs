using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mercury.Autotest.Pages.MainPage
{
    public class MainPageMap : BasePageElementMap
    {
        public IWebElement City
        {
            get
            {
                return this.browser.FindElement(By.Id("ss"));
            }
        }

        public IWebElement CheckInDate
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("div[data-mode='check-in']"));
            }
        }

        public IWebElement CheckInDateString
        {
            get
            {
                return this.CheckInDate.FindElement(By.CssSelector(".sb-date-picker__date"));
            }
        }

        public IWebElement CalendarCurrentDay
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("td.c2-day-s-today"));
            }
        }

        public IWebElement CheckOutDate
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("div[data-mode='check-out']"));
            }
        }

        public IWebElement CheckOutDateString
        {
            get
            {
                return this.CheckOutDate.FindElement(By.CssSelector(".sb-date-picker__date"));
            }
        }

        public IWebElement Rooms
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("#no_rooms"));
            }
        }

        public IWebElement Adults
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("#group_adults"));
            }
        }

        public IWebElement Submit
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("button[type='submit']"));
            }
        }

        public IWebElement CalendarCheckOutDate(long i)
        {
            string lastDateCssSelector = "td.c2-day[data-id='" + i + "']";
            return this.browser.FindElement(By.CssSelector("div[data-mode='check-out'] + div")).FindElement(By.CssSelector(lastDateCssSelector));

        }

        public void WaitForAutosearch()
        {
            browserWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.c-autocomplete__list")));
        }

        public void Maximize()
        {
            this.browser.Manage().Window.Maximize();
        }

        public void Navigate(string url)
        {
            this.browser.Navigate().GoToUrl(url);
        }
    }
}

