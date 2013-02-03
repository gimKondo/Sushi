using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiSabiLib
{
	public class AccountService
	{
		/// <summary>
		/// construct without additional price
		/// </summary>
		/// <param name="table"></param>
		public AccountService(PriceTable table)
		{
			Table = table;
			AdditionalPrice = (price, rank) => price;
		}

		/// <summary>
		/// construct with additional price
		/// </summary>
		/// <param name="table"></param>
		/// <param name="additionalPrice">tax, discount or bla bla bla</param>
		public AccountService(PriceTable table, Func<int,PriceRank,int> additionalPrice)
		{
			Table = table;
			AdditionalPrice = additionalPrice;
		}

		private PriceTable Table { get; set; }
		public Func<int,PriceRank,int> AdditionalPrice { get; set; }

		public int SettleUp(Customer customer)
		{
			return customer.EatenDishes.Sum(e => AdditionalPrice(Table.Price(e.Rank), e.Rank) );
		}
	}
}
