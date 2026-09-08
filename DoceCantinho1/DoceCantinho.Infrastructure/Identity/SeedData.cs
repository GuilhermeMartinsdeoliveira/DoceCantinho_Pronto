// =============================================================================
// SenacGames.Infrastructure - Seed Data (Dados Iniciais)
// =============================================================================
// 📌 CONCEITO IMPORTANTE: Seed Data
// Seed Data são dados iniciais que são inseridos no banco de dados
// quando a aplicação é executada pela primeira vez.
// Isso é útil para:
// - Ter dados de demonstração
// - Criar o usuário administrador inicial
// - Popular categorias padrão
//
// Este método é chamado no Program.cs durante a inicialização da aplicação.
// =============================================================================

using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DoceCantinho.Infrastructure.Identity
{
    /// <summary>
    /// Classe responsável por popular o banco de dados com dados iniciais.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Popula o banco de dados com categorias, games e o usuário admin.
        /// Este método é idempotente — pode ser chamado várias vezes sem duplicar dados.
        /// </summary>
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // Obtém o DbContext do container de Dependency Injection
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DoceCantinhoDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Aplica migrations pendentes automaticamente
            await context.Database.MigrateAsync();

            // =====================================================================
            // 1. SEED DE CATEGORIAS
            // =====================================================================
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Bolo Tradicional" },
                    new Category { Name = "Bolo de Pote" },
                    new Category { Name = "Cone" },
                    new Category { Name = "Bombom" },
                    new Category { Name = "Brigadeiro" },
                    new Category { Name = "Bolo de Festa" },
                    new Category { Name = "Combos" },
                    new Category { Name = "Cappuccino" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // =====================================================================
            // 2. SEED DE GAMES
            // =====================================================================
            if (!context.Doces.Any())
            {
                // Busca as categorias recém-criadas para obter os IDs
                var Bolo_Tradicional_G  = await context.Categories.FirstAsync(c => c.Name == "Bolo Tradicional");
                var Bolo_Tradicional_M  = await context.Categories.FirstAsync(c => c.Name == "Bolo Tradicional");
                var Bolo_Tradicional_P  = await context.Categories.FirstAsync(c => c.Name == "Bolo Tradicional");
                var Bolo_Pote = await context.Categories.FirstAsync(c => c.Name == "Bolo de Pote");
                var Cone = await context.Categories.FirstAsync(c => c.Name == "Cone");
                var Bombom = await context.Categories.FirstAsync(c => c.Name == "Bombom");
                var Brigadeiro = await context.Categories.FirstAsync(c => c.Name == "Brigadeiro");
                var Bolo_Festa = await context.Categories.FirstAsync(c => c.Name == "Bolo de Festa");
                var Combos = await context.Categories.FirstAsync(c => c.Name == "Combos");
                var Cappuccino = await context.Categories.FirstAsync(c => c.Name == "Cappuccino");

                var doces = new List<Doce>
                {
                    new Doce
                    {
                        Title = "Bolo de Chocolate G",
                        Description = "Delicioso bolo de chocolate macio e fofinho, preparado com ingredientes selecionados e coberto com uma irresistível cobertura cremosa de chocolate. Perfeito para tornar qualquer momento mais doce e especial.",
                        CoverImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf3fEqbbC__xHPp4vPbvdCyXFzQdMADjN9IcHzcV4jLjR0M_jj6zpuMXJZ&s=10\r\n\r\n",
                        CategoryId = Bolo_Tradicional_G.Id,
                        IsFeatured = true,
                        IsRecomendado = true,
                        CreatedAt = DateTime.Now,
                        Preco = 45.00
                    },
                    new Doce
                    {
                        Title = "Cone de Ferrero Rocher",
                        Description = "Cone Ferrero Rocher recheado com um delicioso creme de chocolate, coberto com uma generosa camada de chocolate ao leite e finalizado com pedaços do famoso Ferrero Rocher. Uma combinação irresistível de crocância, cremosidade e muito sabor para os amantes de chocolate.",
                        CoverImageUrl = "https://docesemimosgourmet.com.br/wp-content/uploads/2020/05/WhatsApp-Image-2020-05-30-at-09.49.30-14.jpeg",
                        CategoryId = Cone.Id,
                        IsFeatured = true,
                        IsRecomendado = true,
                        CreatedAt = DateTime.Now,
                        Preco = 15.00
                    },
                    new Doce
                    {
                        Title = "Bolo de Festa",
                        Description = "Uma deliciosa sobremesa artesanal preparada com ingredientes selecionados, combinando sabor, cremosidade e uma apresentação irresistível. Perfeita para adoçar momentos especiais, cada detalhe é pensado para proporcionar uma experiência única e inesquecível.",
                        CoverImageUrl = "https://asmeninasdobolo.com.br/wp-content/uploads/2024/09/23.jpg.webp",
                        CategoryId = Bolo_Festa.Id,
                        IsFeatured = true,
                        IsRecomendado = false,
                        CreatedAt = DateTime.Now,
                        Preco = 150.00
                    },
                    new Doce
                    {
                        Title = "Bombom de Morango",
                        Description = "Uma deliciosa sobremesa artesanal preparada com ingredientes de alta qualidade, combinando textura cremosa e sabor marcante. Cada porção é cuidadosamente elaborada para proporcionar uma experiência única, perfeita para qualquer ocasião especial ou para adoçar o seu dia.\r\n",
                        CoverImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi-lX0SdK31RbztsRbVbxhiFkGLu35pYAVL9G9fW_BCo2xIWKNUpBF6Oi5&s=10",
                        CategoryId = Bombom.Id,
                        IsFeatured = true,
                        CreatedAt = DateTime.Now,
                        Preco = 20.00
                    },
                    new Doce
                    {
                        Title = "Bolo de Pote de Cenoura",
                        Description = "bolo de pote de cenoura com chocolate, em camadas de bolo macio e recheio cremoso, finalizado com cobertura de chocolate. É uma sobremesa simples, bonita e muito saborosa.",
                        CoverImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuiVtt5-kU_z3jhpUbwa0aNdTdGUTleS_K7v4Ire7TFpMSdOMycTQy_PlT&s=10",
                        CategoryId = Bolo_Pote.Id,
                        IsFeatured = false,
                        CreatedAt = DateTime.Now,
                        Preco = 12.00
                    },
                    new Doce
                    {
                        Title = "Combos",
                        Description = "Combo de 5 brigadeiros deliciosos de chocolate com uma barra de kit kat.",
                        CoverImageUrl = "https://i.pinimg.com/736x/f2/b1/9c/f2b19ca6905282e130f0251b18d75ef3.jpg",
                        CategoryId = Combos.Id,
                        IsFeatured = false,
                        CreatedAt = DateTime.Now,
                        Preco = 16.00
                    },
                    new Doce
                    {
                        Title = "Beijinho",
                        Description = "3 beijinhos saborosos de 30g cada.\r\n",
                        CoverImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSosDAqagIFUdMgxyNGfHGneaXXZGIpvO54BEO91Mq-pIJuIloy-N3cMFc&s=10",
                        CategoryId = Brigadeiro.Id,
                        IsFeatured = false,
                        CreatedAt = DateTime.Now,
                        Preco = 10.00
                    },
                    new Doce
                    {
                        Title = "Cappuccino",
                        Description = "\r\nConheça nosso incrível cappucino de chocolate, só coloque em um copo de leite quente e sinta o sabor da vida derrentendo na sua boca.",
                        CoverImageUrl = "https://s.ecomplus.io/3967/@v4/1757100716800-forma-de-chocolate-em-policarbonato-bombom-quadrado-reto-29mm-19g-gramado-injetados-b.jpg.thumbs.webp\r\n\r\n\r\n",
                        CategoryId = Cappuccino.Id,
                        IsFeatured = false,
                        CreatedAt = DateTime.Now,
                        Preco = 15.00
                    }
                };

                await context.Doces.AddRangeAsync(doces);
                await context.SaveChangesAsync();
            }

            // =====================================================================
            // 3. SEED DE ROLES (Papéis de Usuário)
            // =====================================================================
            // 📌 CONCEITO: Roles no Identity
            // Roles são papéis que definem o nível de acesso do usuário.
            // Exemplo: "Admin" pode gerenciar games, "User" só pode visualizar.
            // =====================================================================
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("Usuário"))
            {
                await roleManager.CreateAsync(new IdentityRole("Usuário"));
            }

            // =====================================================================
            // 4. SEED DO USUÁRIO ADMINISTRADOR
            // =====================================================================
            // 📌 CONCEITO: UserManager
            // O UserManager é o serviço do Identity para gerenciar usuários.
            // Ele permite criar, buscar, atualizar e deletar usuários.
            // =====================================================================
            var adminEmail = "admin@docecantinho.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    // Campos obrigatórios do ApplicationUser com valores padrão
                    Cpf = "000.000.000-00",
                    Logradouro = "Não informado",
                    Bairro = "Não informado",
                    Cidade = "Não informado",
                    Estado = "SP",
                    Numero = "S/N",
                    Cep = "00000-000"
                };

                // Cria o usuário com a senha padrão
                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    // Atribui a role "Admin" ao usuário
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
