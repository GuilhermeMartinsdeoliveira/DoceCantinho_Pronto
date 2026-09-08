namespace DoceCantinho.Desktop.UserControls
{
    partial class DoceUserControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblQuantidade;

        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Panel pnlPesquisa;

        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAtualizar;

        private System.Windows.Forms.DataGridView gridBanco;

        private System.Windows.Forms.Label lblResultados;

        private System.Windows.Forms.DataGridViewImageColumn colImagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colExcluir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new System.Windows.Forms.Label();
            lblQuantidade = new System.Windows.Forms.Label();

            pnlConteudo = new System.Windows.Forms.Panel();
            pnlPesquisa = new System.Windows.Forms.Panel();

            txtPesquisa = new System.Windows.Forms.TextBox();
            btnPesquisar = new System.Windows.Forms.Button();
            btnNovo = new System.Windows.Forms.Button();
            btnAtualizar = new System.Windows.Forms.Button();

            gridBanco = new System.Windows.Forms.DataGridView();

            lblResultados = new System.Windows.Forms.Label();

            colImagem =
                new System.Windows.Forms.DataGridViewImageColumn();

            colId =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colProduto =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colCategoria =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colPreco =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colEstoque =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colStatus =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colEditar =
                new System.Windows.Forms.DataGridViewButtonColumn();

            colExcluir =
                new System.Windows.Forms.DataGridViewButtonColumn();


            ((System.ComponentModel.ISupportInitialize)(gridBanco))
                .BeginInit();

            pnlConteudo.SuspendLayout();
            pnlPesquisa.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // TÍTULO
            // =====================================================

            lblTitulo.AutoSize = true;
            lblTitulo.Font =
                new System.Drawing.Font(
                    "Georgia",
                    20F,
                    System.Drawing.FontStyle.Bold);

            lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(61, 43, 35);

            lblTitulo.Location =
                new System.Drawing.Point(28, 20);

            lblTitulo.Name = "lblTitulo";

            lblTitulo.Size =
                new System.Drawing.Size(80, 31);

            lblTitulo.Text = "Doces";


            // =====================================================
            // QUANTIDADE
            // =====================================================

            lblQuantidade.AutoSize = true;

            lblQuantidade.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            lblQuantidade.ForeColor =
                System.Drawing.Color.FromArgb(110, 100, 95);

            lblQuantidade.Location =
                new System.Drawing.Point(30, 60);

            lblQuantidade.Name = "lblQuantidade";

            lblQuantidade.Text =
                "0 produtos cadastrados";


            // =====================================================
            // PAINEL PRINCIPAL
            // =====================================================

            pnlConteudo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            pnlConteudo.BackColor =
                System.Drawing.Color.White;

            pnlConteudo.Location =
                new System.Drawing.Point(22, 100);

            pnlConteudo.Name =
                "pnlConteudo";

            pnlConteudo.Size =
                new System.Drawing.Size(1050, 580);


            // =====================================================
            // PAINEL PESQUISA
            // =====================================================

            pnlPesquisa.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            pnlPesquisa.BackColor =
                System.Drawing.Color.FromArgb(248, 247, 246);

            pnlPesquisa.Location =
                new System.Drawing.Point(8, 8);

            pnlPesquisa.Name =
                "pnlPesquisa";

            pnlPesquisa.Size =
                new System.Drawing.Size(1034, 75);


            // =====================================================
            // TEXTBOX PESQUISA
            // =====================================================

            txtPesquisa.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            txtPesquisa.Location =
                new System.Drawing.Point(10, 20);

            txtPesquisa.Name =
                "txtPesquisa";

            txtPesquisa.PlaceholderText =
                "Buscar doce...";

            txtPesquisa.Size =
                new System.Drawing.Size(400, 25);

            txtPesquisa.TextChanged +=
                new System.EventHandler(
                    txtPesquisa_TextChanged);


            // =====================================================
            // BOTÃO PESQUISAR
            // =====================================================

            btnPesquisar.BackColor =
                System.Drawing.Color.FromArgb(180, 108, 75);

            btnPesquisar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnPesquisar.ForeColor =
                System.Drawing.Color.White;

            btnPesquisar.Location =
                new System.Drawing.Point(420, 18);

            btnPesquisar.Name =
                "btnPesquisar";

            btnPesquisar.Size =
                new System.Drawing.Size(90, 30);

            btnPesquisar.Text =
                "Buscar";

            btnPesquisar.UseVisualStyleBackColor =
                false;

            btnPesquisar.Click +=
                new System.EventHandler(
                    btnPesquisar_Click);


            // =====================================================
            // BOTÃO ATUALIZAR
            // =====================================================

            btnAtualizar.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            btnAtualizar.BackColor =
                System.Drawing.Color.FromArgb(100, 100, 100);

            btnAtualizar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnAtualizar.ForeColor =
                System.Drawing.Color.White;

            btnAtualizar.Location =
                new System.Drawing.Point(800, 18);

            btnAtualizar.Name =
                "btnAtualizar";

            btnAtualizar.Size =
                new System.Drawing.Size(100, 30);

            btnAtualizar.Text =
                "Atualizar";

            btnAtualizar.UseVisualStyleBackColor =
                false;

            btnAtualizar.Click +=
                new System.EventHandler(
                    btnAtualizar_Click);


            // =====================================================
            // BOTÃO NOVO
            // =====================================================

            btnNovo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            btnNovo.BackColor =
                System.Drawing.Color.FromArgb(180, 108, 75);

            btnNovo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnNovo.ForeColor =
                System.Drawing.Color.White;

            btnNovo.Location =
                new System.Drawing.Point(910, 18);

            btnNovo.Name =
                "btnNovo";

            btnNovo.Size =
                new System.Drawing.Size(110, 30);

            btnNovo.Text =
                "+ Novo Doce";

            btnNovo.UseVisualStyleBackColor =
                false;

            btnNovo.Click +=
                new System.EventHandler(
                    btnNovo_Click);


            // Adiciona controles da pesquisa

            pnlPesquisa.Controls.Add(txtPesquisa);
            pnlPesquisa.Controls.Add(btnPesquisar);
            pnlPesquisa.Controls.Add(btnAtualizar);
            pnlPesquisa.Controls.Add(btnNovo);


            // =====================================================
            // GRID
            // =====================================================

            gridBanco.AllowUserToAddRows = false;

            gridBanco.AllowUserToDeleteRows = false;

            gridBanco.AllowUserToResizeRows = false;

            gridBanco.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            gridBanco.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            gridBanco.BackgroundColor =
                System.Drawing.Color.White;

            gridBanco.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            gridBanco.ColumnHeadersHeight = 40;

            gridBanco.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            gridBanco.EnableHeadersVisualStyles = false;

            gridBanco.GridColor =
                System.Drawing.Color.FromArgb(230, 225, 220);

            gridBanco.Location =
                new System.Drawing.Point(8, 90);

            gridBanco.MultiSelect = false;

            gridBanco.Name =
                "gridBanco";

            gridBanco.ReadOnly = true;

            gridBanco.RowHeadersVisible = false;

            gridBanco.RowTemplate.Height = 65;

            gridBanco.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            gridBanco.Size =
                new System.Drawing.Size(1034, 440);


            // =====================================================
            // COLUNA IMAGEM
            // =====================================================

            colImagem.HeaderText = "";

            colImagem.ImageLayout =
                System.Windows.Forms.DataGridViewImageCellLayout.Zoom;

            colImagem.Name =
                "colImagem";

            colImagem.ReadOnly = true;

            colImagem.FillWeight = 40;


            // =====================================================
            // ID
            // =====================================================

            colId.HeaderText = "ID";

            colId.Name =
                "colId";

            colId.Visible = false;


            // =====================================================
            // PRODUTO
            // =====================================================

            colProduto.HeaderText =
                "PRODUTO";

            colProduto.Name =
                "colProduto";

            colProduto.ReadOnly = true;

            colProduto.FillWeight = 140;


            // =====================================================
            // CATEGORIA
            // =====================================================

            colCategoria.HeaderText =
                "CATEGORIA";

            colCategoria.Name =
                "colCategoria";

            colCategoria.ReadOnly = true;

            colCategoria.FillWeight = 100;


            // =====================================================
            // PREÇO
            // =====================================================

            colPreco.HeaderText =
                "PREÇO";

            colPreco.Name =
                "colPreco";

            colPreco.ReadOnly = true;

            colPreco.FillWeight = 70;


            // =====================================================
            // ESTOQUE
            // =====================================================

            colEstoque.HeaderText =
                "ESTOQUE";

            colEstoque.Name =
                "colEstoque";

            colEstoque.ReadOnly = true;

            colEstoque.FillWeight = 70;


            // =====================================================
            // STATUS
            // =====================================================

            colStatus.HeaderText =
                "STATUS";

            colStatus.Name =
                "colStatus";

            colStatus.ReadOnly = true;

            colStatus.FillWeight = 80;


            // =====================================================
            // EDITAR
            // =====================================================

            colEditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            colEditar.HeaderText =
                "EDITAR";

            colEditar.Name =
                "colEditar";

            colEditar.ReadOnly = true;

            colEditar.Text =
                "Editar";

            colEditar.UseColumnTextForButtonValue =
                true;

            colEditar.FillWeight = 65;


            // =====================================================
            // EXCLUIR
            // =====================================================

            colExcluir.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            colExcluir.HeaderText =
                "EXCLUIR";

            colExcluir.Name =
                "colExcluir";

            colExcluir.ReadOnly = true;

            colExcluir.Text =
                "Excluir";

            colExcluir.UseColumnTextForButtonValue =
                true;

            colExcluir.FillWeight = 65;


            // =====================================================
            // ADICIONAR COLUNAS
            // =====================================================

            gridBanco.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    colImagem,
                    colId,
                    colProduto,
                    colCategoria,
                    colPreco,
                    colEstoque,
                    colStatus,
                    colEditar,
                    colExcluir
                });


            gridBanco.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    gridBanco_CellContentClick);


            // =====================================================
            // RESULTADOS
            // =====================================================

            lblResultados.Anchor =
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            lblResultados.AutoSize = true;

            lblResultados.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            lblResultados.ForeColor =
                System.Drawing.Color.Gray;

            lblResultados.Location =
                new System.Drawing.Point(10, 545);

            lblResultados.Name =
                "lblResultados";

            lblResultados.Text =
                "0 resultados";


            // =====================================================
            // ADICIONAR AO PAINEL
            // =====================================================

            pnlConteudo.Controls.Add(pnlPesquisa);
            pnlConteudo.Controls.Add(gridBanco);
            pnlConteudo.Controls.Add(lblResultados);


            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            BackColor =
                System.Drawing.Color.FromArgb(245, 243, 241);

            Controls.Add(lblTitulo);
            Controls.Add(lblQuantidade);
            Controls.Add(pnlConteudo);

            Name =
                "DoceUserControl";

            Size =
                new System.Drawing.Size(1100, 710);


            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();

            pnlPesquisa.ResumeLayout(false);
            pnlPesquisa.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(gridBanco))
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}