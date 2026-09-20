using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
 
namespace DoceCantinho.Desktop.Forms
{
    partial class DoceFormDialog
    {
        private IContainer components = null;

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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblNome = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            lblDescricao = new Label();
            txtDescricao = new Guna.UI2.WinForms.Guna2TextBox();
            lblUrl = new Label();
            rdoImagemUrl = new RadioButton();
            rdoImagemLocal = new RadioButton();
            txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdicionarImagemUrl = new Guna.UI2.WinForms.Guna2Button();
            lblArquivoImagem = new Label();
            btnSelecionarImagem = new Guna.UI2.WinForms.Guna2Button();
            btnRemoverImagem = new Guna.UI2.WinForms.Guna2Button();
            lblPreco = new Label();
            nudPreco = new NumericUpDown();
            lblEstoque = new Label();
            nudEstoque = new NumericUpDown();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            chkDestaque = new CheckBox();
            pnlPreview = new Guna.UI2.WinForms.Guna2Panel();
            pictureImagem = new PictureBox();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            openFileDialogImagem = new OpenFileDialog();
            BtnFechar = new Guna.UI2.WinForms.Guna2Button();
            ((ISupportInitialize)nudPreco).BeginInit();
            ((ISupportInitialize)nudEstoque).BeginInit();
            pnlPreview.SuspendLayout();
            ((ISupportInitialize)pictureImagem).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Georgia", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(53, 39, 33);
            lblTitulo.Location = new Point(32, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(180, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Novo Doce";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(154, 137, 128);
            lblSubtitulo.Location = new Point(34, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(321, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Cadastre um novo produto no DoceCantinho";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(95, 80, 72);
            lblNome.Location = new Point(32, 128);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(48, 20);
            lblNome.TabIndex = 2;
            lblNome.Text = "Título";
            // 
            // txtTitulo
            // 
            txtTitulo.BorderColor = Color.FromArgb(224, 214, 208);
            txtTitulo.BorderRadius = 7;
            txtTitulo.CustomizableEdges = customizableEdges1;
            txtTitulo.DefaultText = "";
            txtTitulo.FillColor = Color.FromArgb(250, 248, 246);
            txtTitulo.FocusedState.BorderColor = Color.FromArgb(198, 124, 99);
            txtTitulo.Font = new Font("Segoe UI", 9.5F);
            txtTitulo.ForeColor = Color.FromArgb(65, 50, 43);
            txtTitulo.HoverState.BorderColor = Color.FromArgb(210, 170, 156);
            txtTitulo.Location = new Point(32, 155);
            txtTitulo.Margin = new Padding(3, 5, 3, 5);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex.: Brigadeiro Gourmet";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTitulo.Size = new Size(434, 48);
            txtTitulo.TabIndex = 3;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescricao.ForeColor = Color.FromArgb(95, 80, 72);
            lblDescricao.Location = new Point(32, 219);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(75, 20);
            lblDescricao.TabIndex = 4;
            lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            txtDescricao.BorderColor = Color.FromArgb(224, 214, 208);
            txtDescricao.BorderRadius = 7;
            txtDescricao.CustomizableEdges = customizableEdges3;
            txtDescricao.DefaultText = "";
            txtDescricao.FillColor = Color.FromArgb(250, 248, 246);
            txtDescricao.FocusedState.BorderColor = Color.FromArgb(198, 124, 99);
            txtDescricao.Font = new Font("Segoe UI", 9.5F);
            txtDescricao.ForeColor = Color.FromArgb(65, 50, 43);
            txtDescricao.HoverState.BorderColor = Color.FromArgb(210, 170, 156);
            txtDescricao.Location = new Point(32, 245);
            txtDescricao.Margin = new Padding(3, 5, 3, 5);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Fale um pouco sobre o doce...";
            txtDescricao.SelectedText = "";
            txtDescricao.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtDescricao.Size = new Size(434, 112);
            txtDescricao.TabIndex = 5;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblUrl.ForeColor = Color.FromArgb(95, 80, 72);
            lblUrl.Location = new Point(32, 379);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(123, 20);
            lblUrl.TabIndex = 6;
            lblUrl.Text = "Imagem do doce";
            // 
            // rdoImagemUrl
            // 
            rdoImagemUrl.AutoSize = true;
            rdoImagemUrl.Checked = true;
            rdoImagemUrl.Cursor = Cursors.Hand;
            rdoImagemUrl.Font = new Font("Segoe UI", 9.5F);
            rdoImagemUrl.ForeColor = Color.FromArgb(53, 39, 33);
            rdoImagemUrl.Location = new Point(32, 408);
            rdoImagemUrl.Margin = new Padding(3, 4, 3, 4);
            rdoImagemUrl.Name = "rdoImagemUrl";
            rdoImagemUrl.Size = new Size(133, 25);
            rdoImagemUrl.TabIndex = 6;
            rdoImagemUrl.TabStop = true;
            rdoImagemUrl.Text = "🔗  Link (URL)";
            rdoImagemUrl.UseVisualStyleBackColor = true;
            // 
            // rdoImagemLocal
            // 
            rdoImagemLocal.AutoSize = true;
            rdoImagemLocal.Cursor = Cursors.Hand;
            rdoImagemLocal.Font = new Font("Segoe UI", 9.5F);
            rdoImagemLocal.ForeColor = Color.FromArgb(53, 39, 33);
            rdoImagemLocal.Location = new Point(201, 408);
            rdoImagemLocal.Margin = new Padding(3, 4, 3, 4);
            rdoImagemLocal.Name = "rdoImagemLocal";
            rdoImagemLocal.Size = new Size(152, 25);
            rdoImagemLocal.TabIndex = 7;
            rdoImagemLocal.Text = "📁  Arquivo local";
            rdoImagemLocal.UseVisualStyleBackColor = true;
            // 
            // txtUrl
            // 
            txtUrl.BorderColor = Color.FromArgb(224, 214, 208);
            txtUrl.BorderRadius = 7;
            txtUrl.CustomizableEdges = customizableEdges5;
            txtUrl.DefaultText = "";
            txtUrl.FillColor = Color.FromArgb(250, 248, 246);
            txtUrl.FocusedState.BorderColor = Color.FromArgb(198, 124, 99);
            txtUrl.Font = new Font("Segoe UI", 9.5F);
            txtUrl.ForeColor = Color.FromArgb(65, 50, 43);
            txtUrl.HoverState.BorderColor = Color.FromArgb(210, 170, 156);
            txtUrl.Location = new Point(32, 453);
            txtUrl.Margin = new Padding(3, 5, 3, 5);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "https://...";
            txtUrl.SelectedText = "";
            txtUrl.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUrl.Size = new Size(306, 48);
            txtUrl.TabIndex = 8;
            // 
            // btnAdicionarImagemUrl
            // 
            btnAdicionarImagemUrl.Animated = true;
            btnAdicionarImagemUrl.BorderRadius = 7;
            btnAdicionarImagemUrl.Cursor = Cursors.Hand;
            btnAdicionarImagemUrl.CustomizableEdges = customizableEdges7;
            btnAdicionarImagemUrl.FillColor = Color.FromArgb(101, 97, 94);
            btnAdicionarImagemUrl.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnAdicionarImagemUrl.ForeColor = Color.White;
            btnAdicionarImagemUrl.HoverState.FillColor = Color.FromArgb(81, 77, 74);
            btnAdicionarImagemUrl.Location = new Point(347, 453);
            btnAdicionarImagemUrl.Margin = new Padding(3, 4, 3, 4);
            btnAdicionarImagemUrl.Name = "btnAdicionarImagemUrl";
            btnAdicionarImagemUrl.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAdicionarImagemUrl.Size = new Size(119, 48);
            btnAdicionarImagemUrl.TabIndex = 9;
            btnAdicionarImagemUrl.Text = "Adicionar URL";
            // 
            // lblArquivoImagem
            // 
            lblArquivoImagem.AutoSize = true;
            lblArquivoImagem.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblArquivoImagem.ForeColor = Color.FromArgb(150, 134, 125);
            lblArquivoImagem.Location = new Point(32, 515);
            lblArquivoImagem.Name = "lblArquivoImagem";
            lblArquivoImagem.Size = new Size(195, 20);
            lblArquivoImagem.TabIndex = 10;
            lblArquivoImagem.Text = "Nenhum arquivo selecionado";
            // 
            // btnSelecionarImagem
            // 
            btnSelecionarImagem.Animated = true;
            btnSelecionarImagem.BorderRadius = 7;
            btnSelecionarImagem.Cursor = Cursors.Hand;
            btnSelecionarImagem.CustomizableEdges = customizableEdges9;
            btnSelecionarImagem.FillColor = Color.FromArgb(198, 124, 99);
            btnSelecionarImagem.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnSelecionarImagem.ForeColor = Color.White;
            btnSelecionarImagem.HoverState.FillColor = Color.FromArgb(178, 105, 83);
            btnSelecionarImagem.Location = new Point(32, 453);
            btnSelecionarImagem.Margin = new Padding(3, 4, 3, 4);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSelecionarImagem.Size = new Size(208, 48);
            btnSelecionarImagem.TabIndex = 11;
            btnSelecionarImagem.Text = "📁  Selecionar Imagem";
            // 
            // btnRemoverImagem
            // 
            btnRemoverImagem.Animated = true;
            btnRemoverImagem.BorderRadius = 7;
            btnRemoverImagem.Cursor = Cursors.Hand;
            btnRemoverImagem.CustomizableEdges = customizableEdges11;
            btnRemoverImagem.FillColor = Color.FromArgb(229, 219, 213);
            btnRemoverImagem.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnRemoverImagem.ForeColor = Color.FromArgb(126, 72, 56);
            btnRemoverImagem.HoverState.FillColor = Color.FromArgb(216, 203, 196);
            btnRemoverImagem.Location = new Point(249, 453);
            btnRemoverImagem.Margin = new Padding(3, 4, 3, 4);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRemoverImagem.Size = new Size(217, 48);
            btnRemoverImagem.TabIndex = 12;
            btnRemoverImagem.Text = "🗑  Remover Imagem";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPreco.ForeColor = Color.FromArgb(95, 80, 72);
            lblPreco.Location = new Point(32, 565);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(48, 20);
            lblPreco.TabIndex = 13;
            lblPreco.Text = "Preço";
            // 
            // nudPreco
            // 
            nudPreco.BorderStyle = BorderStyle.FixedSingle;
            nudPreco.Font = new Font("Segoe UI", 9.5F);
            nudPreco.ForeColor = Color.FromArgb(65, 50, 43);
            nudPreco.Location = new Point(32, 592);
            nudPreco.Margin = new Padding(3, 4, 3, 4);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(203, 29);
            nudPreco.TabIndex = 14;
            nudPreco.TextAlign = HorizontalAlignment.Center;
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEstoque.ForeColor = Color.FromArgb(95, 80, 72);
            lblEstoque.Location = new Point(256, 565);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(63, 20);
            lblEstoque.TabIndex = 15;
            lblEstoque.Text = "Estoque";
            // 
            // nudEstoque
            // 
            nudEstoque.BorderStyle = BorderStyle.FixedSingle;
            nudEstoque.Font = new Font("Segoe UI", 9.5F);
            nudEstoque.ForeColor = Color.FromArgb(65, 50, 43);
            nudEstoque.Location = new Point(256, 592);
            nudEstoque.Margin = new Padding(3, 4, 3, 4);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(210, 29);
            nudEstoque.TabIndex = 16;
            nudEstoque.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(95, 80, 72);
            lblCategoria.Location = new Point(32, 653);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(75, 20);
            lblCategoria.TabIndex = 17;
            lblCategoria.Text = "Categoria";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Cursor = Cursors.Hand;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.ForeColor = Color.FromArgb(65, 50, 43);
            cmbCategoria.Location = new Point(32, 680);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(434, 29);
            cmbCategoria.TabIndex = 18;
            // 
            // chkDestaque
            // 
            chkDestaque.AutoSize = true;
            chkDestaque.Cursor = Cursors.Hand;
            chkDestaque.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            chkDestaque.ForeColor = Color.FromArgb(171, 117, 40);
            chkDestaque.Location = new Point(32, 741);
            chkDestaque.Margin = new Padding(3, 4, 3, 4);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(117, 24);
            chkDestaque.TabIndex = 19;
            chkDestaque.Text = "⭐  Destaque";
            // 
            // pnlPreview
            // 
            pnlPreview.BackColor = Color.White;
            pnlPreview.BorderColor = Color.FromArgb(235, 227, 222);
            pnlPreview.BorderRadius = 10;
            pnlPreview.BorderThickness = 1;
            pnlPreview.Controls.Add(pictureImagem);
            pnlPreview.CustomizableEdges = customizableEdges13;
            pnlPreview.FillColor = Color.White;
            pnlPreview.Location = new Point(501, 128);
            pnlPreview.Margin = new Padding(3, 4, 3, 4);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlPreview.Size = new Size(430, 440);
            pnlPreview.TabIndex = 20;
            // 
            // pictureImagem
            // 
            pictureImagem.BackColor = Color.FromArgb(250, 248, 246);
            pictureImagem.Dock = DockStyle.Fill;
            pictureImagem.Location = new Point(0, 0);
            pictureImagem.Margin = new Padding(3, 4, 3, 4);
            pictureImagem.Name = "pictureImagem";
            pictureImagem.Size = new Size(430, 440);
            pictureImagem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureImagem.TabIndex = 0;
            pictureImagem.TabStop = false;
            // 
            // btnSalvar
            // 
            btnSalvar.Animated = true;
            btnSalvar.BorderRadius = 8;
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.CustomizableEdges = customizableEdges15;
            btnSalvar.FillColor = Color.FromArgb(198, 124, 99);
            btnSalvar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.HoverState.FillColor = Color.FromArgb(178, 105, 83);
            btnSalvar.Location = new Point(688, 741);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSalvar.Size = new Size(137, 53);
            btnSalvar.TabIndex = 21;
            btnSalvar.Text = "✓  Salvar Doce";
            // 
            // btnCancelar
            // 
            btnCancelar.Animated = true;
            btnCancelar.BorderRadius = 8;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.CustomizableEdges = customizableEdges17;
            btnCancelar.FillColor = Color.FromArgb(229, 219, 213);
            btnCancelar.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(126, 72, 56);
            btnCancelar.HoverState.FillColor = Color.FromArgb(216, 203, 196);
            btnCancelar.Location = new Point(834, 741);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnCancelar.Size = new Size(126, 53);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            // 
            // BtnFechar
            // 
            BtnFechar.BackColor = Color.FromArgb(247, 243, 240);
            BtnFechar.BorderRadius = 10;
            BtnFechar.CustomizableEdges = customizableEdges19;
            BtnFechar.DisabledState.BorderColor = Color.DarkGray;
            BtnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnFechar.FillColor = Color.FromArgb(201, 130, 107);
            BtnFechar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnFechar.ForeColor = SystemColors.Window;
            BtnFechar.Location = new Point(918, 12);
            BtnFechar.Name = "BtnFechar";
            BtnFechar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            BtnFechar.Size = new Size(55, 38);
            BtnFechar.TabIndex = 23;
            BtnFechar.Text = "X";
            BtnFechar.Click += BtnFechar_Click_1;
            // 
            // DoceFormDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 243, 240);
            ClientSize = new Size(985, 821);
            Controls.Add(BtnFechar);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblNome);
            Controls.Add(txtTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);
            Controls.Add(lblUrl);
            Controls.Add(rdoImagemUrl);
            Controls.Add(rdoImagemLocal);
            Controls.Add(txtUrl);
            Controls.Add(btnAdicionarImagemUrl);
            Controls.Add(lblArquivoImagem);
            Controls.Add(btnSelecionarImagem);
            Controls.Add(btnRemoverImagem);
            Controls.Add(lblPreco);
            Controls.Add(nudPreco);
            Controls.Add(lblEstoque);
            Controls.Add(nudEstoque);
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            Controls.Add(chkDestaque);
            Controls.Add(pnlPreview);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoceFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Doce";
            ((ISupportInitialize)nudPreco).EndInit();
            ((ISupportInitialize)nudEstoque).EndInit();
            pnlPreview.ResumeLayout(false);
            ((ISupportInitialize)pictureImagem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblNome;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;

        private Label lblDescricao;
        private Guna.UI2.WinForms.Guna2TextBox txtDescricao;

        private Label lblUrl;
        private Guna.UI2.WinForms.Guna2TextBox txtUrl;

        private RadioButton rdoImagemUrl;
        private RadioButton rdoImagemLocal;

        private Guna.UI2.WinForms.Guna2Panel pnlPreview;
        private PictureBox pictureImagem;

        private Guna.UI2.WinForms.Guna2Button btnSelecionarImagem;
        private Guna.UI2.WinForms.Guna2Button btnRemoverImagem;
        private Label lblArquivoImagem;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarImagemUrl;

        private Label lblPreco;
        private NumericUpDown nudPreco;

        private Label lblEstoque;
        private NumericUpDown nudEstoque;

        private Label lblCategoria;
        private ComboBox cmbCategoria;

        private CheckBox chkDestaque;

        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;

        private OpenFileDialog openFileDialogImagem;
        private Guna.UI2.WinForms.Guna2Button BtnFechar;
    }
}

