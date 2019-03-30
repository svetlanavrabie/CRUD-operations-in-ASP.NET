using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;

using System.Data;

namespace MVCCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Index
        public ActionResult Index() 
        {
            using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
            {
                return View(dbModel.Customers.ToList());
            }

            
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
            {
                return View(dbModel.Customers.Where(x=>x.Id==id).FirstOrDefault());
            }

            
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {

                using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
                {
                    dbModel.Customers.Add(customer);
                    dbModel.SaveChanges();
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
            {
                return View(dbModel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
                {
                    dbModel.Entry(customer).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }




                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
            {
                return View(dbModel.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                using (MVCCrudOperationsEntities dbModel = new MVCCrudOperationsEntities())
                {
                    Customer customer = dbModel.Customers.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Customers.Remove(customer);
                    dbModel.SaveChanges();
                }

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
