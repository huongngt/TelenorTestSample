using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelenorAutoTest.ModelBase
{
    public class Header
    {
        IWebDriver _driver;
        public MainNavigationMenu MainMenu;

        public Header(IWebDriver driver)
        {
            _driver = driver;
            MainMenu = new MainNavigationMenu(_driver);
        }
        
    }
}
