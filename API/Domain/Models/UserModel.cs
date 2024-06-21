using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = default!;

    [StringLength(255)]
    public string Bio { get; set; } = default!;

    [StringLength(150)]
    public string Email { get; set; } = default!;

    [StringLength(50)]
    public string Password { get; set; } = default!;

    public ICollection<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    public ICollection<Comments> Comments { get; set; } = new List<Comments>();  // Adicione esta linha
}