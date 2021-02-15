using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelLayer;

namespace IBLL
{
	public interface IProduct
	{
		bool SaveProduct(ProductDetailsModel pod);
		List<ProductDetailsModel> searchdetails(string id);
		List<ProductDetailsModel> showDetails();
	}
}
