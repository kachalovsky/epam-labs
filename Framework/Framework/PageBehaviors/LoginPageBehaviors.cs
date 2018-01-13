using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageBehaviors
{
    class LoginPageBehaviors: PageBehaviors
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

        IWebElement loginField;
        IWebElement passwordField;
        IWebElement loginButton;
        public string ValidationError
        {
            get
            {
                var validationBlock = WaitElement(20, By.ClassName("rem-message"));
                if (validationBlock != null) return validationBlock.Text;
                return null;
            }
        }

        public LoginPageBehaviors(IWebDriver webDriver): base(webDriver)
        {
            loginField = webDriver.FindElement(By.Name("l"));
            passwordField = webDriver.FindElement(By.Name("p"));
            loginButton  = webDriver.FindElement(By.CssSelector("input[title=Login]"));

        }

        public void Login()
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
