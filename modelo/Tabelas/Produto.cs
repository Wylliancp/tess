using System.Collections.Generic;

namespace modelo.Tabelas
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public long CategoriaId { get; set; }
        public long FabricanteId { get; set; }
        
        
        public Categoria Categorias { get; set; }
        public Fabricante Fabricantes { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }

    }
}