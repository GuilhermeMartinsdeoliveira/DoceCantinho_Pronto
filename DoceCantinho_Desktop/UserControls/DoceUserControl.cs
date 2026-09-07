using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        // CONFIGURAR GRID
        // ============================================================

        private void ConfigurarGrid()
        {
            gridBanco.AutoGenerateColumns = false;

            gridBanco.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridBanco.MultiSelect = false;

            gridBanco.ReadOnly = true;

            gridBanco.AllowUserToAddRows = false;
            gridBanco.AllowUserToDeleteRows = false;

            gridBanco.RowTemplate.Height = 65;

            try
            {
                DoceTheme.AplicarEstiloGrid(
                    gridBanco);
            }
            catch
            {
                // Mantém o grid funcionando
                // mesmo se houver alguma incompatibilidade
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
                isAdmin = true;
            }

            btnNovo.Visible = isAdmin;

            colEditar.Visible = isAdmin;
            colExcluir.Visible = isAdmin;
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

                var tarefaDoces =
                    _doceService.GetAllAsync();

                var tarefaCategorias =
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
            gridBanco.Rows.Clear();

            foreach (var doce in doces)
            {
                string status =
                    ObterStatus(doce);

                int indice =
                    gridBanco.Rows.Add(
                        null,
                        doce.Id,
                        doce.Title ?? string.Empty,
                        doce.CategoryName ?? string.Empty,
                        doce.Preco.ToString("C2"),
                        doce.QuantidadeEstoque,
                        status,
                        "Editar",
                        "Excluir");

                _ = CarregarImagemAsync(
                    indice,
                    doce.CoverImageUrl);
            }

            lblResultados.Text =
                $"{doces.Count} resultado" +
                $"{(doces.Count == 1 ? "" : "s")}";
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

        private async Task CarregarImagemAsync(
            int indiceLinha,
            string? imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return;

            try
            {
                using HttpClient client =
                    new HttpClient();

                byte[] bytes =
                    await client.GetByteArrayAsync(
                        imageUrl);

                using var stream =
                    new System.IO.MemoryStream(bytes);

                using var imagemOriginal =
                    Image.FromStream(stream);

                Image imagem =
                    new Bitmap(imagemOriginal);

                if (indiceLinha >= 0 &&
                    indiceLinha < gridBanco.Rows.Count)
                {
                    gridBanco.Invoke(
                        new Action(() =>
                        {
                            if (indiceLinha <
                                gridBanco.Rows.Count)
                            {
                                gridBanco.Rows[indiceLinha]
                                    .Cells["colImagem"]
                                    .Value = imagem;
                            }
                        }));
                }
            }
            catch
            {
                // A imagem permanece vazia
                // se houver falha no carregamento.
            }
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

            if (string.IsNullOrWhiteSpace(termo))
            {
                PopularGrid(
                    _todosDoces);

                return;
            }

            var filtrados =
                _todosDoces
                    .Where(d =>
                        (!string.IsNullOrEmpty(d.Title) &&
                         d.Title.Contains(
                             termo,
                             StringComparison
                                 .OrdinalIgnoreCase))
                        ||
                        (!string.IsNullOrEmpty(
                             d.CategoryName) &&
                         d.CategoryName.Contains(
                             termo,
                             StringComparison
                                 .OrdinalIgnoreCase)))
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

            var linha =
                gridBanco.SelectedRows[0];

            if (linha.Cells["colId"].Value == null)
                return null;

            int id =
                Convert.ToInt32(
                    linha.Cells["colId"].Value);

            return _todosDoces
                .FirstOrDefault(
                    d => d.Id == id);
        }

        // ============================================================
        // NOVO DOCE
        // ============================================================

        private async void btnNovo_Click(
            object sender,
            EventArgs e)
        {
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
                    await _doceService.CreateAsync(
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
                    await _doceService.UpdateAsync(
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
            // CONFIRMAÇÃO PERSONALIZADA
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
                    await _doceService.DeleteAsync(
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
        // AVISOS PERSONALIZADOS
        // ============================================================

        private enum TipoAvisoDoce
        {
            Sucesso,
            Aviso,
            Erro
        }

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
                        Controls.Remove(controle);
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

                        BorderRadius = 12,

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
                        AutoSize = false,

                        Location =
                            new Point(
                                18,
                                10),

                        Size =
                            new Size(
                                120,
                                20),

                        Text = titulo,

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
                        AutoSize = false,

                        Location =
                            new Point(
                                18,
                                30),

                        Size =
                            new Size(
                                350,
                                24),

                        Text = mensagem,

                        Font =
                            new Font(
                                "Segoe UI",
                                9F),

                        ForeColor =
                            Color.FromArgb(
                                70,
                                70,
                                70),

                        AutoEllipsis = true
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

                        Text = "×",

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

                        BorderRadius = 8
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
                        Interval = 3500
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

            gridBanco.ClearSelection();

            gridBanco.Rows[e.RowIndex]
                .Selected = true;

            string nomeColuna =
                gridBanco
                    .Columns[e.ColumnIndex]
                    .Name;

            if (nomeColuna == "colEditar")
            {
                await EditarDoceAsync();
            }
            else if (nomeColuna == "colExcluir")
            {
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