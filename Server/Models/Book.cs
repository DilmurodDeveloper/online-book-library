namespace OnlineBookLibrary.Server.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
