using System;
using System.Linq;
using m5task.UI.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace m5task

{
    [TestFixture]
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
            var numberOfColumn = table2.GetColumnNumberByName("First Name");
            var sortByMethod = table2.Rows.OrderBy(el => el.RowContents[numberOfColumn]).Select(r => string.Join("  ", r.RowContents)).ToList();

            Console.WriteLine("Table after sorting\n" + string.Join(", ", sortByMethod));

            table2.SortUpByColumnName("First Name");
            Console.WriteLine("--------------------");

            var sortByTable =  table2.Rows.Select(r => string.Join("  ", r.RowContents)).ToList();
            Console.WriteLine("Table after sorting\n" + string.Join(", ", sortByTable));

            CollectionAssert.AreEqual(sortByMethod, sortByTable);

        }
        [Test]
        public void DragAndDrob_5()
        {
            _driver.Url = "http://the-internet.herokuapp.com/drag_and_drop";

            new DragandDropPage(_driver).ChangeDrags(); 
            

        }









    }
}
