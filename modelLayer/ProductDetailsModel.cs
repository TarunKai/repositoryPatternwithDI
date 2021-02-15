using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelLayer
{
	public class ProductDetailsModel
	{
		public long sNo { get; set; }
		public string ProductName { get; set; }
		public string ProductDetails { get; set; }
		public int Price { get; set; }
		public string ProductType { get; set; }
	}
}
