using DoceCantinho.Domain.Entities;
using DoceCantinho.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly DoceCantinhoDbContext _db;
        private readonly ILogger<BlogController> _logger;

        public BlogController(
            DoceCantinhoDbContext db,
            ILogger<BlogController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // ============================================================
        // GET /api/blog
        // LISTAR PUBLICAÇÕES
        // ============================================================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAll()
        {
            try
            {
                var posts =
                    await _db.BlogPosts
                        .AsNoTracking()
                        .OrderByDescending(
                            p => p.PublishedAt)
                        .ToListAsync();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao listar publicações do blog."
                );

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Erro interno ao carregar as publicações."
                    }
                );
            }
        }

        // ============================================================
        // GET /api/blog/{id}
        // BUSCAR PUBLICAÇÃO
        // ============================================================

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BlogPost>> GetById(
            int id)
        {
            try
            {
                var post =
                    await _db.BlogPosts
                        .AsNoTracking()
                        .FirstOrDefaultAsync(
                            p => p.Id == id
                        );

                if (post == null)
                {
                    return NotFound(
                        new
                        {
                            message =
                                $"Publicação com ID {id} não encontrada."
                        }
                    );
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao buscar publicação {Id}.",
                    id
                );

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Erro interno ao buscar a publicação."
                    }
                );
            }
        }

        // ============================================================
        // POST /api/blog
        // CRIAR
        // ADMIN
        // ============================================================

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BlogPost>> Create(
            [FromBody] CreateBlogPostRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                string slug =
                    GerarSlug(dto.Slug, dto.Title);

                bool slugExiste =
                    await _db.BlogPosts.AnyAsync(
                        p => p.Slug == slug
                    );

                if (slugExiste)
                {
                    return BadRequest(
                        new
                        {
                            message =
                                "Já existe uma publicação utilizando este slug."
                        }
                    );
                }

                var post =
                    new BlogPost
                    {
                        Title =
                            dto.Title.Trim(),

                        Slug =
                            slug,

                        Excerpt =
                            dto.Excerpt.Trim(),

                        Content =
                            dto.Content.Trim(),

                        CoverImageUrl =
                            dto.CoverImageUrl?.Trim()
                            ?? string.Empty,

                        Category =
                            dto.Category.Trim(),

                        Tags =
                            dto.Tags?.Trim()
                            ?? string.Empty,

                        AuthorName =
                            dto.AuthorName.Trim(),

                        AuthorRole =
                            dto.AuthorRole?.Trim()
                            ?? string.Empty,

                        AuthorAvatar =
                            dto.AuthorAvatar?.Trim()
                            ?? string.Empty,

                        AuthorBio =
                            dto.AuthorBio?.Trim()
                            ?? string.Empty,

                        PublishedAt =
                            dto.PublishedAt,

                        CreatedAt =
                            DateTime.Now,

                        UpdatedAt =
                            null,

                        IsPublished =
                            dto.IsPublished,

                        Featured =
                            dto.Featured
                    };

                _db.BlogPosts.Add(post);

                await _db.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        id = post.Id
                    },
                    post
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao criar publicação."
                );

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Erro interno ao criar a publicação."
                    }
                );
            }
        }

        // ============================================================
        // PUT /api/blog/{id}
        // EDITAR
        // ADMIN
        // ============================================================

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BlogPost>> Update(
            int id,
            [FromBody] UpdateBlogPostRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var post =
                    await _db.BlogPosts
                        .FirstOrDefaultAsync(
                            p => p.Id == id
                        );

                if (post == null)
                {
                    return NotFound(
                        new
                        {
                            message =
                                $"Publicação com ID {id} não encontrada."
                        }
                    );
                }

                string slug =
                    GerarSlug(dto.Slug, dto.Title);

                bool slugExiste =
                    await _db.BlogPosts.AnyAsync(
                        p =>
                            p.Slug == slug &&
                            p.Id != id
                    );

                if (slugExiste)
                {
                    return BadRequest(
                        new
                        {
                            message =
                                "Já existe outra publicação utilizando este slug."
                        }
                    );
                }

                post.Title =
                    dto.Title.Trim();

                post.Slug =
                    slug;

                post.Excerpt =
                    dto.Excerpt.Trim();

                post.Content =
                    dto.Content.Trim();

                post.CoverImageUrl =
                    dto.CoverImageUrl?.Trim()
                    ?? string.Empty;

                post.Category =
                    dto.Category.Trim();

                post.Tags =
                    dto.Tags?.Trim()
                    ?? string.Empty;

                post.AuthorName =
                    dto.AuthorName.Trim();

                post.AuthorRole =
                    dto.AuthorRole?.Trim()
                    ?? string.Empty;

                post.AuthorAvatar =
                    dto.AuthorAvatar?.Trim()
                    ?? string.Empty;

                post.AuthorBio =
                    dto.AuthorBio?.Trim()
                    ?? string.Empty;

                post.PublishedAt =
                    dto.PublishedAt;

                post.IsPublished =
                    dto.IsPublished;

                post.Featured =
                    dto.Featured;

                post.UpdatedAt =
                    DateTime.Now;

                await _db.SaveChangesAsync();

                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao atualizar publicação {Id}.",
                    id
                );

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Erro interno ao atualizar a publicação."
                    }
                );
            }
        }

        // ============================================================
        // DELETE /api/blog/{id}
        // EXCLUIR
        // ADMIN
        // ============================================================

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(
            int id)
        {
            try
            {
                var post =
                    await _db.BlogPosts
                        .FirstOrDefaultAsync(
                            p => p.Id == id
                        );

                if (post == null)
                {
                    return NotFound(
                        new
                        {
                            message =
                                $"Publicação com ID {id} não encontrada."
                        }
                    );
                }

                _db.BlogPosts.Remove(post);

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao excluir publicação {Id}.",
                    id
                );

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Erro interno ao excluir a publicação."
                    }
                );
            }
        }

        // ============================================================
        // GERAR SLUG
        // ============================================================

        private static string GerarSlug(
            string? slug,
            string titulo)
        {
            string texto =
                string.IsNullOrWhiteSpace(slug)
                    ? titulo
                    : slug;

            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            texto =
                texto
                    .Trim()
                    .ToLowerInvariant()

                    .Replace("á", "a")
                    .Replace("à", "a")
                    .Replace("ã", "a")
                    .Replace("â", "a")

                    .Replace("é", "e")
                    .Replace("ê", "e")

                    .Replace("í", "i")

                    .Replace("ó", "o")
                    .Replace("ô", "o")
                    .Replace("õ", "o")

                    .Replace("ú", "u")
                    .Replace("ü", "u")

                    .Replace("ç", "c");

            var caracteres =
                texto
                    .Select(
                        c =>
                            char.IsLetterOrDigit(c)
                                ? c
                                : '-'
                    )
                    .ToArray();

            string resultado =
                new string(caracteres);

            while (
                resultado.Contains("--"))
            {
                resultado =
                    resultado.Replace(
                        "--",
                        "-"
                    );
            }

            return resultado.Trim('-');
        }
    }

    // ================================================================
    // DTO CREATE
    // ================================================================

    public class CreateBlogPostRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Excerpt { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string AuthorRole { get; set; } = string.Empty;

        public string AuthorAvatar { get; set; } = string.Empty;

        public string AuthorBio { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool Featured { get; set; }
    }

    // ================================================================
    // DTO UPDATE
    // ================================================================

    public class UpdateBlogPostRequest
    {
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Excerpt { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string AuthorRole { get; set; } = string.Empty;

        public string AuthorAvatar { get; set; } = string.Empty;

        public string AuthorBio { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool Featured { get; set; }
    }
}