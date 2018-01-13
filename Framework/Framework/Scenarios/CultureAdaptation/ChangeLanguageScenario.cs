using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.PageBehaviors;
using Framework.Scenarios.Interfaces;

namespace Framework.Scenarios.CultureAdaptation
{
    class ChangeLanguageScenario: IScenario<MainPageBehaviors>
    {
        IWebDriver webDriver;
        public MainPageBehaviors ResultPage { get; private set; }

        public ChangeLanguageScenario(IWebDriver driver)
        {
            webDriver = driver;
        }

        public void Prepaire()
        {
            webDriver.Navigate().GoToUrl(Constants.BASE_URL);
            ResultPage = new MainPageBehaviors(webDriver);
        }

        public void ImplementScenario()
        {
            ResultPage.CurrentLanguage = MainPageBehaviors.Languages.Japanese;
        }
        public void FinishScenario()
        {
        }
    }
}
