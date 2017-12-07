using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Webdriver.PageBehaviors
{
    class LoginPageBehaviors
    {
        public class LoginCredentials
        {
            public LoginCredentials(string email, string password)
            {
                Email = email;
                Password = password;
            }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        IWebDriver webDriver;
        IWebElement loginField;
        IWebElement passwordField;
        IWebElement loginButton;

        public LoginPageBehaviors(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            loginField = webDriver.FindElement(By.Id("login_field"));
            passwordField = webDriver.FindElement(By.Id("password"));
            loginButton  = webDriver.FindElement(By.Name("commit"));

        }

        public void TryLogin()
        {
            loginButton.Click();
        }

        public void FillCredentials(LoginCredentials credentials)
        {
            loginField.SendKeys(credentials.Email);
            passwordField.SendKeys(credentials.Password);
        }
    }
}
