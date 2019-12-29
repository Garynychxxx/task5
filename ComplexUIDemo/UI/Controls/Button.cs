using System;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    class Button: Control
    {
        private IWebElement LoadingLocator => Driver.FindElement(By.XPath("//button[@disabled]"));
        public Button(IWebElement element) : base(element)
        {
        }

        public void Click()
        {
            try
            {
                var Loading = LoadingLocator;
                WaitUntil(driver => Loading.Displayed);
                WrappedElement.Click();

            }
            catch (Exception e)
            {
                var x = WrappedElement.Text;
                WrappedElement.Click();
                WaitUntil(driver => !WrappedElement.Text.Equals(x));

            }
        }
    }
}
