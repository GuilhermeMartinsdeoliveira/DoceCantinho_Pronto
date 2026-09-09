namespace DoceCantinho.Desktop.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Variável necessária para o Designer.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpa os recursos utilizados.
        /// </summary>
        /// <param name="disposing">true para liberar recursos gerenciados.</param>
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlPanel = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblSair = new Guna.UI2.WinForms.Guna2Button();
            pnlUsuario = new Guna.UI2.WinForms.Guna2Panel();
            lblSessao = new Label();
            lblPerfil = new Label();
            lblUsuario = new Label();
            lblAvatar = new Guna.UI2.WinForms.Guna2CircleButton();
            lblSeparador = new Label();
            btnUsuario = new Guna.UI2.WinForms.Guna2Button();
            btnPedidos = new Guna.UI2.WinForms.Guna2Button();
            btnCategoria = new Guna.UI2.WinForms.Guna2Button();
            btnDoce = new Guna.UI2.WinForms.Guna2Button();
            btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            lblMenu = new Label();
            lblLogoSub = new Label();
            lblLogo = new Label();
            lblLogoIcon = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            pnlLogoIcon = new PictureBox();
            guna2Panel1.SuspendLayout();
            pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLogoIcon).BeginInit();
            SuspendLayout();
            // 
            // pnlPanel
            // 
            pnlPanel.BackColor = Color.FromArgb(248, 245, 242);
            pnlPanel.Dock = DockStyle.Fill;
            pnlPanel.Location = new Point(225, 0);
            pnlPanel.Name = "pnlPanel";
            pnlPanel.Size = new Size(1075, 720);
            pnlPanel.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(47, 34, 30);
            guna2Panel1.Controls.Add(pnlLogoIcon);
            guna2Panel1.Controls.Add(lblLogoIcon);
            guna2Panel1.Controls.Add(lblSair);
            guna2Panel1.Controls.Add(pnlUsuario);
            guna2Panel1.Controls.Add(lblSeparador);
            guna2Panel1.Controls.Add(btnUsuario);
            guna2Panel1.Controls.Add(btnPedidos);
            guna2Panel1.Controls.Add(btnCategoria);
            guna2Panel1.Controls.Add(btnDoce);
            guna2Panel1.Controls.Add(btnDashboard);
            guna2Panel1.Controls.Add(lblMenu);
            guna2Panel1.Controls.Add(lblLogoSub);
            guna2Panel1.Controls.Add(lblLogo);
            guna2Panel1.CustomizableEdges = customizableEdges8;
            guna2Panel1.Dock = DockStyle.Left;
            guna2Panel1.FillColor = Color.FromArgb(47, 34, 30);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(225, 720);
            guna2Panel1.TabIndex = 1;
            // 
            // lblSair
            // 
            lblSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSair.BorderRadius = 8;
            lblSair.CustomizableEdges = customizableEdges1;
            lblSair.FillColor = Color.Transparent;
            lblSair.Font = new Font("Segoe UI", 9F);
            lblSair.ForeColor = Color.FromArgb(205, 187, 178);
            lblSair.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            lblSair.HoverState.ForeColor = Color.White;
            lblSair.Location = new Point(14, 677);
            lblSair.Name = "lblSair";
            lblSair.Padding = new Padding(10, 0, 0, 0);
            lblSair.ShadowDecoration.CustomizableEdges = customizableEdges1;
            lblSair.Size = new Size(197, 34);
            lblSair.TabIndex = 10;
            lblSair.Text = "↪   Sair";
            lblSair.TextAlign = HorizontalAlignment.Left;
            lblSair.Click += lblSair_Click;
            // 
            // pnlUsuario
            // 
            pnlUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlUsuario.BackColor = Color.FromArgb(58, 42, 37);
            pnlUsuario.BorderRadius = 11;
            pnlUsuario.Controls.Add(lblSessao);
            pnlUsuario.Controls.Add(lblPerfil);
            pnlUsuario.Controls.Add(lblUsuario);
            pnlUsuario.Controls.Add(lblAvatar);
            pnlUsuario.CustomizableEdges = customizableEdges2;
            pnlUsuario.FillColor = Color.FromArgb(58, 42, 37);
            pnlUsuario.Location = new Point(14, 593);
            pnlUsuario.Name = "pnlUsuario";
            pnlUsuario.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlUsuario.Size = new Size(197, 78);
            pnlUsuario.TabIndex = 9;
            pnlUsuario.Click += pnlUsuario_Click;
            // 
            // lblSessao
            // 
            lblSessao.AutoEllipsis = true;
            lblSessao.BackColor = Color.Transparent;
            lblSessao.Font = new Font("Segoe UI", 7F);
            lblSessao.ForeColor = Color.FromArgb(151, 128, 117);
            lblSessao.Location = new Point(58, 48);
            lblSessao.Name = "lblSessao";
            lblSessao.Size = new Size(125, 13);
            lblSessao.TabIndex = 3;
            lblSessao.Text = "● conectado";
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.BackColor = Color.Transparent;
            lblPerfil.Font = new Font("Segoe UI", 7.5F);
            lblPerfil.ForeColor = Color.FromArgb(214, 126, 91);
            lblPerfil.Location = new Point(58, 29);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(66, 12);
            lblPerfil.TabIndex = 2;
            lblPerfil.Text = "Administrador";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(58, 10);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(83, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Administrador";
            // 
            // lblAvatar
            // 
            lblAvatar.Animated = true;
            lblAvatar.BackColor = Color.Transparent;
            lblAvatar.BorderColor = Color.FromArgb(232, 166, 139);
            lblAvatar.BorderThickness = 1;
            lblAvatar.FillColor = Color.FromArgb(214, 126, 91);
            lblAvatar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(11, 14);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            lblAvatar.Size = new Size(39, 39);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "A";
            // 
            // lblSeparador
            // 
            lblSeparador.BackColor = Color.FromArgb(78, 57, 50);
            lblSeparador.Location = new Point(22, 366);
            lblSeparador.Name = "lblSeparador";
            lblSeparador.Size = new Size(180, 1);
            lblSeparador.TabIndex = 11;
            // 
            // btnUsuario
            // 
            btnUsuario.BorderRadius = 9;
            btnUsuario.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnUsuario.CustomizableEdges = customizableEdges3;
            btnUsuario.FillColor = Color.Transparent;
            btnUsuario.Font = new Font("Segoe UI", 9.5F);
            btnUsuario.ForeColor = Color.FromArgb(224, 211, 204);
            btnUsuario.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            btnUsuario.HoverState.ForeColor = Color.White;
            btnUsuario.Location = new Point(14, 302);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Padding = new Padding(10, 0, 0, 0);
            btnUsuario.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnUsuario.Size = new Size(197, 42);
            btnUsuario.TabIndex = 8;
            btnUsuario.Text = "♙   Usuários";
            btnUsuario.TextAlign = HorizontalAlignment.Left;
            btnUsuario.Click += btnUsuario_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.BorderRadius = 9;
            btnPedidos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnPedidos.CustomizableEdges = customizableEdges4;
            btnPedidos.FillColor = Color.Transparent;
            btnPedidos.Font = new Font("Segoe UI", 9.5F);
            btnPedidos.ForeColor = Color.FromArgb(224, 211, 204);
            btnPedidos.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            btnPedidos.HoverState.ForeColor = Color.White;
            btnPedidos.Location = new Point(14, 255);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Padding = new Padding(10, 0, 0, 0);
            btnPedidos.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPedidos.Size = new Size(197, 42);
            btnPedidos.TabIndex = 7;
            btnPedidos.Text = "▤   Pedidos";
            btnPedidos.TextAlign = HorizontalAlignment.Left;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnCategoria
            // 
            btnCategoria.BorderRadius = 9;
            btnCategoria.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnCategoria.CustomizableEdges = customizableEdges5;
            btnCategoria.FillColor = Color.Transparent;
            btnCategoria.Font = new Font("Segoe UI", 9.5F);
            btnCategoria.ForeColor = Color.FromArgb(224, 211, 204);
            btnCategoria.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            btnCategoria.HoverState.ForeColor = Color.White;
            btnCategoria.Location = new Point(14, 208);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Padding = new Padding(10, 0, 0, 0);
            btnCategoria.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnCategoria.Size = new Size(197, 42);
            btnCategoria.TabIndex = 6;
            btnCategoria.Text = "◇   Categorias";
            btnCategoria.TextAlign = HorizontalAlignment.Left;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // btnDoce
            // 
            btnDoce.BorderRadius = 9;
            btnDoce.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnDoce.CustomizableEdges = customizableEdges6;
            btnDoce.FillColor = Color.Transparent;
            btnDoce.Font = new Font("Segoe UI", 9.5F);
            btnDoce.ForeColor = Color.FromArgb(224, 211, 204);
            btnDoce.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            btnDoce.HoverState.ForeColor = Color.White;
            btnDoce.Location = new Point(14, 161);
            btnDoce.Name = "btnDoce";
            btnDoce.Padding = new Padding(10, 0, 0, 0);
            btnDoce.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDoce.Size = new Size(197, 42);
            btnDoce.TabIndex = 5;
            btnDoce.Text = "▣   Doces";
            btnDoce.TextAlign = HorizontalAlignment.Left;
            btnDoce.Click += btnDoce_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BorderRadius = 9;
            btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnDashboard.Checked = true;
            btnDashboard.CheckedState.FillColor = Color.FromArgb(214, 126, 91);
            btnDashboard.CheckedState.ForeColor = Color.White;
            btnDashboard.CustomizableEdges = customizableEdges7;
            btnDashboard.DisabledState.BorderColor = Color.Transparent;
            btnDashboard.DisabledState.FillColor = Color.Transparent;
            btnDashboard.DisabledState.ForeColor = Color.FromArgb(130, 110, 101);
            btnDashboard.FillColor = Color.FromArgb(214, 126, 91);
            btnDashboard.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.HoverState.FillColor = Color.FromArgb(84, 59, 51);
            btnDashboard.HoverState.ForeColor = Color.White;
            btnDashboard.ImageAlign = HorizontalAlignment.Left;
            btnDashboard.Location = new Point(14, 114);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 0, 0);
            btnDashboard.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnDashboard.Size = new Size(197, 42);
            btnDashboard.TabIndex = 4;
            btnDashboard.Text = "▦   Dashboard";
            btnDashboard.TextAlign = HorizontalAlignment.Left;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.BackColor = Color.Transparent;
            lblMenu.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblMenu.ForeColor = Color.FromArgb(151, 128, 117);
            lblMenu.Location = new Point(23, 91);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(35, 12);
            lblMenu.TabIndex = 3;
            lblMenu.Text = "MENU";
            // 
            // lblLogoSub
            // 
            lblLogoSub.AutoSize = true;
            lblLogoSub.BackColor = Color.Transparent;
            lblLogoSub.Font = new Font("Segoe UI", 7.5F);
            lblLogoSub.ForeColor = Color.FromArgb(181, 159, 149);
            lblLogoSub.Location = new Point(69, 43);
            lblLogoSub.Name = "lblLogoSub";
            lblLogoSub.Size = new Size(82, 12);
            lblLogoSub.TabIndex = 2;
            lblLogoSub.Text = "ADMINISTRAÇÃO";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Georgia", 13F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(68, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(143, 21);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "DoceCantinho";
            // 
            // lblLogoIcon
            // 
            lblLogoIcon.AutoSize = true;
            lblLogoIcon.BackColor = Color.Transparent;
            lblLogoIcon.Font = new Font("Segoe UI Emoji", 17F);
            lblLogoIcon.ForeColor = Color.White;
            lblLogoIcon.Location = new Point(177, 43);
            lblLogoIcon.Name = "lblLogoIcon";
            lblLogoIcon.Size = new Size(34, 31);
            lblLogoIcon.TabIndex = 0;
            lblLogoIcon.Text = "✿";
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 14;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ShadowForm1
            // 
            guna2ShadowForm1.TargetForm = this;
            // 
            // pnlLogoIcon
            // 
            pnlLogoIcon.Image = Desktop1.Properties.Resources.doce;
            pnlLogoIcon.Location = new Point(14, 12);
            pnlLogoIcon.Name = "pnlLogoIcon";
            pnlLogoIcon.Size = new Size(54, 47);
            pnlLogoIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pnlLogoIcon.TabIndex = 0;
            pnlLogoIcon.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 245, 242);
            ClientSize = new Size(1300, 720);
            Controls.Add(pnlPanel);
            Controls.Add(guna2Panel1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1100, 650);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doce Cantinho";
            Load += MainForm_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            pnlUsuario.ResumeLayout(false);
            pnlUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlLogoIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPanel;

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;

        private Label lblLogo;
        private Label lblLogoSub;

        private Label lblMenu;

        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnDoce;
        private Guna.UI2.WinForms.Guna2Button btnCategoria;
        private Guna.UI2.WinForms.Guna2Button btnPedidos;
        private Guna.UI2.WinForms.Guna2Button btnUsuario;

        private Guna.UI2.WinForms.Guna2Panel pnlUsuario;

        private Guna.UI2.WinForms.Guna2CircleButton lblAvatar;
        private Label lblUsuario;
        private Label lblPerfil;
        private Label lblSessao;

        private Label lblSeparador;

        private Guna.UI2.WinForms.Guna2Button lblSair;

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Label lblLogoIcon;
        private PictureBox pnlLogoIcon;
    }
}