using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService service, ILogger<CategoriesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as categorias
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            try
            {
                var categories = await _service.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter categorias: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Obtém uma categoria por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            try
            {
                var category = await _service.GetByIdAsync(id);
                if (category == null)
                    return NotFound(new { message = $"Categoria com ID {id} não encontrada" });

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter categoria {id}: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        /// <summary>
        /// Cria uma nova categoria (Requer autenticação)
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var category = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar categoria: {ex.Message}");
                return StatusCode(500, "Erro ao criar categoria");
            }
        }

        /// <summary>
        /// Atualiza uma categoria existente (Requer autenticação)
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
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
                return NotFound(new { message = $"Categoria com ID {id} não encontrada" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar categoria {id}: {ex.Message}");
                return StatusCode(500, "Erro ao atualizar categoria");
            }
        }

        /// <summary>
        /// Deleta uma categoria (Requer autenticação)
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
                return NotFound(new { message = $"Categoria com ID {id} não encontrada" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar categoria {id}: {ex.Message}");
                return StatusCode(500, "Erro ao deletar categoria");
            }
        }
    }
}