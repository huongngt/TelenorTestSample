using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelenorAutoTest.ModelBase
{
    public class MainNavigationMenu : ElementBase
    {
        public IWebDriver _driver;
        public IWebElement ProductMenu
        {
            get
            {
                return FindElement("//a[@class='page-header__main-nav-link' and @data-test='Handla']");
            }
        }

        public IWebElement CustomerMenu
        {
            get
            {
                return FindElement("//a[@class='page-header__main-nav-link' and @data-test='Kundservice']");
            }
        }
        public IWebElement TelenorMenu
        {
            get
            {
                return FindElement("//a[@class='page-header__main-nav-link' and @data-test='Varför Telenor']");
            }
        }

        public string XPathSubmenu = "//a[@data-test = '{0}']//parent::div//a[@data-test='{1}']";


        public IWebElement FindSubMenu(string submenu, string menuitem)
        {            
            return FindElement(string.Format(XPathSubmenu, submenu, menuitem));
        }

        public MainNavigationMenu(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}
