using API.Data;
using API.Domain.DTOs;
using API.Domain.ModelsView;

namespace API.Services.Validations;

public class ArticleValidation
{
    private readonly ApplicationContext _context;

    public ArticleValidation(ApplicationContext context)
    {
        _context = context;
    }

    public ValidationErrorModelView ValidationArticle(ArticleDTO articleDTO)
    {
        var validation = new ValidationErrorModelView
        {
            Messages = []
        };

        if (_context.Articles.Any(a => a.Category != articleDTO.Category))
            validation.Messages.Add("Invalid category.");

        if (_context.Articles.Any(i => i.AuthorId != articleDTO.AuthorID))
            validation.Messages.Add("Author ID not found, verify your id in your perfil."); 

        return validation;
    }
}