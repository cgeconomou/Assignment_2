using Assignment_2.Models;
using Assignment_2.MyContext;
using Assignment_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        private ApplicationContext db = new ApplicationContext();
        private TrainerRepository trainerRepository;

        public TrainerController()
        {
            trainerRepository = new TrainerRepository(db);
        }
        public ActionResult Index()
        {
            var trainers = trainerRepository.GetAll();
            return View(trainers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Add(trainer);
                ShowAlert("You have succesfully created an employee");
                return RedirectToAction("Index");
            }


            return View(trainer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trainer = trainerRepository.GetById(id);

            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(trainer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                trainerRepository.Edit(trainer);
                ShowAlert("You have succesfully edited an employee");
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var trainer = trainerRepository.GetById(Id);
            if (trainer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(trainer);
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        [NonAction]
        public void ShowAlert(string message)
        {
            TempData["message"] = message;
        }
    }
}