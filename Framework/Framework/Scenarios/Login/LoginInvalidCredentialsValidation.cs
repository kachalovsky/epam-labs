using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.PageBehaviors;
using Framework.Scenarios.Interfaces;

namespace Framework.Scenarios.Login
{
    class LoginInvalidCredentialsValidation: IScenario<LoginPageBehaviors>
    {
        IWebDriver webDriver;
        public LoginPageBehaviors ResultPage { get; private set; }
        private MainPageBehaviors MainPage { get; set; }
        const string from = "TORONTO";
        const string to = "MONTRÉAL";
        LoginPageBehaviors.LoginCredentials credentials = new LoginPageBehaviors.LoginCredentials("test01@gmail.com", "221122");

        public LoginInvalidCredentialsValidation(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void Prepaire()
        {
            webDriver.Navigate().GoToUrl(Constants.BASE_URL);
            MainPage = new MainPageBehaviors(webDriver);
        }

        public void ImplementScenario()
        {
            MainPage.GoToLoginPage();
            MainPage.SwitchWebDriverToTab(1);
            ResultPage = new LoginPageBehaviors(webDriver);
            ResultPage.FillCredentials(credentials);
            ResultPage.Login();
        }
        public void FinishScenario()
        {
            webDriver.Close();
            ResultPage.SwitchWebDriverToTab(0);
        }
    }
}
