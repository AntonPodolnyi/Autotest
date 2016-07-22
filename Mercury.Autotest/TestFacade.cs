using Mercury.Autotest.Pages.MainPage;
using Mercury.Autotest.Pages.HotelListPage;
using Mercury.Autotest.Pages.SingleHotelPage;
using RelevantCodes.ExtentReports;

namespace Mercury.Autotest
{
    public class TestFacade
    {
        private MainPage mainPage;
        private HotelListPage hotelListPage;
        private SingleHotelPage singleHotelPage;

        public MainPage MainPage
        {
            get
            {
                if (mainPage == null)
                {
                    mainPage = new MainPage();
                }
                return mainPage;
            }
        }
        public HotelListPage HotelListPage
        {
            get
            {
                if (hotelListPage == null)
                {
                    hotelListPage = new HotelListPage();
                }
                return hotelListPage;
            }
        }
        public SingleHotelPage SingleHotelPage
        {
            get
            {
                if (singleHotelPage == null)
                {
                    singleHotelPage = new SingleHotelPage();
                }
                return singleHotelPage;
            }
        }

        public void BookingUnitTest(string mainUrl, string city, int daysToStay, int rooms, int adults, int priceCategory, int maxPrice, string scrName)
        {
            this.MainPage.Navigate(mainUrl);
            this.MainPage.MaximizeWindow();
            this.MainPage.ChooseCity(city);
            this.MainPage.ChooseCheckInDate();
            this.MainPage.ChooseCheckOutDate(daysToStay);
            this.MainPage.ChooseRoomsQuantity(rooms);
            this.MainPage.ChooseAdultsQuantity(adults);
            this.MainPage.ClickSubmitButton();
            this.HotelListPage.ChoosePriceCategory(priceCategory);
            this.HotelListPage.Process().CheckPricesForNight(maxPrice, daysToStay);
            this.HotelListPage.ChooseBestRatingHotel();
            this.SingleHotelPage.TakeScreenshot(scrName);
        }
    }
}
