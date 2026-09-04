namespace DoceCantinho.Desktop1.UserControls
{
    partial class PedidosUserControl
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlPrincipal;
        private Guna.UI2.WinForms.Guna2Panel pnlCabecalho;
        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;
        private Guna.UI2.WinForms.Guna2Panel pnlStatus;

        private Label lblTitulo;
        private Label lblSubTitulo;

        private Guna.UI2.WinForms.Guna2Button btnNovoPedido;

        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;

        private Guna.UI2.WinForms.Guna2Button btnTodos;
        private Guna.UI2.WinForms.Guna2Button btnPendente;
        private Guna.UI2.WinForms.Guna2Button btnPreparo;
        private Guna.UI2.WinForms.Guna2Button btnPronto;
        private Guna.UI2.WinForms.Guna2Button btnEntregue;
        private Guna.UI2.WinForms.Guna2Button btnCancelado;

        private Label lblResultados;

        private Guna.UI2.WinForms.Guna2DataGridView dgvPedidos;

        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colProdutos;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewTextBoxColumn colPagamento;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAcoes;

        private Label lblTotalPedidos;
        private Label lblTotalPedidosValor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges edges1 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges2 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges3 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges4 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges5 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges6 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges7 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges8 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges9 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges10 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges edges11 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            System.Windows.Forms.DataGridViewCellStyle headerStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle rowStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle alternateStyle =
                new System.Windows.Forms.DataGridViewCellStyle();

            pnlPrincipal =
                new Guna.UI2.WinForms.Guna2Panel();

            pnlCabecalho =
                new Guna.UI2.WinForms.Guna2Panel();

            lblTitulo =
                new Label();

            lblSubTitulo =
                new Label();

            btnNovoPedido =
                new Guna.UI2.WinForms.Guna2Button();

            pnlFiltros =
                new Guna.UI2.WinForms.Guna2Panel();

            txtBuscar =
                new Guna.UI2.WinForms.Guna2TextBox();

            pnlStatus =
                new Guna.UI2.WinForms.Guna2Panel();

            btnTodos =
                new Guna.UI2.WinForms.Guna2Button();

            btnPendente =
                new Guna.UI2.WinForms.Guna2Button();

            btnPreparo =
                new Guna.UI2.WinForms.Guna2Button();

            btnPronto =
                new Guna.UI2.WinForms.Guna2Button();

            btnEntregue =
                new Guna.UI2.WinForms.Guna2Button();

            btnCancelado =
                new Guna.UI2.WinForms.Guna2Button();

            lblResultados =
                new Label();

            dgvPedidos =
                new Guna.UI2.WinForms.Guna2DataGridView();

            colNumero =
                new DataGridViewTextBoxColumn();

            colCliente =
                new DataGridViewTextBoxColumn();

            colData =
                new DataGridViewTextBoxColumn();

            colProdutos =
                new DataGridViewTextBoxColumn();

            colValor =
                new DataGridViewTextBoxColumn();

            colPagamento =
                new DataGridViewTextBoxColumn();

            colStatus =
                new DataGridViewTextBoxColumn();

            colAcoes =
                new DataGridViewTextBoxColumn();

            lblTotalPedidos =
                new Label();

            lblTotalPedidosValor =
                new Label();

            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlStatus.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();

            SuspendLayout();

            // ============================================================
            // PAINEL PRINCIPAL
            // ============================================================

            pnlPrincipal.BackColor =
                Color.FromArgb(247, 244, 241);

            pnlPrincipal.Controls.Add(
                dgvPedidos);

            pnlPrincipal.Controls.Add(
                lblResultados);

            pnlPrincipal.Controls.Add(
                pnlFiltros);

            pnlPrincipal.Controls.Add(
                btnNovoPedido);

            pnlPrincipal.Controls.Add(
                pnlCabecalho);

            pnlPrincipal.Controls.Add(
                lblTotalPedidos);

            pnlPrincipal.Controls.Add(
                lblTotalPedidosValor);

            pnlPrincipal.CustomizableEdges =
                edges1;

            pnlPrincipal.Dock =
                DockStyle.Fill;

            pnlPrincipal.FillColor =
                Color.FromArgb(247, 244, 241);

            pnlPrincipal.Location =
                new Point(0, 0);

            pnlPrincipal.Name =
                "pnlPrincipal";

            pnlPrincipal.ShadowDecoration.CustomizableEdges =
                edges2;

            pnlPrincipal.Size =
                new Size(1075, 720);

            pnlPrincipal.TabIndex =
                0;

            // ============================================================
            // CABEÇALHO
            // ============================================================

            pnlCabecalho.BackColor =
                Color.Transparent;

            pnlCabecalho.Controls.Add(
                lblSubTitulo);

            pnlCabecalho.Controls.Add(
                lblTitulo);

            pnlCabecalho.CustomizableEdges =
                edges3;

            pnlCabecalho.FillColor =
                Color.Transparent;

            pnlCabecalho.Location =
                new Point(28, 22);

            pnlCabecalho.Name =
                "pnlCabecalho";

            pnlCabecalho.ShadowDecoration.CustomizableEdges =
                edges4;

            pnlCabecalho.Size =
                new Size(700, 65);

            pnlCabecalho.TabIndex =
                1;

            // ============================================================
            // TÍTULO
            // ============================================================

            lblTitulo.AutoSize =
                true;

            lblTitulo.BackColor =
                Color.Transparent;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            lblTitulo.ForeColor =
                Color.FromArgb(62, 45, 38);

            lblTitulo.Location =
                new Point(0, 0);

            lblTitulo.Name =
                "lblTitulo";

            lblTitulo.Size =
                new Size(95, 37);

            lblTitulo.TabIndex =
                0;

            lblTitulo.Text =
                "Pedidos";

            // ============================================================
            // SUBTÍTULO
            // ============================================================

            lblSubTitulo.AutoSize =
                true;

            lblSubTitulo.BackColor =
                Color.Transparent;

            lblSubTitulo.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            lblSubTitulo.ForeColor =
                Color.FromArgb(153, 137, 128);

            lblSubTitulo.Location =
                new Point(2, 39);

            lblSubTitulo.Name =
                "lblSubTitulo";

            lblSubTitulo.Size =
                new Size(175, 15);

            lblSubTitulo.TabIndex =
                1;

            lblSubTitulo.Text =
                "9 pedidos registrados";

            // ============================================================
            // NOVO PEDIDO
            // ============================================================

            btnNovoPedido.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnNovoPedido.Animated =
                true;

            btnNovoPedido.BackColor =
                Color.Transparent;

            btnNovoPedido.BorderRadius =
                8;

            btnNovoPedido.FillColor =
                Color.FromArgb(210, 119, 87);

            btnNovoPedido.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnNovoPedido.ForeColor =
                Color.White;

            btnNovoPedido.Location =
                new Point(937, 28);

            btnNovoPedido.Name =
                "btnNovoPedido";

            btnNovoPedido.ShadowDecoration.CustomizableEdges =
                edges5;

            btnNovoPedido.Size =
                new Size(110, 38);

            btnNovoPedido.TabIndex =
                2;

            btnNovoPedido.Text =
                "+  Novo Pedido";

            // ============================================================
            // PAINEL FILTROS
            // ============================================================

            pnlFiltros.BackColor =
                Color.White;

            pnlFiltros.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlFiltros.BorderRadius =
                12;

            pnlFiltros.Controls.Add(
                txtBuscar);

            pnlFiltros.Controls.Add(
                pnlStatus);

            pnlFiltros.CustomizableEdges =
                edges6;

            pnlFiltros.FillColor =
                Color.White;

            pnlFiltros.Location =
                new Point(28, 104);

            pnlFiltros.Name =
                "pnlFiltros";

            pnlFiltros.ShadowDecoration.CustomizableEdges =
                edges7;

            pnlFiltros.ShadowDecoration.Depth =
                4;

            pnlFiltros.ShadowDecoration.Enabled =
                true;

            pnlFiltros.Size =
                new Size(1019, 105);

            pnlFiltros.TabIndex =
                3;

            // ============================================================
            // BUSCA
            // ============================================================

            txtBuscar.BorderColor =
                Color.FromArgb(231, 224, 220);

            txtBuscar.BorderRadius =
                8;

            txtBuscar.Cursor =
                Cursors.IBeam;

            txtBuscar.DefaultText =
                "";

            txtBuscar.DisabledState.BorderColor =
                Color.FromArgb(230, 230, 230);

            txtBuscar.DisabledState.FillColor =
                Color.FromArgb(245, 245, 245);

            txtBuscar.DisabledState.ForeColor =
                Color.FromArgb(160, 160, 160);

            txtBuscar.FillColor =
                Color.FromArgb(250, 248, 246);

            txtBuscar.FocusedState.BorderColor =
                Color.FromArgb(210, 119, 87);

            txtBuscar.Font =
                new Font("Segoe UI", 8.5F);

            txtBuscar.ForeColor =
                Color.FromArgb(80, 64, 56);

            txtBuscar.HoverState.BorderColor =
                Color.FromArgb(220, 190, 179);

            txtBuscar.Location =
                new Point(16, 12);

            txtBuscar.Name =
                "txtBuscar";

            txtBuscar.PlaceholderForeColor =
                Color.FromArgb(165, 149, 140);

            txtBuscar.PlaceholderText =
                "🔍  Buscar por cliente ou número...";

            txtBuscar.SelectedText =
                "";

            txtBuscar.ShadowDecoration.CustomizableEdges =
                edges8;

            txtBuscar.Size =
                new Size(475, 38);

            txtBuscar.TabIndex =
                0;

            txtBuscar.TextOffset =
                new Point(5, 0);

            // ============================================================
            // STATUS
            // ============================================================

            pnlStatus.BackColor =
                Color.Transparent;

            pnlStatus.Controls.Add(
                btnTodos);

            pnlStatus.Controls.Add(
                btnPendente);

            pnlStatus.Controls.Add(
                btnPreparo);

            pnlStatus.Controls.Add(
                btnPronto);

            pnlStatus.Controls.Add(
                btnEntregue);

            pnlStatus.Controls.Add(
                btnCancelado);

            pnlStatus.CustomizableEdges =
                edges9;

            pnlStatus.FillColor =
                Color.Transparent;

            pnlStatus.Location =
                new Point(16, 56);

            pnlStatus.Name =
                "pnlStatus";

            pnlStatus.ShadowDecoration.CustomizableEdges =
                edges10;

            pnlStatus.Size =
                new Size(985, 38);

            pnlStatus.TabIndex =
                1;

            // ============================================================
            // TODOS
            // ============================================================

            btnTodos.BorderRadius =
                8;

            btnTodos.FillColor =
                Color.FromArgb(210, 119, 87);

            btnTodos.Font =
                new Font(
                    "Segoe UI Semibold",
                    7.5F,
                    FontStyle.Bold);

            btnTodos.ForeColor =
                Color.White;

            btnTodos.Location =
                new Point(0, 0);

            btnTodos.Name =
                "btnTodos";

            btnTodos.ShadowDecoration.CustomizableEdges =
                edges11;

            btnTodos.Size =
                new Size(105, 30);

            btnTodos.TabIndex =
                0;

            btnTodos.Text =
                "Todos  9";

            // ============================================================
            // PENDENTE
            // ============================================================

            btnPendente.BorderRadius =
                8;

            btnPendente.FillColor =
                Color.FromArgb(250, 245, 240);

            btnPendente.Font =
                new Font("Segoe UI", 7.5F);

            btnPendente.ForeColor =
                Color.FromArgb(117, 96, 84);

            btnPendente.Location =
                new Point(113, 0);

            btnPendente.Name =
                "btnPendente";

            btnPendente.Size =
                new Size(115, 30);

            btnPendente.TabIndex =
                1;

            btnPendente.Text =
                "Pendente  2";

            // ============================================================
            // EM PREPARO
            // ============================================================

            btnPreparo.BorderRadius =
                8;

            btnPreparo.FillColor =
                Color.FromArgb(250, 245, 240);

            btnPreparo.Font =
                new Font("Segoe UI", 7.5F);

            btnPreparo.ForeColor =
                Color.FromArgb(117, 96, 84);

            btnPreparo.Location =
                new Point(236, 0);

            btnPreparo.Name =
                "btnPreparo";

            btnPreparo.Size =
                new Size(125, 30);

            btnPreparo.TabIndex =
                2;

            btnPreparo.Text =
                "Em preparo  1";

            // ============================================================
            // PRONTO
            // ============================================================

            btnPronto.BorderRadius =
                8;

            btnPronto.FillColor =
                Color.FromArgb(250, 245, 240);

            btnPronto.Font =
                new Font("Segoe UI", 7.5F);

            btnPronto.ForeColor =
                Color.FromArgb(117, 96, 84);

            btnPronto.Location =
                new Point(369, 0);

            btnPronto.Name =
                "btnPronto";

            btnPronto.Size =
                new Size(105, 30);

            btnPronto.TabIndex =
                3;

            btnPronto.Text =
                "Pronto  1";

            // ============================================================
            // ENTREGUE
            // ============================================================

            btnEntregue.BorderRadius =
                8;

            btnEntregue.FillColor =
                Color.FromArgb(250, 245, 240);

            btnEntregue.Font =
                new Font("Segoe UI", 7.5F);

            btnEntregue.ForeColor =
                Color.FromArgb(117, 96, 84);

            btnEntregue.Location =
                new Point(482, 0);

            btnEntregue.Name =
                "btnEntregue";

            btnEntregue.Size =
                new Size(110, 30);

            btnEntregue.TabIndex =
                4;

            btnEntregue.Text =
                "Entregue  4";

            // ============================================================
            // CANCELADO
            // ============================================================

            btnCancelado.BorderRadius =
                8;

            btnCancelado.FillColor =
                Color.FromArgb(250, 245, 240);

            btnCancelado.Font =
                new Font("Segoe UI", 7.5F);

            btnCancelado.ForeColor =
                Color.FromArgb(117, 96, 84);

            btnCancelado.Location =
                new Point(600, 0);

            btnCancelado.Name =
                "btnCancelado";

            btnCancelado.Size =
                new Size(115, 30);

            btnCancelado.TabIndex =
                5;

            btnCancelado.Text =
                "Cancelado  1";

            // ============================================================
            // RESULTADOS
            // ============================================================

            lblResultados.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            lblResultados.AutoSize =
                true;

            lblResultados.BackColor =
                Color.Transparent;

            lblResultados.Font =
                new Font("Segoe UI", 7.5F);

            lblResultados.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblResultados.Location =
                new Point(928, 224);

            lblResultados.Name =
                "lblResultados";

            lblResultados.Size =
                new Size(119, 13);

            lblResultados.TabIndex =
                4;

            lblResultados.Text =
                "9 resultados";

            lblResultados.TextAlign =
                ContentAlignment.MiddleRight;

            // ============================================================
            // GRID
            // ============================================================

            alternateStyle.BackColor =
                Color.FromArgb(253, 251, 249);

            alternateStyle.Font =
                new Font("Segoe UI", 8F);

            alternateStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            alternateStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            alternateStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            dgvPedidos.AlternatingRowsDefaultCellStyle =
                alternateStyle;

            dgvPedidos.BackgroundColor =
                Color.White;

            dgvPedidos.BorderStyle =
                BorderStyle.None;

            dgvPedidos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPedidos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvPedidos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            dgvPedidos.ColumnHeadersHeight =
                42;

            dgvPedidos.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvPedidos.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colNumero,
                    colCliente,
                    colData,
                    colProdutos,
                    colValor,
                    colPagamento,
                    colStatus,
                    colAcoes
                });

            dgvPedidos.DefaultCellStyle =
                rowStyle;

            dgvPedidos.EnableHeadersVisualStyles =
                false;

            dgvPedidos.GridColor =
                Color.FromArgb(240, 234, 230);

            dgvPedidos.Location =
                new Point(28, 244);

            dgvPedidos.Name =
                "dgvPedidos";

            dgvPedidos.ReadOnly =
                true;

            dgvPedidos.RowHeadersVisible =
                false;

            dgvPedidos.RowTemplate.Height =
                58;

            dgvPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.Size =
                new Size(1019, 415);

            dgvPedidos.TabIndex =
                5;

            // ============================================================
            // TEMA GRID
            // ============================================================

            dgvPedidos.ThemeStyle.AlternatingRowsStyle.BackColor =
                Color.FromArgb(253, 251, 249);

            dgvPedidos.ThemeStyle.AlternatingRowsStyle.Font =
                new Font("Segoe UI", 8F);

            dgvPedidos.ThemeStyle.AlternatingRowsStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            dgvPedidos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            dgvPedidos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            dgvPedidos.ThemeStyle.BackColor =
                Color.White;

            dgvPedidos.ThemeStyle.GridColor =
                Color.FromArgb(240, 234, 230);

            dgvPedidos.ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(250, 247, 245);

            dgvPedidos.ThemeStyle.HeaderStyle.BorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvPedidos.ThemeStyle.HeaderStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    7F,
                    FontStyle.Bold);

            dgvPedidos.ThemeStyle.HeaderStyle.ForeColor =
                Color.FromArgb(139, 120, 111);

            dgvPedidos.ThemeStyle.HeaderStyle.Height =
                42;

            dgvPedidos.ThemeStyle.ReadOnly =
                true;

            dgvPedidos.ThemeStyle.RowsStyle.BackColor =
                Color.White;

            dgvPedidos.ThemeStyle.RowsStyle.BorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPedidos.ThemeStyle.RowsStyle.Font =
                new Font("Segoe UI", 8F);

            dgvPedidos.ThemeStyle.RowsStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            dgvPedidos.ThemeStyle.RowsStyle.Height =
                58;

            dgvPedidos.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            dgvPedidos.ThemeStyle.RowsStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            // ============================================================
            // HEADER
            // ============================================================

            headerStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            headerStyle.BackColor =
                Color.FromArgb(250, 247, 245);

            headerStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    7F,
                    FontStyle.Bold);

            headerStyle.ForeColor =
                Color.FromArgb(139, 120, 111);

            headerStyle.SelectionBackColor =
                Color.FromArgb(250, 247, 245);

            headerStyle.SelectionForeColor =
                Color.FromArgb(139, 120, 111);

            headerStyle.WrapMode =
                DataGridViewTriState.False;

            // ============================================================
            // LINHAS
            // ============================================================

            rowStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            rowStyle.BackColor =
                Color.White;

            rowStyle.Font =
                new Font("Segoe UI", 8F);

            rowStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            rowStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            rowStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            rowStyle.WrapMode =
                DataGridViewTriState.False;

            // ============================================================
            // COLUNA Nº PEDIDO
            // ============================================================

            colNumero.HeaderText =
                "Nº PEDIDO";

            colNumero.Name =
                "colNumero";

            colNumero.ReadOnly =
                true;

            colNumero.Width =
                105;

            // ============================================================
            // CLIENTE
            // ============================================================

            colCliente.HeaderText =
                "CLIENTE";

            colCliente.Name =
                "colCliente";

            colCliente.ReadOnly =
                true;

            colCliente.Width =
                150;

            // ============================================================
            // DATA
            // ============================================================

            colData.HeaderText =
                "DATA";

            colData.Name =
                "colData";

            colData.ReadOnly =
                true;

            colData.Width =
                105;

            // ============================================================
            // PRODUTOS
            // ============================================================

            colProdutos.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colProdutos.FillWeight =
                160;

            colProdutos.HeaderText =
                "PRODUTOS";

            colProdutos.Name =
                "colProdutos";

            colProdutos.ReadOnly =
                true;

            // ============================================================
            // VALOR
            // ============================================================

            colValor.HeaderText =
                "VALOR";

            colValor.Name =
                "colValor";

            colValor.ReadOnly =
                true;

            colValor.Width =
                100;

            // ============================================================
            // PAGAMENTO
            // ============================================================

            colPagamento.HeaderText =
                "PAGAMENTO";

            colPagamento.Name =
                "colPagamento";

            colPagamento.ReadOnly =
                true;

            colPagamento.Width =
                105;

            // ============================================================
            // STATUS
            // ============================================================

            colStatus.HeaderText =
                "STATUS";

            colStatus.Name =
                "colStatus";

            colStatus.ReadOnly =
                true;

            colStatus.Width =
                120;

            // ============================================================
            // AÇÕES
            // ============================================================

            colAcoes.HeaderText =
                "AÇÕES";

            colAcoes.Name =
                "colAcoes";

            colAcoes.ReadOnly =
                true;

            colAcoes.Width =
                105;

            // ============================================================
            // RODAPÉ
            // ============================================================

            lblTotalPedidos.AutoSize =
                true;

            lblTotalPedidos.BackColor =
                Color.Transparent;

            lblTotalPedidos.Font =
                new Font("Segoe UI", 7.5F);

            lblTotalPedidos.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblTotalPedidos.Location =
                new Point(28, 674);

            lblTotalPedidos.Name =
                "lblTotalPedidos";

            lblTotalPedidos.Text =
                "Total de pedidos:";

            // ============================================================
            // VALOR TOTAL
            // ============================================================

            lblTotalPedidosValor.AutoSize =
                true;

            lblTotalPedidosValor.BackColor =
                Color.Transparent;

            lblTotalPedidosValor.Font =
                new Font(
                    "Segoe UI Semibold",
                    7.5F,
                    FontStyle.Bold);

            lblTotalPedidosValor.ForeColor =
                Color.FromArgb(95, 75, 65);

            lblTotalPedidosValor.Location =
                new Point(116, 674);

            lblTotalPedidosValor.Name =
                "lblTotalPedidosValor";

            lblTotalPedidosValor.Text =
                "9";

            // ============================================================
            // FINALIZAÇÃO
            // ============================================================

            Controls.Add(
                pnlPrincipal);

            Name =
                "PedidosUserControl";

            Size =
                new Size(1075, 720);

            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();

            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();

            pnlFiltros.ResumeLayout(false);

            pnlStatus.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();

            ResumeLayout(false);
        }

        #endregion
    }
}