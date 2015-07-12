using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using egr.am.Models;
using egr.am.Constants;
namespace egr.am.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the AppRoles.SuperAdmin role if it doesn't already exist.
            if (!roleMgr.RoleExists(AppRoles.SuperAdmin))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = AppRoles.SuperAdmin });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "marcus@norcloud.ca",
                Email = "marcus@norcloud.ca"
            };

            IdUserResult = userMgr.Create(appUser, "Vlarm!982");

            // If the new AppRoles.SuperAdmin user was successfully created, 
            // add the AppRoles.SuperAdmin user to the AppRoles.SuperAdmin role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("marcus@norcloud.ca").Id, AppRoles.SuperAdmin))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("marcus@norcloud.ca").Id, AppRoles.SuperAdmin);
            }
        }
    }
}