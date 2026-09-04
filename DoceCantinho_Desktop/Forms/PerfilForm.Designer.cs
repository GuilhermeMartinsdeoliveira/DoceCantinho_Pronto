using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    partial class PerfilForm
    {
        private System.ComponentModel.IContainer components = null;

        // ============================================================
        // CONTROLES PRINCIPAIS
        // ============================================================

        private Panel pnlPrincipal;
        private Panel pnlCabecalho;

        private Label lblTitulo;
        private Label lblSubtitulo;

        // ============================================================
        // CARD PERFIL
        // ============================================================

        private Panel pnlPerfil;

        private Label lblAvatar;
        private PictureBox pictureFoto;

        private Button btnAlterarFoto;

        private Label lblNomeUsuario;
        private Label lblEmail;
        private Label lblPerfil;

        // ============================================================
        // CARD INFORMAÇÕES
        // ============================================================

        private Panel pnlInformacoes;

        private Label lblTituloInformacoes;

        private Label lblNome;
        private Label lblEmailCampo;
        private Label lblPerfilCampo;

        private TextBox txtNome;
        private TextBox txtEmail;

        // ============================================================
        // CARD SEGURANÇA
        // ============================================================

        private Panel pnlSeguranca;

        private Label lblTituloSeguranca;

        private Label lblSenhaAtual;
        private Label lblNovaSenha;
        private Label lblConfirmarSenha;

        private TextBox txtSenhaAtual;
        private TextBox txtNovaSenha;
        private TextBox txtConfirmarSenha;

        private CheckBox chkMostrarSenha;

        // ============================================================
        // BOTÕES
        // ============================================================

        private Button btnSalvar;
        private Button btnCancelar;

        // ============================================================
        // DISPOSE
        // ============================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            btnCancelar = new Button();
            btnSalvar = new Button();
            pnlSeguranca = new Panel();
            lblTituloSeguranca = new Label();
            lblSenhaAtual = new Label();
            txtSenhaAtual = new TextBox();
            lblNovaSenha = new Label();
            txtNovaSenha = new TextBox();
            lblConfirmarSenha = new Label();
            txtConfirmarSenha = new TextBox();
            chkMostrarSenha = new CheckBox();
            pnlInformacoes = new Panel();
            lblTituloInformacoes = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            lblEmailCampo = new Label();
            txtEmail = new TextBox();
            lblPerfilCampo = new Label();
            lblPerfilValor = new Label();
            lblAvisoPerfil = new Label();
            pnlPerfil = new Panel();
            lblAvatar = new Label();
            pictureFoto = new PictureBox();
            btnAlterarFoto = new Button();
            lblNomeUsuario = new Label();
            lblEmail = new Label();
            lblPerfil = new Label();
            pnlCabecalho = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlPrincipal.SuspendLayout();
            pnlSeguranca.SuspendLayout();
            pnlInformacoes.SuspendLayout();
            pnlPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFoto).BeginInit();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.FromArgb(248, 245, 242);
            pnlPrincipal.Controls.Add(btnCancelar);
            pnlPrincipal.Controls.Add(btnSalvar);
            pnlPrincipal.Controls.Add(pnlSeguranca);
            pnlPrincipal.Controls.Add(pnlInformacoes);
            pnlPrincipal.Controls.Add(pnlPerfil);
            pnlPrincipal.Controls.Add(pnlCabecalho);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Padding = new Padding(28, 22, 28, 20);
            pnlPrincipal.Size = new Size(760, 680);
            pnlPrincipal.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(244, 240, 237);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(100, 80, 70);
            btnCancelar.Location = new Point(502, 625);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 34);
            btnCancelar.TabIndex = 0;
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
            btnSalvar.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(610, 625);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(122, 34);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar alterações";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // pnlSeguranca
            // 
            pnlSeguranca.BackColor = Color.White;
            pnlSeguranca.BorderStyle = BorderStyle.FixedSingle;
            pnlSeguranca.Controls.Add(lblTituloSeguranca);
            pnlSeguranca.Controls.Add(lblSenhaAtual);
            pnlSeguranca.Controls.Add(txtSenhaAtual);
            pnlSeguranca.Controls.Add(lblNovaSenha);
            pnlSeguranca.Controls.Add(txtNovaSenha);
            pnlSeguranca.Controls.Add(lblConfirmarSenha);
            pnlSeguranca.Controls.Add(txtConfirmarSenha);
            pnlSeguranca.Controls.Add(chkMostrarSenha);
            pnlSeguranca.Location = new Point(28, 459);
            pnlSeguranca.Name = "pnlSeguranca";
            pnlSeguranca.Size = new Size(704, 150);
            pnlSeguranca.TabIndex = 2;
            // 
            // lblTituloSeguranca
            // 
            lblTituloSeguranca.AutoSize = true;
            lblTituloSeguranca.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lblTituloSeguranca.ForeColor = Color.FromArgb(55, 37, 31);
            lblTituloSeguranca.Location = new Point(22, 16);
            lblTituloSeguranca.Name = "lblTituloSeguranca";
            lblTituloSeguranca.Size = new Size(95, 18);
            lblTituloSeguranca.TabIndex = 0;
            lblTituloSeguranca.Text = "Segurança";
            // 
            // lblSenhaAtual
            // 
            lblSenhaAtual.AutoSize = true;
            lblSenhaAtual.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblSenhaAtual.ForeColor = Color.FromArgb(90, 70, 60);
            lblSenhaAtual.Location = new Point(22, 50);
            lblSenhaAtual.Name = "lblSenhaAtual";
            lblSenhaAtual.Size = new Size(65, 13);
            lblSenhaAtual.TabIndex = 1;
            lblSenhaAtual.Text = "Senha atual";
            // 
            // txtSenhaAtual
            // 
            txtSenhaAtual.BackColor = Color.FromArgb(250, 248, 246);
            txtSenhaAtual.BorderStyle = BorderStyle.FixedSingle;
            txtSenhaAtual.Font = new Font("Segoe UI", 9F);
            txtSenhaAtual.Location = new Point(22, 70);
            txtSenhaAtual.Name = "txtSenhaAtual";
            txtSenhaAtual.Size = new Size(205, 23);
            txtSenhaAtual.TabIndex = 0;
            txtSenhaAtual.UseSystemPasswordChar = true;
            // 
            // lblNovaSenha
            // 
            lblNovaSenha.AutoSize = true;
            lblNovaSenha.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblNovaSenha.ForeColor = Color.FromArgb(90, 70, 60);
            lblNovaSenha.Location = new Point(245, 50);
            lblNovaSenha.Name = "lblNovaSenha";
            lblNovaSenha.Size = new Size(66, 13);
            lblNovaSenha.TabIndex = 2;
            lblNovaSenha.Text = "Nova senha";
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.BackColor = Color.FromArgb(250, 248, 246);
            txtNovaSenha.BorderStyle = BorderStyle.FixedSingle;
            txtNovaSenha.Font = new Font("Segoe UI", 9F);
            txtNovaSenha.Location = new Point(245, 70);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(205, 23);
            txtNovaSenha.TabIndex = 1;
            txtNovaSenha.UseSystemPasswordChar = true;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblConfirmarSenha.ForeColor = Color.FromArgb(90, 70, 60);
            lblConfirmarSenha.Location = new Point(468, 50);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(118, 13);
            lblConfirmarSenha.TabIndex = 3;
            lblConfirmarSenha.Text = "Confirmar nova senha";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.BackColor = Color.FromArgb(250, 248, 246);
            txtConfirmarSenha.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmarSenha.Font = new Font("Segoe UI", 9F);
            txtConfirmarSenha.Location = new Point(468, 70);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(212, 23);
            txtConfirmarSenha.TabIndex = 2;
            txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // chkMostrarSenha
            // 
            chkMostrarSenha.AutoSize = true;
            chkMostrarSenha.Font = new Font("Segoe UI", 8F);
            chkMostrarSenha.ForeColor = Color.FromArgb(110, 90, 80);
            chkMostrarSenha.Location = new Point(22, 108);
            chkMostrarSenha.Name = "chkMostrarSenha";
            chkMostrarSenha.Size = new Size(105, 17);
            chkMostrarSenha.TabIndex = 3;
            chkMostrarSenha.Text = "Mostrar senhas";
            chkMostrarSenha.UseVisualStyleBackColor = true;
            chkMostrarSenha.CheckedChanged += chkMostrarSenha_CheckedChanged;
            // 
            // pnlInformacoes
            // 
            pnlInformacoes.BackColor = Color.White;
            pnlInformacoes.BorderStyle = BorderStyle.FixedSingle;
            pnlInformacoes.Controls.Add(lblTituloInformacoes);
            pnlInformacoes.Controls.Add(lblNome);
            pnlInformacoes.Controls.Add(txtNome);
            pnlInformacoes.Controls.Add(lblEmailCampo);
            pnlInformacoes.Controls.Add(txtEmail);
            pnlInformacoes.Controls.Add(lblPerfilCampo);
            pnlInformacoes.Controls.Add(lblPerfilValor);
            pnlInformacoes.Controls.Add(lblAvisoPerfil);
            pnlInformacoes.Location = new Point(28, 266);
            pnlInformacoes.Name = "pnlInformacoes";
            pnlInformacoes.Size = new Size(704, 175);
            pnlInformacoes.TabIndex = 3;
            // 
            // lblTituloInformacoes
            // 
            lblTituloInformacoes.AutoSize = true;
            lblTituloInformacoes.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lblTituloInformacoes.ForeColor = Color.FromArgb(55, 37, 31);
            lblTituloInformacoes.Location = new Point(22, 17);
            lblTituloInformacoes.Name = "lblTituloInformacoes";
            lblTituloInformacoes.Size = new Size(189, 18);
            lblTituloInformacoes.TabIndex = 0;
            lblTituloInformacoes.Text = "Informações da conta";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblNome.ForeColor = Color.FromArgb(90, 70, 60);
            lblNome.Location = new Point(22, 55);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(100, 13);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome de exibição";
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.FromArgb(250, 248, 246);
            txtNome.BorderStyle = BorderStyle.FixedSingle;
            txtNome.Font = new Font("Segoe UI", 9F);
            txtNome.ForeColor = Color.FromArgb(65, 50, 43);
            txtNome.Location = new Point(22, 75);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(315, 23);
            txtNome.TabIndex = 0;
            // 
            // lblEmailCampo
            // 
            lblEmailCampo.AutoSize = true;
            lblEmailCampo.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblEmailCampo.ForeColor = Color.FromArgb(90, 70, 60);
            lblEmailCampo.Location = new Point(355, 55);
            lblEmailCampo.Name = "lblEmailCampo";
            lblEmailCampo.Size = new Size(39, 13);
            lblEmailCampo.TabIndex = 2;
            lblEmailCampo.Text = "E-mail";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(250, 248, 246);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.FromArgb(65, 50, 43);
            txtEmail.Location = new Point(355, 75);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(325, 23);
            txtEmail.TabIndex = 1;
            // 
            // lblPerfilCampo
            // 
            lblPerfilCampo.AutoSize = true;
            lblPerfilCampo.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblPerfilCampo.ForeColor = Color.FromArgb(90, 70, 60);
            lblPerfilCampo.Location = new Point(22, 115);
            lblPerfilCampo.Name = "lblPerfilCampo";
            lblPerfilCampo.Size = new Size(86, 13);
            lblPerfilCampo.TabIndex = 3;
            lblPerfilCampo.Text = "Perfil de acesso";
            // 
            // lblPerfilValor
            // 
            lblPerfilValor.BackColor = Color.FromArgb(250, 248, 246);
            lblPerfilValor.BorderStyle = BorderStyle.FixedSingle;
            lblPerfilValor.Font = new Font("Segoe UI", 9F);
            lblPerfilValor.ForeColor = Color.FromArgb(120, 100, 90);
            lblPerfilValor.Location = new Point(22, 135);
            lblPerfilValor.Name = "lblPerfilValor";
            lblPerfilValor.Size = new Size(315, 27);
            lblPerfilValor.TabIndex = 4;
            lblPerfilValor.Text = "Definido pelo administrador";
            lblPerfilValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAvisoPerfil
            // 
            lblAvisoPerfil.Font = new Font("Segoe UI", 7.5F);
            lblAvisoPerfil.ForeColor = Color.FromArgb(145, 125, 115);
            lblAvisoPerfil.Location = new Point(355, 115);
            lblAvisoPerfil.Name = "lblAvisoPerfil";
            lblAvisoPerfil.Size = new Size(325, 42);
            lblAvisoPerfil.TabIndex = 5;
            lblAvisoPerfil.Text = "O perfil de acesso é definido pelo administrador do sistema e não pode ser alterado aqui.";
            // 
            // pnlPerfil
            // 
            pnlPerfil.BackColor = Color.White;
            pnlPerfil.BorderStyle = BorderStyle.FixedSingle;
            pnlPerfil.Controls.Add(lblAvatar);
            pnlPerfil.Controls.Add(pictureFoto);
            pnlPerfil.Controls.Add(btnAlterarFoto);
            pnlPerfil.Controls.Add(lblNomeUsuario);
            pnlPerfil.Controls.Add(lblEmail);
            pnlPerfil.Controls.Add(lblPerfil);
            pnlPerfil.Location = new Point(28, 98);
            pnlPerfil.Name = "pnlPerfil";
            pnlPerfil.Size = new Size(704, 150);
            pnlPerfil.TabIndex = 4;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(207, 132, 106);
            lblAvatar.Font = new Font("Georgia", 24F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(25, 10);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(100, 100);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "JS";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureFoto
            // 
            pictureFoto.BackColor = Color.FromArgb(247, 242, 239);
            pictureFoto.BorderStyle = BorderStyle.FixedSingle;
            pictureFoto.Location = new Point(25, 10);
            pictureFoto.Name = "pictureFoto";
            pictureFoto.Size = new Size(100, 100);
            pictureFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureFoto.TabIndex = 1;
            pictureFoto.TabStop = false;
            pictureFoto.Visible = false;
            // 
            // btnAlterarFoto
            // 
            btnAlterarFoto.BackColor = Color.FromArgb(247, 244, 242);
            btnAlterarFoto.Cursor = Cursors.Hand;
            btnAlterarFoto.FlatAppearance.BorderColor = Color.FromArgb(229, 220, 215);
            btnAlterarFoto.FlatStyle = FlatStyle.Flat;
            btnAlterarFoto.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnAlterarFoto.ForeColor = Color.FromArgb(105, 80, 70);
            btnAlterarFoto.Location = new Point(20, 116);
            btnAlterarFoto.Name = "btnAlterarFoto";
            btnAlterarFoto.Size = new Size(110, 24);
            btnAlterarFoto.TabIndex = 0;
            btnAlterarFoto.Text = "Alterar foto";
            btnAlterarFoto.UseVisualStyleBackColor = false;
            btnAlterarFoto.Click += btnAlterarFoto_Click;
            // 
            // lblNomeUsuario
            // 
            lblNomeUsuario.AutoSize = true;
            lblNomeUsuario.Font = new Font("Georgia", 14F, FontStyle.Bold);
            lblNomeUsuario.ForeColor = Color.FromArgb(55, 37, 31);
            lblNomeUsuario.Location = new Point(155, 32);
            lblNomeUsuario.Name = "lblNomeUsuario";
            lblNomeUsuario.Size = new Size(136, 23);
            lblNomeUsuario.TabIndex = 2;
            lblNomeUsuario.Text = "José da Silva";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 8.5F);
            lblEmail.ForeColor = Color.FromArgb(130, 108, 98);
            lblEmail.Location = new Point(156, 61);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(113, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "usuario@email.com";
            // 
            // lblPerfil
            // 
            lblPerfil.BackColor = Color.FromArgb(250, 242, 238);
            lblPerfil.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblPerfil.ForeColor = Color.FromArgb(198, 124, 99);
            lblPerfil.Location = new Point(155, 87);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(130, 25);
            lblPerfil.TabIndex = 4;
            lblPerfil.Text = "Administrador";
            lblPerfil.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.BackColor = Color.Transparent;
            pnlCabecalho.Controls.Add(lblSubtitulo);
            pnlCabecalho.Controls.Add(lblTitulo);
            pnlCabecalho.Location = new Point(28, 22);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(704, 62);
            pnlCabecalho.TabIndex = 5;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(130, 108, 98);
            lblSubtitulo.Location = new Point(2, 37);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(242, 15);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Gerencie suas informações pessoais e acesso";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Georgia", 21F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(55, 37, 31);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(167, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Meu Perfil";
            // 
            // PerfilForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 245, 242);
            ClientSize = new Size(760, 680);
            Controls.Add(pnlPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerfilForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Meu Perfil";
            pnlPrincipal.ResumeLayout(false);
            pnlSeguranca.ResumeLayout(false);
            pnlSeguranca.PerformLayout();
            pnlInformacoes.ResumeLayout(false);
            pnlInformacoes.PerformLayout();
            pnlPerfil.ResumeLayout(false);
            pnlPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFoto).EndInit();
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblPerfilValor;
        private Label lblAvisoPerfil;
    }
}