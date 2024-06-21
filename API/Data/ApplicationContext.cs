using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{

    public DbSet<ArticleModel> Articles { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ArticleCategoryModel> ArticleCategories { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<Comments> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurando a relação muitos-para-muitos
        modelBuilder.Entity<ArticleCategoryModel>()
            .HasKey(ac => new { ac.ArticleId, ac.CategoryId });

        modelBuilder.Entity<ArticleCategoryModel>()
            .HasOne(ac => ac.Article)
            .WithMany(a => a.ArticleCategories) // Um artigo pode ter muitas categorias
            .HasForeignKey(ac => ac.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ArticleCategoryModel>()
            .HasOne(ac => ac.Category)
            .WithMany(c => c.ArticleCategories)
            .HasForeignKey(ac => ac.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurando a relação um-para-muitos entre UserModel e ArticleModel
        modelBuilder.Entity<ArticleModel>()
            .HasOne(a => a.Author)
            .WithMany(u => u.Articles) // Um usuário pode ter muitos artigos
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configurando a relação um-para-muitos entre Comments e ArticleModel
        modelBuilder.Entity<Comments>()
            .HasOne(c => c.Article)
            .WithMany(a => a.Comments) // Um artigo pode ter muitos comentários
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}