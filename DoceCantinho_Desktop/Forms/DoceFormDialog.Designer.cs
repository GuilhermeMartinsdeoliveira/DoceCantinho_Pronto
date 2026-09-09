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
            this.components = new System.ComponentModel.Container();

            this.guna2BorderlessForm1 =
                new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);

            this.guna2ShadowForm1 =
                new Guna.UI2.WinForms.Guna2ShadowForm();

            this.pnlPrincipal =
                new Guna.UI2.WinForms.Guna2Panel();

            this.pnlCabecalho =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblTitulo =
                new System.Windows.Forms.Label();

            this.lblSubtitulo =
                new System.Windows.Forms.Label();

            this.pnlConteudo =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblNome =
                new System.Windows.Forms.Label();

            this.txtTitulo =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.lblDescricao =
                new System.Windows.Forms.Label();

            this.txtDescricao =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.lblPreco =
                new System.Windows.Forms.Label();

            this.nudPreco =
                new Guna.UI2.WinForms.Guna2NumericUpDown();

            this.lblEstoque =
                new System.Windows.Forms.Label();

            this.nudEstoque =
                new Guna.UI2.WinForms.Guna2NumericUpDown();

            this.lblCategoria =
                new System.Windows.Forms.Label();

            this.cmbCategoria =
                new Guna.UI2.WinForms.Guna2ComboBox();

            this.pnlImagem =
                new Guna.UI2.WinForms.Guna2Panel();

            this.lblImagemTitulo =
                new System.Windows.Forms.Label();

            this.lblImagemUrl =
                new System.Windows.Forms.Label();

            this.txtUrl =
                new Guna.UI2.WinForms.Guna2TextBox();

            this.lblImagemArquivo =
                new System.Windows.Forms.Label();

            this.btnSelecionarImagem =
                new Guna.UI2.WinForms.Guna2Button();

            this.lblArquivoSelecionado =
                new System.Windows.Forms.Label();

            this.btnLimparImagem =
                new Guna.UI2.WinForms.Guna2Button();

            this.lblPreview =
                new System.Windows.Forms.Label();

            this.picturePreview =
                new System.Windows.Forms.PictureBox();

            this.pnlOpcoes =
                new Guna.UI2.WinForms.Guna2Panel();

            this.chkDestaque =
                new Guna.UI2.WinForms.Guna2CheckBox();

            this.chkRecomendado =
                new Guna.UI2.WinForms.Guna2CheckBox();

            this.btnSalvar =
                new Guna.UI2.WinForms.Guna2Button();

            this.btnCancelar =
                new Guna.UI2.WinForms.Guna2Button();

            this.openFileDialogImagem =
                new System.Windows.Forms.OpenFileDialog();

            // ============================================================
            // FORM
            // ============================================================

            this.SuspendLayout();

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(248, 245, 242);

            this.ClientSize =
                new System.Drawing.Size(820, 720);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Novo Doce";

            this.ShowInTaskbar =
                false;

            this.guna2BorderlessForm1.BorderRadius = 14;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;

            // ============================================================
            // PAINEL PRINCIPAL
            // ============================================================

            this.pnlPrincipal.BorderRadius = 14;
            this.pnlPrincipal.Controls.Add(this.pnlCabecalho);
            this.pnlPrincipal.Controls.Add(this.pnlConteudo);
            this.pnlPrincipal.Controls.Add(this.pnlImagem);
            this.pnlPrincipal.Controls.Add(this.pnlOpcoes);
            this.pnlPrincipal.Controls.Add(this.btnSalvar);
            this.pnlPrincipal.Controls.Add(this.btnCancelar);

            this.pnlPrincipal.FillColor =
                System.Drawing.Color.White;

            this.pnlPrincipal.Location =
                new System.Drawing.Point(10, 10);

            this.pnlPrincipal.Name =
                "pnlPrincipal";

            this.pnlPrincipal.Size =
                new System.Drawing.Size(800, 700);

            // ============================================================
            // CABEÇALHO
            // ============================================================

            this.pnlCabecalho.BackColor =
                System.Drawing.Color.Transparent;

            this.pnlCabecalho.Controls.Add(this.lblTitulo);
            this.pnlCabecalho.Controls.Add(this.lblSubtitulo);

            this.pnlCabecalho.FillColor =
                System.Drawing.Color.FromArgb(250, 247, 244);

            this.pnlCabecalho.Location =
                new System.Drawing.Point(0, 0);

            this.pnlCabecalho.Name =
                "pnlCabecalho";

            this.pnlCabecalho.Size =
                new System.Drawing.Size(800, 82);

            // ============================================================
            // TÍTULO
            // ============================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Georgia",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(58, 40, 34);

            this.lblTitulo.Location =
                new System.Drawing.Point(28, 17);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Text =
                "➕ Novo Doce";

            // ============================================================
            // SUBTÍTULO
            // ============================================================

            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(145, 117, 105);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(31, 51);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Text =
                "Cadastre um novo produto no DoceCantinho";

            // ============================================================
            // CONTEÚDO - ESQUERDA
            // ============================================================

            this.pnlConteudo.BackColor =
                System.Drawing.Color.Transparent;

            this.pnlConteudo.Controls.Add(this.lblNome);
            this.pnlConteudo.Controls.Add(this.txtTitulo);
            this.pnlConteudo.Controls.Add(this.lblDescricao);
            this.pnlConteudo.Controls.Add(this.txtDescricao);
            this.pnlConteudo.Controls.Add(this.lblPreco);
            this.pnlConteudo.Controls.Add(this.nudPreco);
            this.pnlConteudo.Controls.Add(this.lblEstoque);
            this.pnlConteudo.Controls.Add(this.nudEstoque);
            this.pnlConteudo.Controls.Add(this.lblCategoria);
            this.pnlConteudo.Controls.Add(this.cmbCategoria);

            this.pnlConteudo.FillColor =
                System.Drawing.Color.Transparent;

            this.pnlConteudo.Location =
                new System.Drawing.Point(28, 98);

            this.pnlConteudo.Name =
                "pnlConteudo";

            this.pnlConteudo.Size =
                new System.Drawing.Size(360, 405);

            // ============================================================
            // NOME
            // ============================================================

            this.lblNome.AutoSize = true;

            this.lblNome.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblNome.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblNome.Location =
                new System.Drawing.Point(2, 0);

            this.lblNome.Text =
                "Nome do doce";

            // ============================================================
            // TÍTULO
            // ============================================================

            this.txtTitulo.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.txtTitulo.BorderRadius = 8;
            this.txtTitulo.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.txtTitulo.DefaultText =
                "";

            this.txtTitulo.FillColor =
                System.Drawing.Color.WhiteSmoke;

            this.txtTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.txtTitulo.ForeColor =
                System.Drawing.Color.FromArgb(60, 45, 40);

            this.txtTitulo.Location =
                new System.Drawing.Point(0, 22);

            this.txtTitulo.Name =
                "txtTitulo";

            this.txtTitulo.PlaceholderText =
                "Ex.: Brigadeiro Gourmet";

            this.txtTitulo.SelectedText =
                "";

            this.txtTitulo.Size =
                new System.Drawing.Size(350, 42);

            // ============================================================
            // DESCRIÇÃO
            // ============================================================

            this.lblDescricao.AutoSize = true;

            this.lblDescricao.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblDescricao.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblDescricao.Location =
                new System.Drawing.Point(2, 78);

            this.lblDescricao.Text =
                "Descrição";

            this.txtDescricao.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.txtDescricao.BorderRadius = 8;

            this.txtDescricao.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.txtDescricao.DefaultText =
                "";

            this.txtDescricao.FillColor =
                System.Drawing.Color.WhiteSmoke;

            this.txtDescricao.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.txtDescricao.Location =
                new System.Drawing.Point(0, 100);

            this.txtDescricao.Multiline = true;

            this.txtDescricao.Name =
                "txtDescricao";

            this.txtDescricao.PlaceholderText =
                "Conte um pouco sobre esse doce...";

            this.txtDescricao.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescricao.SelectedText =
                "";

            this.txtDescricao.Size =
                new System.Drawing.Size(350, 100);

            // ============================================================
            // PREÇO
            // ============================================================

            this.lblPreco.AutoSize = true;

            this.lblPreco.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblPreco.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblPreco.Location =
                new System.Drawing.Point(2, 215);

            this.lblPreco.Text =
                "Preço";

            this.nudPreco.BackColor =
                System.Drawing.Color.Transparent;

            this.nudPreco.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.nudPreco.BorderRadius = 8;

            this.nudPreco.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.nudPreco.DecimalPlaces = 2;

            this.nudPreco.FillColor =
                System.Drawing.Color.WhiteSmoke;

            this.nudPreco.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.nudPreco.Location =
                new System.Drawing.Point(0, 237);

            this.nudPreco.Maximum =
                999999M;

            this.nudPreco.Minimum =
                0M;

            this.nudPreco.Name =
                "nudPreco";

            this.nudPreco.Size =
                new System.Drawing.Size(350, 42);

            this.nudPreco.ThousandsSeparator = true;

            // ============================================================
            // ESTOQUE
            // ============================================================

            this.lblEstoque.AutoSize = true;

            this.lblEstoque.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblEstoque.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblEstoque.Location =
                new System.Drawing.Point(2, 292);

            this.lblEstoque.Text =
                "Estoque";

            this.nudEstoque.BackColor =
                System.Drawing.Color.Transparent;

            this.nudEstoque.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.nudEstoque.BorderRadius = 8;

            this.nudEstoque.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.nudEstoque.DecimalPlaces = 0;

            this.nudEstoque.FillColor =
                System.Drawing.Color.WhiteSmoke;

            this.nudEstoque.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.nudEstoque.Location =
                new System.Drawing.Point(0, 314);

            this.nudEstoque.Maximum =
                999999M;

            this.nudEstoque.Minimum =
                0M;

            this.nudEstoque.Name =
                "nudEstoque";

            this.nudEstoque.Size =
                new System.Drawing.Size(350, 42);

            // ============================================================
            // CATEGORIA
            // ============================================================

            this.lblCategoria.AutoSize = true;

            this.lblCategoria.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblCategoria.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblCategoria.Location =
                new System.Drawing.Point(2, 369);

            this.lblCategoria.Text =
                "Categoria";

            this.cmbCategoria.BackColor =
                System.Drawing.Color.Transparent;

            this.cmbCategoria.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.cmbCategoria.BorderRadius = 8;

            this.cmbCategoria.DrawMode =
                System.Windows.Forms.DrawMode.OwnerDrawFixed;

            this.cmbCategoria.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCategoria.FillColor =
                System.Drawing.Color.WhiteSmoke;

            this.cmbCategoria.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F);

            this.cmbCategoria.ForeColor =
                System.Drawing.Color.FromArgb(60, 45, 40);

            this.cmbCategoria.ItemHeight = 30;

            this.cmbCategoria.Location =
                new System.Drawing.Point(0, 391);

            this.cmbCategoria.Name =
                "cmbCategoria";

            this.cmbCategoria.Size =
                new System.Drawing.Size(350, 36);

            // ============================================================
            // PAINEL DE IMAGEM
            // ============================================================

            this.pnlImagem.BackColor =
                System.Drawing.Color.Transparent;

            this.pnlImagem.BorderColor =
                System.Drawing.Color.FromArgb(235, 226, 221);

            this.pnlImagem.BorderRadius = 10;
            this.pnlImagem.BorderThickness = 1;

            this.pnlImagem.Controls.Add(this.lblImagemTitulo);
            this.pnlImagem.Controls.Add(this.lblImagemUrl);
            this.pnlImagem.Controls.Add(this.txtUrl);
            this.pnlImagem.Controls.Add(this.lblImagemArquivo);
            this.pnlImagem.Controls.Add(this.btnSelecionarImagem);
            this.pnlImagem.Controls.Add(this.lblArquivoSelecionado);
            this.pnlImagem.Controls.Add(this.btnLimparImagem);
            this.pnlImagem.Controls.Add(this.lblPreview);
            this.pnlImagem.Controls.Add(this.picturePreview);

            this.pnlImagem.FillColor =
                System.Drawing.Color.FromArgb(250, 247, 244);

            this.pnlImagem.Location =
                new System.Drawing.Point(410, 98);

            this.pnlImagem.Name =
                "pnlImagem";

            this.pnlImagem.Size =
                new System.Drawing.Size(360, 405);

            // ============================================================
            // TÍTULO IMAGEM
            // ============================================================

            this.lblImagemTitulo.AutoSize = true;

            this.lblImagemTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.lblImagemTitulo.ForeColor =
                System.Drawing.Color.FromArgb(72, 52, 45);

            this.lblImagemTitulo.Location =
                new System.Drawing.Point(18, 16);

            this.lblImagemTitulo.Text =
                "Imagem do produto";

            // ============================================================
            // URL
            // ============================================================

            this.lblImagemUrl.AutoSize = true;

            this.lblImagemUrl.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblImagemUrl.ForeColor =
                System.Drawing.Color.FromArgb(95, 73, 65);

            this.lblImagemUrl.Location =
                new System.Drawing.Point(18, 51);

            this.lblImagemUrl.Text =
                "Imagem (URL)";

            this.txtUrl.BorderColor =
                System.Drawing.Color.FromArgb(220, 208, 201);

            this.txtUrl.BorderRadius = 8;

            this.txtUrl.Cursor =
                System.Windows.Forms.Cursors.IBeam;

            this.txtUrl.DefaultText =
                "";

            this.txtUrl.FillColor =
                System.Drawing.Color.White;

            this.txtUrl.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.txtUrl.ForeColor =
                System.Drawing.Color.FromArgb(60, 45, 40);

            this.txtUrl.Location =
                new System.Drawing.Point(18, 74);

            this.txtUrl.Name =
                "txtUrl";

            this.txtUrl.PlaceholderText =
                "https://exemplo.com/imagem.jpg";

            this.txtUrl.SelectedText =
                "";

            this.txtUrl.Size =
                new System.Drawing.Size(324, 40);

            // ============================================================
            // ARQUIVO
            // ============================================================

            this.lblImagemArquivo.AutoSize = true;

            this.lblImagemArquivo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblImagemArquivo.ForeColor =
                System.Drawing.Color.FromArgb(95, 73, 65);

            this.lblImagemArquivo.Location =
                new System.Drawing.Point(18, 127);

            this.lblImagemArquivo.Text =
                "Imagem (arquivo local)";

            // ============================================================
            // BOTÃO ESCOLHER ARQUIVO
            // ============================================================

            this.btnSelecionarImagem.BorderRadius = 7;

            this.btnSelecionarImagem.FillColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.btnSelecionarImagem.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnSelecionarImagem.ForeColor =
                System.Drawing.Color.White;

            this.btnSelecionarImagem.Location =
                new System.Drawing.Point(18, 151);

            this.btnSelecionarImagem.Name =
                "btnSelecionarImagem";

            this.btnSelecionarImagem.Size =
                new System.Drawing.Size(145, 38);

            this.btnSelecionarImagem.Text =
                "📁 Escolher arquivo";

            // ============================================================
            // ARQUIVO SELECIONADO
            // ============================================================

            this.lblArquivoSelecionado.AutoEllipsis = true;

            this.lblArquivoSelecionado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F);

            this.lblArquivoSelecionado.ForeColor =
                System.Drawing.Color.FromArgb(125, 105, 95);

            this.lblArquivoSelecionado.Location =
                new System.Drawing.Point(18, 195);

            this.lblArquivoSelecionado.Name =
                "lblArquivoSelecionado";

            this.lblArquivoSelecionado.Size =
                new System.Drawing.Size(260, 35);

            this.lblArquivoSelecionado.Text =
                "Nenhum arquivo selecionado";

            // ============================================================
            // LIMPAR IMAGEM
            // ============================================================

            this.btnLimparImagem.BorderRadius = 7;

            this.btnLimparImagem.FillColor =
                System.Drawing.Color.FromArgb(230, 223, 219);

            this.btnLimparImagem.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8.5F);

            this.btnLimparImagem.ForeColor =
                System.Drawing.Color.FromArgb(90, 70, 62);

            this.btnLimparImagem.Location =
                new System.Drawing.Point(238, 151);

            this.btnLimparImagem.Name =
                "btnLimparImagem";

            this.btnLimparImagem.Size =
                new System.Drawing.Size(104, 38);

            this.btnLimparImagem.Text =
                "Limpar";

            // ============================================================
            // PREVIEW
            // ============================================================

            this.lblPreview.AutoSize = true;

            this.lblPreview.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblPreview.ForeColor =
                System.Drawing.Color.FromArgb(95, 73, 65);

            this.lblPreview.Location =
                new System.Drawing.Point(18, 237);

            this.lblPreview.Text =
                "Pré-visualização";

            this.picturePreview.BackColor =
                System.Drawing.Color.FromArgb(239, 233, 229);

            this.picturePreview.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.picturePreview.Location =
                new System.Drawing.Point(18, 263);

            this.picturePreview.Name =
                "picturePreview";

            this.picturePreview.Size =
                new System.Drawing.Size(145, 120);

            this.picturePreview.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // ============================================================
            // OPÇÕES
            // ============================================================

            this.pnlOpcoes.BackColor =
                System.Drawing.Color.Transparent;

            this.pnlOpcoes.BorderRadius = 9;

            this.pnlOpcoes.Controls.Add(this.chkDestaque);
            this.pnlOpcoes.Controls.Add(this.chkRecomendado);

            this.pnlOpcoes.FillColor =
                System.Drawing.Color.FromArgb(250, 247, 244);

            this.pnlOpcoes.Location =
                new System.Drawing.Point(28, 520);

            this.pnlOpcoes.Name =
                "pnlOpcoes";

            this.pnlOpcoes.Size =
                new System.Drawing.Size(742, 70);

            // ============================================================
            // DESTAQUE
            // ============================================================

            this.chkDestaque.AutoSize = true;

            this.chkDestaque.CheckedState.BorderColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.chkDestaque.CheckedState.FillColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.chkDestaque.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.chkDestaque.ForeColor =
                System.Drawing.Color.FromArgb(75, 55, 48);

            this.chkDestaque.Location =
                new System.Drawing.Point(20, 23);

            this.chkDestaque.Name =
                "chkDestaque";

            this.chkDestaque.Text =
                "⭐ Destacar este doce na loja";

            // ============================================================
            // RECOMENDADO
            // ============================================================

            this.chkRecomendado.AutoSize = true;

            this.chkRecomendado.CheckedState.BorderColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.chkRecomendado.CheckedState.FillColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.chkRecomendado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.chkRecomendado.ForeColor =
                System.Drawing.Color.FromArgb(75, 55, 48);

            this.chkRecomendado.Location =
                new System.Drawing.Point(370, 23);

            this.chkRecomendado.Name =
                "chkRecomendado";

            this.chkRecomendado.Text =
                "👍 Marcar como recomendado";

            // ============================================================
            // BOTÃO SALVAR
            // ============================================================

            this.btnSalvar.BorderRadius = 8;

            this.btnSalvar.FillColor =
                System.Drawing.Color.FromArgb(198, 124, 99);

            this.btnSalvar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnSalvar.ForeColor =
                System.Drawing.Color.White;

            this.btnSalvar.Location =
                new System.Drawing.Point(28, 615);

            this.btnSalvar.Name =
                "btnSalvar";

            this.btnSalvar.Size =
                new System.Drawing.Size(350, 48);

            this.btnSalvar.Text =
                "✓  Salvar Doce";

            this.btnSalvar.Click +=
                new System.EventHandler(
                    this.btnSalvar_Click);

            // ============================================================
            // BOTÃO CANCELAR
            // ============================================================

            this.btnCancelar.BorderColor =
                System.Drawing.Color.FromArgb(215, 200, 192);

            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.BorderThickness = 1;

            this.btnCancelar.FillColor =
                System.Drawing.Color.White;

            this.btnCancelar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9.5F,
                    System.Drawing.FontStyle.Bold);

            this.btnCancelar.ForeColor =
                System.Drawing.Color.FromArgb(100, 75, 65);

            this.btnCancelar.Location =
                new System.Drawing.Point(420, 615);

            this.btnCancelar.Name =
                "btnCancelar";

            this.btnCancelar.Size =
                new System.Drawing.Size(350, 48);

            this.btnCancelar.Text =
                "←  Voltar";

            this.btnCancelar.Click +=
                new System.EventHandler(
                    this.btnCancelar_Click);

            // ============================================================
            // OPEN FILE DIALOG
            // ============================================================

            this.openFileDialogImagem.Filter =
                "Imagens|*.jpg;*.jpeg;*.png;*.webp;*.bmp";

            this.openFileDialogImagem.Title =
                "Selecionar imagem do doce";

            this.openFileDialogImagem.Multiselect =
                false;

            // ============================================================
            // ADICIONAR AO FORM
            // ============================================================

            this.pnlPrincipal.Controls.Add(
                this.pnlCabecalho);

            this.pnlPrincipal.Controls.Add(
                this.pnlConteudo);

            this.pnlPrincipal.Controls.Add(
                this.pnlImagem);

            this.pnlPrincipal.Controls.Add(
                this.pnlOpcoes);

            this.pnlPrincipal.Controls.Add(
                this.btnSalvar);

            this.pnlPrincipal.Controls.Add(
                this.btnCancelar);

            this.Controls.Add(
                this.pnlPrincipal);

            this.Name =
                "DoceFormDialog";

            this.ResumeLayout(false);
        }
    }
}