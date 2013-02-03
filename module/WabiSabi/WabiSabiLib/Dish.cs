using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiSabiLib
{
	/// <summary>
	/// sushi dish
	/// this object has PriceRank
	/// </summary>
	public class Dish
	{
		public Dish(PriceRank priceRank)
		{
			Rank = priceRank;
		}

		public PriceRank Rank { get; private set; }
	}
}
