using modelo.Tabelas;
using persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicos.Tabelas
{
    public class CompraServico
    {

        private CompraDAL compraDAL = new CompraDAL();

        public IQueryable ObterCompraOrdenadoPorData()
        {
            return compraDAL.ObterCompraOrdenadoPorData();
        }

        public Compra ObterCompraPorId(long id)
        {
            return compraDAL.ObterCompraPorId(id);
        }

        public void GravarCompra(Compra compra)
        {
            compraDAL.GravarCompra(compra);
        }

        public Compra EliminarCompraPorId(long id)
        {
            return compraDAL.EliminarCompraPorId(id);
        }
    }
}
