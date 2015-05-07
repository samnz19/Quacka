using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Quacka.Models;

namespace Quacka.Controllers
{
    public class QuacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quacks
        public ActionResult Index()
        {
            List <Quack> quacks = db.Quacks.OrderByDescending(q => q.CreatedAt).ToList();
            return View(new FeedViewModel
            {
                New = new Quack(),
                Quacks = quacks
            });
        }

        // POST: Quacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FeedViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string currentUser = User.Identity.GetUserId();
                viewModel.New.Owner = db.Users.Single(u => u.Id == currentUser);
                viewModel.New.CreatedAt = DateTime.Now;
                db.Quacks.Add(viewModel.New);
                db.SaveChanges();
            }
            return RedirectToRoute("Quacks");
        }

        // GET: Quacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // GET: Quacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,CreatedAt,Owner")] Quack quack)
        {
            if (ModelState.IsValid)
            {
                db.Quacks.Add(quack);
                db.SaveChanges();
                return RedirectToRoute("Quacks");
            }

            return View(quack);
        }

        // GET: Quacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // POST: Quacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,CreatedAt")] Quack quack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToRoute("Quacks");
            }
            return View(quack);
        }

        // GET: Quacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // POST: Quacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quack quack = db.Quacks.Find(id);
            db.Quacks.Remove(quack);
            db.SaveChanges();
            return RedirectToRoute("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
