using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.Ext;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    class TextBox : Control
    {
        public TextBox(IWebElement element) : base(element)
        {
        }
        private Button Button => WrappedElement.Find<Button>(By.XPath("./button"));
        private IWebElement DefaultLocator => WrappedElement.FindElement(By.XPath(".//input[@type = 'text']"));
        private IWebElement DefaultLocatorToCheckStatus => WrappedElement.FindElement(By.XPath(".//input[@disabled]"));
        public bool TextBoxExist
        {
            get
            {
                try
                {
                    return !DefaultLocatorToCheckStatus.Displayed;
                }
                catch (Exception e)
                {
                    return true;
                }

            }
            set
            {
                if (TextBoxExist != value)
                {
                    Button.Click();
                }
            }

            
        }

        public void SendKey(string text)
        {
            DefaultLocator.SendKeys(text);
        }

       
    }
}
