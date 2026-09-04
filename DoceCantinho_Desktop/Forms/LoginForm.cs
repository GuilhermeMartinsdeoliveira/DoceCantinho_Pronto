using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using System.Net.Http;

namespace DoceCantinho.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private AuthApiService _authService = null!;

        public LoginForm()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOGIN
        // ============================================================

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            ExibirErro(string.Empty);

            // --------------------------------------------------------
            // VALIDAÇÃO DO E-MAIL
            // --------------------------------------------------------

            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                ExibirErro("Informe seu e-mail.");
                txtEmail.Focus();
                return;
            }

            // --------------------------------------------------------
            // VALIDAÇÃO DA SENHA
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(senha))
            {
                ExibirErro("Informe sua senha.");
                txtSenha.Focus();
                return;
            }

            // --------------------------------------------------------
            // CARREGANDO
            // --------------------------------------------------------

            SetCarregando(true);

            try
            {
                var (success, user, errorMessage) =
                    await _authService.LoginAsync(
                        email,
                        senha);

                // ----------------------------------------------------
                // LOGIN REALIZADO
                // ----------------------------------------------------

                if (success && user != null)
                {
                    SessionManager.Instance.SetUser(user);

                    Hide();

                    using var doceForm = new MainForm();

                    doceForm.ShowDialog();

                    Close();

                    return;
                }

                // ----------------------------------------------------
                // LOGIN NEGADO
                // ----------------------------------------------------

                ExibirErro(
                    string.IsNullOrWhiteSpace(errorMessage)
                        ? "E-mail ou senha inválidos."
                        : errorMessage);
            }
            catch (HttpRequestException ex)
            {
                ExibirErro(
                    "Não foi possível conectar à API.");

                MessageBox.Show(
                    $"Não foi possível conectar à API.\n\n" +
                    $"Verifique se a API está em execução.\n\n" +
                    $"Detalhes: {ex.Message}",
                    "Erro de conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExibirErro(
                    "Ocorreu um erro inesperado.");

                MessageBox.Show(
                    $"Ocorreu um erro inesperado.\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetCarregando(false);
            }
        }

        // ============================================================
        // EXIBIR ERRO
        // ============================================================

        private void ExibirErro(string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                lblErro.Visible = false;
                lblErro.Text = string.Empty;
                return;
            }

            lblErro.Text = $"⚠  {mensagem}";
            lblErro.Visible = true;
        }

        // ============================================================
        // CANCELAR / SAIR
        // ============================================================

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ============================================================
        // LOAD
        // ============================================================

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            _authService = new AuthApiService();

            // --------------------------------------------------------
            // INFORMAÇÕES
            // --------------------------------------------------------

            lblVersao.Text =
                $"Versão {AppConfig.Version}  •  © {DateTime.Now.Year} SENAC-SMP";

            lblApi.Text =
                $"API  •  {AppConfig.ApiBaseUrl}";

            // --------------------------------------------------------
            // USUÁRIO DE TESTE
            // --------------------------------------------------------
            // Se não quiser deixar os dados preenchidos,
            // basta apagar estas duas linhas.

            txtEmail.Text =
                "admin@docecantinho.com";

            txtSenha.Text =
                "Admin@123";

            txtSenha.UseSystemPasswordChar = true;

            lblAutenticando.Visible = false;
            lblErro.Visible = false;

            // --------------------------------------------------------
            // FOCO
            // --------------------------------------------------------

            BeginInvoke(new Action(() =>
            {
                txtEmail.Focus();
                txtEmail.SelectAll();
            }));
        }

        // ============================================================
        // ENTER NO E-MAIL
        // ============================================================

        private void txtEmail_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                txtSenha.Focus();
            }
        }

        // ============================================================
        // ENTER NA SENHA
        // ============================================================

        private async void txtSenha_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                await RealizarLoginAsync();
            }
        }

        // ============================================================
        // LOGIN PELO ENTER
        // ============================================================

        private async Task RealizarLoginAsync()
        {
            if (!btnEntrar.Enabled)
                return;

            await Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    btnEntrar_Click(
                        btnEntrar,
                        EventArgs.Empty);
                }));
            });
        }

        // ============================================================
        // ESTADO DE CARREGAMENTO
        // ============================================================

        private void SetCarregando(bool carregando)
        {
            btnEntrar.Enabled = !carregando;

            btnCancelar.Enabled = !carregando;

            txtEmail.Enabled = !carregando;

            txtSenha.Enabled = !carregando;

            lblAutenticando.Visible = carregando;

            if (carregando)
            {
                btnEntrar.Text = "Entrando...";

                ExibirErro(string.Empty);
            }
            else
            {
                btnEntrar.Text = "Entrar";
            }
        }
    }
}