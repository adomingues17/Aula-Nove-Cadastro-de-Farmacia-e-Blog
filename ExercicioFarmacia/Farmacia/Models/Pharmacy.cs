using System.ComponentModel.DataAnnotations;

namespace Farmacia.Models
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome")]
        [MaxLength(30)]
        public string? Nome { get; set; }
        [Required]
        [Display(Name ="Endereço")]
        //[Range(1, 50, ErrorMessage ="Endereço deve possuir no máximo 50 caracteres!")]
        public string? Endereco { get; set; }
        [Required]
        public string? Horario { get; set; }
    }
}
