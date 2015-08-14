using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace socNetwork.Controllers
{
    public class socNetworkController : Controller
    {

        socNetworkContext db = new socNetworkContext();

        public ActionResult Index1()
        {
            return View(db.users.ToList());
        }
        // GET: socNetwork
        public ActionResult Index()
        {
            return View();
        }

        // GET: socNetwork/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: socNetwork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: socNetwork/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: socNetwork/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: socNetwork/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: socNetwork/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: socNetwork/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
