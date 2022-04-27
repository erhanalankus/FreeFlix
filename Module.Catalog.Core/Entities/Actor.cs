using System.Text.Json.Serialization;

namespace Module.Catalog.Core.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }
    }
}
