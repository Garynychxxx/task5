using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.Ext;
using OpenQA.Selenium;
using m5task.UI.Controls.Table;

namespace m5task.UI.Pages
{
    class TablesPage : BasePage
    {
        public TablesPage(IWebDriver driver) : base(driver)
        {
        }

        public Grid Grid1 => Driver.Find<Grid>(By.XPath("//table[@id='table2']"));
    }
}
