using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageBehaviors
{
    class PageBehaviors
    {
        protected IWebDriver webDriver;
        protected IAlert alert;

        public PageBehaviors(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string PageTitle { get => webDriver.Title; }

        public string AlertText { get => alert.Text; }

        public void SwitchToAlert()
        {
            alert = webDriver.SwitchTo().Alert();
        }

        public void SwitchToContent()
        {
            webDriver.SwitchTo().DefaultContent();
        }

        public void SwitchWebDriverToTab(int index)
        {
            var browserTabs = webDriver.WindowHandles;
            webDriver.SwitchTo().Window(browserTabs[index]);
        }

        public void AcceptAlert()
        {
            alert.Accept();
            alert = null;
        }

        public string AlertErrorMessage
        {
            get
            {
                var alertErrorBlock = WaitElement(20, By.ClassName("alert-message"));
                if(alertErrorBlock != null) return alertErrorBlock.Text;
                return null;
            }

        }

        public IWebElement WaitElement(int maxWait, By findBy)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(maxWait));
                var element = wait.Until(drv => webDriver.FindElement(findBy));
                return element;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverTimeoutException) return null;
                throw ex;
            }
        }

        public bool IsElementShowing(int maxWait, By findBy)
        {
            return WaitElement(maxWait, findBy) != null;
        }


    }
}
