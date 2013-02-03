using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiSabiLib
{
	public class PriceTable
	{
		public PriceTable()
		{
			Table = new Dictionary<PriceRank,int>();
			Table.Add(PriceRank.A, 400);
			Table.Add(PriceRank.B, 300);
			Table.Add(PriceRank.C, 200);
			Table.Add(PriceRank.D, 100);
		}

		public int Price(PriceRank priceRank)
		{
			return Table[priceRank];
		}

		private Dictionary<PriceRank, int> Table { get; set ; }
	}
}
