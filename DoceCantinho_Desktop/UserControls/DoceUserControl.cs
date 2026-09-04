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

        private async void DoceUserControl_Load(object? sender, EventArgs e)
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
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CONFIGURAR GRID
        // ============================================================

        private void ConfigurarGrid()
        {
            gridBanco.AutoGenerateColumns = false;

            gridBanco.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBanco.MultiSelect = false;

            gridBanco.ReadOnly = true;

            gridBanco.AllowUserToAddRows = false;
            gridBanco.AllowUserToDeleteRows = false;

            gridBanco.RowTemplate.Height = 65;

            try
            {
                DoceTheme.AplicarEstiloGrid(gridBanco);
            }
            catch
            {
                // Caso o tema tenha alguma configuração incompatível,
                // o grid continua funcionando normalmente.
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
                isAdmin = SessionManager.Instance.IsAdmin;
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
            if (_doceService == null || _categoriasService == null)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                var tarefaDoces = _doceService.GetAllAsync();
                var tarefaCategorias = _categoriasService.GetAllAsync();

                await Task.WhenAll(tarefaDoces, tarefaCategorias);

                _todosDoces = tarefaDoces.Result ?? new List<DoceResponseDto>();
                _categorias = tarefaCategorias.Result ?? new List<CategoriaResponseDto>();

                PopularGrid(_todosDoces);

                lblQuantidade.Text =
                    $"{_todosDoces.Count} produto{(_todosDoces.Count == 1 ? "" : "s")} cadastrado{(_todosDoces.Count == 1 ? "" : "s")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar os doces da API.\n\n{ex.Message}",
                    "Erro ao carregar dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // POPULAR GRID
        // ============================================================

        private void PopularGrid(List<DoceResponseDto> doces)
        {
            gridBanco.Rows.Clear();

            foreach (var doce in doces)
            {
                string status = ObterStatus(doce);

                int indice = gridBanco.Rows.Add(
                    null,
                    doce.Id,
                    doce.Title ?? string.Empty,
                    doce.CategoryName ?? string.Empty,
                    doce.Preco.ToString("C2"),
                    doce.QuantidadeEstoque,
                    status,
                    "Editar",
                    "Excluir"
                );

                // Carregar imagem sem travar a tela
                _ = CarregarImagemAsync(
                    indice,
                    doce.CoverImageUrl
                );
            }

            lblResultados.Text =
                $"{doces.Count} resultado{(doces.Count == 1 ? "" : "s")}";
        }

        // ============================================================
        // DEFINIR STATUS
        // ============================================================

        private string ObterStatus(DoceResponseDto doce)
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
                using HttpClient client = new HttpClient();

                byte[] bytes =
                    await client.GetByteArrayAsync(imageUrl);

                using var stream =
                    new System.IO.MemoryStream(bytes);

                using var imagemOriginal =
                    Image.FromStream(stream);

                Image imagem =
                    new Bitmap(imagemOriginal);

                if (indiceLinha >= 0 &&
                    indiceLinha < gridBanco.Rows.Count)
                {
                    gridBanco.Invoke(new Action(() =>
                    {
                        if (indiceLinha < gridBanco.Rows.Count)
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
                // Se uma imagem falhar, apenas deixa a célula vazia.
            }
        }

        // ============================================================
        // PESQUISAR
        // ============================================================

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FiltrarDoces();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarDoces();
        }

        private void FiltrarDoces()
        {
            string termo =
                txtPesquisa.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                PopularGrid(_todosDoces);
                return;
            }

            var filtrados = _todosDoces
                .Where(d =>
                    (!string.IsNullOrEmpty(d.Title) &&
                     d.Title.Contains(
                         termo,
                         StringComparison.OrdinalIgnoreCase))

                    ||

                    (!string.IsNullOrEmpty(d.CategoryName) &&
                     d.CategoryName.Contains(
                         termo,
                         StringComparison.OrdinalIgnoreCase))
                )
                .ToList();

            PopularGrid(filtrados);
        }

        // ============================================================
        // OBTER DOCE SELECIONADO
        // ============================================================

        private DoceResponseDto? ObterDoceSelecionado()
        {
            if (gridBanco.SelectedRows.Count == 0)
                return null;

            var linha = gridBanco.SelectedRows[0];

            if (linha.Cells["colId"].Value == null)
                return null;

            int id = Convert.ToInt32(
                linha.Cells["colId"].Value
            );

            return _todosDoces
                .FirstOrDefault(d => d.Id == id);
        }

        // ============================================================
        // NOVO DOCE
        // ============================================================

        private async void btnNovo_Click(object sender, EventArgs e)
        {
            if (_doceService == null)
                return;

            using var form =
                new DoceFormDialog(_categorias, null);

            if (form.ShowDialog() != DialogResult.OK)
                return;

            if (form.DoceDto == null)
                return;

            try
            {
                var (success, _, error) =
                    await _doceService.CreateAsync(form.DoceDto);

                if (success)
                {
                    MessageBox.Show(
                        "Doce criado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        error ?? "Não foi possível criar o doce.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EDITAR
        // ============================================================

        private async Task EditarDoceAsync()
        {
            if (_doceService == null)
                return;

            var doce = ObterDoceSelecionado();

            if (doce == null)
            {
                MessageBox.Show(
                    "Selecione um doce para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var form =
                new DoceFormDialog(_categorias, doce);

            if (form.ShowDialog() != DialogResult.OK)
                return;

            if (form.UpdateDto == null)
                return;

            try
            {
                var (success, _, error) =
                    await _doceService.UpdateAsync(
                        doce.Id,
                        form.UpdateDto
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Doce atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        error ?? "Não foi possível atualizar o doce.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // EXCLUIR
        // ============================================================

        private async Task ExcluirDoceAsync()
        {
            if (_doceService == null)
                return;

            var doce = ObterDoceSelecionado();

            if (doce == null)
            {
                MessageBox.Show(
                    "Selecione um doce para excluir.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var resposta = MessageBox.Show(
                $"Deseja realmente excluir o doce:\n\n{doce.Title}?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                var (success, error) =
                    await _doceService.DeleteAsync(doce.Id);

                if (success)
                {
                    MessageBox.Show(
                        "Doce excluído com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        error ?? "Não foi possível excluir o doce.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

            gridBanco.Rows[e.RowIndex].Selected = true;

            string nomeColuna =
                gridBanco.Columns[e.ColumnIndex].Name;

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