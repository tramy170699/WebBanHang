using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using PagedList;
using WebBanHang.Models.Entity;

namespace WebBanHang.Controllers
{
    public class BaoCaoController : Controller
    {
        // GET: BaoCao
        BanHangEntity db;
        List<DonDatHang> getlstDonDatHang()
        {
            db = new BanHangEntity();
            var lst = db.DonDatHangs.OrderBy(x => x.DonDatHangID).ToList();
            return lst;
        }
        public ActionResult BangKeMuaHangHoa(string currentSFilter, string searchDateS, string currentFFilter, string searchDateF, int? option, int? sanPhamID, int? page)
        {
           
                db = new BanHangEntity();
                ViewBag.lstSanPham = new SelectList(db.SanPhams, "SanPhamID", "TenSanPham", sanPhamID);
                ViewBag.sanPhamID = sanPhamID;
                if (searchDateS != null || searchDateF != null)
                {
                    page = 1;
                }
                else
                {
                    searchDateS = currentSFilter;
                    searchDateF = currentFFilter;
                }

                ViewBag.CurrentSFilter = searchDateS;
                ViewBag.CurrentFFilter = searchDateF;

                var lstDonDatHang = getlstDonDatHang().AsQueryable().Where(x => x.TinhTrang != 0);

                if (sanPhamID.HasValue)
                {
                    lstDonDatHang = lstDonDatHang.Where(s => s.ChiTietDonDatHangs.Any(x => x.SanPhamID == sanPhamID));
                }
                if (!String.IsNullOrEmpty(searchDateS))
                {
                    lstDonDatHang = lstDonDatHang.Where(s => s.NgayDat >= Convert.ToDateTime(searchDateS));
                }
                if (!String.IsNullOrEmpty(searchDateF))
                {
                    lstDonDatHang = lstDonDatHang.Where(s => s.NgayDat <= Convert.ToDateTime(searchDateF));
                }
                if (option.HasValue)
                {
                    if (option == -1)
                        lstDonDatHang = lstDonDatHang.Where(o => o.TinhTrang != TrangThaiDonHang.CHUA_GUI && o.TinhTrang != TrangThaiDonHang.THANH_LY_HUY_HANG);
                    else
                        lstDonDatHang = lstDonDatHang.Where(o => o.TinhTrang == option);
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(lstDonDatHang.ToPagedList(pageNumber, pageSize));
            }
    
    }
}