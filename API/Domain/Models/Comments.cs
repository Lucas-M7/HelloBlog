using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class Comments
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommentId { get; set; } = default!;

    public int UserId { get; set; }

    [ForeignKey(nameof(Article))]
    public int ArticleId { get; set; }

    public ArticleModel Article { get; set; } = default!;

    [StringLength(255)]
    public string Content { get; set; } = default!;
}