

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestProject1
{
    class WebDisclosureModel
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = @"//label[@for='Belgium-cb-CountryFilter']")]
        public IWebElement BelgiumCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = @"//*[@id='btn-update'][@class='btnMain btnSize']")]
        public IWebElement Update { get; set; }

        [FindsBy(How = How.XPath, Using = @"//table//tbody//tr//td[4]")]
        public IList<IWebElement> CountryColumn { get; set; }

        [FindsBy(How = How.XPath, Using = @"//a[@title='Go to the next page']")]
        public IWebElement GoRight { get; set; }


        public WebDisclosureModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public IWebElement CountryCheckBox(string country)
        {

            return driver.FindElement(By.XPath("//label[@for='" + country + "-cb-CountryFilter']"));
        }

        public IWebElement CompanyName(string company)
        {

            return driver.FindElement(By.XPath("//a[contains(text(),'" + company + "')]"));
        }

        public IWebElement CompanyVoteCardPage(string company)
        {

            return driver.FindElement(By.XPath("//span[@id='detail-issuer-name' and text()='" + company + "']"));
        }

        public void VerifyAllCountyColumnsAreContainCountry(string country)
        {
            int count = 0;

            //Initialize All Country Column Elements
            IList<IWebElement> countryColumnsElem = new WebDisclosureModel(driver).CountryColumn;

            //Iterate All Country Column Elements
            for (int i=0; i < countryColumnsElem.Count;i++) 
             {
                string title = countryColumnsElem[i].GetText(driver);
                Assert.AreEqual(title, country);
                count++;

                //When Country Columns >= 50, Recursively perform same logic above 
                //Naviage to Next Page if Possible ; case where Country Columns == 50
                if (count == 49 && !new WebDisclosureModel(driver).GoRight.GetAttribute("class").Contains("disabled"))
                {
                    new WebDisclosureModel(driver).GoRight.Click(driver);
                    VerifyAllCountyColumnsAreContainCountry(country);
                }
            }

        }

    }

}
