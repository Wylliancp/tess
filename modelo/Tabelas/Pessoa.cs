using System.Collections.Generic;

namespace modelo.Tabelas
{
    public class Pessoa
    {

        public long Id { get; set; }
        public string Nome { get; set; }

        public string sobrenome { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
    }
}