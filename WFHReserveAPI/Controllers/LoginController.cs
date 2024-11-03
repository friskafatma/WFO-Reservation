using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WFHReserveAPI.Models;
using WFHReserveAPI.ViewModel;



namespace WFHReserveAPI.Controllers
{
    [RoutePrefix("WFHReserveAPI/Login")]
    
    public class LoginController : ApiController
    {
        DB_WFHReserveDataContext db = new DB_WFHReserveDataContext();

        [HttpPost]
        [Route("Get_Login")]
        public IHttpActionResult Get_Login(ClsLogin param)
        {
            bool remarks = false;
            try
            {

                bool status = param.Login();

                remarks = status;

                return Ok(new { Remarks = remarks });
            }
            catch (Exception)
            {

                return Ok(remarks);
            }

        }

    }
}
