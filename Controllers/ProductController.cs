using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Tracking_App.Models.Entity;


namespace Stock_Tracking_App.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        
        Stock_Tracking_App_Entities DB = new Stock_Tracking_App_Entities();
        public ActionResult Index()
        {
            var allProducts = DB.TBL_Product.ToList();
            return View(allProducts);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> Values = (from i in DB.TBL_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()
                                           }
                                           ).ToList();
            ViewBag.Value = Values;
            return View();
        }
        [HttpPost]
        public ActionResult Add(TBL_Product newProduct)
        {   //ADD Product
            var category = DB.TBL_Category
                 .Where(m => m.CategoryId == newProduct.TBL_Category.CategoryId)
                 .FirstOrDefault();
            //List Category with where keyword
            newProduct.TBL_Category = category; 
            DB.TBL_Product.Add(newProduct);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}