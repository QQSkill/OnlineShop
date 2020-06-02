using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long cateID, int page = 1, int pageSize = 1)
        {
            var category = new ProductCategoryDAO().ViewDetail(cateID);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDAO().ListByCategoryId(cateID, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5; 
            int totalPage = 0;

            totalPage = (int)(totalRecord / pageSize);
            ViewBag.MaxPage = maxPage;
            ViewBag.TotalPage = totalPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProducts(id);
            return View(product);
        }

        public JsonResult ListName(string q)
        {
            var data = new ProductDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDAO().Search(keyword, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)(totalRecord / pageSize);
            ViewBag.MaxPage = maxPage;
            ViewBag.TotalPage = totalPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}