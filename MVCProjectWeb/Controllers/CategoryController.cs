using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProjectWeb.Controllers.Data;
using MVCProjectWeb.Models;

namespace MVCProjectWeb.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //List in db
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create Category with validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer", "The Display cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        //Post Edit Category with validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer", "The Display cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        //Post Delete Category with validation
        [HttpPost,ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj = _db.Categories.Find(id);
            if (obj == null)
                return NotFound();

                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
