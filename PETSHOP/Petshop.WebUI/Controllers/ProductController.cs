using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Petshop.BL.Repositories;
using Petshop.DAL.Entities;
using Petshop.DAL.Migrations;
using Petshop.WebUI.ViewModels;

namespace Petshop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> repoProduct;
        public ProductController(IRepository<Product> _repoProduct)
        {
            repoProduct = _repoProduct;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/detay/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product product=repoProduct.GetAll().Include(x => x.ProductPictures).FirstOrDefault(x => x.ID == id);

            ProductVM productVM = new ProductVM
            {

                Product = product,
                RelatedProducts = repoProduct.GetAll(x => x.BrandID == product.BrandID && x.ID != id).Include(i=>i.ProductPictures).OrderBy(x=>Guid.NewGuid()).Take(2)
            };

            return View(productVM);

           
        }
    }
}
