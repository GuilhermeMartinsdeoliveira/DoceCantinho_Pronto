using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.UserControls
{
    partial class DoceUserControl
    {
        private IContainer components = null;

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
            this.components = new Container();

            this.pnlPrincipal =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitulo =
                new Label();

            this.lblSubtitulo =
                new Label();

            this.btnAtualizar =
                new Guna.UI2.WinForms.Guna2Button();

            this.btnNovo =
                new Guna.UI2.WinForms.Guna2Button();

            this.pnlFiltros =
                new Guna.UI2.WinForms.Guna2Panel();

            this.txtPesquisa =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.btnPesquisar =
                new Guna.UI2.WinForms.Guna2Button();

            this.btnEditar =
                new Guna.UI2.WinForms.Guna2Button();

            this.btnExcluir =
                new Guna.UI2.WinForms.Guna2Button();

            this.lblResultados =
                new Label();

            this.pnlTabela =
                new Guna.UI2.WinForms.Guna2Panel();

            this.gridBanco =
                new DataGridView();

            this.colId =
                new DataGridViewTextBoxColumn();

            this.colTitle =
                new DataGridViewTextBoxColumn();

            this.colCategoryId =
                new DataGridViewTextBoxColumn();

            this.colPreco =
                new DataGridViewTextBoxColumn();

            this.colEstoque =
                new DataGridViewTextBoxColumn();

            this.colStatus =
                new DataGridViewTextBoxColumn();

            this.colIsFeatured =
                new DataGridViewTextBoxColumn();

            this.colData =
                new DataGridViewTextBoxColumn();

            ((ISupportInitialize)(this.gridBanco)).BeginInit();

            this.pnlPrincipal.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlTabela.SuspendLayout();

            this.SuspendLayout();

            // ============================================================
            // pnlPrincipal
            // ============================================================

            this.pnlPrincipal.Dock =
                DockStyle.Fill;

            this.pnlPrincipal.FillColor =
                Color.FromArgb(247, 243, 240);

            this.pnlPrincipal.BackColor =
                Color.FromArgb(247, 243, 240);

            this.pnlPrincipal.Location =
                new Point(0, 0);

            this.pnlPrincipal.Name =
                "pnlPrincipal";

            this.pnlPrincipal.Size =
                new Size(1075, 720);

            this.pnlPrincipal.TabIndex =
                0;

            // ============================================================
            // lblTitulo
            // ============================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.BackColor =
                Color.Transparent;

            this.lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Bold);

            this.lblTitulo.ForeColor =
                Color.FromArgb(53, 39, 33);

            this.lblTitulo.Location =
                new Point(28, 20);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Size =
                new Size(88, 35);

            this.lblTitulo.TabIndex =
                0;

            this.lblTitulo.Text =
                "Doces";

            // ============================================================
            // lblSubtitulo
            // ============================================================

            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.BackColor =
                Color.Transparent;

            this.lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Regular);

            this.lblSubtitulo.ForeColor =
                Color.FromArgb(154, 137, 128);

            this.lblSubtitulo.Location =
                new Point(30, 59);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Size =
                new Size(150, 15);

            this.lblSubtitulo.TabIndex =
                1;

            this.lblSubtitulo.Text =
                "Carregando produtos...";

            // ============================================================
            // btnAtualizar
            // ============================================================

            this.btnAtualizar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.btnAtualizar.Animated =
                true;

            this.btnAtualizar.BorderRadius =
                8;

            this.btnAtualizar.FillColor =
                Color.FromArgb(101, 97, 94);

            this.btnAtualizar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnAtualizar.ForeColor =
                Color.White;

            this.btnAtualizar.HoverState.FillColor =
                Color.FromArgb(81, 77, 74);

            this.btnAtualizar.Location =
                new Point(798, 25);

            this.btnAtualizar.Name =
                "btnAtualizar";

            this.btnAtualizar.Size =
                new Size(112, 40);

            this.btnAtualizar.TabIndex =
                2;

            this.btnAtualizar.Text =
                "↻  Atualizar";

            this.btnAtualizar.Cursor =
                Cursors.Hand;

            this.btnAtualizar.Click +=
                new EventHandler(
                    this.btnAtualizar_Click);

            // ============================================================
            // btnNovo
            // ============================================================

            this.btnNovo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.btnNovo.Animated =
                true;

            this.btnNovo.BorderRadius =
                8;

            this.btnNovo.FillColor =
                Color.FromArgb(198, 124, 99);

            this.btnNovo.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnNovo.ForeColor =
                Color.White;

            this.btnNovo.HoverState.FillColor =
                Color.FromArgb(178, 105, 83);

            this.btnNovo.Location =
                new Point(922, 25);

            this.btnNovo.Name =
                "btnNovo";

            this.btnNovo.Size =
                new Size(125, 40);

            this.btnNovo.TabIndex =
                3;

            this.btnNovo.Text =
                "+  Novo Doce";

            this.btnNovo.Cursor =
                Cursors.Hand;

            this.btnNovo.Click +=
                new EventHandler(
                    this.btnNovo_Click);

            // ============================================================
            // pnlFiltros
            // ============================================================

            this.pnlFiltros.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.pnlFiltros.BackColor =
                Color.White;

            this.pnlFiltros.BorderColor =
                Color.FromArgb(235, 227, 222);

            this.pnlFiltros.BorderRadius =
                10;

            this.pnlFiltros.FillColor =
                Color.White;

            this.pnlFiltros.Location =
                new Point(28, 91);

            this.pnlFiltros.Name =
                "pnlFiltros";

            this.pnlFiltros.Size =
                new Size(1019, 64);

            this.pnlFiltros.TabIndex =
                4;

            // ============================================================
            // txtPesquisa
            // ============================================================

            this.txtPesquisa.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.txtPesquisa.BorderColor =
                Color.FromArgb(224, 214, 208);

            this.txtPesquisa.BorderRadius =
                7;

            this.txtPesquisa.Cursor =
                Cursors.IBeam;

            this.txtPesquisa.FillColor =
                Color.FromArgb(250, 248, 246);

            this.txtPesquisa.FocusedState.BorderColor =
                Color.FromArgb(198, 124, 99);

            this.txtPesquisa.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.txtPesquisa.ForeColor =
                Color.FromArgb(72, 57, 49);

            this.txtPesquisa.HoverState.BorderColor =
                Color.FromArgb(210, 170, 156);

            this.txtPesquisa.Location =
                new Point(12, 13);

            this.txtPesquisa.Name =
                "txtPesquisa";

            this.txtPesquisa.PlaceholderText =
                "Buscar por nome ou categoria...";

            this.txtPesquisa.SelectedText =
                "";

            this.txtPesquisa.Size =
                new Size(765, 38);

            this.txtPesquisa.TabIndex =
                5;

            this.txtPesquisa.TextChanged +=
                new EventHandler(
                    this.txtPesquisa_TextChanged);

            // ============================================================
            // btnPesquisar
            // ============================================================

            this.btnPesquisar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.btnPesquisar.Animated =
                true;

            this.btnPesquisar.BorderRadius =
                7;

            this.btnPesquisar.FillColor =
                Color.FromArgb(198, 124, 99);

            this.btnPesquisar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnPesquisar.ForeColor =
                Color.White;

            this.btnPesquisar.HoverState.FillColor =
                Color.FromArgb(178, 105, 83);

            this.btnPesquisar.Location =
                new Point(789, 13);

            this.btnPesquisar.Name =
                "btnPesquisar";

            this.btnPesquisar.Size =
                new Size(115, 38);

            this.btnPesquisar.TabIndex =
                6;

            this.btnPesquisar.Text =
                "Buscar";

            this.btnPesquisar.Cursor =
                Cursors.Hand;

            this.btnPesquisar.Click +=
                new EventHandler(
                    this.btnPesquisar_Click);

            // ============================================================
            // btnEditar
            // ============================================================

            this.btnEditar.Animated =
                true;

            this.btnEditar.BorderRadius =
                7;

            this.btnEditar.FillColor =
                Color.FromArgb(198, 124, 99);

            this.btnEditar.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold);

            this.btnEditar.ForeColor =
                Color.White;

            this.btnEditar.HoverState.FillColor =
                Color.FromArgb(178, 105, 83);

            this.btnEditar.Location =
                new Point(28, 169);

            this.btnEditar.Name =
                "btnEditar";

            this.btnEditar.Size =
                new Size(108, 36);

            this.btnEditar.TabIndex =
                7;

            this.btnEditar.Text =
                "✎  Editar";

            this.btnEditar.Cursor =
                Cursors.Hand;

            this.btnEditar.Click +=
                new EventHandler(
                    this.btnEditar_Click);

            // ============================================================
            // btnExcluir
            // ============================================================

            this.btnExcluir.Animated =
                true;

            this.btnExcluir.BorderRadius =
                7;

            this.btnExcluir.FillColor =
                Color.FromArgb(229, 219, 213);

            this.btnExcluir.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold);

            this.btnExcluir.ForeColor =
                Color.FromArgb(126, 72, 56);

            this.btnExcluir.HoverState.FillColor =
                Color.FromArgb(216, 203, 196);

            this.btnExcluir.Location =
                new Point(144, 169);

            this.btnExcluir.Name =
                "btnExcluir";

            this.btnExcluir.Size =
                new Size(108, 36);

            this.btnExcluir.TabIndex =
                8;

            this.btnExcluir.Text =
                "⌫  Excluir";

            this.btnExcluir.Cursor =
                Cursors.Hand;

            this.btnExcluir.Click +=
                new EventHandler(
                    this.btnExcluir_Click);

            // ============================================================
            // lblResultados
            // ============================================================

            this.lblResultados.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.lblResultados.AutoSize =
                true;

            this.lblResultados.BackColor =
                Color.Transparent;

            this.lblResultados.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Regular);

            this.lblResultados.ForeColor =
                Color.FromArgb(150, 134, 125);

            this.lblResultados.Location =
                new Point(950, 180);

            this.lblResultados.Name =
                "lblResultados";

            this.lblResultados.Size =
                new Size(80, 15);

            this.lblResultados.TabIndex =
                9;

            this.lblResultados.Text =
                "0 resultados";

            // ============================================================
            // pnlTabela
            // ============================================================

            this.pnlTabela.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.pnlTabela.BackColor =
                Color.White;

            this.pnlTabela.BorderColor =
                Color.FromArgb(235, 227, 222);

            this.pnlTabela.BorderRadius =
                10;

            this.pnlTabela.FillColor =
                Color.White;

            this.pnlTabela.Location =
                new Point(28, 218);

            this.pnlTabela.Name =
                "pnlTabela";

            this.pnlTabela.Size =
                new Size(1019, 470);

            this.pnlTabela.TabIndex =
                10;

            // ============================================================
            // gridBanco
            // ============================================================

            this.gridBanco.AllowUserToAddRows =
                false;

            this.gridBanco.AllowUserToDeleteRows =
                false;

            this.gridBanco.AllowUserToResizeColumns =
                false;

            this.gridBanco.AllowUserToResizeRows =
                false;

            this.gridBanco.AutoGenerateColumns =
                false;

            this.gridBanco.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.gridBanco.BackgroundColor =
                Color.White;

            this.gridBanco.BorderStyle =
                BorderStyle.None;

            this.gridBanco.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.gridBanco.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            this.gridBanco.ColumnHeadersHeight =
                44;

            this.gridBanco.Dock =
                DockStyle.Fill;

            this.gridBanco.EnableHeadersVisualStyles =
                false;

            this.gridBanco.GridColor =
                Color.FromArgb(236, 228, 223);

            this.gridBanco.Location =
                new Point(8, 8);

            this.gridBanco.MultiSelect =
                false;

            this.gridBanco.Name =
                "gridBanco";

            this.gridBanco.ReadOnly =
                true;

            this.gridBanco.RowHeadersVisible =
                false;

            this.gridBanco.RowTemplate.Height =
                46;

            this.gridBanco.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.gridBanco.Size =
                new Size(1003, 454);

            this.gridBanco.TabIndex =
                11;

            // ============================================================
            // HEADER GRID
            // ============================================================

            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            headerStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            headerStyle.BackColor =
                Color.FromArgb(250, 247, 245);

            headerStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold);

            headerStyle.ForeColor =
                Color.FromArgb(110, 92, 82);

            headerStyle.SelectionBackColor =
                Color.FromArgb(250, 247, 245);

            headerStyle.SelectionForeColor =
                Color.FromArgb(110, 92, 82);

            headerStyle.Padding =
                new Padding(10, 0, 6, 0);

            this.gridBanco.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // ============================================================
            // LINHAS
            // ============================================================

            DataGridViewCellStyle rowStyle =
                new DataGridViewCellStyle();

            rowStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            rowStyle.BackColor =
                Color.White;

            rowStyle.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            rowStyle.ForeColor =
                Color.FromArgb(65, 50, 43);

            rowStyle.SelectionBackColor =
                Color.FromArgb(249, 235, 229);

            rowStyle.SelectionForeColor =
                Color.FromArgb(65, 50, 43);

            rowStyle.Padding =
                new Padding(10, 0, 6, 0);

            this.gridBanco.DefaultCellStyle =
                rowStyle;

            // ============================================================
            // LINHAS ALTERNADAS
            // ============================================================

            DataGridViewCellStyle alternateStyle =
                new DataGridViewCellStyle();

            alternateStyle.BackColor =
                Color.FromArgb(253, 250, 248);

            alternateStyle.ForeColor =
                Color.FromArgb(65, 50, 43);

            alternateStyle.SelectionBackColor =
                Color.FromArgb(249, 235, 229);

            alternateStyle.SelectionForeColor =
                Color.FromArgb(65, 50, 43);

            this.gridBanco.AlternatingRowsDefaultCellStyle =
                alternateStyle;

            // ============================================================
            // COLUNA ID
            // ============================================================

            this.colId.HeaderText =
                "ID";

            this.colId.Name =
                "colId";

            this.colId.ReadOnly =
                true;

            this.colId.FillWeight =
                40;

            this.colId.MinimumWidth =
                45;

            this.colId.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    Alignment =
                        DataGridViewContentAlignment.MiddleCenter
                };

            // ============================================================
            // COLUNA PRODUTO
            // ============================================================

            this.colTitle.HeaderText =
                "PRODUTO";

            this.colTitle.Name =
                "colTitle";

            this.colTitle.ReadOnly =
                true;

            this.colTitle.FillWeight =
                155;

            this.colTitle.MinimumWidth =
                150;

            // ============================================================
            // COLUNA CATEGORIA
            // ============================================================

            this.colCategoryId.HeaderText =
                "CATEGORIA";

            this.colCategoryId.Name =
                "colCategoryId";

            this.colCategoryId.ReadOnly =
                true;

            this.colCategoryId.FillWeight =
                115;

            this.colCategoryId.MinimumWidth =
                105;

            // ============================================================
            // COLUNA PREÇO
            // ============================================================

            this.colPreco.HeaderText =
                "PREÇO";

            this.colPreco.Name =
                "colPreco";

            this.colPreco.ReadOnly =
                true;

            this.colPreco.FillWeight =
                80;

            this.colPreco.MinimumWidth =
                80;

            // ============================================================
            // COLUNA ESTOQUE
            // ============================================================

            this.colEstoque.HeaderText =
                "ESTOQUE";

            this.colEstoque.Name =
                "colEstoque";

            this.colEstoque.ReadOnly =
                true;

            this.colEstoque.FillWeight =
                105;

            this.colEstoque.MinimumWidth =
                95;

            // ============================================================
            // COLUNA STATUS
            // ============================================================

            this.colStatus.HeaderText =
                "STATUS";

            this.colStatus.Name =
                "colStatus";

            this.colStatus.ReadOnly =
                true;

            this.colStatus.FillWeight =
                80;

            this.colStatus.MinimumWidth =
                80;

            // ============================================================
            // COLUNA DESTAQUE
            // ============================================================

            this.colIsFeatured.HeaderText =
                "DESTAQUE";

            this.colIsFeatured.Name =
                "colIsFeatured";

            this.colIsFeatured.ReadOnly =
                true;

            this.colIsFeatured.FillWeight =
                80;

            this.colIsFeatured.MinimumWidth =
                80;

            // ============================================================
            // COLUNA DATA
            // ============================================================

            this.colData.HeaderText =
                "CADASTRO";

            this.colData.Name =
                "colData";

            this.colData.ReadOnly =
                true;

            this.colData.FillWeight =
                90;

            this.colData.MinimumWidth =
                90;

            // ============================================================
            // COLUNAS
            // ============================================================

            this.gridBanco.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    this.colId,
                    this.colTitle,
                    this.colCategoryId,
                    this.colPreco,
                    this.colEstoque,
                    this.colStatus,
                    this.colIsFeatured,
                    this.colData
                });

            // ============================================================
            // CONTROLES
            // ============================================================

            this.pnlFiltros.Controls.Add(
                this.txtPesquisa);

            this.pnlFiltros.Controls.Add(
                this.btnPesquisar);

            this.pnlTabela.Controls.Add(
                this.gridBanco);

            this.pnlPrincipal.Controls.Add(
                this.pnlTabela);

            this.pnlPrincipal.Controls.Add(
                this.lblResultados);

            this.pnlPrincipal.Controls.Add(
                this.btnExcluir);

            this.pnlPrincipal.Controls.Add(
                this.btnEditar);

            this.pnlPrincipal.Controls.Add(
                this.pnlFiltros);

            this.pnlPrincipal.Controls.Add(
                this.btnNovo);

            this.pnlPrincipal.Controls.Add(
                this.btnAtualizar);

            this.pnlPrincipal.Controls.Add(
                this.lblSubtitulo);

            this.pnlPrincipal.Controls.Add(
                this.lblTitulo);

            // ============================================================
            // USER CONTROL
            // ============================================================

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(247, 243, 240);

            this.Controls.Add(
                this.pnlPrincipal);

            this.Name =
                "DoceUserControl";

            this.Size =
                new Size(1075, 720);

            this.Load +=
                new EventHandler(
                    this.DoceUserControl_Load);

            // ============================================================
            // FINALIZAÇÃO
            // ============================================================

            this.pnlTabela.ResumeLayout(false);

            this.pnlFiltros.ResumeLayout(false);

            ((ISupportInitialize)(this.gridBanco)).EndInit();

            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        // ================================================================
        // CONTROLES
        // ================================================================

        private Guna.UI2.WinForms.Guna2Panel pnlPrincipal;

        private Guna.UI2.WinForms.Guna2Panel pnlFiltros;

        private Guna.UI2.WinForms.Guna2Panel pnlTabela;

        private Label lblTitulo;

        private Label lblSubtitulo;

        private Label lblResultados;

        private Guna.UI2.WinForms.Guna2TextBox txtPesquisa;

        private Guna.UI2.WinForms.Guna2Button btnPesquisar;

        private Guna.UI2.WinForms.Guna2Button btnNovo;

        private Guna.UI2.WinForms.Guna2Button btnAtualizar;

        private Guna.UI2.WinForms.Guna2Button btnEditar;

        private Guna.UI2.WinForms.Guna2Button btnExcluir;

        private DataGridView gridBanco;

        private DataGridViewTextBoxColumn colId;

        private DataGridViewTextBoxColumn colTitle;

        private DataGridViewTextBoxColumn colCategoryId;

        private DataGridViewTextBoxColumn colPreco;

        private DataGridViewTextBoxColumn colEstoque;

        private DataGridViewTextBoxColumn colStatus;

        private DataGridViewTextBoxColumn colIsFeatured;

        private DataGridViewTextBoxColumn colData;
    }
}