using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WFHReserveAPI.Models;
using WFHReserveAPI.ViewModel;
using System.Web.Http.Cors;



namespace WFHReserveAPI.Controllers
{
    [RoutePrefix("WFHReserveAPI/Booking")]
    public class BookingController : ApiController
    {
        DB_WFHReserveDataContext db = new DB_WFHReserveDataContext();

        [HttpGet]
        [Route("Get_Seat")]
        public IHttpActionResult GetSeats()
        {
            var seats = db.TBL_SEATs.Select(seat => new ClsSeat
            {
                Number = seat.seat_no,
                Type = seat.seat_type,
                Avail = seat.is_avail
            }).ToList();

            return Ok(seats);
        }

        [HttpGet]
        [Route("Get_Time")]
        public IHttpActionResult Get_TargetTime()
        {
            DateTime now = DateTime.Now;
            DateTime targetTime;
            if (now.Hour >= 21 && now.Hour < 23)
            {
                targetTime = new DateTime(now.Year, now.Month, now.Day, 23, 0, 0);
            }
            else
            {
                DateTime nextDay = now.AddDays(1);
                targetTime = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 6, 0, 0);
            }

            return Ok(new { targetTime = targetTime });
        }

        [HttpPost]
        [Route("BookingSeat")]
        public IHttpActionResult BookingSeat(IList<TBL_BOOKING> data)
        {
            try
            {
                var cek = db.TBL_BOOKINGs.Where(a => a.nrp == data[0].nrp).SingleOrDefault();
                if (cek == null)
                {

                    List<TBL_BOOKING> tblBooking = new List<TBL_BOOKING>();

                    foreach (var book in data)
                    {
                        tblBooking.Add(new TBL_BOOKING
                        {
                            nrp = book.nrp,
                            seat_no = book.seat_no,
                            tanggal = DateTime.Now
                        });
                    }

                    db.TBL_BOOKINGs.InsertAllOnSubmit(tblBooking);
                    db.SubmitChanges();
                    return Ok(new { Remarks = true });
                }
                else
                {
                    return Ok(new { Remarks = false, Message = "Anda sudah memilih kursi" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { Remarks = false, Message = e });
            }
        }


    }
}
