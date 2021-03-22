using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChetuProject.Models;
using System.Web.Security;
using System.IO;

namespace ChetuProject.Controllers
{

   [Authorize]
    public class UserController : Controller
    {       

        DatabaseContext db = new DatabaseContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.userAccounts.ToList());
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserAccount obj, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                filename = DateTime.Now.ToString("yymmssfff") + extension;
                obj.ProfileImage = "~/PICS/" + filename;
                filename = Path.Combine(Server.MapPath("~/PICS/"), filename);
                ImageFile.SaveAs(filename);


                db.userAccounts.Add(obj);
                db.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.Message = obj.UserName + "  SuccessFully Registred.";
            return View();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserAccount obj)
        {
            var usr = db.userAccounts.Single(u => u.UserName == obj.UserName && u.Password == obj.Password);
            if (usr!= null)
            {
                Session["UserID"] = usr.Id.ToString();
                Session["UserName"] = usr.UserName.ToString();
                string img = usr.ProfileImage.ToString();
                Session["Img"] = img;

                FormsAuthentication.SetAuthCookie(obj.Email,false);
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "UserName Password is wrong");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
            
        }

        public ActionResult LoggedIn()
        {         
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }          

        }

        //[HttpGet]
        //public ActionResult LoggedIn(int id)
        //{
        //    UserAccount uaImg = new UserAccount();
        //    uaImg = db.userAccounts.Where(x => x.Id == id).FirstOrDefault();
        //    return View(uaImg);

        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult LoggedIn(UserAccount obj)
        //{

        //    db.userAccounts.Add(obj);
        //    db.SaveChanges();

        //    return View();
        //}



    }
    }