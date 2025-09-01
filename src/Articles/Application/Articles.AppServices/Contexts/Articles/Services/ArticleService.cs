using Articles.Contracts.Articles;

namespace Articles.AppServices.Contexts.Articles.Services;

public class ArticleService : IArticleService
{
    public Task<IReadOnlyCollection<ArticleDto>> GetByFilterAsync(ArticleFilterDto filter)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDto> CreateAsync(CreateArticleDto article)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDto> UpdateAsync(ArticleDto article)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}