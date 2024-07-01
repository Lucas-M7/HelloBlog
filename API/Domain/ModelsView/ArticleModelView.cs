namespace API.Domain.ModelsView;

public class ArticleModelView
{
    public int ArticleID { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Category { get; set; } = default!;
    public DateTime DatePublished { get; set; }
    public int AuthorID { get; set; } = default!;
}