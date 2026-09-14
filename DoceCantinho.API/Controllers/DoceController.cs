using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoceController : ControllerBase
    {
        private readonly IDoceService _service;
        private readonly ILogger<DoceController> _logger;

        public DoceController(
            IDoceService service,
            ILogger<DoceController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ============================================================
        // GET: api/doce
        // Obtém todos os doces
        // ============================================================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoceDto>>> GetAll()
        {
            try
            {
                var doces = await _service.GetAllAsync();

                return Ok(doces);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao obter doces.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro interno do servidor.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // GET: api/doce/{id}
        // Obtém um doce pelo ID
        // ============================================================

        [HttpGet("{id}")]
        public async Task<ActionResult<DoceDto>> GetById(int id)
        {
            try
            {
                var doce = await _service.GetByIdAsync(id);

                if (doce == null)
                {
                    return NotFound(
                        new
                        {
                            message =
                                $"Doce com ID {id} não encontrado."
                        });
                }

                return Ok(doce);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao obter doce {Id}.",
                    id);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro interno do servidor.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // GET: api/doce/featured/list
        // Obtém doces em destaque
        // ============================================================

        [HttpGet("featured/list")]
        public async Task<ActionResult<IEnumerable<DoceDto>>> GetFeatured()
        {
            try
            {
                var doces = await _service.GetFeaturedAsync();

                return Ok(doces);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao obter doces em destaque.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro interno do servidor.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // GET: api/doce/category/{categoryId}
        // Obtém doces por categoria
        // ============================================================

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<DoceDto>>> GetByCategory(
            int categoryId)
        {
            try
            {
                var doces =
                    await _service.GetByCategoryAsync(categoryId);

                return Ok(doces);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao obter doces da categoria {CategoryId}.",
                    categoryId);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro interno do servidor.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // POST: api/doce
        // Cria um novo doce
        // ============================================================

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DoceDto>> Create(
            [FromBody] CreateDoceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // ----------------------------------------------------
                // Validação básica do DTO
                // ----------------------------------------------------

                if (dto == null)
                {
                    return BadRequest(
                        new
                        {
                            message = "Os dados do doce são obrigatórios."
                        });
                }

                // ----------------------------------------------------
                // Cria o doce através do Service
                // ----------------------------------------------------

                var doce =
                    await _service.CreateAsync(dto);

                // ----------------------------------------------------
                // Retorna 201 Created
                // ----------------------------------------------------

                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        id = doce.Id
                    },
                    doce);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Dados inválidos ao criar doce.");

                return BadRequest(
                    new
                    {
                        message = ex.Message
                    });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Categoria não encontrada ao criar doce.");

                return NotFound(
                    new
                    {
                        message = ex.Message
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao criar doce.");

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro ao criar doce.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // PUT: api/doce/{id}
        // Atualiza um doce existente
        // ============================================================

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateDoceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (dto == null)
                {
                    return BadRequest(
                        new
                        {
                            message = "Os dados do doce são obrigatórios."
                        });
                }

                await _service.UpdateAsync(id, dto);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(
                    new
                    {
                        message =
                            $"Doce com ID {id} não encontrado."
                    });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Dados inválidos ao atualizar doce {Id}.",
                    id);

                return BadRequest(
                    new
                    {
                        message = ex.Message
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao atualizar doce {Id}.",
                    id);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro ao atualizar doce.",
                        detail = ex.Message
                    });
            }
        }

        // ============================================================
        // DELETE: api/doce/{id}
        // Deleta um doce
        // ============================================================

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(
                    new
                    {
                        message =
                            $"Doce com ID {id} não encontrado."
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao deletar doce {Id}.",
                    id);

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "Erro ao deletar doce.",
                        detail = ex.Message
                    });
            }
        }
    }
}