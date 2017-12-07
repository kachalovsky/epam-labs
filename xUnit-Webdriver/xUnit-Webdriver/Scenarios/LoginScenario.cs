using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnit_Webdriver.PageBehaviors;

namespace xUnit_Webdriver.Scenarios
{
    class LoginScenario
    {
        IWebDriver webDriver;

        public LoginScenario(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            webDriver.Navigate().GoToUrl(Constants.BASE_URL);
        }

        public void NavigateToLoginPage()
        {
            var mainPage = new MainPageBehaviors(webDriver);
            mainPage.PresentLoginPage();
        }

        public void Authorize (LoginPageBehaviors.LoginCredentials credentials)
        {
            var loginPage = new LoginPageBehaviors(webDriver); ;
            loginPage.FillCredentials(credentials);
            loginPage.TryLogin();
        }
    }
}
