using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_lab5.Models;

namespace IT_lab5.Controllers
{
    public class FriendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize(Roles = "Administrator,Manager,User")]
        [Authorize(Roles = "Professor,Student")]
        // GET: Friends
        public ActionResult Index()
        {
            return View(db.Friends.ToList());
        }

        //[Authorize(Roles = "Administrator,Manager,User")]
        [Authorize(Roles = "Professor,Student")]
        // GET: Friends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //[Authorize(Roles = "Administrator,Manager,User")]
        [Authorize(Roles = "Professor")]
        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

    
        [Authorize(Roles = "Professor")]
        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subject,Grade")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        //[Authorize(Roles = "Administrator,Manager")]
        [Authorize(Roles = "Professor")]
        // GET: Friends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //[Authorize(Roles = "Administrator,Manager")]
        [Authorize(Roles = "Professor")]
        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Grade")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                //Debug.WriteLine("PRED " + friend.Id);
                db.Entry(friend).State = EntityState.Modified;
                //Debug.WriteLine("PO " + friend.Id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        //[Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Professor")]
        // GET: Friends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //[Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Professor")]
        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
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
    }
}
