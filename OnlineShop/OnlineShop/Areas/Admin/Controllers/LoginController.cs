using Model.DAO;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            var dao = new UserDAO();
            var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
            if(result == 1)
            {
                var user = dao.GetByID(model.UserName);
                var userSession = new UserLogin();
                userSession.UserName = user.UserName;
                userSession.UserID = user.ID;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home");
            }
            else if (result == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại!");
            }
            else if(result == -1)
            {
                ModelState.AddModelError("", "Tài khoản bị khóa!");
            }
            else if(result == -2)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng!");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng!");
            }
            return View("Index");
        }

    }
}