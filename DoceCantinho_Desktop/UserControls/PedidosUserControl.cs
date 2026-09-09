using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop1.Forms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class PedidosUserControl : UserControl
    {
        // ============================================================
        // SERVIÇO
        // ============================================================

        private PedidosApiService? _pedidosService;

        // ============================================================
        // DADOS
        // ============================================================

        private List<PedidoResponseDto> _pedidos = new();

        // ============================================================
        // AVISO VISUAL
        // ============================================================

        private Panel? _painelAviso;
        private Label? _lblAviso;

        private System.Windows.Forms.Timer? _timerAviso;

        // ============================================================
        // BOTÃO PDF
        // ============================================================

        private Button? _btnExportarPdf;

        // ============================================================
        // PERMISSÕES
        // ============================================================

        private void ConfigurarPermissoes()
        {
            bool isAdmin =
                SessionManager.Instance.IsAdmin;

            // --------------------------------------------------------
            // NOVO PEDIDO
            // --------------------------------------------------------

            btnNovo.Visible =
                isAdmin;

            // --------------------------------------------------------
            // AÇÕES
            // --------------------------------------------------------

            colAcoes.Visible =
                isAdmin;
        }

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public PedidosUserControl()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                ConfigurarTabela();

                ConfigurarPermissoes();

                CriarBotaoExportarPdf();
            }
        }

        // ============================================================
        // CONFIGURAÇÃO DA TABELA
        // ============================================================

        private void ConfigurarTabela()
        {
            dgvPedidos.AutoGenerateColumns =
                false;

            // --------------------------------------------------------
            // COLUNAS
            // --------------------------------------------------------

            colNumero.DataPropertyName =
                "Id";

            colCliente.DataPropertyName =
                "NomeCliente";

            colData.DataPropertyName =
                "CreatedAt";

            colData.DefaultCellStyle.Format =
                "dd/MM/yyyy HH\\:mm";

            colProdutos.DataPropertyName =
                "Produtos";

            colValor.DataPropertyName =
                "Total";

            colValor.DefaultCellStyle.Format =
                "C2";

            colPagamento.DataPropertyName =
                "PaymentMethod";

            colStatus.DataPropertyName =
                "Status";

            colAcoes.DataPropertyName =
                string.Empty;

            // --------------------------------------------------------
            // COLUNA AÇÕES
            // --------------------------------------------------------

            colAcoes.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.None;

            colAcoes.Width =
                160;

            colAcoes.HeaderText =
                "AÇÕES";

            colAcoes.ReadOnly =
                true;

            // --------------------------------------------------------
            // CONFIGURAÇÃO GERAL
            // --------------------------------------------------------

            dgvPedidos.AllowUserToAddRows =
                false;

            dgvPedidos.AllowUserToDeleteRows =
                false;

            dgvPedidos.AllowUserToResizeRows =
                false;

            dgvPedidos.ReadOnly =
                true;

            dgvPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.MultiSelect =
                false;

            dgvPedidos.RowHeadersVisible =
                false;

            // --------------------------------------------------------
            // COR NORMAL
            // --------------------------------------------------------

            dgvPedidos.DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgvPedidos.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    55,
                    39,
                    34);

            dgvPedidos.RowsDefaultCellStyle.BackColor =
                Color.White;

            dgvPedidos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(
                    250,
                    248,
                    246);

            // --------------------------------------------------------
            // EVENTO DE PINTURA
            // --------------------------------------------------------

            dgvPedidos.CellPainting -=
                DgvPedidos_CellPainting;

            dgvPedidos.CellPainting +=
                DgvPedidos_CellPainting;

            // --------------------------------------------------------
            // EVENTO DE CLIQUE
            // --------------------------------------------------------

            dgvPedidos.CellMouseClick -=
                DgvPedidos_CellMouseClick;

            dgvPedidos.CellMouseClick +=
                DgvPedidos_CellMouseClick;
        }

        // ============================================================
        // BOTÃO EXPORTAR PDF
        // ============================================================

        private void CriarBotaoExportarPdf()
        {
            if (_btnExportarPdf != null)
                return;

            _btnExportarPdf =
                new Button
                {
                    Name =
                        "btnExportarPdf",

                    Text =
                        "↓  PDF",

                    Size =
                        new Size(
                            105,
                            38),

                    BackColor =
                        Color.FromArgb(
                            238,
                            230,
                            225),

                    ForeColor =
                        Color.FromArgb(
                            105,
                            78,
                            68),

                    FlatStyle =
                        FlatStyle.Flat,

                    Font =
                        new Font(
                            "Segoe UI",
                            9F,
                            FontStyle.Bold),

                    Cursor =
                        Cursors.Hand,

                    TabStop =
                        false
                };

            _btnExportarPdf.FlatAppearance.BorderColor =
                Color.FromArgb(
                    210,
                    190,
                    180);

            _btnExportarPdf.FlatAppearance.BorderSize =
                1;

            _btnExportarPdf.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            _btnExportarPdf.Click +=
                BtnExportarPdf_Click;

            _btnExportarPdf.MouseEnter +=
                BtnExportarPdf_MouseEnter;

            _btnExportarPdf.MouseLeave +=
                BtnExportarPdf_MouseLeave;

            pnlPrincipal.Controls.Add(
                _btnExportarPdf);

            ReposicionarBotaoPdf();

            _btnExportarPdf.BringToFront();
        }

        // ============================================================
        // HOVER PDF
        // ============================================================

        private void BtnExportarPdf_MouseEnter(
            object? sender,
            EventArgs e)
        {
            if (_btnExportarPdf == null)
                return;

            _btnExportarPdf.BackColor =
                Color.FromArgb(
                    226,
                    211,
                    202);
        }

        private void BtnExportarPdf_MouseLeave(
            object? sender,
            EventArgs e)
        {
            if (_btnExportarPdf == null)
                return;

            _btnExportarPdf.BackColor =
                Color.FromArgb(
                    238,
                    230,
                    225);
        }

        // ============================================================
        // POSICIONAR PDF
        // ============================================================

        private void ReposicionarBotaoPdf()
        {
            if (_btnExportarPdf == null)
                return;

            if (btnNovo.Visible)
            {
                _btnExportarPdf.Location =
                    new Point(
                        btnNovo.Left -
                        _btnExportarPdf.Width -
                        10,
                        btnNovo.Top);
            }
            else
            {
                _btnExportarPdf.Location =
                    new Point(
                        pnlPrincipal.ClientSize.Width -
                        _btnExportarPdf.Width -
                        15,
                        58);
            }

            _btnExportarPdf.BringToFront();
        }

        // ============================================================
        // EXPORTAR PDF
        // ============================================================

        private void BtnExportarPdf_Click(
            object? sender,
            EventArgs e)
        {
            if (_pedidos.Count == 0)
            {
                MostrarAviso(
                    "Não existem pedidos para exportar.",
                    true);

                return;
            }

            using SaveFileDialog dialog =
                new SaveFileDialog
                {
                    Title =
                        "Salvar relatório de pedidos",

                    Filter =
                        "Arquivo PDF (*.pdf)|*.pdf",

                    FileName =
                        $"Pedidos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",

                    DefaultExt =
                        "pdf",

                    AddExtension =
                        true,

                    OverwritePrompt =
                        true
                };

            if (dialog.ShowDialog(
                    FindForm())
                != DialogResult.OK)
            {
                return;
            }

            try
            {
                Cursor =
                    Cursors.WaitCursor;

                PedidosPdfService.Gerar(
                    _pedidos,
                    dialog.FileName);

                MostrarAviso(
                    "Relatório PDF gerado com sucesso.",
                    false);
            }
            catch (Exception ex)
            {
                MostrarAviso(
                    $"Não foi possível gerar o PDF: {ex.Message}",
                    true);
            }
            finally
            {
                Cursor =
                    Cursors.Default;
            }
        }

        // ============================================================
        // DESENHAR BOTÕES EDITAR / EXCLUIR
        // ============================================================

        private void DgvPedidos_CellPainting(
            object? sender,
            DataGridViewCellPaintingEventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex !=
                colAcoes.Index)
            {
                return;
            }

            e.PaintBackground(
                e.CellBounds,
                true);

            Rectangle area =
                e.CellBounds;

            int margem =
                5;

            int espacamento =
                5;

            int larguraBotao =
                (area.Width -
                 (margem * 2) -
                 espacamento) / 2;

            int alturaBotao =
                28;

            int posY =
                area.Y +
                ((area.Height -
                  alturaBotao) / 2);

            // --------------------------------------------------------
            // EDITAR
            // --------------------------------------------------------

            Rectangle rectEditar =
                new Rectangle(
                    area.X +
                    margem,
                    posY,
                    larguraBotao,
                    alturaBotao);

            // --------------------------------------------------------
            // EXCLUIR
            // --------------------------------------------------------

            Rectangle rectExcluir =
                new Rectangle(
                    rectEditar.Right +
                    espacamento,
                    posY,
                    larguraBotao,
                    alturaBotao);

            // --------------------------------------------------------
            // FUNDO EDITAR
            // --------------------------------------------------------

            using (var brushEditar =
                   new SolidBrush(
                       Color.FromArgb(
                           236,
                           219,
                           210)))
            using (var penEditar =
                   new Pen(
                       Color.FromArgb(
                           208,
                           126,
                           91)))
            {
                e.Graphics.FillRectangle(
                    brushEditar,
                    rectEditar);

                e.Graphics.DrawRectangle(
                    penEditar,
                    rectEditar);
            }

            // --------------------------------------------------------
            // FUNDO EXCLUIR
            // --------------------------------------------------------

            using (var brushExcluir =
                   new SolidBrush(
                       Color.FromArgb(
                           245,
                           225,
                           220)))
            using (var penExcluir =
                   new Pen(
                       Color.FromArgb(
                           190,
                           90,
                           75)))
            {
                e.Graphics.FillRectangle(
                    brushExcluir,
                    rectExcluir);

                e.Graphics.DrawRectangle(
                    penExcluir,
                    rectExcluir);
            }

            // --------------------------------------------------------
            // TEXTO EDITAR
            // --------------------------------------------------------

            using (var fonte =
                   new Font(
                       "Segoe UI",
                       8.5F,
                       FontStyle.Bold))
            using (var brush =
                   new SolidBrush(
                       Color.FromArgb(
                           145,
                           78,
                           53)))
            {
                e.Graphics.DrawString(
                    "Editar",
                    fonte,
                    brush,
                    rectEditar,
                    new StringFormat
                    {
                        Alignment =
                            StringAlignment.Center,

                        LineAlignment =
                            StringAlignment.Center
                    });
            }

            // --------------------------------------------------------
            // TEXTO EXCLUIR
            // --------------------------------------------------------

            using (var fonte =
                   new Font(
                       "Segoe UI",
                       8.5F,
                       FontStyle.Bold))
            using (var brush =
                   new SolidBrush(
                       Color.FromArgb(
                           165,
                           70,
                           60)))
            {
                e.Graphics.DrawString(
                    "Excluir",
                    fonte,
                    brush,
                    rectExcluir,
                    new StringFormat
                    {
                        Alignment =
                            StringAlignment.Center,

                        LineAlignment =
                            StringAlignment.Center
                    });
            }

            e.Handled =
                true;
        }

        // ============================================================
        // CLIQUE NOS BOTÕES
        // ============================================================

        private async void DgvPedidos_CellMouseClick(
            object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex !=
                colAcoes.Index)
            {
                return;
            }

            if (e.Button !=
                MouseButtons.Left)
            {
                return;
            }

            if (e.RowIndex >=
                dgvPedidos.Rows.Count)
            {
                return;
            }

            if (dgvPedidos.Rows[e.RowIndex]
                    .DataBoundItem
                is not PedidoResponseDto pedido)
            {
                return;
            }

            Rectangle cellBounds =
                dgvPedidos.GetCellDisplayRectangle(
                    e.ColumnIndex,
                    e.RowIndex,
                    false);

            int metade =
                cellBounds.Width / 2;

            // --------------------------------------------------------
            // EDITAR
            // --------------------------------------------------------

            if (e.X < metade)
            {
                EditarPedido(
                    pedido.Id);
            }
            else
            {
                await ExcluirPedidoAsync(
                    pedido);
            }
        }

        // ============================================================
        // EDITAR PEDIDO
        // ============================================================

        private void EditarPedido(
            int pedidoId)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAviso(
                    "Seu perfil não possui permissão para editar pedidos.",
                    true);

                return;
            }

            try
            {
                using var form =
                    new PedidoForm(
                        pedidoId);

                var resultado =
                    form.ShowDialog(
                        FindForm());

                if (resultado ==
                    DialogResult.OK)
                {
                    _ =
                        CarregarDadosAsync();
                }
            }
            catch (Exception ex)
            {
                MostrarAviso(
                    $"Não foi possível abrir o pedido para edição: {ex.Message}",
                    true);
            }
        }

        // ============================================================
        // EXCLUIR PEDIDO
        // ============================================================

        private async Task ExcluirPedidoAsync(
            PedidoResponseDto pedido)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAviso(
                    "Seu perfil não possui permissão para excluir pedidos.",
                    true);

                return;
            }

            // --------------------------------------------------------
            // CONFIRMAÇÃO
            // --------------------------------------------------------

            using (var confirmacao =
                new DoceCantinho.Desktop.Forms
                    .ConfirmarExclusaoForm(
                        "pedido",
                        $"#{pedido.Id}"))
            {
                var resultadoConfirmacao =
                    confirmacao.ShowDialog(
                        FindForm());

                if (resultadoConfirmacao !=
                    DialogResult.OK)
                {
                    return;
                }
            }

            // --------------------------------------------------------
            // EXCLUSÃO
            // --------------------------------------------------------

            try
            {
                if (_pedidosService == null)
                {
                    _pedidosService =
                        new PedidosApiService();
                }

                var resultado =
                    await _pedidosService
                        .DeleteAsync(
                            pedido.Id);

                if (resultado.Success)
                {
                    _pedidos =
                        _pedidos
                            .Where(
                                p =>
                                    p.Id !=
                                    pedido.Id)
                            .ToList();

                    AtualizarTabela(
                        _pedidos);

                    AtualizarContadores();

                    if (!string.IsNullOrWhiteSpace(
                        txtBuscar.Text))
                    {
                        AplicarFiltro();
                    }

                    MostrarAviso(
                        $"Pedido #{pedido.Id} excluído com sucesso.",
                        false);
                }
                else
                {
                    MostrarAviso(
                        string.IsNullOrWhiteSpace(
                            resultado.ErrorMessage)
                            ? "Não foi possível excluir o pedido."
                            : resultado.ErrorMessage,
                        true);
                }
            }
            catch (Exception ex)
            {
                MostrarAviso(
                    $"Ocorreu um erro ao excluir o pedido: {ex.Message}",
                    true);
            }
        }

        // ============================================================
        // AVISO VISUAL
        // ============================================================

        private void MostrarAviso(
            string mensagem,
            bool erro)
        {
            // --------------------------------------------------------
            // REMOVE TIMER ANTERIOR
            // --------------------------------------------------------

            if (_timerAviso != null)
            {
                _timerAviso.Stop();

                _timerAviso.Dispose();

                _timerAviso = null;
            }

            // --------------------------------------------------------
            // CRIA PAINEL
            // --------------------------------------------------------

            if (_painelAviso == null ||
                _painelAviso.IsDisposed)
            {
                _painelAviso =
                    new Panel
                    {
                        Name =
                            "painelAvisoPedido",

                        Size =
                            new Size(
                                360,
                                48),

                        Anchor =
                            AnchorStyles.Top |
                            AnchorStyles.Right,

                        Padding =
                            new Padding(
                                14,
                                0,
                                14,
                                0)
                    };

                _lblAviso =
                    new Label
                    {
                        Dock =
                            DockStyle.Fill,

                        TextAlign =
                            ContentAlignment.MiddleLeft,

                        Font =
                            new Font(
                                "Segoe UI Semibold",
                                9F,
                                FontStyle.Bold),

                        AutoEllipsis =
                            true
                    };

                _painelAviso.Controls.Add(
                    _lblAviso);

                Controls.Add(
                    _painelAviso);

                _painelAviso.BringToFront();
            }

            // --------------------------------------------------------
            // POSICIONAR
            // --------------------------------------------------------

            _painelAviso.Location =
                new Point(
                    Math.Max(
                        10,
                        Width -
                        _painelAviso.Width -
                        20),
                    20);

            // --------------------------------------------------------
            // TEXTO
            // --------------------------------------------------------

            if (_lblAviso != null)
            {
                _lblAviso.Text =
                    (erro
                        ? "⚠ "
                        : "✓ ") +
                    mensagem;

                _lblAviso.ForeColor =
                    erro
                        ? Color.FromArgb(
                            150,
                            65,
                            60)
                        : Color.FromArgb(
                            55,
                            120,
                            82);
            }

            // --------------------------------------------------------
            // COR
            // --------------------------------------------------------

            _painelAviso.BackColor =
                erro
                    ? Color.FromArgb(
                        250,
                        232,
                        228)
                    : Color.FromArgb(
                        231,
                        246,
                        236);

            _painelAviso.Visible =
                true;

            _painelAviso.BringToFront();

            // --------------------------------------------------------
            // TIMER
            // --------------------------------------------------------

            _timerAviso =
                new System.Windows.Forms.Timer
                {
                    Interval =
                        3500
                };

            _timerAviso.Tick +=
                TimerAviso_Tick;

            _timerAviso.Start();
        }

        // ============================================================
        // TIMER DO AVISO
        // ============================================================

        private void TimerAviso_Tick(
            object? sender,
            EventArgs e)
        {
            if (_timerAviso != null)
            {
                _timerAviso.Stop();

                _timerAviso.Dispose();

                _timerAviso = null;
            }

            if (_painelAviso != null)
            {
                _painelAviso.Visible =
                    false;
            }
        }

        // ============================================================
        // LOAD
        // ============================================================

        protected override void OnLoad(
            EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            _pedidosService =
                new PedidosApiService();

            ConfigurarEventos();

            ConfigurarPermissoes();

            ReposicionarBotaoPdf();

            _ =
                CarregarDadosAsync();
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            // --------------------------------------------------------
            // BUSCA
            // --------------------------------------------------------

            txtBuscar.TextChanged -=
                TxtBuscar_TextChanged;

            txtBuscar.TextChanged +=
                TxtBuscar_TextChanged;

            // --------------------------------------------------------
            // FILTROS
            // --------------------------------------------------------

            btnTodos.Click -=
                BtnTodos_Click;

            btnTodos.Click +=
                BtnTodos_Click;

            btnPendente.Click -=
                BtnPendente_Click;

            btnPendente.Click +=
                BtnPendente_Click;

            btnPreparo.Click -=
                BtnPreparo_Click;

            btnPreparo.Click +=
                BtnPreparo_Click;

            btnPronto.Click -=
                BtnPronto_Click;

            btnPronto.Click +=
                BtnPronto_Click;

            btnEntregue.Click -=
                BtnEntregue_Click;

            btnEntregue.Click +=
                BtnEntregue_Click;

            btnCancelado.Click -=
                BtnCancelado_Click;

            btnCancelado.Click +=
                BtnCancelado_Click;

            // --------------------------------------------------------
            // NOVO
            // --------------------------------------------------------

            btnNovo.Click -=
                BtnNovo_Click;

            btnNovo.Click +=
                BtnNovo_Click;

            // --------------------------------------------------------
            // DUPLO CLIQUE
            // --------------------------------------------------------

            dgvPedidos.CellDoubleClick -=
                DgvPedidos_CellDoubleClick;

            dgvPedidos.CellDoubleClick +=
                DgvPedidos_CellDoubleClick;
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            try
            {
                if (_pedidosService == null)
                {
                    _pedidosService =
                        new PedidosApiService();
                }

                var pedidos =
                    await _pedidosService
                        .GetAllAsync();

                _pedidos =
                    pedidos ??
                    new List<PedidoResponseDto>();

                AtualizarTabela(
                    _pedidos);

                AtualizarContadores();
            }
            catch (Exception ex)
            {
                MostrarAviso(
                    $"Não foi possível carregar os pedidos: {ex.Message}",
                    true);
            }
        }

        // ============================================================
        // ATUALIZAR TABELA
        // ============================================================

        private void AtualizarTabela(
            IEnumerable<PedidoResponseDto> pedidos)
        {
            var lista =
                new BindingList<PedidoResponseDto>(
                    pedidos.ToList());

            dgvPedidos.DataSource =
                null;

            dgvPedidos.DataSource =
                lista;

            if (colAcoes.Index >= 0)
            {
                dgvPedidos.InvalidateColumn(
                    colAcoes.Index);
            }

            ReposicionarBotaoPdf();
        }

        // ============================================================
        // CONTADORES
        // ============================================================

        private void AtualizarContadores()
        {
            int total =
                _pedidos.Count;

            int pendente =
                _pedidos.Count(
                    p =>
                        NormalizarStatus(
                            p.Status) ==
                        "pendente");

            int preparo =
                _pedidos.Count(
                    p =>
                        NormalizarStatus(
                            p.Status) ==
                        "preparo");

            int pronto =
                _pedidos.Count(
                    p =>
                        NormalizarStatus(
                            p.Status) ==
                        "pronto");

            int entregue =
                _pedidos.Count(
                    p =>
                        NormalizarStatus(
                            p.Status) ==
                        "entregue");

            int cancelado =
                _pedidos.Count(
                    p =>
                        NormalizarStatus(
                            p.Status) ==
                        "cancelado");

            btnTodos.Text =
                $"Todos  {total}";

            btnPendente.Text =
                $"Pendente  {pendente}";

            btnPreparo.Text =
                $"Em preparo  {preparo}";

            btnPronto.Text =
                $"Pronto  {pronto}";

            btnEntregue.Text =
                $"Entregue  {entregue}";

            btnCancelado.Text =
                $"Cancelado  {cancelado}";
        }

        // ============================================================
        // NORMALIZAR STATUS
        // ============================================================

        private string NormalizarStatus(
            string? status)
        {
            return (status ??
                    string.Empty)
                .Trim()
                .ToLowerInvariant()
                .Replace(
                    "í",
                    "i")
                .Replace(
                    "ó",
                    "o")
                .Replace(
                    "ã",
                    "a");
        }

        // ============================================================
        // BUSCA
        // ============================================================

        private void TxtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            string texto =
                txtBuscar.Text
                    .Trim()
                    .ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(
                texto))
            {
                AtualizarTabela(
                    _pedidos);

                return;
            }

            var filtrados =
                _pedidos
                    .Where(
                        p =>
                            (
                                p.NomeCliente ??
                                string.Empty
                            )
                            .ToLowerInvariant()
                            .Contains(texto)
                            ||
                            p.Id
                                .ToString()
                                .Contains(texto))
                    .ToList();

            AtualizarTabela(
                filtrados);
        }

        // ============================================================
        // FILTROS DE STATUS
        // ============================================================

        private void FiltrarStatus(
            string status)
        {
            var filtrados =
                _pedidos
                    .Where(
                        p =>
                            NormalizarStatus(
                                p.Status) ==
                            status)
                    .ToList();

            AtualizarTabela(
                filtrados);
        }

        private void BtnTodos_Click(
            object? sender,
            EventArgs e)
        {
            AtualizarTabela(
                _pedidos);
        }

        private void BtnPendente_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus(
                "pendente");
        }

        private void BtnPreparo_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus(
                "preparo");
        }

        private void BtnPronto_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus(
                "pronto");
        }

        private void BtnEntregue_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus(
                "entregue");
        }

        private void BtnCancelado_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus(
                "cancelado");
        }

        // ============================================================
        // NOVO PEDIDO
        // ============================================================

        private void BtnNovo_Click(
            object? sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAviso(
                    "Seu perfil não possui permissão para criar pedidos.",
                    true);

                return;
            }

            using var form =
                new PedidoForm();

            var resultado =
                form.ShowDialog(
                    FindForm());

            if (resultado ==
                DialogResult.OK)
            {
                _ =
                    CarregarDadosAsync();
            }
        }

        // ============================================================
        // DUPLO CLIQUE - DETALHES
        // ============================================================

        private async void DgvPedidos_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                dgvPedidos.Rows.Count)
            {
                return;
            }

            if (dgvPedidos.Rows[e.RowIndex]
                    .DataBoundItem
                is not PedidoResponseDto pedido)
            {
                return;
            }

            try
            {
                if (_pedidosService == null)
                {
                    _pedidosService =
                        new PedidosApiService();
                }

                Cursor =
                    Cursors.WaitCursor;

                var detalhes =
                    await _pedidosService
                        .GetByIdAsync(
                            pedido.Id);

                if (detalhes == null)
                {
                    MostrarAviso(
                        "Não foi possível carregar os detalhes do pedido.",
                        true);

                    return;
                }

                string produtos =
                    detalhes.Items.Count == 0
                        ? "Nenhum produto"
                        : string.Join(
                            Environment.NewLine,
                            detalhes.Items.Select(
                                i =>
                                    $"• {i.Nome} x{i.Quantidade} - {i.Subtotal:C2}"));

                MessageBox.Show(
                    $"Pedido #{detalhes.Id}\n\n" +
                    $"Cliente: {detalhes.NomeCliente}\n" +
                    $"Telefone: {detalhes.Telefone}\n\n" +
                    $"Produtos:\n{produtos}\n\n" +
                    $"Total: {detalhes.Total:C2}\n" +
                    $"Status: {detalhes.Status}",
                    "Detalhes do pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarAviso(
                    $"Erro ao carregar detalhes: {ex.Message}",
                    true);
            }
            finally
            {
                Cursor =
                    Cursors.Default;
            }
        }

        // ============================================================
        // REDIMENSIONAMENTO
        // ============================================================

        protected override void OnResize(
            EventArgs e)
        {
            base.OnResize(e);

            ReposicionarBotaoPdf();

            if (_painelAviso != null)
            {
                _painelAviso.Location =
                    new Point(
                        Math.Max(
                            10,
                            Width -
                            _painelAviso.Width -
                            20),
                        20);
            }
        }
    }
}