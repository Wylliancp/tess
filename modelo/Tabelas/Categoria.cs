using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace modelo.Tabelas
{
    public class Categoria
    {
        [DisplayName("Id")]
        public long CategoriaId { get; set; }

        [Required( ErrorMessage = "Informe o nome da Categoria")]
        [StringLength(40, ErrorMessage = "Minimo permitido de 2 caracteres para o nome da categoria e maximo 40", MinimumLength = 2)]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}