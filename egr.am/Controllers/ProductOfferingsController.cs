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
using egr.am.Constants;
using egr.am.Services;

namespace egr.am.Controllers
{
    
    public class ProductOfferingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductOfferings
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductOfferings.ToListAsync());
        }

        // GET: ProductOfferings/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffering productOffering = await db.ProductOfferings.FindAsync(id);
            if (productOffering == null)
            {
                return HttpNotFound();
            }
            return View(productOffering);
        }

        // GET: ProductOfferings/Create
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOfferings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
      
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductName,DateAdded,DateLastModified,Status")] ProductOffering productOffering)
        {
            if (ModelState.IsValid)
            {
                productOffering.Id = Guid.NewGuid();
                db.ProductOfferings.Add(productOffering);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productOffering);
        }

        // GET: ProductOfferings/Edit/5
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffering productOffering = await db.ProductOfferings.FindAsync(id);
            if (productOffering == null)
            {
                return HttpNotFound();
            }
            return View(productOffering);
        }

        // POST: ProductOfferings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductName,DateAdded,DateLastModified,Status")] ProductOffering productOffering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productOffering).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productOffering);
        }

        // GET: ProductOfferings/Delete/5
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOffering productOffering = await db.ProductOfferings.FindAsync(id);
            if (productOffering == null)
            {
                return HttpNotFound();
            }
            return View(productOffering);
        }

        // POST: ProductOfferings/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductOffering productOffering = await db.ProductOfferings.FindAsync(id);
            db.ProductOfferings.Remove(productOffering);
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
        [Authorize(Roles = AppRoles.ProductOfferingsAdminAction)]
        
        [Route("Create", Name = ProductOfferingsControllerRoute.Create)]
        public ActionResult GetCreate()
        {
            return this.View(ProductOfferingsControllerAction.Create);
        }
    }

}
