using Petshop.DAL.Entities;

namespace Petshop.WebUI.ViewModels
{
	public class ProductVM
	{
        public Product Product { get; set; }
		public IEnumerable<Product> RelatedProducts { get; set;}
    }
}
