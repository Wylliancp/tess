using modelo.Tabelas;
using persistencia.Context;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistencia.DAL
{
    public class CompraDAL
    {

        private EFContext context = new EFContext();

        public IQueryable<Compra> ObterCompraOrdenadoPorData()
        {
            var compra = context.Compras.Include(p => p.Pessoa)
                                        .Include(p => p.Produto)
                                        .OrderBy(x => x.DataCompra);
            return compra;
        }

        public Compra ObterCompraPorId(long id)
        {
            var compra = context.Compras.Where(x => x.CompraId == id)
                                        .Include(p => p.Pessoa)
                                        .Include(p => p.Produto)
                                        .FirstOrDefault();
            return compra;
        }

        public void GravarCompra(Compra compra)
        {
            if(compra.CompraId == null || compra.CompraId.Equals(0))
            {
                context.Compras.Add(compra);
                context.SaveChanges();
            }
            else
            {
                context.Entry(compra).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Compra EliminarCompraPorId(long id)
        {
            var compra = ObterCompraPorId(id);
            context.Compras.Remove(compra);
            context.SaveChanges();
            return compra;
        }
    }
}
