using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dairy_departure
{
	class DiscountManager
	{
		private static readonly Random getrandom = new Random();

		public decimal Calculate(decimal price, DateTime expired)
		{
			return Round(Convert.ToDecimal(getrandom.Next(3, 7) + getrandom.NextDouble()));
		}

		public decimal CalculatePrice(decimal price, decimal discount)
		{
			return Round(price - price * discount / 100);
		}

		public decimal Round(decimal price)
		{
			return System.Math.Round(price, 2);
		}

		public string Format(decimal price)
		{
			return price.ToString("0.00");
		}

	}
}