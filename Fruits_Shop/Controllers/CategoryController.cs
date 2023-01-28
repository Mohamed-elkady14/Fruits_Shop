using Microsoft.AspNetCore.Mvc;
using Fruits_Shop.Models;
using Fruits_Shop.Repository;

namespace Fruits_Shop.Controllers
{
    public class CategoryController : Controller
    {
        
        ICategoryRepository categoryRepo;
        public CategoryController( ICategoryRepository categoryRepo)
        {
            
            this.categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            List<Category> categList = categoryRepo.GetAll();
            return View(categList);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View(new Category());
        }
        [HttpPost]//Form 
        [ValidateAntiForgeryToken]
        public IActionResult SaveNEw(Category categ)
        {
            if (ModelState.IsValid)
            {
                if (categ.Categ_Name != null)
                {
                    categoryRepo.Insert(categ);
                    return RedirectToAction("Index");
                }
            }

            return View("New", categ);
        }
        public IActionResult Details(int id)
        {
            return View(categoryRepo.GetByID(id));
        }
        public IActionResult Edit(int id)
        {
            Category category = categoryRepo.GetByID(id);

            return View(category);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Category newcateg)
        {
            if (ModelState.IsValid)
            {

                categoryRepo.Update(id, newcateg);
                return RedirectToAction("Index");

            }
            

            return View("Edit", newcateg);
        }
        public IActionResult Delete(int Id)
        {
            categoryRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
