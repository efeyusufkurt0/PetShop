using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petshop.BL.Repositories;
using Petshop.DAL.Entities;
using Petshop.WebUI.ViewModels;

namespace Petshop.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        IRepository<Slide> repoSlide;
		IRepository<Product> repoProduct;
		public HomeController(IRepository<Slide> _repoSlide, IRepository<Product> _repoProduct)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
            
        }
        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM
            {
                Slides = repoSlide.GetAll().OrderBy(o => o.DisplayIndex),

				LatestProducts=repoProduct.GetAll().Include(x=>x.ProductPictures).OrderByDescending(o=>o.ID).Take(4),
				
                BestSalesProducts=repoProduct.GetAll().Include(x=>x.ProductPictures).OrderBy(o=>Guid.NewGuid()).Take(2),


			};
            return View(indexVM);
        }
    }
}
