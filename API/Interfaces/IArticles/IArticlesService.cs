using API.Domain.DTOs;
using API.Domain.Models;

namespace API.Interfaces.IArticles;

public interface IArticlesService
{
    ArticleModel CreateArticle(ArticleModel articleModel);
    void RemoveArticle(int id);
    List<ArticleModel> ListArticles(int? page);
    ArticleModel FindArticleByTitle(string title);
}