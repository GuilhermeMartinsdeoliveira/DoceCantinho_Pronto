namespace DoceCantinho.Desktop1.UserControls
{
    partial class UsuarioUserControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblSubTitulo;

        private Guna.UI2.WinForms.Guna2TextBox txtPesquisar;

        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;

        private Guna.UI2.WinForms.Guna2Panel pnlTotal;
        private Guna.UI2.WinForms.Guna2Panel pnlAtivos;
        private Guna.UI2.WinForms.Guna2Panel pnlAdministradores;

        private Label lblCardTotalTitulo;
        private Label lblCardTotalValor;
        private Label lblCardTotalDescricao;

        private Label lblCardAtivosTitulo;
        private Label lblCardAtivosValor;
        private Label lblCardAtivosDescricao;

        private Label lblCardAdminTitulo;
        private Label lblCardAdminValor;
        private Label lblCardAdminDescricao;

        private Guna.UI2.WinForms.Guna2DataGridView gridUsuarios;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPerfil;

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
            components = new System.ComponentModel.Container();

            lblTitulo = new Label();
            lblSubTitulo = new Label();

            txtPesquisar = new Guna.UI2.WinForms.Guna2TextBox();

            btnNovo = new Guna.UI2.WinForms.Guna2Button();
            btnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            btnEditar = new Guna.UI2.WinForms.Guna2Button();
            btnExcluir = new Guna.UI2.WinForms.Guna2Button();

            pnlTotal = new Guna.UI2.WinForms.Guna2Panel();
            pnlAtivos = new Guna.UI2.WinForms.Guna2Panel();
            pnlAdministradores = new Guna.UI2.WinForms.Guna2Panel();

            lblCardTotalTitulo = new Label();
            lblCardTotalValor = new Label();
            lblCardTotalDescricao = new Label();

            lblCardAtivosTitulo = new Label();
            lblCardAtivosValor = new Label();
            lblCardAtivosDescricao = new Label();

            lblCardAdminTitulo = new Label();
            lblCardAdminValor = new Label();
            lblCardAdminDescricao = new Label();

            gridUsuarios = new Guna.UI2.WinForms.Guna2DataGridView();

            colId = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPerfil = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)gridUsuarios).BeginInit();

            SuspendLayout();

            // ============================================================
            // USUARIO USER CONTROL
            // ============================================================

            BackColor = Color.FromArgb(247, 244, 242);
            Name = "UsuarioUserControl";
            Size = new Size(1075, 720);

            // ============================================================
            // TÍTULO
            // ============================================================

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font(
                "Segoe UI Semibold",
                21F,
                FontStyle.Bold);

            lblTitulo.ForeColor = Color.FromArgb(62, 47, 40);

            lblTitulo.Location = new Point(28, 22);
            lblTitulo.Name = "lblTitulo";

            lblTitulo.Text = "Usuários";

            // ============================================================
            // SUBTÍTULO
            // ============================================================

            lblSubTitulo.AutoSize = true;

            lblSubTitulo.Font = new Font(
                "Segoe UI",
                9F);

            lblSubTitulo.ForeColor =
                Color.FromArgb(143, 127, 118);

            lblSubTitulo.Location =
                new Point(30, 60);

            lblSubTitulo.Name =
                "lblSubTitulo";

            lblSubTitulo.Text =
                "Gerencie os usuários da Doce Cantinho";

            // ============================================================
            // CARD TOTAL
            // ============================================================

            pnlTotal.BackColor =
                Color.White;

            pnlTotal.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlTotal.BorderRadius =
                12;

            pnlTotal.Location =
                new Point(30, 100);

            pnlTotal.Name =
                "pnlTotal";

            pnlTotal.Size =
                new Size(300, 82);

            // ============================================================
            // CARD TOTAL - TEXTOS
            // ============================================================

            lblCardTotalTitulo.AutoSize = true;
            lblCardTotalTitulo.Font =
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold);

            lblCardTotalTitulo.ForeColor =
                Color.FromArgb(143, 127, 118);

            lblCardTotalTitulo.Location =
                new Point(18, 13);

            lblCardTotalTitulo.Text =
                "TOTAL DE USUÁRIOS";

            lblCardTotalValor.AutoSize = true;
            lblCardTotalValor.Font =
                new Font("Segoe UI Semibold", 19F, FontStyle.Bold);

            lblCardTotalValor.ForeColor =
                Color.FromArgb(62, 47, 40);

            lblCardTotalValor.Location =
                new Point(18, 32);

            lblCardTotalValor.Text =
                "0";

            lblCardTotalDescricao.AutoSize = true;
            lblCardTotalDescricao.Font =
                new Font("Segoe UI", 8F);

            lblCardTotalDescricao.ForeColor =
                Color.FromArgb(165, 149, 140);

            lblCardTotalDescricao.Location =
                new Point(62, 43);

            lblCardTotalDescricao.Text =
                "usuários cadastrados";

            pnlTotal.Controls.Add(lblCardTotalTitulo);
            pnlTotal.Controls.Add(lblCardTotalValor);
            pnlTotal.Controls.Add(lblCardTotalDescricao);

            // ============================================================
            // CARD ATIVOS
            // ============================================================

            pnlAtivos.BackColor =
                Color.White;

            pnlAtivos.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlAtivos.BorderRadius =
                12;

            pnlAtivos.Location =
                new Point(350, 100);

            pnlAtivos.Name =
                "pnlAtivos";

            pnlAtivos.Size =
                new Size(300, 82);

            lblCardAtivosTitulo.AutoSize = true;
            lblCardAtivosTitulo.Font =
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold);

            lblCardAtivosTitulo.ForeColor =
                Color.FromArgb(143, 127, 118);

            lblCardAtivosTitulo.Location =
                new Point(18, 13);

            lblCardAtivosTitulo.Text =
                "USUÁRIOS ATIVOS";

            lblCardAtivosValor.AutoSize = true;
            lblCardAtivosValor.Font =
                new Font("Segoe UI Semibold", 19F, FontStyle.Bold);

            lblCardAtivosValor.ForeColor =
                Color.FromArgb(82, 145, 105);

            lblCardAtivosValor.Location =
                new Point(18, 32);

            lblCardAtivosValor.Text =
                "0";

            lblCardAtivosDescricao.AutoSize = true;
            lblCardAtivosDescricao.Font =
                new Font("Segoe UI", 8F);

            lblCardAtivosDescricao.ForeColor =
                Color.FromArgb(165, 149, 140);

            lblCardAtivosDescricao.Location =
                new Point(62, 43);

            lblCardAtivosDescricao.Text =
                "com acesso ativo";

            pnlAtivos.Controls.Add(lblCardAtivosTitulo);
            pnlAtivos.Controls.Add(lblCardAtivosValor);
            pnlAtivos.Controls.Add(lblCardAtivosDescricao);

            // ============================================================
            // CARD ADMINISTRADORES
            // ============================================================

            pnlAdministradores.BackColor =
                Color.White;

            pnlAdministradores.BorderColor =
                Color.FromArgb(235, 227, 222);

            pnlAdministradores.BorderRadius =
                12;

            pnlAdministradores.Location =
                new Point(670, 100);

            pnlAdministradores.Name =
                "pnlAdministradores";

            pnlAdministradores.Size =
                new Size(300, 82);

            lblCardAdminTitulo.AutoSize = true;
            lblCardAdminTitulo.Font =
                new Font("Segoe UI Semibold", 8F, FontStyle.Bold);

            lblCardAdminTitulo.ForeColor =
                Color.FromArgb(143, 127, 118);

            lblCardAdminTitulo.Location =
                new Point(18, 13);

            lblCardAdminTitulo.Text =
                "ADMINISTRADORES";

            lblCardAdminValor.AutoSize = true;
            lblCardAdminValor.Font =
                new Font("Segoe UI Semibold", 19F, FontStyle.Bold);

            lblCardAdminValor.ForeColor =
                Color.FromArgb(212, 112, 74);

            lblCardAdminValor.Location =
                new Point(18, 32);

            lblCardAdminValor.Text =
                "0";

            lblCardAdminDescricao.AutoSize = true;
            lblCardAdminDescricao.Font =
                new Font("Segoe UI", 8F);

            lblCardAdminDescricao.ForeColor =
                Color.FromArgb(165, 149, 140);

            lblCardAdminDescricao.Location =
                new Point(62, 43);

            lblCardAdminDescricao.Text =
                "com acesso administrativo";

            pnlAdministradores.Controls.Add(lblCardAdminTitulo);
            pnlAdministradores.Controls.Add(lblCardAdminValor);
            pnlAdministradores.Controls.Add(lblCardAdminDescricao);

            // ============================================================
            // CAMPO DE PESQUISA
            // ============================================================

            txtPesquisar.BorderRadius = 9;

            txtPesquisar.BorderColor =
                Color.FromArgb(226, 216, 211);

            txtPesquisar.FillColor =
                Color.White;

            txtPesquisar.FocusedState.BorderColor =
                Color.FromArgb(212, 112, 74);

            txtPesquisar.Font =
                new Font("Segoe UI", 9F);

            txtPesquisar.ForeColor =
                Color.FromArgb(64, 48, 40);

            txtPesquisar.Location =
                new Point(30, 205);

            txtPesquisar.Name =
                "txtPesquisar";

            txtPesquisar.PlaceholderText =
                "🔍  Buscar usuário por e-mail...";

            txtPesquisar.Size =
                new Size(455, 40);

            txtPesquisar.TabIndex =
                0;

            txtPesquisar.TextChanged +=
                txtPesquisar_TextChanged;

            // ============================================================
            // NOVO
            // ============================================================

            btnNovo.BorderRadius = 9;

            btnNovo.FillColor =
                Color.FromArgb(212, 112, 74);

            btnNovo.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            btnNovo.ForeColor =
                Color.White;

            btnNovo.Location =
                new Point(850, 205);

            btnNovo.Name =
                "btnNovo";

            btnNovo.Size =
                new Size(120, 40);

            btnNovo.Text =
                "+ Novo usuário";

            btnNovo.Click +=
                btnNovo_Click;

            // ============================================================
            // ATUALIZAR
            // ============================================================

            btnAtualizar.BorderRadius = 9;

            btnAtualizar.FillColor =
                Color.White;

            btnAtualizar.BorderColor =
                Color.FromArgb(221, 211, 205);

            btnAtualizar.BorderThickness =
                1;

            btnAtualizar.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            btnAtualizar.ForeColor =
                Color.FromArgb(100, 80, 70);

            btnAtualizar.Location =
                new Point(500, 205);

            btnAtualizar.Name =
                "btnAtualizar";

            btnAtualizar.Size =
                new Size(110, 40);

            btnAtualizar.Text =
                "↻ Atualizar";

            btnAtualizar.Click +=
                btnAtualizar_Click;

            // ============================================================
            // EDITAR
            // ============================================================

            btnEditar.BorderRadius = 9;

            btnEditar.FillColor =
                Color.White;

            btnEditar.BorderColor =
                Color.FromArgb(221, 211, 205);

            btnEditar.BorderThickness =
                1;

            btnEditar.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            btnEditar.ForeColor =
                Color.FromArgb(100, 80, 70);

            btnEditar.Location =
                new Point(620, 205);

            btnEditar.Name =
                "btnEditar";

            btnEditar.Size =
                new Size(105, 40);

            btnEditar.Text =
                "Editar";

            btnEditar.Click +=
                btnEditar_Click;

            // ============================================================
            // EXCLUIR
            // ============================================================

            btnExcluir.BorderRadius = 9;

            btnExcluir.FillColor =
                Color.White;

            btnExcluir.BorderColor =
                Color.FromArgb(221, 211, 205);

            btnExcluir.BorderThickness =
                1;

            btnExcluir.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            btnExcluir.ForeColor =
                Color.FromArgb(155, 82, 72);

            btnExcluir.Location =
                new Point(735, 205);

            btnExcluir.Name =
                "btnExcluir";

            btnExcluir.Size =
                new Size(105, 40);

            btnExcluir.Text =
                "Excluir";

            btnExcluir.Click +=
                btnExcluir_Click;

            // ============================================================
            // GRID
            // ============================================================

            gridUsuarios.AllowUserToAddRows = false;
            gridUsuarios.AllowUserToDeleteRows = false;
            gridUsuarios.AllowUserToResizeRows = false;

            gridUsuarios.BackgroundColor =
                Color.White;

            gridUsuarios.BorderStyle =
                BorderStyle.None;

            gridUsuarios.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            gridUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            gridUsuarios.ColumnHeadersHeight =
                42;

            gridUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            gridUsuarios.EnableHeadersVisualStyles =
                false;

            gridUsuarios.GridColor =
                Color.FromArgb(238, 231, 226);

            gridUsuarios.Location =
                new Point(30, 265);

            gridUsuarios.MultiSelect =
                false;

            gridUsuarios.Name =
                "gridUsuarios";

            gridUsuarios.ReadOnly =
                true;

            gridUsuarios.RowHeadersVisible =
                false;

            gridUsuarios.RowTemplate.Height =
                48;

            gridUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridUsuarios.Size =
                new Size(940, 390);

            gridUsuarios.TabIndex =
                1;

            gridUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            gridUsuarios.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            gridUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(64, 48, 40);

            gridUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(249, 229, 220);

            gridUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(80, 50, 40);

            // ============================================================
            // CABEÇALHO DO GRID
            // ============================================================

            gridUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(248, 243, 239);

            gridUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            gridUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(92, 68, 57);

            gridUsuarios.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(248, 243, 239);

            gridUsuarios.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.FromArgb(92, 68, 57);

            // ============================================================
            // COLUNAS
            // ============================================================

            colId.HeaderText =
                "ID";

            colId.Name =
                "colId";

            colId.Width =
                100;

            colId.ReadOnly =
                true;

            colEmail.HeaderText =
                "E-MAIL";

            colEmail.Name =
                "colEmail";

            colEmail.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colEmail.ReadOnly =
                true;

            colPerfil.HeaderText =
                "PERFIL";

            colPerfil.Name =
                "colPerfil";

            colPerfil.Width =
                220;

            colPerfil.ReadOnly =
                true;

            gridUsuarios.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colId,
                    colEmail,
                    colPerfil
                });

            // ============================================================
            // ADICIONAR CONTROLES
            // ============================================================

            Controls.Add(lblTitulo);
            Controls.Add(lblSubTitulo);

            Controls.Add(pnlTotal);
            Controls.Add(pnlAtivos);
            Controls.Add(pnlAdministradores);

            Controls.Add(txtPesquisar);

            Controls.Add(btnAtualizar);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnNovo);

            Controls.Add(gridUsuarios);

            // ============================================================
            // LOAD
            // ============================================================

            Load +=
                UsuarioFormDialog_Load;

            ((System.ComponentModel.ISupportInitialize)gridUsuarios).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}