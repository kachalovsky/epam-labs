using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageBehaviors
{
    class MainPageBehaviors : PageBehaviors
    {
        IWebElement logInLink;
        SelectElement languageSelect;

        public enum Languages { English, French, Spanish, German, Dutch, Portuguese, Chines, Japanese, Korean }

        Languages[] languagesMapping = new Languages[] {
            Languages.English, Languages.French, Languages.Spanish, Languages.German,
            Languages.French, // Double French in list
            Languages.Dutch, Languages.Portuguese, Languages.Chines, Languages.Japanese, Languages.Korean };

        public Languages CurrentLanguage { set => languageSelect.SelectByIndex(Array.IndexOf(languagesMapping, value)); }

        public MainPageBehaviors(IWebDriver webDriver): base(webDriver)
        {
            logInLink = webDriver.FindElement(By.Id("ui-id-3"));
            languageSelect = new SelectElement(webDriver.FindElement(By.Id("language_selector")));
        }

        public void GoToLoginPage()
        {
            logInLink.Click();
        }
    }
}
