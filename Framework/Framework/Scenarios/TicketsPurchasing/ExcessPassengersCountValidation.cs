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
    class ExcessPassengersCountValidation : IScenario<BuyTicketPageBehaviors>
    {
        IWebDriver webDriver;
        public BuyTicketPageBehaviors ResultPage { get; private set; }
        const string from = "TORONTO";
        const string to = "MONTRÉAL";

        public ExcessPassengersCountValidation(IWebDriver driver)
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
            ResultPage.SelectDepartureDate(DateTime.Now.AddDays(1));
            ResultPage.SelectDepartureDate(DateTime.Now.AddDays(7));
            ResultPage.AuditsCount = 1;
            ResultPage.SeniorsCount = 5;
            ResultPage.ChildrenCount = 5;
            ResultPage.YouthsCount = 3;
            ResultPage.InflantsCount = 2;
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
