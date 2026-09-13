using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    partial class BlogFormDialog
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlPrincipal;
        private Panel pnlCabecalho;

        private Guna.UI2.WinForms.Guna2Button btnFechar;

        private Label lblTituloJanela;
        private Label lblSubtitulo;

        private Label lblTitulo;
        private Guna.UI2.WinForms.Guna2TextBox txtTitulo;

        private Label lblSlug;
        private Guna.UI2.WinForms.Guna2TextBox txtSlug;

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
            pnlPrincipal = new Panel();

            pnlCabecalho = new Panel();

            btnFechar =
                new Guna.UI2.WinForms.Guna2Button();

            lblSubtitulo =
                new Label();

            lblTituloJanela =
                new Label();

            lblTitulo =
                new Label();

            txtTitulo =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblSlug =
                new Label();

            txtSlug =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblCategoria =
                new Label();

            txtCategoria =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblCapa =
                new Label();

            txtCapa =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblResumo =
                new Label();

            txtResumo =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblConteudo =
                new Label();

            txtConteudo =
                new TextBox();

            lblAjudaConteudo =
                new Label();

            lblTags =
                new Label();

            txtTags =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblAutor =
                new Label();

            txtAutor =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblCargoAutor =
                new Label();

            txtCargoAutor =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblAvatarAutor =
                new Label();

            txtAvatarAutor =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblBioAutor =
                new Label();

            txtBioAutor =
                new Guna.UI2.WinForms.Guna2TextBox();

            lblPublicacao =
                new Label();

            dtPublicacao =
                new DateTimePicker();

            chkPublicado =
                new CheckBox();

            chkDestaque =
                new CheckBox();

            btnCancelar =
                new Guna.UI2.WinForms.Guna2Button();

            btnSalvar =
                new Guna.UI2.WinForms.Guna2Button();


            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();

            SuspendLayout();


            // ========================================================
            // PRINCIPAL
            // ========================================================

            pnlPrincipal.BackColor =
                Color.FromArgb(
                    253,
                    246,
                    237
                );

            pnlPrincipal.Dock =
                DockStyle.Fill;

            pnlPrincipal.Padding =
                new Padding(28);

            pnlPrincipal.AutoScroll =
                true;


            pnlPrincipal.Controls.Add(
                btnCancelar
            );

            pnlPrincipal.Controls.Add(
                btnSalvar
            );

            pnlPrincipal.Controls.Add(
                chkDestaque
            );

            pnlPrincipal.Controls.Add(
                chkPublicado
            );

            pnlPrincipal.Controls.Add(
                dtPublicacao
            );

            pnlPrincipal.Controls.Add(
                lblPublicacao
            );

            pnlPrincipal.Controls.Add(
                txtBioAutor
            );

            pnlPrincipal.Controls.Add(
                lblBioAutor
            );

            pnlPrincipal.Controls.Add(
                txtAvatarAutor
            );

            pnlPrincipal.Controls.Add(
                lblAvatarAutor
            );

            pnlPrincipal.Controls.Add(
                txtCargoAutor
            );

            pnlPrincipal.Controls.Add(
                lblCargoAutor
            );

            pnlPrincipal.Controls.Add(
                txtAutor
            );

            pnlPrincipal.Controls.Add(
                lblAutor
            );

            pnlPrincipal.Controls.Add(
                txtTags
            );

            pnlPrincipal.Controls.Add(
                lblTags
            );

            pnlPrincipal.Controls.Add(
                lblAjudaConteudo
            );

            pnlPrincipal.Controls.Add(
                txtConteudo
            );

            pnlPrincipal.Controls.Add(
                lblConteudo
            );

            pnlPrincipal.Controls.Add(
                txtResumo
            );

            pnlPrincipal.Controls.Add(
                lblResumo
            );

            pnlPrincipal.Controls.Add(
                txtCapa
            );

            pnlPrincipal.Controls.Add(
                lblCapa
            );

            pnlPrincipal.Controls.Add(
                txtCategoria
            );

            pnlPrincipal.Controls.Add(
                lblCategoria
            );

            pnlPrincipal.Controls.Add(
                txtSlug
            );

            pnlPrincipal.Controls.Add(
                lblSlug
            );

            pnlPrincipal.Controls.Add(
                txtTitulo
            );

            pnlPrincipal.Controls.Add(
                lblTitulo
            );

            pnlPrincipal.Controls.Add(
                pnlCabecalho
            );


            // ========================================================
            // CABEÇALHO
            // ========================================================

            pnlCabecalho.BackColor =
                Color.Transparent;

            pnlCabecalho.Location =
                new Point(
                    28,
                    18
                );

            pnlCabecalho.Size =
                new Size(
                    1030,
                    72
                );

            pnlCabecalho.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;


            pnlCabecalho.Controls.Add(
                btnFechar
            );

            pnlCabecalho.Controls.Add(
                lblSubtitulo
            );

            pnlCabecalho.Controls.Add(
                lblTituloJanela
            );


            // ========================================================
            // TÍTULO DA JANELA
            // ========================================================

            lblTituloJanela.AutoSize =
                true;

            lblTituloJanela.Font =
                new Font(
                    "Georgia",
                    18F,
                    FontStyle.Bold
                );

            lblTituloJanela.ForeColor =
                Color.FromArgb(
                    55,
                    37,
                    31
                );

            lblTituloJanela.Location =
                new Point(
                    0,
                    0
                );

            lblTituloJanela.Text =
                "Nova publicação";


            // ========================================================
            // SUBTÍTULO
            // ========================================================

            lblSubtitulo.AutoSize =
                true;

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            lblSubtitulo.ForeColor =
                Color.FromArgb(
                    130,
                    108,
                    98
                );

            lblSubtitulo.Location =
                new Point(
                    2,
                    40
                );

            lblSubtitulo.Text =
                "Cadastre uma nova publicação para o blog";


            // ========================================================
            // FECHAR
            // ========================================================

            btnFechar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnFechar.BorderRadius =
                8;

            btnFechar.FillColor =
                Color.FromArgb(
                    207,
                    132,
                    106
                );

            btnFechar.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold
                );

            btnFechar.ForeColor =
                Color.White;

            btnFechar.Location =
                new Point(
                    984,
                    0
                );

            btnFechar.Size =
                new Size(
                    40,
                    34
                );

            btnFechar.Text =
                "X";


            // ========================================================
            // CAMPOS
            // ========================================================

            ConfigurarLabel(
                lblTitulo,
                "Título *",
                28,
                108
            );

            ConfigurarTextBox(
                txtTitulo,
                28,
                130,
                650,
                40,
                "Título da publicação"
            );


            ConfigurarLabel(
                lblSlug,
                "Slug",
                698,
                108
            );

            ConfigurarTextBox(
                txtSlug,
                698,
                130,
                360,
                40,
                "gerado automaticamente"
            );


            ConfigurarLabel(
                lblCategoria,
                "Categoria *",
                28,
                184
            );

            ConfigurarTextBox(
                txtCategoria,
                28,
                206,
                315,
                40,
                "Ex.: Receitas, Dicas, Novidades"
            );


            ConfigurarLabel(
                lblCapa,
                "Imagem de capa (URL)",
                360,
                184
            );

            ConfigurarTextBox(
                txtCapa,
                360,
                206,
                698,
                40,
                "https://..."
            );


            ConfigurarLabel(
                lblResumo,
                "Resumo *",
                28,
                260
            );


            txtResumo.Multiline =
                true;

            txtResumo.BorderRadius =
                9;

            txtResumo.FillColor =
                Color.White;

            txtResumo.FocusedState.BorderColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            txtResumo.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            txtResumo.Location =
                new Point(
                    28,
                    282
                );

            txtResumo.Size =
                new Size(
                    1030,
                    62
                );

            txtResumo.MaxLength =
                500;


            txtCapa.MaxLength =
                500;

            txtSlug.MaxLength =
                250;

            txtCategoria.MaxLength =
                100;

            txtTags.MaxLength =
                500;

            txtAutor.MaxLength =
                150;

            txtCargoAutor.MaxLength =
                150;

            txtAvatarAutor.MaxLength =
                500;

            txtBioAutor.MaxLength =
                1000;


            // ========================================================
            // CONTEÚDO
            // ========================================================

            ConfigurarLabel(
                lblConteudo,
                "Conteúdo *",
                28,
                364
            );


            txtConteudo.BackColor =
                Color.White;

            txtConteudo.BorderStyle =
                BorderStyle.FixedSingle;

            txtConteudo.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            txtConteudo.ForeColor =
                Color.FromArgb(
                    70,
                    55,
                    48
                );

            txtConteudo.Location =
                new Point(
                    28,
                    386
                );

            txtConteudo.Multiline =
                true;

            txtConteudo.ScrollBars =
                ScrollBars.Vertical;

            txtConteudo.Size =
                new Size(
                    1030,
                    180
                );

            txtConteudo.MaxLength =
                50000;


            lblAjudaConteudo.AutoSize =
                true;

            lblAjudaConteudo.Font =
                new Font(
                    "Segoe UI",
                    7.5F
                );

            lblAjudaConteudo.ForeColor =
                Color.FromArgb(
                    145,
                    125,
                    115
                );

            lblAjudaConteudo.Location =
                new Point(
                    30,
                    571
                );

            lblAjudaConteudo.Text =
                "Dica: use ## Título para uma seção, ### Subtítulo e linhas iniciadas por - para listas.";


            // ========================================================
            // TAGS
            // ========================================================

            ConfigurarLabel(
                lblTags,
                "Tags",
                28,
                603
            );

            ConfigurarTextBox(
                txtTags,
                28,
                625,
                650,
                40,
                "receitas, confeitaria, dicas"
            );


            // ========================================================
            // AUTOR
            // ========================================================

            ConfigurarLabel(
                lblAutor,
                "Autor *",
                698,
                603
            );

            ConfigurarTextBox(
                txtAutor,
                698,
                625,
                360,
                40,
                "Nome do autor"
            );


            ConfigurarLabel(
                lblCargoAutor,
                "Cargo do autor",
                28,
                679
            );

            ConfigurarTextBox(
                txtCargoAutor,
                28,
                701,
                315,
                40,
                "Ex.: Confeiteira-chefe"
            );


            ConfigurarLabel(
                lblAvatarAutor,
                "Avatar do autor (URL ou Base64)",
                360,
                679
            );

            ConfigurarTextBox(
                txtAvatarAutor,
                360,
                701,
                698,
                40,
                "Opcional"
            );


            // ========================================================
            // BIO
            // ========================================================

            ConfigurarLabel(
                lblBioAutor,
                "Bio do autor",
                28,
                755
            );

            ConfigurarTextBox(
                txtBioAutor,
                28,
                777,
                1030,
                40,
                "Breve descrição do autor"
            );


            // ========================================================
            // DATA
            // ========================================================

            ConfigurarLabel(
                lblPublicacao,
                "Data de publicação",
                28,
                831
            );


            dtPublicacao.Format =
                DateTimePickerFormat.Custom;

            dtPublicacao.CustomFormat =
                "dd/MM/yyyy HH:mm";

            dtPublicacao.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            dtPublicacao.Location =
                new Point(
                    28,
                    853
                );

            dtPublicacao.Size =
                new Size(
                    210,
                    27
                );


            // ========================================================
            // PUBLICADO
            // ========================================================

            chkPublicado.AutoSize =
                true;

            chkPublicado.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            chkPublicado.ForeColor =
                Color.FromArgb(
                    92,
                    70,
                    60
                );

            chkPublicado.Location =
                new Point(
                    270,
                    855
                );

            chkPublicado.Text =
                "Publicação ativa";

            chkPublicado.Checked =
                true;


            // ========================================================
            // DESTAQUE
            // ========================================================

            chkDestaque.AutoSize =
                true;

            chkDestaque.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            chkDestaque.ForeColor =
                Color.FromArgb(
                    92,
                    70,
                    60
                );

            chkDestaque.Location =
                new Point(
                    430,
                    855
                );

            chkDestaque.Text =
                "Marcar como destaque";


            // ========================================================
            // CANCELAR
            // ========================================================

            btnCancelar.BorderRadius =
                9;

            btnCancelar.FillColor =
                Color.FromArgb(
                    244,
                    236,
                    231
                );

            btnCancelar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnCancelar.ForeColor =
                Color.FromArgb(
                    92,
                    46,
                    14
                );

            btnCancelar.Location =
                new Point(
                    810,
                    918
                );

            btnCancelar.Size =
                new Size(
                    118,
                    42
                );

            btnCancelar.Text =
                "Cancelar";


            // ========================================================
            // SALVAR
            // ========================================================

            btnSalvar.BorderRadius =
                9;

            btnSalvar.FillColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            btnSalvar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnSalvar.ForeColor =
                Color.White;

            btnSalvar.Location =
                new Point(
                    938,
                    918
                );

            btnSalvar.Size =
                new Size(
                    120,
                    42
                );

            btnSalvar.Text =
                "Publicar";


            // ========================================================
            // FORM
            // ========================================================

            AutoScaleDimensions =
                new SizeF(
                    8F,
                    20F
                );

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    253,
                    246,
                    237
                );

            ClientSize =
                new Size(
                    1090,
                    990
                );

            Controls.Add(
                pnlPrincipal
            );

            FormBorderStyle =
                FormBorderStyle.None;

            MaximizeBox =
                false;

            MinimizeBox =
                false;

            Name =
                "BlogFormDialog";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Blog";


            pnlCabecalho.ResumeLayout(
                false
            );

            pnlCabecalho.PerformLayout();

            pnlPrincipal.ResumeLayout(
                false
            );

            pnlPrincipal.PerformLayout();

            ResumeLayout(false);
        }


        // ============================================================
        // LABEL
        // ============================================================

        private static void ConfigurarLabel(
            Label label,
            string texto,
            int x,
            int y)
        {
            label.AutoSize =
                true;

            label.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold
                );

            label.ForeColor =
                Color.FromArgb(
                    90,
                    70,
                    60
                );

            label.Location =
                new Point(
                    x,
                    y
                );

            label.Text =
                texto;
        }


        // ============================================================
        // GUNA TEXTBOX
        // ============================================================

        private static void ConfigurarTextBox(
            Guna.UI2.WinForms.Guna2TextBox textBox,
            int x,
            int y,
            int width,
            int height,
            string placeholder)
        {
            textBox.BorderColor =
                Color.FromArgb(
                    224,
                    214,
                    209
                );

            textBox.BorderRadius =
                9;

            textBox.BorderThickness =
                1;

            textBox.FillColor =
                Color.White;

            textBox.FocusedState.BorderColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            textBox.HoverState.BorderColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            textBox.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            textBox.ForeColor =
                Color.FromArgb(
                    65,
                    50,
                    43
                );

            textBox.Location =
                new Point(
                    x,
                    y
                );

            textBox.PlaceholderText =
                placeholder;

            textBox.Size =
                new Size(
                    width,
                    height
                );
        }
    }
}