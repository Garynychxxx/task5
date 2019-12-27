using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.UI.Controls;
using OpenQA.Selenium;

namespace m5task.UI.Controls
{
    public class GridCell : Control
    {
        public GridCell(IWebElement element) : base(element)
        {
        }


        public string Text => WrappedElement.Text;
    }
}
