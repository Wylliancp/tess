using modelo.Tabelas;
using servicos.Tabelas;
using System;
using System.Net;
using System.Web.Mvc;

namespace tess.Areas.Tabelas.Controllers
{
    public class FabricanteController : Controller
    {

        private FabricanteServico fabricanteServico = new FabricanteServico();
        
        public ActionResult Index()
        {
            var fabricante = fabricanteServico.ObterFabricanteOrdenadoPorNome();
            return View(fabricante);
        }

        public ActionResult Details(long? id)
        {
            var fabricante = ObterFabricantePorId(id);
            return fabricante;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Edit(long id)
        {
            var fabricante = ObterFabricantePorId(id);
            return fabricante;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        public ActionResult Delete(long id)
        {
            var fabricante = ObterFabricantePorId(id);
            return fabricante;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long? id)
        {
            try
            {
                var fabricante = fabricanteServico.EliminarFabricantePorId((long)id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi Removido com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private ActionResult ObterFabricantePorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var fabricante = fabricanteServico.ObterFabricanteProId((long)id);

            if (fabricante == null)
                return HttpNotFound();

            return View(fabricante);
        }

        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


//        private EFContext context = new EFContext();
        
//        // GET: Fabricante
//        public ActionResult Index()
//        {
//            return View(context.Fabricantes.OrderBy(x => x.Nome));
//        }

//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Fabricante fabricante)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Fabricantes.Add(fabricante);
//                context.SaveChanges();
//            }
//            return RedirectToAction("Index");
//        }

//        public ActionResult Edit(long? id)
//        {
//            if(id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Fabricante fabricante = context.Fabricantes.Find(id);
//            if(fabricante == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fabricante);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Fabricante fabricante)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(fabricante);
//            //var resultado = Json(
//            //    new
//            //    {
//            //        msg = "Sucesso",
//            //        result = fabricante,
//            //        ok = HttpStatusCode.OK
//            //    }, JsonRequestBehavior.AllowGet
//            //    );
//        }

//        public ActionResult Details(long? id)
//        {
//            if(id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            Fabricante fabriacante = context.Fabricantes.Find(id);
//            if (fabriacante == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fabriacante);
//        }

//        public ActionResult Delete(long? id)
//        {
//            if(id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }

//            Fabricante fabricante = context.Fabricantes.Find(id);
//            if(fabricante == null)
//            {
//                return HttpNotFound();
//            }
//            return View(fabricante);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)
//        {
//            Fabricante fabricante = context.Fabricantes.Find(id);
//            context.Fabricantes.Remove(fabricante);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }


//    }
//}