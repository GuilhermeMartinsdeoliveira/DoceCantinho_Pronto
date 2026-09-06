using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class PerfilForm : Form
    {
        private Image? _fotoAtual;

        public PerfilForm()
        {
            InitializeComponent();

            ConfigurarFormulario();
            CarregarPerfil();
            ConfigurarEventos();
        }

        // ============================================================
        // CONFIGURAÇÃO
        // ============================================================

        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterParent;

            txtSenhaAtual.UseSystemPasswordChar = true;
            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmarSenha.UseSystemPasswordChar = true;

            txtEmail.ReadOnly = true;

            btnSalvar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
            btnAlterarFoto.Cursor = Cursors.Hand;

            lblAvatar.Cursor = Cursors.Default;
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            btnAlterarFoto.Click -= btnAlterarFoto_Click;
            btnAlterarFoto.Click += btnAlterarFoto_Click;

            chkMostrarSenha.CheckedChanged -= chkMostrarSenha_CheckedChanged;
            chkMostrarSenha.CheckedChanged += chkMostrarSenha_CheckedChanged;
        }

        // ============================================================
        // CARREGAR PERFIL
        // ============================================================

        private void CarregarPerfil()
        {
            /*
             * Estes valores são os valores exibidos atualmente
             * no Designer.
             *
             * Quando o sistema estiver ligado ao usuário autenticado,
             * esta parte poderá ser substituída pelos dados vindos da API.
             */

            string nome = "José da Silva";
            string email = "usuario@email.com";
            string perfil = "Administrador";

            txtNome.Text = nome;
            txtEmail.Text = email;

            lblNomeUsuario.Text = nome;
            lblEmail.Text = email;
            lblPerfil.Text = perfil;

            lblPerfilValor.Text = perfil;

            AtualizarAvatar(nome);
        }

        // ============================================================
        // AVATAR
        // ============================================================

        private void AtualizarAvatar(string nome)
        {
            string iniciais = ObterIniciais(nome);

            lblAvatar.Text = iniciais;

            if (_fotoAtual == null)
            {
                lblAvatar.Visible = true;
                pictureFoto.Visible = false;
            }
            else
            {
                lblAvatar.Visible = false;
                pictureFoto.Visible = true;
                pictureFoto.Image = _fotoAtual;
            }
        }

        private string ObterIniciais(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return "JS";

            string[] partes = nome
                .Trim()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 1)
            {
                string primeira = partes[0];

                return primeira.Length >= 2
                    ? primeira[..2].ToUpper()
                    : primeira.ToUpper();
            }

            string primeiraInicial = partes[0][0].ToString();
            string ultimaInicial = partes[^1][0].ToString();

            return (
                primeiraInicial +
                ultimaInicial
            ).ToUpper();
        }

        // ============================================================
        // ALTERAR FOTO
        // ============================================================

        private void btnAlterarFoto_Click(
            object? sender,
            EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Selecionar foto do perfil",
                Filter =
                    "Imagens (*.jpg;*.jpeg;*.png;*.bmp)|" +
                    "*.jpg;*.jpeg;*.png;*.bmp|" +
                    "Todos os arquivos (*.*)|*.*",
                Multiselect = false
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                using Image imagemTemporaria =
                    Image.FromFile(dialog.FileName);

                Image novaImagem =
                    new Bitmap(imagemTemporaria);

                _fotoAtual?.Dispose();
                _fotoAtual = novaImagem;

                pictureFoto.Image = _fotoAtual;
                pictureFoto.Visible = true;
                lblAvatar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar a foto.\n\n" +
                    ex.Message,
                    "Foto do perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // MOSTRAR / OCULTAR SENHAS
        // ============================================================

        private void chkMostrarSenha_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            bool mostrar = chkMostrarSenha.Checked;

            txtSenhaAtual.UseSystemPasswordChar = !mostrar;
            txtNovaSenha.UseSystemPasswordChar = !mostrar;
            txtConfirmarSenha.UseSystemPasswordChar = !mostrar;
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            if (!ValidarDados())
                return;

            string nome = txtNome.Text.Trim();

            bool alterouSenha =
                !string.IsNullOrWhiteSpace(txtSenhaAtual.Text) ||
                !string.IsNullOrWhiteSpace(txtNovaSenha.Text) ||
                !string.IsNullOrWhiteSpace(txtConfirmarSenha.Text);

            if (alterouSenha)
            {
                if (!ValidarSenha())
                    return;
            }

            lblNomeUsuario.Text = nome;
            AtualizarAvatar(nome);

            /*
             * Neste momento o formulário atualiza a interface localmente.
             *
             * A gravação definitiva no banco/API do usuário deverá ser
             * ligada aqui quando tivermos o endpoint de atualização
             * do usuário autenticado.
             */

            MessageBox.Show(
                "As alterações foram aplicadas com sucesso.",
                "Meu Perfil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        // ============================================================
        // VALIDAR DADOS
        // ============================================================

        private bool ValidarDados()
        {
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show(
                    "Informe o nome de exibição.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();
                return false;
            }

            if (nome.Length < 2)
            {
                MessageBox.Show(
                    "O nome deve possuir pelo menos 2 caracteres.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // VALIDAR SENHA
        // ============================================================

        private bool ValidarSenha()
        {
            string senhaAtual = txtSenhaAtual.Text;
            string novaSenha = txtNovaSenha.Text;
            string confirmarSenha = txtConfirmarSenha.Text;

            if (string.IsNullOrWhiteSpace(senhaAtual))
            {
                MessageBox.Show(
                    "Informe a senha atual.",
                    "Alteração de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSenhaAtual.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(novaSenha))
            {
                MessageBox.Show(
                    "Informe a nova senha.",
                    "Alteração de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNovaSenha.Focus();
                return false;
            }

            if (novaSenha.Length < 6)
            {
                MessageBox.Show(
                    "A nova senha deve possuir pelo menos 6 caracteres.",
                    "Alteração de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNovaSenha.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show(
                    "Confirme a nova senha.",
                    "Alteração de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmarSenha.Focus();
                return false;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show(
                    "A nova senha e a confirmação não são iguais.",
                    "Alteração de senha",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmarSenha.Focus();
                return false;
            }

            return true;
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
