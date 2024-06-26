using API.Domain.Models;

namespace API.Domain.DTOs;

public class ArticleDTO
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Category { get; set; } = default!;
    public int AuthorID { get; set; } = default!;
}