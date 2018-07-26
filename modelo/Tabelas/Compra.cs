using System;

namespace modelo.Tabelas
{
    public class Compra
    {
        public long CompraId { get; set; }
        public DateTime DataCompra { get; set; }
        public long ProdutoId { get; set; }
        public long PessoaId { get; set; }
        public Produto Produto { get; set; }
        public Pessoa Pessoa { get; set; }
    }
    
}