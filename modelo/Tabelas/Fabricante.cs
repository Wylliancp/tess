using System.Collections.Generic;

namespace modelo.Tabelas
{
    public class Fabricante
    {
        public long FabricanteID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}