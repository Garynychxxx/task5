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
    public class BatchEditPage : BasePage
    {
        public BatchEditPage(IWebDriver driver) : base(driver)
        {
        }

        public Grid Grid => Driver.Find<Grid>(By.CssSelector("#grid"));
        // public IWebElement SomeButton => Driver.FindElement(By.CssSelector())
    }
}
