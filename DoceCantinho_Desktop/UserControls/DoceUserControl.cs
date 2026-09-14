using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                _doceService = new DoceApiService();
                _categoriasService = new CategoriasApiService();

                ConfigurarGrid();
                ConfigurarPermissoes();

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao iniciar a tela de doces:\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CONFIGURAÇÃO DO GRID
        // ============================================================

        private void ConfigurarGrid()
        {
            gridBanco.AutoGenerateColumns = false;

            gridBanco.AllowUserToAddRows = false;
            gridBanco.AllowUserToDeleteRows = false;
            gridBanco.AllowUserToResizeRows = false;

            gridBanco.ReadOnly = true;
            gridBanco.MultiSelect = false;

            gridBanco.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridBanco.RowHeadersVisible = false;

            gridBanco.EnableHeadersVisualStyles = false;

            gridBanco.BackgroundColor =
                Color.White;

            gridBanco.BorderStyle =
                BorderStyle.None;

            gridBanco.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            gridBanco.GridColor =
                Color.FromArgb(236, 228, 223);

            gridBanco.RowTemplate.Height = 48;

            try
            {
                DoceTheme.AplicarEstiloGrid(gridBanco);
            }
            catch
            {
                // O estilo do próprio controle continua funcionando.
            }

            gridBanco.CellFormatting -= GridBanco_CellFormatting;
            gridBanco.CellFormatting += GridBanco_CellFormatting;
        }

        // ============================================================
        // FORMATAÇÃO DO GRID
        // ============================================================

        private void GridBanco_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            string nomeColuna =
                gridBanco.Columns[e.ColumnIndex].Name;

            // --------------------------------------------------------
            // STATUS DO DOCE
            // --------------------------------------------------------

            if (nomeColuna == "colStatus")
            {
                string status =
                    e.Value?.ToString() ?? "";

                e.CellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                e.CellStyle.Font =
                    new Font(
                        "Segoe UI Semibold",
                        8.5F,
                        FontStyle.Bold);

                if (status.Equals(
                    "Ativo",
                    StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(32, 135, 72);

                    e.CellStyle.BackColor =
                        Color.FromArgb(232, 247, 238);
                }
                else
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(105, 105, 105);

                    e.CellStyle.BackColor =
                        Color.FromArgb(238, 238, 238);
                }
            }

            // --------------------------------------------------------
            // ESTOQUE
            // --------------------------------------------------------

            if (nomeColuna == "colEstoque")
            {
                if (!int.TryParse(
                    e.Value?.ToString(),
                    out int estoque))
                    return;

                e.CellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                e.CellStyle.Font =
                    new Font(
                        "Segoe UI Semibold",
                        8.5F,
                        FontStyle.Bold);

                if (estoque <= 0)
                {
                    e.Value = "Sem estoque";

                    e.CellStyle.ForeColor =
                        Color.FromArgb(190, 65, 65);

                    e.CellStyle.BackColor =
                        Color.FromArgb(252, 235, 235);
                }
                else if (estoque <= 5)
                {
                    e.Value =
                        $"{estoque} estoque baixo";

                    e.CellStyle.ForeColor =
                        Color.FromArgb(180, 110, 25);

                    e.CellStyle.BackColor =
                        Color.FromArgb(255, 246, 226);
                }
                else
                {
                    e.Value =
                        estoque.ToString();

                    e.CellStyle.ForeColor =
                        Color.FromArgb(65, 65, 65);

                    e.CellStyle.BackColor =
                        Color.White;
                }
            }

            // --------------------------------------------------------
            // DESTAQUE
            // --------------------------------------------------------

            if (nomeColuna == "colIsFeatured")
            {
                bool destaque =
                    string.Equals(
                        e.Value?.ToString(),
                        "Sim",
                        StringComparison.OrdinalIgnoreCase);

                e.CellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                e.CellStyle.Font =
                    new Font(
                        "Segoe UI Semibold",
                        8.5F,
                        FontStyle.Bold);

                if (destaque)
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(171, 117, 40);

                    e.CellStyle.BackColor =
                        Color.FromArgb(255, 247, 225);
                }
                else
                {
                    e.CellStyle.ForeColor =
                        Color.FromArgb(145, 135, 130);
                }
            }

            // --------------------------------------------------------
            // PREÇO
            // --------------------------------------------------------

            if (nomeColuna == "colPreco")
            {
                e.CellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

                e.CellStyle.Font =
                    new Font(
                        "Segoe UI Semibold",
                        8.5F,
                        FontStyle.Bold);

                e.CellStyle.ForeColor =
                    Color.FromArgb(75, 60, 52);
            }
        }

        // ============================================================
        // PERMISSÕES
        // ============================================================

        private void ConfigurarPermissoes()
        {
            bool isAdmin =
                SessionManager.Instance.IsAdmin;

            btnNovo.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            if (_doceService == null ||
                _categoriasService == null)
                return;

            try
            {
                btnAtualizar.Enabled = false;

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

                AtualizarCabecalho();

                PopularGrid(_todosDoces);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar os doces:\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                btnAtualizar.Enabled = true;
            }
        }

        // ============================================================
        // CABEÇALHO
        // ============================================================

        private void AtualizarCabecalho()
        {
            int quantidade =
                _todosDoces.Count;

            lblSubtitulo.Text =
                $"{quantidade} produto" +
                (quantidade == 1 ? "" : "s") +
                " cadastrado" +
                (quantidade == 1 ? "" : "s");
        }

        // ============================================================
        // POPULAR GRID
        // ============================================================

        private void PopularGrid(
            IEnumerable<DoceResponseDto> doces)
        {
            var lista =
                doces.ToList();

            gridBanco.Rows.Clear();

            foreach (var doce in lista)
            {
                int rowIndex =
                    gridBanco.Rows.Add(
                        doce.Id,
                        doce.Title,
                        string.IsNullOrWhiteSpace(
                            doce.CategoryName)
                            ? "Sem categoria"
                            : doce.CategoryName,
                        doce.Preco.ToString("C2"),
                        doce.QuantidadeEstoque,
                        doce.IsAtivo
                            ? "Ativo"
                            : "Inativo",
                        doce.IsFeatured
                            ? "Sim"
                            : "Não",
                        doce.CreatedAt
                            .ToLocalTime()
                            .ToString("dd/MM/yyyy"));

                gridBanco.Rows[rowIndex].Tag =
                    doce.Id;
            }

            lblResultados.Text =
                $"{lista.Count} resultado" +
                (lista.Count == 1 ? "" : "s");
        }

        // ============================================================
        // PESQUISA
        // ============================================================

        private void FiltrarDoces()
        {
            string termo =
                txtPesquisa.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                PopularGrid(_todosDoces);
                return;
            }

            var filtrados =
                _todosDoces
                    .Where(d =>
                        (d.Title ?? "")
                            .Contains(
                                termo,
                                StringComparison.OrdinalIgnoreCase)
                        ||
                        (d.CategoryName ?? "")
                            .Contains(
                                termo,
                                StringComparison.OrdinalIgnoreCase))
                    .ToList();

            PopularGrid(filtrados);
        }

        private void btnPesquisar_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarDoces();
        }

        private void txtPesquisa_TextChanged(
            object? sender,
            EventArgs e)
        {
            FiltrarDoces();
        }

        // ============================================================
        // OBTER DOCE SELECIONADO
        // ============================================================

        private DoceResponseDto? ObterDoceSelecionado()
        {
            if (gridBanco.SelectedRows.Count == 0)
                return null;

            DataGridViewRow row =
                gridBanco.SelectedRows[0];

            if (row.Cells["colId"].Value == null)
                return null;

            if (!int.TryParse(
                row.Cells["colId"].Value.ToString(),
                out int id))
                return null;

            return _todosDoces
                .FirstOrDefault(
                    d => d.Id == id);
        }

        // ============================================================
        // NOVO DOCE
        // ============================================================

        private async void btnNovo_Click(
            object? sender,
            EventArgs e)
        {
            if (_categorias.Count == 0)
            {
                MessageBox.Show(
                    "Nenhuma categoria foi encontrada.\n\n" +
                    "Cadastre uma categoria antes de criar um doce.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var form =
                new DoceFormDialog(_categorias);

            if (form.ShowDialog(this)
                != DialogResult.OK)
                return;

            if (form.DoceDto == null)
                return;

            if (_doceService == null)
                return;

            var resultado =
                await _doceService.CreateAsync(
                    form.DoceDto);

            if (resultado.Success)
            {
                MessageBox.Show(
                    "Doce criado com sucesso!",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show(
                    resultado.ErrorMessage,
                    "Não foi possível salvar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EDITAR DOCE
        // ============================================================

        private async void btnEditar_Click(
            object? sender,
            EventArgs e)
        {
            var doce =
                ObterDoceSelecionado();

            if (doce == null)
            {
                MessageBox.Show(
                    "Selecione um doce para editar.",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_categorias.Count == 0)
            {
                MessageBox.Show(
                    "Não foi possível carregar as categorias.",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var form =
                new DoceFormDialog(
                    _categorias,
                    doce);

            if (form.ShowDialog(this)
                != DialogResult.OK)
                return;

            if (form.UpdateDto == null)
                return;

            if (_doceService == null)
                return;

            var resultado =
                await _doceService.UpdateAsync(
                    doce.Id,
                    form.UpdateDto);

            if (resultado.Success)
            {
                MessageBox.Show(
                    "Doce atualizado com sucesso!",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show(
                    resultado.ErrorMessage,
                    "Não foi possível atualizar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EXCLUIR DOCE
        // ============================================================

        private async void btnExcluir_Click(
            object? sender,
            EventArgs e)
        {
            var doce =
                ObterDoceSelecionado();

            if (doce == null)
            {
                MessageBox.Show(
                    "Selecione um doce para excluir.",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirmacao =
                MessageBox.Show(
                    $"Deseja realmente excluir o doce \"{doce.Title}\"?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            if (_doceService == null)
                return;

            var resultado =
                await _doceService.DeleteAsync(
                    doce.Id);

            if (resultado.Success)
            {
                MessageBox.Show(
                    "Doce excluído com sucesso!",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show(
                    resultado.ErrorMessage,
                    "Não foi possível excluir",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ATUALIZAR
        // ============================================================

        private async void btnAtualizar_Click(
            object? sender,
            EventArgs e)
        {
            await CarregarDadosAsync();
        }
    }
}

