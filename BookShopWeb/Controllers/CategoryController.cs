using BookShopWeb.Data;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext m_Db;

        public CategoryController(ApplicationDbContext db)
        {
            m_Db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = m_Db.Categories;
            return View(categoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCategory)
        {
            //if (objCategory.Name == objCategory.DisplayOrder.ToString()) 
            //{
            //    ModelState.AddModelError("CustomError", "The DisplayOrder can't exactly match the Name!");//view içerisinde asp-validation-summary tag helper eklediğimiz için kullanabiliyoruz.
            //    //ModelState.AddModelError("Name", "The DisplayOrder can't exactly match the Name!"); //Yukarıda CustomError vermesiyle birlikte Name field' ının altında da custom summary görünmesini istersek.
            //}
            if (ModelState.IsValid)
            {
                m_Db.Categories.Add(objCategory);
                m_Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }
    }
}
