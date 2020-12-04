using eRef.Models;
using eRef.Models.VoterModels;
using eRef.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eRef.MVC.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter Index
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VoterService(userID);
            var model = service.ListVoter();

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
        public ActionResult Create(VoterRegister model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVoterService();

            if (service.RegisterVoter(model))
            {
                TempData["Save Result"] = "Voter has been registered";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Voter could not be registered.");

            return View(model);
        }

        //GET: Read
        public ActionResult Details(int id)
        {
            var service = CreateVoterService();
            var model = service.ListVoterByID(id);

            return View(model);
        }

        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateVoterService();
            var detail = service.ListVoterByID(id);
            var model = new VoterUpdate
            {
                Name = detail.Name,
                VoterID = detail.VoterID,
                PartyAff = detail.PartyAff,
                LegislatorID=detail.LegislatorID
            };

            return View(model);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VoterUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ID != id)
            {
                ModelState.AddModelError("", "Voter ID mismatch");
                return View(model);
            }

            var service = CreateVoterService();

            if (service.UpdateVoterRegistrationInfo(model))
            {
                TempData["Save Result"] = "Voter Registration has been updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("","Voter ID could not be updated");
            return View(model);
        }

        //GET: Delete
        public ActionResult Delete(int id)
        {
            var service = CreateVoterService();
            var model = service.ListVoterByID(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVoter(int id)
        {
            var service = CreateVoterService();

            service.DeleteVoter(id);

            TempData["Save Result"] = "Voter deleted";

            return RedirectToAction("Index");
        }


        private VoterService CreateVoterService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VoterService(userID);
            return service;
        }
    }
}