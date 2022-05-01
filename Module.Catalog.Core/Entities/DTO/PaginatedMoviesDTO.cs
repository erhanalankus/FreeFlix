namespace Module.Catalog.Core.Entities.DTO
{
    public class PaginatedMoviesDTO
    {
        public IEnumerable<MovieDTO> Movies { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
