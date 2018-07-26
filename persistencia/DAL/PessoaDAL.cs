using modelo.Tabelas;
using persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistencia.DAL
{
    public class PessoaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Pessoa> ObterPessoaOrdenadoPorNome()
        {
            var pessoa = context.Pessoas.OrderBy(x => x.Nome);
            return pessoa;
        }

        public Pessoa ObterPessoaPorId(long id)
        {
            var pessoa = context.Pessoas.Where(x => x.Id == id).First();
            return pessoa;
        }

        public void GravarPessoa(Pessoa pessoa)
        {
            if(pessoa.Id == null || pessoa.Id.Equals(0))
            {
                context.Pessoas.Add(pessoa);
                context.SaveChanges();
            }
            else
            {
                context.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Pessoa EliminarPessoaPorId(long id)
        {
            var pessoa = ObterPessoaPorId(id);
            context.Pessoas.Remove(pessoa);
            context.SaveChanges();
            return pessoa;
        }
    }
}
