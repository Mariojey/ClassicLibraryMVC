using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicLibraryMVC.Models
{
    public class Book
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public DateTime? BorrowDate { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public required Author Author { get; set; }

        [Required]
        public int PublishingHouseId { get; set; }
        [ForeignKey("PublishingHouseId")]
        public required PublishingHouse PublishingHouse { get; set; }

        public int ? UserId { get; set; }
        [ForeignKey("UserId")]
        public User ? User { get; set; }
    }
}
