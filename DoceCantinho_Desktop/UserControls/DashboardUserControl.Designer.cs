namespace DoceCantinho.Desktop1.UserControls
{
    partial class DashboardUserControl
    {
        private System.ComponentModel.IContainer components = null;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            pnldash = new Guna.UI2.WinForms.Guna2Panel();

            lblCarregando = new Label();

            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitulo = new Label();
            lblSubTitulo = new Label();

            cardDoces = new Guna.UI2.WinForms.Guna2Panel();
            cardDoceslblNumero = new Label();
            lblCardDocesTitulo = new Label();
            lblCardDocesIcone = new Label();
            lblCardDocesDescricao = new Label();

            cardCategorias = new Guna.UI2.WinForms.Guna2Panel();
            cardCategoriaslblNumero = new Label();
            lblCardCategoriasTitulo = new Label();
            lblCardCategoriasIcone = new Label();
            lblCardCategoriasDescricao = new Label();

            pnlCardDestaques = new Guna.UI2.WinForms.Guna2Panel();
            CardDestaquesValor = new Label();
            lblCardDestaquesTitulo = new Label();
            lblCardDestaquesIcone = new Label();
            lblCardDestaquesDescricao = new Label();

            cardPedidos = new Guna.UI2.WinForms.Guna2Panel();
            lblCardPedidosNumero = new Label();
            lblCardPedidosTitulo = new Label();
            lblCardPedidosIcone = new Label();
            lblCardPedidosDescricao = new Label();

            pnlVendas = new Guna.UI2.WinForms.Guna2Panel();
            lblVendasTitulo = new Label();
            lblVendasSubtitulo = new Label();
            lblVendasValor = new Label();
            lblVendasPeriodo = new Label();

            pnlChart = new Guna.UI2.WinForms.Guna2Panel();

            lblChart0 = new Label();
            lblChart1 = new Label();
            lblChart2 = new Label();
            lblChart3 = new Label();
            lblChart4 = new Label();

            barra1 = new Guna.UI2.WinForms.Guna2Panel();
            barra2 = new Guna.UI2.WinForms.Guna2Panel();
            barra3 = new Guna.UI2.WinForms.Guna2Panel();
            barra4 = new Guna.UI2.WinForms.Guna2Panel();
            barra5 = new Guna.UI2.WinForms.Guna2Panel();
            barra6 = new Guna.UI2.WinForms.Guna2Panel();

            lblSeg = new Label();
            lblTer = new Label();
            lblQua = new Label();
            lblQui = new Label();
            lblSex = new Label();
            lblSab = new Label();
            lblDom = new Label();

            pnlCategorias = new Guna.UI2.WinForms.Guna2Panel();

            lblCategoriasTitulo = new Label();
            lblCategoriasSubtitulo = new Label();

            lblCat1 = new Label();
            lblCat1Qtd = new Label();
            progressCat1 = new Guna.UI2.WinForms.Guna2ProgressBar();

            lblCat2 = new Label();
            lblCat2Qtd = new Label();
            progressCat2 = new Guna.UI2.WinForms.Guna2ProgressBar();

            lblCat3 = new Label();
            lblCat3Qtd = new Label();
            progressCat3 = new Guna.UI2.WinForms.Guna2ProgressBar();

            lblCat4 = new Label();
            lblCat4Qtd = new Label();
            progressCat4 = new Guna.UI2.WinForms.Guna2ProgressBar();

            lblUltimosDoces = new Label();
            lblUltimosSubtitulo = new Label();

            gridUltimosDoces = new Guna.UI2.WinForms.Guna2DataGridView();

            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoriaDoces = new DataGridViewTextBoxColumn();
            colReleaseYear = new DataGridViewTextBoxColumn();

            // CORREÇÃO:
            // Antes era DataGridViewCheckBoxColumn.
            // Como o código envia "Destaque" / "Normal",
            // precisa ser DataGridViewTextBoxColumn.
            colIsFeatured = new DataGridViewTextBoxColumn();

            colCreatedAt = new DataGridViewTextBoxColumn();

            btnVerTodos = new Guna.UI2.WinForms.Guna2Button();

            pnldash.SuspendLayout();
            pnlHeader.SuspendLayout();

            cardDoces.SuspendLayout();
            cardCategorias.SuspendLayout();
            pnlCardDestaques.SuspendLayout();
            cardPedidos.SuspendLayout();

            pnlVendas.SuspendLayout();
            pnlChart.SuspendLayout();

            pnlCategorias.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)gridUltimosDoces).BeginInit();

            SuspendLayout();

            // ============================================================
            // PNLDASH
            // ============================================================

            pnldash.BackColor = Color.FromArgb(247, 244, 241);
            pnldash.Controls.Add(lblCarregando);
            pnldash.Controls.Add(gridUltimosDoces);
            pnldash.Controls.Add(lblUltimosDoces);
            pnldash.Controls.Add(lblUltimosSubtitulo);
            pnldash.Controls.Add(btnVerTodos);
            pnldash.Controls.Add(pnlCategorias);
            pnldash.Controls.Add(pnlVendas);
            pnldash.Controls.Add(cardPedidos);
            pnldash.Controls.Add(pnlCardDestaques);
            pnldash.Controls.Add(cardCategorias);
            pnldash.Controls.Add(cardDoces);
            pnldash.Controls.Add(pnlHeader);

            pnldash.CustomizableEdges = customizableEdges1;
            pnldash.Dock = DockStyle.Fill;
            pnldash.FillColor = Color.FromArgb(247, 244, 241);
            pnldash.Location = new Point(0, 0);
            pnldash.Name = "pnldash";
            pnldash.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnldash.Size = new Size(1075, 720);
            pnldash.TabIndex = 0;

            // ============================================================
            // HEADER
            // ============================================================

            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblSubTitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.CustomizableEdges = customizableEdges3;
            pnlHeader.FillColor = Color.Transparent;
            pnlHeader.Location = new Point(28, 22);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlHeader.Size = new Size(1019, 62);
            pnlHeader.TabIndex = 1;

            // ============================================================
            // TITULO
            // ============================================================

            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font(
                "Segoe UI Semibold",
                19F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            lblTitulo.ForeColor = Color.FromArgb(62, 45, 38);
            lblTitulo.Location = new Point(0, 1);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(251, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Olá, Administrador";

            // ============================================================
            // SUBTITULO
            // ============================================================

            lblSubTitulo.AutoSize = true;
            lblSubTitulo.BackColor = Color.Transparent;
            lblSubTitulo.Font = new Font(
                "Segoe UI",
                8.5F,
                FontStyle.Regular,
                GraphicsUnit.Point);

            lblSubTitulo.ForeColor = Color.FromArgb(148, 130, 120);
            lblSubTitulo.Location = new Point(2, 39);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(390, 15);
            lblSubTitulo.TabIndex = 1;
            lblSubTitulo.Text = "Bem-vindo ao DoceCantinho";

            // ============================================================
            // CARD DOCES
            // ============================================================

            cardDoces.BackColor = Color.White;
            cardDoces.BorderColor = Color.FromArgb(237, 229, 224);
            cardDoces.BorderRadius = 14;

            cardDoces.Controls.Add(lblCardDocesDescricao);
            cardDoces.Controls.Add(lblCardDocesTitulo);
            cardDoces.Controls.Add(cardDoceslblNumero);
            cardDoces.Controls.Add(lblCardDocesIcone);

            cardDoces.CustomizableEdges = customizableEdges5;
            cardDoces.FillColor = Color.White;
            cardDoces.Location = new Point(28, 98);
            cardDoces.Name = "cardDoces";
            cardDoces.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cardDoces.ShadowDecoration.Depth = 5;
            cardDoces.ShadowDecoration.Enabled = true;
            cardDoces.Size = new Size(239, 91);
            cardDoces.TabIndex = 2;

            cardDoceslblNumero.AutoSize = true;
            cardDoceslblNumero.BackColor = Color.Transparent;
            cardDoceslblNumero.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Bold);

            cardDoceslblNumero.ForeColor = Color.FromArgb(62, 45, 38);
            cardDoceslblNumero.Location = new Point(17, 30);
            cardDoceslblNumero.Name = "cardDoceslblNumero";
            cardDoceslblNumero.Size = new Size(31, 37);
            cardDoceslblNumero.TabIndex = 0;
            cardDoceslblNumero.Text = "--";

            lblCardDocesTitulo.AutoSize = true;
            lblCardDocesTitulo.BackColor = Color.Transparent;
            lblCardDocesTitulo.Font = new Font(
                "Segoe UI Semibold",
                7.5F,
                FontStyle.Bold);

            lblCardDocesTitulo.ForeColor = Color.FromArgb(116, 96, 87);
            lblCardDocesTitulo.Location = new Point(18, 11);
            lblCardDocesTitulo.Name = "lblCardDocesTitulo";
            lblCardDocesTitulo.Text = "DOCES CADASTRADOS";

            lblCardDocesIcone.BackColor = Color.FromArgb(250, 234, 226);
            lblCardDocesIcone.Font = new Font(
                "Segoe UI Emoji",
                13F);

            lblCardDocesIcone.ForeColor = Color.FromArgb(210, 119, 87);
            lblCardDocesIcone.Location = new Point(192, 12);
            lblCardDocesIcone.Name = "lblCardDocesIcone";
            lblCardDocesIcone.Size = new Size(32, 32);
            lblCardDocesIcone.TabIndex = 2;
            lblCardDocesIcone.Text = "🍰";
            lblCardDocesIcone.TextAlign = ContentAlignment.MiddleCenter;

            lblCardDocesDescricao.AutoSize = true;
            lblCardDocesDescricao.BackColor = Color.Transparent;
            lblCardDocesDescricao.Font = new Font(
                "Segoe UI",
                7F);

            lblCardDocesDescricao.ForeColor = Color.FromArgb(157, 140, 131);
            lblCardDocesDescricao.Location = new Point(73, 62);
            lblCardDocesDescricao.Name = "lblCardDocesDescricao";
            lblCardDocesDescricao.Text = "produtos cadastrados";

            // ============================================================
            // CARD CATEGORIAS
            // ============================================================

            cardCategorias.BackColor = Color.White;
            cardCategorias.BorderColor = Color.FromArgb(237, 229, 224);
            cardCategorias.BorderRadius = 14;

            cardCategorias.Controls.Add(lblCardCategoriasDescricao);
            cardCategorias.Controls.Add(lblCardCategoriasTitulo);
            cardCategorias.Controls.Add(cardCategoriaslblNumero);
            cardCategorias.Controls.Add(lblCardCategoriasIcone);

            cardCategorias.FillColor = Color.White;
            cardCategorias.Location = new Point(284, 98);
            cardCategorias.Name = "cardCategorias";
            cardCategorias.ShadowDecoration.Depth = 5;
            cardCategorias.ShadowDecoration.Enabled = true;
            cardCategorias.Size = new Size(239, 91);
            cardCategorias.TabIndex = 3;

            cardCategoriaslblNumero.AutoSize = true;
            cardCategoriaslblNumero.BackColor = Color.Transparent;
            cardCategoriaslblNumero.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Bold);

            cardCategoriaslblNumero.ForeColor = Color.FromArgb(62, 45, 38);
            cardCategoriaslblNumero.Location = new Point(17, 30);
            cardCategoriaslblNumero.Name = "cardCategoriaslblNumero";
            cardCategoriaslblNumero.Text = "--";

            lblCardCategoriasTitulo.AutoSize = true;
            lblCardCategoriasTitulo.BackColor = Color.Transparent;
            lblCardCategoriasTitulo.Font = new Font(
                "Segoe UI Semibold",
                7.5F,
                FontStyle.Bold);

            lblCardCategoriasTitulo.ForeColor = Color.FromArgb(116, 96, 87);
            lblCardCategoriasTitulo.Location = new Point(18, 11);
            lblCardCategoriasTitulo.Name = "lblCardCategoriasTitulo";
            lblCardCategoriasTitulo.Text = "CATEGORIAS";

            lblCardCategoriasIcone.BackColor = Color.FromArgb(249, 242, 226);
            lblCardCategoriasIcone.Font = new Font(
                "Segoe UI Emoji",
                13F);

            lblCardCategoriasIcone.ForeColor = Color.FromArgb(190, 151, 77);
            lblCardCategoriasIcone.Location = new Point(192, 12);
            lblCardCategoriasIcone.Name = "lblCardCategoriasIcone";
            lblCardCategoriasIcone.Size = new Size(32, 32);
            lblCardCategoriasIcone.Text = "🏷";
            lblCardCategoriasIcone.TextAlign = ContentAlignment.MiddleCenter;

            lblCardCategoriasDescricao.AutoSize = true;
            lblCardCategoriasDescricao.BackColor = Color.Transparent;
            lblCardCategoriasDescricao.Font = new Font(
                "Segoe UI",
                7F);

            lblCardCategoriasDescricao.ForeColor = Color.FromArgb(157, 140, 131);
            lblCardCategoriasDescricao.Location = new Point(73, 62);
            lblCardCategoriasDescricao.Name = "lblCardCategoriasDescricao";
            lblCardCategoriasDescricao.Text = "categorias cadastradas";

            // ============================================================
            // CARD DESTAQUES
            // ============================================================

            pnlCardDestaques.BackColor = Color.White;
            pnlCardDestaques.BorderColor = Color.FromArgb(237, 229, 224);
            pnlCardDestaques.BorderRadius = 14;

            pnlCardDestaques.Controls.Add(lblCardDestaquesDescricao);
            pnlCardDestaques.Controls.Add(lblCardDestaquesTitulo);
            pnlCardDestaques.Controls.Add(CardDestaquesValor);
            pnlCardDestaques.Controls.Add(lblCardDestaquesIcone);

            pnlCardDestaques.FillColor = Color.White;
            pnlCardDestaques.Location = new Point(540, 98);
            pnlCardDestaques.Name = "pnlCardDestaques";
            pnlCardDestaques.ShadowDecoration.Depth = 5;
            pnlCardDestaques.ShadowDecoration.Enabled = true;
            pnlCardDestaques.Size = new Size(239, 91);
            pnlCardDestaques.TabIndex = 4;

            CardDestaquesValor.AutoSize = true;
            CardDestaquesValor.BackColor = Color.Transparent;
            CardDestaquesValor.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Bold);

            CardDestaquesValor.ForeColor = Color.FromArgb(62, 45, 38);
            CardDestaquesValor.Location = new Point(17, 30);
            CardDestaquesValor.Name = "CardDestaquesValor";
            CardDestaquesValor.Text = "--";

            lblCardDestaquesTitulo.AutoSize = true;
            lblCardDestaquesTitulo.BackColor = Color.Transparent;
            lblCardDestaquesTitulo.Font = new Font(
                "Segoe UI Semibold",
                7.5F,
                FontStyle.Bold);

            lblCardDestaquesTitulo.ForeColor = Color.FromArgb(116, 96, 87);
            lblCardDestaquesTitulo.Location = new Point(18, 11);
            lblCardDestaquesTitulo.Name = "lblCardDestaquesTitulo";
            lblCardDestaquesTitulo.Text = "EM DESTAQUE";

            lblCardDestaquesIcone.BackColor = Color.FromArgb(246, 239, 234);
            lblCardDestaquesIcone.Font = new Font(
                "Segoe UI Emoji",
                13F);

            lblCardDestaquesIcone.ForeColor = Color.FromArgb(143, 111, 91);
            lblCardDestaquesIcone.Location = new Point(192, 12);
            lblCardDestaquesIcone.Name = "lblCardDestaquesIcone";
            lblCardDestaquesIcone.Size = new Size(32, 32);
            lblCardDestaquesIcone.Text = "★";
            lblCardDestaquesIcone.TextAlign = ContentAlignment.MiddleCenter;

            lblCardDestaquesDescricao.AutoSize = true;
            lblCardDestaquesDescricao.BackColor = Color.Transparent;
            lblCardDestaquesDescricao.Font = new Font(
                "Segoe UI",
                7F);

            lblCardDestaquesDescricao.ForeColor = Color.FromArgb(157, 140, 131);
            lblCardDestaquesDescricao.Location = new Point(73, 62);
            lblCardDestaquesDescricao.Name = "lblCardDestaquesDescricao";
            lblCardDestaquesDescricao.Text = "produtos destacados";

            // ============================================================
            // CARD PEDIDOS
            // ============================================================

            cardPedidos.BackColor = Color.White;
            cardPedidos.BorderColor = Color.FromArgb(237, 229, 224);
            cardPedidos.BorderRadius = 14;

            cardPedidos.Controls.Add(lblCardPedidosDescricao);
            cardPedidos.Controls.Add(lblCardPedidosTitulo);
            cardPedidos.Controls.Add(lblCardPedidosNumero);
            cardPedidos.Controls.Add(lblCardPedidosIcone);

            cardPedidos.FillColor = Color.White;
            cardPedidos.Location = new Point(796, 98);
            cardPedidos.Name = "cardPedidos";
            cardPedidos.ShadowDecoration.Depth = 5;
            cardPedidos.ShadowDecoration.Enabled = true;
            cardPedidos.Size = new Size(251, 91);
            cardPedidos.TabIndex = 5;

            lblCardPedidosNumero.AutoSize = true;
            lblCardPedidosNumero.BackColor = Color.Transparent;
            lblCardPedidosNumero.Font = new Font(
                "Segoe UI Semibold",
                20F,
                FontStyle.Bold);

            lblCardPedidosNumero.ForeColor = Color.FromArgb(62, 45, 38);
            lblCardPedidosNumero.Location = new Point(17, 30);
            lblCardPedidosNumero.Name = "lblCardPedidosNumero";
            lblCardPedidosNumero.Text = "00";

            lblCardPedidosTitulo.AutoSize = true;
            lblCardPedidosTitulo.BackColor = Color.Transparent;
            lblCardPedidosTitulo.Font = new Font(
                "Segoe UI Semibold",
                7.5F,
                FontStyle.Bold);

            lblCardPedidosTitulo.ForeColor = Color.FromArgb(116, 96, 87);
            lblCardPedidosTitulo.Location = new Point(18, 11);
            lblCardPedidosTitulo.Name = "lblCardPedidosTitulo";
            lblCardPedidosTitulo.Text = "PEDIDOS HOJE";

            lblCardPedidosIcone.BackColor = Color.FromArgb(232, 244, 238);
            lblCardPedidosIcone.Font = new Font(
                "Segoe UI Symbol",
                14F,
                FontStyle.Bold);

            lblCardPedidosIcone.ForeColor = Color.FromArgb(89, 145, 119);
            lblCardPedidosIcone.Location = new Point(204, 12);
            lblCardPedidosIcone.Name = "lblCardPedidosIcone";
            lblCardPedidosIcone.Size = new Size(32, 32);
            lblCardPedidosIcone.Text = "◷";
            lblCardPedidosIcone.TextAlign = ContentAlignment.MiddleCenter;

            lblCardPedidosDescricao.AutoSize = true;
            lblCardPedidosDescricao.BackColor = Color.Transparent;
            lblCardPedidosDescricao.Font = new Font(
                "Segoe UI",
                7F);

            lblCardPedidosDescricao.ForeColor = Color.FromArgb(157, 140, 131);
            lblCardPedidosDescricao.Location = new Point(73, 62);
            lblCardPedidosDescricao.Name = "lblCardPedidosDescricao";
            lblCardPedidosDescricao.Text = "aguardando preparo";

            // ============================================================
            // VENDAS
            // ============================================================

            pnlVendas.BackColor = Color.White;
            pnlVendas.BorderColor = Color.FromArgb(237, 229, 224);
            pnlVendas.BorderRadius = 14;

            pnlVendas.Controls.Add(pnlChart);
            pnlVendas.Controls.Add(lblVendasPeriodo);
            pnlVendas.Controls.Add(lblVendasValor);
            pnlVendas.Controls.Add(lblVendasSubtitulo);
            pnlVendas.Controls.Add(lblVendasTitulo);

            pnlVendas.FillColor = Color.White;
            pnlVendas.Location = new Point(28, 207);
            pnlVendas.Name = "pnlVendas";
            pnlVendas.ShadowDecoration.Depth = 5;
            pnlVendas.ShadowDecoration.Enabled = true;
            pnlVendas.Size = new Size(655, 235);
            pnlVendas.TabIndex = 10;

            lblVendasTitulo.AutoSize = true;
            lblVendasTitulo.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            lblVendasTitulo.ForeColor = Color.FromArgb(62, 45, 38);
            lblVendasTitulo.Location = new Point(18, 15);
            lblVendasTitulo.Name = "lblVendasTitulo";
            lblVendasTitulo.Text = "Vendas dos últimos 7 dias";

            lblVendasSubtitulo.AutoSize = true;
            lblVendasSubtitulo.Font = new Font(
                "Segoe UI",
                7.5F);

            lblVendasSubtitulo.ForeColor = Color.FromArgb(153, 137, 128);
            lblVendasSubtitulo.Location = new Point(19, 35);
            lblVendasSubtitulo.Name = "lblVendasSubtitulo";
            lblVendasSubtitulo.Text = "Receita acumulada por dia";

            lblVendasValor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVendasValor.AutoSize = true;
            lblVendasValor.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            lblVendasValor.ForeColor = Color.FromArgb(210, 119, 87);
            lblVendasValor.Location = new Point(549, 15);
            lblVendasValor.Name = "lblVendasValor";
            lblVendasValor.Text = "R$ 0,00";

            lblVendasPeriodo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVendasPeriodo.AutoSize = true;
            lblVendasPeriodo.Font = new Font(
                "Segoe UI",
                7F);

            lblVendasPeriodo.ForeColor = Color.FromArgb(153, 137, 128);
            lblVendasPeriodo.Location = new Point(549, 35);
            lblVendasPeriodo.Name = "lblVendasPeriodo";
            lblVendasPeriodo.Text = "esta semana";

            // ============================================================
            // GRAFICO
            // ============================================================

            pnlChart.BackColor = Color.FromArgb(253, 251, 249);
            pnlChart.BorderRadius = 8;
            pnlChart.FillColor = Color.FromArgb(253, 251, 249);
            pnlChart.Location = new Point(18, 60);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(619, 158);
            pnlChart.TabIndex = 11;

            lblChart0.AutoSize = true;
            lblChart0.Font = new Font("Segoe UI", 6.5F);
            lblChart0.ForeColor = Color.FromArgb(170, 153, 144);
            lblChart0.Location = new Point(8, 128);
            lblChart0.Text = "R$ 0";

            lblChart1.AutoSize = true;
            lblChart1.Font = new Font("Segoe UI", 6.5F);
            lblChart1.ForeColor = Color.FromArgb(170, 153, 144);
            lblChart1.Location = new Point(8, 98);
            lblChart1.Text = "R$ 1k";

            lblChart2.AutoSize = true;
            lblChart2.Font = new Font("Segoe UI", 6.5F);
            lblChart2.ForeColor = Color.FromArgb(170, 153, 144);
            lblChart2.Location = new Point(8, 68);
            lblChart2.Text = "R$ 2k";

            lblChart3.AutoSize = true;
            lblChart3.Font = new Font("Segoe UI", 6.5F);
            lblChart3.ForeColor = Color.FromArgb(170, 153, 144);
            lblChart3.Location = new Point(8, 38);
            lblChart3.Text = "R$ 3k";

            lblChart4.AutoSize = true;
            lblChart4.Font = new Font("Segoe UI", 6.5F);
            lblChart4.ForeColor = Color.FromArgb(170, 153, 144);
            lblChart4.Location = new Point(8, 8);
            lblChart4.Text = "R$ 4k";

            // ============================================================
            // BARRAS
            // ============================================================

            ConfigurarBarra(barra1, new Point(115, 65), new Size(8, 63));
            ConfigurarBarra(barra2, new Point(190, 48), new Size(8, 80));
            ConfigurarBarra(barra3, new Point(265, 77), new Size(8, 51));
            ConfigurarBarra(barra4, new Point(340, 42), new Size(8, 86));
            ConfigurarBarra(barra5, new Point(415, 28), new Size(8, 100));
            ConfigurarBarra(barra6, new Point(490, 18), new Size(8, 110));

            // ============================================================
            // DIAS
            // ============================================================

            ConfigurarDia(lblSeg, "Seg", new Point(105, 137));
            ConfigurarDia(lblTer, "Ter", new Point(180, 137));
            ConfigurarDia(lblQua, "Qua", new Point(255, 137));
            ConfigurarDia(lblQui, "Qui", new Point(330, 137));
            ConfigurarDia(lblSex, "Sex", new Point(405, 137));
            ConfigurarDia(lblSab, "Sáb", new Point(480, 137));
            ConfigurarDia(lblDom, "Dom", new Point(555, 137));

            pnlChart.Controls.Add(lblChart0);
            pnlChart.Controls.Add(lblChart1);
            pnlChart.Controls.Add(lblChart2);
            pnlChart.Controls.Add(lblChart3);
            pnlChart.Controls.Add(lblChart4);

            pnlChart.Controls.Add(barra1);
            pnlChart.Controls.Add(barra2);
            pnlChart.Controls.Add(barra3);
            pnlChart.Controls.Add(barra4);
            pnlChart.Controls.Add(barra5);
            pnlChart.Controls.Add(barra6);

            pnlChart.Controls.Add(lblSeg);
            pnlChart.Controls.Add(lblTer);
            pnlChart.Controls.Add(lblQua);
            pnlChart.Controls.Add(lblQui);
            pnlChart.Controls.Add(lblSex);
            pnlChart.Controls.Add(lblSab);
            pnlChart.Controls.Add(lblDom);

            // ============================================================
            // CATEGORIAS
            // ============================================================

            pnlCategorias.BackColor = Color.White;
            pnlCategorias.BorderColor = Color.FromArgb(237, 229, 224);
            pnlCategorias.BorderRadius = 14;

            pnlCategorias.Controls.Add(progressCat4);
            pnlCategorias.Controls.Add(lblCat4Qtd);
            pnlCategorias.Controls.Add(lblCat4);

            pnlCategorias.Controls.Add(progressCat3);
            pnlCategorias.Controls.Add(lblCat3Qtd);
            pnlCategorias.Controls.Add(lblCat3);

            pnlCategorias.Controls.Add(progressCat2);
            pnlCategorias.Controls.Add(lblCat2Qtd);
            pnlCategorias.Controls.Add(lblCat2);

            pnlCategorias.Controls.Add(progressCat1);
            pnlCategorias.Controls.Add(lblCat1Qtd);
            pnlCategorias.Controls.Add(lblCat1);

            pnlCategorias.Controls.Add(lblCategoriasSubtitulo);
            pnlCategorias.Controls.Add(lblCategoriasTitulo);

            pnlCategorias.FillColor = Color.White;
            pnlCategorias.Location = new Point(699, 207);
            pnlCategorias.Name = "pnlCategorias";
            pnlCategorias.ShadowDecoration.Depth = 5;
            pnlCategorias.ShadowDecoration.Enabled = true;
            pnlCategorias.Size = new Size(348, 235);
            pnlCategorias.TabIndex = 20;

            lblCategoriasTitulo.AutoSize = true;
            lblCategoriasTitulo.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            lblCategoriasTitulo.ForeColor = Color.FromArgb(62, 45, 38);
            lblCategoriasTitulo.Location = new Point(18, 15);
            lblCategoriasTitulo.Name = "lblCategoriasTitulo";
            lblCategoriasTitulo.Text = "Por categoria";

            lblCategoriasSubtitulo.AutoSize = true;
            lblCategoriasSubtitulo.Font = new Font(
                "Segoe UI",
                7.5F);

            lblCategoriasSubtitulo.ForeColor = Color.FromArgb(153, 137, 128);
            lblCategoriasSubtitulo.Location = new Point(19, 35);
            lblCategoriasSubtitulo.Name = "lblCategoriasSubtitulo";
            lblCategoriasSubtitulo.Text = "Produtos cadastrados";

            // ============================================================
            // CATEGORIA 1
            // ============================================================

            ConfigurarCategoria(
                lblCat1,
                lblCat1Qtd,
                progressCat1,
                "Brigadeiros",
                "0",
                100,
                new Point(19, 65),
                new Point(273, 65),
                new Point(19, 85),
                Color.FromArgb(211, 119, 87));

            // ============================================================
            // CATEGORIA 2
            // ============================================================

            ConfigurarCategoria(
                lblCat2,
                lblCat2Qtd,
                progressCat2,
                "Bolos",
                "0",
                0,
                new Point(19, 105),
                new Point(273, 105),
                new Point(19, 125),
                Color.FromArgb(194, 157, 89));

            // ============================================================
            // CATEGORIA 3
            // ============================================================

            ConfigurarCategoria(
                lblCat3,
                lblCat3Qtd,
                progressCat3,
                "Brownies",
                "0",
                0,
                new Point(19, 145),
                new Point(273, 145),
                new Point(19, 165),
                Color.FromArgb(130, 108, 96));

            // ============================================================
            // CATEGORIA 4
            // ============================================================

            ConfigurarCategoria(
                lblCat4,
                lblCat4Qtd,
                progressCat4,
                "Cupcakes",
                "0",
                0,
                new Point(19, 185),
                new Point(273, 185),
                new Point(19, 205),
                Color.FromArgb(180, 130, 112));

            // ============================================================
            // ULTIMOS DOCES
            // ============================================================

            lblUltimosDoces.AutoSize = true;
            lblUltimosDoces.BackColor = Color.Transparent;
            lblUltimosDoces.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            lblUltimosDoces.ForeColor = Color.FromArgb(62, 45, 38);
            lblUltimosDoces.Location = new Point(28, 465);
            lblUltimosDoces.Name = "lblUltimosDoces";
            lblUltimosDoces.Text = "Doces cadastrados recentemente";

            lblUltimosSubtitulo.AutoSize = true;
            lblUltimosSubtitulo.BackColor = Color.Transparent;
            lblUltimosSubtitulo.Font = new Font(
                "Segoe UI",
                7.5F);

            lblUltimosSubtitulo.ForeColor = Color.FromArgb(153, 137, 128);
            lblUltimosSubtitulo.Location = new Point(29, 486);
            lblUltimosSubtitulo.Name = "lblUltimosSubtitulo";
            lblUltimosSubtitulo.Text = "Últimos produtos adicionados";

            // ============================================================
            // BOTAO
            // ============================================================

            btnVerTodos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerTodos.BorderRadius = 7;
            btnVerTodos.FillColor = Color.FromArgb(250, 239, 233);

            btnVerTodos.Font = new Font(
                "Segoe UI Semibold",
                7.5F,
                FontStyle.Bold);

            btnVerTodos.ForeColor = Color.FromArgb(201, 108, 78);
            btnVerTodos.Location = new Point(957, 462);
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.Size = new Size(90, 28);
            btnVerTodos.TabIndex = 31;
            btnVerTodos.Text = "Ver todos";

            // ============================================================
            // GRID
            // ============================================================

            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(76, 61, 53);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(249, 238, 232);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(76, 61, 53);

            gridUltimosDoces.AlternatingRowsDefaultCellStyle =
                dataGridViewCellStyle1;

            dataGridViewCellStyle2.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridViewCellStyle2.BackColor =
                Color.FromArgb(250, 247, 245);

            dataGridViewCellStyle2.Font =
                new Font(
                    "Segoe UI Semibold",
                    7F,
                    FontStyle.Bold);

            dataGridViewCellStyle2.ForeColor =
                Color.FromArgb(140, 122, 113);

            dataGridViewCellStyle2.SelectionBackColor =
                Color.FromArgb(250, 247, 245);

            dataGridViewCellStyle2.SelectionForeColor =
                Color.FromArgb(140, 122, 113);

            dataGridViewCellStyle2.WrapMode =
                DataGridViewTriState.False;

            gridUltimosDoces.ColumnHeadersDefaultCellStyle =
                dataGridViewCellStyle2;

            gridUltimosDoces.ColumnHeadersHeight = 30;
            gridUltimosDoces.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            gridUltimosDoces.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colId,
                    colTitle,
                    colCategoriaDoces,
                    colReleaseYear,
                    colIsFeatured,
                    colCreatedAt
                });

            dataGridViewCellStyle3.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridViewCellStyle3.BackColor =
                Color.White;

            dataGridViewCellStyle3.Font =
                new Font("Segoe UI", 8F);

            dataGridViewCellStyle3.ForeColor =
                Color.FromArgb(76, 61, 53);

            dataGridViewCellStyle3.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            dataGridViewCellStyle3.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            dataGridViewCellStyle3.WrapMode =
                DataGridViewTriState.False;

            gridUltimosDoces.DefaultCellStyle =
                dataGridViewCellStyle3;

            gridUltimosDoces.GridColor =
                Color.FromArgb(240, 234, 230);

            gridUltimosDoces.Location =
                new Point(28, 510);

            gridUltimosDoces.Name =
                "gridUltimosDoces";

            gridUltimosDoces.ReadOnly = true;
            gridUltimosDoces.RowHeadersVisible = false;
            gridUltimosDoces.RowTemplate.Height = 31;

            gridUltimosDoces.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridUltimosDoces.Size =
                new Size(1019, 182);

            gridUltimosDoces.TabIndex = 32;

            gridUltimosDoces.ThemeStyle.AlternatingRowsStyle.BackColor =
                Color.White;

            gridUltimosDoces.ThemeStyle.AlternatingRowsStyle.Font =
                new Font("Segoe UI", 8F);

            gridUltimosDoces.ThemeStyle.AlternatingRowsStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            gridUltimosDoces.ThemeStyle.AlternatingRowsStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            gridUltimosDoces.ThemeStyle.AlternatingRowsStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            gridUltimosDoces.ThemeStyle.BackColor =
                Color.White;

            gridUltimosDoces.ThemeStyle.GridColor =
                Color.FromArgb(240, 234, 230);

            gridUltimosDoces.ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(250, 247, 245);

            gridUltimosDoces.ThemeStyle.HeaderStyle.BorderStyle =
                DataGridViewHeaderBorderStyle.None;

            gridUltimosDoces.ThemeStyle.HeaderStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    7F,
                    FontStyle.Bold);

            gridUltimosDoces.ThemeStyle.HeaderStyle.ForeColor =
                Color.FromArgb(140, 122, 113);

            gridUltimosDoces.ThemeStyle.HeaderStyle.Height = 30;

            gridUltimosDoces.ThemeStyle.ReadOnly = true;

            gridUltimosDoces.ThemeStyle.RowsStyle.BackColor =
                Color.White;

            gridUltimosDoces.ThemeStyle.RowsStyle.BorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            gridUltimosDoces.ThemeStyle.RowsStyle.Font =
                new Font("Segoe UI", 8F);

            gridUltimosDoces.ThemeStyle.RowsStyle.ForeColor =
                Color.FromArgb(76, 61, 53);

            gridUltimosDoces.ThemeStyle.RowsStyle.Height = 31;

            gridUltimosDoces.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(249, 238, 232);

            gridUltimosDoces.ThemeStyle.RowsStyle.SelectionForeColor =
                Color.FromArgb(76, 61, 53);

            // ============================================================
            // COLUNAS
            // ============================================================

            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 65;

            colTitle.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colTitle.HeaderText = "PRODUTO";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.FillWeight = 180;

            colCategoriaDoces.HeaderText = "CATEGORIA";
            colCategoriaDoces.Name = "colCategoriaDoces";
            colCategoriaDoces.ReadOnly = true;
            colCategoriaDoces.Width = 170;

            colReleaseYear.HeaderText = "ANO";
            colReleaseYear.Name = "colReleaseYear";
            colReleaseYear.ReadOnly = true;
            colReleaseYear.Width = 80;

            // ============================================================
            // CORREÇÃO PRINCIPAL DO ERRO "NORMAL"
            // ============================================================

            colIsFeatured.HeaderText = "DESTAQUE";
            colIsFeatured.Name = "colIsFeatured";
            colIsFeatured.ReadOnly = true;
            colIsFeatured.Width = 100;

            colCreatedAt.HeaderText = "CADASTRADO EM";
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.Width = 155;

            // ============================================================
            // CARREGANDO
            // ============================================================

            lblCarregando.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            lblCarregando.BackColor =
                Color.FromArgb(247, 244, 241);

            lblCarregando.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            lblCarregando.ForeColor =
                Color.FromArgb(210, 119, 87);

            lblCarregando.Location =
                new Point(28, 300);

            lblCarregando.Name =
                "lblCarregando";

            lblCarregando.Size =
                new Size(1019, 30);

            lblCarregando.TabIndex = 33;

            lblCarregando.Text =
                "Carregando informações...";

            lblCarregando.TextAlign =
                ContentAlignment.MiddleCenter;

            lblCarregando.Visible = false;

            // ============================================================
            // FINALIZAÇÃO
            // ============================================================

            Controls.Add(pnldash);

            Name = "DashboardUserControl";
            Size = new Size(1075, 720);

            Load += DashboardUserControl_Load;

            pnldash.ResumeLayout(false);
            pnldash.PerformLayout();

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            cardDoces.ResumeLayout(false);
            cardDoces.PerformLayout();

            cardCategorias.ResumeLayout(false);
            cardCategorias.PerformLayout();

            pnlCardDestaques.ResumeLayout(false);
            pnlCardDestaques.PerformLayout();

            cardPedidos.ResumeLayout(false);
            cardPedidos.PerformLayout();

            pnlVendas.ResumeLayout(false);
            pnlVendas.PerformLayout();

            pnlChart.ResumeLayout(false);
            pnlChart.PerformLayout();

            pnlCategorias.ResumeLayout(false);
            pnlCategorias.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)gridUltimosDoces).EndInit();

            ResumeLayout(false);
        }

        // ================================================================
        // MÉTODOS AUXILIARES DO DESIGNER
        // ================================================================

        private void ConfigurarBarra(
            Guna.UI2.WinForms.Guna2Panel barra,
            Point location,
            Size size)
        {
            barra.BackColor = Color.FromArgb(221, 153, 125);
            barra.BorderRadius = 4;
            barra.FillColor = Color.FromArgb(221, 153, 125);
            barra.Location = location;
            barra.Size = size;
        }

        private void ConfigurarDia(
            Label label,
            string texto,
            Point location)
        {
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font("Segoe UI", 7F);
            label.ForeColor = Color.FromArgb(150, 133, 124);
            label.Location = location;
            label.Text = texto;
        }

        private void ConfigurarCategoria(
            Label label,
            Label quantidade,
            Guna.UI2.WinForms.Guna2ProgressBar progress,
            string nome,
            string qtd,
            int valor,
            Point labelLocation,
            Point quantidadeLocation,
            Point progressLocation,
            Color progressColor)
        {
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Font = new Font(
                "Segoe UI Semibold",
                8F,
                FontStyle.Bold);

            label.ForeColor = Color.FromArgb(83, 65, 57);
            label.Location = labelLocation;
            label.Text = nome;

            quantidade.AutoSize = true;
            quantidade.BackColor = Color.Transparent;
            quantidade.Font = new Font(
                "Segoe UI",
                7F);

            quantidade.ForeColor = Color.FromArgb(151, 134, 125);
            quantidade.Location = quantidadeLocation;
            quantidade.Text = qtd;

            progress.BackColor = Color.Transparent;
            progress.Location = progressLocation;
            progress.Size = new Size(309, 6);
            progress.BorderRadius = 3;
            progress.FillColor = Color.FromArgb(241, 233, 228);
            progress.ProgressColor = progressColor;
            progress.ProgressColor2 = progressColor;

            if (valor < 0)
                valor = 0;

            if (valor > 100)
                valor = 100;

            progress.Value = valor;
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnldash;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;

        private Label lblTitulo;
        private Label lblSubTitulo;

        private Guna.UI2.WinForms.Guna2Panel cardDoces;
        private Label cardDoceslblNumero;
        private Label lblCardDocesTitulo;
        private Label lblCardDocesIcone;
        private Label lblCardDocesDescricao;

        private Guna.UI2.WinForms.Guna2Panel cardCategorias;
        private Label cardCategoriaslblNumero;
        private Label lblCardCategoriasTitulo;
        private Label lblCardCategoriasIcone;
        private Label lblCardCategoriasDescricao;

        private Guna.UI2.WinForms.Guna2Panel pnlCardDestaques;
        private Label CardDestaquesValor;
        private Label lblCardDestaquesTitulo;
        private Label lblCardDestaquesIcone;
        private Label lblCardDestaquesDescricao;

        private Guna.UI2.WinForms.Guna2Panel cardPedidos;
        private Label lblCardPedidosNumero;
        private Label lblCardPedidosTitulo;
        private Label lblCardPedidosIcone;
        private Label lblCardPedidosDescricao;

        private Guna.UI2.WinForms.Guna2Panel pnlVendas;
        private Label lblVendasTitulo;
        private Label lblVendasSubtitulo;
        private Label lblVendasValor;
        private Label lblVendasPeriodo;

        private Guna.UI2.WinForms.Guna2Panel pnlChart;

        private Label lblChart0;
        private Label lblChart1;
        private Label lblChart2;
        private Label lblChart3;
        private Label lblChart4;

        private Guna.UI2.WinForms.Guna2Panel barra1;
        private Guna.UI2.WinForms.Guna2Panel barra2;
        private Guna.UI2.WinForms.Guna2Panel barra3;
        private Guna.UI2.WinForms.Guna2Panel barra4;
        private Guna.UI2.WinForms.Guna2Panel barra5;
        private Guna.UI2.WinForms.Guna2Panel barra6;

        private Label lblSeg;
        private Label lblTer;
        private Label lblQua;
        private Label lblQui;
        private Label lblSex;
        private Label lblSab;
        private Label lblDom;

        private Guna.UI2.WinForms.Guna2Panel pnlCategorias;

        private Label lblCategoriasTitulo;
        private Label lblCategoriasSubtitulo;

        private Label lblCat1;
        private Label lblCat1Qtd;
        private Guna.UI2.WinForms.Guna2ProgressBar progressCat1;

        private Label lblCat2;
        private Label lblCat2Qtd;
        private Guna.UI2.WinForms.Guna2ProgressBar progressCat2;

        private Label lblCat3;
        private Label lblCat3Qtd;
        private Guna.UI2.WinForms.Guna2ProgressBar progressCat3;

        private Label lblCat4;
        private Label lblCat4Qtd;
        private Guna.UI2.WinForms.Guna2ProgressBar progressCat4;

        private Label lblUltimosDoces;
        private Label lblUltimosSubtitulo;

        private Guna.UI2.WinForms.Guna2DataGridView gridUltimosDoces;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategoriaDoces;
        private DataGridViewTextBoxColumn colReleaseYear;

        // CORRIGIDO:
        private DataGridViewTextBoxColumn colIsFeatured;

        private DataGridViewTextBoxColumn colCreatedAt;

        private Guna.UI2.WinForms.Guna2Button btnVerTodos;

        private Label lblCarregando;
    }
}