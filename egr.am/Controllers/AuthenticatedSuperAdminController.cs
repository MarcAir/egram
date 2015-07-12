using System.Diagnostics;
using System.Text;
using System.Web.Mvc;
using Boilerplate.Web.Mvc;
using Boilerplate.Web.Mvc.Filters;
using egr.am.Constants;
using egr.am.Services;
using egr.am.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace egr.am.Controllers
{
   
    public class AuthenticatedSuperAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AuthenticatedSuperAdmin
        [Authorize(Users = AppRoles.SuperAdmin)]
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: AuthenticatedSuperAdmin/Details/5
        [Authorize(Users = AppRoles.SuperAdmin)]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthenticatedSuperAdmin/Create
        [Authorize(Users = AppRoles.SuperAdmin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthenticatedSuperAdmin/Create

        [HttpPost]
        [Authorize(Users = AppRoles.SuperAdmin)]
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

        // GET: AuthenticatedSuperAdmin/Edit/5
        [Authorize(Users = AppRoles.SuperAdmin)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthenticatedSuperAdmin/Edit/5
        [HttpPost]
        [Authorize(Users = AppRoles.SuperAdmin)]
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

        // GET: AuthenticatedSuperAdmin/Delete/5
        [Authorize(Users = AppRoles.SuperAdmin)]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthenticatedSuperAdmin/Delete/5
        [HttpPost]
        [Authorize(Users = AppRoles.SuperAdmin)]
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
    

    [Route("SuperAdmin", Name = AdminControllerRoute.GetSuperAdmin)]
    public ActionResult SuperAdmin()
    {
        return this.View(AdminControllerAction.SuperAdmin);
    }

        [Route("ManageUsers", Name = AdminControllerRoute.GetSuperAdminManageUsers)]
        public ActionResult ManageUsers()
        {
            return this.View(AdminControllerAction.ManageUsers);
        }

    }
}
