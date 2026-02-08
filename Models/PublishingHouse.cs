namespace ClassicLibraryMVC.Models
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Book> Books { get; set; }
    }
}
