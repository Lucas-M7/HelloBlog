using API.Domain.DTOs;
using API.Domain.Models;

namespace API.Interfaces.IArticles;

public interface IArticlesService
{
    void CreateArticle(ArticleDTO articleDTO);
    void RemoveArticle(int id);
    List<ArticleModel> ListArticles(int? page);
    ArticleModel FindArticleById(int id);
}