using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace socNetwork.Controllers
{
    public class FilesController : Controller
    {
        private IUserService _userSvc;
        private IPictureService _pictureSvc;

        public FilesController(IUserService userSvc, IPictureService pictureSvc)
        {
            _userSvc = userSvc;
            _pictureSvc = pictureSvc;
        }


        [HttpGet]
        public FileResult Small(int id)
        {
            string rootPath = HttpContext.Request.MapPath("~/");
            var picture = _pictureSvc.Get(id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(rootPath + picture.urlSmall);
            string fileName = "myfile.ext";
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName); 
        }

        [HttpGet]
        public FileResult Standart(int id)
        {
            string rootPath = HttpContext.Request.MapPath("~/");
            var picture = _pictureSvc.Get(id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(rootPath + picture.urlStandart);
            string fileName = "myfile.ext";
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public FileResult Medium(int id)
        {
            string rootPath = HttpContext.Request.MapPath("~/");
            var picture = _pictureSvc.Get(id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(rootPath + picture.urlMedium);
            string fileName = "myfile.ext";
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
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
