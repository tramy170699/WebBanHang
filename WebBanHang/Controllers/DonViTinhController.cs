using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models.Entity;

namespace WebBanHang.Controllers
{
    public class DonViTinhController : Controller
    {
        BanHangEntity db;
        List<DonViTinh> GetlstDVT()
        {
            db = new BanHangEntity();
            var lst = db.DonViTinhs.ToList();
            return lst;
        }
        // GET: DonViTinh
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //if (Session["username"] == null)
            //    return RedirectToAction("/Index", "Users");
            //else
            //{
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;
                var lstDonViTinh = GetlstDVT().AsQueryable();
                if (!String.IsNullOrEmpty(searchString))
                {
                    lstDonViTinh = lstDonViTinh.Where(s => s.TenDonVi.ToUpper().Contains(searchString.ToUpper()));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        lstDonViTinh = lstDonViTinh.OrderByDescending(s => s.TenDonVi);
                        break;
                    default:  // Name ascending 
                        lstDonViTinh = lstDonViTinh.OrderBy(s => s.TenDonVi);
                        break;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(lstDonViTinh.ToPagedList(pageNumber, pageSize));
            //}
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(DonViTinh donViTinh)
        {
            if(ModelState.IsValid)
            {
                using (var db = new BanHangEntity())
                {
                    db.DonViTinhs.Add(donViTinh);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(donViTinh);
        }
        //--
    }
}