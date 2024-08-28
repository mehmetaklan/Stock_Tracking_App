using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Tracking_App.Models.Entity;

namespace Stock_Tracking_App.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Stock_Tracking_App_Entities DB = new Stock_Tracking_App_Entities();
        public ActionResult Index()
        {
            var Values = DB.TBL_Category.ToList(); //Select * Command
            return View(Values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TBL_Category newCategory)
        {
            DB.TBL_Category.Add(newCategory); // Insert Into Command
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {
            var category = DB.TBL_Category.Find(id);
            DB.TBL_Category.Remove(category);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}