using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Advertisement.Models;

namespace Advertisement.Controllers
{
    public class AdsController : Controller
    {
        private AdvertisementContext db = new AdvertisementContext();

        // GET: Ads
        public ActionResult Index()
        {
            return View(db.Ads.ToList());
        }

        // GET: Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }
        public ActionResult AddCategoryToAd(int id)
        {
            AddCategoryToAd model = new AddCategoryToAd();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.AdName = db.Ads.Find(id).Name;
            model.AdId = id;
            model.Categories = db.Categories.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddCategoryToAd(AddCategoryToAd model)
        {
            var category = db.Categories.Find(model.CategoryId);
            var ad = db.Ads.Find(model.AdId);
            category.Ads.Add(ad);
            db.SaveChanges();
            return RedirectToAction("Index", "Ads");
        }
        //postari verzii
       /* public ActionResult AddToCategory(int id)
        {
            AddToCategoryModel model = new AddToCategoryModel();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Category = db.Categories.Find(id).CategoryName;
            model.CategoryId = id;
            model.Ads = db.Ads.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddToCategory(AddToCategoryModel model)
        {
            var category = db.Categories.Find(model.CategoryId);
            var ad = db.Ads.Find(model.AdId);
            category.Ads.Add(ad);
            db.SaveChanges();
            return View("Index", db.Ads.ToList());
        }
        */

        // GET: Ads/Create 
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,ImgUrl,Date,Location,Category,Description,Price")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                return RedirectToAction("AddCategoryToAd/" + ad.Id);
            }

            return View(ad);
        }

        // GET: Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,ImgUrl,Date,Location,Category,Description,Price")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // GET: Ads/Delete/5
        public ActionResult Delete(int id)
        {
            Ad ad = db.Ads.Find(id);
            db.Ads.Remove(ad);
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
