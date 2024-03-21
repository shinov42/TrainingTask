using FluentAssertions.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTask.Utils
{
    internal class Browser 
    {
        private static WebDriver driver = null;
        private static WebDriverWait wait = null;
        private static readonly long maxWait = ConfigReader.GetConfigTestDataValue("maxWait");

        public Browser(WebDriver webDriver) 
        {
            driver = webDriver;
        }

        public static WebDriver GetDriver()
        {
           
            return driver;
        }
        
    }
}
