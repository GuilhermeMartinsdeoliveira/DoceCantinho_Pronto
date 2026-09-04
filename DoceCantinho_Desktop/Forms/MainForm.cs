using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using DoceCantinho.Desktop.UserControls;
using DoceCantinho.Desktop1.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class MainForm : Form
    {
        // ==========================================
        // CONTROLE ATUAL DA ÁREA PRINCIPAL
        // ==========================================
        private UserControl? _controleAtual;

        // ==========================================
        // BOTÃO ATIVO DA SIDEBAR
        // ==========================================
        private Guna2Button? _botaoAtivo;

        // ==========================================
        // SERVIÇO DE AUTENTICAÇÃO
        // ==========================================
        private AuthApiService? _authService;

        public MainForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD
        // ==========================================
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            _authService = new AuthApiService();

            // Título da aplicação
            Text = $"Doce Cantinho Desktop - {AppConfig.Version}";

            // ==========================================
            // DADOS DO USUÁRIO
            // ==========================================

            lblUsuario.Text =
                $"👤 {SessionManager.Instance.GetDisplayName()}";

            lblPerfil.Text =
                SessionManager.Instance.IsAdmin
                    ? "🔑 Administrador"
                    : "👀 Usuário Comum";

            lblPerfil.ForeColor =
                SessionManager.Instance.IsAdmin
                    ? DoceTheme.LaranjaPrimario
                    : DoceTheme.AzulVariante;

            lblSessao.Text =
                $"✉ {SessionManager.Instance.GetEmail()}";

            // ==========================================
            // PERMISSÕES
            // ==========================================

            ConfigurarPermissoes();

            // ==========================================
            // GARANTIR EVENTOS DOS BOTÕES
            // ==========================================

            ConfigurarEventos();

            // ==========================================
            // ABRIR DASHBOARD
            // ==========================================

            NavegarParaDashboard();
        }

        // ==========================================
        // CONFIGURAR PERMISSÕES
        // ==========================================
        private void ConfigurarPermissoes()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;

            btnCategoria.Visible = isAdmin;
            btnUsuario.Visible = isAdmin;

            // Pedidos podem ficar disponíveis para todos
            btnPedidos.Visible = true;
            btnDoce.Visible = true;
            btnDashboard.Visible = true;
        }

        // ==========================================
        // GARANTIR QUE OS CLICKS FUNCIONEM
        // ==========================================
        private void ConfigurarEventos()
        {
            // Remove eventos duplicados antes
            btnDashboard.Click -= btnDashboard_Click;
            btnDoce.Click -= btnDoce_Click;
            btnCategoria.Click -= btnCategoria_Click;
            btnPedidos.Click -= btnPedidos_Click;
            btnUsuario.Click -= btnUsuario_Click;

            // Adiciona os eventos
            btnDashboard.Click += btnDashboard_Click;
            btnDoce.Click += btnDoce_Click;
            btnCategoria.Click += btnCategoria_Click;
            btnPedidos.Click += btnPedidos_Click;
            btnUsuario.Click += btnUsuario_Click;

            // Logout
            lblSair.Click -= lblSair_Click;
            lblSair.Click += lblSair_Click;
        }

        // ==========================================
        // DASHBOARD
        // ==========================================
        private void NavegarParaDashboard()
        {
            Navegar(
                new DashboardUserControl(),
                btnDashboard
            );
        }

        // ==========================================
        // MÉTODO PRINCIPAL DE NAVEGAÇÃO
        // ==========================================
        private void Navegar(
            UserControl novoControle,
            Guna2Button? botao = null)
        {
            try
            {
                pnlPanel.SuspendLayout();

                // ==========================================
                // REMOVER CONTROLE ANTERIOR
                // ==========================================

                if (_controleAtual != null)
                {
                    pnlPanel.Controls.Remove(_controleAtual);

                    _controleAtual.Dispose();

                    _controleAtual = null;
                }

                // ==========================================
                // CONFIGURAR NOVO CONTROLE
                // ==========================================

                novoControle.Dock = DockStyle.Fill;

                novoControle.Visible = true;

                pnlPanel.Controls.Add(novoControle);

                // Garante que fique na frente
                novoControle.BringToFront();

                _controleAtual = novoControle;

                // ==========================================
                // ATUALIZAR BOTÃO ATIVO
                // ==========================================

                AtualizarBotaoAtivo(botao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir a tela:\n\n{ex.Message}",
                    "Erro de Navegação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                pnlPanel.ResumeLayout();
            }
        }

        // ==========================================
        // ESTILO DO BOTÃO ATIVO
        // ==========================================
        private void AtualizarBotaoAtivo(Guna2Button? botao)
        {
            // ==========================================
            // RESETAR BOTÃO ANTERIOR
            // ==========================================

            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor = Color.Transparent;

                _botaoAtivo.ForeColor = Color.White;

                _botaoAtivo.CustomBorderColor =
                    Color.Transparent;
            }

            // ==========================================
            // DEFINIR NOVO BOTÃO
            // ==========================================

            _botaoAtivo = botao;

            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor =
                    Color.FromArgb(212, 112, 74);

                _botaoAtivo.ForeColor =
                    Color.White;

                _botaoAtivo.CustomBorderColor =
                    Color.FromArgb(212, 112, 74);
            }
        }

        // ==========================================
        // BOTÃO DASHBOARD
        // ==========================================
        private void btnDashboard_Click(
            object sender,
            EventArgs e)
        {
            NavegarParaDashboard();
        }

        // ==========================================
        // BOTÃO DOCES
        // ==========================================
        private void btnDoce_Click(
            object sender,
            EventArgs e)
        {
            Navegar(
                new DoceUserControl(),
                btnDoce
            );
        }

        // ==========================================
        // BOTÃO CATEGORIAS
        // ==========================================
        private void btnCategoria_Click(
            object sender,
            EventArgs e)
        {
            Navegar(
                new CategoriasUserControl(),
                btnCategoria
            );
        }

        // ==========================================
        // BOTÃO PEDIDOS
        // ==========================================
        private void btnPedidos_Click(
            object sender,
            EventArgs e)
        {
            Navegar(
                new PedidosUserControl(),
                btnPedidos
            );
        }

        // ==========================================
        // BOTÃO USUÁRIOS
        // ==========================================
        private void btnUsuario_Click(
            object sender,
            EventArgs e)
        {
            Navegar(
                new UsuarioUserControl(),
                btnUsuario
            );
        }

        // ==========================================
        // LOGOUT
        // ==========================================
        private async void lblSair_Click(
            object sender,
            EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                if (_authService != null)
                {
                    await _authService.LogoutAsync();
                }
            }
            catch
            {
                // Mesmo se a API falhar,
                // a sessão local será encerrada.
            }
            finally
            {
                SessionManager.Instance.Clear();

                Close();
            }
        }
    }
}