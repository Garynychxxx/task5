using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    public class TinyMceTextField : Control
    {

        public TinyMceTextField(IWebElement element) : base(element)
        {
        }

        public string Value
        {
            get => WrappedElement.Text;
            set
            {
                WrappedElement.Clear();
                WrappedElement.SendKeys(value);
            }
        }
    }
}
