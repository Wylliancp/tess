using modelo.Tabelas;
using persistencia.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistencia.DAL
{
    public class ProdutoDAL
    {

        private EFContext context = new EFContext();

        public IQueryable<Produto> ObterProdutoOrdenadoPorNome()
        {
            var produto = context.Produtos.Include(c => c.Categorias)
                                          .Include(f => f.Fabricantes)
                                          .OrderBy(x => x.Nome);
            return produto;
        }

        public Produto ObterProdutoPorId(long id)
        {
            var produto = context.Produtos.Where(x => x.ProdutoId == id)
                                          .Include(c => c.Categorias)
                                          .Include(f => f.Fabricantes).First();
            return produto;
        }

        public void GravarProduto(Produto produto)
        {
            if (produto.ProdutoId == null || produto.ProdutoId.Equals(0))
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Produto EliminarProdutoPorId(long id)
        {
            var produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}
