using System.Text.Json.Serialization;

namespace Module.Catalog.Core.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<Movie> Movies { get; set; }
}
