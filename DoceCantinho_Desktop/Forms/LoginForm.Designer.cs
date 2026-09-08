namespace DoceCantinho.Desktop.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            pnlEsquerdo = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblMarca = new Label();
            lblMensagemEsquerda = new Label();
            lblDescricaoEsquerda = new Label();
            lblDecoracao1 = new Label();
            lblDecoracao2 = new Label();
            lblDecoracao3 = new Label();
            pnlDireito = new Panel();
            lblTitulo = new Label();
            lblSubTitulo = new Label();
            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblSenha = new Label();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            lblAutenticando = new Label();
            panel1 = new Panel();
            lblAdm = new Label();
            lblApi = new Label();
            lblErro = new Label();
            lblVersao = new Label();
            pnlEsquerdo.SuspendLayout();
            pnlDireito.SuspendLayout();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlEsquerdo
            // 
            pnlEsquerdo.Controls.Add(lblMarca);
            pnlEsquerdo.Controls.Add(lblMensagemEsquerda);
            pnlEsquerdo.Controls.Add(lblDescricaoEsquerda);
            pnlEsquerdo.Controls.Add(lblDecoracao1);
            pnlEsquerdo.Controls.Add(lblDecoracao2);
            pnlEsquerdo.Controls.Add(lblDecoracao3);
            pnlEsquerdo.CustomizableEdges = customizableEdges9;
            pnlEsquerdo.Dock = DockStyle.Left;
            pnlEsquerdo.FillColor = Color.FromArgb(43, 29, 26);
            pnlEsquerdo.FillColor2 = Color.FromArgb(201, 130, 107);
            pnlEsquerdo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            pnlEsquerdo.Location = new Point(0, 0);
            pnlEsquerdo.Name = "pnlEsquerdo";
            pnlEsquerdo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlEsquerdo.Size = new Size(390, 560);
            pnlEsquerdo.TabIndex = 0;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.BackColor = Color.Transparent;
            lblMarca.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(35, 35);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(165, 25);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "🍰 DoceCantinho";
            // 
            // lblMensagemEsquerda
            // 
            lblMensagemEsquerda.BackColor = Color.Transparent;
            lblMensagemEsquerda.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblMensagemEsquerda.ForeColor = Color.White;
            lblMensagemEsquerda.Location = new Point(35, 145);
            lblMensagemEsquerda.Name = "lblMensagemEsquerda";
            lblMensagemEsquerda.Size = new Size(315, 163);
            lblMensagemEsquerda.TabIndex = 1;
            lblMensagemEsquerda.Text = "Faça login\r\nno seu cantinho\r\ndoce.";
            // 
            // lblDescricaoEsquerda
            // 
            lblDescricaoEsquerda.BackColor = Color.Transparent;
            lblDescricaoEsquerda.Font = new Font("Segoe UI", 10F);
            lblDescricaoEsquerda.ForeColor = Color.White;
            lblDescricaoEsquerda.Location = new Point(45, 308);
            lblDescricaoEsquerda.Name = "lblDescricaoEsquerda";
            lblDescricaoEsquerda.Size = new Size(305, 60);
            lblDescricaoEsquerda.TabIndex = 2;
            lblDescricaoEsquerda.Text = "Gerencie seus produtos,\r\ncategorias e pedidos de forma simples.";
            // 
            // lblDecoracao1
            // 
            lblDecoracao1.AutoSize = true;
            lblDecoracao1.BackColor = Color.Transparent;
            lblDecoracao1.Font = new Font("Segoe UI", 8F);
            lblDecoracao1.ForeColor = Color.White;
            lblDecoracao1.Location = new Point(38, 500);
            lblDecoracao1.Name = "lblDecoracao1";
            lblDecoracao1.Size = new Size(64, 13);
            lblDecoracao1.TabIndex = 3;
            lblDecoracao1.Text = "Confeitaria";
            // 
            // lblDecoracao2
            // 
            lblDecoracao2.AutoSize = true;
            lblDecoracao2.BackColor = Color.Transparent;
            lblDecoracao2.Font = new Font("Segoe UI", 8F);
            lblDecoracao2.ForeColor = Color.White;
            lblDecoracao2.Location = new Point(150, 500);
            lblDecoracao2.Name = "lblDecoracao2";
            lblDecoracao2.Size = new Size(54, 13);
            lblDecoracao2.TabIndex = 4;
            lblDecoracao2.Text = "Produtos";
            // 
            // lblDecoracao3
            // 
            lblDecoracao3.AutoSize = true;
            lblDecoracao3.BackColor = Color.Transparent;
            lblDecoracao3.Font = new Font("Segoe UI", 8F);
            lblDecoracao3.ForeColor = Color.White;
            lblDecoracao3.Location = new Point(265, 500);
            lblDecoracao3.Name = "lblDecoracao3";
            lblDecoracao3.Size = new Size(48, 13);
            lblDecoracao3.TabIndex = 5;
            lblDecoracao3.Text = "Pedidos";
            // 
            // pnlDireito
            // 
            pnlDireito.BackColor = Color.White;
            pnlDireito.Controls.Add(lblTitulo);
            pnlDireito.Controls.Add(lblSubTitulo);
            pnlDireito.Controls.Add(lblEmail);
            pnlDireito.Controls.Add(txtEmail);
            pnlDireito.Controls.Add(lblSenha);
            pnlDireito.Controls.Add(txtSenha);
            pnlDireito.Controls.Add(btnEntrar);
            pnlDireito.Controls.Add(btnCancelar);
            pnlDireito.Controls.Add(lblAutenticando);
            pnlDireito.Controls.Add(panel1);
            pnlDireito.Controls.Add(lblAdm);
            pnlDireito.Controls.Add(lblApi);
            pnlDireito.Controls.Add(lblErro);
            pnlDireito.Controls.Add(lblVersao);
            pnlDireito.Dock = DockStyle.Fill;
            pnlDireito.Location = new Point(390, 0);
            pnlDireito.Name = "pnlDireito";
            pnlDireito.Padding = new Padding(65, 65, 65, 40);
            pnlDireito.Size = new Size(510, 560);
            pnlDireito.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(35, 31, 32);
            lblTitulo.Location = new Point(65, 65);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(275, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bem-vindo de volta";
            // 
            // lblSubTitulo
            // 
            lblSubTitulo.Font = new Font("Segoe UI", 9F);
            lblSubTitulo.ForeColor = Color.FromArgb(145, 145, 150);
            lblSubTitulo.Location = new Point(68, 108);
            lblSubTitulo.Name = "lblSubTitulo";
            lblSubTitulo.Size = new Size(370, 38);
            lblSubTitulo.TabIndex = 1;
            lblSubTitulo.Text = "Entre com seus dados para acessar\r\no painel do DoceCantinho.";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(55, 52, 54);
            lblEmail.Location = new Point(68, 163);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(225, 225, 230);
            txtEmail.BorderRadius = 8;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(220, 220, 225);
            txtEmail.DisabledState.FillColor = Color.FromArgb(245, 245, 247);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(150, 150, 155);
            txtEmail.FillColor = Color.FromArgb(250, 250, 252);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(74, 56, 210);
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.FromArgb(45, 43, 45);
            txtEmail.HoverState.BorderColor = Color.FromArgb(130, 115, 225);
            txtEmail.Location = new Point(65, 185);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(170, 170, 175);
            txtEmail.PlaceholderText = "Digite seu email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(380, 42);
            txtEmail.TabIndex = 3;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSenha.ForeColor = Color.FromArgb(55, 52, 54);
            lblSenha.Location = new Point(68, 242);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(41, 15);
            lblSenha.TabIndex = 4;
            lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.BorderColor = Color.FromArgb(225, 225, 230);
            txtSenha.BorderRadius = 8;
            txtSenha.CustomizableEdges = customizableEdges3;
            txtSenha.DefaultText = "";
            txtSenha.DisabledState.BorderColor = Color.FromArgb(220, 220, 225);
            txtSenha.DisabledState.FillColor = Color.FromArgb(245, 245, 247);
            txtSenha.DisabledState.ForeColor = Color.FromArgb(150, 150, 155);
            txtSenha.FillColor = Color.FromArgb(250, 250, 252);
            txtSenha.FocusedState.BorderColor = Color.FromArgb(74, 56, 210);
            txtSenha.Font = new Font("Segoe UI", 9.5F);
            txtSenha.ForeColor = Color.FromArgb(45, 43, 45);
            txtSenha.HoverState.BorderColor = Color.FromArgb(130, 115, 225);
            txtSenha.Location = new Point(65, 264);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '●';
            txtSenha.PlaceholderForeColor = Color.FromArgb(170, 170, 175);
            txtSenha.PlaceholderText = "Digite sua senha";
            txtSenha.SelectedText = "";
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSenha.Size = new Size(380, 42);
            txtSenha.TabIndex = 5;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // btnEntrar
            // 
            btnEntrar.BorderRadius = 8;
            btnEntrar.CustomizableEdges = customizableEdges5;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(190, 185, 215);
            btnEntrar.DisabledState.ForeColor = Color.White;
            btnEntrar.FillColor = Color.FromArgb(201, 130, 107);
            btnEntrar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.HoverState.FillColor = Color.FromArgb(82, 67, 220);
            btnEntrar.Location = new Point(65, 326);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEntrar.Size = new Size(380, 42);
            btnEntrar.TabIndex = 6;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BorderRadius = 8;
            btnCancelar.CustomizableEdges = customizableEdges7;
            btnCancelar.DisabledState.BorderColor = Color.DarkGray;
            btnCancelar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancelar.DisabledState.FillColor = Color.FromArgb(235, 235, 238);
            btnCancelar.DisabledState.ForeColor = Color.FromArgb(150, 150, 155);
            btnCancelar.FillColor = Color.FromArgb(244, 244, 247);
            btnCancelar.Font = new Font("Segoe UI", 9F);
            btnCancelar.ForeColor = Color.FromArgb(80, 76, 82);
            btnCancelar.HoverState.FillColor = Color.FromArgb(235, 235, 240);
            btnCancelar.Location = new Point(65, 378);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancelar.Size = new Size(380, 38);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblAutenticando
            // 
            lblAutenticando.AutoSize = true;
            lblAutenticando.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAutenticando.ForeColor = Color.FromArgb(43, 29, 26);
            lblAutenticando.Location = new Point(65, 426);
            lblAutenticando.Name = "lblAutenticando";
            lblAutenticando.Size = new Size(91, 15);
            lblAutenticando.TabIndex = 8;
            lblAutenticando.Text = "Autenticando...";
            lblAutenticando.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(235, 235, 238);
            panel1.Location = new Point(65, 453);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 1);
            panel1.TabIndex = 9;
            // 
            // lblAdm
            // 
            lblAdm.AutoSize = true;
            lblAdm.Font = new Font("Segoe UI", 7.5F);
            lblAdm.ForeColor = Color.FromArgb(145, 145, 150);
            lblAdm.Location = new Point(65, 465);
            lblAdm.Name = "lblAdm";
            lblAdm.Size = new Size(222, 12);
            lblAdm.TabIndex = 10;
            lblAdm.Text = "Problemas para acessar? Contate o administrador.";
            // 
            // lblApi
            // 
            lblApi.AutoSize = true;
            lblApi.Font = new Font("Segoe UI", 7.5F);
            lblApi.ForeColor = Color.FromArgb(160, 160, 165);
            lblApi.Location = new Point(65, 487);
            lblApi.Name = "lblApi";
            lblApi.Size = new Size(31, 12);
            lblApi.TabIndex = 11;
            lblApi.Text = "API: ...";
            // 
            // lblErro
            // 
            lblErro.AutoEllipsis = true;
            lblErro.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblErro.ForeColor = Color.FromArgb(190, 55, 65);
            lblErro.Location = new Point(65, 508);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(380, 30);
            lblErro.TabIndex = 12;
            lblErro.Visible = false;
            // 
            // lblVersao
            // 
            lblVersao.AutoSize = true;
            lblVersao.Font = new Font("Segoe UI", 7.5F);
            lblVersao.ForeColor = Color.FromArgb(175, 175, 180);
            lblVersao.Location = new Point(285, 487);
            lblVersao.Name = "lblVersao";
            lblVersao.Size = new Size(55, 12);
            lblVersao.TabIndex = 13;
            lblVersao.Text = "Versão 1.0.0";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 560);
            Controls.Add(pnlDireito);
            Controls.Add(pnlEsquerdo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoceCantinho";
            Load += LoginForm_Load;
            pnlEsquerdo.ResumeLayout(false);
            pnlEsquerdo.PerformLayout();
            pnlDireito.ResumeLayout(false);
            pnlDireito.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // =============================================================
        // COMPONENTES
        // =============================================================

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

        // Painel esquerdo
        private Guna.UI2.WinForms.Guna2GradientPanel pnlEsquerdo;
        private Label lblMarca;
        private Label lblMensagemEsquerda;
        private Label lblDescricaoEsquerda;
        private Label lblDecoracao1;
        private Label lblDecoracao2;
        private Label lblDecoracao3;

        // Painel direito
        private Panel pnlDireito;

        private Label lblTitulo;
        private Label lblSubTitulo;

        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;

        private Label lblSenha;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;

        private Guna.UI2.WinForms.Guna2Button btnEntrar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;

        private Label lblAutenticando;

        private Panel panel1;

        private Label lblAdm;
        private Label lblApi;
        private Label lblErro;
        private Label lblVersao;
    }
}