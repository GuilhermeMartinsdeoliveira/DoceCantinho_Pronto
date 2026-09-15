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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlPrincipal = new Guna.UI2.WinForms.Guna2Panel();
            pnlTabela = new Guna.UI2.WinForms.Guna2Panel();
            gridBanco = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colCategoryId = new DataGridViewTextBoxColumn();
            colPreco = new DataGridViewTextBoxColumn();
            colEstoque = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colIsFeatured = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            lblResultados = new Label();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            pnlFiltros = new Guna.UI2.WinForms.Guna2Panel();
            txtPesquisa = new Guna.UI2.WinForms.Guna2TextBox();
            btnPesquisar = new Guna.UI2.WinForms.Guna2Button();
            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlPrincipal.SuspendLayout();
            pnlTabela.SuspendLayout();
            ((ISupportInitialize)gridBanco).BeginInit();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.FromArgb(247, 243, 240);
            pnlPrincipal.Controls.Add(pnlTabela);
            pnlPrincipal.Controls.Add(lblResultados);
            pnlPrincipal.Controls.Add(btnExcluir);
            pnlPrincipal.Controls.Add(btnEditar);
            pnlPrincipal.Controls.Add(pnlFiltros);
            pnlPrincipal.Controls.Add(btnNovo);
            pnlPrincipal.Controls.Add(btnAtualizar);
            pnlPrincipal.Controls.Add(lblSubtitulo);
            pnlPrincipal.Controls.Add(lblTitulo);
            pnlPrincipal.CustomizableEdges = customizableEdges17;
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.FillColor = Color.FromArgb(247, 243, 240);
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.ShadowDecoration.CustomizableEdges = customizableEdges18;
            pnlPrincipal.Size = new Size(1075, 720);
            pnlPrincipal.TabIndex = 0;
            // 
            // pnlTabela
            // 
            pnlTabela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTabela.BackColor = Color.White;
            pnlTabela.BorderColor = Color.FromArgb(235, 227, 222);
            pnlTabela.BorderRadius = 10;
            pnlTabela.Controls.Add(gridBanco);
            pnlTabela.CustomizableEdges = customizableEdges1;
            pnlTabela.FillColor = Color.White;
            pnlTabela.Location = new Point(28, 218);
            pnlTabela.Name = "pnlTabela";
            pnlTabela.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlTabela.Size = new Size(1019, 470);
            pnlTabela.TabIndex = 10;
            // 
            // gridBanco
            // 
            gridBanco.AllowUserToAddRows = false;
            gridBanco.AllowUserToDeleteRows = false;
            gridBanco.AllowUserToResizeColumns = false;
            gridBanco.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(253, 250, 248);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(65, 50, 43);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(249, 235, 229);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(65, 50, 43);
            gridBanco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridBanco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridBanco.BackgroundColor = Color.White;
            gridBanco.BorderStyle = BorderStyle.None;
            gridBanco.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridBanco.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(250, 247, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(110, 92, 82);
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 6, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(250, 247, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(110, 92, 82);
            gridBanco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridBanco.ColumnHeadersHeight = 44;
            gridBanco.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colCategoryId, colPreco, colEstoque, colStatus, colIsFeatured, colData });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(65, 50, 43);
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 6, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(249, 235, 229);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(65, 50, 43);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridBanco.DefaultCellStyle = dataGridViewCellStyle3;
            gridBanco.Dock = DockStyle.Fill;
            gridBanco.EnableHeadersVisualStyles = false;
            gridBanco.GridColor = Color.FromArgb(236, 228, 223);
            gridBanco.Location = new Point(0, 0);
            gridBanco.MultiSelect = false;
            gridBanco.Name = "gridBanco";
            gridBanco.ReadOnly = true;
            gridBanco.RowHeadersVisible = false;
            gridBanco.RowTemplate.Height = 46;
            gridBanco.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBanco.Size = new Size(1019, 470);
            gridBanco.TabIndex = 11;
            // 
            // colId
            // 
            colId.FillWeight = 40F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 45;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.FillWeight = 155F;
            colTitle.HeaderText = "PRODUTO";
            colTitle.MinimumWidth = 150;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colCategoryId
            // 
            colCategoryId.FillWeight = 115F;
            colCategoryId.HeaderText = "CATEGORIA";
            colCategoryId.MinimumWidth = 105;
            colCategoryId.Name = "colCategoryId";
            colCategoryId.ReadOnly = true;
            // 
            // colPreco
            // 
            colPreco.FillWeight = 80F;
            colPreco.HeaderText = "PREÇO";
            colPreco.MinimumWidth = 80;
            colPreco.Name = "colPreco";
            colPreco.ReadOnly = true;
            // 
            // colEstoque
            // 
            colEstoque.FillWeight = 105F;
            colEstoque.HeaderText = "ESTOQUE";
            colEstoque.MinimumWidth = 95;
            colEstoque.Name = "colEstoque";
            colEstoque.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 80F;
            colStatus.HeaderText = "STATUS";
            colStatus.MinimumWidth = 80;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colIsFeatured
            // 
            colIsFeatured.FillWeight = 80F;
            colIsFeatured.HeaderText = "DESTAQUE";
            colIsFeatured.MinimumWidth = 80;
            colIsFeatured.Name = "colIsFeatured";
            colIsFeatured.ReadOnly = true;
            // 
            // colData
            // 
            colData.FillWeight = 90F;
            colData.HeaderText = "CADASTRO";
            colData.MinimumWidth = 90;
            colData.Name = "colData";
            colData.ReadOnly = true;
            // 
            // lblResultados
            // 
            lblResultados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblResultados.AutoSize = true;
            lblResultados.BackColor = Color.Transparent;
            lblResultados.Font = new Font("Segoe UI", 8.5F);
            lblResultados.ForeColor = Color.FromArgb(150, 134, 125);
            lblResultados.Location = new Point(950, 180);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(70, 15);
            lblResultados.TabIndex = 9;
            lblResultados.Text = "0 resultados";
            // 
            // btnExcluir
            // 
            btnExcluir.Animated = true;
            btnExcluir.BorderRadius = 7;
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.CustomizableEdges = customizableEdges3;
            btnExcluir.FillColor = Color.FromArgb(229, 219, 213);
            btnExcluir.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.FromArgb(126, 72, 56);
            btnExcluir.HoverState.FillColor = Color.FromArgb(216, 203, 196);
            btnExcluir.Location = new Point(144, 169);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnExcluir.Size = new Size(108, 36);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "⌫  Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderRadius = 7;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.CustomizableEdges = customizableEdges5;
            btnEditar.FillColor = Color.FromArgb(198, 124, 99);
            btnEditar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.FillColor = Color.FromArgb(178, 105, 83);
            btnEditar.Location = new Point(28, 169);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEditar.Size = new Size(108, 36);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "✎  Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderColor = Color.FromArgb(235, 227, 222);
            pnlFiltros.BorderRadius = 10;
            pnlFiltros.Controls.Add(txtPesquisa);
            pnlFiltros.Controls.Add(btnPesquisar);
            pnlFiltros.CustomizableEdges = customizableEdges11;
            pnlFiltros.FillColor = Color.White;
            pnlFiltros.Location = new Point(28, 91);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlFiltros.Size = new Size(1019, 64);
            pnlFiltros.TabIndex = 4;
            // 
            // txtPesquisa
            // 
            txtPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPesquisa.BorderColor = Color.FromArgb(224, 214, 208);
            txtPesquisa.BorderRadius = 7;
            txtPesquisa.Cursor = Cursors.IBeam;
            txtPesquisa.CustomizableEdges = customizableEdges7;
            txtPesquisa.DefaultText = "";
            txtPesquisa.FillColor = Color.FromArgb(250, 248, 246);
            txtPesquisa.FocusedState.BorderColor = Color.FromArgb(198, 124, 99);
            txtPesquisa.Font = new Font("Segoe UI", 9F);
            txtPesquisa.ForeColor = Color.FromArgb(72, 57, 49);
            txtPesquisa.HoverState.BorderColor = Color.FromArgb(210, 170, 156);
            txtPesquisa.Location = new Point(12, 13);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.PlaceholderText = "Buscar por nome ou categoria...";
            txtPesquisa.SelectedText = "";
            txtPesquisa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPesquisa.Size = new Size(765, 38);
            txtPesquisa.TabIndex = 5;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPesquisar.Animated = true;
            btnPesquisar.BorderRadius = 7;
            btnPesquisar.Cursor = Cursors.Hand;
            btnPesquisar.CustomizableEdges = customizableEdges9;
            btnPesquisar.FillColor = Color.FromArgb(198, 124, 99);
            btnPesquisar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.HoverState.FillColor = Color.FromArgb(178, 105, 83);
            btnPesquisar.Location = new Point(789, 13);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnPesquisar.Size = new Size(115, 38);
            btnPesquisar.TabIndex = 6;
            btnPesquisar.Text = "Buscar";
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovo.Animated = true;
            btnNovo.BorderRadius = 8;
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.CustomizableEdges = customizableEdges13;
            btnNovo.FillColor = Color.FromArgb(198, 124, 99);
            btnNovo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNovo.ForeColor = Color.White;
            btnNovo.HoverState.FillColor = Color.FromArgb(178, 105, 83);
            btnNovo.Location = new Point(922, 45);
            btnNovo.Name = "btnNovo";
            btnNovo.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnNovo.Size = new Size(125, 40);
            btnNovo.TabIndex = 3;
            btnNovo.Text = "+  Novo Doce";
            btnNovo.Click += btnNovo_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAtualizar.Animated = true;
            btnAtualizar.BorderRadius = 8;
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.CustomizableEdges = customizableEdges15;
            btnAtualizar.FillColor = Color.FromArgb(101, 97, 94);
            btnAtualizar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.HoverState.FillColor = Color.FromArgb(81, 77, 74);
            btnAtualizar.Location = new Point(804, 45);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnAtualizar.Size = new Size(112, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "↻  Atualizar";
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(154, 137, 128);
            lblSubtitulo.Location = new Point(30, 59);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(129, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Carregando produtos...";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(53, 39, 33);
            lblTitulo.Location = new Point(28, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(107, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Doces";
            // 
            // DoceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 243, 240);
            Controls.Add(pnlPrincipal);
            Name = "DoceUserControl";
            Size = new Size(1075, 720);
            Load += DoceUserControl_Load;
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            pnlTabela.ResumeLayout(false);
            ((ISupportInitialize)gridBanco).EndInit();
            pnlFiltros.ResumeLayout(false);
            ResumeLayout(false);
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