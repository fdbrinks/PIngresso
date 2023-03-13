namespace PIngresso.Input
{
    public class SessionUpdateInputModel
    {
        public Guid Id { get; set; }
        public string? Date { get; set; }
        public string? Hour { get; set; }
        public string? Dub { get; set; }
        public string? D3 { get; set; }
        public Guid MovieId { get; set; }
        public Guid RoomId { get; set; }
    }
}