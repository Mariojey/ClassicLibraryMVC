namespace ClassicLibraryMVC.Models
{
    public class Author
    {

        public int Id { get; set; }
        public string Names { get; set; } = string.Empty;

        public string Surnames { get; set; } = string.Empty;

        public List<Book> Books { get; set; }
    }
}
