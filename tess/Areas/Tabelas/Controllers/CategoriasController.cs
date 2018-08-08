using modelo.Tabelas;
using servicos.Tabelas;
using System;
using System.Net;
using System.Web.Mvc;

namespace tess.Areas.Tabelas.Controllers
{
    [Authorize(Roles = "administradores")]
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();

        public ActionResult Index()
        {
            var categoria = categoriaServico.ObterCategoriaOrdenadoPorNome();
            return View(categoria);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Details(long? id)
        {
            var categoria = ObterCategoriaPorId((long)id);
            return categoria;
        }

        public ActionResult Edit(long id)
        {
            var categoria = ObterCategoriaPorId(id);
            return categoria;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        public ActionResult Delete(long? id)
        {
            var categoria = ObterCategoriaPorId((long)id);
            return categoria;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                var categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi Removido!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult ObterCategoriaPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = categoriaServico.ObterCategoriaPorId((long)id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


        // GET: Categorias

//        public static IList<Categoria> categorias = new List<Categoria>()
//        {
//            new Categoria()
//            {
//                CategoriaId = 1,
//                Nome = "Notebooks"
//            },
//            new Categoria()
//            {
//                CategoriaId = 2,
//                Nome = "Monitores"
//            },
//            new Categoria()
//            {
//                CategoriaId = 3,
//                Nome = "Impressoras"
//            },
//            new Categoria()
//            {
//                CategoriaId = 4,
//                Nome = "Mouse"
//            },
//            new Categoria()
//            {
//                CategoriaId = 5,
//                Nome = "Desktop"
//            }
//        };
//        private EFContext context = new EFContext();

//        public ActionResult Index()
//        {
//            //return View(categorias);
//                var categoria = context.Categorias.OrderBy(x => x.Nome);
//                return View(categoria);  
//        }

//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Categoria categoria)
//        {
//            //categorias.Add(categoria);
//            //categoria.CategoriaId = categorias.Select(x => x.CategoriaId).Max() + 1;
//            //return RedirectToAction("Index");
//                context.Categorias.Add(categoria);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//        }

//        public ActionResult Edit(long id)
//        {
//            //return View(categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//                var categoria = context.Categorias.Find(id);
//                return View(categoria);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Categoria categoria)
//        {
//            //Categoria aux = categorias.Where(x => x.CategoriaId == categoria.CategoriaId).FirstOrDefault();
//            //categorias.Remove(aux);
//            //categorias.Add(categoria);
//            //return RedirectToAction("Index");

//                if (ModelState.IsValid)
//                {
//                    context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
//                    context.SaveChanges();
//                    return RedirectToAction("index");
//                }
//                return View(categoria);
//        }

//        public ActionResult Details(long id)
//        {
//            //return View(categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//                return View(context.Categorias.Find(id));
//        }

//        public ActionResult Delete(long? id)
//        {
//            //return View(categorias.Where(x => x.CategoriaId == id).FirstOrDefault());
//                var categoria = context.Categorias.Find(id);
//                return View(categoria);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)//(Categoria categoria)
//        {
//            //Categoria aux = categorias.Where(x => x.CategoriaId == categoria.CategoriaId).FirstOrDefault();
//            //categorias.Remove(aux);
//            //return RedirectToAction("Index");

//                var categoria = context.Categorias.Find(id);
//                context.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
//                context.SaveChanges();
//                return RedirectToAction("index");
//        }
//    }
//}