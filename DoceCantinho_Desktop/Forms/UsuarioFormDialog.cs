using DoceCantinho.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.Forms
{
    public partial class UsuarioFormDialog : Form
    {
        /// <summary>
        /// DTO preenchido após clicar em "Salvar" com sucesso (modo criação).
        /// Fica null se o usuário cancelar o formulário ou se estiver em modo edição.
        /// </summary>
        public CreateUsuarioDto? UsuarioDto { get; private set; }

        /// <summary>
        /// DTO preenchido após clicar em "Salvar" com sucesso (modo edição).
        /// Fica null se o usuário cancelar o formulário ou se estiver em modo criação.
        /// </summary>
        public UpdateUsuarioDto? UsuarioUpdateDto { get; private set; }

        /// <summary>
        /// Id do usuário sendo editado. Só é preenchido em modo edição.
        /// </summary>
        public string? UsuarioId { get; private set; }

        private readonly bool _modoEdicao;
        public UsuarioFormDialog()
        {
            InitializeComponent();

            // Popula o combo de perfis (roles) disponíveis.
            // Antes o cmbPerfil ficava sempre vazio, o que fazia a validação
            // de "Selecione um perfil" falhar SEMPRE, bloqueando criação e edição.
            if (cmbPerfil.Items.Count == 0)
            {
                cmbPerfil.Items.AddRange(new object[] { "Admin", "Usuário" });
            }

            // Perfil padrão
            if (cmbPerfil.Items.Count > 0)
                cmbPerfil.SelectedIndex = 0;
        }

        public UsuarioFormDialog(UsuarioResponseDto usuarioExistente) : this()
        {
            _modoEdicao = true;
            UsuarioId = usuarioExistente.Id;

            txtEmail.Text = usuarioExistente.Email;

            var perfilAtual = usuarioExistente.Roles.FirstOrDefault();
            if (perfilAtual != null && cmbPerfil.Items.Contains(perfilAtual))
                cmbPerfil.SelectedItem = perfilAtual;

            // Em modo edição a senha é opcional (deixar em branco mantém a senha atual)
            lblSenha.Text = "SENHA";
            lblconf.Text = "CONFIRMAR SENHA";
            lbltitulo.Text = "✏️ Editar Usuário";
            btnSalvar.Text = "💾 Salvar Alterações";
            Text = "Editar Usuário";
        }



        private void UsuarioFormDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var senha = txtSenha.Text;
            var confirmar = txtConfirmar.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Informe o e-mail do usuário", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Em modo edição a senha só é validada se o usuário preencheu algo
            bool senhaInformada = !string.IsNullOrWhiteSpace(senha) || !string.IsNullOrWhiteSpace(confirmar);
            if (!_modoEdicao || senhaInformada)
            {
                if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                {
                    MessageBox.Show("A senha deve ter ao menos 6 caracteres", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (senha != confirmar)
                {
                    MessageBox.Show("As senhas não coincidem", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (cmbPerfil.SelectedItem == null)
            {
                MessageBox.Show("Selecione um perfil (role)", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var role = cmbPerfil.SelectedItem.ToString() ?? "Usuário";

            if (_modoEdicao)
            {
                UsuarioUpdateDto = new UpdateUsuarioDto
                {
                    Email = email,
                    Password = senhaInformada ? senha : null,
                    ConfirmPassword = senhaInformada ? confirmar : null,
                    Role = role
                };
            }
            else
            {
                UsuarioDto = new CreateUsuarioDto
                {
                    Email = email,
                    Password = senha,
                    ConfirmPassword = confirmar,
                    Role = role
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
