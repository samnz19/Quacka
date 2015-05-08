using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Quacka.Models;

namespace Quacka.Controllers
{
    public class PondsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Show(string userName = "")
        {
            if (userName != "")
            {
                var user = db.Users.SingleOrDefault(u => u.UserName == userName + "@quacka.com");
                if (user != null)
                {
                    string userId = User.Identity.GetUserId();
                    ApplicationUser currentUser = db.Users.SingleOrDefault(c => c.Id == userId);
                    ShowViewModel viewModel = new ShowViewModel
                    {
                        IsFollowing = false,
                        UserName = user.UserName,
                        Quacks = user.Quacks
                    };
                    if (currentUser != null)
                    {
                        viewModel.IsFollowing = user.Followers.Contains(currentUser);
                    }
                    return View(viewModel);
                }
            }
            return RedirectToRoute("Pond");
        }

        [HttpPost]
        public ActionResult Flock(string UserName = "")
        {
            if (UserName != "")
            {
                ApplicationUser userToFollow = db.Users.SingleOrDefault(u => u.UserName == UserName + "@quacka.com");
                if (userToFollow != null)
                {
                    string userId = User.Identity.GetUserId();
                    ApplicationUser currentUser = db.Users.Single(u => u.Id == userId);
                    userToFollow.Followers.Add(currentUser);
                    db.SaveChanges();
                }
            }
            return RedirectToRoute("Pond", new {userName = UserName});
        }

        [HttpPost]
        public ActionResult Unflock(string UserName = "")
        {
            if (UserName != "")
            {
                ApplicationUser userToFollow = db.Users.SingleOrDefault(u => u.UserName == UserName + "@quacka.com");
                if (userToFollow != null)
                {
                    string userId = User.Identity.GetUserId();
                    ApplicationUser currentUser = db.Users.Single(u => u.Id == userId);
                    userToFollow.Followers.Remove(currentUser);
                    db.SaveChanges();
                }
            }
            return RedirectToRoute("Pond", new {userName = UserName});
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
