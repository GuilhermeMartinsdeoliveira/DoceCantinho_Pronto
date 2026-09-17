//// =============================================================================
//// SenacGames.Application - CategoryService
//// =============================================================================
//// Implementação do serviço de categorias.
//// Segue o mesmo padrão do GameService.
//// =============================================================================

//using DoceCantinho.Application.DTOs;
//using DoceCantinho.Application.Interfaces;
//using DoceCantinho.Domain.Entities;
//using DoceCantinho.Domain.Interfaces;


//namespace DoceCantinho.Application.Services
//{
//    /// <summary>
//    /// Serviço de Categorias — lógica de aplicação para operações com categorias.
//    /// </summary>
//    public class CategoryService : ICategoryService
//    {
//        private readonly ICategoryRepository _categoryRepository;

//        public CategoryService(ICategoryRepository categoryRepository)
//        {
//            _categoryRepository = categoryRepository;
//        }

//        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
//        {
//            var categories = await _categoryRepository.GetAllAsync();
//            return categories.Select(MapToDto);
//        }

//        public async Task<CategoryDto?> GetByIdAsync(int id)
//        {
//            var category = await _categoryRepository.GetByIdAsync(id);
//            return category == null ? null : MapToDto(category);
//        }

//        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
//        {
//            var category = new Category { Name = dto.Name };
//            await _categoryRepository.AddAsync(category);
//            return MapToDto(category);
//        }

//        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto)
//        {
//            var category = await _categoryRepository.GetByIdAsync(id);
//            if (category == null) return null;

//            category.Name = dto.Name;
//            await _categoryRepository.UpdateAsync(category);
//            return MapToDto(category);
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var category = await _categoryRepository.GetByIdAsync(id);
//            if (category == null) return false;

//            await _categoryRepository.DeleteAsync(id);
//            return true;
//        }

//        public async Task<int> CountAsync()
//        {
//            return await _categoryRepository.CountAsync();
//        }

//        /// <summary>
//        /// Mapeia uma entidade Category para CategoryDto.
//        /// </summary>
//        private static CategoryDto MapToDto(Category category)
//        {
//            return new CategoryDto
//            {
//                Id = category.Id,
//                Name = category.Name,
//                DoceCount = category.Doces?.Count ?? 0
//            };
//        }
//    }
//}

using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DoceCantinho.Application.Services
{
    /// <summary>
    /// Serviço de Categorias — lógica de aplicação para operações com categorias.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(MapToDto);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category == null ? null : MapToDto(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = new Category { Name = dto.Name };
            await _categoryRepository.AddAsync(category);
            return MapToDto(category);
        }

        public async Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;

            category.Name = dto.Name;
            await _categoryRepository.UpdateAsync(category);
            return MapToDto(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            // Se houver doces associados, não permite exclusão (evita FK constraint)
            if (category.Doces != null && category.Doces.Any())
                return false;

            await _categoryRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _categoryRepository.CountAsync();
        }

        /// <summary>
        /// Mapeia uma entidade Category para CategoryDto.
        /// </summary>
        private static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                DoceCount = category.Doces?.Count ?? 0
            };
        }
    }
}
