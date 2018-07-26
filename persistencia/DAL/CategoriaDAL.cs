using modelo.Tabelas;
using persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistencia.DAL
{
    public class CategoriaDAL
    {

        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriaOrdenadoPorNome()
        {
            var categoria = context.Categorias.OrderBy(x => x.Nome);
            return categoria;
        }

        public Categoria ObterCategoriaPorId(long? id)
        {
            var categoria = context.Categorias.Where(x => x.CategoriaId == id).First();
            return categoria;
        }

        public void GravarCategoria(Categoria categoria)
        {
            if(categoria.CategoriaId.Equals(0) || categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            else
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            var categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
