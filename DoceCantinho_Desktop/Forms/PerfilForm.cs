using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class PerfilForm : Form
    {
        private readonly UserResponseDto? _usuario;

        private string? _caminhoFoto;

        private readonly AuthApiService _authService;

        public PerfilForm()
        {
            InitializeComponent();

            _authService = new AuthApiService();

            // Obtém o usuário atualmente conectado.
            _usuario = SessionManager.Instance.CurrentUser;

            CarregarPerfil();
        }

        // ============================================================
        // CARREGAR PERFIL
        // ============================================================

        private void CarregarPerfil()
        {
            if (_usuario == null)
            {
                lblNomeUsuario.Text = "Usuário";
                lblEmail.Text = string.Empty;
                lblPerfil.Text = "Usuário Comum";

                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;

                lblAvatar.Text = "U";
                lblAvatar.Visible = true;
                pictureFoto.Visible = false;

                return;
            }

            // ========================================================
            // E-MAIL
            // ========================================================

            txtEmail.Text = _usuario.Email;

            lblEmail.Text = _usuario.Email;

            // ========================================================
            // PERFIL
            // ========================================================

            lblPerfil.Text = _usuario.IsAdmin
                ? "Administrador"
                : "Usuário Comum";

            // ========================================================
            // NOME DE EXIBIÇÃO
            // ========================================================

            string nome =
                SessionManager.Instance.GetDisplayName();

            txtNome.Text = nome;

            lblNomeUsuario.Text = nome;

            // ========================================================
            // AVATAR
            // ========================================================

            lblAvatar.Text =
                ObterIniciais(nome);

            lblAvatar.Visible = true;

            pictureFoto.Visible = false;

            // ========================================================
            // SEGURANÇA
            // ========================================================

            // A senha nunca é carregada do sistema.
            //
            // O usuário somente informa a senha atual quando:
            // - alterar o e-mail
            // - alterar a senha
            //
            // Se não quiser alterar a senha, os três campos
            // permanecem vazios.

            txtSenhaAtual.Clear();
            txtNovaSenha.Clear();
            txtConfirmarSenha.Clear();
        }

        // ============================================================
        // OBTER INICIAIS
        // ============================================================

        private string ObterIniciais(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return "U";

            string[] partes =
                nome
                    .Trim()
                    .Split(
                        ' ',
                        StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 1)
            {
                return partes[0]
                    .Substring(0, 1)
                    .ToUpper();
            }

            return (
                partes[0].Substring(0, 1) +
                partes[^1].Substring(0, 1)
            ).ToUpper();
        }

        // ============================================================
        // ALTERAR FOTO
        // ============================================================

        private void btnAlterarFoto_Click(
            object sender,
            EventArgs e)
        {
            using OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Title =
                "Selecionar foto de perfil";

            dialog.Filter =
                "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            dialog.Multiselect =
                false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using Image imagemTemporaria =
                    Image.FromFile(dialog.FileName);

                pictureFoto.Image =
                    new Bitmap(imagemTemporaria);

                pictureFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;

                pictureFoto.Visible =
                    true;

                lblAvatar.Visible =
                    false;

                _caminhoFoto =
                    dialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar a imagem.\n\n{ex.Message}",
                    "Foto de perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ============================================================
        // MOSTRAR / OCULTAR SENHAS
        // ============================================================

        private void chkMostrarSenha_CheckedChanged(
            object sender,
            EventArgs e)
        {
            bool mostrar =
                chkMostrarSenha.Checked;

            txtSenhaAtual.UseSystemPasswordChar =
                !mostrar;

            txtNovaSenha.UseSystemPasswordChar =
                !mostrar;

            txtConfirmarSenha.UseSystemPasswordChar =
                !mostrar;
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private async void btnSalvar_Click(
            object sender,
            EventArgs e)
        {
            if (_usuario == null)
            {
                MessageBox.Show(
                    "Não foi possível identificar o usuário conectado.",
                    "Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ========================================================
            // CAPTURA DOS CAMPOS
            // ========================================================

            string nome =
                txtNome.Text.Trim();

            string email =
                txtEmail.Text.Trim();

            string senhaAtual =
                txtSenhaAtual.Text;

            string novaSenha =
                txtNovaSenha.Text;

            string confirmarSenha =
                txtConfirmarSenha.Text;

            // ========================================================
            // VALIDAÇÃO DO NOME
            // ========================================================

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show(
                    "Informe o nome de exibição.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();

                return;
            }

            // ========================================================
            // VALIDAÇÃO DO E-MAIL
            // ========================================================

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Informe o e-mail.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();

                return;
            }

            if (!email.Contains("@") ||
                !email.Contains("."))
            {
                MessageBox.Show(
                    "Informe um e-mail válido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();

                return;
            }

            // ========================================================
            // IDENTIFICA O QUE FOI ALTERADO
            // ========================================================

            bool alterandoSenha =
                !string.IsNullOrWhiteSpace(novaSenha) ||
                !string.IsNullOrWhiteSpace(confirmarSenha);

            bool alterandoEmail =
                !email.Equals(
                    _usuario.Email,
                    StringComparison.OrdinalIgnoreCase);

            bool alterandoNome =
                !nome.Equals(
                    SessionManager.Instance.GetDisplayName(),
                    StringComparison.OrdinalIgnoreCase);

            bool alterandoFoto =
                !string.IsNullOrWhiteSpace(_caminhoFoto);

            // ========================================================
            // VALIDAÇÃO DA SENHA
            // ========================================================

            // A senha atual somente é necessária quando:
            //
            // 1. O usuário deseja alterar o e-mail
            // 2. O usuário deseja alterar a senha
            //
            // Alterar nome ou foto não exige senha.

            if (alterandoSenha)
            {
                if (string.IsNullOrWhiteSpace(senhaAtual))
                {
                    MessageBox.Show(
                        "Para alterar sua senha, informe a senha atual.",
                        "Senha atual",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSenhaAtual.Focus();

                    return;
                }

                if (string.IsNullOrWhiteSpace(novaSenha))
                {
                    MessageBox.Show(
                        "Informe a nova senha.",
                        "Nova senha",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNovaSenha.Focus();

                    return;
                }

                if (novaSenha.Length < 6)
                {
                    MessageBox.Show(
                        "A nova senha deve possuir pelo menos 6 caracteres.",
                        "Nova senha",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNovaSenha.Focus();

                    return;
                }

                if (string.IsNullOrWhiteSpace(confirmarSenha))
                {
                    MessageBox.Show(
                        "Confirme a nova senha.",
                        "Confirmar senha",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtConfirmarSenha.Focus();

                    return;
                }

                if (!novaSenha.Equals(confirmarSenha))
                {
                    MessageBox.Show(
                        "A nova senha e a confirmação não coincidem.",
                        "Nova senha",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtConfirmarSenha.Focus();

                    return;
                }
            }

            // ========================================================
            // ALTERAÇÃO DE E-MAIL
            // ========================================================

            if (alterandoEmail &&
                string.IsNullOrWhiteSpace(senhaAtual))
            {
                MessageBox.Show(
                    "Para alterar o e-mail, informe sua senha atual.",
                    "Senha atual",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSenhaAtual.Focus();

                return;
            }

            // ========================================================
            // NADA ALTERADO
            // ========================================================

            if (!alterandoNome &&
                !alterandoEmail &&
                !alterandoSenha &&
                !alterandoFoto)
            {
                MessageBox.Show(
                    "Nenhuma alteração foi realizada.",
                    "Meu Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // ========================================================
            // BOTÃO SALVAR
            // ========================================================

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;

            string textoOriginal =
                btnSalvar.Text;

            btnSalvar.Text =
                "Salvando...";

            try
            {
                // ====================================================
                // ENVIA ALTERAÇÕES PARA API
                // ====================================================

                var resultado =
                    await _authService.UpdateProfileAsync(
                        email,
                        senhaAtual,
                        alterandoSenha
                            ? novaSenha
                            : null,
                        alterandoSenha
                            ? confirmarSenha
                            : null);

                // ====================================================
                // API RETORNOU ERRO
                // ====================================================

                if (!resultado.Success)
                {
                    MessageBox.Show(
                        resultado.ErrorMessage,
                        "Não foi possível salvar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // ====================================================
                // ATUALIZA SESSION MANAGER
                // ====================================================

                if (resultado.User != null)
                {
                    SessionManager.Instance.SetUser(
                        resultado.User);
                }

                // ====================================================
                // FOTO
                // ====================================================

                // Neste momento a foto é exibida no formulário,
                // mas ainda não é persistida no servidor.
                //
                // A persistência da foto será implementada na
                // próxima etapa junto com o campo DisplayName.

                // ====================================================
                // SUCESSO
                // ====================================================

                MessageBox.Show(
                    "Suas informações foram atualizadas com sucesso.",
                    "Perfil atualizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao salvar seu perfil.\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSalvar.Enabled =
                    true;

                btnCancelar.Enabled =
                    true;

                btnSalvar.Text =
                    textoOriginal;
            }
        }
    }
}