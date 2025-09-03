using Articles.Contracts.Articles;

namespace Articles.AppServices.Contexts.Articles.Services;

public interface IArticleService
{
    Task<IReadOnlyCollection<ArticleDto>> GetByFilterAsync(ArticleFilterDto filter);
    Task<ArticleDto> GetByIdAsync(Guid id);
    Task<ArticleDto> CreateAsync(CreateArticleDto article);
    Task<ArticleDto> UpdateAsync(UpdateArticleDto article);
    Task<bool> DeleteAsync(Guid id);
}