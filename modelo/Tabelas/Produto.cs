using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace modelo.Tabelas
{
    public class Produto
    {
        [DisplayName("Id")]
        public long ProdutoId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Produto")]
        [StringLength(40,ErrorMessage = "Minimo permitido de 3 caracteres para o produto e maximo 40", MinimumLength = 3)]
        public string Nome { get; set; }

        [Range(0,50, ErrorMessage = "Maximo permitido utrapassado")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe a data de cadastro")]
        //[DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Categoria")]
        public long CategoriaId { get; set; }
        [DisplayName("Fabricante")]
        public long FabricanteId { get; set; }
        
        
        public Categoria Categorias { get; set; }
        public Fabricante Fabricantes { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }

    }
}