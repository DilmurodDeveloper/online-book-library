namespace OnlineBookLibrary.Server.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime PublishedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
