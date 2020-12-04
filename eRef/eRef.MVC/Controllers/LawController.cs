using eRef.Models.LawModels;
using eRef.Services.LawServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRef.MVC.Controllers
{
    public class LawController : Controller
    {
        // GET: Law
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LawService(userID);
            var model = service.ListLaw();

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
        public ActionResult Create(LawAuthor model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLawService();

            if (service.AuthorLaw(model))
            {
                TempData["Save Result"] = "Law has been added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Law could not be added.");

            return View(model);
        }

        //GET: Read
        public ActionResult Details(int id)
        {
            var service = CreateLawService();
            var model = service.IndLaw(id);

            return View(model);
        }

        //GET: Update
        public ActionResult Edit(int id)
        {
            var service = CreateLawService();
            var detail = service.IndLaw(id);
            var model = new LawUpdate
            {
                Name = detail.Name,
                MajDescrip = detail.MajDescrip,
                MinDescrip = detail.MinDescrip,
                AddDescrip = detail.AddDescrip,
                Author = detail.Author,
                VoteScheduled = detail.VoteScheduled
            };

            return View(model);
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LawUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ID != id)
            {
                ModelState.AddModelError("", "Law does not match");
                return View(model);
            }

            var service = CreateLawService();

            if (service.UpdateLaw(model))
            {
                TempData["SaveResult"] = "Law has been updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("","Law could not be updated");
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int id)
        {
            var service = CreateLawService();
            var model = service.IndLaw(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLaw(int id)
        {
            var service = CreateLawService();

            if (service.DeleteLaw(id))
            {
                TempData["Save Result"] = "Law deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Law could not be deleted");
            return View();
        }

        //GET: VoteFor
        public ActionResult VoteFor(int id)
        {
            var service = CreateLawService();
            var model = service.IndLaw(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("VoteFor")]
        [ValidateAntiForgeryToken]
        public ActionResult VoteForLaw(int id)
        {
            var service = CreateLawService();

            if (service.VoteFor(id))
            {
                TempData["Save Result"] = "You voted for";
                return RedirectToAction("Index");
            }
            
            ModelState.AddModelError("", "Law could not be voted on");
            return View();
        }

        //GET: Delete
        public ActionResult VoteAgainst(int id)
        {
            var service = CreateLawService();
            var model = service.IndLaw(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("VoteAgainst")]
        [ValidateAntiForgeryToken]
        public ActionResult VoteAgainstLaw(int id)
        {
            var service = CreateLawService();

            if (service.VoteAgainst(id))
            {
                TempData["Save Result"] = "You voted against";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Law could not be voted on");
            return View();
        }

        private LawService CreateLawService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LawService(userID);
            return service;
        }
    }
}