using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using modelLayer;
using DataLayer;

namespace BusinessLogic
{
	public class ProductManager:IProduct
	{
		testEntities1 _dbContext = new testEntities1();

		public ProductManager()
		{

		}
		public bool SaveProduct(ProductDetailsModel pod)
		{
			productDetail pd = new productDetail();
			pd.ProductName = pod.ProductName;
			pd.ProductDetails = pod.ProductDetails;
			pd.ProductType = pod.ProductType;
			_dbContext.productDetails.Add(pd);
			if (_dbContext.SaveChanges() == 1)
			{
				return true;

			}
			else
			{
				return false;

			}
		}

		public List<ProductDetailsModel> searchdetails(string type)
		{
			List<ProductDetailsModel> li = new List<ProductDetailsModel>();
			var details = _dbContext.productDetails.Where(x => x.ProductType == type);
			if (details != null)
			{
				Parallel.ForEach(details, x =>
				{
					ProductDetailsModel obj = new ProductDetailsModel();
					obj.sNo = x.sNo;
					obj.ProductName = x.ProductName;
					obj.Price = Convert.ToInt32(x.Price);
					li.Add(obj);
				});
				return li;
			}
			else
			{
				return li;
			}

		}

		public List<ProductDetailsModel> showDetails()
		{
			List<ProductDetailsModel> li = new List<ProductDetailsModel>();
			var details = _dbContext.productDetails;
			if (details != null)
			{
				Parallel.ForEach(details, x =>
				{
					ProductDetailsModel obj = new ProductDetailsModel();
					obj.sNo = x.sNo;
					obj.ProductName = x.ProductName;
					obj.ProductDetails = x.ProductDetails;
					obj.ProductType = x.ProductType;
					obj.Price = Convert.ToInt32(x.Price);
					li.Add(obj);

				});
				return li;
			}
			else
			{
				return li;
			}
		}
		public bool DeleteDetails(int id)
		{
			var Info = _dbContext.productDetails.Where(m => m.sNo == id).FirstOrDefault();
			_dbContext.productDetails.Remove(Info);
			if (_dbContext.SaveChanges() == 0)
				return true;
			return false;
		}
	}
}
