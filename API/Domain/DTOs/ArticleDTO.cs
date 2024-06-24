namespace API.Domain.DTOs;

public class ArticleDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public List<CategoryDTO> Categories { get; set; } = default!;
    public string AuthorID { get; set; } = default!;
    public DateTime PublishedDate { get; set; } = default!;
}