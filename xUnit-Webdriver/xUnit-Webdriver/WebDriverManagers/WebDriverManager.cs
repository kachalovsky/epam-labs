using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_Webdriver.WebDriverManagers
{
    class WebDriverManager<DriverType> where DriverType: IWebDriver, new()
    {
        private static IWebDriver webDriver;

        public static IWebDriver GetInstance()
        {
            if (webDriver == null) webDriver = new DriverType();

            return webDriver;
        }

        public static void CloseDriver()
        {
            if (webDriver == null) return;

            webDriver.Close();
            webDriver = null;
        }
    }
}
