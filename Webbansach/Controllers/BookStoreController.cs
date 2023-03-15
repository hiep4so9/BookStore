using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbansach.Models;
using PagedList;
using PagedList.Mvc;
namespace Webbansach.Controllers
{
    public class BookStoreController : Controller
    {
        // GET: BookStore
        //Tao doi tuong data chưa dữ liệu từ model dbQLBansach đã tạo. 
        dbQLBanSachDataContext data = new dbQLBanSachDataContext();

        // Ham lay n quyen sach moi
        private List<SACH> Laysachmoi(int count)
        {
            //Sắp xếp sách theo ngày cập nhật, sau đó lấy top @count 
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page )
        {
            int pagesize = 6;
            int pagenum = (page ?? 1);
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = Laysachmoi(15);
            return View(sachmoi.ToPagedList(pagenum, pagesize));
        }
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from nxb in data.NHAXUATBANs  select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult Sachtheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SachtheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB==id select s;
            return View(sach);
        }
        public ActionResult Chitietsach(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}