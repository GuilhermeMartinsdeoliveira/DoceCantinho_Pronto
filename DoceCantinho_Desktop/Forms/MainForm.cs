using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using DoceCantinho.Desktop.UserControls;
using DoceCantinho.Desktop1.UserControls;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        // ==========================================
        // BOTÃO X
        // ==========================================
        private Guna2Button? _btnFechar;

        public MainForm()
        {
            InitializeComponent();

            // Garante que o formulário continue sem
            // a borda padrão do Windows.
            FormBorderStyle = FormBorderStyle.None;

            // Cria o X visual no canto superior direito.
            CriarBotaoFechar();
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
            AtualizarDadosUsuario();

            // ==========================================
            // PERMISSÕES
            // ==========================================
            ConfigurarPermissoes();

            // ==========================================
            // EVENTOS
            // ==========================================
            ConfigurarEventos();

            // ==========================================
            // ABRIR DASHBOARD
            // ==========================================
            NavegarParaDashboard();
        }

        // ==========================================
        // CRIAR BOTÃO X
        // ==========================================
        private void CriarBotaoFechar()
        {
            if (_btnFechar != null)
                return;

            _btnFechar = new Guna2Button();

            _btnFechar.Name = "btnFecharMain";
            _btnFechar.Text = "×";

            _btnFechar.Size = new Size(42, 34);

            // Fica no canto superior direito
            _btnFechar.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            _btnFechar.Location =
                new Point(
                    ClientSize.Width - 48,
                    8
                );

            _btnFechar.BorderRadius = 8;

            _btnFechar.FillColor =
                Color.Transparent;

            _btnFechar.ForeColor =
                Color.FromArgb(
                    224,
                    211,
                    204
                );

            _btnFechar.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Regular
                );

            _btnFechar.HoverState.FillColor =
                Color.FromArgb(
                    170,
                    65,
                    65
                );

            _btnFechar.HoverState.ForeColor =
                Color.White;

            _btnFechar.Cursor =
                Cursors.Hand;

            _btnFechar.Padding =
                new Padding(0, 0, 0, 4);

            _btnFechar.Click +=
                BtnFechar_Click;

            Controls.Add(_btnFechar);

            _btnFechar.BringToFront();

            // Reposiciona automaticamente caso
            // o tamanho da janela mude.
            Resize += MainForm_Resize;
        }

        // ==========================================
        // POSIÇÃO DO X
        // ==========================================
        private void MainForm_Resize(
            object? sender,
            EventArgs e)
        {
            if (_btnFechar == null)
                return;

            _btnFechar.Location =
                new Point(
                    ClientSize.Width -
                    _btnFechar.Width -
                    8,
                    8
                );
        }

        // ==========================================
        // CLIQUE NO X
        // ==========================================
        private async void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            await VoltarParaLoginAsync();
        }

        // ==========================================
        // ATUALIZAR DADOS DO USUÁRIO
        // ==========================================
        private void AtualizarDadosUsuario()
        {
            var usuario =
                SessionManager.Instance.CurrentUser;

            if (usuario == null)
                return;

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
            // FOTO
            // ==========================================
            AtualizarAvatar(usuario.FotoPerfil);
        }

        // ==========================================
        // ATUALIZAR AVATAR
        // ==========================================
        private void AtualizarAvatar(string? fotoBase64)
        {
            // ==========================================
            // LIBERAR FOTO ANTERIOR
            // ==========================================
            if (lblAvatar.Image != null)
            {
                var imagemAnterior =
                    lblAvatar.Image;

                lblAvatar.Image = null;

                imagemAnterior.Dispose();
            }

            // ==========================================
            // SEM FOTO
            // ==========================================
            if (string.IsNullOrWhiteSpace(fotoBase64))
            {
                lblAvatar.Text =
                    ObterInicialUsuario();

                lblAvatar.FillColor =
                    Color.FromArgb(
                        214,
                        126,
                        91
                    );

                return;
            }

            // ==========================================
            // COM FOTO
            // ==========================================
            try
            {
                string base64 =
                    fotoBase64.Trim();

                // Remove o prefixo:
                // data:image/jpeg;base64,...
                if (base64.Contains(","))
                {
                    base64 =
                        base64.Substring(
                            base64.IndexOf(",") + 1
                        );
                }

                byte[] bytes =
                    Convert.FromBase64String(base64);

                using var ms =
                    new MemoryStream(bytes);

                using var imagemOriginal =
                    Image.FromStream(ms);

                using var imagem =
                    new Bitmap(imagemOriginal);

                Bitmap avatar =
                    CriarImagemCircular(
                        imagem,
                        lblAvatar.Width,
                        lblAvatar.Height
                    );

                lblAvatar.Text =
                    string.Empty;

                lblAvatar.FillColor =
                    Color.Transparent;

                lblAvatar.Image =
                    avatar;

                lblAvatar.ImageSize =
                    new Size(
                        lblAvatar.Width,
                        lblAvatar.Height
                    );
            }
            catch
            {
                // ==========================================
                // FOTO INVÁLIDA
                // ==========================================
                lblAvatar.Image = null;

                lblAvatar.Text =
                    ObterInicialUsuario();

                lblAvatar.FillColor =
                    Color.FromArgb(
                        214,
                        126,
                        91
                    );
            }
        }

        // ==========================================
        // OBTER INICIAL DO USUÁRIO
        // ==========================================
        private string ObterInicialUsuario()
        {
            var usuario =
                SessionManager.Instance.CurrentUser;

            if (usuario == null)
                return "U";

            if (!string.IsNullOrWhiteSpace(
                usuario.Nome))
            {
                return usuario.Nome
                    .Trim()
                    .Substring(0, 1)
                    .ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Email))
            {
                return usuario.Email
                    .Trim()
                    .Substring(0, 1)
                    .ToUpper();
            }

            return "U";
        }

        // ==========================================
        // CRIAR IMAGEM CIRCULAR
        // ==========================================
        private Bitmap CriarImagemCircular(
            Image imagemOriginal,
            int larguraDestino,
            int alturaDestino)
        {
            int tamanho =
                Math.Min(
                    larguraDestino,
                    alturaDestino
                );

            var bitmap =
                new Bitmap(
                    tamanho,
                    tamanho
                );

            using Graphics g =
                Graphics.FromImage(bitmap);

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            g.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            g.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            g.CompositingQuality =
                CompositingQuality.HighQuality;

            // ==========================================
            // RECORTE CIRCULAR
            // ==========================================
            using GraphicsPath path =
                new GraphicsPath();

            path.AddEllipse(
                0,
                0,
                tamanho - 1,
                tamanho - 1
            );

            g.SetClip(path);

            g.Clear(
                Color.Transparent
            );

            // ==========================================
            // ESCALA DA IMAGEM
            // ==========================================
            float escala =
                Math.Max(
                    (float)tamanho /
                    imagemOriginal.Width,

                    (float)tamanho /
                    imagemOriginal.Height
                );

            int largura =
                (int)(
                    imagemOriginal.Width *
                    escala
                );

            int altura =
                (int)(
                    imagemOriginal.Height *
                    escala
                );

            int x =
                (tamanho - largura) / 2;

            int y =
                (tamanho - altura) / 2;

            // ==========================================
            // DESENHAR FOTO
            // ==========================================
            g.DrawImage(
                imagemOriginal,
                new Rectangle(
                    x,
                    y,
                    largura,
                    altura
                )
            );

            return bitmap;
        }

        // ==========================================
        // CONFIGURAR PERMISSÕES
        // ==========================================
        private void ConfigurarPermissoes()
        {
            bool isAdmin =
                SessionManager.Instance.IsAdmin;

            btnCategoria.Visible =
                true;
            btnUsuario.Visible =
                isAdmin;

            // Pedidos
            btnPedidos.Visible = true;

            // Doces
            btnDoce.Visible = true;

            // Dashboard
            btnDashboard.Visible = true;
        }

        // ==========================================
        // CONFIGURAR EVENTOS
        // ==========================================
        private void ConfigurarEventos()
        {
            // ==========================================
            // BOTÕES
            // ==========================================
            btnDashboard.Click -=
                btnDashboard_Click;

            btnDoce.Click -=
                btnDoce_Click;

            btnCategoria.Click -=
                btnCategoria_Click;

            btnPedidos.Click -=
                btnPedidos_Click;

            btnUsuario.Click -=
                btnUsuario_Click;

            btnDashboard.Click +=
                btnDashboard_Click;

            btnDoce.Click +=
                btnDoce_Click;

            btnCategoria.Click +=
                btnCategoria_Click;

            btnPedidos.Click +=
                btnPedidos_Click;

            btnUsuario.Click +=
                btnUsuario_Click;

            // ==========================================
            // SAIR
            // ==========================================
            lblSair.Click -=
                lblSair_Click;

            lblSair.Click +=
                lblSair_Click;

            // ==========================================
            // PERFIL
            // ==========================================
            pnlUsuario.Click -=
                pnlUsuario_Click;

            pnlUsuario.Click +=
                pnlUsuario_Click;

            lblAvatar.Click -=
                pnlUsuario_Click;

            lblAvatar.Click +=
                pnlUsuario_Click;

            lblUsuario.Click -=
                pnlUsuario_Click;

            lblUsuario.Click +=
                pnlUsuario_Click;

            lblPerfil.Click -=
                pnlUsuario_Click;

            lblPerfil.Click +=
                pnlUsuario_Click;

            lblSessao.Click -=
                pnlUsuario_Click;

            lblSessao.Click +=
                pnlUsuario_Click;
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
        // NAVEGAÇÃO
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
                    pnlPanel.Controls.Remove(
                        _controleAtual
                    );

                    _controleAtual.Dispose();

                    _controleAtual = null;
                }

                // ==========================================
                // ADICIONAR NOVO CONTROLE
                // ==========================================
                novoControle.Dock =
                    DockStyle.Fill;

                novoControle.Visible =
                    true;

                pnlPanel.Controls.Add(
                    novoControle
                );

                novoControle.BringToFront();

                _controleAtual =
                    novoControle;

                // ==========================================
                // BOTÃO ATIVO
                // ==========================================
                AtualizarBotaoAtivo(
                    botao
                );
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
        // BOTÃO ATIVO
        // ==========================================
        private void AtualizarBotaoAtivo(
            Guna2Button? botao)
        {
            // ==========================================
            // RESETAR BOTÃO ANTIGO
            // ==========================================
            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor =
                    Color.Transparent;

                _botaoAtivo.ForeColor =
                    Color.White;

                _botaoAtivo.CustomBorderColor =
                    Color.Transparent;
            }

            // ==========================================
            // NOVO BOTÃO
            // ==========================================
            _botaoAtivo =
                botao;

            if (_botaoAtivo != null)
            {
                _botaoAtivo.FillColor =
                    Color.FromArgb(
                        212,
                        112,
                        74
                    );

                _botaoAtivo.ForeColor =
                    Color.White;

                _botaoAtivo.CustomBorderColor =
                    Color.FromArgb(
                        212,
                        112,
                        74
                    );
            }
        }

        // ==========================================
        // BOTÃO DASHBOARD
        // ==========================================
        private void btnDashboard_Click(
            object? sender,
            EventArgs e)
        {
            NavegarParaDashboard();
        }

        // ==========================================
        // BOTÃO DOCES
        // ==========================================
        private void btnDoce_Click(
            object? sender,
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
            object? sender,
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
            object? sender,
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
            object? sender,
            EventArgs e)
        {
            Navegar(
                new UsuarioUserControl(),
                btnUsuario
            );
        }

        // ==========================================
        // BOTÃO SAIR
        // ==========================================
        private async void lblSair_Click(
            object? sender,
            EventArgs e)
        {
            var resposta =
                MessageBox.Show(
                    "Deseja realmente sair do sistema?",
                    "Confirmar Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (resposta != DialogResult.Yes)
                return;

            await VoltarParaLoginAsync();
        }

        // ==========================================
        // VOLTAR PARA LOGIN
        // ==========================================
        private async Task VoltarParaLoginAsync()
        {
            try
            {
                // ==========================================
                // LOGOUT NA API
                // ==========================================
                if (_authService != null)
                {
                    await _authService.LogoutAsync();
                }
            }
            catch
            {
                // Mesmo se a API falhar,
                // encerra a sessão local.
            }

            // ==========================================
            // LIMPAR SESSÃO
            // ==========================================
            SessionManager.Instance.Clear();

            // ==========================================
            // ESCONDER MAINFORM
            // ==========================================
            Hide();

            // ==========================================
            // VOLTAR PARA LOGIN
            // ==========================================
            using (var loginForm =
                new LoginForm())
            {
                loginForm.ShowDialog();
            }

            // ==========================================
            // FECHAR MAINFORM ANTIGO
            // ==========================================
            Close();
        }

        // ==========================================
        // ABRIR PERFIL
        // ==========================================
        private void AbrirPerfil()
        {
            using (var perfilForm =
                new PerfilForm())
            {
                perfilForm.ShowDialog(this);
            }

            // ==========================================
            // O PERFIL ATUALIZOU O SESSIONMANAGER
            // ==========================================
            AtualizarDadosUsuario();
        }

        // ==========================================
        // CLIQUE NO USUÁRIO
        // ==========================================
        private void pnlUsuario_Click(
            object? sender,
            EventArgs e)
        {
            AbrirPerfil();
        }

        // ==========================================
        // FECHAMENTO
        // ==========================================
        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            // ==========================================
            // LIBERAR IMAGEM DO AVATAR
            // ==========================================
            if (lblAvatar.Image != null)
            {
                var imagem =
                    lblAvatar.Image;

                lblAvatar.Image = null;

                imagem.Dispose();
            }

            // ==========================================
            // LIBERAR CONTROLE DO X
            // ==========================================
            if (_btnFechar != null)
            {
                _btnFechar.Click -=
                    BtnFechar_Click;

                _btnFechar.Dispose();

                _btnFechar = null;
            }

            base.OnFormClosed(e);
        }
    }
}