using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.PageBehaviors;
using Framework.Scenarios.Interfaces;

namespace Framework.Scenarios.TicketsPurchasing
{
    class InvalidDiscountCodeValidation : IScenario<BuyTicketPageBehaviors>
    {
        IWebDriver webDriver;
        public BuyTicketPageBehaviors ResultPage { get; private set; }
        const string from = "TORONTO";
        const string to = "MONTRÉAL";
        const string discountCode = "123456";

        public InvalidDiscountCodeValidation(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void Prepaire()
        {
            webDriver.Navigate().GoToUrl(Constants.GenerateUrl(Constants.Routes.ByeTicket));
            ResultPage = new BuyTicketPageBehaviors(webDriver);
        }

        public void ImplementScenario()
        {            
            ResultPage.TypeOfJourney = BuyTicketPageBehaviors.TypesOfJourney.OneWay;
            ResultPage.From = from;
            ResultPage.To = to;
            ResultPage.SelectDepartureDate(DateTime.Now);
            ResultPage.AuditsCount = 1;
            ResultPage.DiscountCode = discountCode;
            ResultPage.ClickSearch();
            ResultPage.SwitchWebDriverToTab(1);
        }
        public void FinishScenario()
        {
            webDriver.Close();
            ResultPage.SwitchWebDriverToTab(0);
        }
    }
}
