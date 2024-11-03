using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeApi;
//using WFHReserveAPI.ViewModel;

namespace EmployeeApi.Controllers
{
    [RoutePrefix("EmployeeAPI/Employee")]
    public class EmployeeController : ApiController
    {
        DB_EMPLOYEEDataContext db = new DB_EMPLOYEEDataContext();

        [HttpGet]
        [Route("Get_Employee")]
        public IHttpActionResult Get_Employee(string nrp)
        {
            try
            {
                var data = db.TBL_KARies.Where(a => a.nrp == nrp).FirstOrDefault();

                return Ok(new { Data = data });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
