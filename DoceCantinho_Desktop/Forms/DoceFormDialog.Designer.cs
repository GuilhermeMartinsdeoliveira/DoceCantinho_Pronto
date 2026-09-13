using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    partial class DoceFormDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTituloJanela = new Label();
            lblTitulo = new Label();
            lblNome = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();
            lblDescricao = new Label();
            txtDescricao = new Guna.UI2.WinForms.Guna2TextBox();
            lblUrl = new Label();
            txtUrl = new Guna.UI2.WinForms.Guna2TextBox();
            lblImagem = new Label();
            pictureImagem = new PictureBox();
            btnSelecionarImagem = new Guna.UI2.WinForms.Guna2Button();
            btnRemoverImagem = new Guna.UI2.WinForms.Guna2Button();
            lblArquivoImagem = new Label();
            btnAdicionarImagemUrl = new Guna.UI2.WinForms.Guna2Button();
            lblPreco = new Label();
            nudPreco = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblEstoque = new Label();
            nudEstoque = new Guna.UI2.WinForms.Guna2NumericUpDown();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            chkDestaque = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            lblDestaque = new Label();
            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)pictureImagem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).BeginInit();
            SuspendLayout();
            // 
            // lblTituloJanela
            // 
            lblTituloJanela.AutoSize = true;
            lblTituloJanela.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloJanela.ForeColor = Color.FromArgb(92, 46, 14);
            lblTituloJanela.Location = new Point(34, 29);
            lblTituloJanela.Name = "lblTituloJanela";
            lblTituloJanela.Size = new Size(243, 37);
            lblTituloJanela.TabIndex = 0;
            lblTituloJanela.Text = "Cadastro de Doce";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(138, 101, 85);
            lblTitulo.Location = new Point(34, 83);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(142, 20);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "TÍTULO DO DOCE *";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(138, 101, 85);
            lblNome.Location = new Point(30, 82);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(0, 13);
            lblNome.TabIndex = 2;
            lblNome.Visible = false;
            // 
            // txtTitulo
            // 
            txtTitulo.BorderRadius = 10;
            txtTitulo.CustomizableEdges = customizableEdges1;
            txtTitulo.DefaultText = "";
            txtTitulo.FillColor = Color.FromArgb(255, 248, 240);
            txtTitulo.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTitulo.Font = new Font("Segoe UI", 10F);
            txtTitulo.ForeColor = Color.FromArgb(44, 24, 16);
            txtTitulo.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtTitulo.Location = new Point(34, 112);
            txtTitulo.Margin = new Padding(3, 5, 3, 5);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex: Brigadeiro Gourmet";
            txtTitulo.SelectedText = "";
            txtTitulo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTitulo.Size = new Size(571, 53);
            txtTitulo.TabIndex = 3;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDescricao.ForeColor = Color.FromArgb(138, 101, 85);
            lblDescricao.Location = new Point(34, 184);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(86, 19);
            lblDescricao.TabIndex = 4;
            lblDescricao.Text = "DESCRIÇÃO";
            // 
            // txtDescricao
            // 
            txtDescricao.BorderRadius = 10;
            txtDescricao.CustomizableEdges = customizableEdges3;
            txtDescricao.DefaultText = "";
            txtDescricao.FillColor = Color.FromArgb(255, 248, 240);
            txtDescricao.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtDescricao.Font = new Font("Segoe UI", 9F);
            txtDescricao.ForeColor = Color.FromArgb(44, 24, 16);
            txtDescricao.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtDescricao.Location = new Point(34, 211);
            txtDescricao.Margin = new Padding(3, 5, 3, 5);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Descreva o produto...";
            txtDescricao.SelectedText = "";
            txtDescricao.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtDescricao.Size = new Size(571, 133);
            txtDescricao.TabIndex = 5;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUrl.ForeColor = Color.FromArgb(138, 101, 85);
            lblUrl.Location = new Point(34, 371);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(100, 19);
            lblUrl.TabIndex = 6;
            lblUrl.Text = "URL DA CAPA";
            // 
            // txtUrl
            // 
            txtUrl.BorderRadius = 10;
            txtUrl.CustomizableEdges = customizableEdges5;
            txtUrl.DefaultText = "";
            txtUrl.FillColor = Color.FromArgb(255, 248, 240);
            txtUrl.FocusedState.BorderColor = Color.FromArgb(212, 112, 74);
            txtUrl.Font = new Font("Segoe UI", 9F);
            txtUrl.ForeColor = Color.FromArgb(44, 24, 16);
            txtUrl.HoverState.BorderColor = Color.FromArgb(212, 112, 74);
            txtUrl.Location = new Point(34, 395);
            txtUrl.Margin = new Padding(3, 5, 3, 5);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "https://...";
            txtUrl.SelectedText = "";
            txtUrl.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUrl.Size = new Size(571, 51);
            txtUrl.TabIndex = 7;
            // 
            // lblImagem
            // 
            lblImagem.AutoSize = true;
            lblImagem.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblImagem.ForeColor = Color.FromArgb(138, 101, 85);
            lblImagem.Location = new Point(663, 83);
            lblImagem.Name = "lblImagem";
            lblImagem.Size = new Size(132, 19);
            lblImagem.TabIndex = 8;
            lblImagem.Text = "IMAGEM DO DOCE";
            // 
            // pictureImagem
            // 
            pictureImagem.BackColor = Color.FromArgb(255, 248, 240);
            pictureImagem.BorderStyle = BorderStyle.FixedSingle;
            pictureImagem.Location = new Point(663, 112);
            pictureImagem.Margin = new Padding(3, 4, 3, 4);
            pictureImagem.Name = "pictureImagem";
            pictureImagem.Size = new Size(320, 373);
            pictureImagem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureImagem.TabIndex = 9;
            pictureImagem.TabStop = false;
            // 
            // btnSelecionarImagem
            // 
            btnSelecionarImagem.BorderRadius = 10;
            btnSelecionarImagem.CustomizableEdges = customizableEdges7;
            btnSelecionarImagem.FillColor = Color.FromArgb(212, 112, 74);
            btnSelecionarImagem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelecionarImagem.ForeColor = Color.White;
            btnSelecionarImagem.HoverState.FillColor = Color.FromArgb(190, 95, 61);
            btnSelecionarImagem.Location = new Point(663, 507);
            btnSelecionarImagem.Margin = new Padding(3, 4, 3, 4);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSelecionarImagem.Size = new Size(154, 53);
            btnSelecionarImagem.TabIndex = 10;
            btnSelecionarImagem.Text = "Selecionar imagem";
            btnSelecionarImagem.Click += btnSelecionarImagem_Click;
            // 
            // btnRemoverImagem
            // 
            btnRemoverImagem.BorderRadius = 10;
            btnRemoverImagem.CustomizableEdges = customizableEdges9;
            btnRemoverImagem.FillColor = Color.FromArgb(237, 224, 212);
            btnRemoverImagem.Font = new Font("Segoe UI", 9F);
            btnRemoverImagem.ForeColor = Color.FromArgb(92, 46, 14);
            btnRemoverImagem.HoverState.FillColor = Color.FromArgb(225, 208, 193);
            btnRemoverImagem.Location = new Point(829, 507);
            btnRemoverImagem.Margin = new Padding(3, 4, 3, 4);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRemoverImagem.Size = new Size(154, 53);
            btnRemoverImagem.TabIndex = 11;
            btnRemoverImagem.Text = "Remover imagem";
            btnRemoverImagem.Click += btnRemoverImagem_Click;
            // 
            // lblArquivoImagem
            // 
            lblArquivoImagem.AutoEllipsis = true;
            lblArquivoImagem.Font = new Font("Segoe UI", 8.5F);
            lblArquivoImagem.ForeColor = Color.FromArgb(110, 90, 78);
            lblArquivoImagem.Location = new Point(663, 573);
            lblArquivoImagem.Name = "lblArquivoImagem";
            lblArquivoImagem.Size = new Size(320, 47);
            lblArquivoImagem.TabIndex = 12;
            lblArquivoImagem.Text = "Nenhum arquivo selecionado";
            // 
            // btnAdicionarImagemUrl
            // 
            btnAdicionarImagemUrl.BorderRadius = 10;
            btnAdicionarImagemUrl.CustomizableEdges = customizableEdges11;
            btnAdicionarImagemUrl.FillColor = Color.FromArgb(92, 46, 14);
            btnAdicionarImagemUrl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdicionarImagemUrl.ForeColor = Color.White;
            btnAdicionarImagemUrl.HoverState.FillColor = Color.FromArgb(212, 112, 74);
            btnAdicionarImagemUrl.Location = new Point(462, 455);
            btnAdicionarImagemUrl.Margin = new Padding(3, 4, 3, 4);
            btnAdicionarImagemUrl.Name = "btnAdicionarImagemUrl";
            btnAdicionarImagemUrl.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAdicionarImagemUrl.Size = new Size(143, 48);
            btnAdicionarImagemUrl.TabIndex = 8;
            btnAdicionarImagemUrl.Text = "Adicionar por URL";
            btnAdicionarImagemUrl.Click += btnAdicionarImagemUrl_Click;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPreco.ForeColor = Color.FromArgb(138, 101, 85);
            lblPreco.Location = new Point(34, 487);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(64, 19);
            lblPreco.TabIndex = 13;
            lblPreco.Text = "PREÇO *";
            // 
            // nudPreco
            // 
            nudPreco.BackColor = Color.Transparent;
            nudPreco.BorderRadius = 10;
            nudPreco.CustomizableEdges = customizableEdges13;
            nudPreco.DecimalPlaces = 2;
            nudPreco.FillColor = Color.FromArgb(255, 248, 240);
            nudPreco.Font = new Font("Segoe UI", 10F);
            nudPreco.ForeColor = Color.FromArgb(44, 24, 16);
            nudPreco.Location = new Point(34, 513);
            nudPreco.Margin = new Padding(3, 5, 3, 5);
            nudPreco.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.ShadowDecoration.CustomizableEdges = customizableEdges14;
            nudPreco.Size = new Size(274, 51);
            nudPreco.TabIndex = 14;
            nudPreco.ThousandsSeparator = true;
            nudPreco.UpDownButtonFillColor = Color.FromArgb(212, 112, 74);
            nudPreco.UpDownButtonForeColor = Color.White;
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEstoque.ForeColor = Color.FromArgb(138, 101, 85);
            lblEstoque.Location = new Point(331, 487);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(80, 19);
            lblEstoque.TabIndex = 15;
            lblEstoque.Text = "ESTOQUE *";
            // 
            // nudEstoque
            // 
            nudEstoque.BackColor = Color.Transparent;
            nudEstoque.BorderRadius = 10;
            nudEstoque.CustomizableEdges = customizableEdges15;
            nudEstoque.FillColor = Color.FromArgb(255, 248, 240);
            nudEstoque.Font = new Font("Segoe UI", 10F);
            nudEstoque.ForeColor = Color.FromArgb(44, 24, 16);
            nudEstoque.Location = new Point(331, 513);
            nudEstoque.Margin = new Padding(3, 5, 3, 5);
            nudEstoque.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudEstoque.Name = "nudEstoque";
            nudEstoque.ShadowDecoration.CustomizableEdges = customizableEdges16;
            nudEstoque.Size = new Size(274, 51);
            nudEstoque.TabIndex = 16;
            nudEstoque.ThousandsSeparator = true;
            nudEstoque.UpDownButtonFillColor = Color.FromArgb(212, 112, 74);
            nudEstoque.UpDownButtonForeColor = Color.White;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.FromArgb(138, 101, 85);
            lblCategoria.Location = new Point(34, 593);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(96, 19);
            lblCategoria.TabIndex = 17;
            lblCategoria.Text = "CATEGORIA *";
            // 
            // cmbCategoria
            // 
            cmbCategoria.BackColor = Color.FromArgb(255, 248, 240);
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FlatStyle = FlatStyle.Flat;
            cmbCategoria.Font = new Font("Segoe UI", 9.5F);
            cmbCategoria.ForeColor = Color.FromArgb(44, 24, 16);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(34, 620);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(571, 29);
            cmbCategoria.TabIndex = 18;
            // 
            // chkDestaque
            // 
            chkDestaque.CheckedState.BorderColor = Color.FromArgb(212, 112, 74);
            chkDestaque.CheckedState.BorderRadius = 2;
            chkDestaque.CheckedState.BorderThickness = 0;
            chkDestaque.CheckedState.FillColor = Color.FromArgb(212, 112, 74);
            chkDestaque.CustomizableEdges = customizableEdges17;
            chkDestaque.Location = new Point(34, 687);
            chkDestaque.Margin = new Padding(3, 4, 3, 4);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.ShadowDecoration.CustomizableEdges = customizableEdges18;
            chkDestaque.Size = new Size(25, 27);
            chkDestaque.TabIndex = 19;
            chkDestaque.UncheckedState.BorderColor = Color.FromArgb(168, 150, 135);
            chkDestaque.UncheckedState.BorderRadius = 2;
            chkDestaque.UncheckedState.BorderThickness = 0;
            chkDestaque.UncheckedState.FillColor = Color.FromArgb(168, 150, 135);
            // 
            // lblDestaque
            // 
            lblDestaque.AutoSize = true;
            lblDestaque.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblDestaque.ForeColor = Color.FromArgb(44, 24, 16);
            lblDestaque.Location = new Point(69, 687);
            lblDestaque.Name = "lblDestaque";
            lblDestaque.Size = new Size(193, 23);
            lblDestaque.TabIndex = 20;
            lblDestaque.Text = "Marcar como destaque";
            // 
            // btnSalvar
            // 
            btnSalvar.BorderRadius = 10;
            btnSalvar.CustomizableEdges = customizableEdges19;
            btnSalvar.DisabledState.BorderColor = Color.DarkGray;
            btnSalvar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSalvar.DisabledState.FillColor = Color.FromArgb(196, 184, 174);
            btnSalvar.DisabledState.ForeColor = Color.FromArgb(158, 143, 132);
            btnSalvar.FillColor = Color.FromArgb(92, 46, 14);
            btnSalvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.HoverState.FillColor = Color.FromArgb(212, 112, 74);
            btnSalvar.Location = new Point(34, 787);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSalvar.Size = new Size(274, 64);
            btnSalvar.TabIndex = 21;
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 10;
            btnCancelar.CustomizableEdges = customizableEdges21;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(196, 184, 174);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(158, 143, 132);
            btnCancelar.FillColor = Color.FromArgb(237, 224, 212);
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.ForeColor = Color.FromArgb(92, 46, 14);
            btnCancelar.HoverState.FillColor = Color.FromArgb(232, 221, 210);
            btnCancelar.Location = new Point(331, 787);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnCancelar.Size = new Size(274, 64);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // DoceFormDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(253, 246, 237);
            ClientSize = new Size(1029, 933);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(lblDestaque);
            Controls.Add(chkDestaque);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(nudEstoque);
            Controls.Add(lblEstoque);
            Controls.Add(nudPreco);
            Controls.Add(lblPreco);
            Controls.Add(lblArquivoImagem);
            Controls.Add(btnRemoverImagem);
            Controls.Add(btnSelecionarImagem);
            Controls.Add(pictureImagem);
            Controls.Add(lblImagem);
            Controls.Add(txtUrl);
            Controls.Add(lblUrl);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(lblTituloJanela);
            Controls.Add(btnAdicionarImagemUrl);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoceFormDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo Doce";
            Load += DoceFormDialog_Load;
            ((System.ComponentModel.ISupportInitialize)pictureImagem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloJanela;
        private Label lblTitulo;

        private Label lblNome;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;

        private Label lblDescricao;
        private Guna.UI2.WinForms.Guna2TextBox txtDescricao;

        private Label lblUrl;
        private Guna.UI2.WinForms.Guna2TextBox txtUrl;

        private Label lblImagem;
        private PictureBox pictureImagem;

        private Guna.UI2.WinForms.Guna2Button btnSelecionarImagem;
        private Guna.UI2.WinForms.Guna2Button btnRemoverImagem;
        private Label lblArquivoImagem;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarImagemUrl;

        private Label lblPreco;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudPreco;

        private Label lblEstoque;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudEstoque;

        private Label lblCategoria;
        private ComboBox cmbCategoria;

        private Guna.UI2.WinForms.Guna2CustomCheckBox chkDestaque;
        private Label lblDestaque;

        private Guna.UI2.WinForms.Guna2Button btnSalvar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}