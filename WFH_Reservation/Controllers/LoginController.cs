using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WFH_Reservation.Models;

namespace WFH_Reservation.Controllers
{
    public class LoginController : Controller
    {
        DB_WFHReserveDataContext db = new DB_WFHReserveDataContext();

        // GET: Login
        public ActionResult Index()
        {
            Session["reserve_API"] = System.Configuration.ConfigurationManager.AppSettings["ReserveAPI"].ToString();
            Session["emp_API"] = System.Configuration.ConfigurationManager.AppSettings["EmpAPI"].ToString();
            return View();
        }


        public JsonResult MakeSession(string nrp)
        {
            
            var data = db.TBL_USERs.Where(a => a.nrp == nrp).SingleOrDefault();

            if (data != null)
            {

                Session["reserve_API"] = System.Configuration.ConfigurationManager.AppSettings["ReserveAPI"].ToString();
                Session["emp_API"] = System.Configuration.ConfigurationManager.AppSettings["EmpAPI"].ToString();
                Session["nrp"] = nrp;
                return new JsonResult() { Data = new { Remarks = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult() { Data = new { Remarks = false, Message = "Maaf anda tidak memiliki akses" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public ActionResult Logout()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Login");
        }
    }


}