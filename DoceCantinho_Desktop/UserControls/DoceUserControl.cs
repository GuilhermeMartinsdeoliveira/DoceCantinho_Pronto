using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.UserControls
{
    public partial class DoceUserControl : UserControl
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================

        private DoceApiService? _doceService;
        private CategoriasApiService? _categoriasService;

        // ============================================================
        // HTTP
        // ============================================================

        private static readonly HttpClient _httpClient =
            CriarHttpClient();

        // ============================================================
        // DADOS
        // ============================================================

        private List<DoceResponseDto> _todosDoces = new();
        private List<CategoriaResponseDto> _categorias = new();

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public DoceUserControl()
        {
            InitializeComponent();

            Load += DoceUserControl_Load;
        }

        // ============================================================
        // LOAD
        // ============================================================

        private async void DoceUserControl_Load(
            object? sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            try
            {
                _doceService =
                    new DoceApiService();

                _categoriasService =
                    new CategoriasApiService();

                ConfigurarGrid();

                ConfigurarPermissoes();

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MostrarAvisoDoce(
                    $"Erro ao iniciar a tela de doces: {ex.Message}",
                    TipoAvisoDoce.Erro);
            }
        }

        // ============================================================
        // HTTP CLIENT
        // ============================================================

        private static HttpClient CriarHttpClient()
        {
            var client =
                new HttpClient
                {
                    Timeout =
                        TimeSpan.FromSeconds(15)
                };

            client.DefaultRequestHeaders
                .UserAgent
                .ParseAdd(
                    "DoceCantinho-Desktop/1.0");

            client.DefaultRequestHeaders
                .Accept
                .ParseAdd(
                    "image/avif,image/webp,image/apng,image/svg+xml,image/*,*/*;q=0.8");

            return client;
        }

        // ============================================================
        // CONFIGURAR GRID
        // ============================================================

        private void ConfigurarGrid()
        {
            gridBanco.AutoGenerateColumns =
                false;

            gridBanco.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridBanco.MultiSelect =
                false;

            gridBanco.ReadOnly =
                true;

            gridBanco.AllowUserToAddRows =
                false;

            gridBanco.AllowUserToDeleteRows =
                false;

            gridBanco.AllowUserToResizeRows =
                false;

            gridBanco.RowTemplate.Height =
                65;

            try
            {
                DoceTheme.AplicarEstiloGrid(
                    gridBanco);
            }
            catch
            {
                // Mantém o grid funcionando
                // mesmo se houver incompatibilidade
                // no tema.
            }
        }

        // ============================================================
        // PERMISSÕES
        // ============================================================

        private void ConfigurarPermissoes()
        {
            bool isAdmin = false;

            try
            {
                isAdmin =
                    SessionManager.Instance.IsAdmin;
            }
            catch
            {
                // Nunca liberar CRUD
                // por falha na leitura da sessão.
                isAdmin = false;
            }

            btnNovo.Visible =
                isAdmin;

            colEditar.Visible =
                isAdmin;

            colExcluir.Visible =
                isAdmin;
        }

        // ============================================================
        // CARREGAR DADOS DA API
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            if (_doceService == null ||
                _categoriasService == null)
            {
                return;
            }

            try
            {
                Cursor =
                    Cursors.WaitCursor;

                Task<List<DoceResponseDto>> tarefaDoces =
                    _doceService.GetAllAsync();

                Task<List<CategoriaResponseDto>> tarefaCategorias =
                    _categoriasService.GetAllAsync();

                await Task.WhenAll(
                    tarefaDoces,
                    tarefaCategorias);

                _todosDoces =
                    tarefaDoces.Result ??
                    new List<DoceResponseDto>();

                _categorias =
                    tarefaCategorias.Result ??
                    new List<CategoriaResponseDto>();

                PopularGrid(
                    _todosDoces);

                lblQuantidade.Text =
                    $"{_todosDoces.Count} produto" +
                    $"{(_todosDoces.Count == 1 ? "" : "s")} " +
                    $"cadastrado" +
                    $"{(_todosDoces.Count == 1 ? "" : "s")}";
            }
            catch (Exception ex)
            {
                MostrarAvisoDoce(
                    $"Não foi possível carregar os doces da API: {ex.Message}",
                    TipoAvisoDoce.Erro);
            }
            finally
            {
                Cursor =
                    Cursors.Default;
            }
        }

        // ============================================================
        // POPULAR GRID
        // ============================================================

        private void PopularGrid(
            List<DoceResponseDto> doces)
        {
            // Libera imagens antigas antes de reconstruir
            // a grade.
            LiberarImagensGrid();

            gridBanco.Rows.Clear();

            foreach (var doce in doces)
            {
                string status =
                    ObterStatus(doce);

                int indice =
                    gridBanco.Rows.Add(
                        CriarImagemPlaceholder(),
                        doce.Id,
                        doce.Title ??
                        string.Empty,
                        doce.CategoryName ??
                        string.Empty,
                        doce.Preco.ToString("C2"),
                        doce.QuantidadeEstoque,
                        status,
                        "Editar",
                        "Excluir");

                // Não usamos mais o índice da linha.
                // A busca da linha será feita pelo ID.
                _ = CarregarImagemAsync(
                    doce.Id,
                    doce.CoverImageUrl);
            }

            lblResultados.Text =
                $"{doces.Count} resultado" +
                $"{(doces.Count == 1 ? "" : "s")}";
        }

        // ============================================================
        // LIBERAR IMAGENS DO GRID
        // ============================================================

        private void LiberarImagensGrid()
        {
            try
            {
                DataGridViewColumn? colunaImagem =
                    gridBanco.Columns["colImagem"];

                if (colunaImagem == null)
                    return;

                foreach (DataGridViewRow linha
                         in gridBanco.Rows)
                {
                    if (linha.IsNewRow)
                        continue;

                    DataGridViewCell celula =
                        linha.Cells[colunaImagem.Index];

                    if (celula.Value is Image imagem)
                    {
                        celula.Value = null;

                        imagem.Dispose();
                    }
                }
            }
            catch
            {
                // Não interrompe a reconstrução do grid.
            }
        }

        // ============================================================
        // DEFINIR STATUS
        // ============================================================

        private string ObterStatus(
            DoceResponseDto doce)
        {
            if (!doce.IsAtivo)
                return "Inativo";

            if (doce.IsFeatured)
                return "Destaque";

            if (doce.QuantidadeEstoque <= 0)
                return "Sem estoque";

            return "Ativo";
        }

        // ============================================================
        // CARREGAR IMAGEM
        // ============================================================

        // ============================================================
        // CARREGAR IMAGEM DO DOCE
        // ============================================================

        private async Task CarregarImagemAsync(
            int doceId,
            string? imageUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imageUrl))
                    return;

                Image? imagem =
                    await BaixarImagemAsync(imageUrl);

                if (imagem == null)
                    return;

                if (IsDisposed ||
                    Disposing ||
                    gridBanco.IsDisposed)
                {
                    imagem.Dispose();
                    return;
                }

                void AplicarImagem()
                {
                    try
                    {
                        if (IsDisposed ||
                            Disposing ||
                            gridBanco.IsDisposed)
                        {
                            imagem.Dispose();
                            return;
                        }

                        foreach (DataGridViewRow linha
                                 in gridBanco.Rows)
                        {
                            if (linha.IsNewRow)
                                continue;

                            object? valorId =
                                linha.Cells["colId"].Value;

                            if (valorId == null)
                                continue;

                            if (!int.TryParse(
                                    valorId.ToString(),
                                    out int idLinha))
                            {
                                continue;
                            }

                            if (idLinha != doceId)
                                continue;

                            // Libera imagem anterior
                            if (linha.Cells["colImagem"].Value
                                is Image imagemAnterior)
                            {
                                linha.Cells["colImagem"].Value = null;

                                try
                                {
                                    imagemAnterior.Dispose();
                                }
                                catch
                                {
                                }
                            }

                            // Aplica nova imagem
                            linha.Cells["colImagem"].Value =
                                imagem;

                            gridBanco.InvalidateRow(
                                linha.Index);

                            return;
                        }

                        // A linha não existe mais
                        imagem.Dispose();
                    }
                    catch
                    {
                        try
                        {
                            imagem.Dispose();
                        }
                        catch
                        {
                        }
                    }
                }

                if (gridBanco.InvokeRequired)
                {
                    try
                    {
                        gridBanco.BeginInvoke(
                            new Action(AplicarImagem));
                    }
                    catch
                    {
                        imagem.Dispose();
                    }
                }
                else
                {
                    AplicarImagem();
                }
            }
            catch
            {
                // Mantém o placeholder
            }
        }


        // ============================================================
        // BAIXAR / CONVERTER IMAGEM
        // ============================================================

        private async Task<Image?> BaixarImagemAsync(
            string valorImagem)
        {
            string valor =
                valorImagem.Trim();

            if (string.IsNullOrWhiteSpace(valor))
                return null;


            // ========================================================
            // BASE64 / DATA URI
            // ========================================================

            if (valor.StartsWith(
                    "data:image",
                    StringComparison.OrdinalIgnoreCase))
            {
                int virgula =
                    valor.IndexOf(',');

                if (virgula >= 0)
                {
                    string base64 =
                        valor.Substring(
                            virgula + 1);

                    try
                    {
                        return ConverterBase64ParaImagemDoce(
                            base64);
                    }
                    catch
                    {
                        return null;
                    }
                }

                return null;
            }


            // ========================================================
            // BASE64 PURO
            // ========================================================

            if (!valor.StartsWith(
                    "http://",
                    StringComparison.OrdinalIgnoreCase) &&
                !valor.StartsWith(
                    "https://",
                    StringComparison.OrdinalIgnoreCase) &&
                !valor.StartsWith(
                    "/",
                    StringComparison.OrdinalIgnoreCase) &&
                !valor.StartsWith(
                    "\\",
                    StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return ConverterBase64ParaImagemDoce(
                        valor);
                }
                catch
                {
                    // Não era Base64.
                }
            }


            // ========================================================
            // CAMINHO LOCAL
            // ========================================================

            if (Path.IsPathRooted(valor))
            {
                try
                {
                    if (!File.Exists(valor))
                        return null;

                    using FileStream arquivo =
                        new FileStream(
                            valor,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);

                    using MemoryStream memoria =
                        new MemoryStream();

                    await arquivo.CopyToAsync(
                        memoria);

                    memoria.Position = 0;

                    using Image original =
                        Image.FromStream(
                            memoria);

                    return new Bitmap(original);
                }
                catch
                {
                    return null;
                }
            }


            // ========================================================
            // URL ABSOLUTA
            // ========================================================

            string urlFinal =
                MontarUrlImagem(valor);

            if (string.IsNullOrWhiteSpace(urlFinal))
                return null;


            // ========================================================
            // DOWNLOAD
            // ========================================================

            try
            {
                using HttpRequestMessage request =
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        urlFinal);

                using HttpResponseMessage resposta =
                    await _httpClient.SendAsync(
                        request,
                        HttpCompletionOption.ResponseHeadersRead);

                if (!resposta.IsSuccessStatusCode)
                    return null;

                byte[] bytes =
                    await resposta.Content
                        .ReadAsByteArrayAsync();

                if (bytes.Length == 0)
                    return null;

                using MemoryStream stream =
                    new MemoryStream(bytes);

                using Image original =
                    Image.FromStream(stream);

                return new Bitmap(original);
            }
            catch
            {
                return null;
            }
        }


        // ============================================================
        // MONTAR URL DA IMAGEM
        // ============================================================

        private string MontarUrlImagem(
            string valorImagem)
        {
            string valor =
                valorImagem.Trim();

            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;


            // ========================================================
            // URL ABSOLUTA
            // ========================================================

            if (Uri.TryCreate(
                    valor,
                    UriKind.Absolute,
                    out Uri? uriAbsoluta))
            {
                if (uriAbsoluta.Scheme ==
                        Uri.UriSchemeHttp ||
                    uriAbsoluta.Scheme ==
                        Uri.UriSchemeHttps)
                {
                    return uriAbsoluta.AbsoluteUri;
                }
            }


            // ========================================================
            // CONFIGURAÇÃO DA API
            // ========================================================

            string baseApi =
                AppConfig.ApiBaseUrl?.Trim()
                ?? string.Empty;

            if (string.IsNullOrWhiteSpace(baseApi))
                return string.Empty;


            if (!baseApi.EndsWith("/"))
                baseApi += "/";


            // ========================================================
            // NORMALIZAR CAMINHO
            // ========================================================

            string caminho =
                valor.TrimStart(
                    '/',
                    '\\');


            // ========================================================
            // SE JÁ FOR UMA ROTA DA API
            // ========================================================

            if (caminho.StartsWith(
                    "api/",
                    StringComparison.OrdinalIgnoreCase))
            {
                return baseApi + caminho;
            }


            // ========================================================
            // UPLOADS
            // ========================================================

            if (caminho.StartsWith(
                    "uploads/",
                    StringComparison.OrdinalIgnoreCase))
            {
                return baseApi + caminho;
            }


            // ========================================================
            // IMAGES
            // ========================================================

            if (caminho.StartsWith(
                    "images/",
                    StringComparison.OrdinalIgnoreCase))
            {
                return baseApi + caminho;
            }


            // ========================================================
            // WWWROOT
            // ========================================================

            if (caminho.StartsWith(
                    "wwwroot/",
                    StringComparison.OrdinalIgnoreCase))
            {
                caminho =
                    caminho.Substring(
                        "wwwroot/".Length);
            }


            // ========================================================
            // CAMINHO RELATIVO GENÉRICO
            // ========================================================

            if (Uri.TryCreate(
                    baseApi + caminho,
                    UriKind.Absolute,
                    out Uri? uriFinal))
            {
                return uriFinal.AbsoluteUri;
            }

            return string.Empty;
        }


        // ============================================================
        // BASE64 → IMAGEM
        // ============================================================

        private Image ConverterBase64ParaImagemDoce(
            string base64)
        {
            string valor =
                base64.Trim();

            if (valor.Contains(","))
            {
                valor =
                    valor.Substring(
                        valor.IndexOf(",") + 1);
            }

            valor =
                valor.Trim();

            byte[] bytes =
                Convert.FromBase64String(
                    valor);

            using MemoryStream stream =
                new MemoryStream(bytes);

            using Image original =
                Image.FromStream(stream);

            return new Bitmap(original);
        }

        // ============================================================
        // PLACEHOLDER
        // ============================================================

        private Bitmap CriarImagemPlaceholder()
        {
            const int largura = 58;
            const int altura = 58;

            Bitmap bitmap =
                new Bitmap(
                    largura,
                    altura);

            using Graphics g =
                Graphics.FromImage(
                    bitmap);

            g.Clear(
                Color.FromArgb(
                    246,
                    242,
                    239));

            using Pen pen =
                new Pen(
                    Color.FromArgb(
                        210,
                        195,
                        187),
                    1);

            g.DrawRectangle(
                pen,
                0,
                0,
                largura - 1,
                altura - 1);

            using Font fonte =
                new Font(
                    "Segoe UI",
                    7F,
                    FontStyle.Regular);

            using Brush brush =
                new SolidBrush(
                    Color.FromArgb(
                        145,
                        125,
                        115));

            StringFormat formato =
                new StringFormat
                {
                    Alignment =
                        StringAlignment.Center,

                    LineAlignment =
                        StringAlignment.Center
                };

            g.DrawString(
                "Sem\nimagem",
                fonte,
                brush,
                new RectangleF(
                    0,
                    0,
                    largura,
                    altura),
                formato);

            return bitmap;
        }

        // ============================================================
        // PESQUISAR
        // ============================================================

        private void btnPesquisar_Click(
            object sender,
            EventArgs e)
        {
            FiltrarDoces();
        }

        // ============================================================
        // PESQUISA AUTOMÁTICA
        // ============================================================

        private void txtPesquisa_TextChanged(
            object sender,
            EventArgs e)
        {
            FiltrarDoces();
        }

        private void FiltrarDoces()
        {
            string termo =
                txtPesquisa.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                termo))
            {
                PopularGrid(
                    _todosDoces);

                return;
            }

            var filtrados =
                _todosDoces
                    .Where(
                        d =>
                            (
                                !string.IsNullOrEmpty(
                                    d.Title)
                                &&
                                d.Title.Contains(
                                    termo,
                                    StringComparison
                                        .OrdinalIgnoreCase)
                            )
                            ||
                            (
                                !string.IsNullOrEmpty(
                                    d.CategoryName)
                                &&
                                d.CategoryName.Contains(
                                    termo,
                                    StringComparison
                                        .OrdinalIgnoreCase)
                            )
                    )
                    .ToList();

            PopularGrid(
                filtrados);
        }

        // ============================================================
        // OBTER DOCE SELECIONADO
        // ============================================================

        private DoceResponseDto?
            ObterDoceSelecionado()
        {
            if (gridBanco.SelectedRows.Count == 0)
                return null;

            DataGridViewRow linha =
                gridBanco.SelectedRows[0];

            if (linha.Cells["colId"].Value == null)
                return null;

            if (!int.TryParse(
                    linha.Cells["colId"].Value.ToString(),
                    out int id))
            {
                return null;
            }

            return _todosDoces
                .FirstOrDefault(
                    d =>
                        d.Id == id);
        }

        // ============================================================
        // NOVO DOCE
        // ============================================================

        private async void btnNovo_Click(
            object sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoDoce(
                    "Seu perfil não possui permissão para criar doces.",
                    TipoAvisoDoce.Aviso);

                return;
            }

            if (_doceService == null)
                return;

            using var form =
                new DoceFormDialog(
                    _categorias,
                    null);

            if (form.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            if (form.DoceDto == null)
                return;

            try
            {
                var (success, _, error) =
                    await _doceService
                        .CreateAsync(
                            form.DoceDto);

                if (success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoDoce(
                        "Doce criado com sucesso!",
                        TipoAvisoDoce.Sucesso);
                }
                else
                {
                    MostrarAvisoDoce(
                        error ??
                        "Não foi possível criar o doce.",
                        TipoAvisoDoce.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoDoce(
                    $"Erro ao criar doce: {ex.Message}",
                    TipoAvisoDoce.Erro);
            }
        }

        // ============================================================
        // EDITAR
        // ============================================================

        private async Task EditarDoceAsync()
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoDoce(
                    "Seu perfil não possui permissão para editar doces.",
                    TipoAvisoDoce.Aviso);

                return;
            }

            if (_doceService == null)
                return;

            var doce =
                ObterDoceSelecionado();

            if (doce == null)
            {
                MostrarAvisoDoce(
                    "Selecione um doce para editar.",
                    TipoAvisoDoce.Aviso);

                return;
            }

            using var form =
                new DoceFormDialog(
                    _categorias,
                    doce);

            if (form.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            if (form.UpdateDto == null)
                return;

            try
            {
                var (success, _, error) =
                    await _doceService
                        .UpdateAsync(
                            doce.Id,
                            form.UpdateDto);

                if (success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoDoce(
                        "Doce atualizado com sucesso!",
                        TipoAvisoDoce.Sucesso);
                }
                else
                {
                    MostrarAvisoDoce(
                        error ??
                        "Não foi possível atualizar o doce.",
                        TipoAvisoDoce.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoDoce(
                    $"Erro ao atualizar doce: {ex.Message}",
                    TipoAvisoDoce.Erro);
            }
        }

        // ============================================================
        // EXCLUIR
        // ============================================================

        private async Task ExcluirDoceAsync()
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoDoce(
                    "Seu perfil não possui permissão para excluir doces.",
                    TipoAvisoDoce.Aviso);

                return;
            }

            if (_doceService == null)
                return;

            var doce =
                ObterDoceSelecionado();

            if (doce == null)
            {
                MostrarAvisoDoce(
                    "Selecione um doce para excluir.",
                    TipoAvisoDoce.Aviso);

                return;
            }

            // ========================================================
            // CONFIRMAÇÃO
            // ========================================================

            using (var confirmar =
                new DoceCantinho.Desktop.Forms
                    .ConfirmarExclusaoForm(
                        "doce",
                        doce.Title))
            {
                var resultado =
                    confirmar.ShowDialog(
                        FindForm());

                if (resultado !=
                    DialogResult.OK)
                {
                    return;
                }
            }

            // ========================================================
            // EXCLUSÃO
            // ========================================================

            try
            {
                var (success, error) =
                    await _doceService
                        .DeleteAsync(
                            doce.Id);

                if (success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoDoce(
                        "Doce excluído com sucesso!",
                        TipoAvisoDoce.Sucesso);
                }
                else
                {
                    MostrarAvisoDoce(
                        error ??
                        "Não foi possível excluir o doce.",
                        TipoAvisoDoce.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoDoce(
                    $"Erro ao excluir doce: {ex.Message}",
                    TipoAvisoDoce.Erro);
            }
        }

        // ============================================================
        // AVISOS
        // ============================================================

        private enum TipoAvisoDoce
        {
            Sucesso,
            Aviso,
            Erro
        }

        // ============================================================
        // AVISO PERSONALIZADO
        // ============================================================

        private void MostrarAvisoDoce(
            string mensagem,
            TipoAvisoDoce tipo)
        {
            try
            {
                foreach (
                    Control controle
                    in Controls
                        .OfType<Panel>()
                        .ToList())
                {
                    if (controle.Name ==
                        "pnlAvisoDoce")
                    {
                        Controls.Remove(
                            controle);

                        controle.Dispose();
                    }
                }

                var pnlAviso =
                    new Guna.UI2.WinForms
                        .Guna2Panel
                    {
                        Name =
                            "pnlAvisoDoce",

                        Size =
                            new Size(
                                420,
                                62),

                        BorderRadius =
                            12,

                        Anchor =
                            AnchorStyles.Top |
                            AnchorStyles.Right,

                        FillColor =
                            Color.White,

                        ShadowDecoration =
                        {
                            Enabled = true,
                            Depth = 8,
                            BorderRadius = 12
                        }
                    };

                pnlAviso.Location =
                    new Point(
                        Math.Max(
                            10,
                            Width -
                            pnlAviso.Width -
                            20),
                        20);

                Color corPrincipal;
                string titulo;

                switch (tipo)
                {
                    case TipoAvisoDoce.Sucesso:

                        corPrincipal =
                            Color.FromArgb(
                                46,
                                160,
                                67);

                        titulo =
                            "Sucesso";

                        break;

                    case TipoAvisoDoce.Aviso:

                        corPrincipal =
                            Color.FromArgb(
                                230,
                                155,
                                45);

                        titulo =
                            "Atenção";

                        break;

                    default:

                        corPrincipal =
                            Color.FromArgb(
                                200,
                                70,
                                70);

                        titulo =
                            "Erro";

                        break;
                }

                var lblTituloAviso =
                    new Label
                    {
                        AutoSize =
                            false,

                        Location =
                            new Point(
                                18,
                                10),

                        Size =
                            new Size(
                                120,
                                20),

                        Text =
                            titulo,

                        Font =
                            new Font(
                                "Segoe UI",
                                10F,
                                FontStyle.Bold),

                        ForeColor =
                            corPrincipal
                    };

                var lblMensagemAviso =
                    new Label
                    {
                        AutoSize =
                            false,

                        Location =
                            new Point(
                                18,
                                30),

                        Size =
                            new Size(
                                350,
                                24),

                        Text =
                            mensagem,

                        Font =
                            new Font(
                                "Segoe UI",
                                9F),

                        ForeColor =
                            Color.FromArgb(
                                70,
                                70,
                                70),

                        AutoEllipsis =
                            true
                    };

                var btnFechar =
                    new Guna.UI2.WinForms
                        .Guna2Button
                    {
                        Size =
                            new Size(
                                28,
                                28),

                        Location =
                            new Point(
                                380,
                                8),

                        Text =
                            "×",

                        Font =
                            new Font(
                                "Segoe UI",
                                14F),

                        ForeColor =
                            Color.FromArgb(
                                100,
                                100,
                                100),

                        FillColor =
                            Color.Transparent,

                        BorderRadius =
                            8,

                        Cursor =
                            Cursors.Hand
                    };

                btnFechar.HoverState.FillColor =
                    Color.FromArgb(
                        245,
                        245,
                        245);

                btnFechar.HoverState.ForeColor =
                    Color.Black;

                btnFechar.Click +=
                    (_, __) =>
                    {
                        if (!pnlAviso.IsDisposed)
                        {
                            Controls.Remove(
                                pnlAviso);

                            pnlAviso.Dispose();
                        }
                    };

                pnlAviso.Controls.Add(
                    lblTituloAviso);

                pnlAviso.Controls.Add(
                    lblMensagemAviso);

                pnlAviso.Controls.Add(
                    btnFechar);

                Controls.Add(
                    pnlAviso);

                pnlAviso.BringToFront();

                var timer =
                    new System.Windows.Forms.Timer
                    {
                        Interval =
                            3500
                    };

                timer.Tick +=
                    (_, __) =>
                    {
                        timer.Stop();

                        timer.Dispose();

                        if (!pnlAviso.IsDisposed)
                        {
                            Controls.Remove(
                                pnlAviso);

                            pnlAviso.Dispose();
                        }
                    };

                timer.Start();
            }
            catch
            {
                // Não interrompe a operação
                // se o aviso visual falhar.
            }
        }

        // ============================================================
        // CLIQUE NO GRID
        // ============================================================

        private async void gridBanco_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                gridBanco.Rows.Count)
            {
                return;
            }

            gridBanco.ClearSelection();

            gridBanco.Rows[e.RowIndex]
                .Selected =
                true;

            string nomeColuna =
                gridBanco
                    .Columns[e.ColumnIndex]
                    .Name;

            // --------------------------------------------------------
            // EDITAR
            // --------------------------------------------------------

            if (nomeColuna ==
                "colEditar")
            {
                if (!SessionManager.Instance.IsAdmin)
                {
                    MostrarAvisoDoce(
                        "Seu perfil não possui permissão para editar doces.",
                        TipoAvisoDoce.Aviso);

                    return;
                }

                await EditarDoceAsync();
            }

            // --------------------------------------------------------
            // EXCLUIR
            // --------------------------------------------------------

            else if (nomeColuna ==
                     "colExcluir")
            {
                if (!SessionManager.Instance.IsAdmin)
                {
                    MostrarAvisoDoce(
                        "Seu perfil não possui permissão para excluir doces.",
                        TipoAvisoDoce.Aviso);

                    return;
                }

                await ExcluirDoceAsync();
            }
        }

        // ============================================================
        // ATUALIZAR
        // ============================================================

        private async void btnAtualizar_Click(
            object sender,
            EventArgs e)
        {
            await CarregarDadosAsync();
        }

    }
}