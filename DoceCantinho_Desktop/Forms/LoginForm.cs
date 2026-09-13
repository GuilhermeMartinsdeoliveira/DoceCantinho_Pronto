using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private AuthApiService _authService = null!;

        // ============================================================
        // BOTÃO X
        // ============================================================

        private Guna2Button? _btnFechar;

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public LoginForm()
        {
            InitializeComponent();

            // --------------------------------------------------------
            // FORMULÁRIO SEM BORDA NATIVA
            // --------------------------------------------------------

            FormBorderStyle =
                FormBorderStyle.None;

            // --------------------------------------------------------
            // CRIAR BOTÃO X
            // --------------------------------------------------------

            CriarBotaoFechar();
        }

        // ============================================================
        // CRIAR BOTÃO X
        // ============================================================

        private void CriarBotaoFechar()
        {
            if (_btnFechar != null)
                return;

            _btnFechar = new Guna2Button
            {
                Name = "btnFecharLogin",

                // Usamos um X mais simples para evitar
                // que o caractere seja cortado.
                Text = "✕",

                Size = new Size(36, 36),

                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right,

                BorderRadius = 8,

                FillColor =
                    Color.Transparent,

                ForeColor =
                    Color.FromArgb(
                        100,
                        90,
                        90),

                Font =
                    new Font(
                        "Segoe UI",
                        13F,
                        FontStyle.Regular),

                Cursor =
                    Cursors.Hand,

                Padding =
                    new Padding(0),

                TabStop = false
            };

            // --------------------------------------------------------
            // POSIÇÃO INICIAL
            // --------------------------------------------------------

            _btnFechar.Location =
                new Point(
                    pnlDireito.ClientSize.Width -
                    _btnFechar.Width -
                    8,
                    5);

            // --------------------------------------------------------
            // HOVER
            // --------------------------------------------------------

            _btnFechar.HoverState.FillColor =
                Color.FromArgb(
                    225,
                    205,
                    198);

            _btnFechar.HoverState.ForeColor =
                Color.FromArgb(
                    150,
                    60,
                    55);

            // --------------------------------------------------------
            // PRESSIONADO
            // --------------------------------------------------------

            _btnFechar.PressedColor =
                Color.FromArgb(
                    210,
                    185,
                    178);

            // --------------------------------------------------------
            // EVENTO
            // --------------------------------------------------------

            _btnFechar.Click +=
                BtnFechar_Click;

            // --------------------------------------------------------
            // ADICIONAR AO PAINEL DIREITO
            // --------------------------------------------------------

            pnlDireito.Controls.Add(
                _btnFechar);

            _btnFechar.BringToFront();

            // --------------------------------------------------------
            // REDIMENSIONAMENTO
            // --------------------------------------------------------

            pnlDireito.Resize +=
                PnlDireito_Resize;
        }

        // ============================================================
        // POSICIONAR BOTÃO X
        // ============================================================

        private void PnlDireito_Resize(
            object? sender,
            EventArgs e)
        {
            if (_btnFechar == null)
                return;

            _btnFechar.Location =
                new Point(
                    pnlDireito.ClientSize.Width -
                    _btnFechar.Width -
                    8,
                    5);
        }

        // ============================================================
        // CLIQUE NO X
        // ============================================================

        private void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            Application.Exit();
        }

        // ============================================================
        // TEMA DO LOGIN
        // ============================================================

        private void AplicarTemaLogin()
        {
            // ========================================================
            // E-MAIL
            // ========================================================

            txtEmail.BorderColor =
                DoceTheme.Borda;

            txtEmail.FocusedState.BorderColor =
                DoceTheme.Primaria;

            txtEmail.HoverState.BorderColor =
                DoceTheme.Primaria;

            txtEmail.FillColor =
                DoceTheme.FundoInput;

            txtEmail.ForeColor =
                DoceTheme.Texto;

            txtEmail.PlaceholderForeColor =
                DoceTheme.TextoFraco;

            // ========================================================
            // SENHA
            // ========================================================

            txtSenha.BorderColor =
                DoceTheme.Borda;

            txtSenha.FocusedState.BorderColor =
                DoceTheme.Primaria;

            txtSenha.HoverState.BorderColor =
                DoceTheme.Primaria;

            txtSenha.FillColor =
                DoceTheme.FundoInput;

            txtSenha.ForeColor =
                DoceTheme.Texto;

            txtSenha.PlaceholderForeColor =
                DoceTheme.TextoFraco;

            // ========================================================
            // BOTÃO ENTRAR
            // ========================================================

            DoceTheme.AplicarBotaoPrimario(
                btnEntrar);

            // ========================================================
            // BOTÃO CANCELAR
            // ========================================================

            DoceTheme.AplicarBotaoSecundario(
                btnCancelar);
        }

        // ============================================================
        // LOGIN
        // ============================================================

        private async void btnEntrar_Click(
            object sender,
            EventArgs e)
        {
            ExibirErro(string.Empty);

            // --------------------------------------------------------
            // E-MAIL
            // --------------------------------------------------------

            string email =
                txtEmail.Text.Trim();

            string senha =
                txtSenha.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                ExibirErro(
                    "Informe seu e-mail.");

                txtEmail.Focus();

                return;
            }

            // --------------------------------------------------------
            // SENHA
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(senha))
            {
                ExibirErro(
                    "Informe sua senha.");

                txtSenha.Focus();

                return;
            }

            // --------------------------------------------------------
            // CARREGANDO
            // --------------------------------------------------------

            SetCarregando(true);

            try
            {
                var (
                    success,
                    user,
                    errorMessage
                ) =
                    await _authService.LoginAsync(
                        email,
                        senha);

                // ----------------------------------------------------
                // LOGIN REALIZADO
                // ----------------------------------------------------

                if (success && user != null)
                {
                    SessionManager.Instance
                        .SetUser(user);

                    Hide();

                    using var doceForm =
                        new MainForm();

                    doceForm.ShowDialog();

                    Close();

                    return;
                }

                // ----------------------------------------------------
                // LOGIN NEGADO
                // ----------------------------------------------------

                ExibirErro(
                    string.IsNullOrWhiteSpace(
                        errorMessage)
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
                    $"Ocorreu um erro inesperado.\n\n" +
                    $"{ex.Message}",
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

        private void ExibirErro(
            string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                lblErro.Visible =
                    false;

                lblErro.Text =
                    string.Empty;

                return;
            }

            lblErro.Text =
                $"⚠  {mensagem}";

            lblErro.Visible =
                true;
        }

        // ============================================================
        // CANCELAR / SAIR
        // ============================================================

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        // ============================================================
        // LOAD
        // ============================================================

        private void LoginForm_Load(
            object sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            // --------------------------------------------------------
            // APLICAR TEMA
            // --------------------------------------------------------

            AplicarTemaLogin();

            // --------------------------------------------------------
            // SERVIÇO DA API
            // --------------------------------------------------------

            _authService =
                new AuthApiService();

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

            txtEmail.Text =
                "admin@docecantinho.com";

            txtSenha.Text =
                "Admin@123";

            txtSenha.UseSystemPasswordChar =
                true;

            // --------------------------------------------------------
            // ESTADOS INICIAIS
            // --------------------------------------------------------

            lblAutenticando.Visible =
                false;

            lblErro.Visible =
                false;

            // --------------------------------------------------------
            // FOCO
            // --------------------------------------------------------
            // Não usamos SelectAll().
            // Isso evita a seleção azul do texto ao abrir a tela.

            BeginInvoke(new Action(() =>
            {
                txtEmail.Focus();

                txtEmail.SelectionStart =
                    txtEmail.Text.Length;

                txtEmail.SelectionLength =
                    0;
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

        private void SetCarregando(
            bool carregando)
        {
            btnEntrar.Enabled =
                !carregando;

            btnCancelar.Enabled =
                !carregando;

            txtEmail.Enabled =
                !carregando;

            txtSenha.Enabled =
                !carregando;

            // --------------------------------------------------------
            // X CONTINUA FUNCIONANDO
            // --------------------------------------------------------

            if (_btnFechar != null)
            {
                _btnFechar.Enabled =
                    true;
            }

            // --------------------------------------------------------
            // INDICADOR
            // --------------------------------------------------------

            lblAutenticando.Visible =
                carregando;

            // --------------------------------------------------------
            // BOTÃO
            // --------------------------------------------------------

            if (carregando)
            {
                btnEntrar.Text =
                    "Entrando...";

                ExibirErro(
                    string.Empty);
            }
            else
            {
                btnEntrar.Text =
                    "Entrar";
            }
        }

        // ============================================================
        // FECHAMENTO
        // ============================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            // --------------------------------------------------------
            // REMOVER EVENTO DO X
            // --------------------------------------------------------

            if (_btnFechar != null)
            {
                _btnFechar.Click -=
                    BtnFechar_Click;

                _btnFechar.Dispose();

                _btnFechar = null;
            }

            // --------------------------------------------------------
            // BASE
            // --------------------------------------------------------

            base.OnFormClosed(e);
        }
    }
}