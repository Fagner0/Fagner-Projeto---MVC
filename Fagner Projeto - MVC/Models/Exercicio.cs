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
        
        [Display(Name = "Grupo Muscular")]
        public GrupoMuscular Tipo { get; set; }

        public ICollection<FichaDeTreino> Fichas { get; set; }

    }
        public enum GrupoMuscular
    {
        Peito,
        Tríceps,
        Bíceps,
        Dorsal,
        AnteBraço,
        Ombro,
        Trapézio,
        Abdômen,
        Panturrilha,
        Glúteo,
        Quadríceps,
        Posterior,
    }
}
