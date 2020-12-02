using eRef.Models.LegislatorModels;
using eRef.Services.LawServices;
using eRef.Services.LegislatorService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRef.MVC.Controllers
{
    public class LegislatorController : Controller
    {
        // GET: Legislator
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LegislatorService(userID);
            var model = service.ListLegislators();

            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewLegislatorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLegislatorService();

            if (service.CreateNewLegislator(model))
            {
                TempData["Save Result"] = "Legislator has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Legislator could not be added.");

            return View(model);
        }

        //GET: Read
        public ActionResult Details(int id)
        {
            var service = CreateLegislatorService();
            var model = service.LegislatorEntry(id);

            return View(model);
        }

        //GET: Update
        public ActionResult Edit(int id)
        {
            var service = CreateLegislatorService();
            var detail = service.LegislatorEntry(id);
            var model = new LegislatorUpdate
            {
                Name = detail.Name,
                JobRole = detail.JobRole,
                District = detail.District
            };

            return View(model);
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LegislatorUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Legislator does not match");
                return View(model);
            }

            var service = CreateLegislatorService();

            if (service.UpdateLegislator(model))
            {
                TempData["SaveResult"] = "Legislator has been updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Legislator could not be updated");
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int id)
        {
            var service = CreateLegislatorService();
            var model = service.LegislatorEntry(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLegislator(int id)
        {
            var service = CreateLegislatorService();

            if (service.DeleteLegislator(id))
            {
                TempData["Save Result"] = "Legislator deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Legislator could not be deleted");
            return View();
        }


        private LegislatorService CreateLegislatorService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LegislatorService(userID);
            return service;
        }
    }
}