using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models.Entity;
using WebBanHang.Models;


namespace WebBanHang.Controllers
{
    public class ListSanPham
    {
        public List<SanPham> SanPhams { get; set; }
        public int? SoLuong { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
          //  ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ListDonDat()
        {
            return View();
        }
        public ActionResult CartView()
        {
            return View();
        }
        public ActionResult ChiTietDon()
        {
            return View();
        }
        public ActionResult DeleteItem()
        {
            return View();
        }
        public ActionResult CheckOutView()
        {
           
                return View();
           
        }
        [HttpPost]
        public ActionResult CheckOut()
        {
            return View();
        }
        public ActionResult ListProductView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ListProduct()
        {
            return View();
        }
        public ActionResult DetailProductView()
        {
            return View();

        }
        [HttpPost]
        public ActionResult DetailProduct()
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(User us)
        {
            return View();
        }



    }
}