using Petshop.DAL.Entities;

namespace Petshop.WebUI.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Slide> Slides{ get; set; }
        public IEnumerable<Product> LatestProducts { get; set; }
		public IEnumerable<Product> BestSalesProducts { get; set; }


	}
}
