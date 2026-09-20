using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    partial class BlogFormDialog
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlPrincipal;
        private Panel pnlCabecalho;
        private Panel pnlSeparador1;
        private Panel pnlSeparador2;

        private Guna.UI2.WinForms.Guna2Button btnFechar;

        private Label lblTituloJanela;
        private Label lblSubtitulo;

        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;

        private Label lblCategoria;
        private Guna.UI2.WinForms.Guna2TextBox txtCategoria;

        private Label lblCapa;
        private Guna.UI2.WinForms.Guna2TextBox txtCapa;

        private Label lblResumo;
        private Guna.UI2.WinForms.Guna2TextBox txtResumo;

        private Label lblConteudo;
        private TextBox txtConteudo;

        private Label lblAjudaConteudo;

        private Label lblTags;
        private Guna.UI2.WinForms.Guna2TextBox txtTags;

        private Label lblAutor;
        private Guna.UI2.WinForms.Guna2TextBox txtAutor;

        private Label lblCargoAutor;
        private Guna.UI2.WinForms.Guna2TextBox txtCargoAutor;

        private Label lblAvatarAutor;
        private Guna.UI2.WinForms.Guna2TextBox txtAvatarAutor;

        private Label lblBioAutor;
        private Guna.UI2.WinForms.Guna2TextBox txtBioAutor;

        private Label lblPublicacao;
        private DateTimePicker dtPublicacao;

        private CheckBox chkPublicado;
        private CheckBox chkDestaque;

        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private Guna.UI2.WinForms.Guna2Button btnSalvar;


        protected override void Dispose(
            bool disposing)
        {
            if (
                disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlPrincipal = new Panel();
            pnlCabecalho = new Panel();
            pnlSeparador1 = new Panel();
            pnlSeparador2 = new Panel();
            lblTituloJanela = new Label();
            lblSubtitulo = new Label();
            btnFechar = new Guna.UI2.WinForms.Guna2Button();
            lblTitulo = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            lblCategoria = new Label();
            txtCategoria = new Guna.UI2.WinForms.Guna2TextBox();
            lblCapa = new Label();
            txtCapa = new Guna.UI2.WinForms.Guna2TextBox();
            lblTags = new Label();
            txtTags = new Guna.UI2.WinForms.Guna2TextBox();
            lblResumo = new Label();
            txtResumo = new Guna.UI2.WinForms.Guna2TextBox();
            lblConteudo = new Label();
            txtConteudo = new TextBox();
            lblAjudaConteudo = new Label();
            lblAutor = new Label();
            txtAutor = new Guna.UI2.WinForms.Guna2TextBox();
            lblCargoAutor = new Label();
            txtCargoAutor = new Guna.UI2.WinForms.Guna2TextBox();
            lblAvatarAutor = new Label();
            txtAvatarAutor = new Guna.UI2.WinForms.Guna2TextBox();
            lblBioAutor = new Label();
            txtBioAutor = new Guna.UI2.WinForms.Guna2TextBox();
            lblPublicacao = new Label();
            dtPublicacao = new DateTimePicker();
            chkPublicado = new CheckBox();
            chkDestaque = new CheckBox();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.AutoScroll = true;
            pnlPrincipal.BackColor = Color.FromArgb(253, 246, 237);
            pnlPrincipal.Controls.Add(pnlCabecalho);
            pnlPrincipal.Controls.Add(pnlSeparador1);
            pnlPrincipal.Controls.Add(pnlSeparador2);
            pnlPrincipal.Controls.Add(btnSalvar);
            pnlPrincipal.Controls.Add(btnCancelar);
            pnlPrincipal.Controls.Add(chkDestaque);
            pnlPrincipal.Controls.Add(chkPublicado);
            pnlPrincipal.Controls.Add(dtPublicacao);
            pnlPrincipal.Controls.Add(lblPublicacao);
            pnlPrincipal.Controls.Add(txtBioAutor);
            pnlPrincipal.Controls.Add(lblBioAutor);
            pnlPrincipal.Controls.Add(txtAvatarAutor);
            pnlPrincipal.Controls.Add(lblAvatarAutor);
            pnlPrincipal.Controls.Add(txtCargoAutor);
            pnlPrincipal.Controls.Add(lblCargoAutor);
            pnlPrincipal.Controls.Add(txtAutor);
            pnlPrincipal.Controls.Add(lblAutor);
            pnlPrincipal.Controls.Add(lblAjudaConteudo);
            pnlPrincipal.Controls.Add(txtConteudo);
            pnlPrincipal.Controls.Add(lblConteudo);
            pnlPrincipal.Controls.Add(txtResumo);
            pnlPrincipal.Controls.Add(lblResumo);
            pnlPrincipal.Controls.Add(txtTags);
            pnlPrincipal.Controls.Add(lblTags);
            pnlPrincipal.Controls.Add(txtCapa);
            pnlPrincipal.Controls.Add(lblCapa);
            pnlPrincipal.Controls.Add(txtCategoria);
            pnlPrincipal.Controls.Add(lblCategoria);
            pnlPrincipal.Controls.Add(txtTitulo);
            pnlPrincipal.Controls.Add(lblTitulo);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Padding = new Padding(28);
            pnlPrincipal.Size = new Size(1090, 880);
            pnlPrincipal.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(90, 70, 60);
            lblTitulo.Location = new Point(28, 104);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(0, 20);
            lblTitulo.Text = "Título *";
            // 
            // txtTitulo
            // 
            txtTitulo.BorderColor = Color.FromArgb(224, 214, 209);
            txtTitulo.BorderRadius = 9;
            txtTitulo.BorderThickness = 1;
            txtTitulo.CustomizableEdges = customizableEdges1;
            txtTitulo.DefaultText = "";
            txtTitulo.FillColor = Color.White;
            txtTitulo.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTitulo.Font = new Font("Segoe UI", 9.5F);
            txtTitulo.ForeColor = Color.FromArgb(65, 50, 43);
            txtTitulo.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTitulo.Location = new Point(28, 126);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.MaxLength = 200;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex.: Como conservar bolos de aniversário";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTitulo.Size = new Size(505, 44);
            txtTitulo.TabIndex = 0;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(90, 70, 60);
            lblCategoria.Location = new Point(557, 104);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(0, 20);
            lblCategoria.Text = "Categoria *";
            // 
            // txtCategoria
            // 
            txtCategoria.BorderColor = Color.FromArgb(224, 214, 209);
            txtCategoria.BorderRadius = 9;
            txtCategoria.BorderThickness = 1;
            txtCategoria.CustomizableEdges = customizableEdges3;
            txtCategoria.DefaultText = "";
            txtCategoria.FillColor = Color.White;
            txtCategoria.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCategoria.Font = new Font("Segoe UI", 9.5F);
            txtCategoria.ForeColor = Color.FromArgb(65, 50, 43);
            txtCategoria.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCategoria.Location = new Point(557, 126);
            txtCategoria.Margin = new Padding(3, 4, 3, 4);
            txtCategoria.MaxLength = 100;
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PlaceholderText = "Ex.: Dicas, Receitas, Novidades";
            txtCategoria.SelectedText = "";
            txtCategoria.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtCategoria.Size = new Size(505, 44);
            txtCategoria.TabIndex = 1;
            // 
            // lblCapa
            // 
            lblCapa.AutoSize = true;
            lblCapa.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCapa.ForeColor = Color.FromArgb(90, 70, 60);
            lblCapa.Location = new Point(28, 186);
            lblCapa.Name = "lblCapa";
            lblCapa.Size = new Size(0, 20);
            lblCapa.Text = "Imagem de capa (URL)";
            // 
            // txtCapa
            // 
            txtCapa.BorderColor = Color.FromArgb(224, 214, 209);
            txtCapa.BorderRadius = 9;
            txtCapa.BorderThickness = 1;
            txtCapa.CustomizableEdges = customizableEdges5;
            txtCapa.DefaultText = "";
            txtCapa.FillColor = Color.White;
            txtCapa.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCapa.Font = new Font("Segoe UI", 9.5F);
            txtCapa.ForeColor = Color.FromArgb(65, 50, 43);
            txtCapa.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCapa.Location = new Point(28, 208);
            txtCapa.Margin = new Padding(3, 4, 3, 4);
            txtCapa.MaxLength = 500;
            txtCapa.Name = "txtCapa";
            txtCapa.PlaceholderText = "https://...";
            txtCapa.SelectedText = "";
            txtCapa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtCapa.Size = new Size(505, 44);
            txtCapa.TabIndex = 2;
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblTags.ForeColor = Color.FromArgb(90, 70, 60);
            lblTags.Location = new Point(557, 186);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(0, 20);
            lblTags.Text = "Tags (separadas por vírgula)";
            // 
            // txtTags
            // 
            txtTags.BorderColor = Color.FromArgb(224, 214, 209);
            txtTags.BorderRadius = 9;
            txtTags.BorderThickness = 1;
            txtTags.CustomizableEdges = customizableEdges7;
            txtTags.DefaultText = "";
            txtTags.FillColor = Color.White;
            txtTags.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTags.Font = new Font("Segoe UI", 9.5F);
            txtTags.ForeColor = Color.FromArgb(65, 50, 43);
            txtTags.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTags.Location = new Point(557, 208);
            txtTags.Margin = new Padding(3, 4, 3, 4);
            txtTags.MaxLength = 500;
            txtTags.Name = "txtTags";
            txtTags.PlaceholderText = "bolo, dicas, confeitaria";
            txtTags.SelectedText = "";
            txtTags.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtTags.Size = new Size(505, 44);
            txtTags.TabIndex = 3;
            // 
            // lblResumo
            // 
            lblResumo.AutoSize = true;
            lblResumo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblResumo.ForeColor = Color.FromArgb(90, 70, 60);
            lblResumo.Location = new Point(28, 268);
            lblResumo.Name = "lblResumo";
            lblResumo.Size = new Size(0, 20);
            lblResumo.Text = "Resumo * (até 500 caracteres)";
            // 
            // txtResumo
            // 
            txtResumo.BorderColor = Color.FromArgb(224, 214, 209);
            txtResumo.BorderRadius = 9;
            txtResumo.BorderThickness = 1;
            txtResumo.CustomizableEdges = customizableEdges9;
            txtResumo.DefaultText = "";
            txtResumo.FillColor = Color.White;
            txtResumo.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtResumo.Font = new Font("Segoe UI", 9.5F);
            txtResumo.ForeColor = Color.FromArgb(65, 50, 43);
            txtResumo.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtResumo.Location = new Point(28, 290);
            txtResumo.Margin = new Padding(3, 4, 3, 4);
            txtResumo.MaxLength = 500;
            txtResumo.Multiline = true;
            txtResumo.Name = "txtResumo";
            txtResumo.PlaceholderText = "Escreva um resumo curto que aparece na listagem do blog...";
            txtResumo.SelectedText = "";
            txtResumo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtResumo.Size = new Size(1034, 72);
            txtResumo.TabIndex = 4;
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAutor.ForeColor = Color.FromArgb(90, 70, 60);
            lblAutor.Location = new Point(28, 624);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(0, 20);
            lblAutor.Text = "Autor *";
            // 
            // txtAutor
            // 
            txtAutor.BorderColor = Color.FromArgb(224, 214, 209);
            txtAutor.BorderRadius = 9;
            txtAutor.BorderThickness = 1;
            txtAutor.CustomizableEdges = customizableEdges11;
            txtAutor.DefaultText = "";
            txtAutor.FillColor = Color.White;
            txtAutor.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtAutor.Font = new Font("Segoe UI", 9.5F);
            txtAutor.ForeColor = Color.FromArgb(65, 50, 43);
            txtAutor.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtAutor.Location = new Point(28, 646);
            txtAutor.Margin = new Padding(3, 4, 3, 4);
            txtAutor.MaxLength = 150;
            txtAutor.Name = "txtAutor";
            txtAutor.PlaceholderText = "Nome do autor";
            txtAutor.SelectedText = "";
            txtAutor.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtAutor.Size = new Size(505, 44);
            txtAutor.TabIndex = 6;
            // 
            // lblCargoAutor
            // 
            lblCargoAutor.AutoSize = true;
            lblCargoAutor.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblCargoAutor.ForeColor = Color.FromArgb(90, 70, 60);
            lblCargoAutor.Location = new Point(557, 624);
            lblCargoAutor.Name = "lblCargoAutor";
            lblCargoAutor.Size = new Size(0, 20);
            lblCargoAutor.Text = "Cargo do autor";
            // 
            // txtCargoAutor
            // 
            txtCargoAutor.BorderColor = Color.FromArgb(224, 214, 209);
            txtCargoAutor.BorderRadius = 9;
            txtCargoAutor.BorderThickness = 1;
            txtCargoAutor.CustomizableEdges = customizableEdges13;
            txtCargoAutor.DefaultText = "";
            txtCargoAutor.FillColor = Color.White;
            txtCargoAutor.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCargoAutor.Font = new Font("Segoe UI", 9.5F);
            txtCargoAutor.ForeColor = Color.FromArgb(65, 50, 43);
            txtCargoAutor.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtCargoAutor.Location = new Point(557, 646);
            txtCargoAutor.Margin = new Padding(3, 4, 3, 4);
            txtCargoAutor.MaxLength = 150;
            txtCargoAutor.Name = "txtCargoAutor";
            txtCargoAutor.PlaceholderText = "Ex.: Confeiteira chefe";
            txtCargoAutor.SelectedText = "";
            txtCargoAutor.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtCargoAutor.Size = new Size(505, 44);
            txtCargoAutor.TabIndex = 7;
            // 
            // lblAvatarAutor
            // 
            lblAvatarAutor.AutoSize = true;
            lblAvatarAutor.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblAvatarAutor.ForeColor = Color.FromArgb(90, 70, 60);
            lblAvatarAutor.Location = new Point(28, 706);
            lblAvatarAutor.Name = "lblAvatarAutor";
            lblAvatarAutor.Size = new Size(0, 20);
            lblAvatarAutor.Text = "Foto do autor (URL)";
            // 
            // txtAvatarAutor
            // 
            txtAvatarAutor.BorderColor = Color.FromArgb(224, 214, 209);
            txtAvatarAutor.BorderRadius = 9;
            txtAvatarAutor.BorderThickness = 1;
            txtAvatarAutor.CustomizableEdges = customizableEdges15;
            txtAvatarAutor.DefaultText = "";
            txtAvatarAutor.FillColor = Color.White;
            txtAvatarAutor.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtAvatarAutor.Font = new Font("Segoe UI", 9.5F);
            txtAvatarAutor.ForeColor = Color.FromArgb(65, 50, 43);
            txtAvatarAutor.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtAvatarAutor.Location = new Point(28, 728);
            txtAvatarAutor.Margin = new Padding(3, 4, 3, 4);
            txtAvatarAutor.MaxLength = 500;
            txtAvatarAutor.Name = "txtAvatarAutor";
            txtAvatarAutor.PlaceholderText = "https://... (opcional)";
            txtAvatarAutor.SelectedText = "";
            txtAvatarAutor.ShadowDecoration.CustomizableEdges = customizableEdges16;
            txtAvatarAutor.Size = new Size(505, 44);
            txtAvatarAutor.TabIndex = 8;
            // 
            // lblBioAutor
            // 
            lblBioAutor.AutoSize = true;
            lblBioAutor.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblBioAutor.ForeColor = Color.FromArgb(90, 70, 60);
            lblBioAutor.Location = new Point(557, 706);
            lblBioAutor.Name = "lblBioAutor";
            lblBioAutor.Size = new Size(0, 20);
            lblBioAutor.Text = "Mini bio do autor";
            // 
            // txtBioAutor
            // 
            txtBioAutor.BorderColor = Color.FromArgb(224, 214, 209);
            txtBioAutor.BorderRadius = 9;
            txtBioAutor.BorderThickness = 1;
            txtBioAutor.CustomizableEdges = customizableEdges17;
            txtBioAutor.DefaultText = "";
            txtBioAutor.FillColor = Color.White;
            txtBioAutor.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtBioAutor.Font = new Font("Segoe UI", 9.5F);
            txtBioAutor.ForeColor = Color.FromArgb(65, 50, 43);
            txtBioAutor.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtBioAutor.Location = new Point(557, 728);
            txtBioAutor.Margin = new Padding(3, 4, 3, 4);
            txtBioAutor.MaxLength = 1000;
            txtBioAutor.Name = "txtBioAutor";
            txtBioAutor.PlaceholderText = "Uma frase sobre o autor (opcional)";
            txtBioAutor.SelectedText = "";
            txtBioAutor.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtBioAutor.Size = new Size(505, 44);
            txtBioAutor.TabIndex = 9;
            // 
            // lblConteudo
            // 
            lblConteudo.AutoSize = true;
            lblConteudo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblConteudo.ForeColor = Color.FromArgb(90, 70, 60);
            lblConteudo.Location = new Point(28, 378);
            lblConteudo.Name = "lblConteudo";
            lblConteudo.Size = new Size(0, 20);
            lblConteudo.Text = "Conteúdo *";
            // 
            // txtConteudo
            // 
            txtConteudo.AcceptsReturn = true;
            txtConteudo.BackColor = Color.White;
            txtConteudo.BorderStyle = BorderStyle.FixedSingle;
            txtConteudo.Font = new Font("Segoe UI", 9.5F);
            txtConteudo.ForeColor = Color.FromArgb(70, 55, 48);
            txtConteudo.Location = new Point(28, 400);
            txtConteudo.MaxLength = 50000;
            txtConteudo.Multiline = true;
            txtConteudo.Name = "txtConteudo";
            txtConteudo.ScrollBars = ScrollBars.Vertical;
            txtConteudo.Size = new Size(1034, 170);
            txtConteudo.TabIndex = 5;
            // 
            // lblAjudaConteudo
            // 
            lblAjudaConteudo.AutoSize = true;
            lblAjudaConteudo.Font = new Font("Segoe UI", 7.5F);
            lblAjudaConteudo.ForeColor = Color.FromArgb(145, 125, 115);
            lblAjudaConteudo.Location = new Point(30, 576);
            lblAjudaConteudo.Name = "lblAjudaConteudo";
            lblAjudaConteudo.Size = new Size(503, 17);
            lblAjudaConteudo.Text = "Dica: use ## Título para uma seção, ### Subtítulo e linhas iniciadas por - para listas.";
            // 
            // pnlSeparador1
            // 
            pnlSeparador1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeparador1.BackColor = Color.FromArgb(234, 222, 212);
            pnlSeparador1.Location = new Point(28, 608);
            pnlSeparador1.Name = "pnlSeparador1";
            pnlSeparador1.Size = new Size(1034, 1);
            pnlSeparador1.TabStop = false;
            // 
            // pnlSeparador2
            // 
            pnlSeparador2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeparador2.BackColor = Color.FromArgb(234, 222, 212);
            pnlSeparador2.Location = new Point(28, 788);
            pnlSeparador2.Name = "pnlSeparador2";
            pnlSeparador2.Size = new Size(1034, 1);
            pnlSeparador2.TabStop = false;
            // 
            // lblPublicacao
            // 
            lblPublicacao.AutoSize = true;
            lblPublicacao.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblPublicacao.ForeColor = Color.FromArgb(90, 70, 60);
            lblPublicacao.Location = new Point(28, 806);
            lblPublicacao.Name = "lblPublicacao";
            lblPublicacao.Size = new Size(0, 20);
            lblPublicacao.Text = "Data de publicação";
            // 
            // dtPublicacao
            // 
            dtPublicacao.CustomFormat = "dd/MM/yyyy HH:mm";
            dtPublicacao.Font = new Font("Segoe UI", 9.5F);
            dtPublicacao.Format = DateTimePickerFormat.Custom;
            dtPublicacao.Location = new Point(28, 830);
            dtPublicacao.Name = "dtPublicacao";
            dtPublicacao.Size = new Size(240, 29);
            dtPublicacao.TabIndex = 10;
            // 
            // chkPublicado
            // 
            chkPublicado.AutoSize = true;
            chkPublicado.Checked = true;
            chkPublicado.CheckState = CheckState.Checked;
            chkPublicado.Cursor = Cursors.Hand;
            chkPublicado.Font = new Font("Segoe UI", 9F);
            chkPublicado.ForeColor = Color.FromArgb(92, 70, 60);
            chkPublicado.Location = new Point(310, 832);
            chkPublicado.Name = "chkPublicado";
            chkPublicado.Size = new Size(139, 24);
            chkPublicado.TabIndex = 11;
            chkPublicado.Text = "Publicação ativa";
            chkPublicado.UseVisualStyleBackColor = true;
            // 
            // chkDestaque
            // 
            chkDestaque.AutoSize = true;
            chkDestaque.Cursor = Cursors.Hand;
            chkDestaque.Font = new Font("Segoe UI", 9F);
            chkDestaque.ForeColor = Color.FromArgb(92, 70, 60);
            chkDestaque.Location = new Point(480, 832);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(184, 24);
            chkDestaque.TabIndex = 12;
            chkDestaque.Text = "Marcar como destaque";
            chkDestaque.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Animated = true;
            btnSalvar.BorderRadius = 9;
            btnSalvar.CustomizableEdges = customizableEdges19;
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FillColor = Color.FromArgb(212, 112, 74);
            btnSalvar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(912, 814);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSalvar.Size = new Size(150, 44);
            btnSalvar.TabIndex = 14;
            btnSalvar.Text = "Publicar";
            // 
            // btnCancelar
            // 
            btnCancelar.Animated = true;
            btnCancelar.BorderRadius = 9;
            btnCancelar.CustomizableEdges = customizableEdges21;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FillColor = Color.FromArgb(244, 236, 231);
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(92, 46, 14);
            btnCancelar.Location = new Point(776, 814);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnCancelar.Size = new Size(124, 44);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFechar.Animated = true;
            btnFechar.BorderRadius = 8;
            btnFechar.CustomizableEdges = customizableEdges23;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FillColor = Color.FromArgb(207, 132, 106);
            btnFechar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(990, 0);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnFechar.Size = new Size(44, 38);
            btnFechar.TabIndex = 15;
            btnFechar.Text = "X";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(130, 108, 98);
            lblSubtitulo.Location = new Point(2, 42);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(295, 20);
            lblSubtitulo.Text = "Cadastre uma nova publicação para o blog";
            // 
            // lblTituloJanela
            // 
            lblTituloJanela.AutoSize = true;
            lblTituloJanela.Font = new Font("Georgia", 18F, FontStyle.Bold);
            lblTituloJanela.ForeColor = Color.FromArgb(55, 37, 31);
            lblTituloJanela.Location = new Point(0, 0);
            lblTituloJanela.Name = "lblTituloJanela";
            lblTituloJanela.Size = new Size(269, 35);
            lblTituloJanela.Text = "Nova publicação";
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCabecalho.BackColor = Color.Transparent;
            pnlCabecalho.Controls.Add(btnFechar);
            pnlCabecalho.Controls.Add(lblSubtitulo);
            pnlCabecalho.Controls.Add(lblTituloJanela);
            pnlCabecalho.Location = new Point(28, 18);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(1034, 72);
            pnlCabecalho.TabIndex = 16;
            // 
            // BlogFormDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 246, 237);
            ClientSize = new Size(1090, 880);
            Controls.Add(pnlPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BlogFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Blog";
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            ResumeLayout(false);
        }
    }
}
