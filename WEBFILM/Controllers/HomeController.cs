using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Net.Mail;
using WEBFILM.Models;

namespace WEBFILM.Controllers
{
    public class HomeController : Controller
    {
        MovieDataContext db = new MovieDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var un = collection["Username"];
            var pw = collection["Password"];
            if (String.IsNullOrEmpty(un))
                ViewData["Loi"] = "Bạn phải nhập tên đăng nhập";
            else if (String.IsNullOrEmpty(pw))
            {
                ViewData["Loi1"] = "Bạn phải nhập mật khẩu";
            }
            else
            {
                User tk = db.Users.SingleOrDefault(n => n.Username.Equals(un) && n.Password.Equals(pw));
                if (tk != null)
                {
                    if (tk.Permission == true)//Admin
                    {
                        @Session["UserName"] = tk.Username;
                        @Session["Permission"] = 1;
                        ViewBag.ThongBao = "Đăng nhập Amin thành công admin";
                        return RedirectToAction("Home", "Admin");
                    }
                    if (tk.Permission == false || tk.Permission == null)
                    {
                        @Session["UserName"] = tk.Username;
                        @Session["Permission"] = null;
                        ViewBag.ThongBao = "Đăng nhập thành công";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData["Loi2"] = "Tên đăng nhâp hoặc mật khẩu không đúng";
                }
            }

            return RedirectToAction("Login", "User");
        }
    }
}