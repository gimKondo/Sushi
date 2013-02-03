using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WabiSabiLib
{
	public class Customer
	{
		public Customer()
		{
			EatenDishes = new List<Dish>();
		}

		//-------------------------
		// property
		//-------------------------
		public List<Dish> EatenDishes { get; private set; }

		//-------------------------
		// method
		//-------------------------
		public void TakeDish(Dish dish)
		{
			EatenDishes.Add(dish);
		}
	}
}
