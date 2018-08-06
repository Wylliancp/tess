using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace modelo.Tabelas
{
    public class Compra
    {
        [DisplayName("Id")]
        public long CompraId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data Cadastro")]
        [Required(ErrorMessage = "Informe a data de Cadastro")]
        public DateTime DataCompra { get; set; }

        [DisplayName("Produto")]
        public long ProdutoId { get; set; }
        [DisplayName("Pessoa")]
        public long PessoaId { get; set; }

        public Produto Produto { get; set; }
        public Pessoa Pessoa { get; set; }
    }
    
}