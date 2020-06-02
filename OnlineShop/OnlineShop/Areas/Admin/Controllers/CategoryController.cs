using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Category model)
        {
            if(ModelState.IsValid)
            {
                model.Language = Session[Common.CommonConstants.CurrentCulture].ToString();
                var id = new CategoryDAO().Insert(model);
                if(id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", StaticRecourses.Resource.InsertCategoryFailed); 
                }
            }
            return View(model);
        }
    }
}