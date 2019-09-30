using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelenorAutoTest.ModelBase
{
    public class PageBase
    {
        public Header Header;
        public IWebDriver m_driver;    

        
        public IWebElement CookieButton
        {
            get
            {
                try
                {
                    return FindElement("//button[@data-test = 'accept-cookies-button']");
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            }
        }

        public PageBase(IWebDriver driver)
        {
            m_driver = driver;
            Header = new Header(m_driver);            
        }

        public IWebElement FindElement(string path)
        {
            return m_driver.FindElement(By.XPath(path));
        }

        public List<IWebElement> FindElements(string path)
        {
            return m_driver.FindElements(By.XPath(path)).ToList();
        }

        public void GoTo(string url)
        {
            m_driver.Url = url;
            m_driver.Manage().Window.Maximize();
        }

    }
}
