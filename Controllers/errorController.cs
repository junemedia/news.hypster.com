using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hypster_tv.Controllers
{
    public class errorController : Controller
    {
        //
        // GET: /error/

        public ActionResult NotFound()
        {
            return View();
        }

    }
}
