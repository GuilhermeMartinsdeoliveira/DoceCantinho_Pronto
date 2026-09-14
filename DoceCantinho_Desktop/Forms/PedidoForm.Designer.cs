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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            BtnFechar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlCliente = new Guna.UI2.WinForms.Guna2Panel();
            lblCliente = new Label();
            lblSelecionarCliente = new Label();
            cmbCliente = new Guna.UI2.WinForms.Guna2ComboBox();
            lblNome = new Label();
            txtNomeCliente = new Guna.UI2.WinForms.Guna2TextBox();
            lblTelefone = new Label();
            txtTelefone = new Guna.UI2.WinForms.Guna2TextBox();
            lblEndereco = new Label();
            txtEndereco = new Guna.UI2.WinForms.Guna2TextBox();
            pnlProdutos = new Guna.UI2.WinForms.Guna2Panel();
            lblProdutos = new Label();
            lblDoce = new Label();
            cmbDoce = new Guna.UI2.WinForms.Guna2ComboBox();
            lblQuantidade = new Label();
            nudQuantidade = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblPreco = new Label();
            txtPreco = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdicionar = new Guna.UI2.WinForms.Guna2Button();
            dgvItens = new DataGridView();
            pnlResumo = new Guna.UI2.WinForms.Guna2Panel();
            lblTotalTexto = new Label();
            lblTotal = new Label();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pnlHeader.SuspendLayout();
            pnlCliente.SuspendLayout();
            pnlProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            pnlResumo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderRadius = 18;
            pnlHeader.Controls.Add(BtnFechar);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.CustomizableEdges = customizableEdges3;
            pnlHeader.FillColor = Color.FromArgb(43, 29, 26);
            pnlHeader.Location = new Point(27, 28);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlHeader.Size = new Size(1179, 132);
            pnlHeader.TabIndex = 0;
            // 
            // BtnFechar
            // 
            BtnFechar.BackColor = Color.FromArgb(43, 29, 26);
            BtnFechar.BorderRadius = 10;
            BtnFechar.CustomizableEdges = customizableEdges1;
            BtnFechar.DisabledState.BorderColor = Color.DarkGray;
            BtnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnFechar.FillColor = Color.FromArgb(201, 130, 107);
            BtnFechar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnFechar.ForeColor = SystemColors.Window;
            BtnFechar.Location = new Point(1111, 13);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BtnFechar.Size = new Size(55, 38);
            BtnFechar.TabIndex = 4;
            BtnFechar.Text = "X";
            BtnFechar.Click += BtnFechar_Click_1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(43, 29, 26);
            lblTitulo.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(32, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(218, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Novo Pedido";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.FromArgb(43, 29, 26);
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(225, 210, 204);
            lblSubtitulo.Location = new Point(35, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(376, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Selecione o cliente e adicione os produtos do pedido.";
            // 
            // pnlCliente
            // 
            pnlCliente.BorderRadius = 18;
            pnlCliente.Controls.Add(lblCliente);
            pnlCliente.Controls.Add(lblSelecionarCliente);
            pnlCliente.Controls.Add(cmbCliente);
            pnlCliente.Controls.Add(lblNome);
            pnlCliente.Controls.Add(txtNomeCliente);
            pnlCliente.Controls.Add(lblTelefone);
            pnlCliente.Controls.Add(txtTelefone);
            pnlCliente.Controls.Add(lblEndereco);
            pnlCliente.Controls.Add(txtEndereco);
            pnlCliente.CustomizableEdges = customizableEdges13;
            pnlCliente.FillColor = Color.White;
            pnlCliente.Location = new Point(27, 171);
            pnlCliente.Margin = new Padding(3, 4, 3, 4);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlCliente.Size = new Size(1179, 227);
            pnlCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(55, 40, 35);
            lblCliente.Location = new Point(27, 19);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(165, 28);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Dados do cliente";
            // 
            // lblSelecionarCliente
            // 
            lblSelecionarCliente.AutoSize = true;
            lblSelecionarCliente.Font = new Font("Segoe UI", 9F);
            lblSelecionarCliente.ForeColor = Color.FromArgb(90, 75, 70);
            lblSelecionarCliente.Location = new Point(29, 60);
            lblSelecionarCliente.Name = "lblSelecionarCliente";
            lblSelecionarCliente.Size = new Size(133, 20);
            lblSelecionarCliente.TabIndex = 1;
            lblSelecionarCliente.Text = "Cliente cadastrado";
            // 
            // cmbCliente
            // 
            cmbCliente.BackColor = Color.Transparent;
            cmbCliente.BorderColor = Color.FromArgb(224, 213, 207);
            cmbCliente.BorderRadius = 10;
            cmbCliente.CustomizableEdges = customizableEdges5;
            cmbCliente.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FocusedColor = Color.FromArgb(201, 130, 107);
            cmbCliente.FocusedState.BorderColor = Color.FromArgb(201, 130, 107);
            cmbCliente.Font = new Font("Segoe UI", 9.5F);
            cmbCliente.ForeColor = Color.FromArgb(55, 40, 35);
            cmbCliente.ItemHeight = 30;
            cmbCliente.Location = new Point(27, 87);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbCliente.Size = new Size(365, 36);
            cmbCliente.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9F);
            lblNome.ForeColor = Color.FromArgb(90, 75, 70);
            lblNome.Location = new Point(414, 60);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(112, 20);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome / usuário";
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.BorderColor = Color.FromArgb(224, 213, 207);
            txtNomeCliente.BorderRadius = 10;
            txtNomeCliente.CustomizableEdges = customizableEdges7;
            txtNomeCliente.DefaultText = "";
            txtNomeCliente.FillColor = Color.FromArgb(247, 243, 240);
            txtNomeCliente.Font = new Font("Segoe UI", 9.5F);
            txtNomeCliente.ForeColor = Color.FromArgb(55, 40, 35);
            txtNomeCliente.Location = new Point(413, 87);
            txtNomeCliente.Margin = new Padding(3, 5, 3, 5);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.PlaceholderText = "Nome ou e-mail";
            txtNomeCliente.ReadOnly = true;
            txtNomeCliente.SelectedText = "";
            txtNomeCliente.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtNomeCliente.Size = new Size(343, 53);
            txtNomeCliente.TabIndex = 4;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI", 9F);
            lblTelefone.ForeColor = Color.FromArgb(90, 75, 70);
            lblTelefone.Location = new Point(777, 60);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(66, 20);
            lblTelefone.TabIndex = 5;
            lblTelefone.Text = "Telefone";
            // 
            // txtTelefone
            // 
            txtTelefone.BorderColor = Color.FromArgb(224, 213, 207);
            txtTelefone.BorderRadius = 10;
            txtTelefone.CustomizableEdges = customizableEdges9;
            txtTelefone.DefaultText = "";
            txtTelefone.FillColor = Color.FromArgb(247, 243, 240);
            txtTelefone.Font = new Font("Segoe UI", 9.5F);
            txtTelefone.ForeColor = Color.FromArgb(55, 40, 35);
            txtTelefone.Location = new Point(776, 87);
            txtTelefone.Margin = new Padding(3, 5, 3, 5);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.PlaceholderText = "(00) 00000-0000";
            txtTelefone.ReadOnly = true;
            txtTelefone.SelectedText = "";
            txtTelefone.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtTelefone.Size = new Size(189, 53);
            txtTelefone.TabIndex = 6;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Font = new Font("Segoe UI", 9F);
            lblEndereco.ForeColor = Color.FromArgb(90, 75, 70);
            lblEndereco.Location = new Point(27, 159);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(147, 20);
            lblEndereco.TabIndex = 7;
            lblEndereco.Text = "Endereço de entrega";
            // 
            // txtEndereco
            // 
            txtEndereco.BorderColor = Color.FromArgb(224, 213, 207);
            txtEndereco.BorderRadius = 10;
            txtEndereco.CustomizableEdges = customizableEdges11;
            txtEndereco.DefaultText = "";
            txtEndereco.FillColor = Color.FromArgb(247, 243, 240);
            txtEndereco.Font = new Font("Segoe UI", 9.5F);
            txtEndereco.ForeColor = Color.FromArgb(55, 40, 35);
            txtEndereco.Location = new Point(199, 149);
            txtEndereco.Margin = new Padding(3, 5, 3, 5);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.PlaceholderText = "Endereço cadastrado";
            txtEndereco.ReadOnly = true;
            txtEndereco.SelectedText = "";
            txtEndereco.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtEndereco.Size = new Size(953, 53);
            txtEndereco.TabIndex = 8;
            // 
            // pnlProdutos
            // 
            pnlProdutos.BorderRadius = 18;
            pnlProdutos.Controls.Add(lblProdutos);
            pnlProdutos.Controls.Add(lblDoce);
            pnlProdutos.Controls.Add(cmbDoce);
            pnlProdutos.Controls.Add(lblQuantidade);
            pnlProdutos.Controls.Add(nudQuantidade);
            pnlProdutos.Controls.Add(lblPreco);
            pnlProdutos.Controls.Add(txtPreco);
            pnlProdutos.Controls.Add(btnAdicionar);
            pnlProdutos.Controls.Add(dgvItens);
            pnlProdutos.CustomizableEdges = customizableEdges23;
            pnlProdutos.FillColor = Color.White;
            pnlProdutos.Location = new Point(27, 421);
            pnlProdutos.Margin = new Padding(3, 4, 3, 4);
            pnlProdutos.Name = "pnlProdutos";
            pnlProdutos.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlProdutos.Size = new Size(1179, 400);
            pnlProdutos.TabIndex = 2;
            // 
            // lblProdutos
            // 
            lblProdutos.AutoSize = true;
            lblProdutos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblProdutos.ForeColor = Color.FromArgb(55, 40, 35);
            lblProdutos.Location = new Point(27, 19);
            lblProdutos.Name = "lblProdutos";
            lblProdutos.Size = new Size(195, 28);
            lblProdutos.TabIndex = 0;
            lblProdutos.Text = "Produtos do pedido";
            // 
            // lblDoce
            // 
            lblDoce.AutoSize = true;
            lblDoce.Font = new Font("Segoe UI", 9F);
            lblDoce.ForeColor = Color.FromArgb(90, 75, 70);
            lblDoce.Location = new Point(29, 60);
            lblDoce.Name = "lblDoce";
            lblDoce.Size = new Size(62, 20);
            lblDoce.TabIndex = 1;
            lblDoce.Text = "Produto";
            // 
            // cmbDoce
            // 
            cmbDoce.BackColor = Color.Transparent;
            cmbDoce.BorderColor = Color.FromArgb(224, 213, 207);
            cmbDoce.BorderRadius = 10;
            cmbDoce.CustomizableEdges = customizableEdges15;
            cmbDoce.DrawMode = DrawMode.OwnerDrawFixed;
            cmbDoce.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoce.FocusedColor = Color.FromArgb(201, 130, 107);
            cmbDoce.FocusedState.BorderColor = Color.FromArgb(201, 130, 107);
            cmbDoce.Font = new Font("Segoe UI", 9.5F);
            cmbDoce.ForeColor = Color.FromArgb(55, 40, 35);
            cmbDoce.ItemHeight = 30;
            cmbDoce.Location = new Point(27, 87);
            cmbDoce.Margin = new Padding(3, 4, 3, 4);
            cmbDoce.Name = "cmbDoce";
            cmbDoce.ShadowDecoration.CustomizableEdges = customizableEdges16;
            cmbDoce.Size = new Size(468, 36);
            cmbDoce.TabIndex = 2;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Font = new Font("Segoe UI", 9F);
            lblQuantidade.ForeColor = Color.FromArgb(90, 75, 70);
            lblQuantidade.Location = new Point(517, 60);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(87, 20);
            lblQuantidade.TabIndex = 3;
            lblQuantidade.Text = "Quantidade";
            // 
            // nudQuantidade
            // 
            nudQuantidade.BackColor = Color.Transparent;
            nudQuantidade.BorderColor = Color.FromArgb(224, 213, 207);
            nudQuantidade.BorderRadius = 10;
            nudQuantidade.Cursor = Cursors.IBeam;
            nudQuantidade.CustomizableEdges = customizableEdges17;
            nudQuantidade.Font = new Font("Segoe UI", 9.5F);
            nudQuantidade.Location = new Point(515, 87);
            nudQuantidade.Margin = new Padding(3, 5, 3, 5);
            nudQuantidade.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.ShadowDecoration.CustomizableEdges = customizableEdges18;
            nudQuantidade.Size = new Size(143, 53);
            nudQuantidade.TabIndex = 1;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 9F);
            lblPreco.ForeColor = Color.FromArgb(90, 75, 70);
            lblPreco.Location = new Point(686, 60);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(101, 20);
            lblPreco.TabIndex = 4;
            lblPreco.Text = "Preço unitário";
            // 
            // txtPreco
            // 
            txtPreco.BorderColor = Color.FromArgb(224, 213, 207);
            txtPreco.BorderRadius = 10;
            txtPreco.CustomizableEdges = customizableEdges19;
            txtPreco.DefaultText = "";
            txtPreco.Enabled = false;
            txtPreco.FillColor = Color.FromArgb(247, 243, 240);
            txtPreco.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            txtPreco.ForeColor = Color.FromArgb(55, 40, 35);
            txtPreco.Location = new Point(685, 87);
            txtPreco.Margin = new Padding(3, 5, 3, 5);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "R$ 0,00";
            txtPreco.ReadOnly = true;
            txtPreco.SelectedText = "";
            txtPreco.ShadowDecoration.CustomizableEdges = customizableEdges20;
            txtPreco.Size = new Size(171, 53);
            txtPreco.TabIndex = 5;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Animated = true;
            btnAdicionar.BorderRadius = 10;
            btnAdicionar.CustomizableEdges = customizableEdges21;
            btnAdicionar.FillColor = Color.FromArgb(201, 130, 107);
            btnAdicionar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.HoverState.FillColor = Color.FromArgb(181, 108, 88);
            btnAdicionar.Location = new Point(874, 87);
            btnAdicionar.Margin = new Padding(3, 4, 3, 4);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnAdicionar.Size = new Size(278, 53);
            btnAdicionar.TabIndex = 2;
            btnAdicionar.Text = "+   Adicionar produto";
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.AllowUserToResizeRows = false;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItens.BackgroundColor = Color.White;
            dgvItens.BorderStyle = BorderStyle.None;
            dgvItens.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItens.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 243, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(80, 65, 60);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvItens.ColumnHeadersHeight = 38;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(65, 50, 45);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(249, 235, 229);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(65, 50, 45);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvItens.DefaultCellStyle = dataGridViewCellStyle2;
            dgvItens.EnableHeadersVisualStyles = false;
            dgvItens.GridColor = Color.FromArgb(238, 231, 227);
            dgvItens.Location = new Point(27, 163);
            dgvItens.Margin = new Padding(3, 4, 3, 4);
            dgvItens.MultiSelect = false;
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.RowHeadersVisible = false;
            dgvItens.RowHeadersWidth = 51;
            dgvItens.RowTemplate.Height = 36;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(1125, 200);
            dgvItens.TabIndex = 3;
            // 
            // pnlResumo
            // 
            pnlResumo.BorderRadius = 18;
            pnlResumo.Controls.Add(lblTotalTexto);
            pnlResumo.Controls.Add(lblTotal);
            pnlResumo.Controls.Add(btnCancelar);
            pnlResumo.Controls.Add(btnSalvar);
            pnlResumo.CustomizableEdges = customizableEdges29;
            pnlResumo.FillColor = Color.White;
            pnlResumo.Location = new Point(27, 845);
            pnlResumo.Margin = new Padding(3, 4, 3, 4);
            pnlResumo.Name = "pnlResumo";
            pnlResumo.ShadowDecoration.CustomizableEdges = customizableEdges30;
            pnlResumo.Size = new Size(1179, 91);
            pnlResumo.TabIndex = 3;
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.Font = new Font("Segoe UI", 9.5F);
            lblTotalTexto.ForeColor = Color.FromArgb(100, 85, 80);
            lblTotalTexto.Location = new Point(29, 32);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(116, 21);
            lblTotalTexto.TabIndex = 0;
            lblTotalTexto.Text = "Total do pedido";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(201, 130, 107);
            lblTotal.Location = new Point(189, 23);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 41);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "R$ 0,00";
            // 
            // btnCancelar
            // 
            btnCancelar.Animated = true;
            btnCancelar.BorderRadius = 10;
            btnCancelar.CustomizableEdges = customizableEdges25;
            btnCancelar.FillColor = Color.FromArgb(235, 228, 224);
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 65, 60);
            btnCancelar.HoverState.FillColor = Color.FromArgb(220, 211, 206);
            btnCancelar.Location = new Point(839, 19);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnCancelar.Size = new Size(149, 53);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            // 
            // btnSalvar
            // 
            btnSalvar.Animated = true;
            btnSalvar.BorderRadius = 10;
            btnSalvar.CustomizableEdges = customizableEdges27;
            btnSalvar.FillColor = Color.FromArgb(201, 130, 107);
            btnSalvar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.HoverState.FillColor = Color.FromArgb(181, 108, 88);
            btnSalvar.Location = new Point(1003, 19);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnSalvar.Size = new Size(149, 53);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar pedido";
            // 
            // PedidoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 243, 240);
            ClientSize = new Size(1234, 980);
            Controls.Add(pnlHeader);
            Controls.Add(pnlCliente);
            Controls.Add(pnlProdutos);
            Controls.Add(pnlResumo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PedidoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo Pedido";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCliente.ResumeLayout(false);
            pnlCliente.PerformLayout();
            pnlProdutos.ResumeLayout(false);
            pnlProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            pnlResumo.ResumeLayout(false);
            pnlResumo.PerformLayout();
            ResumeLayout(false);
        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2Button BtnFechar;
    }
}