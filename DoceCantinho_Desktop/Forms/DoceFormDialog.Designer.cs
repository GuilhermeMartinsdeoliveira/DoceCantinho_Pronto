namespace DoceCantinho.Desktop.Forms
{
    partial class DoceFormDialog
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;

        private Guna.UI2.WinForms.Guna2Panel pnlPrincipal;
        private Guna.UI2.WinForms.Guna2Panel pnlCabecalho;
        private Guna.UI2.WinForms.Guna2Panel pnlConteudo;
        private Guna.UI2.WinForms.Guna2Panel pnlImagem;
        private Guna.UI2.WinForms.Guna2Panel pnlOpcoes;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.Label lblCategoria;

        private System.Windows.Forms.Label lblImagemTitulo;
        private System.Windows.Forms.Label lblImagemUrl;
        private System.Windows.Forms.Label lblImagemArquivo;
        private System.Windows.Forms.Label lblArquivoSelecionado;

        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.PictureBox picturePreview;

        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtDescricao;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudPreco;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudEstoque;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtUrl;

        private Guna.UI2.WinForms.Guna2Button btnSelecionarImagem;
        private Guna.UI2.WinForms.Guna2Button btnLimparImagem;

        /*
         * ============================================================
         * COMPATIBILIDADE COM O DoceFormDialog.cs ANTIGO
         * ============================================================
         *
         * O código antigo utiliza estes nomes.
         * Eles apontarão para os controles novos.
         */

        private Guna.UI2.WinForms.Guna2Button btnRemoverImagem;
        private System.Windows.Forms.Label lblArquivoImagem;
        private System.Windows.Forms.PictureBox pictureImagem;

        private Guna.UI2.WinForms.Guna2CheckBox chkDestaque;
        private Guna.UI2.WinForms.Guna2CheckBox chkRecomendado;

        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;

        private System.Windows.Forms.OpenFileDialog openFileDialogImagem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            pnlPrincipal = new Guna.UI2.WinForms.Guna2Panel();
            pnlCabecalho = new Guna.UI2.WinForms.Guna2Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlConteudo = new Guna.UI2.WinForms.Guna2Panel();
            lblNome = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            lblDescricao = new Label();
            txtDescricao = new Guna.UI2.WinForms.Guna2TextBox();
            lblPreco = new Label();
            nudPreco = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblEstoque = new Label();
            nudEstoque = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblCategoria = new Label();
            cmbCategoria = new Guna.UI2.WinForms.Guna2ComboBox();
            pnlImagem = new Guna.UI2.WinForms.Guna2Panel();
            lblImagemTitulo = new Label();
            lblImagemUrl = new Label();
            txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            lblImagemArquivo = new Label();
            btnSelecionarImagem = new Guna.UI2.WinForms.Guna2Button();
            lblArquivoSelecionado = new Label();
            btnLimparImagem = new Guna.UI2.WinForms.Guna2Button();
            lblPreview = new Label();
            picturePreview = new PictureBox();
            pnlOpcoes = new Guna.UI2.WinForms.Guna2Panel();
            chkDestaque = new Guna.UI2.WinForms.Guna2CheckBox();
            chkRecomendado = new Guna.UI2.WinForms.Guna2CheckBox();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            openFileDialogImagem = new OpenFileDialog();
            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).BeginInit();
            pnlImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePreview).BeginInit();
            pnlOpcoes.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 14;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BorderRadius = 14;
            pnlPrincipal.Controls.Add(pnlCabecalho);
            pnlPrincipal.Controls.Add(pnlConteudo);
            pnlPrincipal.Controls.Add(pnlImagem);
            pnlPrincipal.Controls.Add(pnlOpcoes);
            pnlPrincipal.Controls.Add(btnSalvar);
            pnlPrincipal.Controls.Add(btnCancelar);
            pnlPrincipal.CustomizableEdges = customizableEdges29;
            pnlPrincipal.FillColor = Color.White;
            pnlPrincipal.Location = new Point(10, 10);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.ShadowDecoration.CustomizableEdges = customizableEdges30;
            pnlPrincipal.Size = new Size(800, 700);
            pnlPrincipal.TabIndex = 0;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.BackColor = Color.Transparent;
            pnlCabecalho.Controls.Add(lblTitulo);
            pnlCabecalho.Controls.Add(lblSubtitulo);
            pnlCabecalho.CustomizableEdges = customizableEdges1;
            pnlCabecalho.FillColor = Color.FromArgb(250, 247, 244);
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCabecalho.Size = new Size(800, 82);
            pnlCabecalho.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Georgia", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(58, 40, 34);
            lblTitulo.Location = new Point(28, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 31);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "➕ Novo Doce";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(145, 117, 105);
            lblSubtitulo.Location = new Point(31, 51);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(246, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Cadastre um novo produto no DoceCantinho";
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.Transparent;
            pnlConteudo.Controls.Add(lblNome);
            pnlConteudo.Controls.Add(txtTitulo);
            pnlConteudo.Controls.Add(lblDescricao);
            pnlConteudo.Controls.Add(txtDescricao);
            pnlConteudo.Controls.Add(lblPreco);
            pnlConteudo.Controls.Add(nudPreco);
            pnlConteudo.Controls.Add(lblEstoque);
            pnlConteudo.Controls.Add(nudEstoque);
            pnlConteudo.Controls.Add(lblCategoria);
            pnlConteudo.Controls.Add(cmbCategoria);
            pnlConteudo.CustomizableEdges = customizableEdges13;
            pnlConteudo.FillColor = Color.Transparent;
            pnlConteudo.Location = new Point(28, 98);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlConteudo.Size = new Size(360, 405);
            pnlConteudo.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(72, 52, 45);
            lblNome.Location = new Point(2, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(88, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome do doce";
            // 
            // txtTitulo
            // 
            txtTitulo.BorderColor = Color.FromArgb(220, 208, 201);
            txtTitulo.BorderRadius = 8;
            txtTitulo.Cursor = Cursors.IBeam;
            txtTitulo.CustomizableEdges = customizableEdges3;
            txtTitulo.DefaultText = "";
            txtTitulo.FillColor = Color.WhiteSmoke;
            txtTitulo.Font = new Font("Segoe UI", 9.5F);
            txtTitulo.ForeColor = Color.FromArgb(60, 45, 40);
            txtTitulo.Location = new Point(0, 22);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex.: Brigadeiro Gourmet";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTitulo.Size = new Size(350, 42);
            txtTitulo.TabIndex = 1;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescricao.ForeColor = Color.FromArgb(72, 52, 45);
            lblDescricao.Location = new Point(2, 78);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(61, 15);
            lblDescricao.TabIndex = 2;
            lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            txtDescricao.BorderColor = Color.FromArgb(220, 208, 201);
            txtDescricao.BorderRadius = 8;
            txtDescricao.Cursor = Cursors.IBeam;
            txtDescricao.CustomizableEdges = customizableEdges5;
            txtDescricao.DefaultText = "";
            txtDescricao.FillColor = Color.WhiteSmoke;
            txtDescricao.Font = new Font("Segoe UI", 9.5F);
            txtDescricao.Location = new Point(0, 100);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Conte um pouco sobre esse doce...";
            txtDescricao.ScrollBars = ScrollBars.Vertical;
            txtDescricao.SelectedText = "";
            txtDescricao.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDescricao.Size = new Size(350, 100);
            txtDescricao.TabIndex = 3;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreco.ForeColor = Color.FromArgb(72, 52, 45);
            lblPreco.Location = new Point(2, 215);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(39, 15);
            lblPreco.TabIndex = 4;
            lblPreco.Text = "Preço";
            // 
            // nudPreco
            // 
            nudPreco.BackColor = Color.Transparent;
            nudPreco.BorderColor = Color.FromArgb(220, 208, 201);
            nudPreco.BorderRadius = 8;
            nudPreco.CustomizableEdges = customizableEdges7;
            nudPreco.DecimalPlaces = 2;
            nudPreco.FillColor = Color.WhiteSmoke;
            nudPreco.Font = new Font("Segoe UI", 9.5F);
            nudPreco.Location = new Point(0, 237);
            nudPreco.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.ShadowDecoration.CustomizableEdges = customizableEdges8;
            nudPreco.Size = new Size(350, 42);
            nudPreco.TabIndex = 5;
            nudPreco.ThousandsSeparator = true;
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstoque.ForeColor = Color.FromArgb(72, 52, 45);
            lblEstoque.Location = new Point(2, 292);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(51, 15);
            lblEstoque.TabIndex = 6;
            lblEstoque.Text = "Estoque";
            // 
            // nudEstoque
            // 
            nudEstoque.BackColor = Color.Transparent;
            nudEstoque.BorderColor = Color.FromArgb(220, 208, 201);
            nudEstoque.BorderRadius = 8;
            nudEstoque.CustomizableEdges = customizableEdges9;
            nudEstoque.FillColor = Color.WhiteSmoke;
            nudEstoque.Font = new Font("Segoe UI", 9.5F);
            nudEstoque.Location = new Point(0, 314);
            nudEstoque.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudEstoque.Name = "nudEstoque";
            nudEstoque.ShadowDecoration.CustomizableEdges = customizableEdges10;
            nudEstoque.Size = new Size(350, 42);
            nudEstoque.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(72, 52, 45);
            lblCategoria.Location = new Point(2, 369);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(60, 15);
            lblCategoria.TabIndex = 8;
            lblCategoria.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.Transparent;
            cmbCategoria.BorderColor = Color.FromArgb(220, 208, 201);
            cmbCategoria.BorderRadius = 8;
            cmbCategoria.CustomizableEdges = customizableEdges11;
            cmbCategoria.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FillColor = Color.WhiteSmoke;
            cmbCategoria.FocusedColor = Color.Empty;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.ForeColor = Color.FromArgb(60, 45, 40);
            cmbCategoria.ItemHeight = 30;
            cmbCategoria.Location = new Point(0, 391);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbCategoria.Size = new Size(350, 36);
            cmbCategoria.TabIndex = 9;
            // 
            // pnlImagem
            // 
            pnlImagem.BackColor = Color.Transparent;
            pnlImagem.BorderColor = Color.FromArgb(235, 226, 221);
            pnlImagem.BorderRadius = 10;
            pnlImagem.BorderThickness = 1;
            pnlImagem.Controls.Add(lblImagemTitulo);
            pnlImagem.Controls.Add(lblImagemUrl);
            pnlImagem.Controls.Add(txtUrl);
            pnlImagem.Controls.Add(lblImagemArquivo);
            pnlImagem.Controls.Add(btnSelecionarImagem);
            pnlImagem.Controls.Add(lblArquivoSelecionado);
            pnlImagem.Controls.Add(btnLimparImagem);
            pnlImagem.Controls.Add(lblPreview);
            pnlImagem.Controls.Add(picturePreview);
            pnlImagem.CustomizableEdges = customizableEdges21;
            pnlImagem.FillColor = Color.FromArgb(250, 247, 244);
            pnlImagem.Location = new Point(410, 98);
            pnlImagem.Name = "pnlImagem";
            pnlImagem.ShadowDecoration.CustomizableEdges = customizableEdges22;
            pnlImagem.Size = new Size(360, 405);
            pnlImagem.TabIndex = 2;
            // 
            // lblImagemTitulo
            // 
            lblImagemTitulo.AutoSize = true;
            lblImagemTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblImagemTitulo.ForeColor = Color.FromArgb(72, 52, 45);
            lblImagemTitulo.Location = new Point(18, 16);
            lblImagemTitulo.Name = "lblImagemTitulo";
            lblImagemTitulo.Size = new Size(150, 20);
            lblImagemTitulo.TabIndex = 0;
            lblImagemTitulo.Text = "Imagem do produto";
            // 
            // lblImagemUrl
            // 
            lblImagemUrl.AutoSize = true;
            lblImagemUrl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImagemUrl.ForeColor = Color.FromArgb(95, 73, 65);
            lblImagemUrl.Location = new Point(18, 51);
            lblImagemUrl.Name = "lblImagemUrl";
            lblImagemUrl.Size = new Size(87, 15);
            lblImagemUrl.TabIndex = 1;
            lblImagemUrl.Text = "Imagem (URL)";
            // 
            // txtUrl
            // 
            txtUrl.BorderColor = Color.FromArgb(220, 208, 201);
            txtUrl.BorderRadius = 8;
            txtUrl.Cursor = Cursors.IBeam;
            txtUrl.CustomizableEdges = customizableEdges15;
            txtUrl.DefaultText = "";
            txtUrl.Font = new Font("Segoe UI", 9F);
            txtUrl.ForeColor = Color.FromArgb(60, 45, 40);
            txtUrl.Location = new Point(18, 74);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "https://exemplo.com/imagem.jpg";
            txtUrl.SelectedText = "";
            txtUrl.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtUrl.Size = new Size(324, 40);
            txtUrl.TabIndex = 2;
            // 
            // lblImagemArquivo
            // 
            lblImagemArquivo.AutoSize = true;
            lblImagemArquivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImagemArquivo.ForeColor = Color.FromArgb(95, 73, 65);
            lblImagemArquivo.Location = new Point(18, 127);
            lblImagemArquivo.Name = "lblImagemArquivo";
            lblImagemArquivo.Size = new Size(134, 15);
            lblImagemArquivo.TabIndex = 3;
            lblImagemArquivo.Text = "Imagem (arquivo local)";
            // 
            // btnSelecionarImagem
            // 
            btnSelecionarImagem.BorderRadius = 7;
            btnSelecionarImagem.CustomizableEdges = customizableEdges17;
            btnSelecionarImagem.FillColor = Color.FromArgb(198, 124, 99);
            btnSelecionarImagem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelecionarImagem.ForeColor = Color.White;
            btnSelecionarImagem.Location = new Point(18, 151);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnSelecionarImagem.Size = new Size(145, 38);
            btnSelecionarImagem.TabIndex = 4;
            btnSelecionarImagem.Text = "📁 Escolher arquivo";
            // 
            // lblArquivoSelecionado
            // 
            lblArquivoSelecionado.AutoEllipsis = true;
            lblArquivoSelecionado.Font = new Font("Segoe UI", 8.5F);
            lblArquivoSelecionado.ForeColor = Color.FromArgb(125, 105, 95);
            lblArquivoSelecionado.Location = new Point(18, 195);
            lblArquivoSelecionado.Name = "lblArquivoSelecionado";
            lblArquivoSelecionado.Size = new Size(260, 35);
            lblArquivoSelecionado.TabIndex = 5;
            lblArquivoSelecionado.Text = "Nenhum arquivo selecionado";
            // 
            // btnLimparImagem
            // 
            btnLimparImagem.BorderRadius = 7;
            btnLimparImagem.CustomizableEdges = customizableEdges19;
            btnLimparImagem.FillColor = Color.FromArgb(230, 223, 219);
            btnLimparImagem.Font = new Font("Segoe UI", 8.5F);
            btnLimparImagem.ForeColor = Color.FromArgb(90, 70, 62);
            btnLimparImagem.Location = new Point(238, 151);
            btnLimparImagem.Name = "btnLimparImagem";
            btnLimparImagem.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnLimparImagem.Size = new Size(104, 38);
            btnLimparImagem.TabIndex = 6;
            btnLimparImagem.Text = "Limpar";
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreview.ForeColor = Color.FromArgb(95, 73, 65);
            lblPreview.Location = new Point(18, 237);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(96, 15);
            lblPreview.TabIndex = 7;
            lblPreview.Text = "Pré-visualização";
            // 
            // picturePreview
            // 
            picturePreview.BackColor = Color.FromArgb(239, 233, 229);
            picturePreview.BorderStyle = BorderStyle.FixedSingle;
            picturePreview.Location = new Point(18, 263);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(145, 120);
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picturePreview.TabIndex = 8;
            picturePreview.TabStop = false;
            // 
            // pnlOpcoes
            // 
            pnlOpcoes.BackColor = Color.Transparent;
            pnlOpcoes.BorderRadius = 9;
            pnlOpcoes.Controls.Add(chkDestaque);
            pnlOpcoes.Controls.Add(chkRecomendado);
            pnlOpcoes.CustomizableEdges = customizableEdges23;
            pnlOpcoes.FillColor = Color.FromArgb(250, 247, 244);
            pnlOpcoes.Location = new Point(28, 520);
            pnlOpcoes.Name = "pnlOpcoes";
            pnlOpcoes.ShadowDecoration.CustomizableEdges = customizableEdges24;
            pnlOpcoes.Size = new Size(742, 70);
            pnlOpcoes.TabIndex = 3;
            // 
            // chkDestaque
            // 
            chkDestaque.AutoSize = true;
            chkDestaque.CheckedState.BorderColor = Color.FromArgb(198, 124, 99);
            chkDestaque.CheckedState.BorderRadius = 0;
            chkDestaque.CheckedState.BorderThickness = 0;
            chkDestaque.CheckedState.FillColor = Color.FromArgb(198, 124, 99);
            chkDestaque.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkDestaque.ForeColor = Color.FromArgb(75, 55, 48);
            chkDestaque.Location = new Point(20, 23);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(184, 19);
            chkDestaque.TabIndex = 0;
            chkDestaque.Text = "⭐ Destacar este doce na loja";
            chkDestaque.UncheckedState.BorderRadius = 0;
            chkDestaque.UncheckedState.BorderThickness = 0;
            // 
            // chkRecomendado
            // 
            chkRecomendado.AutoSize = true;
            chkRecomendado.CheckedState.BorderColor = Color.FromArgb(198, 124, 99);
            chkRecomendado.CheckedState.BorderRadius = 0;
            chkRecomendado.CheckedState.BorderThickness = 0;
            chkRecomendado.CheckedState.FillColor = Color.FromArgb(198, 124, 99);
            chkRecomendado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkRecomendado.ForeColor = Color.FromArgb(75, 55, 48);
            chkRecomendado.Location = new Point(370, 23);
            chkRecomendado.Name = "chkRecomendado";
            chkRecomendado.Size = new Size(195, 19);
            chkRecomendado.TabIndex = 1;
            chkRecomendado.Text = "👍 Marcar como recomendado";
            chkRecomendado.UncheckedState.BorderRadius = 0;
            chkRecomendado.UncheckedState.BorderThickness = 0;
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 8;
            btnSalvar.CustomizableEdges = customizableEdges25;
            btnSalvar.FillColor = Color.FromArgb(198, 124, 99);
            btnSalvar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(28, 615);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnSalvar.Size = new Size(350, 48);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "✓  Salvar Doce";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderColor = Color.FromArgb(215, 200, 192);
            btnCancelar.BorderRadius = 8;
            btnCancelar.BorderThickness = 1;
            btnCancelar.CustomizableEdges = customizableEdges27;
            btnCancelar.FillColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(100, 75, 65);
            btnCancelar.Location = new Point(420, 615);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnCancelar.Size = new Size(350, 48);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "←  Voltar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // openFileDialogImagem
            // 
            openFileDialogImagem.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.webp;*.bmp";
            openFileDialogImagem.Title = "Selecionar imagem do doce";
            // 
            // DoceFormDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 245, 242);
            ClientSize = new Size(820, 720);
            Controls.Add(pnlPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DoceFormDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "7";
            Load += new System.EventHandler(DoceFormDialog_Load);
            pnlPrincipal.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).EndInit();
            pnlImagem.ResumeLayout(false);
            pnlImagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturePreview).EndInit();
            pnlOpcoes.ResumeLayout(false);
            pnlOpcoes.PerformLayout();
            ResumeLayout(false);
        }
    }
}