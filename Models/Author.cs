using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicLibraryMVC.Models
{
    public class Author
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Names { get; set; } = string.Empty;

        [Required]
        public string Surnames { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set;  } = new List<Book>();
    }
}
