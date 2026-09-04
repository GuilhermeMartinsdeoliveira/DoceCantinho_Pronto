using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using DoceCantinho.Desktop.UserControls;
using DoceCantinho.Desktop1.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class MainForm : Form
    {

        private UserControl? _controleAtual;

        /// <summary>
        /// Botão da sidebar atualmente ativo.
        /// </summary>
        private Guna2Button? _botaoAtivo;

        /// <summary>
        /// Serviço de autenticação para logout.
        /// </summary>
        private AuthApiService _authService = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Guard: não executa em tempo de design
            if (DesignMode) return;

            //Instancia o serviço
            _authService = new AuthApiService();

            // Atualiza o título com a versão
            this.Text = $"Doce Cantinho Desktop - {AppConfig.Version}";

            //Preenche dados dinâmicos de sessão no header
            lblUsuario.Text = $"👷‍ {SessionManager.Instance.GetDisplayName()}";
            lblPerfil.Text = SessionManager.Instance.IsAdmin ? "🔑 Administrador" : "👀 Usuário Comum";
            lblPerfil.ForeColor = SessionManager.Instance.IsAdmin
                ? DoceTheme.LaranjaPrimario
                : DoceTheme.AzulVariante;
            lblSessao.Text = $"🟢 {SessionManager.Instance.GetEmail()}";

            // Configura permissões baseadas no perfil do usuário
            ConfigurarPermissoes();

            //Abre o DashBoard como tela inicial
            NavegarParaDashboard();
        }

        private void ConfigurarPermissoes()
        {
            var isAdmin = SessionManager.Instance.IsAdmin;

            btnCategoria.Visible = isAdmin;
            btnUsuario.Visible = isAdmin;
        }

        private void NavegarParaDashboard()
        {
            Navegar(new DashboardUserControl(), btnDashboard);
        }

        private void Navegar(UserControl control, Guna2Button? botao = null)
        {
            //Remove o UserControl anterior
            if (_controleAtual != null)
            {
                pnlPanel.Controls.Remove(_controleAtual);
                _controleAtual.Dispose();
                _controleAtual = null;
            }

            //Adiona o novo UserControl(Tela interna)
            control.Dock = DockStyle.Fill;
            pnlPanel.Controls.Add(control);
            _controleAtual = control;

            AtualizarBotaoAtivo(botao);
        }

        // AtualizarBotaoAtivo: lógica corrigida para trocar corretamente o botão ativo
        private void AtualizarBotaoAtivo(Guna2Button? botao)
        {
            // Reseta estilo do botão previamente ativo (se houver)
            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor = Color.Transparent;
                _botaoAtivo.ForeColor = Color.White;
                _botaoAtivo.CustomBorderColor = Color.Transparent;
            }

            // Define novo botão ativo
            _botaoAtivo = botao;

            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor = Color.FromArgb(212, 112, 74);
                _botaoAtivo.ForeColor = Color.White;
                _botaoAtivo.CustomBorderColor = Color.FromArgb(212, 112, 74);
            }
        }

        private void btnDoce_Click(object sender, EventArgs e) => Navegar(new DoceUserControl(), btnDoce);

        private void btnCategoria_Click(object sender, EventArgs e) => Navegar(new CategoriasUserControl(), btnCategoria);

        // Antes este botão não tinha nenhum evento associado no Designer,
        // então clicar em "Dashboard" na sidebar não fazia nada.
        private void btnDashboard_Click(object sender, EventArgs e) => NavegarParaDashboard();

        private async void lblSair_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes) return;

            try
            {
                await _authService.LogoutAsync();
            }
            catch
            {
                // Mesmo se a API falhar, limpa a sessão local
            }
            finally
            {
                SessionManager.Instance.Clear();
                this.Close();
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e) => Navegar(new UsuarioUserControl(), btnUsuario);

        private void btnPedidos_Click(object sender, EventArgs e) => Navegar(new PedidosUserControl(), btnPedidos);

        private void AbrirPerfil()
        {
            using (PerfilForm perfilForm = new PerfilForm())
            {
                perfilForm.ShowDialog(this);
            }
        }

        private void pnlUsuario_Click(object sender, EventArgs e)
        {
            AbrirPerfil();

        }
    }
}
