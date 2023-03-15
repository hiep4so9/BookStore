using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;

namespace Webbansach.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        dbQLBanSachDataContext data = new dbQLBanSachDataContext();
        // 1. Hiện thi danh sách Nhà xuất bản
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.KHACHHANGs.ToList());
        }
        //2. Thêm mới 1 Nhà xuất bản
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Create(KHACHHANG KHACHHANG)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                data.KHACHHANGs.Add(KHACHHANG);
                data.SaveChanges();
                return RedirectToAction("Index", "KHACHHANG");
            }
        }
        //3. Xem chi tiết thông tin 1 Nhà xuất bản
        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var KHACHHANG = from nxb in data.KHACHHANGs where nxb.MaKH == id select nxb;
                return View(KHACHHANG.SingleOrDefault());
            }
        }
        //4. Xóa 1 Nhà xuất bản
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var KHACHHANG = from nxb in data.KHACHHANGs where nxb.MaKH == id select nxb;
                return View(KHACHHANG.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                KHACHHANG KHACHHANG = data.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);
                data.KHACHHANGs.Add(KHACHHANG);
                data.SaveChanges();
                return RedirectToAction("Index", "KHACHHANG");
            }
        }
        //5. Điều chỉnh thông tin 1 Nhà xuất bản
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var KHACHHANG = from nxb in data.KHACHHANGs where nxb.MaKH == id select nxb;
                return View(KHACHHANG.SingleOrDefault());
            }
        }
        //Do tên Action trùng tên, nên cần tên bí doanh
        [HttpPost, ActionName("Edit")]
        public ActionResult Xacnhansua(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                KHACHHANG KHACHHANG = data.KHACHHANGs.SingleOrDefault(n => n.MaKH == id);

                UpdateModel(KHACHHANG);
                data.SaveChanges();
                return RedirectToAction("Index", "KHACHHANG");
            }
        }
    }
}