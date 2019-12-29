using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m5task.UI.Controls
{
    public class Drag : Control
    {
        public Drag(IWebElement element) : base(element)
        {
        }


    public string Name
        {
            get => Name;
            set
            {
                Name = WrappedElement.Text;
            }
        }
    }
}
