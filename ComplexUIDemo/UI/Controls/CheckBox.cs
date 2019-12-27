using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.Ext;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace m5task.UI.Controls
{
    class CheckBox : Control
    {

        public CheckBox(IWebElement element) : base(element)
        {
        }

        private Button Button => WrappedElement.Find<Button>(By.XPath("./button"));

        private IWebElement DefaultLocator => WrappedElement.FindElement(By.XPath(".//input[@type = 'checkbox']"));
        public bool CheckBoxExist
        {
            get
            {
                try
                {
                    return DefaultLocator.Displayed;
                }
                catch (Exception e)
                {
                    return false;
                }
                 
            }
            set
            {
                if (CheckBoxExist != value)
                {
                    Button.Click();
                }
            }
        }

        public void DoesCheckBoxExist()
        {
            Assert.True(DefaultLocator.Displayed);
        }
    }
}
