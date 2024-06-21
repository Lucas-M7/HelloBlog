using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class ArticleCategoryModel
{
    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }

    public ArticleModel Article { get; set; } = default!;

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public CategoryModel Category { get; set; } = default!;
}