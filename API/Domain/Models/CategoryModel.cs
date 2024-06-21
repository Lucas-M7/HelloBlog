using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class CategoryModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(150)]
    public string CategoryName { get; set; } = default!;

    public ICollection<ArticleCategoryModel> ArticleCategories { get; set; } = new List<ArticleCategoryModel>();
}