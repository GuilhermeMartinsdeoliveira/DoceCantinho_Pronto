using DoceCantinho.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.Application.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DoceDto> FeaturedDoce { get; set; } = new List<DoceDto>();
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public IEnumerable<DoceDto> RecentDoce { get; set; } = new List<DoceDto>();
    }

    public class DoceDetailsViewModel
    {
        public DoceDto Doce { get; set; } = new DoceDto();
        public IEnumerable<DoceDto> RelatedDoce { get; set; } = new List<DoceDto>();
    }

    public class DashboardViewModel
    {
        public int TotalDoces { get; set; }
        public int TotalCategories { get; set; }
        public int FeaturedDoces { get; set; }
        public IEnumerable<DoceDto> RecentDoces { get; set; } = new List<DoceDto>();
        // Categories para serem exibidas nos partials do admin
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }

    public class DoceFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma categoria válida.")]
        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsRecomendado { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public double Preco { get; set; }
    }

    /// <summary>
    /// ViewModel para a lista de games com filtro por categoria.
    /// </summary>
    public class DoceListViewModel
    {
        public IEnumerable<DoceDto> Doces { get; set; } = new List<DoceDto>();
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public double Preco { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}
