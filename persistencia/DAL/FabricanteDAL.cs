using modelo.Tabelas;
using persistencia.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistencia.DAL
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> ObterFabricanteOrdenadoPorNome()
        {
            var fabricante = context.Fabricantes.OrderBy(x => x.Nome);
            return fabricante;
        }
        
        public Fabricante ObterFabricantePorId(long id)
        {
            var fabricante = context.Fabricantes.Where(x => x.FabricanteID == id).Include("Produtos.Categorias").First();               
            return fabricante;
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            if(fabricante.FabricanteID == null || fabricante.FabricanteID.Equals(0))
            {
                context.Fabricantes.Add(fabricante);
                context.SaveChanges();
            }
            else
            {
                context.Entry(fabricante).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Fabricante EliminarFabricantePorId(long id)
        {
            var fabricante = ObterFabricantePorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }
    }
}
