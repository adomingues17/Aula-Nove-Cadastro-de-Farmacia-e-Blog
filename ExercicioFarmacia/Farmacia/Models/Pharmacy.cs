using System.ComponentModel.DataAnnotations;

namespace Farmacia.Models
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Endereco { get; set; }
        [Required]
        public string? Horario { get; set; }
    }
}
