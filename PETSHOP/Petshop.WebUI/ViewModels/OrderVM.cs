using Petshop.DAL.Entities;
using Petshop.WebUI.Models;

namespace Petshop.WebUI.ViewModels
{
	public class OrderVM
	{
		public List<Cart> Carts { get; set; }
		public Order Order { get; set; }
		public IEnumerable<City> Cities { get; set; }

	}
}
