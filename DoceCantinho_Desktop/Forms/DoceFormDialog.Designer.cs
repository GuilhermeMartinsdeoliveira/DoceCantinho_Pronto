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
            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblNome = new Label();
            txtTitulo = new Guna.UI2.WinForms.Guna2TextBox();

            lblDescricao = new Label();
            txtDescricao = new Guna.UI2.WinForms.Guna2TextBox();

            lblUrl = new Label();
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

            pnlThumb = new Guna.UI2.WinForms.Guna2Panel();
            picturePreview = new PictureBox();

            btnSalvar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();

            openFileDialogImagem = new OpenFileDialog();

            ((ISupportInitialize)nudPreco).BeginInit();
            ((ISupportInitialize)nudEstoque).BeginInit();
            ((ISupportInitialize)pictureImagem).BeginInit();
            ((ISupportInitialize)picturePreview).BeginInit();

            pnlPreview.SuspendLayout();
            pnlThumb.SuspendLayout();

            SuspendLayout();

            // ============================================================
            // lblTitulo
            // ============================================================

            lblTitulo.AutoSize = true;

            lblTitulo.Font = new Font(
                "Georgia",
                18F,
                FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(53, 39, 33);

            lblTitulo.Location = new Point(28, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(160, 29);
            lblTitulo.Text = "Novo Doce";

            // ============================================================
            // lblSubtitulo
            // ============================================================

            lblSubtitulo.AutoSize = true;

            lblSubtitulo.Font = new Font(
                "Segoe UI",
                9.5F);

            lblSubtitulo.ForeColor =
                Color.FromArgb(154, 137, 128);

            lblSubtitulo.Location = new Point(30, 56);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(300, 17);
            lblSubtitulo.Text = "Cadastre um novo produto no DoceCantinho";

            // ============================================================
            // lblNome
            // ============================================================

            lblNome.AutoSize = true;

            lblNome.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblNome.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblNome.Location = new Point(28, 96);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.Text = "Título";

            // ============================================================
            // txtTitulo
            // ============================================================

            txtTitulo.BorderColor =
                Color.FromArgb(224, 214, 208);

            txtTitulo.BorderRadius = 7;

            txtTitulo.FillColor =
                Color.FromArgb(250, 248, 246);

            txtTitulo.FocusedState.BorderColor =
                Color.FromArgb(198, 124, 99);

            txtTitulo.Font = new Font(
                "Segoe UI",
                9.5F);

            txtTitulo.ForeColor =
                Color.FromArgb(65, 50, 43);

            txtTitulo.HoverState.BorderColor =
                Color.FromArgb(210, 170, 156);

            txtTitulo.Location = new Point(28, 116);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex.: Brigadeiro Gourmet";
            txtTitulo.Size = new Size(380, 36);

            // ============================================================
            // lblDescricao
            // ============================================================

            lblDescricao.AutoSize = true;

            lblDescricao.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblDescricao.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblDescricao.Location = new Point(28, 164);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(60, 15);
            lblDescricao.Text = "Descrição";

            // ============================================================
            // txtDescricao
            // ============================================================

            txtDescricao.BorderColor =
                Color.FromArgb(224, 214, 208);

            txtDescricao.BorderRadius = 7;

            txtDescricao.FillColor =
                Color.FromArgb(250, 248, 246);

            txtDescricao.FocusedState.BorderColor =
                Color.FromArgb(198, 124, 99);

            txtDescricao.Font = new Font(
                "Segoe UI",
                9.5F);

            txtDescricao.ForeColor =
                Color.FromArgb(65, 50, 43);

            txtDescricao.HoverState.BorderColor =
                Color.FromArgb(210, 170, 156);

            txtDescricao.Location = new Point(28, 184);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Fale um pouco sobre o doce...";
            txtDescricao.Size = new Size(380, 84);

            // ============================================================
            // lblUrl
            // ============================================================

            lblUrl.AutoSize = true;

            lblUrl.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblUrl.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblUrl.Location = new Point(28, 284);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(94, 15);
            lblUrl.Text = "URL da Imagem";

            // ============================================================
            // txtUrl
            // ============================================================

            txtUrl.BorderColor =
                Color.FromArgb(224, 214, 208);

            txtUrl.BorderRadius = 7;

            txtUrl.FillColor =
                Color.FromArgb(250, 248, 246);

            txtUrl.FocusedState.BorderColor =
                Color.FromArgb(198, 124, 99);

            txtUrl.Font = new Font(
                "Segoe UI",
                9.5F);

            txtUrl.ForeColor =
                Color.FromArgb(65, 50, 43);

            txtUrl.HoverState.BorderColor =
                Color.FromArgb(210, 170, 156);

            txtUrl.Location = new Point(28, 304);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "https://...";
            txtUrl.Size = new Size(268, 36);

            // ============================================================
            // btnAdicionarImagemUrl
            // ============================================================

            btnAdicionarImagemUrl.Animated = true;
            btnAdicionarImagemUrl.BorderRadius = 7;

            btnAdicionarImagemUrl.FillColor =
                Color.FromArgb(101, 97, 94);

            btnAdicionarImagemUrl.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold);

            btnAdicionarImagemUrl.ForeColor = Color.White;

            btnAdicionarImagemUrl.HoverState.FillColor =
                Color.FromArgb(81, 77, 74);

            btnAdicionarImagemUrl.Location = new Point(304, 304);
            btnAdicionarImagemUrl.Name = "btnAdicionarImagemUrl";
            btnAdicionarImagemUrl.Size = new Size(104, 36);
            btnAdicionarImagemUrl.Text = "Adicionar URL";
            btnAdicionarImagemUrl.Cursor = Cursors.Hand;

            // ============================================================
            // lblArquivoImagem
            // ============================================================

            lblArquivoImagem.AutoSize = true;

            lblArquivoImagem.Font = new Font(
                "Segoe UI",
                8.5F,
                FontStyle.Italic);

            lblArquivoImagem.ForeColor =
                Color.FromArgb(150, 134, 125);

            lblArquivoImagem.Location = new Point(28, 350);
            lblArquivoImagem.Name = "lblArquivoImagem";
            lblArquivoImagem.Size = new Size(163, 15);
            lblArquivoImagem.Text = "Nenhum arquivo selecionado";

            // ============================================================
            // btnSelecionarImagem
            // ============================================================

            btnSelecionarImagem.Animated = true;
            btnSelecionarImagem.BorderRadius = 7;

            btnSelecionarImagem.FillColor =
                Color.FromArgb(198, 124, 99);

            btnSelecionarImagem.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold);

            btnSelecionarImagem.ForeColor = Color.White;

            btnSelecionarImagem.HoverState.FillColor =
                Color.FromArgb(178, 105, 83);

            btnSelecionarImagem.Location = new Point(28, 370);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.Size = new Size(182, 36);
            btnSelecionarImagem.Text = "📁  Selecionar Imagem";
            btnSelecionarImagem.Cursor = Cursors.Hand;

            // ============================================================
            // btnRemoverImagem
            // ============================================================

            btnRemoverImagem.Animated = true;
            btnRemoverImagem.BorderRadius = 7;

            btnRemoverImagem.FillColor =
                Color.FromArgb(229, 219, 213);

            btnRemoverImagem.Font = new Font(
                "Segoe UI Semibold",
                8.5F,
                FontStyle.Bold);

            btnRemoverImagem.ForeColor =
                Color.FromArgb(126, 72, 56);

            btnRemoverImagem.HoverState.FillColor =
                Color.FromArgb(216, 203, 196);

            btnRemoverImagem.Location = new Point(218, 370);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.Size = new Size(190, 36);
            btnRemoverImagem.Text = "🗑  Remover Imagem";
            btnRemoverImagem.Cursor = Cursors.Hand;

            // ============================================================
            // lblPreco
            // ============================================================

            lblPreco.AutoSize = true;

            lblPreco.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblPreco.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblPreco.Location = new Point(28, 424);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(39, 15);
            lblPreco.Text = "Preço";

            // ============================================================
            // nudPreco
            // ============================================================

            nudPreco.BorderStyle = BorderStyle.FixedSingle;

            nudPreco.Font = new Font(
                "Segoe UI",
                9.5F);

            nudPreco.ForeColor =
                Color.FromArgb(65, 50, 43);

            nudPreco.Location = new Point(28, 444);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(178, 27);
            nudPreco.TextAlign = HorizontalAlignment.Center;

            // ============================================================
            // lblEstoque
            // ============================================================

            lblEstoque.AutoSize = true;

            lblEstoque.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblEstoque.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblEstoque.Location = new Point(224, 424);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(51, 15);
            lblEstoque.Text = "Estoque";

            // ============================================================
            // nudEstoque
            // ============================================================

            nudEstoque.BorderStyle = BorderStyle.FixedSingle;

            nudEstoque.Font = new Font(
                "Segoe UI",
                9.5F);

            nudEstoque.ForeColor =
                Color.FromArgb(65, 50, 43);

            nudEstoque.Location = new Point(224, 444);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(184, 27);
            nudEstoque.TextAlign = HorizontalAlignment.Center;

            // ============================================================
            // lblCategoria
            // ============================================================

            lblCategoria.AutoSize = true;

            lblCategoria.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            lblCategoria.ForeColor =
                Color.FromArgb(95, 80, 72);

            lblCategoria.Location = new Point(28, 490);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(60, 15);
            lblCategoria.Text = "Categoria";

            // ============================================================
            // cmbCategoria
            // ============================================================

            cmbCategoria.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCategoria.FlatStyle = FlatStyle.Flat;

            cmbCategoria.Font = new Font(
                "Segoe UI",
                9.5F);

            cmbCategoria.ForeColor =
                Color.FromArgb(65, 50, 43);

            cmbCategoria.Location = new Point(28, 510);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(380, 28);
            cmbCategoria.Cursor = Cursors.Hand;

            // ============================================================
            // chkDestaque
            // ============================================================

            chkDestaque.AutoSize = true;

            chkDestaque.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            chkDestaque.ForeColor =
                Color.FromArgb(171, 117, 40);

            chkDestaque.Location = new Point(28, 556);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(95, 22);
            chkDestaque.Text = "⭐  Destaque";
            chkDestaque.Cursor = Cursors.Hand;

            // ============================================================
            // pnlPreview (moldura da imagem principal)
            // ============================================================

            pnlPreview.BackColor = Color.White;

            pnlPreview.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlPreview.BorderRadius = 10;
            pnlPreview.BorderThickness = 1;

            pnlPreview.FillColor = Color.White;

            pnlPreview.Location = new Point(438, 96);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.Size = new Size(376, 260);

            // ============================================================
            // pictureImagem
            // ============================================================

            pictureImagem.BackColor =
                Color.FromArgb(250, 248, 246);

            pictureImagem.Dock = DockStyle.Fill;
            pictureImagem.Location = new Point(0, 0);
            pictureImagem.Name = "pictureImagem";
            pictureImagem.Size = new Size(376, 260);
            pictureImagem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureImagem.TabStop = false;

            // ============================================================
            // pnlThumb (moldura da miniatura)
            // ============================================================

            pnlThumb.BackColor = Color.White;

            pnlThumb.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlThumb.BorderRadius = 10;
            pnlThumb.BorderThickness = 1;

            pnlThumb.FillColor = Color.White;

            pnlThumb.Location = new Point(438, 370);
            pnlThumb.Name = "pnlThumb";
            pnlThumb.Size = new Size(180, 130);

            // ============================================================
            // picturePreview
            // ============================================================

            picturePreview.BackColor =
                Color.FromArgb(250, 248, 246);

            picturePreview.Dock = DockStyle.Fill;
            picturePreview.Location = new Point(0, 0);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(180, 130);
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picturePreview.TabStop = false;

            // ============================================================
            // btnSalvar
            // ============================================================

            btnSalvar.Animated = true;
            btnSalvar.BorderRadius = 8;

            btnSalvar.FillColor =
                Color.FromArgb(198, 124, 99);

            btnSalvar.Font = new Font(
                "Segoe UI Semibold",
                9.5F,
                FontStyle.Bold);

            btnSalvar.ForeColor = Color.White;

            btnSalvar.HoverState.FillColor =
                Color.FromArgb(178, 105, 83);

            btnSalvar.Location = new Point(602, 556);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 40);
            btnSalvar.Text = "✓  Salvar Doce";
            btnSalvar.Cursor = Cursors.Hand;

            // ============================================================
            // btnCancelar
            // ============================================================

            btnCancelar.Animated = true;
            btnCancelar.BorderRadius = 8;

            btnCancelar.FillColor =
                Color.FromArgb(229, 219, 213);

            btnCancelar.Font = new Font(
                "Segoe UI Semibold",
                9.5F,
                FontStyle.Bold);

            btnCancelar.ForeColor =
                Color.FromArgb(126, 72, 56);

            btnCancelar.HoverState.FillColor =
                Color.FromArgb(216, 203, 196);

            btnCancelar.Location = new Point(730, 556);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Cursor = Cursors.Hand;

            // ============================================================
            // Montagem dos painéis
            // ============================================================

            pnlPreview.Controls.Add(pictureImagem);
            pnlThumb.Controls.Add(picturePreview);

            // ============================================================
            // DoceFormDialog
            // ============================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(247, 243, 240);

            ClientSize = new Size(862, 616);

            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);

            Controls.Add(lblNome);
            Controls.Add(txtTitulo);

            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);

            Controls.Add(lblUrl);
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
            Controls.Add(pnlThumb);

            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Name = "DoceFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Doce";

            ((ISupportInitialize)nudPreco).EndInit();
            ((ISupportInitialize)nudEstoque).EndInit();
            ((ISupportInitialize)pictureImagem).EndInit();
            ((ISupportInitialize)picturePreview).EndInit();

            pnlPreview.ResumeLayout(false);
            pnlThumb.ResumeLayout(false);

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

        private Guna.UI2.WinForms.Guna2Panel pnlThumb;
        private PictureBox picturePreview;

        private OpenFileDialog openFileDialogImagem;
    }
}

