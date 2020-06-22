using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models.Entity;
using PagedList;


namespace WebBanHang.Controllers
{
    public class UsersController : Controller
    {
        BanHangEntity db;
        // GET: Users
        List<User> getlstUser()
        {
            db = new BanHangEntity();
            var lst = db.Users.ToList();
            return lst;
        }

        public ActionResult Index()
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

            using (var db = new BanHangEntity())
            {
                if (ModelState.IsValid)
                {
                    us.NgayLap = DateTime.Now;
                    db.Users.Add(us);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                    return View(us);
            }


        }
        public ActionResult Edit(int id)
        {


            using (var db = new BanHangEntity())
            {
                try
                {
                    User us = db.Users.Find(id);
                    return View(us);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new HttpStatusCodeResult(404, "Error in cloud - GetPLUInfo" + ex.Message);
                }


            }
        }

        [HttpPost]
        public ActionResult Edit(User us)
        {
            using (var db = new BanHangEntity())
            {
                db.Entry(us).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("/List");
        }

        public ActionResult Details(int id)
        {

            using (var db = new BanHangEntity())
            {
                try
                {
                    User us = db.Users.Find(id);
                    return View(us);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new HttpStatusCodeResult(404, "Error in cloud - GetPLUInfo" + ex.Message);
                }
            }

        }
        public ActionResult List(string sortOrder, string currentFilter, string searchString, int? page)
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
                var lstUser = getlstUser().AsQueryable();
                if (!String.IsNullOrEmpty(searchString))
                {
                    lstUser = lstUser.Where(s => s.HoTen.ToUpper().Contains(searchString.ToUpper()));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        lstUser = lstUser.OrderByDescending(s => s.HoTen);
                        break;
                    default:  // Name ascending 
                        lstUser = lstUser.OrderBy(s => s.HoTen);
                        break;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(lstUser.ToPagedList(pageNumber, pageSize));
            
        }

        public ActionResult Delete(int id)
        {
            using (var db = new BanHangEntity())
            {
                try
                {
                    User us = db.Users.Find(id);
                    return View(us);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new HttpStatusCodeResult(404, "Error in cloud - GetPLUInfo" + ex.Message);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(float id)
        {
            using (var db = new BanHangEntity())
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("/List");
        }

    }
}