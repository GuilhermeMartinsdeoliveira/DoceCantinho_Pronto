using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        // =========================================================
        // LISTAR TODOS
        // =========================================================

        public async Task<IEnumerable<DoceDto>> GetAllAsync()
        {
            var doces = await _doceRepository.GetAllAsync();

            return doces.Select(MapToDto);
        }

        // =========================================================
        // BUSCAR POR ID
        // =========================================================

        public async Task<DoceDto?> GetByIdAsync(int id)
        {
            var doce = await _doceRepository.GetByIdAsync(id);

            return doce == null ? null : MapToDto(doce);
        }

        // =========================================================
        // DOCES EM DESTAQUE
        // =========================================================

        public async Task<IEnumerable<DoceDto>> GetFeaturedAsync()
        {
            var doces = await _doceRepository.GetFeaturedAsync();

            return doces.Select(MapToDto);
        }

        // =========================================================
        // DOCES RECOMENDADOS
        // =========================================================

        public async Task<IEnumerable<DoceDto>> GetRecommendedAsync(int count = 3)
        {
            var doces = await _doceRepository.GetRecommendedAsync(count);

            return doces.Select(MapToDto);
        }

        // =========================================================
        // BUSCAR POR CATEGORIA
        // =========================================================

        public async Task<IEnumerable<DoceDto>> GetByCategoryAsync(int categoryId)
        {
            var doces = await _doceRepository.GetByCategoryAsync(categoryId);

            return doces.Select(MapToDto);
        }

        // =========================================================
        // CRIAR DOCE
        // =========================================================

        public async Task<DoceDto> CreateAsync(CreateDoceDto dto)
        {
            if (dto.CategoryId <= 0)
            {
                throw new ArgumentException(
                    "Categoria inválida.",
                    nameof(dto.CategoryId)
                );
            }

            var doce = new Doce
            {
                Title = dto.Title,
                Description = dto.Description,
                CoverImageUrl = dto.CoverImageUrl,

                Preco = dto.Preco,

                QuantidadeEstoque = dto.QuantidadeEstoque,

                IsAtivo = dto.IsAtivo,

                CategoryId = dto.CategoryId,

                IsFeatured = dto.IsFeatured,

                IsRecomendado = dto.IsRecomendado,

                CreatedAt = DateTime.Now
            };

            await _doceRepository.AddAsync(doce);

            return MapToDto(doce);
        }

        // =========================================================
        // ATUALIZAR DOCE
        // =========================================================

        public async Task<DoceDto?> UpdateAsync(int id, UpdateDoceDto dto)
        {
            var doce = await _doceRepository.GetByIdAsync(id);

            if (doce == null)
                return null;

            doce.Title = dto.Title;
            doce.Description = dto.Description;
            doce.CoverImageUrl = dto.CoverImageUrl;

            doce.Preco = dto.Preco;

            doce.QuantidadeEstoque = dto.QuantidadeEstoque;

            doce.IsAtivo = dto.IsAtivo;

            doce.CategoryId = dto.CategoryId;

            doce.IsFeatured = dto.IsFeatured;

            doce.IsRecomendado = dto.IsRecomendado;

            await _doceRepository.UpdateAsync(doce);

            return MapToDto(doce);
        }

        // =========================================================
        // EXCLUIR
        // =========================================================

        public async Task<bool> DeleteAsync(int id)
        {
            var doce = await _doceRepository.GetByIdAsync(id);

            if (doce == null)
                return false;

            await _doceRepository.DeleteAsync(id);

            return true;
        }

        // =========================================================
        // CONTAR
        // =========================================================

        public async Task<int> CountAsync()
        {
            return await _doceRepository.CountAsync();
        }

        // =========================================================
        // CONVERTER ENTITY → DTO
        // =========================================================

        private static DoceDto MapToDto(Doce doce)
        {
            return new DoceDto
            {
                Id = doce.Id,

                Title = doce.Title,

                Description = doce.Description,

                CoverImageUrl = doce.CoverImageUrl,

                Preco = doce.Preco,

                // NOVOS CAMPOS
                QuantidadeEstoque = doce.QuantidadeEstoque,

                IsAtivo = doce.IsAtivo,

                CategoryId = doce.CategoryId,

                CategoryName = doce.Category?.Name ?? string.Empty,

                IsFeatured = doce.IsFeatured,

                IsRecomendado = doce.IsRecomendado,

                CreatedAt = doce.CreatedAt
            };
        }
    }
    }
