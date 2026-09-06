namespace DoceCantinho.Desktop1.Forms
{
    partial class PedidoForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlCliente;
        private Guna.UI2.WinForms.Guna2Panel pnlProdutos;
        private Guna.UI2.WinForms.Guna2Panel pnlResumo;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblSelecionarCliente;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEndereco;

        private Guna.UI2.WinForms.Guna2ComboBox cmbCliente;
        private Guna.UI2.WinForms.Guna2TextBox txtNomeCliente;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefone;
        private Guna.UI2.WinForms.Guna2TextBox txtEndereco;

        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblDoce;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblPreco;

        private Guna.UI2.WinForms.Guna2ComboBox cmbDoce;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudQuantidade;
        private Guna.UI2.WinForms.Guna2TextBox txtPreco;
        private Guna.UI2.WinForms.Guna2Button btnAdicionar;

        private System.Windows.Forms.DataGridView dgvItens;

        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotal;

        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.pnlHeader =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitulo =
                new System.Windows.Forms.Label();

            this.lblSubtitulo =
                new System.Windows.Forms.Label();

            this.pnlCliente =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblCliente =
                new System.Windows.Forms.Label();

            this.lblSelecionarCliente =
                new System.Windows.Forms.Label();

            this.lblNome =
                new System.Windows.Forms.Label();

            this.lblTelefone =
                new System.Windows.Forms.Label();

            this.lblEndereco =
                new System.Windows.Forms.Label();

            this.cmbCliente =
                new Guna.UI2.WinForms.Guna2ComboBox();

            this.txtNomeCliente =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.txtTelefone =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.txtEndereco =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.pnlProdutos =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblProdutos =
                new System.Windows.Forms.Label();

            this.lblDoce =
                new System.Windows.Forms.Label();

            this.lblQuantidade =
                new System.Windows.Forms.Label();

            this.lblPreco =
                new System.Windows.Forms.Label();

            this.cmbDoce =
                new Guna.UI2.WinForms.Guna2ComboBox();

            this.nudQuantidade =
                new Guna.UI2.WinForms.Guna2NumericUpDown();

            this.txtPreco =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.btnAdicionar =
                new Guna.UI2.WinForms.Guna2Button();

            this.dgvItens =
                new System.Windows.Forms.DataGridView();

            this.pnlResumo =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblTotalTexto =
                new System.Windows.Forms.Label();

            this.lblTotal =
                new System.Windows.Forms.Label();

            this.btnCancelar =
                new Guna.UI2.WinForms.Guna2Button();

            this.btnSalvar =
                new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.nudQuantidade)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvItens)).BeginInit();

            this.SuspendLayout();

            // ============================================================
            // FORM
            // ============================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.ClientSize =
                new System.Drawing.Size(1080, 735);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name = "PedidoForm";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Novo Pedido";

            // ============================================================
            // HEADER
            // ============================================================

            this.pnlHeader.BorderRadius = 18;

            this.pnlHeader.FillColor =
                System.Drawing.Color.FromArgb(
                    43, 29, 26);

            this.pnlHeader.Location =
                new System.Drawing.Point(24, 20);

            this.pnlHeader.Name =
                "pnlHeader";

            this.pnlHeader.Size =
                new System.Drawing.Size(1032, 92);

            this.pnlHeader.TabIndex = 0;

            // ============================================================
            // TITULO
            // ============================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;

            this.lblTitulo.Location =
                new System.Drawing.Point(28, 17);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Text =
                "Novo Pedido";

            // ============================================================
            // SUBTITULO
            // ============================================================

            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(
                    225, 210, 204);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(31, 56);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Text =
                "Selecione o cliente e adicione os produtos do pedido.";

            this.pnlHeader.Controls.Add(
                this.lblTitulo);

            this.pnlHeader.Controls.Add(
                this.lblSubtitulo);

            // ============================================================
            // PAINEL CLIENTE
            // ============================================================

            this.pnlCliente.BorderRadius = 18;

            this.pnlCliente.FillColor =
                System.Drawing.Color.White;

            this.pnlCliente.Location =
                new System.Drawing.Point(24, 128);

            this.pnlCliente.Name =
                "pnlCliente";

            this.pnlCliente.Size =
                new System.Drawing.Size(1032, 170);

            this.pnlCliente.TabIndex = 1;

            // ============================================================
            // TITULO CLIENTE
            // ============================================================

            this.lblCliente.AutoSize = true;

            this.lblCliente.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblCliente.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.lblCliente.Location =
                new System.Drawing.Point(24, 14);

            this.lblCliente.Name =
                "lblCliente";

            this.lblCliente.Text =
                "Dados do cliente";

            // ============================================================
            // LABEL SELECIONAR
            // ============================================================

            this.lblSelecionarCliente.AutoSize = true;

            this.lblSelecionarCliente.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblSelecionarCliente.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblSelecionarCliente.Location =
                new System.Drawing.Point(25, 45);

            this.lblSelecionarCliente.Name =
                "lblSelecionarCliente";

            this.lblSelecionarCliente.Text =
                "Cliente cadastrado";

            // ============================================================
            // COMBO CLIENTE
            // ============================================================

            this.cmbCliente.BackColor =
                System.Drawing.Color.Transparent;

            this.cmbCliente.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.cmbCliente.BorderRadius = 10;

            this.cmbCliente.DrawMode =
                System.Windows.Forms.DrawMode.OwnerDrawFixed;

            this.cmbCliente.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCliente.FocusedColor =
                System.Drawing.Color.FromArgb(
                    201, 130, 107);

            this.cmbCliente.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.cmbCliente.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.cmbCliente.ItemHeight = 30;

            this.cmbCliente.Location =
                new System.Drawing.Point(24, 65);

            this.cmbCliente.Name =
                "cmbCliente";

            this.cmbCliente.Size =
                new System.Drawing.Size(320, 40);

            // ============================================================
            // NOME
            // ============================================================

            this.lblNome.AutoSize = true;

            this.lblNome.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblNome.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblNome.Location =
                new System.Drawing.Point(362, 45);

            this.lblNome.Name =
                "lblNome";

            this.lblNome.Text =
                "Nome / usuário";

            // ============================================================
            // TXT NOME
            // ============================================================

            this.txtNomeCliente.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.txtNomeCliente.BorderRadius = 10;

            this.txtNomeCliente.DefaultText =
                "";

            this.txtNomeCliente.FillColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.txtNomeCliente.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.txtNomeCliente.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.txtNomeCliente.Location =
                new System.Drawing.Point(361, 65);

            this.txtNomeCliente.Name =
                "txtNomeCliente";

            this.txtNomeCliente.PlaceholderText =
                "Nome ou e-mail";

            this.txtNomeCliente.ReadOnly = true;

            this.txtNomeCliente.SelectedText =
                "";

            this.txtNomeCliente.Size =
                new System.Drawing.Size(300, 40);

            // ============================================================
            // TELEFONE
            // ============================================================

            this.lblTelefone.AutoSize = true;

            this.lblTelefone.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblTelefone.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblTelefone.Location =
                new System.Drawing.Point(680, 45);

            this.lblTelefone.Name =
                "lblTelefone";

            this.lblTelefone.Text =
                "Telefone";

            // ============================================================
            // TXT TELEFONE
            // ============================================================

            this.txtTelefone.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.txtTelefone.BorderRadius = 10;

            this.txtTelefone.DefaultText =
                "";

            this.txtTelefone.FillColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.txtTelefone.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.txtTelefone.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.txtTelefone.Location =
                new System.Drawing.Point(679, 65);

            this.txtTelefone.Name =
                "txtTelefone";

            this.txtTelefone.PlaceholderText =
                "(00) 00000-0000";

            this.txtTelefone.ReadOnly = true;

            this.txtTelefone.SelectedText =
                "";

            this.txtTelefone.Size =
                new System.Drawing.Size(165, 40);

            // ============================================================
            // ENDEREÇO
            // ============================================================

            this.lblEndereco.AutoSize = true;

            this.lblEndereco.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblEndereco.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblEndereco.Location =
                new System.Drawing.Point(24, 119);

            this.lblEndereco.Name =
                "lblEndereco";

            this.lblEndereco.Text =
                "Endereço de entrega";

            // ============================================================
            // TXT ENDEREÇO
            // ============================================================

            this.txtEndereco.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.txtEndereco.BorderRadius = 10;

            this.txtEndereco.DefaultText =
                "";

            this.txtEndereco.FillColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.txtEndereco.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.txtEndereco.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.txtEndereco.Location =
                new System.Drawing.Point(174, 112);

            this.txtEndereco.Name =
                "txtEndereco";

            this.txtEndereco.PlaceholderText =
                "Endereço cadastrado";

            this.txtEndereco.ReadOnly = true;

            this.txtEndereco.SelectedText =
                "";

            this.txtEndereco.Size =
                new System.Drawing.Size(834, 40);

            // ============================================================
            // ADICIONAR CONTROLES CLIENTE
            // ============================================================

            this.pnlCliente.Controls.Add(
                this.lblCliente);

            this.pnlCliente.Controls.Add(
                this.lblSelecionarCliente);

            this.pnlCliente.Controls.Add(
                this.cmbCliente);

            this.pnlCliente.Controls.Add(
                this.lblNome);

            this.pnlCliente.Controls.Add(
                this.txtNomeCliente);

            this.pnlCliente.Controls.Add(
                this.lblTelefone);

            this.pnlCliente.Controls.Add(
                this.txtTelefone);

            this.pnlCliente.Controls.Add(
                this.lblEndereco);

            this.pnlCliente.Controls.Add(
                this.txtEndereco);

            // ============================================================
            // PAINEL PRODUTOS
            // ============================================================

            this.pnlProdutos.BorderRadius = 18;

            this.pnlProdutos.FillColor =
                System.Drawing.Color.White;

            this.pnlProdutos.Location =
                new System.Drawing.Point(24, 316);

            this.pnlProdutos.Name =
                "pnlProdutos";

            this.pnlProdutos.Size =
                new System.Drawing.Size(1032, 300);

            this.pnlProdutos.TabIndex = 2;

            // ============================================================
            // TITULO PRODUTOS
            // ============================================================

            this.lblProdutos.AutoSize = true;

            this.lblProdutos.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblProdutos.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.lblProdutos.Location =
                new System.Drawing.Point(24, 14);

            this.lblProdutos.Name =
                "lblProdutos";

            this.lblProdutos.Text =
                "Produtos do pedido";

            // ============================================================
            // LABEL DOCE
            // ============================================================

            this.lblDoce.AutoSize = true;

            this.lblDoce.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblDoce.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblDoce.Location =
                new System.Drawing.Point(25, 45);

            this.lblDoce.Name =
                "lblDoce";

            this.lblDoce.Text =
                "Produto";

            // ============================================================
            // COMBO DOCE
            // ============================================================

            this.cmbDoce.BackColor =
                System.Drawing.Color.Transparent;

            this.cmbDoce.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.cmbDoce.BorderRadius = 10;

            this.cmbDoce.DrawMode =
                System.Windows.Forms.DrawMode.OwnerDrawFixed;

            this.cmbDoce.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbDoce.FocusedColor =
                System.Drawing.Color.FromArgb(
                    201, 130, 107);

            this.cmbDoce.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.cmbDoce.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.cmbDoce.ItemHeight = 30;

            this.cmbDoce.Location =
                new System.Drawing.Point(24, 65);

            this.cmbDoce.Name =
                "cmbDoce";

            this.cmbDoce.Size =
                new System.Drawing.Size(410, 40);

            // ============================================================
            // QUANTIDADE
            // ============================================================

            this.lblQuantidade.AutoSize = true;

            this.lblQuantidade.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblQuantidade.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblQuantidade.Location =
                new System.Drawing.Point(452, 45);

            this.lblQuantidade.Name =
                "lblQuantidade";

            this.lblQuantidade.Text =
                "Quantidade";

            // ============================================================
            // NUMERIC
            // ============================================================

            this.nudQuantidade.BackColor =
                System.Drawing.Color.Transparent;

            this.nudQuantidade.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.nudQuantidade.BorderRadius = 10;

            this.nudQuantidade.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.nudQuantidade.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.nudQuantidade.Location =
                new System.Drawing.Point(451, 65);

            this.nudQuantidade.Maximum =
                new decimal(
                    new int[]
                    {
                        999,
                        0,
                        0,
                        0
                    });

            this.nudQuantidade.Minimum =
                new decimal(
                    new int[]
                    {
                        1,
                        0,
                        0,
                        0
                    });

            this.nudQuantidade.Name =
                "nudQuantidade";

            this.nudQuantidade.Size =
                new System.Drawing.Size(125, 40);

            this.nudQuantidade.TabIndex = 1;

            this.nudQuantidade.Value =
                new decimal(
                    new int[]
                    {
                        1,
                        0,
                        0,
                        0
                    });

            // ============================================================
            // PREÇO
            // ============================================================

            this.lblPreco.AutoSize = true;

            this.lblPreco.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblPreco.ForeColor =
                System.Drawing.Color.FromArgb(
                    90, 75, 70);

            this.lblPreco.Location =
                new System.Drawing.Point(600, 45);

            this.lblPreco.Name =
                "lblPreco";

            this.lblPreco.Text =
                "Preço unitário";

            this.txtPreco.BorderColor =
                System.Drawing.Color.FromArgb(
                    224, 213, 207);

            this.txtPreco.BorderRadius = 10;

            this.txtPreco.DefaultText =
                "";

            this.txtPreco.Enabled = false;

            this.txtPreco.FillColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.txtPreco.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.txtPreco.ForeColor =
                System.Drawing.Color.FromArgb(
                    55, 40, 35);

            this.txtPreco.Location =
                new System.Drawing.Point(599, 65);

            this.txtPreco.Name =
                "txtPreco";

            this.txtPreco.PlaceholderText =
                "R$ 0,00";

            this.txtPreco.ReadOnly = true;

            this.txtPreco.SelectedText =
                "";

            this.txtPreco.Size =
                new System.Drawing.Size(150, 40);

            // ============================================================
            // BOTÃO ADICIONAR
            // ============================================================

            this.btnAdicionar.Animated = true;

            this.btnAdicionar.BorderRadius = 10;

            this.btnAdicionar.FillColor =
                System.Drawing.Color.FromArgb(
                    201, 130, 107);

            this.btnAdicionar.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnAdicionar.ForeColor =
                System.Drawing.Color.White;

            this.btnAdicionar.HoverState.FillColor =
                System.Drawing.Color.FromArgb(
                    181, 108, 88);

            this.btnAdicionar.Location =
                new System.Drawing.Point(765, 65);

            this.btnAdicionar.Name =
                "btnAdicionar";

            this.btnAdicionar.Size =
                new System.Drawing.Size(243, 40);

            this.btnAdicionar.TabIndex = 2;

            this.btnAdicionar.Text =
                "+   Adicionar produto";

            // ============================================================
            // GRID
            // ============================================================

            this.dgvItens.AllowUserToAddRows = false;

            this.dgvItens.AllowUserToDeleteRows = false;

            this.dgvItens.AllowUserToResizeRows = false;

            this.dgvItens.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvItens.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvItens.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvItens.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvItens.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvItens.ColumnHeadersHeight = 38;

            this.dgvItens.EnableHeadersVisualStyles = false;

            this.dgvItens.GridColor =
                System.Drawing.Color.FromArgb(
                    238, 231, 227);

            this.dgvItens.Location =
                new System.Drawing.Point(24, 122);

            this.dgvItens.MultiSelect = false;

            this.dgvItens.Name =
                "dgvItens";

            this.dgvItens.ReadOnly = true;

            this.dgvItens.RowHeadersVisible = false;

            this.dgvItens.RowTemplate.Height = 36;

            this.dgvItens.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvItens.Size =
                new System.Drawing.Size(984, 150);

            this.dgvItens.TabIndex = 3;

            this.dgvItens.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(
                    247, 243, 240);

            this.dgvItens.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.dgvItens.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(
                    80, 65, 60);

            this.dgvItens.ColumnHeadersDefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(
                    8, 0, 8, 0);

            this.dgvItens.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.dgvItens.DefaultCellStyle.ForeColor =
                System.Drawing.Color.FromArgb(
                    65, 50, 45);

            this.dgvItens.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(
                    249, 235, 229);

            this.dgvItens.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.FromArgb(
                    65, 50, 45);

            this.dgvItens.DefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(
                    8, 0, 8, 0);

            // ============================================================
            // PAINEL RESUMO
            // ============================================================

            this.pnlResumo.BorderRadius = 18;

            this.pnlResumo.FillColor =
                System.Drawing.Color.White;

            this.pnlResumo.Location =
                new System.Drawing.Point(24, 634);

            this.pnlResumo.Name =
                "pnlResumo";

            this.pnlResumo.Size =
                new System.Drawing.Size(1032, 68);

            this.pnlResumo.TabIndex = 3;

            // ============================================================
            // TOTAL TEXTO
            // ============================================================

            this.lblTotalTexto.AutoSize = true;

            this.lblTotalTexto.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.lblTotalTexto.ForeColor =
                System.Drawing.Color.FromArgb(
                    100, 85, 80);

            this.lblTotalTexto.Location =
                new System.Drawing.Point(25, 24);

            this.lblTotalTexto.Name =
                "lblTotalTexto";

            this.lblTotalTexto.Text =
                "Total do pedido";

            // ============================================================
            // TOTAL
            // ============================================================

            this.lblTotal.AutoSize = true;

            this.lblTotal.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTotal.ForeColor =
                System.Drawing.Color.FromArgb(
                    201, 130, 107);

            this.lblTotal.Location =
                new System.Drawing.Point(165, 17);

            this.lblTotal.Name =
                "lblTotal";

            this.lblTotal.Text =
                "R$ 0,00";

            // ============================================================
            // BOTÃO CANCELAR
            // ============================================================

            this.btnCancelar.Animated = true;

            this.btnCancelar.BorderRadius = 10;

            this.btnCancelar.FillColor =
                System.Drawing.Color.FromArgb(
                    235, 228, 224);

            this.btnCancelar.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnCancelar.ForeColor =
                System.Drawing.Color.FromArgb(
                    80, 65, 60);

            this.btnCancelar.HoverState.FillColor =
                System.Drawing.Color.FromArgb(
                    220, 211, 206);

            this.btnCancelar.Location =
                new System.Drawing.Point(734, 14);

            this.btnCancelar.Name =
                "btnCancelar";

            this.btnCancelar.Size =
                new System.Drawing.Size(130, 40);

            this.btnCancelar.TabIndex = 4;

            this.btnCancelar.Text =
                "Cancelar";

            // ============================================================
            // BOTÃO SALVAR
            // ============================================================

            this.btnSalvar.Animated = true;

            this.btnSalvar.BorderRadius = 10;

            this.btnSalvar.FillColor =
                System.Drawing.Color.FromArgb(
                    201, 130, 107);

            this.btnSalvar.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnSalvar.ForeColor =
                System.Drawing.Color.White;

            this.btnSalvar.HoverState.FillColor =
                System.Drawing.Color.FromArgb(
                    181, 108, 88);

            this.btnSalvar.Location =
                new System.Drawing.Point(878, 14);

            this.btnSalvar.Name =
                "btnSalvar";

            this.btnSalvar.Size =
                new System.Drawing.Size(130, 40);

            this.btnSalvar.TabIndex = 5;

            this.btnSalvar.Text =
                "Salvar pedido";

            // ============================================================
            // CONTROLES PRODUTOS
            // ============================================================

            this.pnlProdutos.Controls.Add(
                this.lblProdutos);

            this.pnlProdutos.Controls.Add(
                this.lblDoce);

            this.pnlProdutos.Controls.Add(
                this.cmbDoce);

            this.pnlProdutos.Controls.Add(
                this.lblQuantidade);

            this.pnlProdutos.Controls.Add(
                this.nudQuantidade);

            this.pnlProdutos.Controls.Add(
                this.lblPreco);

            this.pnlProdutos.Controls.Add(
                this.txtPreco);

            this.pnlProdutos.Controls.Add(
                this.btnAdicionar);

            this.pnlProdutos.Controls.Add(
                this.dgvItens);

            // ============================================================
            // CONTROLES RESUMO
            // ============================================================

            this.pnlResumo.Controls.Add(
                this.lblTotalTexto);

            this.pnlResumo.Controls.Add(
                this.lblTotal);

            this.pnlResumo.Controls.Add(
                this.btnCancelar);

            this.pnlResumo.Controls.Add(
                this.btnSalvar);

            // ============================================================
            // CONTROLES FORM
            // ============================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlCliente);

            this.Controls.Add(
                this.pnlProdutos);

            this.Controls.Add(
                this.pnlResumo);

            ((System.ComponentModel.ISupportInitialize)
                (this.nudQuantidade)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvItens)).EndInit();

            this.ResumeLayout(false);
        }
    }
}