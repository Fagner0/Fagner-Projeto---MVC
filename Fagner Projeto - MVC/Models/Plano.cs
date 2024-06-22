using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fagner_Projeto___MVC.Models
{
    [Table("Planos")]
    public class Plano
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório o Alimento!")]
        [Display(Name = "Alimento")]
        public int AlimentoId { get; set; }

        [ForeignKey("AlimentoId")]
        public Alimento alimento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Refeição!")]
        public string Refeição { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Hora!")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Porçao")]
        public int Porção { get; set; }

    }
}