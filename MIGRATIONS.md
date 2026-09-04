# Migrations EF Core — DoceCantinho

Instruções para gerar/aplicar migrations e manter o banco sincronizado.

Pré-requisitos
- .NET SDK instalado
- dotnet-ef tool (global) instalado: `dotnet tool install --global dotnet-ef`

Gerar uma nova migration (ex.: ao alterar entidades)
- Abra um terminal na raiz do repositório
- Rode o comando (usando o projeto de migrations e o projeto startup corretos):

  dotnet ef migrations add NomeDaMigration --project DoceCantinho.Infrastructure --startup-project DoceCantinho.UI

Isso criará uma pasta `Migrations` dentro do projeto `DoceCantinho.Infrastructure` com os arquivos da migration.

Aplicar migrations ao banco de dados
- Para aplicar todas as migrations pendentes ao banco configurado na connection string do projeto de startup:

  dotnet ef database update --project DoceCantinho.Infrastructure --startup-project DoceCantinho.UI

Notas
- Em desenvolvimento rápido o projeto UI chama `db.Database.EnsureCreated()` para criar o esquema automaticamente. Porém, para controlar versões do banco (produção) use migrations e aplique via `dotnet ef database update`.
- Se preferir usar DoceCantinho.API como startup para aplicar migrations, substitua `--startup-project DoceCantinho.UI` por `--startup-project DoceCantinho.API`.

Cuidados
- Commit as migrations geradas ao controle de versão para que outros desenvolvedores apliquem o mesmo esquema.
- Nunca modifique manualmente os arquivos de migration já aplicados em produção; crie uma nova migration para alterações.
