using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using m5task.UI.Controls;
using OpenQA.Selenium;
using m5task.Ext;

namespace m5task.UI.Pages
{
    public class DragandDropPage : BasePage
    {
        public DragandDropPage(IWebDriver driver) : base(driver)
        {
        }

        public List<Drag> Drags => Driver.FindAll<Drag>(By.CssSelector(".column")).ToList();

        public void ChangeDrags()
        { 

            (new Actions(Driver)).ClickAndHold(Drags[1].WrappedElement).MoveToElement(Drags[0].WrappedElement).DragAndDrop(Drags[1].WrappedElement, Drags[0].WrappedElement).Build().Perform();

            //var firstCount = Drags[0].Name;
            
            
            //if (firstCount.Equals(Drags[0].Name))
            //{
            //    ChangeDrags();
            //}

        }
        public void SetFirstDrag(string FirstDragName)
        {

            if (!FirstDragName.Equals(Drags[0].Name))
            {
                ChangeDrags();
            }
        }

    }
}
