using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_Tracking_App.Models.Entity;

namespace Stock_Tracking_App.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Stock_Tracking_App_Entities DB = new Stock_Tracking_App_Entities();
        public ActionResult Index()
        {
            var Values = DB.TBL_Customer.ToList();
            return View(Values);
        }
        [HttpGet]
        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TBL_Customer newCustomer) 
        {
            DB.TBL_Customer.Add(newCustomer);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = DB.TBL_Customer.Find(id);
            DB.TBL_Customer.Remove(customer);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}