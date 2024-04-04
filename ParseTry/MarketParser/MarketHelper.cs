using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTry.MarketParser
{
	public static class MarketHelper
	{
		public static decimal OrderChanger(decimal skinOrder, decimal skinInfoOrder)
		{
			if (skinOrder > skinInfoOrder && skinOrder / 2 >= skinInfoOrder)
			{
				return skinOrder;
			}
			if (skinOrder > skinInfoOrder)
			{
				return skinInfoOrder;
			}
			return skinOrder;
		}
	}
}
