using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelenorAutoTest.ModelBase
{
    public class ElementBase
    {
        private IWebDriver _driver;
        public ElementBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindElement(string path)
        {
            return _driver.FindElement(By.XPath(path));
        }

        public List<IWebElement> FindElements(string path)
        {
            return _driver.FindElements(By.XPath(path)).ToList();
        }


    }
}
