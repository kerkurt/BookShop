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
            m_Db.Categories.Add(objCategory);
            m_Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
