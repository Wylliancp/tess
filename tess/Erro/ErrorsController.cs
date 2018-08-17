using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tess.Erro
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult General(Exception exception)
        {
            return View();
        }

        public ActionResult Http400()
        {
            return View();
        }

        public ActionResult Http404()
        {
            return View();
        }

    }
}