using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m5task.Ext;
using m5task.UI.Controls;
using m5task.UI.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace m5task
{
    public class Tests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void BeforeSuite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void AfterSuite()
        {
           // _driver.Quit();
        }


        [Test]
        public void TinyMce_1()
        {

            _driver.Url = "http://the-internet.herokuapp.com/tinymce";
            var TinyMcePage = new TinyMcePage(_driver);

            TinyMcePage.SetText("some text");
            TinyMcePage.IsTextTheSame("some text");

        }


        [Test]
        public void DynamicControlsCheckBox_2_1()
        {

            _driver.Url = "http://the-internet.herokuapp.com/dynamic_controls";
            var DynamicControlsPage = new DynamicControlsPage(_driver);

            DynamicControlsPage.CheckBox.CheckBoxExist = false;
            DynamicControlsPage.CheckBox.CheckBoxExist = true;
            DynamicControlsPage.CheckBox.DoesCheckBoxExist();

            


        }
        [Test]
        public void DynamicControlsTextBox_2_2()
        {

            _driver.Url = "http://the-internet.herokuapp.com/dynamic_controls";
            var DynamicControlsPage = new DynamicControlsPage(_driver);

            DynamicControlsPage.TextBox.TextBoxExist = true;
            DynamicControlsPage.TextBox.SendKey("Hello");
            DynamicControlsPage.TextBox.TextBoxExist = false;
            Assert.IsFalse(DynamicControlsPage.TextBox.TextBoxExist);
        }
        [Test]
        public void Login_3()
        {

            _driver.Url = "http://the-internet.herokuapp.com/login";
            var loginPage = new LoginPage(_driver);

            loginPage.Login.Entrance("tomsmith", "SuperSecretPassword!");
            Assert.IsTrue(loginPage.Status);
            loginPage.Login.Logout();
            loginPage.Login.Entrance("11111", "22222!");
            Assert.IsFalse(loginPage.Status);

        }

        [Test]
        public void Table_4()
        {
            _driver.Url = "http://the-internet.herokuapp.com/tables";
            var table2 = new TablesPage(_driver).Grid1;
            
            var sortedColumn = table2.GetColumnContents("First Name").OrderBy(element => element).ToList();

            var tableRows = string.Join(", ", table2.Rows.Select(row => row.RowContents));
            


            Console.WriteLine("Table without  sorting\n" + sortByMethod);
            
            table2.SortUpByColumnName("First Name");
            Console.WriteLine("--------------------");

            var sortByTable =  table2.Rows.Select(r => string.Join("  ", r.RowContents)).ToList();
            Console.WriteLine("Table after sorting\n" + string.Join(", ", sortByTable));
            


            CollectionAssert.AreEqual(sortByMethod, sortByTable);



        }








        //[Test]
        //public void SliderTest()
        //{

        //    _driver.Url = "https://demos.telerik.com/kendo-ui/switch/index";
        //    new SwitchPage(_driver).SetAll(false);

        //}

        //[Test]
        //public void GridTest()
        //{
        //    _driver.Url = "https://demos.telerik.com/kendo-ui/grid/editing";
        //    var grid = new BatchEditPage(_driver).Grid;
        //    Console.WriteLine(string.Join(", ", grid.GetColumnContents(1)));
        //    Console.WriteLine(string.Join(", ", grid.GetColumnContents("Unit Price")));

        //    Console.WriteLine(string.Join(", ", grid.Rows.First().RowContents));

        //    grid.Rows.First(row => row.CellAtColumn("ProductName").Text == "Chang")
        //        .CellAtColumn("ProductName").As<InlineEditable>().Value = "Mang";
        //}

        //[Test]
        //public void TreeTest()
        //{
        //    _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/odata-binding";
        //    var treeView = new TreeViewPage(_driver).TreeView;
        //    treeView.GetNode(new List<string> {"Dairy Products", "Mascarpone Fabioli", "10335"}).Select();

        //    _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/index";

        //    treeView = new TreeViewPage(_driver).TreeView;
        //    treeView.GetNodeQuickly(new List<string> { "My Web Site", "resources", "pdf", "brochure.pdf" }).Select();

        //}
    }
}
