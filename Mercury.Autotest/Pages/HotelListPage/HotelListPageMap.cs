using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mercury.Autotest.Pages.HotelListPage
{
    public class HotelListPageMap : BasePageElementMap
    {
        public IWebElement PriceCategory(int priceCategory)
        {
            string priceSelector = "a[data-id='pri-" + priceCategory.ToString() + "']";
            return this.browserWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(priceSelector)));
        }

        public IWebElement AjaxOverlay
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("div.overlay_msg"));
            }
        }

        public IWebElement Body
        {
            get
            {
                return this.browser.FindElement(By.CssSelector("body"));
            }
        }

        public void WaitForAjaxWorking()
        {
            browserWait.Until<IWebElement>((d) =>
            {
                if (AjaxOverlay.Displayed)
                {
                    return AjaxOverlay;
                }
                return null;
            });
            browserWait.Until<IWebElement>((d) =>
            {
                if (!AjaxOverlay.Displayed)
                {
                    return AjaxOverlay;
                }
                return null;
            });

            for (int i = 1; i < 15; i++)
            {
                Thread.Sleep(800);
                this.Body.SendKeys(Keys.PageDown);
            }
            this.Body.SendKeys(Keys.Home);
            Thread.Sleep(800);
        }

        public List<IWebElement> GetAllHotels()
        {
            return this.browser.FindElements(By.CssSelector("div.sr_item")).ToList();
        }

        public IWebElement GetHotelPrice(IWebElement hotel)
        {
            return hotel.FindElement(By.CssSelector(".price"));
        }

        public IWebElement GetHotelRating(IWebElement hotel)
        {
            return hotel.FindElement(By.CssSelector(".rating"));
        }

        public IWebElement GetHotelLink(IWebElement hotel)
        {
            return hotel.FindElement(By.CssSelector(".hotel_name_link"));
        }
    }
}
