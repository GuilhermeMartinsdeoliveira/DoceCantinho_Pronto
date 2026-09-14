using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoceCantinho.Desktop1.UserControls
{
    partial class DashboardUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();

            pnldash = new Guna2Panel();

            lblCarregando = new Label();

            gridUltimosDoces = new Guna2DataGridView();

            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoriaDoces = new DataGridViewTextBoxColumn();
            colReleaseYear = new DataGridViewTextBoxColumn();
            colIsFeatured = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();

            lblUltimosDoces = new Label();
            lblUltimosSubtitulo = new Label();
            btnVerTodos = new Guna2Button();

            pnlCategorias = new Guna2Panel();

            lblCat4Qtd = new Label();
            lblCat4 = new Label();
            progressCat4 = new Guna2ProgressBar();

            lblCat3Qtd = new Label();
            lblCat3 = new Label();
            progressCat3 = new Guna2ProgressBar();

            lblCat2Qtd = new Label();
            lblCat2 = new Label();
            progressCat2 = new Guna2ProgressBar();

            lblCat1Qtd = new Label();
            lblCat1 = new Label();
            progressCat1 = new Guna2ProgressBar();

            lblCategoriasSubtitulo = new Label();
            lblCategoriasTitulo = new Label();

            pnlVendas = new Guna2Panel();
            pnlChart = new Guna2Panel();

            lblChart0 = new Label();
            lblChart1 = new Label();
            lblChart2 = new Label();
            lblChart3 = new Label();
            lblChart4 = new Label();

            barra1 = new Guna2Panel();
            barra2 = new Guna2Panel();
            barra3 = new Guna2Panel();
            barra4 = new Guna2Panel();
            barra5 = new Guna2Panel();
            barra6 = new Guna2Panel();

            lblSeg = new Label();
            lblTer = new Label();
            lblQua = new Label();
            lblQui = new Label();
            lblSex = new Label();
            lblSab = new Label();
            lblDom = new Label();

            lblVendasPeriodo = new Label();
            lblVendasValor = new Label();
            lblVendasSubtitulo = new Label();
            lblVendasTitulo = new Label();

            cardPedidos = new Guna2Panel();
            lblCardPedidosDescricao = new Label();
            lblCardPedidosTitulo = new Label();
            lblCardPedidosNumero = new Label();
            lblCardPedidosIcone = new Label();

            pnlCardDestaques = new Guna2Panel();
            lblCardDestaquesDescricao = new Label();
            lblCardDestaquesTitulo = new Label();
            CardDestaquesValor = new Label();
            lblCardDestaquesIcone = new Label();

            cardCategorias = new Guna2Panel();
            lblCardCategoriasDescricao = new Label();
            lblCardCategoriasTitulo = new Label();
            cardCategoriaslblNumero = new Label();
            lblCardCategoriasIcone = new Label();

            cardDoces = new Guna2Panel();
            lblCardDocesDescricao = new Label();
            lblCardDocesTitulo = new Label();
            cardDoceslblNumero = new Label();
            lblCardDocesIcone = new Label();

            pnlHeader = new Guna2Panel();
            lblSubTitulo = new Label();
            lblTitulo = new Label();

            pnldash.SuspendLayout();

            ((ISupportInitialize)gridUltimosDoces).BeginInit();

            pnlCategorias.SuspendLayout();
            pnlVendas.SuspendLayout();
            pnlChart.SuspendLayout();
            cardPedidos.SuspendLayout();
            pnlCardDestaques.SuspendLayout();
            cardCategorias.SuspendLayout();
            cardDoces.SuspendLayout();
            pnlHeader.SuspendLayout();

            SuspendLayout();

            // ============================================================
            // pnldash
            // ============================================================

            pnldash.BackColor =
                Color.FromArgb(247, 244, 241);

            pnldash.Dock =
                DockStyle.Fill;

            pnldash.FillColor =
                Color.FromArgb(247, 244, 241);

            pnldash.Location =
                new Point(0, 0);

            pnldash.Name =
                "pnldash";

            pnldash.Size =
                new Size(1075, 720);

            pnldash.TabIndex = 0;

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

            // ============================================================
            // lblCarregando
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

            lblCarregando.TabIndex =
                33;

            lblCarregando.Text =
                "Carregando informações...";

            lblCarregando.TextAlign =
                ContentAlignment.MiddleCenter;

            lblCarregando.Visible =
                false;

            // ============================================================
            // gridUltimosDoces
            // ============================================================

            gridUltimosDoces.AllowUserToAddRows =
                false;

            gridUltimosDoces.AllowUserToDeleteRows =
                false;

            gridUltimosDoces.AllowUserToResizeRows =
                false;

            gridUltimosDoces.BackgroundColor =
                Color.White;

            gridUltimosDoces.BorderStyle =
                BorderStyle.None;

            gridUltimosDoces.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            gridUltimosDoces.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            gridUltimosDoces.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        Color.FromArgb(250, 247, 245),

                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            7F,
                            FontStyle.Bold),

                    ForeColor =
                        Color.FromArgb(140, 122, 113),

                    SelectionBackColor =
                        Color.FromArgb(250, 247, 245),

                    SelectionForeColor =
                        Color.FromArgb(140, 122, 113),

                    WrapMode =
                        DataGridViewTriState.False
                };

            gridUltimosDoces.ColumnHeadersHeight =
                30;

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

            gridUltimosDoces.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        Color.White,

                    Font =
                        new Font(
                            "Segoe UI",
                            8F),

                    ForeColor =
                        Color.FromArgb(76, 61, 53),

                    SelectionBackColor =
                        Color.FromArgb(249, 238, 232),

                    SelectionForeColor =
                        Color.FromArgb(76, 61, 53),

                    WrapMode =
                        DataGridViewTriState.False
                };

            gridUltimosDoces.EnableHeadersVisualStyles =
                false;

            gridUltimosDoces.GridColor =
                Color.FromArgb(240, 234, 230);

            gridUltimosDoces.Location =
                new Point(28, 510);

            gridUltimosDoces.Name =
                "gridUltimosDoces";

            gridUltimosDoces.ReadOnly =
                true;

            gridUltimosDoces.RowHeadersVisible =
                false;

            gridUltimosDoces.RowTemplate.Height =
                31;

            gridUltimosDoces.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridUltimosDoces.MultiSelect =
                false;

            gridUltimosDoces.Size =
                new Size(1019, 182);

            gridUltimosDoces.TabIndex =
                32;

            // ============================================================
            // colId
            // ============================================================

            colId.HeaderText =
                "ID";

            colId.Name =
                "colId";

            colId.ReadOnly =
                true;

            colId.Width =
                80;

            // ============================================================
            // colTitle
            // ============================================================

            colTitle.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colTitle.FillWeight =
                180F;

            colTitle.HeaderText =
                "PRODUTO";

            colTitle.Name =
                "colTitle";

            colTitle.ReadOnly =
                true;

            // ============================================================
            // colCategoriaDoces
            // ============================================================

            colCategoriaDoces.HeaderText =
                "CATEGORIA";

            colCategoriaDoces.Name =
                "colCategoriaDoces";

            colCategoriaDoces.ReadOnly =
                true;

            colCategoriaDoces.Width =
                150;

            // ============================================================
            // colReleaseYear
            // ============================================================

            colReleaseYear.HeaderText =
                "PREÇO";

            colReleaseYear.Name =
                "colReleaseYear";

            colReleaseYear.ReadOnly =
                true;

            colReleaseYear.Width =
                100;

            // ============================================================
            // colIsFeatured
            // ============================================================

            colIsFeatured.HeaderText =
                "DESTAQUE";

            colIsFeatured.Name =
                "colIsFeatured";

            colIsFeatured.ReadOnly =
                true;

            colIsFeatured.Width =
                110;

            // ============================================================
            // colCreatedAt
            // ============================================================

            colCreatedAt.HeaderText =
                "CADASTRADO EM";

            colCreatedAt.Name =
                "colCreatedAt";

            colCreatedAt.ReadOnly =
                true;

            colCreatedAt.Width =
                150;

            // ============================================================
            // lblUltimosDoces
            // ============================================================

            lblUltimosDoces.AutoSize =
                true;

            lblUltimosDoces.BackColor =
                Color.Transparent;

            lblUltimosDoces.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            lblUltimosDoces.ForeColor =
                Color.FromArgb(62, 45, 38);

            lblUltimosDoces.Location =
                new Point(28, 465);

            lblUltimosDoces.Name =
                "lblUltimosDoces";

            lblUltimosDoces.Size =
                new Size(214, 19);

            lblUltimosDoces.TabIndex =
                34;

            lblUltimosDoces.Text =
                "Doces cadastrados recentemente";

            // ============================================================
            // lblUltimosSubtitulo
            // ============================================================

            lblUltimosSubtitulo.AutoSize =
                true;

            lblUltimosSubtitulo.BackColor =
                Color.Transparent;

            lblUltimosSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            lblUltimosSubtitulo.ForeColor =
                Color.FromArgb(153, 137, 128);

            lblUltimosSubtitulo.Location =
                new Point(29, 486);

            lblUltimosSubtitulo.Name =
                "lblUltimosSubtitulo";

            lblUltimosSubtitulo.Size =
                new Size(137, 12);

            lblUltimosSubtitulo.TabIndex =
                35;

            lblUltimosSubtitulo.Text =
                "Últimos produtos adicionados";

            // ============================================================
            // btnVerTodos
            // ============================================================

            btnVerTodos.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnVerTodos.BackColor =
                Color.Transparent;

            btnVerTodos.BorderRadius =
                7;

            btnVerTodos.FillColor =
                Color.FromArgb(250, 239, 233);

            btnVerTodos.Font =
                new Font(
                    "Segoe UI Semibold",
                    7.5F,
                    FontStyle.Bold);

            btnVerTodos.ForeColor =
                Color.FromArgb(201, 108, 78);

            btnVerTodos.Location =
                new Point(957, 462);

            btnVerTodos.Name =
                "btnVerTodos";

            btnVerTodos.Size =
                new Size(90, 28);

            btnVerTodos.TabIndex =
                31;

            btnVerTodos.Text =
                "Ver todos";

            // ============================================================
            // pnlCategorias
            // ============================================================

            pnlCategorias.BackColor =
                Color.Transparent;

            pnlCategorias.BorderColor =
                Color.FromArgb(237, 229, 224);

            pnlCategorias.BorderRadius =
                14;

            pnlCategorias.FillColor =
                Color.White;

            pnlCategorias.Location =
                new Point(699, 207);

            pnlCategorias.Name =
                "pnlCategorias";

            pnlCategorias.Size =
                new Size(348, 235);

            pnlCategorias.TabIndex =
                20;

            pnlCategorias.Controls.Add(lblCat4Qtd);
            pnlCategorias.Controls.Add(lblCat4);
            pnlCategorias.Controls.Add(progressCat4);

            pnlCategorias.Controls.Add(lblCat3Qtd);
            pnlCategorias.Controls.Add(lblCat3);
            pnlCategorias.Controls.Add(progressCat3);

            pnlCategorias.Controls.Add(lblCat2Qtd);
            pnlCategorias.Controls.Add(lblCat2);
            pnlCategorias.Controls.Add(progressCat2);

            pnlCategorias.Controls.Add(lblCat1Qtd);
            pnlCategorias.Controls.Add(lblCat1);
            pnlCategorias.Controls.Add(progressCat1);

            pnlCategorias.Controls.Add(lblCategoriasSubtitulo);
            pnlCategorias.Controls.Add(lblCategoriasTitulo);

            pnlCategorias.ShadowDecoration.Enabled =
                true;

            pnlCategorias.ShadowDecoration.Depth =
                5;

            // ============================================================
            // lblCategoriasTitulo
            // ============================================================

            lblCategoriasTitulo.AutoSize =
                true;

            lblCategoriasTitulo.BackColor =
                Color.Transparent;

            lblCategoriasTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            lblCategoriasTitulo.ForeColor =
                Color.FromArgb(62, 45, 38);

            lblCategoriasTitulo.Location =
                new Point(18, 15);

            lblCategoriasTitulo.Name =
                "lblCategoriasTitulo";

            lblCategoriasTitulo.TabIndex =
                13;

            lblCategoriasTitulo.Text =
                "Por categoria";

            // ============================================================
            // lblCategoriasSubtitulo
            // ============================================================

            lblCategoriasSubtitulo.AutoSize =
                true;

            lblCategoriasSubtitulo.BackColor =
                Color.Transparent;

            lblCategoriasSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            lblCategoriasSubtitulo.ForeColor =
                Color.FromArgb(153, 137, 128);

            lblCategoriasSubtitulo.Location =
                new Point(19, 35);

            lblCategoriasSubtitulo.Name =
                "lblCategoriasSubtitulo";

            lblCategoriasSubtitulo.TabIndex =
                12;

            lblCategoriasSubtitulo.Text =
                "Produtos cadastrados";

            // ============================================================
            // CATEGORIA 1
            // ============================================================

            lblCat1.AutoSize =
                true;

            lblCat1.BackColor =
                Color.Transparent;

            lblCat1.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            lblCat1.ForeColor =
                Color.FromArgb(83, 65, 57);

            lblCat1.Location =
                new Point(19, 55);

            lblCat1.Name =
                "lblCat1";

            lblCat1.TabIndex =
                11;

            lblCat1.Text =
                "Categoria";

            // ============================================================

            lblCat1Qtd.AutoSize =
                true;

            lblCat1Qtd.BackColor =
                Color.Transparent;

            lblCat1Qtd.Font =
                new Font(
                    "Segoe UI",
                    7F);

            lblCat1Qtd.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblCat1Qtd.Location =
                new Point(310, 55);

            lblCat1Qtd.Name =
                "lblCat1Qtd";

            lblCat1Qtd.TabIndex =
                10;

            lblCat1Qtd.Text =
                "0";

            // ============================================================

            progressCat1.Location =
                new Point(19, 75);

            progressCat1.Name =
                "progressCat1";

            progressCat1.Size =
                new Size(309, 6);

            progressCat1.BorderRadius =
                3;

            progressCat1.FillColor =
                Color.FromArgb(241, 233, 228);

            progressCat1.ProgressColor =
                Color.FromArgb(221, 153, 125);

            progressCat1.ProgressColor2 =
                Color.FromArgb(221, 153, 125);

            progressCat1.Value =
                0;

            // ============================================================
            // CATEGORIA 2
            // ============================================================

            lblCat2.AutoSize =
                true;

            lblCat2.BackColor =
                Color.Transparent;

            lblCat2.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            lblCat2.ForeColor =
                Color.FromArgb(83, 65, 57);

            lblCat2.Location =
                new Point(19, 95);

            lblCat2.Name =
                "lblCat2";

            lblCat2.TabIndex =
                8;

            lblCat2.Text =
                "Categoria";

            // ============================================================

            lblCat2Qtd.AutoSize =
                true;

            lblCat2Qtd.BackColor =
                Color.Transparent;

            lblCat2Qtd.Font =
                new Font(
                    "Segoe UI",
                    7F);

            lblCat2Qtd.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblCat2Qtd.Location =
                new Point(310, 95);

            lblCat2Qtd.Name =
                "lblCat2Qtd";

            lblCat2Qtd.TabIndex =
                7;

            lblCat2Qtd.Text =
                "0";

            // ============================================================

            progressCat2.Location =
                new Point(19, 115);

            progressCat2.Name =
                "progressCat2";

            progressCat2.Size =
                new Size(309, 6);

            progressCat2.BorderRadius =
                3;

            progressCat2.FillColor =
                Color.FromArgb(241, 233, 228);

            progressCat2.ProgressColor =
                Color.FromArgb(221, 153, 125);

            progressCat2.ProgressColor2 =
                Color.FromArgb(221, 153, 125);

            progressCat2.Value =
                0;

            // ============================================================
            // CATEGORIA 3
            // ============================================================

            lblCat3.AutoSize =
                true;

            lblCat3.BackColor =
                Color.Transparent;

            lblCat3.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            lblCat3.ForeColor =
                Color.FromArgb(83, 65, 57);

            lblCat3.Location =
                new Point(19, 135);

            lblCat3.Name =
                "lblCat3";

            lblCat3.TabIndex =
                5;

            lblCat3.Text =
                "Categoria";

            // ============================================================

            lblCat3Qtd.AutoSize =
                true;

            lblCat3Qtd.BackColor =
                Color.Transparent;

            lblCat3Qtd.Font =
                new Font(
                    "Segoe UI",
                    7F);

            lblCat3Qtd.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblCat3Qtd.Location =
                new Point(310, 135);

            lblCat3Qtd.Name =
                "lblCat3Qtd";

            lblCat3Qtd.TabIndex =
                4;

            lblCat3Qtd.Text =
                "0";

            // ============================================================

            progressCat3.Location =
                new Point(19, 155);

            progressCat3.Name =
                "progressCat3";

            progressCat3.Size =
                new Size(309, 6);

            progressCat3.BorderRadius =
                3;

            progressCat3.FillColor =
                Color.FromArgb(241, 233, 228);

            progressCat3.ProgressColor =
                Color.FromArgb(221, 153, 125);

            progressCat3.ProgressColor2 =
                Color.FromArgb(221, 153, 125);

            progressCat3.Value =
                0;

            // ============================================================
            // CATEGORIA 4
            // ============================================================

            lblCat4.AutoSize =
                true;

            lblCat4.BackColor =
                Color.Transparent;

            lblCat4.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            lblCat4.ForeColor =
                Color.FromArgb(83, 65, 57);

            lblCat4.Location =
                new Point(19, 175);

            lblCat4.Name =
                "lblCat4";

            lblCat4.TabIndex =
                2;

            lblCat4.Text =
                "Categoria";

            // ============================================================

            lblCat4Qtd.AutoSize =
                true;

            lblCat4Qtd.BackColor =
                Color.Transparent;

            lblCat4Qtd.Font =
                new Font(
                    "Segoe UI",
                    7F);

            lblCat4Qtd.ForeColor =
                Color.FromArgb(151, 134, 125);

            lblCat4Qtd.Location =
                new Point(310, 175);

            lblCat4Qtd.Name =
                "lblCat4Qtd";

            lblCat4Qtd.TabIndex =
                1;

            lblCat4Qtd.Text =
                "0";

            // ============================================================

            progressCat4.Location =
                new Point(19, 195);

            progressCat4.Name =
                "progressCat4";

            progressCat4.Size =
                new Size(309, 6);

            progressCat4.BorderRadius =
                3;

            progressCat4.FillColor =
                Color.FromArgb(241, 233, 228);

            progressCat4.ProgressColor =
                Color.FromArgb(221, 153, 125);

            progressCat4.ProgressColor2 =
                Color.FromArgb(221, 153, 125);

            progressCat4.Value =
                0;

            // ============================================================
            // pnlVendas
            // ============================================================

            pnlVendas.BackColor =
                Color.Transparent;

            pnlVendas.BorderColor =
                Color.FromArgb(237, 229, 224);

            pnlVendas.BorderRadius =
                14;

            pnlVendas.FillColor =
                Color.White;

            pnlVendas.Location =
                new Point(28, 207);

            pnlVendas.Name =
                "pnlVendas";

            pnlVendas.Size =
                new Size(655, 235);

            pnlVendas.TabIndex =
                10;

            pnlVendas.Controls.Add(pnlChart);
            pnlVendas.Controls.Add(lblVendasPeriodo);
            pnlVendas.Controls.Add(lblVendasValor);
            pnlVendas.Controls.Add(lblVendasSubtitulo);
            pnlVendas.Controls.Add(lblVendasTitulo);

            pnlVendas.ShadowDecoration.Enabled =
                true;

            pnlVendas.ShadowDecoration.Depth =
                5;

            // ============================================================
            // pnlChart
            // ============================================================

            pnlChart.BackColor =
                Color.FromArgb(253, 251, 249);

            pnlChart.BorderRadius =
                8;

            pnlChart.FillColor =
                Color.FromArgb(253, 251, 249);

            pnlChart.Location =
                new Point(18, 60);

            pnlChart.Name =
                "pnlChart";

            pnlChart.Size =
                new Size(619, 158);

            pnlChart.TabIndex =
                11;

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
            // ESCALA DO GRÁFICO
            // ============================================================

            ConfigurarLabelGrafico(
                lblChart0,
                "R$ 0",
                new Point(8, 128));

            ConfigurarLabelGrafico(
                lblChart1,
                "R$ 1k",
                new Point(8, 98));

            ConfigurarLabelGrafico(
                lblChart2,
                "R$ 2k",
                new Point(8, 68));

            ConfigurarLabelGrafico(
                lblChart3,
                "R$ 3k",
                new Point(8, 38));

            ConfigurarLabelGrafico(
                lblChart4,
                "R$ 4k",
                new Point(8, 8));

            // ============================================================
            // DIAS
            // ============================================================

            ConfigurarDia(
                lblSeg,
                "Seg",
                new Point(95, 137));

            ConfigurarDia(
                lblTer,
                "Ter",
                new Point(175, 137));

            ConfigurarDia(
                lblQua,
                "Qua",
                new Point(255, 137));

            ConfigurarDia(
                lblQui,
                "Qui",
                new Point(335, 137));

            ConfigurarDia(
                lblSex,
                "Sex",
                new Point(415, 137));

            ConfigurarDia(
                lblSab,
                "Sáb",
                new Point(495, 137));

            ConfigurarDia(
                lblDom,
                "Dom",
                new Point(565, 137));

            // ============================================================
            // BARRAS ESTÁTICAS - OCULTADAS PELO .CS
            // ============================================================

            ConfigurarBarra(
                barra1,
                new Point(0, 0),
                new Size(20, 20));

            ConfigurarBarra(
                barra2,
                new Point(0, 0),
                new Size(20, 20));

            ConfigurarBarra(
                barra3,
                new Point(0, 0),
                new Size(20, 20));

            ConfigurarBarra(
                barra4,
                new Point(0, 0),
                new Size(20, 20));

            ConfigurarBarra(
                barra5,
                new Point(0, 0),
                new Size(20, 20));

            ConfigurarBarra(
                barra6,
                new Point(0, 0),
                new Size(20, 20));

            // ============================================================
            // TÍTULO VENDAS
            // ============================================================

            lblVendasTitulo.AutoSize =
                true;

            lblVendasTitulo.BackColor =
                Color.Transparent;

            lblVendasTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            lblVendasTitulo.ForeColor =
                Color.FromArgb(62, 45, 38);

            lblVendasTitulo.Location =
                new Point(18, 15);

            lblVendasTitulo.Name =
                "lblVendasTitulo";

            lblVendasTitulo.TabIndex =
                15;

            lblVendasTitulo.Text =
                "Vendas dos últimos 7 dias";

            // ============================================================

            lblVendasSubtitulo.AutoSize =
                true;

            lblVendasSubtitulo.BackColor =
                Color.Transparent;

            lblVendasSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            lblVendasSubtitulo.ForeColor =
                Color.FromArgb(153, 137, 128);

            lblVendasSubtitulo.Location =
                new Point(19, 35);

            lblVendasSubtitulo.Name =
                "lblVendasSubtitulo";

            lblVendasSubtitulo.TabIndex =
                14;

            lblVendasSubtitulo.Text =
                "Receita acumulada por dia";

            // ============================================================

            lblVendasValor.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            lblVendasValor.AutoSize =
                true;

            lblVendasValor.BackColor =
                Color.Transparent;

            lblVendasValor.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            lblVendasValor.ForeColor =
                Color.FromArgb(210, 119, 87);

            lblVendasValor.Location =
                new Point(549, 15);

            lblVendasValor.Name =
                "lblVendasValor";

            lblVendasValor.TabIndex =
                13;

            lblVendasValor.Text =
                "R$ 0,00";

            // ============================================================

            lblVendasPeriodo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            lblVendasPeriodo.AutoSize =
                true;

            lblVendasPeriodo.BackColor =
                Color.Transparent;

            lblVendasPeriodo.Font =
                new Font(
                    "Segoe UI",
                    7F);

            lblVendasPeriodo.ForeColor =
                Color.FromArgb(153, 137, 128);

            lblVendasPeriodo.Location =
                new Point(549, 35);

            lblVendasPeriodo.Name =
                "lblVendasPeriodo";

            lblVendasPeriodo.TabIndex =
                12;

            lblVendasPeriodo.Text =
                "esta semana";

            // ============================================================
            // CARD DOCES
            // ============================================================

            ConfigurarCard(
                cardDoces,
                new Point(28, 98),
                new Size(239, 91));

            cardDoces.Controls.Add(
                lblCardDocesDescricao);

            cardDoces.Controls.Add(
                lblCardDocesTitulo);

            cardDoces.Controls.Add(
                cardDoceslblNumero);

            cardDoces.Controls.Add(
                lblCardDocesIcone);

            ConfigurarTituloCard(
                lblCardDocesTitulo,
                "DOCES CADASTRADOS");

            ConfigurarNumeroCard(
                cardDoceslblNumero,
                "--");

            ConfigurarDescricaoCard(
                lblCardDocesDescricao,
                "produtos cadastrados");

            ConfigurarIconeCard(
                lblCardDocesIcone,
                "🍰",
                Color.FromArgb(250, 234, 226),
                Color.FromArgb(210, 119, 87));

            // ============================================================
            // CARD CATEGORIAS
            // ============================================================

            ConfigurarCard(
                cardCategorias,
                new Point(284, 98),
                new Size(239, 91));

            cardCategorias.Controls.Add(
                lblCardCategoriasDescricao);

            cardCategorias.Controls.Add(
                lblCardCategoriasTitulo);

            cardCategorias.Controls.Add(
                cardCategoriaslblNumero);

            cardCategorias.Controls.Add(
                lblCardCategoriasIcone);

            ConfigurarTituloCard(
                lblCardCategoriasTitulo,
                "CATEGORIAS");

            ConfigurarNumeroCard(
                cardCategoriaslblNumero,
                "--");

            ConfigurarDescricaoCard(
                lblCardCategoriasDescricao,
                "categorias cadastradas");

            ConfigurarIconeCard(
                lblCardCategoriasIcone,
                "🏷",
                Color.FromArgb(249, 242, 226),
                Color.FromArgb(190, 151, 77));

            // ============================================================
            // CARD DESTAQUES
            // ============================================================

            ConfigurarCard(
                pnlCardDestaques,
                new Point(540, 98),
                new Size(239, 91));

            pnlCardDestaques.Controls.Add(
                lblCardDestaquesDescricao);

            pnlCardDestaques.Controls.Add(
                lblCardDestaquesTitulo);

            pnlCardDestaques.Controls.Add(
                CardDestaquesValor);

            pnlCardDestaques.Controls.Add(
                lblCardDestaquesIcone);

            ConfigurarTituloCard(
                lblCardDestaquesTitulo,
                "EM DESTAQUE");

            ConfigurarNumeroCard(
                CardDestaquesValor,
                "--");

            ConfigurarDescricaoCard(
                lblCardDestaquesDescricao,
                "produtos destacados");

            ConfigurarIconeCard(
                lblCardDestaquesIcone,
                "★",
                Color.FromArgb(246, 239, 234),
                Color.FromArgb(143, 111, 91));

            // ============================================================
            // CARD PEDIDOS
            // ============================================================

            ConfigurarCard(
                cardPedidos,
                new Point(796, 98),
                new Size(251, 91));

            cardPedidos.Controls.Add(
                lblCardPedidosDescricao);

            cardPedidos.Controls.Add(
                lblCardPedidosTitulo);

            cardPedidos.Controls.Add(
                lblCardPedidosNumero);

            cardPedidos.Controls.Add(
                lblCardPedidosIcone);

            ConfigurarTituloCard(
                lblCardPedidosTitulo,
                "PEDIDOS HOJE");

            ConfigurarNumeroCard(
                lblCardPedidosNumero,
                "00");

            ConfigurarDescricaoCard(
                lblCardPedidosDescricao,
                "aguardando preparo");

            ConfigurarIconeCard(
                lblCardPedidosIcone,
                "◷",
                Color.FromArgb(232, 244, 238),
                Color.FromArgb(89, 145, 119));

            lblCardPedidosIcone.Location =
                new Point(204, 12);

            // ============================================================
            // HEADER
            // ============================================================

            pnlHeader.BackColor =
                Color.Transparent;

            pnlHeader.FillColor =
                Color.Transparent;

            pnlHeader.Location =
                new Point(28, 22);

            pnlHeader.Name =
                "pnlHeader";

            pnlHeader.Size =
                new Size(1019, 62);

            pnlHeader.TabIndex =
                1;

            pnlHeader.Controls.Add(
                lblSubTitulo);

            pnlHeader.Controls.Add(
                lblTitulo);

            // ============================================================

            lblTitulo.AutoSize =
                true;

            lblTitulo.BackColor =
                Color.Transparent;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    19F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(62, 45, 38);

            lblTitulo.Location =
                new Point(0, 1);

            lblTitulo.Name =
                "lblTitulo";

            lblTitulo.TabIndex =
                0;

            lblTitulo.Text =
                "Olá, Administrador";

            // ============================================================

            lblSubTitulo.AutoSize =
                true;

            lblSubTitulo.BackColor =
                Color.Transparent;

            lblSubTitulo.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblSubTitulo.ForeColor =
                Color.FromArgb(148, 130, 120);

            lblSubTitulo.Location =
                new Point(2, 39);

            lblSubTitulo.Name =
                "lblSubTitulo";

            lblSubTitulo.TabIndex =
                1;

            lblSubTitulo.Text =
                "Bem-vindo ao DoceCantinho";

            // ============================================================
            // FINAL
            // ============================================================

            Controls.Add(
                pnldash);

            Name =
                "DashboardUserControl";

            Size =
                new Size(1075, 720);

            Load +=
                DashboardUserControl_Load;

            pnldash.ResumeLayout(false);
            pnldash.PerformLayout();

            ((ISupportInitialize)gridUltimosDoces).EndInit();

            pnlCategorias.ResumeLayout(false);
            pnlCategorias.PerformLayout();

            pnlVendas.ResumeLayout(false);
            pnlVendas.PerformLayout();

            pnlChart.ResumeLayout(false);
            pnlChart.PerformLayout();

            cardPedidos.ResumeLayout(false);
            cardPedidos.PerformLayout();

            pnlCardDestaques.ResumeLayout(false);
            pnlCardDestaques.PerformLayout();

            cardCategorias.ResumeLayout(false);
            cardCategorias.PerformLayout();

            cardDoces.ResumeLayout(false);
            cardDoces.PerformLayout();

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        // ================================================================
        // MÉTODOS AUXILIARES DO DESIGNER
        // ================================================================

        private void ConfigurarCard(
            Guna2Panel card,
            Point location,
            Size size)
        {
            card.BackColor =
                Color.Transparent;

            card.BorderColor =
                Color.FromArgb(237, 229, 224);

            card.BorderRadius =
                14;

            card.FillColor =
                Color.White;

            card.Location =
                location;

            card.Size =
                size;

            card.ShadowDecoration.Enabled =
                true;

            card.ShadowDecoration.Depth =
                5;
        }

        private void ConfigurarTituloCard(
            Label label,
            string texto)
        {
            label.AutoSize =
                true;

            label.BackColor =
                Color.Transparent;

            label.Font =
                new Font(
                    "Segoe UI Semibold",
                    7.5F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.FromArgb(116, 96, 87);

            label.Location =
                new Point(18, 11);

            label.Text =
                texto;
        }

        private void ConfigurarNumeroCard(
            Label label,
            string texto)
        {
            label.AutoSize =
                true;

            label.BackColor =
                Color.Transparent;

            label.Font =
                new Font(
                    "Segoe UI Semibold",
                    20F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.FromArgb(62, 45, 38);

            label.Location =
                new Point(17, 30);

            label.Text =
                texto;
        }

        private void ConfigurarDescricaoCard(
            Label label,
            string texto)
        {
            label.AutoSize =
                true;

            label.BackColor =
                Color.Transparent;

            label.Font =
                new Font(
                    "Segoe UI",
                    7F);

            label.ForeColor =
                Color.FromArgb(157, 140, 131);

            label.Location =
                new Point(73, 62);

            label.Text =
                texto;
        }

        private void ConfigurarIconeCard(
            Label label,
            string texto,
            Color backColor,
            Color foreColor)
        {
            label.BackColor =
                backColor;

            label.Font =
                new Font(
                    "Segoe UI Emoji",
                    13F);

            label.ForeColor =
                foreColor;

            label.Location =
                new Point(192, 12);

            label.Size =
                new Size(32, 32);

            label.Text =
                texto;

            label.TextAlign =
                ContentAlignment.MiddleCenter;
        }

        private void ConfigurarLabelGrafico(
            Label label,
            string texto,
            Point location)
        {
            label.AutoSize =
                true;

            label.BackColor =
                Color.Transparent;

            label.Font =
                new Font(
                    "Segoe UI",
                    6.5F);

            label.ForeColor =
                Color.FromArgb(
                    170,
                    153,
                    144);

            label.Location =
                location;

            label.Text =
                texto;
        }

        private void ConfigurarDia(
            Label label,
            string texto,
            Point location)
        {
            label.AutoSize =
                true;

            label.BackColor =
                Color.Transparent;

            label.Font =
                new Font(
                    "Segoe UI",
                    7F);

            label.ForeColor =
                Color.FromArgb(
                    150,
                    133,
                    124);

            label.Location =
                location;

            label.Text =
                texto;
        }

        private void ConfigurarBarra(
            Guna2Panel barra,
            Point location,
            Size size)
        {
            barra.BackColor =
                Color.FromArgb(
                    221,
                    153,
                    125);

            barra.BorderRadius =
                4;

            barra.FillColor =
                Color.FromArgb(
                    221,
                    153,
                    125);

            barra.Location =
                location;

            barra.Size =
                size;
        }

        // ================================================================
        // CAMPOS
        // ================================================================

        private Guna2Panel pnldash;

        private Guna2Panel pnlHeader;

        private Label lblTitulo;
        private Label lblSubTitulo;

        private Guna2Panel cardDoces;
        private Label cardDoceslblNumero;
        private Label lblCardDocesTitulo;
        private Label lblCardDocesIcone;
        private Label lblCardDocesDescricao;

        private Guna2Panel cardCategorias;
        private Label cardCategoriaslblNumero;
        private Label lblCardCategoriasTitulo;
        private Label lblCardCategoriasIcone;
        private Label lblCardCategoriasDescricao;

        private Guna2Panel pnlCardDestaques;
        private Label CardDestaquesValor;
        private Label lblCardDestaquesTitulo;
        private Label lblCardDestaquesIcone;
        private Label lblCardDestaquesDescricao;

        private Guna2Panel cardPedidos;
        private Label lblCardPedidosNumero;
        private Label lblCardPedidosTitulo;
        private Label lblCardPedidosIcone;
        private Label lblCardPedidosDescricao;

        private Guna2Panel pnlVendas;
        private Label lblVendasTitulo;
        private Label lblVendasSubtitulo;
        private Label lblVendasValor;
        private Label lblVendasPeriodo;

        private Guna2Panel pnlChart;

        private Label lblChart0;
        private Label lblChart1;
        private Label lblChart2;
        private Label lblChart3;
        private Label lblChart4;

        private Guna2Panel barra1;
        private Guna2Panel barra2;
        private Guna2Panel barra3;
        private Guna2Panel barra4;
        private Guna2Panel barra5;
        private Guna2Panel barra6;

        private Label lblSeg;
        private Label lblTer;
        private Label lblQua;
        private Label lblQui;
        private Label lblSex;
        private Label lblSab;
        private Label lblDom;

        private Guna2Panel pnlCategorias;

        private Label lblCategoriasTitulo;
        private Label lblCategoriasSubtitulo;

        private Label lblCat1;
        private Label lblCat1Qtd;
        private Guna2ProgressBar progressCat1;

        private Label lblCat2;
        private Label lblCat2Qtd;
        private Guna2ProgressBar progressCat2;

        private Label lblCat3;
        private Label lblCat3Qtd;
        private Guna2ProgressBar progressCat3;

        private Label lblCat4;
        private Label lblCat4Qtd;
        private Guna2ProgressBar progressCat4;

        private Label lblUltimosDoces;
        private Label lblUltimosSubtitulo;

        private Guna2DataGridView gridUltimosDoces;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colCategoriaDoces;
        private DataGridViewTextBoxColumn colReleaseYear;
        private DataGridViewTextBoxColumn colIsFeatured;
        private DataGridViewTextBoxColumn colCreatedAt;

        private Label lblCarregando;
        private Guna2Button btnVerTodos;
    }
}