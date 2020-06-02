using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using OnlineShop.Common;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        // Index method control to Index view
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAll(searchString, page, pageSize);
            // ViewBag ban chat la 1 noi chua du lieu tu controller xuong view.
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encrypterMD5PassWord = Encryptor.MD5Hash(user.Password);
                user.Password = encrypterMD5PassWord;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công!");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encrypterMD5PassWord = Encryptor.MD5Hash(user.Password);
                    user.Password = encrypterMD5PassWord;
                }
                var result = dao.Update(user);
                if (result == true)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDAO();
            dao.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}