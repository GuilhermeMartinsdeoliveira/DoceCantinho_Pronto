using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class PedidosUserControl : UserControl
    {
        private PedidosApiService? _pedidosService;

        private List<PedidoResponseDto> _pedidos = new();

        public PedidosUserControl()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                ConfigurarTabela();
            }
        }

        // ============================================================
        // CONFIGURAÇÃO DA TABELA
        // ============================================================

        private void ConfigurarTabela()
        {
            dgvPedidos.AutoGenerateColumns = false;

            // Coluna Nº Pedido
            colNumero.DataPropertyName = "Id";

            // Cliente
            colCliente.DataPropertyName = "NomeCliente";

            // Data
            colData.DataPropertyName = "CreatedAt";
            colData.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // Produtos
            colProdutos.DataPropertyName = "Produtos";

            // Valor
            colValor.DataPropertyName = "Total";
            colValor.DefaultCellStyle.Format = "C2";

            // Pagamento
            colPagamento.DataPropertyName = "PaymentMethod";

            // Status
            colStatus.DataPropertyName = "Status";

            // Ações
            colAcoes.DataPropertyName = "";

            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AllowUserToResizeRows = false;

            dgvPedidos.ReadOnly = true;

            dgvPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.MultiSelect = false;

            dgvPedidos.RowHeadersVisible = false;

            dgvPedidos.AutoGenerateColumns = false;

            try
            {
                DoceTheme.AplicarEstiloGrid(dgvPedidos);
            }
            catch
            {
                // O Designer já possui o estilo visual.
            }
        }

        // ============================================================
        // LOAD
        // ============================================================

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            try
            {
                _pedidosService = new PedidosApiService();

                ConfigurarEventos();

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao inicializar a tela de pedidos:\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            txtBuscar.TextChanged -= TxtBuscar_TextChanged;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            btnTodos.Click -= BtnTodos_Click;
            btnTodos.Click += BtnTodos_Click;

            btnPendente.Click -= BtnPendente_Click;
            btnPendente.Click += BtnPendente_Click;

            btnPreparo.Click -= BtnPreparo_Click;
            btnPreparo.Click += BtnPreparo_Click;

            btnPronto.Click -= BtnPronto_Click;
            btnPronto.Click += BtnPronto_Click;

            btnEntregue.Click -= BtnEntregue_Click;
            btnEntregue.Click += BtnEntregue_Click;

            btnCancelado.Click -= BtnCancelado_Click;
            btnCancelado.Click += BtnCancelado_Click;

            btnNovoPedido.Click -= BtnNovoPedido_Click;
            btnNovoPedido.Click += BtnNovoPedido_Click;

            dgvPedidos.CellDoubleClick -= DgvPedidos_CellDoubleClick;
            dgvPedidos.CellDoubleClick += DgvPedidos_CellDoubleClick;
        }

        // ============================================================
        // CARREGAR PEDIDOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            if (_pedidosService == null)
                return;

            try
            {
                _pedidos =
                    await _pedidosService.GetAllAsync();

                AtualizarTabela(_pedidos);

                AtualizarContadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar os pedidos.\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ============================================================
        // ATUALIZAR TABELA
        // ============================================================

        private void AtualizarTabela(
            IEnumerable<PedidoResponseDto> pedidos)
        {
            var lista =
                pedidos.ToList();

            dgvPedidos.DataSource =
                new BindingList<PedidoResponseDto>(lista);

            lblResultados.Text =
                $"{lista.Count} resultado" +
                (lista.Count == 1 ? "" : "s");
        }

        // ============================================================
        // CONTADORES
        // ============================================================

        private void AtualizarContadores()
        {
            int total =
                _pedidos.Count;

            int pendentes =
                _pedidos.Count(p =>
                    NormalizarStatus(p.Status) == "pendente");

            int preparo =
                _pedidos.Count(p =>
                    NormalizarStatus(p.Status) == "preparo");

            int prontos =
                _pedidos.Count(p =>
                    NormalizarStatus(p.Status) == "pronto");

            int entregues =
                _pedidos.Count(p =>
                    NormalizarStatus(p.Status) == "entregue");

            int cancelados =
                _pedidos.Count(p =>
                    NormalizarStatus(p.Status) == "cancelado");

            btnTodos.Text =
                $"Todos  {total}";

            btnPendente.Text =
                $"Pendente  {pendentes}";

            btnPreparo.Text =
                $"Em preparo  {preparo}";

            btnPronto.Text =
                $"Pronto  {prontos}";

            btnEntregue.Text =
                $"Entregue  {entregues}";

            btnCancelado.Text =
                $"Cancelado  {cancelados}";

            lblTotalPedidosValor.Text =
                total.ToString();
        }

        // ============================================================
        // NORMALIZAR STATUS
        // ============================================================

        private string NormalizarStatus(string? status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return "";

            string valor =
                status
                    .Trim()
                    .ToLowerInvariant();

            if (valor.Contains("pend"))
                return "pendente";

            if (valor.Contains("preparo"))
                return "preparo";

            if (valor.Contains("pronto"))
                return "pronto";

            if (valor.Contains("entreg"))
                return "entregue";

            if (valor.Contains("cancel"))
                return "cancelado";

            return valor;
        }

        // ============================================================
        // PESQUISA
        // ============================================================

        private void TxtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                AtualizarTabela(_pedidos);
                return;
            }

            var resultado =
                _pedidos.Where(p =>
                    (p.NomeCliente ?? "")
                        .Contains(
                            texto,
                            StringComparison.OrdinalIgnoreCase)
                    ||
                    p.Id.ToString()
                        .Contains(
                            texto,
                            StringComparison.OrdinalIgnoreCase))
                .ToList();

            AtualizarTabela(resultado);
        }

        // ============================================================
        // FILTROS
        // ============================================================

        private void BtnTodos_Click(
            object? sender,
            EventArgs e)
        {
            AtualizarTabela(_pedidos);
        }

        private void BtnPendente_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus("pendente");
        }

        private void BtnPreparo_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus("preparo");
        }

        private void BtnPronto_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus("pronto");
        }

        private void BtnEntregue_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus("entregue");
        }

        private void BtnCancelado_Click(
            object? sender,
            EventArgs e)
        {
            FiltrarStatus("cancelado");
        }

        private void FiltrarStatus(
            string status)
        {
            var resultado =
                _pedidos
                    .Where(p =>
                        NormalizarStatus(p.Status) == status)
                    .ToList();

            AtualizarTabela(resultado);
        }

        // ============================================================
        // NOVO PEDIDO
        // ============================================================

       private void BtnNovoPedido_Click(object? sender, EventArgs e)
        {
            try
            {
                using var form = new DoceCantinho.Desktop1.Forms.PedidoForm();

                var resultado = form.ShowDialog(FindForm());

                if (resultado == DialogResult.OK)
                {
                    _ = CarregarDadosAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível abrir a tela de novo pedido.\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // DETALHES DO PEDIDO
        // ============================================================

        private async void DgvPedidos_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (_pedidosService == null)
                return;

            try
            {
                var pedido =
                    dgvPedidos.Rows[e.RowIndex]
                        .DataBoundItem as PedidoResponseDto;

                if (pedido == null)
                    return;

                var detalhes =
                    await _pedidosService
                        .GetByIdAsync(pedido.Id);

                if (detalhes == null)
                {
                    MessageBox.Show(
                        "Não foi possível carregar os detalhes do pedido.",
                        "Doce Cantinho",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Caso você tenha o formulário de detalhes:
                //
                // var modal =
                //     new DoceCantinho.Desktop1.Forms.PedidoForm(detalhes);
                //
                // modal.ShowDialog();

                MessageBox.Show(
                    $"Pedido #{pedido.Id}\n\n" +
                    $"Cliente: {pedido.NomeCliente}\n" +
                    $"Valor: {pedido.Total:C2}\n" +
                    $"Status: {pedido.Status}",
                    "Detalhes do Pedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir o pedido:\n\n{ex.Message}",
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}