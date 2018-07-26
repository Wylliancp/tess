using modelo.Tabelas;
using persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicos.Tabelas
{
    public class CategoriaServico
    {

        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable ObterCategoriaOrdenadoPorNome()
        {
            return categoriaDAL.ObterCategoriaOrdenadoPorNome();
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return categoriaDAL.ObterCategoriaPorId(id);
        }
        
        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            return categoriaDAL.EliminarCategoriaPorId(id);
        }
    }
}
