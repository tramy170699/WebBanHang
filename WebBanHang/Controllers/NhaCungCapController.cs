using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models.Entity;

namespace WebBanHang.Controllers
{
    public class NhaCungCapController : Controller
    {
        BanHangEntity db;
        List<NhaCungCap> GetNhaCungCaps()
        {
            db = new BanHangEntity();
            var lst = db.NhaCungCaps.ToList();
            return lst;
        }
        // GET: NhaCungCap
        public ActionResult Index(string sortOrder,string currentFilter,string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if(searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var lstNhaCungCap = GetNhaCungCaps().AsQueryable();
            if(!String.IsNullOrEmpty(searchString))
            {
                lstNhaCungCap = lstNhaCungCap.Where(s => s.TenNhaCungCap.ToUpper().Contains(searchString.ToUpper()));

            }
            switch(sortOrder)
            {
                case "name_desc":
                    lstNhaCungCap = lstNhaCungCap.OrderBy(s => s.TenNhaCungCap);
                    break;
                default:
                    lstNhaCungCap = lstNhaCungCap.OrderBy(s => s.TenNhaCungCap);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(lstNhaCungCap.ToPagedList(pageNumber,pageSize));
        }
    }
}