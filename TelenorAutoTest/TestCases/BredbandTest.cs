using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelenorAutoTest.ModelBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace TelenorAutoTest.TestCases
{
    public class BredbandTest
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = CreateWebDriver("chrome");

        }

        private IWebDriver CreateWebDriver(string browser)
        {
            IWebDriver m_driver;
            string path =  Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

            string driverpath = path + @"\Resources";
            if (browser == "firefox")
            {
                m_driver = new FirefoxDriver(driverpath);
            }
            if (browser == "chrome")
            {
                m_driver = new ChromeDriver(driverpath);
            }
            else
            {

                m_driver = new InternetExplorerDriver(driverpath);
            }
            return m_driver;
        }

        [Test]
        [TestCase(TestName = "Search Subscription", Description = "Searching subscription returns value")]
        public void Search_Subscription()
        {            
            //open Homepage
            PageBase homepage = new PageBase(driver);
            homepage.GoTo("https://www.telenor.se/");

            //click on cookies dialog if available
            if (homepage.CookieButton != null)
            {
                homepage.CookieButton.Click();
            }


            //click on menu
            homepage.Header.MainMenu.ProductMenu.Click();
            homepage.Header.MainMenu.FindSubMenu("Bredband","Bredbandsabonnemang").Click();

            //Asesert bredband page is loaded
            string bredbandurl = driver.Url;
            StringAssert.AreEqualIgnoringCase("https://www.telenor.se/handla/bredband/", bredbandurl);

            //do the search
            BredbandServicePage bredbandpage = new BredbandServicePage(driver);           
            bredbandpage.SearchBox.Click();
            bredbandpage.SearchBox.SendKeys("Storgatan 1, Uppsala\n");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='address-search-field__autocomplete__list']/ul")));
            bredbandpage.SearchBox.SendKeys(Keys.Return);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            bredbandpage.ApartmentList.SelectByIndex(1);

            //verify result
            Assert.Greater(bredbandpage.OfferList.Count(), 0);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }


}

