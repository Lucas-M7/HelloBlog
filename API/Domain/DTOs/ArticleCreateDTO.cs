namespace API.Domain.DTOs;

public class ArticleCreateDTO
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int AuthorID { get; set; } = default!;
    public string Status { get; set; } = default!;
    public List<int> CategoryIDs { get; set; } = default!;
}