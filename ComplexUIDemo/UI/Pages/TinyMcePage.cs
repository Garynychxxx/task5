using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using m5task.Ext;
using m5task.UI.Controls;
using NUnit.Framework;
using OpenQA.Selenium;

namespace m5task.UI.Pages
{
    class TinyMcePage : BasePage

    {
        public TinyMceTextField Frame => Driver.Find<TinyMceTextField>(By.Id("tinymce"));

        public TinyMcePage(IWebDriver driver) : base(driver)
        {
            
        }
        
        public void SetText(string text)
        {
            SwitchToFrame();
            
            Frame.Value = text;

            Driver.SwitchTo().DefaultContent();

        }
        public string GetText()
        {

            
            SwitchToFrame();
            
            var result = Frame.Value;
            Driver.SwitchTo().DefaultContent();

            return result;
        }

        private TinyMcePage SwitchToFrame()
        {
            this.Driver.SwitchTo().Frame("mce_0_ifr");
            return this;
        }

        public void IsTextTheSame(string text)
        {
            SwitchToFrame();
            var result = Frame.Value;
            Assert.AreEqual(result, text);
        }
    }
}
