namespace PIngresso.Input
{
    public class MovieUpdateInputModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Age { get; set; }
        public int Lenght { get; set; }
        public string? Genre { get; set; }
        public string? ImageUrl { get; set; }
    }
}