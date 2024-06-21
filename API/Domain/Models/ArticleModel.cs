using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class ArticleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ArticleId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = default!;

    [StringLength(150)]
    public string Category { get; set; } = default!;

    [StringLength(255)]
    public string Content { get; set; } = default!;

    [DataType(DataType.Date)]
    public DateTime DateRelease { get; set; }

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public UserModel Author { get; set; } = default!;

    public ICollection<ArticleCategoryModel> ArticleCategories { get; set; } = new List<ArticleCategoryModel>();
}