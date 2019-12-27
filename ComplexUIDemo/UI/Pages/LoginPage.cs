using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.Ext;
using m5task.UI.Controls;
using OpenQA.Selenium;

namespace m5task.UI.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement statusField => Driver.FindElement(By.XPath("//div[@class = 'flash success']"));
        public Login Login => Driver.Find<Login>(By.XPath("//div[@class = 'example']"));

        public bool Status
        {
            get
            {
                try
                {
                    return statusField.Displayed;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            
        }

    }
}
