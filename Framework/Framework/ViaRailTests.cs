using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.PageBehaviors;
using Framework.Scenarios;
using Framework.Scenarios.CultureAdaptation;
using Framework.Scenarios.Login;
using Framework.Scenarios.TicketsPurchasing;
using Framework.WebDriverManagers;

namespace Framework
{
    [TestFixture]
    class ViaRailTests
    {
        const string dicountCodeValidationMessage = "You have provided an invalid discount code and/or serial number. You can correct it on the \"Passenger information\" screen for this purchase, or do it permanently by editing your profile and restarting your booking.";
        const string missingReturnDateValidationMessage = "Please enter a return date.";
        const string excesssPassengersCountValidationMessage = "You have exceeded the maximum of 6 passengers.";
        const string invalidCredentialsValidationError = "Your credentials are invalid";
        const string japaneseLanguageTitle = "VIA鉄道日本公式ホームページ／列車で旅するカナダ";
        IWebDriver webDriver;
        SuccessOneWayBuying successOneWayBuyingScenario;
        SuccessOneWayMultiPassengersBuying successOneWayMultiPassengersBuying;
        SuccessRoundTripBuying successRoundTripBuyingScenario;
        PreviousDateSelectingValidation previousDateSelectingScenario;
        InvalidDiscountCodeValidation invalidDiscountCodeScenario;
        RoundTripReturnDateValidation roundTripReturnDateValidation;
        RoundTripDepartureDateValidation roundTripDepartureDateValidation;
        ExcessPassengersCountValidation excessPassengersCountValidation;
        LoginInvalidCredentialsValidation loginInvalidCredentialsValidation;
        ChangeLanguageScenario changeLanguageScenario;

        [SetUp]
        public void OnStart()
        {
            webDriver = ChromeWebDriverManager.GetInstance();
            successOneWayBuyingScenario = new SuccessOneWayBuying(webDriver);
            previousDateSelectingScenario = new PreviousDateSelectingValidation(webDriver);
            invalidDiscountCodeScenario = new InvalidDiscountCodeValidation(webDriver);
            roundTripReturnDateValidation = new RoundTripReturnDateValidation(webDriver);
            roundTripDepartureDateValidation = new RoundTripDepartureDateValidation(webDriver);
            successRoundTripBuyingScenario = new SuccessRoundTripBuying(webDriver);
            excessPassengersCountValidation = new ExcessPassengersCountValidation(webDriver);
            successOneWayMultiPassengersBuying = new SuccessOneWayMultiPassengersBuying(webDriver);
            loginInvalidCredentialsValidation = new LoginInvalidCredentialsValidation(webDriver);
            changeLanguageScenario = new ChangeLanguageScenario(webDriver);
        }

        [Test]
        public void SuccessOneWayBuying()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                successOneWayBuyingScenario,
                page => Assert.AreEqual(true, page.IsShowingResultsTable)
            );
            runner.Start();
        }

        [Test]
        public void PreviousDateSelecting()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                previousDateSelectingScenario,
                page => Assert.AreEqual(true, page.IsSelectingPreviousDateFailed)
            );
            runner.Start();
        }

        [Test]
        public void InvalidDiscountCode()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                invalidDiscountCodeScenario,
                page => Assert.AreEqual(dicountCodeValidationMessage, page.AlertErrorMessage)
            );
            runner.Start();
        }

        [Test]
        public void RoundTripReturnDateValidation()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                roundTripReturnDateValidation,
                page => Assert.AreEqual(missingReturnDateValidationMessage, page.AlertText)
            );
            runner.Start();
        }

        [Test]
        public void SuccessRoundTripBuying()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                successRoundTripBuyingScenario,
                page => Assert.AreEqual(true, page.IsShowingResultsTable)
            );
            runner.Start();
        }

        [Test]
        public void RoundTripDepartureDateValidation()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                roundTripDepartureDateValidation,
                page =>
                {
                    Assert.AreEqual(1, page.CountOfTabs);
                    Assert.IsTrue(page.IsDepartureDateRequired);
                }
            );
            runner.Start();
        }

        [Test]
        public void ExcessPassengersCount()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                excessPassengersCountValidation,
                page => Assert.AreEqual(excesssPassengersCountValidationMessage, page.AlertText)
            );
            runner.Start();
        }

        [Test]
        public void SuccessOneWayMultiPassengersBuying()
        {
            ScenarioRunner<BuyTicketPageBehaviors> runner = new ScenarioRunner<BuyTicketPageBehaviors>(
                successOneWayMultiPassengersBuying,
                page => Assert.IsTrue(page.IsShowingResultsTable)
            );
            runner.Start();
        }

        [Test]
        public void LoginInvalidCredentialsValidation()
        {
            ScenarioRunner<LoginPageBehaviors> runner = new ScenarioRunner<LoginPageBehaviors>(
                loginInvalidCredentialsValidation,
                page => Assert.IsTrue(page.ValidationError.StartsWith(invalidCredentialsValidationError))
            );
            runner.Start();
        }

        [Test]
        public void ChangeLanguage()
        {
            ScenarioRunner<MainPageBehaviors> runner = new ScenarioRunner<MainPageBehaviors>(
                changeLanguageScenario,
                page => Assert.AreEqual(japaneseLanguageTitle, page.PageTitle)
            );
            runner.Start();
        }


        [TearDown]
        public void Finish()
        {
             ChromeWebDriverManager.CloseDriver();
        }
    }
}
