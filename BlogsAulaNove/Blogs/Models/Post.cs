using System.ComponentModel.DataAnnotations;

namespace Blogs.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Texto { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public string? ImagemUrl { get; set; }
    }
}
