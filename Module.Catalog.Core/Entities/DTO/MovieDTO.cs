namespace Module.Catalog.Core.Entities.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Synopsis { get; set; }
        public string Director { get; set; }
        public ICollection<string> Actors { get; set; }
        public ICollection<string> Genres { get; set; }
    }
}
