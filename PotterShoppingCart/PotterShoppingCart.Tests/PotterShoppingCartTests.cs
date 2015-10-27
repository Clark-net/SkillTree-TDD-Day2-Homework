using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// PotterShoppingCartTests 的摘要描述
    /// </summary>
    [TestClass]
    public class PotterShoppingCartTests
    {
        public PotterShoppingCartTests()
        {
            //
            // TODO:  在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///的相關資訊與功能的測試內容。
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

        #region 其他測試屬性
        //
        // 您可以使用下列其他屬性撰寫您的測試: 
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestShoppingCart_第一集買一本_其他都沒買_價格應為100元()
        {
            //Scenario: 第一集買了一本，其他都沒買，價格應為100*1=100元
            //    Given 第一集買了 1 本
            //    And 第二集買了 0 本
            //    And 第三集買了 0 本
            //    And 第四集買了 0 本
            //    And 第五集買了 0 本
            //    When 結帳
            //    Then 價格應為 100 元

            //arrange
            var target = new ShoppingCart();
            target.AddBooks(new Book { Name = "哈利波特第一集" });

            var expected = 100;

            //act
            target.Checkout();

            //assert
            Assert.AreEqual(expected, target.TotalAmount);
        }

        [TestMethod]
        public void TestShoppingCart_第一集買一本_第二集也買一本_價格應為190元()
        {
            //Scenario: 第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
            //    Given 第一集買了 1 本
            //    And 第二集買了 1 本
            //    And 第三集買了 0 本
            //    And 第四集買了 0 本
            //    And 第五集買了 0 本
            //    When 結帳
            //    Then 價格應為 190 元

            //arrange
            var target = new ShoppingCart();
            target.AddBooks(new Book { Name = "哈利波特第一集" });
            target.AddBooks(new Book { Name = "哈利波特第二集" });

            var expected = 190;

            //act
            target.Checkout();

            //assert
            Assert.AreEqual(expected, target.TotalAmount);
        }
    }
}
