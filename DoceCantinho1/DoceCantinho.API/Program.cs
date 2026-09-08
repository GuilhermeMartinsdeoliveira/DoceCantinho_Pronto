// =============================================================================
// SenacGames.API - Program.cs
// =============================================================================
// 📌 CONCEITO IMPORTANTE: Program.cs
// Este é o PONTO DE ENTRADA da aplicação API.
// Aqui configuramos todos os serviços (DI), middlewares e a pipeline HTTP.
//
// O que é configurado aqui:
// 1. Entity Framework Core (conexão com banco de dados)
// 2. ASP.NET Core Identity (autenticação e autorização)
// 3. Dependency Injection (repositórios e serviços)
// 4. Swagger (documentação da API)
// 5. CORS (permissões de acesso cross-origin)
// =============================================================================

using DoceCantinho.Application.Interfaces;
using DoceCantinho.Application.Services;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Infrastructure.Context;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DoceCantinho.Infrastructure.Repositories;
using System.Diagnostics;

// =====================================================================
// AUTO-LIBERAÇÃO DE PORTA (evita "Failed to bind... address already in use")
// =====================================================================
// 📌 CONCEITO: Quando a API é parada abruptamente (ex: fechando a janela do
// terminal, crash, ou clicando em "Parar" durante o debug em alguns cenários),
// o processo dotnet pode continuar rodando em segundo plano e travar a porta.
// Na próxima execução, o Kestrel falha ao tentar usar a mesma porta.
// Este helper verifica, ANTES de subir o Kestrel, se as portas configuradas
// em launchSettings.json (5275 e 7296) já estão em uso por um processo
// "dotnet" ou "DoceCantinho.*" travado, e encerra esse processo antigo
// automaticamente — sem precisar rodar netstat/taskkill manualmente.
// =====================================================================
if (OperatingSystem.IsWindows())
{
    LiberarPortasEmUso(new[] { 5275, 7296 });
}

static void LiberarPortasEmUso(int[] portas)
{
    foreach (var porta in portas)
    {
        try
        {
            var netstat = new ProcessStartInfo("netstat", "-ano")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var proc = Process.Start(netstat);
            if (proc == null) continue;

            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            foreach (var linha in output.Split('\n'))
            {
                if (!linha.Contains($":{porta} ") || !linha.Contains("LISTENING"))
                    continue;

                var partes = linha.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length == 0 || !int.TryParse(partes[^1], out int pid))
                    continue;

                if (pid == Environment.ProcessId)
                    continue;

                try
                {
                    var processo = Process.GetProcessById(pid);

                    // 🔒 Segurança: só encerra processos que claramente pertencem
                    // a este projeto (dotnet ou DoceCantinho.API), nunca outros
                    // programas que por acaso estejam usando a porta.
                    bool ehProcessoDoProjeto =
                        processo.ProcessName.Equals("dotnet", StringComparison.OrdinalIgnoreCase) ||
                        processo.ProcessName.Contains("DoceCantinho", StringComparison.OrdinalIgnoreCase);

                    if (ehProcessoDoProjeto)
                    {
                        Console.WriteLine($"⚠️  Porta {porta} estava em uso pelo processo '{processo.ProcessName}' (PID {pid}). Encerrando instância antiga...");
                        processo.Kill();
                        processo.WaitForExit(2000);
                        Console.WriteLine($"✅ Porta {porta} liberada.");
                    }
                }
                catch
                {
                    // Processo pode já ter encerrado sozinho entre a leitura e o Kill — ignora.
                }
            }
        }
        catch
        {
            // netstat indisponível ou outra falha — não impede a API de tentar subir normalmente.
        }
    }
}

var builder = WebApplication.CreateBuilder(args);

// =====================================================================
// 1. ENTITY FRAMEWORK CORE — Configuração do banco de dados
// =====================================================================
// 📌 CONCEITO: AddDbContext registra o DbContext no container de DI.
// UseSqlServer configura o Entity Framework para usar o SQL Server.
// A connection string é lida do arquivo appsettings.json.
// =====================================================================
builder.Services.AddDbContext<DoceCantinhoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================================================================
// 2. ASP.NET CORE IDENTITY — Autenticação e Autorização
// =====================================================================
// 📌 CONCEITO: Identity é o sistema de autenticação do ASP.NET Core.
// Ele gerencia: usuários, senhas, roles, claims, login, logout, etc.
// AddIdentity registra os serviços do Identity no container de DI.
// AddEntityFrameworkStores conecta o Identity ao banco via EF Core.
// =====================================================================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Configurações de senha (simplificadas para ensino)
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<DoceCantinhoDbContext>()
.AddDefaultTokenProviders();

// Observação: certifica-se de que o namespace DoceCantinho.Infrastructure.Identity está importado no topo do arquivo (using DoceCantinho.Infrastructure.Identity;). Caso contrário, adicione-o.

// Se o DbContext estiver configurado para usar ApplicationUser como tipo de usuário, confirme que DoceCantinhoDbContext herda IdentityDbContext<ApplicationUser>. (Verifique o arquivo DoceCantinho.Infrastructure\Context se necessário.)

















// End of replacement; no further changes required for Identity registration.





















// (Note: keep the rest of Program.cs unchanged)

// Configuração de Cookie Authentication para a API
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

// =====================================================================
// 3. DEPENDENCY INJECTION — Registro de Repositórios e Serviços
// =====================================================================
// 📌 CONCEITO: Dependency Injection (DI)
// AddScoped registra um serviço com ciclo de vida "por requisição".
// Isso significa que uma nova instância é criada para cada requisição HTTP.
//
// Exemplo: quando um controller precisa do IGameService,
// o .NET automaticamente cria um GameService e injeta no construtor.
// =====================================================================
builder.Services.AddScoped<IDoceRepository, DoceRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDoceService, DoceService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// =====================================================================
// 4. CONTROLLERS
// =====================================================================
builder.Services.AddControllers();

// =====================================================================
// 5. SWAGGER — Documentação automática da API
// =====================================================================
// 📌 CONCEITO: Swagger gera automaticamente uma interface visual
// para testar os endpoints da API no navegador.
// Acesse: https://localhost:PORTA/swagger
// =====================================================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DoceCantinho API",
        Version = "v1",
        Description = "API REST do sistema DoceCantinho — Catálogo de Doces para ensino de ASP.NET Core"
    });
});

// =====================================================================
// 6. CORS — Permite requisições de outras origens
// =====================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// =====================================================================
// PIPELINE DE MIDDLEWARES
// =====================================================================
// 📌 CONCEITO: Middlewares são executados em sequência para cada requisição.
// A ordem importa! Cada middleware processa a requisição e passa adiante.
// =====================================================================

if (app.Environment.IsDevelopment())
{
    // Swagger só é habilitado em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// 📌 IMPORTANTE: UseAuthentication ANTES de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// =====================================================================
// SEED DATA — Popula o banco com dados iniciais
// =====================================================================
// 📌 CONCEITO: O seed é executado na inicialização da aplicação.
// Ele cria categorias, games de exemplo e o usuário admin.
// =====================================================================
await SeedData.SeedAsync(app.Services);

app.Run();
