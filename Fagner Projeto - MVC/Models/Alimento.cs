using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fagner_Projeto___MVC.Models
{
    [Table("alimentos")]
    public class Alimento
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Obrigatório informar o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar as Calorias")]
        public string Calorias { get; set; }


    }
}
