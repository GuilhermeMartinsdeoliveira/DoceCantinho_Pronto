namespace DoceCantinho.Desktop1.UserControls
{
    partial class CategoriasUserControl
    {
        private System.ComponentModel.IContainer components = null;

        // ============================================================
        // PAINEL PRINCIPAL
        // ============================================================

        private Panel pnlPrincipal;

        // ============================================================
        // CABEÇALHO
        // ============================================================

        private Panel pnlCabecalho;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Button btnNovoCat;

        // ============================================================
        // RESUMO
        // ============================================================

        private Panel pnlResumo;

        private Label lblResumoBolos;
        private Label lblResumoBrigadeiros;
        private Label lblResumoBrownies;
        private Label lblResumoCupcakes;
        private Label lblResumoGourmet;

        // ============================================================
        // CARDS
        // ============================================================

        private FlowLayoutPanel pnlCards;

        // ============================================================
        // FORMULÁRIO
        // ============================================================

        private Panel pnlForm;

        private Label lblFormTitulo;
        private Label lblNomeCategoria;

        private TextBox txtNome;

        private Button btnSalvar;
        private Button btnCancelar;

        // ============================================================
        // DISPOSE
        // ============================================================

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // ============================================================
        // INITIALIZE COMPONENT
        // ============================================================

        private void InitializeComponent()
        {
            pnlPrincipal = new Panel();
            pnlCards = new FlowLayoutPanel();
            pnlResumo = new Panel();
            lblResumoBolos = new Label();
            lblResumoBrigadeiros = new Label();
            lblResumoBrownies = new Label();
            lblResumoCupcakes = new Label();
            lblResumoGourmet = new Label();
            pnlCabecalho = new Panel();
            btnNovoCat = new Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlForm = new Panel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            txtNome = new TextBox();
            lblNomeCategoria = new Label();
            lblFormTitulo = new Label();
            pnlPrincipal.SuspendLayout();
            pnlResumo.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlForm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.FromArgb(248, 245, 242);
            pnlPrincipal.Controls.Add(pnlCards);
            pnlPrincipal.Controls.Add(pnlResumo);
            pnlPrincipal.Controls.Add(pnlCabecalho);
            pnlPrincipal.Controls.Add(pnlForm);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Padding = new Padding(24, 18, 24, 20);
            pnlPrincipal.Size = new Size(900, 600);
            pnlPrincipal.TabIndex = 0;
            // 
            // pnlCards
            // 
            pnlCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCards.AutoScroll = true;
            pnlCards.BackColor = Color.Transparent;
            pnlCards.Location = new Point(24, 160);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(852, 370);
            pnlCards.TabIndex = 2;
            // 
            // pnlResumo
            // 
            pnlResumo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlResumo.BackColor = Color.White;
            pnlResumo.Controls.Add(lblResumoBolos);
            pnlResumo.Controls.Add(lblResumoBrigadeiros);
            pnlResumo.Controls.Add(lblResumoBrownies);
            pnlResumo.Controls.Add(lblResumoCupcakes);
            pnlResumo.Controls.Add(lblResumoGourmet);
            pnlResumo.Location = new Point(24, 95);
            pnlResumo.Name = "pnlResumo";
            pnlResumo.Size = new Size(852, 48);
            pnlResumo.TabIndex = 1;
            // 
            // lblResumoBolos
            // 
            lblResumoBolos.Location = new Point(0, 0);
            lblResumoBolos.Name = "lblResumoBolos";
            lblResumoBolos.Size = new Size(100, 23);
            lblResumoBolos.TabIndex = 0;
            // 
            // lblResumoBrigadeiros
            // 
            lblResumoBrigadeiros.Location = new Point(0, 0);
            lblResumoBrigadeiros.Name = "lblResumoBrigadeiros";
            lblResumoBrigadeiros.Size = new Size(100, 23);
            lblResumoBrigadeiros.TabIndex = 1;
            // 
            // lblResumoBrownies
            // 
            lblResumoBrownies.Location = new Point(0, 0);
            lblResumoBrownies.Name = "lblResumoBrownies";
            lblResumoBrownies.Size = new Size(100, 23);
            lblResumoBrownies.TabIndex = 2;
            // 
            // lblResumoCupcakes
            // 
            lblResumoCupcakes.Location = new Point(0, 0);
            lblResumoCupcakes.Name = "lblResumoCupcakes";
            lblResumoCupcakes.Size = new Size(100, 23);
            lblResumoCupcakes.TabIndex = 3;
            // 
            // lblResumoGourmet
            // 
            lblResumoGourmet.Location = new Point(0, 0);
            lblResumoGourmet.Name = "lblResumoGourmet";
            lblResumoGourmet.Size = new Size(100, 23);
            lblResumoGourmet.TabIndex = 4;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCabecalho.BackColor = Color.Transparent;
            pnlCabecalho.Controls.Add(btnNovoCat);
            pnlCabecalho.Controls.Add(lblSubtitulo);
            pnlCabecalho.Controls.Add(lblTitulo);
            pnlCabecalho.Location = new Point(24, 18);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(852, 68);
            pnlCabecalho.TabIndex = 0;
            // 
            // btnNovoCat
            // 
            btnNovoCat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovoCat.BackColor = Color.FromArgb(198, 124, 99);
            btnNovoCat.Cursor = Cursors.Hand;
            btnNovoCat.FlatAppearance.BorderSize = 0;
            btnNovoCat.FlatStyle = FlatStyle.Flat;
            btnNovoCat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNovoCat.ForeColor = Color.White;
            btnNovoCat.Location = new Point(727, 32);
            btnNovoCat.Name = "btnNovoCat";
            btnNovoCat.Size = new Size(125, 36);
            btnNovoCat.TabIndex = 2;
            btnNovoCat.Text = "+  Nova Categoria";
            btnNovoCat.UseVisualStyleBackColor = false;
            btnNovoCat.Click += btnNovoCat_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(130, 108, 98);
            lblSubtitulo.Location = new Point(6, 39);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(135, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Carregando categorias...";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(55, 37, 31);
            lblTitulo.Location = new Point(4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(179, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Categorias";
            // 
            // pnlForm
            // 
            pnlForm.BackColor = Color.White;
            pnlForm.BorderStyle = BorderStyle.FixedSingle;
            pnlForm.Controls.Add(btnCancelar);
            pnlForm.Controls.Add(btnSalvar);
            pnlForm.Controls.Add(txtNome);
            pnlForm.Controls.Add(lblNomeCategoria);
            pnlForm.Controls.Add(lblFormTitulo);
            pnlForm.Location = new Point(170, 175);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(560, 210);
            pnlForm.TabIndex = 3;
            pnlForm.Visible = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(244, 240, 237);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.FromArgb(100, 80, 70);
            btnCancelar.Location = new Point(435, 145);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(198, 124, 99);
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(325, 145);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(25, 90);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(510, 25);
            txtNome.TabIndex = 2;
            // 
            // lblNomeCategoria
            // 
            lblNomeCategoria.AutoSize = true;
            lblNomeCategoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNomeCategoria.ForeColor = Color.FromArgb(90, 70, 60);
            lblNomeCategoria.Location = new Point(25, 65);
            lblNomeCategoria.Name = "lblNomeCategoria";
            lblNomeCategoria.Size = new Size(108, 15);
            lblNomeCategoria.TabIndex = 1;
            lblNomeCategoria.Text = "Nome da categoria";
            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new Font("Georgia", 15F, FontStyle.Bold);
            lblFormTitulo.ForeColor = Color.FromArgb(60, 40, 32);
            lblFormTitulo.Location = new Point(25, 20);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new Size(167, 24);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Nova Categoria";
            // 
            // CategoriasUserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(248, 245, 242);
            Controls.Add(pnlPrincipal);
            Name = "CategoriasUserControl";
            Size = new Size(900, 600);
            Load += CategoriasUserControl_Load;
            pnlPrincipal.ResumeLayout(false);
            pnlResumo.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ResumeLayout(false);
        }

        // ============================================================
        // CONFIGURAR LABEL DO RESUMO
        // ============================================================

        private void ConfigurarLabelResumo(
            Label label,
            string nome,
            int x)
        {
            label.AutoSize = true;

            label.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Regular);

            label.ForeColor =
                Color.FromArgb(
                    105,
                    80,
                    70);

            label.Location =
                new Point(
                    x,
                    15);

            label.Name =
                nome;

            label.Size =
                new Size(
                    120,
                    20);

            label.TabIndex =
                0;

            label.Text =
                "";
        }
    }
}