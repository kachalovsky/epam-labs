using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.PageBehaviors
{
    class BuyTicketPageBehaviors: PageBehaviors
    {
        const string dateFormat = "dd/mm/yyyy";
        const string dateCalendarSelector = "table.ui-datepicker > tbody > tr > td > a[title=\"{0}\"]";
        const string fromDropDownID = "divStation0";
        const string toDropDownID = "divStation1";
        const string placeAutocompleteCssSelector = "div#{0} > div[pos=\"0\"]";
        public enum TypesOfJourney { RoundTrip, OneWay, MultyCity}
        TypesOfJourney[] typeOfJourneyMapping = new TypesOfJourney[3] { TypesOfJourney.RoundTrip, TypesOfJourney.OneWay, TypesOfJourney.MultyCity };
        SelectElement typeOfJourneySelectField;
        IWebElement fromField;
        IWebElement toField;
        IWebElement returnDateCalendarButton;
        IWebElement returnDateField;
        IWebElement departureDateField;
        IWebElement departureDateCalendarButton;
        IWebElement discountCodeField;
        SelectElement auditsCountField;
        SelectElement seniorsCountField;
        SelectElement youthsCountField;
        SelectElement childrenCountField;
        SelectElement infantsCountField;
        IWebElement searchButton;


        public TypesOfJourney TypeOfJourney { set => SelectTypeOfJourney(value); }
        public String From { set => SelectFrom(value); }
        public String To { set => SelectTo(value); }
        public DateTime DepartureDate { set => departureDateField.SendKeys(value.ToString(dateFormat)); }
        public DateTime ReturnDate { set => returnDateField.SendKeys(value.ToString(dateFormat)); }
        public String DiscountCode { set => discountCodeField.SendKeys(value); }
        public int AuditsCount { set => auditsCountField.SelectByIndex(value); }
        public int SeniorsCount { set => seniorsCountField.SelectByIndex(value); }
        public int YouthsCount { set => youthsCountField.SelectByIndex(value); }
        public int ChildrenCount { set => childrenCountField.SelectByIndex(value); }
        public int InflantsCount { set => infantsCountField.SelectByIndex(value); }
        public bool IsSelectingPreviousDateFailed { get; set; }
        public int CountOfTabs { get => webDriver.WindowHandles.Count(); }
        public bool IsShowingResultsTable { get => IsElementShowing(20, By.Id("fare-matrix")) || IsElementShowing(20, By.Id("trip-selector")); }
        public bool IsDepartureDateRequired { get => departureDateField.GetAttribute("required") == "true"; }

        public BuyTicketPageBehaviors(IWebDriver webDriver): base(webDriver)
        {
            typeOfJourneySelectField = new SelectElement(webDriver.FindElement(By.Name("rad_trip")));
            fromField = webDriver.FindElement(By.Id("cmbStationsFrom"));
            toField = webDriver.FindElement(By.Id("cmbStationsTo"));
            departureDateField = webDriver.FindElement(By.Id("cmbDateFrom"));
            departureDateCalendarButton = webDriver.FindElement(By.CssSelector("div#trainDeparture>button"));
            returnDateCalendarButton = webDriver.FindElement(By.CssSelector("div#trainReturn>button"));
            returnDateField = webDriver.FindElement(By.Id("cmbDateTo"));
            discountCodeField = webDriver.FindElement(By.Id("txtDiscountCode"));
            auditsCountField = new SelectElement(webDriver.FindElement(By.Id("cmbNbAdults")));
            seniorsCountField = new SelectElement(webDriver.FindElement(By.Id("cmbNbSeniors")));
            youthsCountField = new SelectElement(webDriver.FindElement(By.Id("cmbNbYouths")));
            childrenCountField = new SelectElement(webDriver.FindElement(By.Id("cmbNbChilds")));
            infantsCountField = new SelectElement(webDriver.FindElement(By.Id("cmbNbInfants")));
            searchButton = webDriver.FindElement(By.CssSelector("input[value=Search]"));
        }

        public void SelectDepartureDate(DateTime date)
        {
            departureDateCalendarButton.Click();
            SelectDateOnCalendarView(date);
        }

        public void SelectReturnDate(DateTime date)
        {
            returnDateCalendarButton.Click();
            SelectDateOnCalendarView(date);
        }

        private void SelectDateOnCalendarView(DateTime date)
        {
            CultureInfo ci = new CultureInfo("en-US");
            var dateLink = WaitElement(5, By.CssSelector(string.Format(dateCalendarSelector, date.ToString("MMMM  d", ci))));
            if (dateLink != null)
            {
                Thread.Sleep(1000); // wait js scripts loading
                dateLink.Click();
                Thread.Sleep(1000); // wait animations
            }
            else IsSelectingPreviousDateFailed = true;
        }

        private void SelectFrom(string searchString)
        {
            fromField.SendKeys(searchString);
            SelectFirstPlaceFromDropdown(fromDropDownID);
        }

        private void SelectTo(string searchString)
        {
            toField.SendKeys(searchString);
            SelectFirstPlaceFromDropdown(toDropDownID);
        }

        private void SelectFirstPlaceFromDropdown(string dropDownId)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            var placeLink = wait.Until(drv => drv.FindElement(By.CssSelector(string.Format(placeAutocompleteCssSelector, dropDownId))));
            placeLink.Click();
        }

        private void SelectTypeOfJourney(TypesOfJourney type)
        {
            typeOfJourneySelectField.SelectByIndex(Array.IndexOf(typeOfJourneyMapping, type));
        }

        public void OpenPage()
        {
            webDriver.Navigate().GoToUrl(Constants.GenerateUrl(Constants.Routes.ByeTicket));
        }

        public void ClickSearch()
        {
            searchButton.Click();
        }
    }
}
