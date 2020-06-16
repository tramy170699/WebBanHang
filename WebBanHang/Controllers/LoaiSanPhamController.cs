using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models.Entity;

namespace WebBanHang.Controllers
{
    public class LoaiSanPhamController : Controller
    {
       
        BanHangEntity db;
        List<LoaiSanPham> getlstLoaiSanPham()
        {
            db = new BanHangEntity();
            var lst = db.LoaiSanPhams.OrderBy(x => x.LoaiSanPhamID).ToList();
            return lst;
        }

        // tesst git
        // GET: LoaiSanPham
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
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
            var lstLoaiSanPham = getlstLoaiSanPham().AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                lstLoaiSanPham = lstLoaiSanPham.Where(s => s.TenLoai.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    lstLoaiSanPham = lstLoaiSanPham.OrderByDescending(s => s.TenLoai);
                    break;
                default:  // Name ascending 
                    lstLoaiSanPham = lstLoaiSanPham.OrderBy(s => s.TenLoai);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lstLoaiSanPham.ToPagedList(pageNumber, pageSize));
            /// test
        }

    }
}