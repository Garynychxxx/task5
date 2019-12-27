using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.UI.Controls;
using OpenQA.Selenium;
using m5task.Ext;

namespace m5task.UI.Controls.Table
{
    public class GridRow  : Control
    {
        public GridRow(IWebElement element) : base(element)
        {
        }

        private List<GridCell> _cells;
        protected internal Grid Parent;
        
        public List<string> RowContents
        {
            get
            {
                 return Cells.Select(el => el.Text).ToList();
            }
        }

        public List<GridCell> Cells => _cells ?? (_cells = WrappedElement.FindAll<GridCell>(By.CssSelector("td")).ToList());

        public GridCell CellAtColumn(string columnName)
        {
            return Cells.ElementAt(Parent.GetColumnNumberByName(columnName));
        }

        
    }
}
