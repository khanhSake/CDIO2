using DASHBOARD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DASHBOARD.Controllers
{
	public class NhanVienController: Controller
	{
        private NhanVienDAL dal = new NhanVienDAL();
        public ActionResult Index()
        {
            List<NhanVien> danhSach = dal.GetAllNhanVien();
            return View(danhSach);
        }
    }
}