using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace DoceCantinho.Desktop.UserControls
{
    partial class BlogUserControl
    {
        private System.ComponentModel.IContainer components = null;

        // ============================================================
        // CONTROLES
        // ============================================================

        private Panel pnlPrincipal;

        private Label lblTitulo;
        private Label lblSubtitulo;

        private Guna.UI2.WinForms.Guna2TextBox txtBusca;

        private Guna.UI2.WinForms.Guna2Button btnNovo;
        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnExcluir;
        private Guna.UI2.WinForms.Guna2Button btnAtualizar;

        private Label lblResumo;
        private Label lblResultados;

        private Guna.UI2.WinForms.Guna2DataGridView dgvBlog;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colAutor;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDestaque;

        private DataGridViewButtonColumn colEditar;
        private DataGridViewButtonColumn colExcluir;

        // ============================================================
        // DISPOSE
        // ============================================================

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // ============================================================
        // INITIALIZE
        // ============================================================

        private void InitializeComponent()
        {
            pnlPrincipal =
                new Panel();

            lblTitulo =
                new Label();

            lblSubtitulo =
                new Label();

            txtBusca =
                new Guna.UI2.WinForms.Guna2TextBox();

            btnNovo =
                new Guna.UI2.WinForms.Guna2Button();

            btnEditar =
                new Guna.UI2.WinForms.Guna2Button();

            btnExcluir =
                new Guna.UI2.WinForms.Guna2Button();

            btnAtualizar =
                new Guna.UI2.WinForms.Guna2Button();

            lblResumo =
                new Label();

            lblResultados =
                new Label();

            dgvBlog =
                new Guna.UI2.WinForms.Guna2DataGridView();

            colId =
                new DataGridViewTextBoxColumn();

            colTitulo =
                new DataGridViewTextBoxColumn();

            colCategoria =
                new DataGridViewTextBoxColumn();

            colAutor =
                new DataGridViewTextBoxColumn();

            colData =
                new DataGridViewTextBoxColumn();

            colStatus =
                new DataGridViewTextBoxColumn();

            colDestaque =
                new DataGridViewTextBoxColumn();

            colEditar =
                new DataGridViewButtonColumn();

            colExcluir =
                new DataGridViewButtonColumn();

            ((System.ComponentModel.ISupportInitialize)
                dgvBlog).BeginInit();

            pnlPrincipal.SuspendLayout();

            SuspendLayout();

            // ============================================================
            // PAINEL PRINCIPAL
            // ============================================================

            pnlPrincipal.BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242
                );

            pnlPrincipal.Dock =
                DockStyle.Fill;

            pnlPrincipal.Padding =
                new Padding(28);

            pnlPrincipal.Name =
                "pnlPrincipal";

            pnlPrincipal.Size =
                new Size(
                    1200,
                    860
                );

            pnlPrincipal.TabIndex =
                0;

            // ============================================================
            // TÍTULO
            // ============================================================

            lblTitulo.AutoSize =
                true;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    21F,
                    FontStyle.Bold
                );

            lblTitulo.ForeColor =
                Color.FromArgb(
                    55,
                    37,
                    31
                );

            lblTitulo.Location =
                new Point(
                    28,
                    26
                );

            lblTitulo.Name =
                "lblTitulo";

            lblTitulo.Text =
                "Blog";

            // ============================================================
            // SUBTÍTULO
            // ============================================================

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
                    30,
                    69
                );

            lblSubtitulo.Name =
                "lblSubtitulo";

            lblSubtitulo.Text =
                "Crie, edite e organize as publicações do Doce Cantinho";

            // ============================================================
            // BUSCA
            // ============================================================

            txtBusca.BorderColor =
                Color.FromArgb(
                    224,
                    214,
                    209
                );

            txtBusca.BorderRadius =
                9;

            txtBusca.BorderThickness =
                1;

            txtBusca.FillColor =
                Color.White;

            txtBusca.FocusedState.BorderColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            txtBusca.HoverState.BorderColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            txtBusca.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            txtBusca.ForeColor =
                Color.FromArgb(
                    70,
                    55,
                    48
                );

            txtBusca.Location =
                new Point(
                    30,
                    108
                );

            txtBusca.Name =
                "txtBusca";

            txtBusca.PlaceholderText =
                "Buscar por título, categoria, autor ou tag...";

            txtBusca.Size =
                new Size(
                    420,
                    40
                );

            // ============================================================
            // BOTÃO NOVO (CRIAR)
            // ============================================================

            btnNovo.BorderRadius =
                9;

            btnNovo.FillColor =
                Color.FromArgb(
                    212,
                    112,
                    74
                );

            btnNovo.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnNovo.ForeColor =
                Color.White;

            btnNovo.Location =
                new Point(
                    1015,
                    108
                );

            btnNovo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnNovo.Name =
                "btnNovo";

            btnNovo.Size =
                new Size(
                    155,
                    40
                );

            btnNovo.Text =
                "+  Nova publicação";

            btnNovo.Cursor =
                Cursors.Hand;

            // ============================================================
            // BOTÃO EDITAR
            // ============================================================

            btnEditar.BorderRadius =
                9;

            btnEditar.BorderColor =
                Color.FromArgb(
                    221,
                    211,
                    205
                );

            btnEditar.BorderThickness =
                1;

            btnEditar.FillColor =
                Color.White;

            btnEditar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnEditar.ForeColor =
                Color.FromArgb(
                    92,
                    46,
                    14
                );

            btnEditar.HoverState.FillColor =
                Color.FromArgb(
                    245,
                    238,
                    232
                );

            btnEditar.Location =
                new Point(
                    910,
                    108
                );

            btnEditar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnEditar.Name =
                "btnEditar";

            btnEditar.Size =
                new Size(
                    95,
                    40
                );

            btnEditar.Text =
                "Editar";

            btnEditar.Cursor =
                Cursors.Hand;

            // ============================================================
            // BOTÃO EXCLUIR / DELETAR
            // ============================================================

            btnExcluir.BorderRadius =
                9;

            btnExcluir.BorderColor =
                Color.FromArgb(
                    221,
                    211,
                    205
                );

            btnExcluir.BorderThickness =
                1;

            btnExcluir.FillColor =
                Color.White;

            btnExcluir.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnExcluir.ForeColor =
                Color.FromArgb(
                    195,
                    55,
                    55
                );

            btnExcluir.HoverState.FillColor =
                Color.FromArgb(
                    253,
                    239,
                    239
                );

            btnExcluir.Location =
                new Point(
                    805,
                    108
                );

            btnExcluir.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnExcluir.Name =
                "btnExcluir";

            btnExcluir.Size =
                new Size(
                    95,
                    40
                );

            btnExcluir.Text =
                "Excluir";

            btnExcluir.Cursor =
                Cursors.Hand;

            // ============================================================
            // BOTÃO ATUALIZAR
            // ============================================================

            btnAtualizar.BorderRadius =
                9;

            btnAtualizar.BorderColor =
                Color.FromArgb(
                    221,
                    211,
                    205
                );

            btnAtualizar.BorderThickness =
                1;

            btnAtualizar.FillColor =
                Color.White;

            btnAtualizar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnAtualizar.ForeColor =
                Color.FromArgb(
                    92,
                    46,
                    14
                );

            btnAtualizar.HoverState.FillColor =
                Color.FromArgb(
                    245,
                    238,
                    232
                );

            btnAtualizar.Location =
                new Point(
                    690,
                    108
                );

            btnAtualizar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnAtualizar.Name =
                "btnAtualizar";

            btnAtualizar.Size =
                new Size(
                    105,
                    40
                );

            btnAtualizar.Text =
                "↻ Atualizar";

            btnAtualizar.Cursor =
                Cursors.Hand;

            // ============================================================
            // RESUMO
            // ============================================================

            lblResumo.AutoSize =
                true;

            lblResumo.Font =
                new Font(
                    "Segoe UI",
                    8.5F
                );

            lblResumo.ForeColor =
                Color.FromArgb(
                    105,
                    80,
                    70
                );

            lblResumo.Location =
                new Point(
                    30,
                    168
                );

            lblResumo.Name =
                "lblResumo";

            lblResumo.Text =
                "0 posts • 0 publicados • 0 rascunhos • 0 destaque(s)";

            // ============================================================
            // RESULTADOS
            // ============================================================

            lblResultados.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            lblResultados.Font =
                new Font(
                    "Segoe UI",
                    8.5F
                );

            lblResultados.ForeColor =
                Color.FromArgb(
                    151,
                    134,
                    125
                );

            lblResultados.Location =
                new Point(
                    1010,
                    168
                );

            lblResultados.Name =
                "lblResultados";

            lblResultados.Size =
                new Size(
                    162,
                    20
                );

            lblResultados.Text =
                "0 publicação(ões)";

            lblResultados.TextAlign =
                ContentAlignment.MiddleRight;

            // ============================================================
            // GRID
            // ============================================================

            dgvBlog.AllowUserToAddRows =
                false;

            dgvBlog.AllowUserToDeleteRows =
                false;

            dgvBlog.AllowUserToResizeRows =
                false;

            dgvBlog.BackgroundColor =
                Color.White;

            dgvBlog.BorderStyle =
                BorderStyle.None;

            dgvBlog.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvBlog.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvBlog.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    92,
                    46,
                    14
                );

            dgvBlog.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    8.5F,
                    FontStyle.Bold
                );

            dgvBlog.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvBlog.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvBlog.ColumnHeadersHeight =
                42;

            dgvBlog.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvBlog.EnableHeadersVisualStyles =
                false;

            dgvBlog.GridColor =
                Color.FromArgb(
                    240,
                    234,
                    230
                );

            dgvBlog.DefaultCellStyle.BackColor =
                Color.White;

            dgvBlog.DefaultCellStyle.ForeColor =
                Color.FromArgb(
                    65,
                    50,
                    43
                );

            dgvBlog.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    8.5F
                );

            dgvBlog.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    245,
                    224,
                    214
                );

            dgvBlog.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    65,
                    50,
                    43
                );

            dgvBlog.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(
                    252,
                    249,
                    247
                );

            dgvBlog.RowTemplate.Height =
                42;

            dgvBlog.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBlog.MultiSelect =
                false;

            dgvBlog.ReadOnly =
                true;

            dgvBlog.Location =
                new Point(
                    30,
                    202
                );

            dgvBlog.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvBlog.Name =
                "dgvBlog";

            dgvBlog.Size =
                new Size(
                    1142,
                    630
                );

            // ============================================================
            // ID
            // ============================================================

            colId.HeaderText =
                "ID";

            colId.Name =
                "colId";

            colId.DataPropertyName =
                "Id";

            colId.Visible =
                false;

            // ============================================================
            // TÍTULO
            // ============================================================

            colTitulo.HeaderText =
                "TÍTULO";

            colTitulo.Name =
                "colTitulo";

            colTitulo.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            colTitulo.FillWeight =
                35;

            // ============================================================
            // CATEGORIA
            // ============================================================

            colCategoria.HeaderText =
                "CATEGORIA";

            colCategoria.Name =
                "colCategoria";

            colCategoria.Width =
                110;

            // ============================================================
            // AUTOR
            // ============================================================

            colAutor.HeaderText =
                "AUTOR";

            colAutor.Name =
                "colAutor";

            colAutor.Width =
                110;

            // ============================================================
            // DATA
            // ============================================================

            colData.HeaderText =
                "PUBLICAÇÃO";

            colData.Name =
                "colData";

            colData.Width =
                95;

            // ============================================================
            // STATUS
            // ============================================================

            colStatus.HeaderText =
                "STATUS";

            colStatus.Name =
                "colStatus";

            colStatus.Width =
                90;

            // ============================================================
            // DESTAQUE
            // ============================================================

            colDestaque.HeaderText =
                "DESTAQUE";

            colDestaque.Name =
                "colDestaque";

            colDestaque.Width =
                75;

            // ============================================================
            // EDITAR
            // ============================================================

            colEditar.HeaderText =
                "";

            colEditar.Name =
                "colEditar";

            colEditar.Text =
                "Editar";

            colEditar.UseColumnTextForButtonValue =
                true;

            colEditar.Width =
                65;

            colEditar.FlatStyle =
                FlatStyle.Flat;

            // ============================================================
            // EXCLUIR
            // ============================================================

            colExcluir.HeaderText =
                "";

            colExcluir.Name =
                "colExcluir";

            colExcluir.Text =
                "Excluir";

            colExcluir.UseColumnTextForButtonValue =
                true;

            colExcluir.Width =
                65;

            colExcluir.FlatStyle =
                FlatStyle.Flat;

            // ============================================================
            // ADICIONAR COLUNAS
            // ============================================================

            dgvBlog.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colId,
                    colTitulo,
                    colCategoria,
                    colAutor,
                    colData,
                    colStatus,
                    colDestaque,
                    colEditar,
                    colExcluir
                }
            );

            // ============================================================
            // ADICIONAR CONTROLES
            // ============================================================

            pnlPrincipal.Controls.Add(
                dgvBlog
            );

            pnlPrincipal.Controls.Add(
                lblResultados
            );

            pnlPrincipal.Controls.Add(
                lblResumo
            );

            pnlPrincipal.Controls.Add(
                btnAtualizar
            );

            pnlPrincipal.Controls.Add(
                btnExcluir
            );

            pnlPrincipal.Controls.Add(
                btnEditar
            );

            pnlPrincipal.Controls.Add(
                btnNovo
            );

            pnlPrincipal.Controls.Add(
                txtBusca
            );

            pnlPrincipal.Controls.Add(
                lblSubtitulo
            );

            pnlPrincipal.Controls.Add(
                lblTitulo
            );

            Controls.Add(
                pnlPrincipal
            );

            // ============================================================
            // USER CONTROL
            // ============================================================

            AutoScaleDimensions =
                new SizeF(
                    8F,
                    20F
                );

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242
                );

            Name =
                "BlogUserControl";

            Size =
                new Size(
                    1200,
                    860
                );

            ((System.ComponentModel.ISupportInitialize)
                dgvBlog).EndInit();

            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();

            ResumeLayout(false);
        }
    }
}