using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessLogic;
using IBLL;
using modelLayer;

namespace repositoryPattern.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        IProduct iproductdetails = new ProductManager();
		public ProductController()
		{

		}
        public ProductController(IProduct _iproductdetails)
        {
            iproductdetails = _iproductdetails;
        }

		[Route("addProduct")]
		[HttpPost]
		public HttpResponseMessage saveProductDetails(ProductDetailsModel pod)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			bool res = false;

			res = iproductdetails.SaveProduct(pod);

			if (res == true)
			{
				var showmessage = "Product Saved Successfully.";
				dict.Add("Message", showmessage);
				return Request.CreateResponse(HttpStatusCode.OK, dict);
			}
			else
			{
				var showmessage = "Product Not Saved Please try again.";

				dict.Add("Message", showmessage);
				return Request.CreateResponse(HttpStatusCode.BadRequest, dict);

			}
		}
		[Route("showList")]
		[HttpGet]
		public HttpResponseMessage showList()
		{

			List<ProductDetailsModel> li = new List<ProductDetailsModel>();
			Dictionary<string, string> dict = new Dictionary<string, string>();
			var details = iproductdetails.showDetails();
			foreach (var x in details)
			{
				ProductDetailsModel pcm = new ProductDetailsModel();
				pcm.sNo = x.sNo;
				pcm.ProductName = x.ProductName;
				pcm.ProductDetails = x.ProductDetails;
				pcm.ProductType=x.ProductType;
				pcm.Price = x.Price;
				li.Add(pcm);

			}
			return Request.CreateResponse(HttpStatusCode.OK, li);
		}
		[Route("searchProduct")]
		[HttpPost]
		public HttpResponseMessage searchProduct(ProductDetailsModel pod)
		{

			List<ProductDetailsModel> li = new List<ProductDetailsModel>();
			Dictionary<string, string> dict = new Dictionary<string, string>();
			var details = iproductdetails.searchdetails(pod.ProductType);
			foreach (var x in details)
			{
				ProductDetailsModel pcm = new ProductDetailsModel();
				pcm.sNo = x.sNo;
				pcm.ProductName = x.ProductName;
				pcm.Price = x.Price;
				li.Add(pcm);

			}
			return Request.CreateResponse(HttpStatusCode.OK, li);

		}
	}
}
