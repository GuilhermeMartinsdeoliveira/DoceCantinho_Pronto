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
            components = new Container();

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblNome = new Label();
            txtTitulo = new TextBox();

            lblDescricao = new Label();
            txtDescricao = new TextBox();

            lblUrl = new Label();
            txtUrl = new TextBox();

            lblImagem = new Label();
            pictureImagem = new PictureBox();
            btnSelecionarImagem = new Button();
            btnRemoverImagem = new Button();
            lblArquivoImagem = new Label();
            btnAdicionarImagemUrl = new Button();

            lblPreco = new Label();
            nudPreco = new NumericUpDown();

            lblEstoque = new Label();
            nudEstoque = new NumericUpDown();

            lblCategoria = new Label();
            cmbCategoria = new ComboBox();

            chkDestaque = new CheckBox();

            btnSalvar = new Button();
            btnCancelar = new Button();

            picturePreview = new PictureBox();
            openFileDialogImagem = new OpenFileDialog();

            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(150, 25);
            lblTitulo.Text = "Novo Doce";

            // lblSubtitulo
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.Location = new Point(16, 42);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(250, 15);
            lblSubtitulo.Text = "Cadastre um novo produto no DoceCantinho";

            // lblNome
            lblNome.AutoSize = true;
            lblNome.Location = new Point(16, 80);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(90, 15);
            lblNome.Text = "Título";

            // txtTitulo
            txtTitulo.Location = new Point(16, 100);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(300, 23);

            // lblDescricao
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(16, 136);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(60, 15);
            lblDescricao.Text = "Descrição";

            // txtDescricao
            txtDescricao.Location = new Point(16, 156);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(300, 80);

            // lblUrl
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(16, 248);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(60, 15);
            lblUrl.Text = "URL da Imagem";

            // txtUrl
            txtUrl.Location = new Point(16, 268);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(300, 23);

            // btnAdicionarImagemUrl
            btnAdicionarImagemUrl.Location = new Point(328, 266);
            btnAdicionarImagemUrl.Name = "btnAdicionarImagemUrl";
            btnAdicionarImagemUrl.Size = new Size(120, 26);
            btnAdicionarImagemUrl.Text = "Adicionar URL";

            // lblArquivoImagem
            lblArquivoImagem.AutoSize = true;
            lblArquivoImagem.Location = new Point(16, 304);
            lblArquivoImagem.Name = "lblArquivoImagem";
            lblArquivoImagem.Size = new Size(140, 15);
            lblArquivoImagem.Text = "Nenhum arquivo selecionado";

            // btnSelecionarImagem
            btnSelecionarImagem.Location = new Point(16, 326);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.Size = new Size(140, 28);
            btnSelecionarImagem.Text = "Selecionar Imagem";

            // btnRemoverImagem
            btnRemoverImagem.Location = new Point(168, 326);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.Size = new Size(140, 28);
            btnRemoverImagem.Text = "Remover Imagem";

            // pictureImagem
            pictureImagem.Location = new Point(460, 100);
            pictureImagem.Name = "pictureImagem";
            pictureImagem.Size = new Size(320, 240);
            pictureImagem.BorderStyle = BorderStyle.FixedSingle;
            pictureImagem.SizeMode = PictureBoxSizeMode.Zoom;

            // picturePreview
            picturePreview.Location = new Point(460, 360);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(145, 120);
            picturePreview.BorderStyle = BorderStyle.FixedSingle;
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;

            // lblPreco
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(16, 370);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(38, 15);
            lblPreco.Text = "Preço";

            // nudPreco
            nudPreco.Location = new Point(16, 390);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(120, 23);

            // lblEstoque
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(160, 370);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(45, 15);
            lblEstoque.Text = "Estoque";

            // nudEstoque
            nudEstoque.Location = new Point(160, 390);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(120, 23);

            // lblCategoria
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(16, 424);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(60, 15);
            lblCategoria.Text = "Categoria";

            // cmbCategoria
            cmbCategoria.Location = new Point(16, 444);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(220, 23);

            // chkDestaque
            chkDestaque.Location = new Point(16, 480);
            chkDestaque.Name = "chkDestaque";
            chkDestaque.Size = new Size(120, 24);
            chkDestaque.Text = "Destaque";

            // btnSalvar
            btnSalvar.Location = new Point(580, 500);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 36);
            btnSalvar.Text = "Salvar";

            // btnCancelar
            btnCancelar.Location = new Point(708, 500);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 36);
            btnCancelar.Text = "Cancelar";

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 560);
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
            Controls.Add(pictureImagem);
            Controls.Add(picturePreview);
            Controls.Add(lblPreco);
            Controls.Add(nudPreco);
            Controls.Add(lblEstoque);
            Controls.Add(nudEstoque);
            Controls.Add(lblCategoria);
            Controls.Add(cmbCategoria);
            Controls.Add(chkDestaque);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoceFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Doce";

            ((ISupportInitialize)(pictureImagem)).EndInit();
            ((ISupportInitialize)(picturePreview)).EndInit();
            ((ISupportInitialize)(nudPreco)).EndInit();
            ((ISupportInitialize)(nudEstoque)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Label lblNome;
        private TextBox txtTitulo;

        private Label lblDescricao;
        private TextBox txtDescricao;

        private Label lblUrl;
        private TextBox txtUrl;

        private Label lblImagem;
        private PictureBox pictureImagem;

        private Button btnSelecionarImagem;
        private Button btnRemoverImagem;
        private Label lblArquivoImagem;
        private Button btnAdicionarImagemUrl;

        private Label lblPreco;
        private NumericUpDown nudPreco;

        private Label lblEstoque;
        private NumericUpDown nudEstoque;

        private Label lblCategoria;
        private ComboBox cmbCategoria;

        private CheckBox chkDestaque;

        private Button btnSalvar;
        private Button btnCancelar;

        private PictureBox picturePreview;
        private OpenFileDialog openFileDialogImagem;
    }
}