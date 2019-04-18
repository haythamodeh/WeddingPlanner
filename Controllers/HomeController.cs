using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;


namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private WeddingContext dbContext;

        public HomeController(WeddingContext context)
        {
            dbContext = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
             List<Wedding> AllWeddings = dbContext.Weddings
                .Include(g => g.AllGuests)
                .ThenInclude(u => u.User)
                .ToList();

                User retreivedUser = dbContext.Users.FirstOrDefault(u => u.UserID == userID);
                ViewBag.User = retreivedUser;
            return View("dashboard", AllWeddings);
        }

        // [HttpGet("login")]
        // public IActionResult Login()
        // {
        //     return RedirectToAction("Dashboard");
        // }

        [HttpPost("login")]
        public IActionResult LoginValidate(LogRegWrapper LogRegWrapper)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == LogRegWrapper.Login.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(LogRegWrapper.Login, userInDb.Password, LogRegWrapper.Login.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }   
                HttpContext.Session.SetInt32("userID", userInDb.UserID);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("create")]
        public IActionResult CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already taken");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("userID", user.UserID);
                return RedirectToAction("Dashboard");
            }
            else
                return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }




        ///////////////////////////////////////////////////////////////////

        [HttpGet("view/wedding/{weddingID}")]
        public IActionResult ViewWedding(int weddingID)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
            Wedding retreivedWedding = dbContext.Weddings
                .Include(g => g.AllGuests)
                .ThenInclude(u => u.User)
                .FirstOrDefault(w => w.WeddingID == weddingID);
            return View("viewWedding", retreivedWedding);
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View("newWedding");
        }
        [HttpPost("wedding/new")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                if(newWedding.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date needs to be in the future!");
                    return View("newWedding");
                }
                newWedding.UserID = (int)userID;
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("viewWedding", new{weddingID = newWedding.WeddingID});
            }
            else
            {
                return View("newWedding");
            }
        }
        [HttpGet("delete/wedding/{weddingID}")]
        public IActionResult DeleteWedding(int weddingID)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
            Wedding retreivedWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingID == weddingID);
            dbContext.Weddings.Remove(retreivedWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("rsvp/wedding/{weddingID}")]
        public IActionResult RSVPWedding(int weddingID)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
            Wedding retreivedWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingID == weddingID);
            Association newrsvp = new Association();
            newrsvp.UserID = (int)userID; 
            newrsvp.WeddingID = retreivedWedding.WeddingID;
            newrsvp.Wedding = retreivedWedding;
            newrsvp.User = dbContext.Users.FirstOrDefault(u => u.UserID == userID);
            dbContext.Add(newrsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("unrsvp/wedding/{weddingID}")]
        public IActionResult UNRSVPWedding(int weddingID)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID == null)
            {
                TempData["error"] = "You need to be logged in to view this page";
                return RedirectToAction("Index");
            }
            Association unrsvp = dbContext.Associations
                .Where(w => w.WeddingID == weddingID)
                .FirstOrDefault(u => u.UserID == userID);
                dbContext.Remove(unrsvp);
                dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }



    }
}
