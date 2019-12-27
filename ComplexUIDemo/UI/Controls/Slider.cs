using m5task.UI.Controls;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    public class Slider : Control
    {
        public Slider(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.CssSelector("span.k-switch");

        public bool State
        {
            get => WrappedElement.GetAttribute("class").Contains("k-switch-on");
            set
            {
                if (State != value)
                {
                    WrappedElement.Click();

                }
            }
        }


    }
}
