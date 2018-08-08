using modelo.Tabelas;
using servicos.Tabelas;
using System;
using System.Net;
using System.Web.Mvc;

namespace tess.Areas.Tabelas.Controllers
{
    public class PessoasController : Controller
    {

        private PessoaServico pessoaServico = new PessoaServico();

        public ActionResult Index()
        {
            var pessoa = pessoaServico.ObterPessoaOrdenadoPorNome();
            return View(pessoa);
        }

        public ActionResult Details(long? id)
        {
            var pessoa = ObterPessoaPorId(id);
            return pessoa;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            return GravarPessoa(pessoa);
        }

        public ActionResult Edit(long? id)
        {
            var pessoa = ObterPessoaPorId(id);
            return pessoa;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pessoa pessoa)
        {
            return GravarPessoa(pessoa);
        }

        public ActionResult Delete(long id)
        {
            var pessoa = ObterPessoaPorId(id);
            return pessoa;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long? id)
        {
            try
            {
                var pessoa = pessoaServico.EliminarPessoaPorId((long)id);
                TempData["Message"] = "Pessoa " + pessoa.Nome.ToUpper() + " foi Removido com Sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private ActionResult ObterPessoaPorId(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pessoa = pessoaServico.ObterPessoaPorId((long)id);

            if (pessoa == null)
                return HttpNotFound();

            return View(pessoa);
        }

        private ActionResult GravarPessoa(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoaServico.GravarPessoa(pessoa);
                    return RedirectToAction("Index");
                }
                return View(pessoa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


//        private EFContext context = new EFContext();
//        // GET: Pessoas
//        public ActionResult Index()
//        {
//            var pessoa = context.Pessoas.OrderBy(x => x.Nome);
//            return View(pessoa);
//        }

//        public ActionResult Create()
//        {
//            //ViewBag.ProdutoId = new SelectList(context.Produtos.OrderBy(x => x.Nome), "ProdutoId", "Nome");
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Pessoa pessoa)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    context.Pessoas.Add(pessoa);
//                    context.SaveChanges();
//                    return RedirectToAction("index");
//                }
//                catch (Exception e)
//                {
//                    throw e;
//                }
//            }
//            return View(pessoa);
//        }

//        public ActionResult Edit(long id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var pessoa = context.Pessoas.Find(id);

//            if (pessoa == null)
//                return HttpNotFound();
//            return View(pessoa);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Pessoa pessoa)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    context.Entry(pessoa).State = EntityState.Modified;
//                    context.SaveChanges();
//                    return RedirectToAction("Index");
//                }
//                catch (Exception e)
//                {
//                    throw e;
//                }
//            }
//            return View(pessoa);
//        }

//        public ActionResult Details(long id)
//        {
//            var pessoa = context.Pessoas.Find(id);
//            return View(pessoa);
//        }

//        public ActionResult Delete(long? id)
//        {
//            var pessoa = context.Pessoas.Find(id);
//            return View(pessoa);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(long id)
//        {
//            if (id == null)
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            var pessoa = context.Pessoas.Find(id);
//            if (pessoa == null)
//                return HttpNotFound();
//            context.Pessoas.Remove(pessoa);
//            context.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}