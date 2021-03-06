﻿using System;
using System.Collections.Generic;
using m5task.Ext;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace m5task.UI.Controls
{
    public class Control
    {
        protected IWebDriver Driver;
        public IWebElement WrappedElement;


        public Control(IWebElement element)
        {
            WrappedElement = element;
            Driver = ((RemoteWebElement)element).WrappedDriver;
        }

        public T Find<T>(By by) where T : Control
        {            
            return WrappedElement.Find<T>(by);
        }
        public List<T> FindAll<T>(By by) where T : Control
        {
            return WrappedElement.FindAll<T>(by);
        }

        public T As<T>() where T : Control
        {
            return (T)Activator.CreateInstance(typeof(T), WrappedElement);
        }

        public T WaitUntil<T>(Func<IWebDriver, T> waitFor, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            timeout = timeout == default(TimeSpan) ? TimeSpan.FromSeconds(10) : timeout;
            return new WebDriverWait(Driver, timeout) {Message = message}.Until(waitFor);
        }

    }
}
