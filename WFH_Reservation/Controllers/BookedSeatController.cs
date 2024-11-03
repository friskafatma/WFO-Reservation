using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WFH_Reservation.Controllers
{
    public class BookedSeatController : Controller
    {
        // GET: BookedSeat
        public ActionResult Index()
        {
            return View();
        }
    }
}