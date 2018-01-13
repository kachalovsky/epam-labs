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
    class RoundTripReturnDateValidation : IScenario<BuyTicketPageBehaviors>
    {
        IWebDriver webDriver;
        public BuyTicketPageBehaviors ResultPage { get; private set; }
        const string from = "TORONTO";
        const string to = "MONTRÉAL";

        public RoundTripReturnDateValidation(IWebDriver driver)
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
            ResultPage.TypeOfJourney = BuyTicketPageBehaviors.TypesOfJourney.RoundTrip;
            ResultPage.From = from;
            ResultPage.To = to;
            ResultPage.SelectDepartureDate(DateTime.Now.AddDays(1));
            ResultPage.AuditsCount = 1;
            ResultPage.ClickSearch();
            ResultPage.SwitchToAlert();
        }
        public void FinishScenario()
        {
            ResultPage.AcceptAlert();
            ResultPage.SwitchToContent();
        }
    }
}
