using API.Data;
using API.Domain.DTOs;
using API.Domain.Models;
using API.Domain.ModelsView;
using API.Interfaces.IArticles;
using API.Services.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Articles;

[Authorize]
[ApiController]
[Route("api/")]
public class ArticlesController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IArticlesService _service;

    public ArticlesController(ApplicationContext context, IArticlesService service)
    {
        _context = context;
        _service = service;
    }

    [HttpPost("articles")]
    public IActionResult CreateArticle([FromBody] ArticleDTO articleDTO)
    {
        var validArticle = new ArticleValidation(_context);
        var validation = validArticle.ValidationArticle(articleDTO);

        if (validation.Messages.Count > 0)
            return BadRequest(validation);

        var article = new ArticleModel
        {
            Title = articleDTO.Title,
            Content = articleDTO.Content,
            Category = articleDTO.Category,
            AuthorId = articleDTO.AuthorID,
            DateRelease = DateTime.Today
        };

        _service.CreateArticle(article);

        return Created($"/article/{article.ArticleId}", new ArticleModelView
        {
            ArticleID = article.ArticleId,
            Title = article.Title,
            Content = article.Content,
            Category = article.Category,
            DatePublished = article.DateRelease,
            AuthorID = article.AuthorId
        });
    }
}