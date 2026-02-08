using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicLibraryMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public DateTime? BorrowDate { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int PublishingHouseId { get; set; }
        [ForeignKey("PublishingHouseId")]
        public PublishingHouse PublishingHouse { get; set; }

        public int ? UserId { get; set; }
        [ForeignKey("UserId")]
        public User ? User { get; set; }
    }
}
