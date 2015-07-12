using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using egr.am.Models;

namespace egr.am.Controllers
{
    public class ProductOfferingMarketingPagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductOfferingMarketingPages
        public async Task<ActionResult> Index()
        {
            var productOfferingMarketingPages = db.ProductOfferingMarketingPages.Include(p => p.ProductOfferingMarketing);
            return View(await productOfferingMarketingPages.ToListAsync());
        }

        // GET: ProductOfferingMarketingPages/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOfferingMarketingPage productOfferingMarketingPage = await db.ProductOfferingMarketingPages.FindAsync(id);
            if (productOfferingMarketingPage == null)
            {
                return HttpNotFound();
            }
            return View(productOfferingMarketingPage);
        }

        // GET: ProductOfferingMarketingPages/Create
        public ActionResult Create()
        {
            ViewBag.ProductOfferingMarketingId = new SelectList(db.ProductOfferingMarketings, "Id", "Status");
            return View();
        }

        // POST: ProductOfferingMarketingPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductOfferingMarketingId,Page")] ProductOfferingMarketingPage productOfferingMarketingPage)
        {
            if (ModelState.IsValid)
            {
                productOfferingMarketingPage.Id = Guid.NewGuid();
                db.ProductOfferingMarketingPages.Add(productOfferingMarketingPage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductOfferingMarketingId = new SelectList(db.ProductOfferingMarketings, "Id", "Status", productOfferingMarketingPage.ProductOfferingMarketingId);
            return View(productOfferingMarketingPage);
        }

        // GET: ProductOfferingMarketingPages/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOfferingMarketingPage productOfferingMarketingPage = await db.ProductOfferingMarketingPages.FindAsync(id);
            if (productOfferingMarketingPage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductOfferingMarketingId = new SelectList(db.ProductOfferingMarketings, "Id", "Status", productOfferingMarketingPage.ProductOfferingMarketingId);
            return View(productOfferingMarketingPage);
        }

        // POST: ProductOfferingMarketingPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductOfferingMarketingId,Page")] ProductOfferingMarketingPage productOfferingMarketingPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOfferingMarketingPage).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductOfferingMarketingId = new SelectList(db.ProductOfferingMarketings, "Id", "Status", productOfferingMarketingPage.ProductOfferingMarketingId);
            return View(productOfferingMarketingPage);
        }

        // GET: ProductOfferingMarketingPages/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOfferingMarketingPage productOfferingMarketingPage = await db.ProductOfferingMarketingPages.FindAsync(id);
            if (productOfferingMarketingPage == null)
            {
                return HttpNotFound();
            }
            return View(productOfferingMarketingPage);
        }

        // POST: ProductOfferingMarketingPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductOfferingMarketingPage productOfferingMarketingPage = await db.ProductOfferingMarketingPages.FindAsync(id);
            db.ProductOfferingMarketingPages.Remove(productOfferingMarketingPage);
            await db.SaveChangesAsync();
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
