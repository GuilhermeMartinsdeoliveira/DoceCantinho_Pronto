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
    public partial class BlogUserControl : UserControl
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================
        private BlogApiService? _blogService;

        // ============================================================
        // DADOS
        // ============================================================
        private List<BlogPostResponseDto> _todosPosts = new();
        private List<BlogPostResponseDto> _postsFiltrados = new();

        // ============================================================
        // CONSTRUTOR
        // ============================================================
        public BlogUserControl()
        {
            InitializeComponent();

            ConfigurarPermissoes();
            ConfigurarGrid();
            ConfigurarEventos();
            AjustarLayout();
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

            // Garante que os botões fiquem sempre visíveis
            btnNovo.Visible = true;
            btnEditar.Visible = true;
            btnExcluir.Visible = true;
            btnAtualizar.Visible = true;

            // Habilitação das ações conforme o perfil
            btnNovo.Enabled = isAdmin;
            btnEditar.Enabled = isAdmin;
            btnExcluir.Enabled = isAdmin;
            btnAtualizar.Enabled = true;

            colEditar.Visible = isAdmin;
            colExcluir.Visible = isAdmin;
        }

        // ============================================================
        // CONFIGURAR GRID
        // ============================================================
        private void ConfigurarGrid()
        {
            dgvBlog.AutoGenerateColumns = false;
            dgvBlog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBlog.MultiSelect = false;
            dgvBlog.ReadOnly = true;
            dgvBlog.AllowUserToAddRows = false;
            dgvBlog.AllowUserToDeleteRows = false;
            dgvBlog.AllowUserToResizeRows = false;

            try
            {
                DoceTheme.AplicarEstiloGrid(dgvBlog);
            }
            catch
            {
                // Fallback seguro caso haja alguma customização
            }
        }

        // ============================================================
        // EVENTOS
        // ============================================================
        private void ConfigurarEventos()
        {
            Load -= BlogUserControl_Load;
            Load += BlogUserControl_Load;

            btnNovo.Click -= BtnNovo_Click;
            btnNovo.Click += BtnNovo_Click;

            btnEditar.Click -= BtnEditar_Click;
            btnEditar.Click += BtnEditar_Click;

            btnExcluir.Click -= BtnExcluir_Click;
            btnExcluir.Click += BtnExcluir_Click;

            btnAtualizar.Click -= BtnAtualizar_Click;
            btnAtualizar.Click += BtnAtualizar_Click;

            txtBusca.TextChanged -= TxtBusca_TextChanged;
            txtBusca.TextChanged += TxtBusca_TextChanged;

            dgvBlog.CellContentClick -= DgvBlog_CellContentClick;
            dgvBlog.CellContentClick += DgvBlog_CellContentClick;

            dgvBlog.CellDoubleClick -= DgvBlog_CellDoubleClick;
            dgvBlog.CellDoubleClick += DgvBlog_CellDoubleClick;

            dgvBlog.CellFormatting -= DgvBlog_CellFormatting;
            dgvBlog.CellFormatting += DgvBlog_CellFormatting;

            Resize -= BlogUserControl_Resize;
            Resize += BlogUserControl_Resize;

            pnlPrincipal.Resize -= BlogUserControl_Resize;
            pnlPrincipal.Resize += BlogUserControl_Resize;
        }

        // ============================================================
        // LOAD
        // ============================================================
        private async void BlogUserControl_Load(object? sender, EventArgs e)
        {
            if (DesignMode)
                return;

            try
            {
                AjustarLayout();
                _blogService = new BlogApiService();
                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao iniciar a tela de blog: {ex.Message}",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================
        private async Task CarregarDadosAsync()
        {
            if (_blogService == null)
                _blogService = new BlogApiService();

            try
            {
                Cursor = Cursors.WaitCursor;

                var (success, data, error) = await _blogService.GetAllAsync();

                if (success)
                {
                    _todosPosts = data ?? new List<BlogPostResponseDto>();
                    AplicarFiltros();
                }
                else
                {
                    MessageBox.Show(
                        string.IsNullOrWhiteSpace(error)
                            ? "Não foi possível carregar as publicações do blog."
                            : error,
                        "Blog",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar dados do blog: {ex.Message}",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // FILTROS
        // ============================================================
        private void TxtBusca_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string termo = txtBusca.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                _postsFiltrados = _todosPosts.ToList();
            }
            else
            {
                _postsFiltrados = _todosPosts
                    .Where(p =>
                        (!string.IsNullOrEmpty(p.Title) && p.Title.Contains(termo, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.Category) && p.Category.Contains(termo, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.AuthorName) && p.AuthorName.Contains(termo, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.Tags) && p.Tags.Contains(termo, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.Slug) && p.Slug.Contains(termo, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            PopularGrid(_postsFiltrados);
            AtualizarResumos();
        }

        // ============================================================
        // POPULAR GRID
        // ============================================================
        private void PopularGrid(List<BlogPostResponseDto> posts)
        {
            dgvBlog.Rows.Clear();

            foreach (var post in posts)
            {
                string dataFormatada = post.PublishedAt != default
                    ? post.PublishedAt.ToLocalTime().ToString("dd/MM/yyyy")
                    : string.Empty;

                string status = post.IsPublished ? "Publicado" : "Rascunho";
                string destaque = post.Featured ? "★ Sim" : "Não";

                int index = dgvBlog.Rows.Add(
                    post.Id,
                    post.Title,
                    post.Category,
                    post.AuthorName,
                    dataFormatada,
                    status,
                    destaque,
                    "Editar",
                    "Excluir"
                );

                dgvBlog.Rows[index].Tag = post;
            }
        }

        // ============================================================
        // ATUALIZAR RESUMOS
        // ============================================================
        private void AtualizarResumos()
        {
            int total = _todosPosts.Count;
            int publicados = _todosPosts.Count(p => p.IsPublished);
            int rascunhos = total - publicados;
            int destaques = _todosPosts.Count(p => p.Featured);

            lblResumo.Text = $"{total} post{(total == 1 ? "" : "s")} • {publicados} publicado{(publicados == 1 ? "" : "s")} • {rascunhos} rascunho{(rascunhos == 1 ? "" : "s")} • {destaques} destaque{(destaques == 1 ? "" : "s")}";

            int filtrados = _postsFiltrados.Count;
            lblResultados.Text = $"{filtrados} publicação{(filtrados == 1 ? "" : "ões")}";
        }

        // ============================================================
        // FORMATAÇÃO VISUAL DO GRID
        // ============================================================
        private void DgvBlog_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.CellStyle == null)
                return;

            string nomeColuna = dgvBlog.Columns[e.ColumnIndex].Name;

            // STATUS
            if (nomeColuna == "colStatus")
            {
                string status = e.Value?.ToString() ?? string.Empty;

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);

                if (status.Equals("Publicado", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(35, 145, 75);
                    e.CellStyle.BackColor = Color.FromArgb(232, 247, 238);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(170, 110, 40);
                    e.CellStyle.BackColor = Color.FromArgb(254, 246, 235);
                }
            }
            // DESTAQUE
            else if (nomeColuna == "colDestaque")
            {
                string destaque = e.Value?.ToString() ?? string.Empty;

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);

                if (destaque.Contains("Sim", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(190, 110, 20);
                    e.CellStyle.BackColor = Color.FromArgb(255, 248, 230);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(140, 130, 125);
                }
            }
            // BOTÃO EDITAR
            else if (nomeColuna == "colEditar")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.FromArgb(92, 46, 14);
            }
            // BOTÃO EXCLUIR
            else if (nomeColuna == "colExcluir")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.FromArgb(195, 55, 55);
            }
            // ALINHAMENTO DATA
            else if (nomeColuna == "colData")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ============================================================
        // CLIQUE NO GRID (AÇÕES)
        // ============================================================
        private async void DgvBlog_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            try
            {
                if (e.RowIndex >= dgvBlog.Rows.Count)
                    return;

                var post = ObterPostPorLinha(e.RowIndex);
                if (post == null)
                    return;

                string nomeColuna = dgvBlog.Columns[e.ColumnIndex].Name;

                if (nomeColuna == "colEditar")
                {
                    await EditarPostAsync(post);
                }
                else if (nomeColuna == "colExcluir")
                {
                    await ExcluirPostAsync(post);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao processar ação: {ex.Message}",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // DUPLO CLIQUE NA LINHA
        // ============================================================
        private async void DgvBlog_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!SessionManager.Instance.IsAdmin)
                return;

            var post = ObterPostPorLinha(e.RowIndex);
            if (post != null)
            {
                await EditarPostAsync(post);
            }
        }

        // ============================================================
        // NOVO POST
        // ============================================================
        private async void BtnNovo_Click(object? sender, EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MessageBox.Show(
                    "Seu perfil não possui permissão para criar publicações.",
                    "Permissão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using var dialog = new BlogFormDialog();
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            {
                await CarregarDadosAsync();
            }
        }

        // ============================================================
        // ATUALIZAR
        // ============================================================
        private async void BtnAtualizar_Click(object? sender, EventArgs e)
        {
            await CarregarDadosAsync();
        }

        // ============================================================
        // BOTÃO EDITAR (BARRA SUPERIOR)
        // ============================================================
        private async void BtnEditar_Click(object? sender, EventArgs e)
        {
            var post = ObterPostSelecionado();
            if (post == null)
            {
                MessageBox.Show(
                    "Selecione uma publicação na tabela para editar.",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            await EditarPostAsync(post);
        }

        // ============================================================
        // BOTÃO EXCLUIR / DELETAR (BARRA SUPERIOR)
        // ============================================================
        private async void BtnExcluir_Click(object? sender, EventArgs e)
        {
            var post = ObterPostSelecionado();
            if (post == null)
            {
                MessageBox.Show(
                    "Selecione uma publicação na tabela para excluir.",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            await ExcluirPostAsync(post);
        }

        // ============================================================
        // EDITAR POST
        // ============================================================
        private async Task EditarPostAsync(BlogPostResponseDto post)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MessageBox.Show(
                    "Seu perfil não possui permissão para editar publicações.",
                    "Permissão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using var dialog = new BlogFormDialog(post);
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            {
                await CarregarDadosAsync();
            }
        }

        // ============================================================
        // EXCLUIR POST
        // ============================================================
        private async Task ExcluirPostAsync(BlogPostResponseDto post)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MessageBox.Show(
                    "Seu perfil não possui permissão para excluir publicações.",
                    "Permissão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (_blogService == null)
                _blogService = new BlogApiService();

            // Confirmação com ConfirmarExclusaoForm
            using (var confirmar = new ConfirmarExclusaoForm("publicação", post.Title))
            {
                var resultado = confirmar.ShowDialog(FindForm());
                if (resultado != DialogResult.OK)
                    return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                var (success, error) = await _blogService.DeleteAsync(post.Id);

                if (success)
                {
                    await CarregarDadosAsync();
                    MessageBox.Show(
                        "Publicação excluída com sucesso!",
                        "Blog",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        string.IsNullOrWhiteSpace(error)
                            ? "Não foi possível excluir a publicação."
                            : error,
                        "Blog",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao excluir publicação: {ex.Message}",
                    "Blog",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ============================================================
        // AUXILIARES
        // ============================================================
        private BlogPostResponseDto? ObterPostSelecionado()
        {
            if (dgvBlog.CurrentRow == null || dgvBlog.CurrentRow.Index < 0)
                return null;

            return ObterPostPorLinha(dgvBlog.CurrentRow.Index);
        }

        private BlogPostResponseDto? ObterPostPorLinha(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvBlog.Rows.Count)
                return null;

            if (dgvBlog.Rows[rowIndex].Tag is BlogPostResponseDto post)
                return post;

            if (int.TryParse(dgvBlog.Rows[rowIndex].Cells["colId"].Value?.ToString(), out int id))
            {
                return _todosPosts.FirstOrDefault(p => p.Id == id);
            }

            return null;
        }

        // ============================================================
        // AJUSTE DINÂMICO DE LAYOUT
        // ============================================================
        private void BlogUserControl_Resize(object? sender, EventArgs e)
        {
            AjustarLayout();
        }

        private void AjustarLayout()
        {
            if (pnlPrincipal == null || txtBusca == null || btnNovo == null ||
                btnEditar == null || btnExcluir == null || btnAtualizar == null)
                return;

            int larguraPainel = pnlPrincipal.ClientSize.Width;
            if (larguraPainel <= 0)
                return;

            int margemDireita = larguraPainel - 28;
            int espacamento = 8;

            // Alinha os 4 botões perfeitamente à direita
            btnNovo.Left = margemDireita - btnNovo.Width;
            btnEditar.Left = btnNovo.Left - espacamento - btnEditar.Width;
            btnExcluir.Left = btnEditar.Left - espacamento - btnExcluir.Width;
            btnAtualizar.Left = btnExcluir.Left - espacamento - btnAtualizar.Width;

            // Garante que o campo de busca nunca passe por cima dos botões
            int limiteEsquerdaBotoes = btnAtualizar.Left - 16;
            int larguraDisponivelBusca = limiteEsquerdaBotoes - txtBusca.Left;

            if (larguraDisponivelBusca >= 180)
            {
                txtBusca.Width = Math.Min(420, larguraDisponivelBusca);
            }
            else
            {
                txtBusca.Width = Math.Max(140, larguraDisponivelBusca);
            }

            // Alinha o contador de resultados com a margem direita
            if (lblResultados != null)
            {
                lblResultados.Left = margemDireita - lblResultados.Width;
            }

            // Grid preenche a largura do painel
            if (dgvBlog != null)
            {
                dgvBlog.Width = Math.Max(300, larguraPainel - (dgvBlog.Left * 2));
            }
        }
    }
}