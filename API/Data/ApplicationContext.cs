using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{

    public DbSet<ArticleModel> Articles { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ArticleCategoryModel> ArticleCategories { get; set; }
    public DbSet<UserModel> Users { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}