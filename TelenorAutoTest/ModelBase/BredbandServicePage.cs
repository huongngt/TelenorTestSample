using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TelenorAutoTest.ModelBase
{
    public class BredbandServicePage : PageBase
    { 
        public IWebElement SearchBox 
        {
            get
            {
                return FindElement("//input[@type='search' and @name='Address']");
            }
        }

        public SelectElement ApartmentList
        {
            get
            {
                return new SelectElement(FindElement("//select[@id='vue-dropdown-40']"));
            }
        }

        public List<IWebElement> OfferList
        {
            get
            {
                return FindElements("//h1[@data-test='offer-preformatted-title']");
            }
        }



        public BredbandServicePage(IWebDriver driver) : base(driver)
        {
        }


    }
}
