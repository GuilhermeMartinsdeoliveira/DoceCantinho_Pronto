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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();

            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();

            this.lblConfirmar = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();

            this.lblEnderecoTitulo = new System.Windows.Forms.Label();

            this.lblLogradouro = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();

            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();

            this.lblComplemento = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();

            this.lblBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();

            this.lblCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();

            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();

            this.lblCep = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();

            this.lblPerfil = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();

            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // =========================================================
            // FORM
            // =========================================================

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor = System.Drawing.Color.FromArgb(248, 245, 242);

            this.ClientSize = new System.Drawing.Size(760, 680);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);

            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtTelefone);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);

            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.txtConfirmar);

            this.Controls.Add(this.lblEnderecoTitulo);

            this.Controls.Add(this.lblLogradouro);
            this.Controls.Add(this.txtLogradouro);

            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtNumero);

            this.Controls.Add(this.lblComplemento);
            this.Controls.Add(this.txtComplemento);

            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.txtBairro);

            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.txtCidade);

            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);

            this.Controls.Add(this.lblCep);
            this.Controls.Add(this.txtCep);

            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.cmbPerfil);

            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioFormDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuário";

            // =========================================================
            // TÍTULO
            // =========================================================

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(43, 29, 26);

            this.lblTitulo.Location =
                new System.Drawing.Point(45, 25);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Novo usuário";

            // =========================================================
            // SUBTÍTULO
            // =========================================================

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font(
                "Segoe UI",
                9.5F);

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(120, 105, 100);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(47, 68);

            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text =
                "Cadastre os dados de acesso e informações do usuário.";

            // =========================================================
            // NOME
            // =========================================================

            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblNome.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblNome.Location =
                new System.Drawing.Point(47, 105);

            this.lblNome.Text = "NOME";

            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtNome.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtNome.ForeColor =
                System.Drawing.Color.FromArgb(50, 40, 37);

            this.txtNome.Location =
                new System.Drawing.Point(45, 128);

            this.txtNome.Name = "txtNome";

            this.txtNome.Size =
                new System.Drawing.Size(430, 30);

            // =========================================================
            // TELEFONE
            // =========================================================

            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblTelefone.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblTelefone.Location =
                new System.Drawing.Point(495, 105);

            this.lblTelefone.Text = "TELEFONE";

            this.txtTelefone.BackColor =
                System.Drawing.Color.White;

            this.txtTelefone.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtTelefone.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtTelefone.ForeColor =
                System.Drawing.Color.FromArgb(50, 40, 37);

            this.txtTelefone.Location =
                new System.Drawing.Point(493, 128);

            this.txtTelefone.Name = "txtTelefone";

            this.txtTelefone.Size =
                new System.Drawing.Size(220, 30);

            // =========================================================
            // EMAIL
            // =========================================================

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblEmail.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblEmail.Location =
                new System.Drawing.Point(47, 178);

            this.lblEmail.Text = "E-MAIL";

            this.txtEmail.BackColor =
                System.Drawing.Color.White;

            this.txtEmail.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtEmail.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtEmail.ForeColor =
                System.Drawing.Color.FromArgb(50, 40, 37);

            this.txtEmail.Location =
                new System.Drawing.Point(45, 201);

            this.txtEmail.Name = "txtEmail";

            this.txtEmail.Size =
                new System.Drawing.Size(430, 30);

            // =========================================================
            // PERFIL
            // =========================================================

            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblPerfil.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblPerfil.Location =
                new System.Drawing.Point(495, 178);

            this.lblPerfil.Text = "PERFIL";

            this.cmbPerfil.BackColor =
                System.Drawing.Color.White;

            this.cmbPerfil.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbPerfil.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbPerfil.FormattingEnabled = true;

            this.cmbPerfil.Location =
                new System.Drawing.Point(493, 200);

            this.cmbPerfil.Name = "cmbPerfil";

            this.cmbPerfil.Size =
                new System.Drawing.Size(220, 31);

            // =========================================================
            // SENHA
            // =========================================================

            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblSenha.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblSenha.Location =
                new System.Drawing.Point(47, 251);

            this.lblSenha.Text = "SENHA";

            this.txtSenha.BackColor =
                System.Drawing.Color.White;

            this.txtSenha.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtSenha.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtSenha.ForeColor =
                System.Drawing.Color.FromArgb(50, 40, 37);

            this.txtSenha.Location =
                new System.Drawing.Point(45, 274);

            this.txtSenha.Name = "txtSenha";

            this.txtSenha.Size =
                new System.Drawing.Size(315, 30);

            this.txtSenha.UseSystemPasswordChar = true;

            // =========================================================
            // CONFIRMAR SENHA
            // =========================================================

            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.Font = new System.Drawing.Font(
                "Segoe UI Semibold",
                9F,
                System.Drawing.FontStyle.Bold);

            this.lblConfirmar.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblConfirmar.Location =
                new System.Drawing.Point(387, 251);

            this.lblConfirmar.Text = "CONFIRMAR SENHA";

            this.txtConfirmar.BackColor =
                System.Drawing.Color.White;

            this.txtConfirmar.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtConfirmar.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtConfirmar.ForeColor =
                System.Drawing.Color.FromArgb(50, 40, 37);

            this.txtConfirmar.Location =
                new System.Drawing.Point(385, 274);

            this.txtConfirmar.Name = "txtConfirmar";

            this.txtConfirmar.Size =
                new System.Drawing.Size(328, 30);

            this.txtConfirmar.UseSystemPasswordChar = true;

            // =========================================================
            // ENDEREÇO
            // =========================================================

            this.lblEnderecoTitulo.AutoSize = true;
            this.lblEnderecoTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.lblEnderecoTitulo.ForeColor =
                System.Drawing.Color.FromArgb(201, 130, 107);

            this.lblEnderecoTitulo.Location =
                new System.Drawing.Point(45, 326);

            this.lblEnderecoTitulo.Text =
                "ENDEREÇO";

            // =========================================================
            // LOGRADOURO
            // =========================================================

            this.lblLogradouro.AutoSize = true;
            this.lblLogradouro.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblLogradouro.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblLogradouro.Location =
                new System.Drawing.Point(47, 356);

            this.lblLogradouro.Text = "LOGRADOURO";

            this.txtLogradouro.BackColor =
                System.Drawing.Color.White;

            this.txtLogradouro.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtLogradouro.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtLogradouro.Location =
                new System.Drawing.Point(45, 379);

            this.txtLogradouro.Name = "txtLogradouro";

            this.txtLogradouro.Size =
                new System.Drawing.Size(480, 30);

            // =========================================================
            // NÚMERO
            // =========================================================

            this.lblNumero.AutoSize = true;
            this.lblNumero.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblNumero.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblNumero.Location =
                new System.Drawing.Point(545, 356);

            this.lblNumero.Text = "NÚMERO";

            this.txtNumero.BackColor =
                System.Drawing.Color.White;

            this.txtNumero.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtNumero.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtNumero.Location =
                new System.Drawing.Point(543, 379);

            this.txtNumero.Name = "txtNumero";

            this.txtNumero.Size =
                new System.Drawing.Size(170, 30);

            // =========================================================
            // COMPLEMENTO
            // =========================================================

            this.lblComplemento.AutoSize = true;
            this.lblComplemento.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblComplemento.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblComplemento.Location =
                new System.Drawing.Point(47, 428);

            this.lblComplemento.Text = "COMPLEMENTO";

            this.txtComplemento.BackColor =
                System.Drawing.Color.White;

            this.txtComplemento.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtComplemento.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtComplemento.Location =
                new System.Drawing.Point(45, 451);

            this.txtComplemento.Name = "txtComplemento";

            this.txtComplemento.Size =
                new System.Drawing.Size(315, 30);

            // =========================================================
            // BAIRRO
            // =========================================================

            this.lblBairro.AutoSize = true;
            this.lblBairro.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblBairro.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblBairro.Location =
                new System.Drawing.Point(387, 428);

            this.lblBairro.Text = "BAIRRO";

            this.txtBairro.BackColor =
                System.Drawing.Color.White;

            this.txtBairro.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtBairro.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtBairro.Location =
                new System.Drawing.Point(385, 451);

            this.txtBairro.Name = "txtBairro";

            this.txtBairro.Size =
                new System.Drawing.Size(328, 30);

            // =========================================================
            // CIDADE
            // =========================================================

            this.lblCidade.AutoSize = true;
            this.lblCidade.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblCidade.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblCidade.Location =
                new System.Drawing.Point(47, 500);

            this.lblCidade.Text = "CIDADE";

            this.txtCidade.BackColor =
                System.Drawing.Color.White;

            this.txtCidade.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtCidade.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtCidade.Location =
                new System.Drawing.Point(45, 523);

            this.txtCidade.Name = "txtCidade";

            this.txtCidade.Size =
                new System.Drawing.Size(315, 30);

            // =========================================================
            // ESTADO
            // =========================================================

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblEstado.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblEstado.Location =
                new System.Drawing.Point(387, 500);

            this.lblEstado.Text = "ESTADO";

            this.cmbEstado.BackColor =
                System.Drawing.Color.White;

            this.cmbEstado.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbEstado.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.cmbEstado.FormattingEnabled = true;

            this.cmbEstado.Location =
                new System.Drawing.Point(385, 522);

            this.cmbEstado.Name = "cmbEstado";

            this.cmbEstado.Size =
                new System.Drawing.Size(100, 31);

            this.cmbEstado.Items.AddRange(new object[]
            {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
            });

            // =========================================================
            // CEP
            // =========================================================

            this.lblCep.AutoSize = true;
            this.lblCep.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.lblCep.ForeColor =
                System.Drawing.Color.FromArgb(70, 55, 50);

            this.lblCep.Location =
                new System.Drawing.Point(505, 500);

            this.lblCep.Text = "CEP";

            this.txtCep.BackColor =
                System.Drawing.Color.White;

            this.txtCep.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtCep.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtCep.Location =
                new System.Drawing.Point(503, 522);

            this.txtCep.Name = "txtCep";

            this.txtCep.Size =
                new System.Drawing.Size(210, 30);

            // =========================================================
            // BOTÃO CANCELAR
            // =========================================================

            this.btnCancelar.BackColor =
                System.Drawing.Color.FromArgb(235, 229, 225);

            this.btnCancelar.FlatAppearance.BorderSize = 0;

            this.btnCancelar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCancelar.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnCancelar.ForeColor =
                System.Drawing.Color.FromArgb(80, 65, 60);

            this.btnCancelar.Location =
                new System.Drawing.Point(430, 614);

            this.btnCancelar.Name = "btnCancelar";

            this.btnCancelar.Size =
                new System.Drawing.Size(135, 45);

            this.btnCancelar.Text = "Cancelar";

            this.btnCancelar.UseVisualStyleBackColor = false;

            this.btnCancelar.Click +=
                new System.EventHandler(this.btnCancelar_Click);

            // =========================================================
            // BOTÃO SALVAR
            // =========================================================

            this.btnSalvar.BackColor =
                System.Drawing.Color.FromArgb(201, 130, 107);

            this.btnSalvar.FlatAppearance.BorderSize = 0;

            this.btnSalvar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSalvar.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnSalvar.ForeColor =
                System.Drawing.Color.White;

            this.btnSalvar.Location =
                new System.Drawing.Point(575, 614);

            this.btnSalvar.Name = "btnSalvar";

            this.btnSalvar.Size =
                new System.Drawing.Size(138, 45);

            this.btnSalvar.Text = "Salvar";

            this.btnSalvar.UseVisualStyleBackColor = false;

            this.btnSalvar.Click +=
                new System.EventHandler(this.btnSalvar_Click);

            // =========================================================

            this.AcceptButton = this.btnSalvar;
            this.CancelButton = this.btnCancelar;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}