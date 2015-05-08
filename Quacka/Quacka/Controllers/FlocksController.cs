using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Quacka.Models;

namespace Quacka.Controllers
{
    public class FlocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Flocks
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.SingleOrDefault(u => u.Id == userId);
            if (currentUser != null)
            {
                return View(new ShowViewModel
                {
                    UserName = currentUser.UserName,
                    Followers = currentUser.Followers.Select(u => u.UserName),
                    Following = currentUser.Following.Select(u => u.UserName),
                    IsFollowing = false,
                    Quacks = currentUser.Following.Select(f => f.Quacks).SelectMany(q => q).OrderByDescending(q => q.CreatedAt)
                });
            }
            return View(new ShowViewModel());
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
