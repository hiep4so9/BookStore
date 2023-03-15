using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;

namespace Webbansach.Controllers
{
    public class ChuDeController : Controller
    {
        dbQLBanSachDataContext data = new dbQLBanSachDataContext();
        // GET: ChuDe
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.CHUDEs.ToList());
        }
        //2. 
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpPost]
        public ActionResult Create(CHUDE chude)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                data.CHUDEs.Add(chude);
                data.SaveChanges();
                return RedirectToAction("Index", "chude");
            }
        }
        //3. Xem chi tiết thông tin 1 Nhà xuất bản
        public ActionResult Details(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var chude = from cd in data.CHUDEs where cd.MaCD == id select cd;
                return View(chude.SingleOrDefault());
            }
        }
        //4. Xóa 1 Nhà xuất bản
        public ActionResult Delete(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var chude = from cd in data.CHUDEs where cd.MaCD == id select cd;
                return View(chude.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                CHUDE chude = data.CHUDEs.SingleOrDefault(n => n.MaCD == id);
                data.CHUDEs.Add(chude);
                data.SaveChanges();
                return RedirectToAction("Index", "chude");
            }
        }
        //5. Điều chỉnh thông tin 1 Nhà xuất bản
        public ActionResult Edit(int id)
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var chude = from cd in data.CHUDEs where cd.MaCD == id select cd;
                return View(chude.SingleOrDefault());
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
                CHUDE chude = data.CHUDEs.SingleOrDefault(n => n.MaCD == id);

                UpdateModel(chude);
                data.SaveChanges();
                return RedirectToAction("Index", "chude");
            }
        }
    }
}