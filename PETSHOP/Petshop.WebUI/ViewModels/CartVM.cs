using Petshop.DAL.Entities;
using Petshop.WebUI.Models;

namespace Petshop.WebUI.ViewModels
{
	public class CartVM
	{
        public List<Cart>Carts { get; set; }
		public IEnumerable<Product> Products { get; set; }
    }
}
