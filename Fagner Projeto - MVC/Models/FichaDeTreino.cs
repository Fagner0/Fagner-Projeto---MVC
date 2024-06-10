using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fagner_Projeto___MVC.Models
{
    [Table("Fichas")]
    public class FichaDeTreino
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório o Exercício!")]
        [Display(Name = "Exercício")]
        public int ExercicioId { get; set; }

        [ForeignKey("ExercicioId")]
        public Exercicio Exercicio { get; set; }

        [Required(ErrorMessage ="Obrigatório informar número de repetições!")]
        public int Repetiçoes { get; set; }

        [Required(ErrorMessage = "Obrigatório informar número de número de séries!")]
        [Display(Name ="Número de Séries")]
        public int NumeroSerie { get; set; }

        [Required(ErrorMessage = "Obrigatório informar número de tempo de descanso!")]
        [Display(Name = "Tempo de Descanso")]
        public int TempoDescanso { get; set; }
    }


   
}
