using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDAO().GetActiveContact();
            return View(model);
        }

        [HttpPost]
        public ActionResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Phone = mobile;
            feedback.Address = address;
            feedback.Email = email;
            feedback.Content = content;

            var id = new ContactDAO().InsertFeedBack(feedback);
            if(id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}