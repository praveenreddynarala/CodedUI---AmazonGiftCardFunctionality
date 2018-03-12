using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace AmazonGiftCardFunctionality
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {

        public BrowserWindow br;

        public CodedUITest1()
        {
        }

        [TestInitialize]
        public void SetUp()
        {
            br = BrowserWindow.Launch("http://www.amazon.com/gift-cards/b/ref=topnav_giftcert?ie=UTF8&node=2238192011");
            br.WaitForControlReady();
        }

        [TestCleanup]
        public void TearDown()
        {
            br.Close();
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {

            HtmlCustom brandAmazon = new HtmlCustom(br);
            brandAmazon.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "LI");
            brandAmazon.SearchProperties.Add(HtmlCustom.PropertyNames.Class, "refinementImage");
            //brandAmazon.DrawHighlight();
            System.Drawing.Point myPoint = new System.Drawing.Point(100, 100);
            Mouse.Move(brandAmazon, myPoint);

            HtmlHyperlink bAmazonLink = new HtmlHyperlink(brandAmazon);
            bAmazonLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, " Amazon  (1,156) ");
            bAmazonLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.TagName, "A");
            bAmazonLink.DrawHighlight();
            Mouse.Click(bAmazonLink);

            HtmlSpan facebookOption = new HtmlSpan(br);
            facebookOption.SearchProperties.Add(HtmlSpan.PropertyNames.TagName, "SPAN");
            facebookOption.SearchProperties.Add(HtmlSpan.PropertyNames.Class, "bestLink");
            facebookOption.SearchProperties.Add(HtmlSpan.PropertyNames.InnerText, "Facebook");
            Mouse.Click(facebookOption);

            HtmlCustom searchSortForm = new HtmlCustom(br);
            searchSortForm.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "FORM");
            searchSortForm.SearchProperties.Add(HtmlCustom.PropertyNames.Class, "sortByForm");
            searchSortForm.DrawHighlight();

            HtmlComboBox sort = new HtmlComboBox(searchSortForm);
            sort.SearchProperties.Add(HtmlComboBox.PropertyNames.Id, "sort");
            sort.SearchProperties.Add(HtmlComboBox.PropertyNames.Name, "sort");
            sort.SearchProperties.Add(HtmlComboBox.PropertyNames.Class, "sortByDropdown");
            sort.SelectedIndex = 4;

            for (int i = 1; i <= 24; i++ )
            {
                HtmlCustom giftTitle = new HtmlCustom(br);
                giftTitle.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "H3");
                giftTitle.SearchProperties.Add(HtmlCustom.PropertyNames.InnerText, "Amazon.com Gift Cards - Facebook Delivery ");
                giftTitle.SearchProperties.Add(HtmlCustom.PropertyNames.TagInstance, "'"+i+"'");
                giftTitle.DrawHighlight();

                HtmlHyperlink giftTitle1 = new HtmlHyperlink(giftTitle);
                giftTitle1.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Amazon.com Gift Cards - Facebook Delivery");
                giftTitle1.SearchProperties.Add(HtmlHyperlink.PropertyNames.TagName, "A");
                giftTitle1.SearchProperties.Add(HtmlHyperlink.PropertyNames.ClassName, "HtmlHyperlink");
                string s = HtmlHyperlink.PropertyNames.FriendlyName;

                if (s == "Amazon.com Gift Cards - Facebook Delivery")
                {
                    Console.WriteLine("Mathced!");
                }
            }

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

    }
}
