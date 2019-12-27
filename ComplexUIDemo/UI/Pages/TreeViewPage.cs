using m5task.UI.Controls;
using m5task.Ext;
using OpenQA.Selenium;


namespace m5task.UI.Pages
{
    public class TreeViewPage : BasePage
    {
        public TreeViewPage(IWebDriver driver) : base(driver)
        {
        }

        public TreeView TreeView => Driver.Find<TreeView>(By.CssSelector("div.k-treeview"));
    }
}
