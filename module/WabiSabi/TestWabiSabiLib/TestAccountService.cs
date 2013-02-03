using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WabiSabiLib;

namespace TestWabiSabiLib
{
	/// <summary>
	/// TestAccountService の概要の説明
	/// </summary>
	[TestClass]
	public class TestAccountService
	{
		public TestAccountService()
		{
			//
			// TODO: コンストラクター ロジックをここに追加します
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///現在のテストの実行についての情報および機能を
		///提供するテスト コンテキストを取得または設定します。
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

		#region 追加のテスト属性
		//
		// テストを作成する際には、次の追加属性を使用できます:
		//
		// クラス内で最初のテストを実行する前に、ClassInitialize を使用してコードを実行してください
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// クラス内のテストをすべて実行したら、ClassCleanup を使用してコードを実行してください
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// 各テストを実行する前に、TestInitialize を使用してコードを実行してください
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// 各テストを実行した後に、TestCleanup を使用してコードを実行してください
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestSettleUpDefault()
		{
			var service = new AccountService(new PriceTable());
			var customer = new Customer();
			customer.TakeDish( new Dish(PriceRank.A) );
			customer.TakeDish( new Dish(PriceRank.B) );
			customer.TakeDish( new Dish(PriceRank.C) );
			customer.TakeDish( new Dish(PriceRank.C) );
			customer.TakeDish( new Dish(PriceRank.D) );
			Assert.AreEqual(1200, service.SettleUp(customer));
		}

		[TestMethod]
		public void TestSettleUpWithTax()
		{
			var service = new AccountService(new PriceTable(), (price, rank) => (int)(price * 1.05) );
			var customer = new Customer();
			customer.TakeDish( new Dish(PriceRank.A) );
			customer.TakeDish( new Dish(PriceRank.B) );
			customer.TakeDish( new Dish(PriceRank.C) );
			customer.TakeDish( new Dish(PriceRank.C) );
			customer.TakeDish( new Dish(PriceRank.D) );
			Assert.AreEqual(1260, service.SettleUp(customer));
		}
	}
}
