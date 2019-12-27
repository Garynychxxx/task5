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
    class DynamicControlsPage : BasePage
    {
        public DynamicControlsPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckBox CheckBox => Driver.Find<CheckBox>(By.CssSelector("#checkbox-example"));
        public TextBox TextBox => Driver.Find<TextBox>(By.CssSelector("#input-example"));


    }
}
