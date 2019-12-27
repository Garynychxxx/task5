using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.UI.Controls;
using OpenQA.Selenium;
using m5task.Ext;

namespace m5task.UI.Controls.Table
{
    public class Grid : Control
    {
        public Grid(IWebElement element) : base(element)
        {
        }

        private Dictionary<string, IWebElement> _columnNames;
        


        public List<GridRow> Rows => WrappedElement.FindAll<GridRow>(By.XPath(".//tbody/tr")).Select(
            el =>
            {
                el.Parent = this;
                return el;
            }).ToList();

        
        protected Dictionary<string, IWebElement> ColumnNames
        {
            get
            {
                return _columnNames ?? (_columnNames = WrappedElement.FindElements(By.XPath(".//tr/th"))
                           .ToDictionary(t => t.Text.Replace("Filter", String.Empty).Trim(), t => t));

            }
        }
        

        public List<string> GetColumnContents(string columnName)
        {
            return GetColumnContents(GetColumnNumberByName(columnName));
        }

        public List<string> GetColumnContents(int columnNumber)
        {
            return WrappedElement.FindElements(By.XPath($".//tr/td[{columnNumber + 1}]")).Select(el => el.Text.Trim()).ToList();

        }



        public int GetColumnNumberByName(string columnName)
        {
            int index = ColumnNames.Keys.ToList().IndexOf(columnName);

            if (index == -1)
            {
                throw new Exception($"Column with name '{columnName}' is not found");
            }

            return index;
        }

        public void SortUpByColumnName(string columnName)
        {
            var column = ColumnNames[columnName];


            if (!column.GetAttribute("class").Contains("SortUp"))
            {
                column.Click();
            }
            else
            {
                SortUpByColumnName(columnName);
            }
            

        }
        public void SortDownByColumnName(string columnName)
        {
            var column = _columnNames[columnName];

            if (!column.GetAttribute("class").Contains("SortDown"))
            {
                column.Click();
            }
            else
            {
                SortDownByColumnName(columnName);
            }

        }
    }
}
