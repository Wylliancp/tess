using modelo.Tabelas;
using servicos.Tabelas;
using System;
using System.Net;
using System.Web.Mvc;

namespace tess.Controllers
{
    public class ComprasController : Controller
    {
        private CompraServico compraServico = new CompraServico();
        private PessoaServico pessoaServico = new PessoaServico();
        private ProdutoServico produtoServico = new ProdutoServico();

        public ActionResult Index()
        {
            var compra = compraServico.ObterCompraOrdenadoPorData();
            return View(compra);
        }

        public ActionResult Details(long? id)
        {
            var compra = ObterCompraPorId(id);
            return compra;
        }

        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra compra)
        {
            return GravarCompra(compra);
        }

        public ActionResult Edit(long id)
        {
            var compra = compraServico.ObterCompraPorId(id);
            PopularViewBag(compra);
            return ObterCompraPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compra compra)
        {
            return GravarCompra(compra);
        }

        public ActionResult Delete(long id)
        {
            var compra = ObterCompraPorId(id);
            return compra;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long? id)
        {
            try
            {
                var compra = compraServico.EliminarCompraPorId((long)id);
                TempData["Message"] = "Compra da data" + compra.DataCompra + " foi removida com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        

        private ActionResult ObterCompraPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var compra = compraServico.ObterCompraPorId((long)id);

            if (compra == null)
                return HttpNotFound();

            return View(compra);
        }

        private void PopularViewBag(Compra compra = null)
        {
            if (compra == null)
            {
                ViewBag.PessoaId = new SelectList(pessoaServico.ObterPessoaOrdenadoPorNome(), "Id", "Nome");
                ViewBag.ProdutoId = new SelectList(produtoServico.ObterProdutoOrdenadoPorNome(), "ProdutoId", "Nome");
            }
            else
            {
                ViewBag.PessoaId = new SelectList(pessoaServico.ObterPessoaOrdenadoPorNome(), "Id", "Nome", compra.PessoaId);
                ViewBag.ProdutoId = new SelectList(produtoServico.ObterProdutoOrdenadoPorNome(), "ProdutoId", "Nome", compra.ProdutoId);
            }
        }

        private ActionResult GravarCompra(Compra compra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    compraServico.GravarCompra(compra);
                    return RedirectToAction("Index");
                }
                return View(compra);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


















//        private EFContext context = new EFContext();
//        // GET: Comprar
//        public ActionResult Index()
//        {
//            var compra = context.Compras.Include(p => p.Pessoa)
//                                        .Include(o => o.Produto)
//                                        .OrderBy(x => x.DataCompra); 
//            return View(compra);
//        }

//        public ActionResult Create()
//        {
//            ViewBag.PessoaId = new SelectList(context.Pessoas.OrderBy(x => x.Nome), "Id", "Nome");
//            ViewBag.ProdutoId = new SelectList(context.Produtos.OrderBy(x => x.Nome), "ProdutoId", "Nome");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Compra compra)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    context.Compras.Add(compra);
//                    context.SaveChanges();
//                    DecrementarProduto(compra);
//                    return RedirectToAction("index");
//                }
//                catch (Exception e)
//                {
//                    throw e;
//                }
//            }
//            return View(compra);
//        }

//        public ActionResult Details(long id)
//        {
//            var compra = context.Compras.Where(x => x.CompraId == id).Include(p => p.Pessoa).Include(pp => pp.Produto).First();
//            return View(compra);
//        }

//        public ActionResult Edit(long id)
//        {
//            ViewBag.PessoaId = new SelectList(context.Pessoas.OrderBy(x => x.Nome), "Id", "Nome");
//            ViewBag.ProdutoId = new SelectList(context.Produtos.OrderBy(x => x.Nome), "ProdutoId", "Nome");
//            var compra = context.Compras.Find(id);
//            return View(compra);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Compra compra)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    context.Entry(compra).State = EntityState.Modified;
//                    context.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//                return View(compra);
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        public ActionResult Delete(long? id)
//        {
//            var compra = context.Compras.Where(x => x.CompraId == id).Include(p => p.Pessoa).Include(pp => pp.Produto).First();
//            return View(compra);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)
//        {
//            try
//            {
//                var compra = context.Compras.Find(id);
//                context.Compras.Remove(compra);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }

//        private void DecrementarProduto(Compra compra)
//        {
//            var lista = context.Produtos.Where(x => x.ProdutoId == compra.ProdutoId).FirstOrDefault();
//            lista.Quantidade--;
//            context.SaveChanges();
//        }

//        private void IncrementarProduto(Compra compra)
//        {
//            var lista = context.Produtos.Where(x => x.ProdutoId == compra.ProdutoId).FirstOrDefault();
//            lista.Quantidade++;
//            context.SaveChanges();
//        }
//    }
//}