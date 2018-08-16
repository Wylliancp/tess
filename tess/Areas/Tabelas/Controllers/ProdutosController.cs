using modelo.Tabelas;
using servicos.Tabelas;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace tess.Areas.Tabelas.Controllers
{
    public class ProdutosController : Controller
    {

        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        public ActionResult Index()
        {
            var produto = produtoServico.ObterProdutoOrdenadoPorNome();
            return View(produto);
        }

        public ActionResult Details(long id)
        {
            var produto = ObterProdutoPorId(id);
            return produto;
        }

        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto, HttpPostedFileBase logotipo = null)
        {
            return GravarProduto(produto, logotipo, null);
        }

        public ActionResult Edit(long id)
        {
            var produto = produtoServico.ObterProdutoPorId(id);
            PopularViewBag(produto);
            return ObterProdutoPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto, HttpPostedFileBase logotipo = null, string chkRemoverImagem = null)
        {
            return GravarProduto(produto, logotipo, chkRemoverImagem);
        }

        public ActionResult Delete(long? id)
        {
            var produto = ObterProdutoPorId(id);
            return produto;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                var produto = produtoServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi Removido com Sucesso!!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private ActionResult ObterProdutoPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var produto = produtoServico.ObterProdutoPorId((long)id);

            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        private void PopularViewBag(Produto produto = null)
        {
            if(produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriaOrdenadoPorNome(), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricanteOrdenadoPorNome(), "FabricanteId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriaOrdenadoPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricanteOrdenadoPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }

        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase logotipo, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(chkRemoverImagem != null)
                    {
                        produto.LogoTipo = null;
                    }
                    if ( logotipo != null)
                    {
                        produto.LogotipoMimeType = logotipo.ContentType;
                        produto.LogoTipo = SetLogotipo(logotipo);
                    }
                    produtoServico.GravarProduto(produto);
                    PopularViewBag(produto);
                    return RedirectToAction("Index");
                }
                PopularViewBag(produto);
                return View(produto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private byte[] SetLogotipo(HttpPostedFileBase logotipo)
        {
            var bytesLogotipo = new byte[logotipo.ContentLength];
            logotipo.InputStream.Read(bytesLogotipo, 0, logotipo.ContentLength);
            return bytesLogotipo;
        }

        public FileContentResult GetLogotipo(long id)
        {
            Produto produto = produtoServico.ObterProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.LogoTipo, produto.LogotipoMimeType);
            }
            return null;
        }
    }
}
//        private EFContext context = new EFContext();
//        // GET: Produtos
//        public ActionResult Index()
//        {
//            var produto = context.Produtos.Include(c => c.Categorias)
//                                          .Include(f => f.Fabricantes).OrderBy(x => x.Nome);
//            return View(produto);
//        }

//        public ActionResult Create()
//        {
//            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(x => x.Nome), "CategoriaId", "Nome");
//            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(x => x.Nome), "FabricanteId", "Nome");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Produto produto)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    context.Produtos.Add(produto);
//                    context.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//                return View(produto);
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }
        
//        public ActionResult Edit(long? id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var produto = context.Produtos.Find(id);

//            if (produto == null)
//                return HttpNotFound();
//            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(c => c.Nome), "CategoriaId", "Nome");
//            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(f => f.Nome), "FabricanteId", "Nome");
//            return View(produto);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Produto produto)
//        {
//            if (ModelState.IsValid)
//            {
//                context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(produto);
//        }

//        public ActionResult Details(long? id)
//        {
//            var produto = context.Produtos.Where(x => x.ProdutoId == id)
//                                          .Include(c => c.Categorias)
//                                          .Include(f => f.Fabricantes).First();
//            return View(produto);
//        }

//        public ActionResult Delete(long? id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//           var produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categorias).Include(f => f.Fabricantes).FirstOrDefault();
//            if (produto == null)
//                return HttpNotFound();
//            return View(produto);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var produto = context.Produtos.Where(x => x.ProdutoId == id).Include(c => c.Categorias).Include(f => f.Fabricantes).FirstOrDefault();
//            context.Produtos.Remove(produto);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }


//    }
//}