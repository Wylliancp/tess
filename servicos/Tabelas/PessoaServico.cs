using modelo.Tabelas;
using persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servicos.Tabelas
{
    public class PessoaServico
    {

        private PessoaDAL pessoaDAL = new PessoaDAL();

        public IQueryable ObterPessoaOrdenadoPorNome()
        {
            return pessoaDAL.ObterPessoaOrdenadoPorNome();
        }

        public Pessoa ObterPessoaPorId(long id)
        {
            return pessoaDAL.ObterPessoaPorId(id);
        }

        public void GravarPessoa(Pessoa pessoa)
        {
            pessoaDAL.GravarPessoa(pessoa);
        }

        public Pessoa EliminarPessoaPorId(long id)
        {
            return pessoaDAL.EliminarPessoaPorId(id);
        }
    }
}
