using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace modelo.Tabelas
{
    public class Pessoa
    {

        [DisplayName("Id")]
        public long Id { get; set; }

        [StringLength(40, ErrorMessage = "Minimo permitido de 3 caracteres para o nome da pessoa e maximo 40", MinimumLength = 3 )]
        [Required(ErrorMessage = "Preencha o nome da Pessoa")]
        public string Nome { get; set; }

        [StringLength(50,ErrorMessage = "Minimo permitido de 3 caracteres para o sobrenome da categoria e maximo 40", MinimumLength = 3)]
        [Required(ErrorMessage = "Preencha o sobrenome")]
        public string sobrenome { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
    }
}