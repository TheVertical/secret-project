using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;

namespace SecretProject.DAL.DataInitiazation
{
    public class IdentityDataInitializer : DataInitializerBase
    {
        public override void InitializeData(DbContext context)
        {
            if (!(context is AppIdentityDbContext))
                throw new ArgumentException("Your context is wrong for this function! You need AppIdentityDbContext context!");
            InitializeData(context);
        }
        //public void InitializeData(AppIdentityDbContext _context)
        //{
        //    IdentityRole identityRole = new IdentityRole("Admin");
        //    _context.Roles.Add(identityRole);
        //    var role = _context.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                
        //    List<IdentityRoleClaim<string>> claims = new List<IdentityRoleClaim<string>>();
        //    foreach(var c in Enum.GetNames(typeof(SecretProject.Constans.Contans)))
        //    {
        //        var claim = new Claim(c, Guid.NewGuid().ToString());
        //        var claimValue = Guid.NewGuid().ToString();

        //        var userClaim = new IdentityUserClaim<string>();
        //        userClaim.ClaimType = c;
        //        userClaim.ClaimValue = claimValue;

        //        var identityRoleClaim = new IdentityRoleClaim<string>();
        //        identityRoleClaim.ClaimType = c;
        //        identityRoleClaim.ClaimValue = 
        //        identityRoleClaim.RoleId = role.Id;

        //        claims.Add(identityRoleClaim);
        //    }
        //    _context.RoleClaims.AddRange(claims);

        //    var identityUserClaim = new IdentityUserClaim<string>();

        //    IdentityUser admin = new IdentityUser("Admin");

        //    var password = "potapov2222";
        //    var salt = "l12kmlkzspdf";
        //    var cryptedPassword = password;

        //    admin.PasswordHash = cryptedPassword;
        //    var adminRole = new IdentityUserRole<string>();
        //    adminRole.RoleId = role.Id;
        //    adminRole.UserId = admin.Id;
        //    _context.UserRoles.Add(adminRole);
        //    _context.Users.Add(admin);
        //    _context.SaveChanges();
        //}
    }
}
