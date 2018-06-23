using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net;

namespace ApiDemo.Controllers
{
    public class HealthStatusController : ApiController
    {
        // GET: HealthStatus
        public ActionResult Health()
        {
            try
            {
                //CheckDb Access, ping db
                //Check other necessary systems
            }
            catch (Exception ex)
            {
                //Log Exception
                return new HttpStatusCodeResult((int)(HttpStatusCode.ServiceUnavailable));
            }
            return new HttpStatusCodeResult((int)(HttpStatusCode.OK));
        }
    }
}