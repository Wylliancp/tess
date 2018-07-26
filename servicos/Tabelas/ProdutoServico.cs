using modelo.Tabelas;
using persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicos.Tabelas
{
    public class ProdutoServico
    {

        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable ObterProdutoOrdenadoPorNome()
        {
            return produtoDAL.ObterProdutoOrdenadoPorNome();
        }

        public Produto ObterProdutoPorId(long id)
        {
            return produtoDAL.ObterProdutoPorId(id);
        } 

        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }

        public Produto EliminarProdutoPorId(long id)
        {
            return produtoDAL.EliminarProdutoPorId(id);
        }
    }
}
