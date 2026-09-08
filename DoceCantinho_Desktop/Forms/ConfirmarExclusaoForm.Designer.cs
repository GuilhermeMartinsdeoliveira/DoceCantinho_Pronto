using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    partial class ConfirmarExclusaoForm
    {
        private System.ComponentModel.IContainer components = null;

        // ==========================================================
        // CONTROLES PRINCIPAIS
        // ==========================================================
        private Panel pnlPrincipal;
        private Panel pnlCabecalho;

        // ==========================================================
        // CABEÇALHO
        // ==========================================================
        private Label lblTitulo;
        private Label lblSubtitulo;

        // ==========================================================
        // CONTEÚDO
        // ==========================================================
        private Label lblIcone;
        private Label lblPergunta;
        private Label lblMensagem;

        // ==========================================================
        // BOTÕES
        // ==========================================================
        private Button btnCancelar;
        private Button btnExcluir;

        // ==========================================================
        // DISPOSE
        // ==========================================================
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // ==========================================================
        // INITIALIZE COMPONENT
        // ==========================================================
        private void InitializeComponent()
        {
            pnlPrincipal = new Panel();
            pnlCabecalho = new Panel();

            lblTitulo = new Label();
            lblSubtitulo = new Label();

            lblIcone = new Label();
            lblPergunta = new Label();
            lblMensagem = new Label();

            btnCancelar = new Button();
            btnExcluir = new Button();

            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();

            // ==========================================================
            // FORMULÁRIO
            // ==========================================================
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242
                );

            ClientSize =
                new Size(
                    470,
                    330
                );

            FormBorderStyle =
                FormBorderStyle.None;

            MaximizeBox = false;
            MinimizeBox = false;

            Name =
                "ConfirmarExclusaoForm";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Confirmar exclusão";

            // ==========================================================
            // PAINEL PRINCIPAL
            // ==========================================================
            pnlPrincipal.BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242
                );

            pnlPrincipal.Dock =
                DockStyle.Fill;

            pnlPrincipal.Location =
                new Point(
                    0,
                    0
                );

            pnlPrincipal.Name =
                "pnlPrincipal";

            pnlPrincipal.Size =
                new Size(
                    470,
                    330
                );

            pnlPrincipal.TabIndex =
                0;

            // ==========================================================
            // CABEÇALHO
            // ==========================================================
            pnlCabecalho.BackColor =
                Color.FromArgb(
                    47,
                    34,
                    30
                );

            pnlCabecalho.Location =
                new Point(
                    0,
                    0
                );

            pnlCabecalho.Name =
                "pnlCabecalho";

            pnlCabecalho.Size =
                new Size(
                    470,
                    78
                );

            pnlCabecalho.TabIndex =
                0;

            // ==========================================================
            // TÍTULO
            // ==========================================================
            lblTitulo.AutoSize =
                true;

            lblTitulo.BackColor =
                Color.Transparent;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    17F,
                    FontStyle.Bold
                );

            lblTitulo.ForeColor =
                Color.White;

            lblTitulo.Location =
                new Point(
                    24,
                    14
                );

            lblTitulo.Name =
                "lblTitulo";

            lblTitulo.Size =
                new Size(
                    190,
                    27
                );

            lblTitulo.TabIndex =
                0;

            lblTitulo.Text =
                "Excluir pedido";

            // ==========================================================
            // SUBTÍTULO
            // ==========================================================
            lblSubtitulo.AutoSize =
                true;

            lblSubtitulo.BackColor =
                Color.Transparent;

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    8.5F
                );

            lblSubtitulo.ForeColor =
                Color.FromArgb(
                    224,
                    211,
                    204
                );

            lblSubtitulo.Location =
                new Point(
                    26,
                    46
                );

            lblSubtitulo.Name =
                "lblSubtitulo";

            lblSubtitulo.Size =
                new Size(
                    218,
                    15
                );

            lblSubtitulo.TabIndex =
                1;

            lblSubtitulo.Text =
                "Esta ação não poderá ser desfeita.";

            // ==========================================================
            // ÍCONE
            // ==========================================================
            lblIcone.AutoSize =
                false;

            lblIcone.BackColor =
                Color.Transparent;

            lblIcone.Font =
                new Font(
                    "Segoe UI Emoji",
                    29F,
                    FontStyle.Regular
                );

            lblIcone.ForeColor =
                Color.FromArgb(
                    198,
                    124,
                    99
                );

            lblIcone.Location =
                new Point(
                    30,
                    112
                );

            lblIcone.Name =
                "lblIcone";

            lblIcone.Size =
                new Size(
                    52,
                    54
                );

            lblIcone.TabIndex =
                1;

            lblIcone.Text =
                "⚠";

            lblIcone.TextAlign =
                ContentAlignment.MiddleCenter;

            // ==========================================================
            // PERGUNTA
            // ==========================================================
            lblPergunta.AutoSize =
                false;

            lblPergunta.BackColor =
                Color.Transparent;

            lblPergunta.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold
                );

            lblPergunta.ForeColor =
                Color.FromArgb(
                    55,
                    37,
                    31
                );

            lblPergunta.Location =
                new Point(
                    92,
                    110
                );

            lblPergunta.Name =
                "lblPergunta";

            lblPergunta.Size =
                new Size(
                    340,
                    28
                );

            lblPergunta.TabIndex =
                2;

            lblPergunta.Text =
                "Deseja excluir este pedido?";

            // ==========================================================
            // MENSAGEM
            // ==========================================================
            lblMensagem.AutoSize =
                false;

            lblMensagem.BackColor =
                Color.Transparent;

            lblMensagem.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            lblMensagem.ForeColor =
                Color.FromArgb(
                    115,
                    95,
                    85
                );

            lblMensagem.Location =
                new Point(
                    93,
                    145
                );

            lblMensagem.Name =
                "lblMensagem";

            lblMensagem.Size =
                new Size(
                    335,
                    70
                );

            lblMensagem.TabIndex =
                3;

            lblMensagem.Text =
                "O pedido selecionado será removido permanentemente do sistema.";

            // ==========================================================
            // BOTÃO CANCELAR
            // ==========================================================
            btnCancelar.BackColor =
                Color.FromArgb(
                    241,
                    235,
                    231
                );

            btnCancelar.Cursor =
                Cursors.Hand;

            btnCancelar.FlatAppearance.BorderColor =
                Color.FromArgb(
                    224,
                    213,
                    207
                );

            btnCancelar.FlatAppearance.BorderSize =
                1;

            btnCancelar.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(
                    226,
                    218,
                    213
                );

            btnCancelar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(
                    235,
                    225,
                    220
                );

            btnCancelar.FlatStyle =
                FlatStyle.Flat;

            btnCancelar.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnCancelar.ForeColor =
                Color.FromArgb(
                    80,
                    65,
                    60
                );

            btnCancelar.Location =
                new Point(
                    218,
                    254
                );

            btnCancelar.Name =
                "btnCancelar";

            btnCancelar.Size =
                new Size(
                    105,
                    40
                );

            btnCancelar.TabIndex =
                4;

            btnCancelar.Text =
                "Cancelar";

            btnCancelar.UseVisualStyleBackColor =
                false;

            // ==========================================================
            // BOTÃO EXCLUIR
            // ==========================================================
            btnExcluir.BackColor =
                Color.FromArgb(
                    181,
                    72,
                    67
                );

            btnExcluir.Cursor =
                Cursors.Hand;

            btnExcluir.FlatAppearance.BorderSize =
                0;

            btnExcluir.FlatAppearance.MouseDownBackColor =
                Color.FromArgb(
                    145,
                    55,
                    55
                );

            btnExcluir.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(
                    164,
                    61,
                    58
                );

            btnExcluir.FlatStyle =
                FlatStyle.Flat;

            btnExcluir.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold
                );

            btnExcluir.ForeColor =
                Color.White;

            btnExcluir.Location =
                new Point(
                    334,
                    254
                );

            btnExcluir.Name =
                "btnExcluir";

            btnExcluir.Size =
                new Size(
                    112,
                    40
                );

            btnExcluir.TabIndex =
                5;

            btnExcluir.Text =
                "Excluir";

            btnExcluir.UseVisualStyleBackColor =
                false;

            // ==========================================================
            // HIERARQUIA DOS CONTROLES
            // ==========================================================
            pnlCabecalho.Controls.Add(
                lblTitulo
            );

            pnlCabecalho.Controls.Add(
                lblSubtitulo
            );

            pnlPrincipal.Controls.Add(
                btnExcluir
            );

            pnlPrincipal.Controls.Add(
                btnCancelar
            );

            pnlPrincipal.Controls.Add(
                lblMensagem
            );

            pnlPrincipal.Controls.Add(
                lblPergunta
            );

            pnlPrincipal.Controls.Add(
                lblIcone
            );

            pnlPrincipal.Controls.Add(
                pnlCabecalho
            );

            Controls.Add(
                pnlPrincipal
            );

            // ==========================================================
            // FINALIZAÇÃO
            // ==========================================================
            pnlCabecalho.ResumeLayout(
                false
            );

            pnlCabecalho.PerformLayout();

            pnlPrincipal.ResumeLayout(
                false
            );

            pnlPrincipal.PerformLayout();

            ResumeLayout(
                false
            );
        }
    }
}