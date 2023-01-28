using Microsoft.AspNetCore.Mvc;
using Fruits_Shop.Models;
using Fruits_Shop.Repository;

namespace Fruits_Shop.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }
      
        public IActionResult Index()
        {
            List<Product> ProdList = productRepo.GetAll();
            ViewData["CategoryList"] = categoryRepo.GetAll();
            return View(ProdList);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewData["CategoryList"] = categoryRepo.GetAll();
            return View(new Product());
        }
        [HttpPost]//Form 
        [ValidateAntiForgeryToken]
        public IActionResult SaveNEw(Product prod)
        {
            if (ModelState.IsValid)
            {
                if (prod.Name != null)
                {
                    productRepo.Insert(prod);
                    return RedirectToAction("Index");
                }
            }
            ViewData["CategoryList"] = categoryRepo.GetAll();

            return View("New", prod);
        }
        public IActionResult Details(int id)
        {
            return View(productRepo.GetByID(id));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productRepo.GetByID(id);
            ViewData["CategoryList"] = categoryRepo.GetAll();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SaveEdit(int id, Product newProd)
        {
            if (ModelState.IsValid)
            {
                
                productRepo.Update(id, newProd);
                return RedirectToAction("Index");

            }
            ViewData["CategoryList"] = categoryRepo.GetAll();

            return View("Edit", newProd);
        }
        public IActionResult Delete(int Id)
        {
            productRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
