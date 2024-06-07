using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fagner_Projeto___MVC.Models
{
    [Table("Exercicios")]
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Obrigatório informar o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Grupo Muscular!")]
        public String GrupoMuscular { get; set; }
    }
}
