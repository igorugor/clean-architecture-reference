using Articles.AppServices.Contexts.Articles.Services;
using Articles.Contracts.Articles;
using Articles.Contracts.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Hosts.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ArticlesController(IArticleService articleService) : ControllerBase
{
    [HttpGet("by-filter")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ArticleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetArticlesByFilter(ArticleFilterDto filter)
    {
        var articles = await articleService.GetByFilterAsync(filter);

        if (articles.Count == 0) return NotFound();

        return Ok(articles);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetArticleById(Guid id)
    {
        var article = await articleService.GetByIdAsync(id);

        if (article == null) return NotFound();

        return Ok(article);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateArticle(CreateArticleDto article)
    {
        if (article == null) return BadRequest();

        var articleDto = await articleService.CreateAsync(article);

        if (articleDto == null) return BadRequest();

        return CreatedAtAction(nameof(GetArticleById), new { id = articleDto.Id }, articleDto);
    }

    [HttpPut("{id:Guid}")]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateArticle(Guid id, UpdateArticleDto article)
    {
        if (article == null) return BadRequest();

        var articleDto = await articleService.UpdateAsync(article);

        if (articleDto == null) return BadRequest();

        return Ok(articleDto);
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        if (id == Guid.Empty) return BadRequest();

        await articleService.DeleteAsync(id);

        return NoContent();
    }
}