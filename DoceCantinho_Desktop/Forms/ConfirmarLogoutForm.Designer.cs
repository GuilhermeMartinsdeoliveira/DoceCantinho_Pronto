namespace DoceCantinho.Desktop.Forms
{
    partial class ConfirmarLogoutForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código do Designer

        private void InitializeComponent()
        {
            // ============================================================
            // COMPONENTES
            // ============================================================

            components =
                new System.ComponentModel.Container();

            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 =
                new Guna.UI2.WinForms.Suite.CustomizableEdges();

            guna2BorderlessForm1 =
                new Guna.UI2.WinForms.Guna2BorderlessForm(
                    components);

            guna2ShadowForm1 =
                new Guna.UI2.WinForms.Guna2ShadowForm();

            pnlPrincipal =
                new Guna.UI2.WinForms.Guna2Panel();

            pnlCabecalho =
                new Panel();

            lblTitulo =
                new Label();

            lblSubtitulo =
                new Label();

            lblIcone =
                new Label();

            lblMensagem =
                new Label();

            pnlBotoes =
                new Panel();

            btnNao =
                new Guna.UI2.WinForms.Guna2Button();

            btnSim =
                new Guna.UI2.WinForms.Guna2Button();

            pnlPrincipal.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlBotoes.SuspendLayout();
            SuspendLayout();

            // ============================================================
            // BORDERLESS FORM
            // ============================================================

            guna2BorderlessForm1.ContainerControl =
                this;

            guna2BorderlessForm1.DockIndicatorTransparencyValue =
                0.6D;

            guna2BorderlessForm1.TransparentWhileDrag =
                true;

            guna2BorderlessForm1.ShadowColor =
                Color.FromArgb(
                    60,
                    35,
                    25);

            // ============================================================
            // SHADOW
            // ============================================================

            guna2ShadowForm1.TargetForm =
                this;

            // ============================================================
            // FORM
            // ============================================================

            AutoScaleDimensions =
                new SizeF(
                    7F,
                    15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242);

            ClientSize =
                new Size(
                    470,
                    285);

            FormBorderStyle =
                FormBorderStyle.None;

            Name =
                "ConfirmarLogoutForm";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Confirmar saída";

            // ============================================================
            // PAINEL PRINCIPAL
            // ============================================================

            pnlPrincipal.BackColor =
                Color.Transparent;

            pnlPrincipal.BorderRadius =
                16;

            pnlPrincipal.CustomizableEdges =
                customizableEdges1;

            pnlPrincipal.Dock =
                DockStyle.Fill;

            pnlPrincipal.FillColor =
                Color.FromArgb(
                    248,
                    245,
                    242);

            pnlPrincipal.Location =
                new Point(
                    0,
                    0);

            pnlPrincipal.Name =
                "pnlPrincipal";

            pnlPrincipal.ShadowDecoration.CustomizableEdges =
                customizableEdges2;

            pnlPrincipal.ShadowDecoration.Enabled =
                false;

            pnlPrincipal.Size =
                new Size(
                    470,
                    285);

            pnlPrincipal.TabIndex =
                0;

            // ============================================================
            // CABEÇALHO
            // ============================================================

            pnlCabecalho.BackColor =
                Color.Transparent;

            pnlCabecalho.Location =
                new Point(
                    25,
                    18);

            pnlCabecalho.Name =
                "pnlCabecalho";

            pnlCabecalho.Size =
                new Size(
                    420,
                    70);

            pnlCabecalho.TabIndex =
                0;

            pnlCabecalho.Controls.Add(
                lblTitulo);

            pnlCabecalho.Controls.Add(
                lblSubtitulo);

            // ============================================================
            // TÍTULO
            // ============================================================

            lblTitulo.AutoSize =
                true;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    18F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(
                    55,
                    39,
                    34);

            lblTitulo.Location =
                new Point(
                    4,
                    2);

            lblTitulo.Name =
                "lblTitulo";

            lblTitulo.Size =
                new Size(
                    190,
                    29);

            lblTitulo.TabIndex =
                0;

            lblTitulo.Text =
                "Confirmar saída";

            // ============================================================
            // SUBTÍTULO
            // ============================================================

            lblSubtitulo.AutoSize =
                true;

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblSubtitulo.ForeColor =
                Color.FromArgb(
                    145,
                    117,
                    105);

            lblSubtitulo.Location =
                new Point(
                    6,
                    39);

            lblSubtitulo.Name =
                "lblSubtitulo";

            lblSubtitulo.Size =
                new Size(
                    240,
                    15);

            lblSubtitulo.TabIndex =
                1;

            lblSubtitulo.Text =
                "Sua sessão atual será encerrada.";

            // ============================================================
            // ÍCONE
            // ============================================================

            lblIcone.BackColor =
                Color.FromArgb(
                    250,
                    235,
                    228);

            lblIcone.Font =
                new Font(
                    "Segoe UI Symbol",
                    23F,
                    FontStyle.Regular);

            lblIcone.ForeColor =
                Color.FromArgb(
                    198,
                    124,
                    99);

            lblIcone.Location =
                new Point(
                    202,
                    102);

            lblIcone.Name =
                "lblIcone";

            lblIcone.Size =
                new Size(
                    66,
                    56);

            lblIcone.TabIndex =
                2;

            lblIcone.Text =
                "↪";

            lblIcone.TextAlign =
                ContentAlignment.MiddleCenter;

            // ============================================================
            // MENSAGEM
            // ============================================================

            lblMensagem.AutoSize =
                false;

            lblMensagem.Font =
                new Font(
                    "Segoe UI",
                    10.5F);

            lblMensagem.ForeColor =
                Color.FromArgb(
                    70,
                    58,
                    52);

            lblMensagem.Location =
                new Point(
                    45,
                    164);

            lblMensagem.Name =
                "lblMensagem";

            lblMensagem.Size =
                new Size(
                    380,
                    32);

            lblMensagem.TabIndex =
                3;

            lblMensagem.Text =
                "Deseja realmente sair do sistema?";

            lblMensagem.TextAlign =
                ContentAlignment.MiddleCenter;

            // ============================================================
            // PAINEL BOTÕES
            // ============================================================

            pnlBotoes.BackColor =
                Color.Transparent;

            pnlBotoes.Location =
                new Point(
                    102,
                    215);

            pnlBotoes.Name =
                "pnlBotoes";

            pnlBotoes.Size =
                new Size(
                    266,
                    46);

            pnlBotoes.TabIndex =
                4;

            // ============================================================
            // BOTÃO CANCELAR
            // ============================================================

            btnNao.BorderRadius =
                9;

            btnNao.CustomizableEdges =
                customizableEdges3;

            btnNao.FillColor =
                Color.FromArgb(
                    235,
                    229,
                    225);

            btnNao.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            btnNao.ForeColor =
                Color.FromArgb(
                    100,
                    78,
                    70);

            btnNao.HoverState.FillColor =
                Color.FromArgb(
                    224,
                    216,
                    211);

            btnNao.HoverState.ForeColor =
                Color.FromArgb(
                    75,
                    57,
                    51);

            btnNao.Location =
                new Point(
                    0,
                    0);

            btnNao.Name =
                "btnNao";

            btnNao.PressedColor =
                Color.FromArgb(
                    214,
                    203,
                    197);

            btnNao.ShadowDecoration.CustomizableEdges =
                customizableEdges4;

            btnNao.Size =
                new Size(
                    115,
                    40);

            btnNao.TabIndex =
                0;

            btnNao.Text =
                "Cancelar";

            btnNao.Click +=
                btnNao_Click;

            // ============================================================
            // BOTÃO SAIR
            // ============================================================

            btnSim.BorderRadius =
                9;

            btnSim.FillColor =
                Color.FromArgb(
                    198,
                    124,
                    99);

            btnSim.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            btnSim.ForeColor =
                Color.White;

            btnSim.HoverState.FillColor =
                Color.FromArgb(
                    180,
                    106,
                    82);

            btnSim.HoverState.ForeColor =
                Color.White;

            btnSim.Location =
                new Point(
                    126,
                    0);

            btnSim.Name =
                "btnSim";

            btnSim.PressedColor =
                Color.FromArgb(
                    164,
                    94,
                    73);

            btnSim.Size =
                new Size(
                    140,
                    40);

            btnSim.TabIndex =
                1;

            btnSim.Text =
                "Sair do sistema";

            btnSim.Click +=
                btnSim_Click;

            // ============================================================
            // HIERARQUIA
            // ============================================================

            pnlBotoes.Controls.Add(
                btnNao);

            pnlBotoes.Controls.Add(
                btnSim);

            pnlPrincipal.Controls.Add(
                pnlCabecalho);

            pnlPrincipal.Controls.Add(
                lblIcone);

            pnlPrincipal.Controls.Add(
                lblMensagem);

            pnlPrincipal.Controls.Add(
                pnlBotoes);

            Controls.Add(
                pnlPrincipal);

            // ============================================================
            // FINAL
            // ============================================================

            pnlPrincipal.ResumeLayout(false);

            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();

            pnlBotoes.ResumeLayout(false);

            ResumeLayout(false);
        }

        #endregion

        // ============================================================
        // COMPONENTES
        // ============================================================

        private Guna.UI2.WinForms.Guna2BorderlessForm
            guna2BorderlessForm1;

        private Guna.UI2.WinForms.Guna2ShadowForm
            guna2ShadowForm1;

        private Guna.UI2.WinForms.Guna2Panel
            pnlPrincipal;

        private Panel
            pnlCabecalho;

        private Label
            lblTitulo;

        private Label
            lblSubtitulo;

        private Label
            lblIcone;

        private Label
            lblMensagem;

        private Panel
            pnlBotoes;

        private Guna.UI2.WinForms.Guna2Button
            btnNao;

        private Guna.UI2.WinForms.Guna2Button
            btnSim;
    }
}