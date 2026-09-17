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

        public DoceController(IDoceService service, ILogger<DoceController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os doces
        /// </summary>
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
                _logger.LogError($"Erro ao obter doces: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Obtém um doce por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<DoceDto>> GetById(int id)
        {
            try
            {
                var doce = await _service.GetByIdAsync(id);
                if (doce == null)
                    return NotFound(new { message = $"Doce com ID {id} não encontrado" });

                return Ok(doce);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter doce {id}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Obtém doces em destaque
        /// </summary>
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
                _logger.LogError($"Erro ao obter doces em destaque: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Obtém doces por categoria
        /// </summary>
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<DoceDto>>> GetByCategory(int categoryId)
        {
            try
            {
                var doces = await _service.GetByCategoryAsync(categoryId);
                return Ok(doces);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter doces da categoria {categoryId}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria um novo doce (Requer autenticação)
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DoceDto>> Create([FromBody] CreateDoceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var doce = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = doce.Id }, doce);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar doce: {ex.Message}");
                return StatusCode(500, "Erro ao criar doce");
            }
        }

        /// <summary>
        /// Atualiza um doce existente (Requer autenticação)
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDoceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Doce com ID {id} não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar doce {id}: {ex.Message}");
                return StatusCode(500, "Erro ao atualizar doce");
            }
        }

        /// <summary>
        /// Deleta um doce (Requer autenticação)
        /// </summary>
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
                return NotFound(new { message = $"Doce com ID {id} não encontrado" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar doce {id}: {ex.Message}");
                return StatusCode(500, "Erro ao deletar doce");
            }
        }
    }
}