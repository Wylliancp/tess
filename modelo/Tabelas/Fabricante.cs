using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace modelo.Tabelas
{
    public class Fabricante
    {
        [DisplayName("Id")]
        public long FabricanteID { get; set; }
        
        [StringLength(40, ErrorMessage = "Minimo permitido de 3 caracteres para o fabricante e maximo 40", MinimumLength = 3)]
        [Required(ErrorMessage = "Preencha o nome do fabricante")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}