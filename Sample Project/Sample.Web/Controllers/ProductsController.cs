using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Domain.Interfaces.Services;

namespace Sample.Web.Controllers
{
    public class ProductsController : Controller
    {
	    private readonly IProductService _service;

	    public ProductsController(IProductService  service)
	    {
		    if (service == null)
		    {
			    throw new ArgumentNullException("service");
		    }
		    _service = service;
	    }

	    //
        // GET: /Products/

        public ActionResult Index()
        {
			return View(_service.GetProdutcs());
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

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

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5

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

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Products/Delete/5

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
