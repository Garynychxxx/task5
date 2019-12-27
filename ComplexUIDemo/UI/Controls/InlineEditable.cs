using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.UI.Controls;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    public class InlineEditable : Control
    {
        public InlineEditable(IWebElement element) : base(element)
        {
        }

        public string Value
        {
            get
            {
                return WrappedElement.Text.Trim();
            }

            set
            {
                WrappedElement.Click();
                var input = WrappedElement.FindElement(By.CssSelector("input"));
                input.Clear();
                input.SendKeys(value + Keys.Return);
            }
        }
    }
}
