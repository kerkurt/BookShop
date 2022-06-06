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

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = m_Db.Categories.Find(id); //Id' nin primary key olduğunu bildiğimiz durumlarda
            //var categoryFromDbFirst = m_Db.Categories.FirstOrDefault(x => x.Id == id); //İlk bulduğu id' yi getirir, birden fazla varsa exception üretmez.
            //var categoryFromDbSingle = m_Db.Categories.SingleOrDefault(x => x.Id == id); //Birden fazla id varsa exception fırlatır.

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category objCategory)
        {
            //if (objCategory.Name == objCategory.DisplayOrder.ToString()) 
            //{
            //    ModelState.AddModelError("CustomError", "The DisplayOrder can't exactly match the Name!");//view içerisinde asp-validation-summary tag helper eklediğimiz için kullanabiliyoruz.
            //    //ModelState.AddModelError("Name", "The DisplayOrder can't exactly match the Name!"); //Yukarıda CustomError vermesiyle birlikte Name field' ının altında da custom summary görünmesini istersek.
            //}
            if (ModelState.IsValid)
            {
                m_Db.Categories.Update(objCategory);
                m_Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = m_Db.Categories.Find(id); //Id' nin primary key olduğunu bildiğimiz durumlarda
            //var categoryFromDbFirst = m_Db.Categories.FirstOrDefault(x => x.Id == id); //İlk bulduğu id' yi getirir, birden fazla varsa exception üretmez.
            //var categoryFromDbSingle = m_Db.Categories.SingleOrDefault(x => x.Id == id); //Birden fazla id varsa exception fırlatır.

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var categoryFromDb = m_Db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            m_Db.Categories.Remove(categoryFromDb);
            m_Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
