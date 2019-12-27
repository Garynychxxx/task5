using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    public class Login : Control
    {
        public Login(IWebElement element) : base(element)
        {
        }

        private IWebElement LogoutButton => Driver.FindElement(By.XPath("//div[@class = 'example']/a"));
        private IWebElement UsernameField => WrappedElement.FindElement(By.XPath(".//input[@name = 'username']"));
        private IWebElement PasswordField => WrappedElement.FindElement(By.XPath(".//input[@name = 'password']"));
        private IWebElement EnterButton => WrappedElement.FindElement(By.XPath(".//button"));


        public void Entrance(string login, string password)
        {
            UsernameField.SendKeys(login);
            PasswordField.SendKeys(password);
            EnterButton.Click();
        }

        public void Logout()
        {
            LogoutButton.Click();
        }

    }
}
