//using DoceCantinho.Application.Interfaces;
//using DoceCantinho.Domain.Interfaces;
//using DoceCantinho.Application.DTOs;
//using DoceCantinho.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DoceCantinho.Application.Services
//{

//    public class DoceService : IDoceService
//    {
//        private readonly IDoceRepository _doceRepository;

//        public DoceService(IDoceRepository doceRepository)
//        {
//            _doceRepository = doceRepository;
//        }

//        public async Task<IEnumerable<DoceDto>> GetAllAsync()
//        {
//            var doce = await _doceRepository.GetAllAsync();
//            return doce.Select(MapToDto);
//        }

//        public async Task<DoceDto?> GetByIdAsync(int id)
//        {
//            var doces = await _doceRepository.GetByIdAsync(id);
//            return doces == null ? null : MapToDto(doces);
//        }

//        public async Task<IEnumerable<DoceDto>> GetFeaturedAsync()
//        {
//            var doces = await _doceRepository.GetFeaturedAsync();
//            return doces.Select(MapToDto);
//        }

//        public async Task<IEnumerable<DoceDto>> GetByCategoryAsync(int categoryId)
//        {
//            var doces = await _doceRepository.GetByCategoryAsync(categoryId);
//            return doces.Select(MapToDto);
//        }

//        public async Task<DoceDto> CreateAsync(CreateDoceDto dto)
//        {
//            // Validação básica do CategoryId antes de persistir
//            if (dto.CategoryId <= 0)
//                throw new ArgumentException("CategoryId inválido.", nameof(dto.CategoryId));

//            // Opcional: verificar se a categoria existe (se houver repositório disponível)
//            // Aqui preferimos falhar rápido e retornar erro claro ao usuário.

//            var doces = new Doce
//            {
//                Title = dto.Title,
//                Description = dto.Description,
//                CoverImageUrl = dto.CoverImageUrl,
//                CategoryId = dto.CategoryId,
//                IsFeatured = dto.IsFeatured,
//                CreatedAt = DateTime.Now
//            };

//            await _doceRepository.AddAsync(doces);

//            //Retorna o game criado como DTO
//            return MapToDto(doces);
//        }

//        public async Task<DoceDto?> UpdateAsync(int id, UpdateDoceDto dto)
//        {
//            var doce = await _doceRepository.GetByIdAsync(id);
//            if (doce == null) return null;

//            doce.Title = dto.Title;
//            doce.Description = dto.Description;
//            doce.CoverImageUrl = dto.CoverImageUrl;
//            doce.CategoryId = dto.CategoryId;
//            doce.IsFeatured = dto.IsFeatured;

//            await _doceRepository.UpdateAsync(doce);
//            return MapToDto(doce);

//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            var doce = await _doceRepository.GetByIdAsync(id);
//            if (doce == null)
//            {
//                return false;
//            }

//            await _doceRepository.DeleteAsync(id);
//            return true;
//        }

//        public async Task<int> CountAsync()
//        {
//            return await _doceRepository.CountAsync();
//        }

//        private static DoceDto MapToDto(Doce doce)
//        {
//            return new DoceDto
//            {
//                Id = doce.Id,
//                Title = doce.Title,
//                Description = doce.Description,
//                CoverImageUrl = doce.CoverImageUrl,
//                CategoryId = doce.CategoryId,
//                CategoryName = doce.Category?.Name ?? string.Empty,
//                IsFeatured = doce.IsFeatured,
//                CreatedAt = doce.CreatedAt,
//                Preco = doce.Preco
//            };

//        }



//    }
//}

using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Application.DTOs;
using DoceCantinho.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DoceCantinho.Application.Services
{

    public class DoceService : IDoceService
    {
        private readonly IDoceRepository _doceRepository;

        public DoceService(IDoceRepository doceRepository)
        {
            _doceRepository = doceRepository;
        }

        public async Task<IEnumerable<DoceDto>> GetAllAsync()
        {
            var doce = await _doceRepository.GetAllAsync();
            return doce.Select(MapToDto);
        }

        public async Task<DoceDto?> GetByIdAsync(int id)
        {
            var doces = await _doceRepository.GetByIdAsync(id);
            return doces == null ? null : MapToDto(doces);
        }

        public async Task<IEnumerable<DoceDto>> GetFeaturedAsync()
        {
            var doces = await _doceRepository.GetFeaturedAsync();
            return doces.Select(MapToDto);
        }

        public async Task<IEnumerable<DoceDto>> GetRecommendedAsync(int count = 3)
        {
            var doces = await _doceRepository.GetRecommendedAsync(count);
            return doces.Select(MapToDto);
        }

        public async Task<IEnumerable<DoceDto>> GetByCategoryAsync(int categoryId)
        {
            var doces = await _doceRepository.GetByCategoryAsync(categoryId);
            return doces.Select(MapToDto);
        }

        public async Task<DoceDto> CreateAsync(CreateDoceDto dto)
        {
            // Validação básica do CategoryId antes de persistir
            if (dto.CategoryId <= 0)
                throw new ArgumentException("CategoryId inválido.", nameof(dto.CategoryId));

            var doces = new Doce
            {
                Title = dto.Title,
                Description = dto.Description,
                CoverImageUrl = dto.CoverImageUrl,
                CategoryId = dto.CategoryId,
                IsFeatured = dto.IsFeatured,
                IsRecomendado = dto.IsRecomendado,
                CreatedAt = DateTime.Now,
                Preco = dto.Preco // <-- atribuição do preço recebida no DTO
            };

            await _doceRepository.AddAsync(doces);

            //Retorna o game criado como DTO
            return MapToDto(doces);
        }

        public async Task<DoceDto?> UpdateAsync(int id, UpdateDoceDto dto)
        {
            var doce = await _doceRepository.GetByIdAsync(id);
            if (doce == null) return null;

            doce.Title = dto.Title;
            doce.Description = dto.Description;
            doce.CoverImageUrl = dto.CoverImageUrl;
            doce.CategoryId = dto.CategoryId;
            doce.IsFeatured = dto.IsFeatured;
            doce.IsRecomendado = dto.IsRecomendado;
            doce.Preco = dto.Preco; // <-- atualiza o preço

            await _doceRepository.UpdateAsync(doce);
            return MapToDto(doce);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doce = await _doceRepository.GetByIdAsync(id);
            if (doce == null)
            {
                return false;
            }

            await _doceRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _doceRepository.CountAsync();
        }
        private static DoceDto MapToDto(Doce doce)
        {
            return new DoceDto
            {
                Id = doce.Id,
                Title = doce.Title,
                Description = doce.Description,
                CoverImageUrl = doce.CoverImageUrl,
                CategoryId = doce.CategoryId,
                CategoryName = doce.Category?.Name ?? string.Empty,
                IsFeatured = doce.IsFeatured,
                IsRecomendado = doce.IsRecomendado,
                CreatedAt = doce.CreatedAt,
                Preco = doce.Preco
            };
        }
    }
}
