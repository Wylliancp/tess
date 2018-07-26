using modelo.Tabelas;
using persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicos.Tabelas
{
    public class FabricanteServico
    {

        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable ObterFabricanteOrdenadoPorNome()
        {
            return fabricanteDAL.ObterFabricanteOrdenadoPorNome();
        }

        public Fabricante ObterFabricanteProId(long id)
        {
            return fabricanteDAL.ObterFabricantePorId(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante EliminarFabricantePorId(long id)
        {
            return fabricanteDAL.EliminarFabricantePorId(id);
        }
        
    }
}
