namespace DoceCantinho.Desktop1.Forms
{
    partial class UsuarioFormDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;

        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone;

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;

        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.TextBox txtConfirmar;

        private System.Windows.Forms.Label lblEnderecoTitulo;

        private System.Windows.Forms.Label lblLogradouro;
        private System.Windows.Forms.TextBox txtLogradouro;

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;

        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.TextBox txtComplemento;

        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtBairro;

        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtCidade;

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;

        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.TextBox txtCep;

        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox cmbPerfil;

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;

        private Guna.UI2.WinForms.Guna2Button btnFechar;
        private Guna.UI2.WinForms.Guna2Button btnMostrarSenha;
        private Guna.UI2.WinForms.Guna2Button btnMostrarConfirSenha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            lblEnderecoTitulo = new Label();
            lblLogradouro = new Label();
            txtLogradouro = new TextBox();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblComplemento = new Label();
            txtComplemento = new TextBox();
            lblBairro = new Label();
            txtBairro = new TextBox();
            lblCidade = new Label();
            txtCidade = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblCep = new Label();
            txtCep = new TextBox();
            lblPerfil = new Label();
            cmbPerfil = new ComboBox();
            btnCancelar = new Button();
            btnSalvar = new Button();
            btnFechar = new Guna.UI2.WinForms.Guna2Button();
            btnMostrarSenha = new Guna.UI2.WinForms.Guna2Button();
            btnMostrarConfirSenha = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(43, 29, 26);
            lblTitulo.Location = new Point(51, 33);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(236, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Novo usuário";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(120, 105, 100);
            lblSubtitulo.Location = new Point(54, 91);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(391, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Cadastre os dados de acesso e informações do usuário.";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(70, 55, 50);
            lblNome.Location = new Point(54, 140);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(54, 20);
            lblNome.TabIndex = 2;
            lblNome.Text = "NOME";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.White;
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.ForeColor = Color.FromArgb(50, 40, 37);
            txtNome.Location = new Point(51, 171);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(491, 30);
            txtNome.TabIndex = 3;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTelefone.ForeColor = Color.FromArgb(70, 55, 50);
            lblTelefone.Location = new Point(566, 140);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(79, 20);
            lblTelefone.TabIndex = 4;
            lblTelefone.Text = "TELEFONE";
            // 
            // txtTelefone
            // 
            txtTelefone.BackColor = Color.White;
            txtTelefone.BorderStyle = BorderStyle.FixedSingle;
            txtTelefone.Font = new Font("Segoe UI", 10F);
            txtTelefone.ForeColor = Color.FromArgb(50, 40, 37);
            txtTelefone.Location = new Point(563, 171);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(251, 30);
            txtTelefone.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(70, 55, 50);
            lblEmail.Location = new Point(54, 237);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "E-MAIL";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(50, 40, 37);
            txtEmail.Location = new Point(51, 268);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(491, 30);
            txtEmail.TabIndex = 7;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSenha.ForeColor = Color.FromArgb(70, 55, 50);
            lblSenha.Location = new Point(54, 335);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(58, 20);
            lblSenha.TabIndex = 8;
            lblSenha.Text = "SENHA";
            // 
            // txtSenha
            // 
            txtSenha.BackColor = Color.White;
            txtSenha.BorderStyle = BorderStyle.FixedSingle;
            txtSenha.Font = new Font("Segoe UI", 10F);
            txtSenha.ForeColor = Color.FromArgb(50, 40, 37);
            txtSenha.Location = new Point(51, 365);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(360, 30);
            txtSenha.TabIndex = 9;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblConfirmar.ForeColor = Color.FromArgb(70, 55, 50);
            lblConfirmar.Location = new Point(442, 335);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(148, 20);
            lblConfirmar.TabIndex = 10;
            lblConfirmar.Text = "CONFIRMAR SENHA";
            // 
            // txtConfirmar
            // 
            txtConfirmar.BackColor = Color.White;
            txtConfirmar.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmar.Font = new Font("Segoe UI", 10F);
            txtConfirmar.ForeColor = Color.FromArgb(50, 40, 37);
            txtConfirmar.Location = new Point(440, 365);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(335, 30);
            txtConfirmar.TabIndex = 11;
            txtConfirmar.UseSystemPasswordChar = true;
            // 
            // lblEnderecoTitulo
            // 
            lblEnderecoTitulo.AutoSize = true;
            lblEnderecoTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEnderecoTitulo.ForeColor = Color.FromArgb(201, 130, 107);
            lblEnderecoTitulo.Location = new Point(51, 435);
            lblEnderecoTitulo.Name = "lblEnderecoTitulo";
            lblEnderecoTitulo.Size = new Size(109, 25);
            lblEnderecoTitulo.TabIndex = 12;
            lblEnderecoTitulo.Text = "ENDEREÇO";
            // 
            // lblLogradouro
            // 
            lblLogradouro.AutoSize = true;
            lblLogradouro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLogradouro.ForeColor = Color.FromArgb(70, 55, 50);
            lblLogradouro.Location = new Point(304, 472);
            lblLogradouro.Name = "lblLogradouro";
            lblLogradouro.Size = new Size(109, 20);
            lblLogradouro.TabIndex = 13;
            lblLogradouro.Text = "LOGRADOURO";
            // 
            // txtLogradouro
            // 
            txtLogradouro.BackColor = Color.White;
            txtLogradouro.BorderStyle = BorderStyle.FixedSingle;
            txtLogradouro.Font = new Font("Segoe UI", 10F);
            txtLogradouro.Location = new Point(304, 507);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.Size = new Size(511, 30);
            txtLogradouro.TabIndex = 14;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNumero.ForeColor = Color.FromArgb(70, 55, 50);
            lblNumero.Location = new Point(605, 667);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(74, 20);
            lblNumero.TabIndex = 15;
            lblNumero.Text = "NÚMERO";
            // 
            // txtNumero
            // 
            txtNumero.BackColor = Color.White;
            txtNumero.BorderStyle = BorderStyle.FixedSingle;
            txtNumero.Font = new Font("Segoe UI", 10F);
            txtNumero.Location = new Point(605, 697);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(194, 30);
            txtNumero.TabIndex = 16;
            // 
            // lblComplemento
            // 
            lblComplemento.AutoSize = true;
            lblComplemento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblComplemento.ForeColor = Color.FromArgb(70, 55, 50);
            lblComplemento.Location = new Point(54, 571);
            lblComplemento.Name = "lblComplemento";
            lblComplemento.Size = new Size(119, 20);
            lblComplemento.TabIndex = 17;
            lblComplemento.Text = "COMPLEMENTO";
            // 
            // txtComplemento
            // 
            txtComplemento.BackColor = Color.White;
            txtComplemento.BorderStyle = BorderStyle.FixedSingle;
            txtComplemento.Font = new Font("Segoe UI", 10F);
            txtComplemento.Location = new Point(51, 601);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(360, 30);
            txtComplemento.TabIndex = 18;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBairro.ForeColor = Color.FromArgb(70, 55, 50);
            lblBairro.Location = new Point(442, 571);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(61, 20);
            lblBairro.TabIndex = 19;
            lblBairro.Text = "BAIRRO";
            // 
            // txtBairro
            // 
            txtBairro.BackColor = Color.White;
            txtBairro.BorderStyle = BorderStyle.FixedSingle;
            txtBairro.Font = new Font("Segoe UI", 10F);
            txtBairro.Location = new Point(440, 601);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(375, 30);
            txtBairro.TabIndex = 20;
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCidade.ForeColor = Color.FromArgb(70, 55, 50);
            lblCidade.Location = new Point(54, 667);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(62, 20);
            lblCidade.TabIndex = 21;
            lblCidade.Text = "CIDADE";
            // 
            // txtCidade
            // 
            txtCidade.BackColor = Color.White;
            txtCidade.BorderStyle = BorderStyle.FixedSingle;
            txtCidade.Font = new Font("Segoe UI", 10F);
            txtCidade.Location = new Point(51, 697);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(360, 30);
            txtCidade.TabIndex = 22;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(70, 55, 50);
            lblEstado.Location = new Point(442, 667);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(64, 20);
            lblEstado.TabIndex = 23;
            lblEstado.Text = "ESTADO";
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = Color.White;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 10F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" });
            cmbEstado.Location = new Point(440, 696);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(114, 31);
            cmbEstado.TabIndex = 24;
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCep.ForeColor = Color.FromArgb(70, 55, 50);
            lblCep.Location = new Point(54, 472);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(35, 20);
            lblCep.TabIndex = 25;
            lblCep.Text = "CEP";
            // 
            // txtCep
            // 
            txtCep.BackColor = Color.White;
            txtCep.BorderStyle = BorderStyle.FixedSingle;
            txtCep.Font = new Font("Segoe UI", 10F);
            txtCep.Location = new Point(51, 507);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(240, 30);
            txtCep.TabIndex = 26;
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPerfil.ForeColor = Color.FromArgb(70, 55, 50);
            lblPerfil.Location = new Point(566, 237);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(54, 20);
            lblPerfil.TabIndex = 27;
            lblPerfil.Text = "PERFIL";
            // 
            // cmbPerfil
            // 
            cmbPerfil.BackColor = Color.White;
            cmbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerfil.Font = new Font("Segoe UI", 10F);
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Location = new Point(563, 267);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(251, 31);
            cmbPerfil.TabIndex = 28;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(235, 229, 225);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 65, 60);
            btnCancelar.Location = new Point(491, 819);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(154, 60);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(201, 130, 107);
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(657, 819);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(158, 60);
            btnSalvar.TabIndex = 30;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnFechar
            // 
            btnFechar.CustomizableEdges = customizableEdges1;
            btnFechar.DisabledState.BorderColor = Color.DarkGray;
            btnFechar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFechar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFechar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFechar.FillColor = Color.FromArgb(201, 130, 107);
            btnFechar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(795, 21);
            btnFechar.Name = "btnFechar";
            btnFechar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnFechar.Size = new Size(43, 43);
            btnFechar.TabIndex = 31;
            btnFechar.Text = "X";
            btnFechar.Click += btnFechar_Click;
            // 
            // btnMostrarSenha
            // 
            btnMostrarSenha.BackColor = Color.White;
            btnMostrarSenha.CustomizableEdges = customizableEdges3;
            btnMostrarSenha.FillColor = Color.White;
            btnMostrarSenha.Font = new Font("Segoe UI Emoji", 10F);
            btnMostrarSenha.ForeColor = Color.FromArgb(92, 46, 14);
            btnMostrarSenha.HoverState.FillColor = Color.FromArgb(250, 244, 239);
            btnMostrarSenha.Location = new Point(370, 323);
            btnMostrarSenha.Name = "btnMostrarSenha";
            btnMostrarSenha.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMostrarSenha.Size = new Size(41, 36);
            btnMostrarSenha.TabIndex = 32;
            btnMostrarSenha.Text = "👁";
            // 
            // btnMostrarConfirSenha
            // 
            btnMostrarConfirSenha.BackColor = Color.White;
            btnMostrarConfirSenha.CustomizableEdges = customizableEdges5;
            btnMostrarConfirSenha.FillColor = Color.White;
            btnMostrarConfirSenha.Font = new Font("Segoe UI Emoji", 10F);
            btnMostrarConfirSenha.ForeColor = Color.FromArgb(92, 46, 14);
            btnMostrarConfirSenha.HoverState.FillColor = Color.FromArgb(250, 244, 239);
            btnMostrarConfirSenha.Location = new Point(733, 319);
            btnMostrarConfirSenha.Name = "btnMostrarConfirSenha";
            btnMostrarConfirSenha.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnMostrarConfirSenha.Size = new Size(42, 36);
            btnMostrarConfirSenha.TabIndex = 33;
            btnMostrarConfirSenha.Text = "👁";
            // 
            // UsuarioFormDialog
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 245, 242);
            CancelButton = btnCancelar;
            ClientSize = new Size(869, 907);
            Controls.Add(btnMostrarConfirSenha);
            Controls.Add(btnMostrarSenha);
            Controls.Add(btnFechar);
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblSenha);
            Controls.Add(txtSenha);
            Controls.Add(lblConfirmar);
            Controls.Add(txtConfirmar);
            Controls.Add(lblEnderecoTitulo);
            Controls.Add(lblCep);
            Controls.Add(txtCep);
            Controls.Add(lblLogradouro);
            Controls.Add(txtLogradouro);
            Controls.Add(lblComplemento);
            Controls.Add(txtComplemento);
            Controls.Add(lblBairro);
            Controls.Add(txtBairro);
            Controls.Add(lblCidade);
            Controls.Add(txtCidade);
            Controls.Add(lblEstado);
            Controls.Add(cmbEstado);
            Controls.Add(lblNumero);
            Controls.Add(txtNumero);
            Controls.Add(lblPerfil);
            Controls.Add(cmbPerfil);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsuarioFormDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuário";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}