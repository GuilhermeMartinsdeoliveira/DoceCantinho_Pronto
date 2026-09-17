using System;
using System.Collections.Generic;
using System.Text;

//DTO DE CATEGORIA, PARA SER USADO NA HORA DE CADASTRAR UM JOGO, PARA O USUÁRIO SELECIONAR A CATEGORIA DO JOGO

namespace DoceCantinho.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade de doces nesta categoria.
        /// Útil para mostrar no dashboard e na listagem.
        /// </summary>
        public int DoceCount { get; set; }
    }

    /// <summary>
    /// DTO para criação de uma nova categoria
    /// </summary>
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para atualização de uma categoria existente.
    /// </summary>
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
    }
    public class DeleteCategoryDto
    {
        public string Name { get; set; } = string.Empty;
    }


}
