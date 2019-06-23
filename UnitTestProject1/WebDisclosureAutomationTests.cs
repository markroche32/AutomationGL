using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class WebDisclosureAutomationTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestInitialize()]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();      
            driver.Navigate().GoToUrl("https://viewpoint.glasslewis.com/WD/?siteId=DemoClient");
          
        }

        [TestMethod]
        public void WD_UpdateCounrtyShouldDisplayOnlyThatCountrysMeetingResults()
        {
            var country = "Belgium";
            new WebDisclosureModel(driver).CountryCheckBox(country).Click(driver);
            new WebDisclosureModel(driver).Update.Click(driver);
            new WebDisclosureModel(driver).VerifyAllCountyColumnsAreContainCountry(country);     
        }


        [TestMethod]
        public void WD_ClickCompanyNameShouldNavigateToCompanysVoteCardPage()
        {           
            var company = "Activision Blizzard Inc";
            bool found = false;

            while (!found)
            {
                try
                {
                    new WebDisclosureModel(driver).CompanyName(company).Click(driver);
                    found = true;
                    Assert.AreEqual(company, new WebDisclosureModel(driver).CompanyVoteCardPage(company).GetText(driver));

                }
                catch (NoSuchElementException ex)
                {
                    //Go Right to Next Page While Possible and Repeat above logic in try block
                    if (!new WebDisclosureModel(driver).GoRight.GetAttribute("class").Contains("disabled"))
                    {
                        new WebDisclosureModel(driver).GoRight.Click(driver);
                    }
                    else
                    {
                        Assert.Fail("Company : " + company + " Is Not Available For Selection");
                    }
                    
                }
            }
        
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

    }
}
