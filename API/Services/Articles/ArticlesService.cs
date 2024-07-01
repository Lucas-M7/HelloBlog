
using API.Data;
using API.Domain.Models;
using API.Interfaces.IArticles;

namespace API.Services.Articles;

public class ArticlesService : IArticlesService
{
    private readonly ApplicationContext _applicationContext;

    public ArticlesService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public ArticleModel CreateArticle(ArticleModel article)
    {
        _applicationContext.Articles.Add(article);
        _applicationContext.SaveChanges();

        return article;
    }

    public ArticleModel FindArticleByTitle(string title)
    {
        return _applicationContext.Articles.FirstOrDefault(t => t.Title == title)
        ?? throw new FileNotFoundException("Article not found.");
    }

    public List<ArticleModel> ListArticles(int? page)
    {
        var query = _applicationContext.Articles.AsQueryable();

        int itensForPage = 10;

        if (page != null && page > 0)
            query = query.Skip(((int)page - 1) * itensForPage).Take(itensForPage);

        return [.. query];
    }

    public void RemoveArticle(int id)
    {
        var article = FindArticleById(id);
        _applicationContext.Remove(article);
        _applicationContext.SaveChanges();
    }

    private ArticleModel FindArticleById(int id)
    {
        var articleId = _applicationContext.Articles.FirstOrDefault(i => i.ArticleId == id);
        return articleId ?? throw new FileNotFoundException("Article not found");
    }
}