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
        // BOTÕES DE CONTROLE DA JANELA
        // ==========================================
        private Guna2Button? _btnFechar;
        private Guna2Button? _btnMaximizar;
        private Guna2Button? _btnMinimizar;

        public MainForm()
        {
            InitializeComponent();

            // Garante que o formulário continue sem
            // a borda padrão do Windows.
            FormBorderStyle = FormBorderStyle.None;

            // Cria os botões de controle no canto superior direito.
            CriarBotoesJanela();
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
        // CRIAR BOTÕES DE CONTROLE DA JANELA
        // ==========================================
        private void CriarBotoesJanela()
        {
            if (_btnFechar != null)
                return;

            // --- BOTÃO FECHAR (X) ---
            _btnFechar = new Guna2Button();
            _btnFechar.Name = "btnFecharMain";
            _btnFechar.Text = "✕";
            _btnFechar.Size = new Size(40, 36);
            _btnFechar.BorderRadius = 8;
            _btnFechar.FillColor = Color.Transparent;
            _btnFechar.ForeColor = Color.FromArgb(100, 80, 70);
            _btnFechar.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            _btnFechar.Padding = new Padding(0);
            _btnFechar.HoverState.FillColor = Color.FromArgb(215, 60, 60);
            _btnFechar.HoverState.ForeColor = Color.White;
            _btnFechar.Cursor = Cursors.Hand;
            _btnFechar.Click += BtnFechar_Click;

            // --- BOTÃO MAXIMIZAR / RESTAURAR ---
            _btnMaximizar = new Guna2Button();
            _btnMaximizar.Name = "btnMaximizarMain";
            _btnMaximizar.Text = WindowState == FormWindowState.Maximized ? "❐" : "🗖";
            _btnMaximizar.Size = new Size(40, 36);
            _btnMaximizar.BorderRadius = 8;
            _btnMaximizar.FillColor = Color.Transparent;
            _btnMaximizar.ForeColor = Color.FromArgb(100, 80, 70);
            _btnMaximizar.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            _btnMaximizar.Padding = new Padding(0);
            _btnMaximizar.HoverState.FillColor = Color.FromArgb(235, 226, 220);
            _btnMaximizar.HoverState.ForeColor = Color.FromArgb(60, 40, 30);
            _btnMaximizar.Cursor = Cursors.Hand;
            _btnMaximizar.Click += BtnMaximizar_Click;

            // --- BOTÃO MINIMIZAR ---
            _btnMinimizar = new Guna2Button();
            _btnMinimizar.Name = "btnMinimizarMain";
            _btnMinimizar.Text = "🗕";
            _btnMinimizar.Size = new Size(40, 36);
            _btnMinimizar.BorderRadius = 8;
            _btnMinimizar.FillColor = Color.Transparent;
            _btnMinimizar.ForeColor = Color.FromArgb(100, 80, 70);
            _btnMinimizar.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            _btnMinimizar.Padding = new Padding(0);
            _btnMinimizar.HoverState.FillColor = Color.FromArgb(235, 226, 220);
            _btnMinimizar.HoverState.ForeColor = Color.FromArgb(60, 40, 30);
            _btnMinimizar.Cursor = Cursors.Hand;
            _btnMinimizar.Click += BtnMinimizar_Click;

            // Adiciona ao formulário
            Controls.Add(_btnFechar);
            Controls.Add(_btnMaximizar);
            Controls.Add(_btnMinimizar);

            ReposicionarBotoesJanela();

            // Reposiciona quando a janela mudar de tamanho
            Resize -= MainForm_Resize;
            Resize += MainForm_Resize;

            // Suporte a duplo clique para maximizar/restaurar
            guna2Panel1.DoubleClick -= PainelTopo_DoubleClick;
            guna2Panel1.DoubleClick += PainelTopo_DoubleClick;
        }

        // ==========================================
        // REPOSICIONAR BOTÕES DE CONTROLE
        // ==========================================
        private void MainForm_Resize(object? sender, EventArgs e)
        {
            ReposicionarBotoesJanela();
        }

        private void ReposicionarBotoesJanela()
        {
            if (_btnFechar == null)
                return;

            int top = 6;
            int right = ClientSize.Width - 8;

            _btnFechar.Location = new Point(right - _btnFechar.Width, top);
            _btnFechar.BringToFront();

            if (_btnMaximizar != null)
            {
                _btnMaximizar.Location = new Point(_btnFechar.Left - _btnMaximizar.Width - 2, top);
                _btnMaximizar.Text = WindowState == FormWindowState.Maximized ? "❐" : "🗖";
                _btnMaximizar.BringToFront();
            }

            if (_btnMinimizar != null)
            {
                _btnMinimizar.Location = new Point((_btnMaximizar?.Left ?? _btnFechar.Left) - _btnMinimizar.Width - 2, top);
                _btnMinimizar.BringToFront();
            }
        }

        // ==========================================
        // CLIQUE NO BOTÃO MAXIMIZAR / RESTAURAR
        // ==========================================
        private void BtnMaximizar_Click(object? sender, EventArgs e)
        {
            AlternarMaximizar();
        }

        // ==========================================
        // CLIQUE NO BOTÃO MINIMIZAR
        // ==========================================
        private void BtnMinimizar_Click(object? sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // ==========================================
        // DUPLO CLIQUE NO CABEÇALHO PARA MAXIMIZAR
        // ==========================================
        private void PainelTopo_DoubleClick(object? sender, EventArgs e)
        {
            AlternarMaximizar();
        }

        // ==========================================
        // ALTERNAR MAXIMIZADO / RESTAURADO
        // ==========================================
        private void AlternarMaximizar()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }

            ReposicionarBotoesJanela();
        }

        // ==========================================
        // CLIQUE NO X
        // ==========================================
        private async void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            if (!await ConfirmarSaidaAsync())
                return;

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

            // Blog
            btnBlog.Visible = true;
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

            btnBlog.Click -=
                btnBlog_Click;

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

            btnBlog.Click +=
                btnBlog_Click;

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
            if (await ConfirmarSaidaAsync())
            {
                await VoltarParaLoginAsync();
            }
        }

        private async Task<bool> ConfirmarSaidaAsync()
        {
            using var confirmar =
                new ConfirmarLogoutForm();

            DialogResult resultado =
                confirmar.ShowDialog(this);

            return resultado ==
                   DialogResult.Yes;
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
            // LIBERAR CONTROLES DA JANELA
            // ==========================================
            if (_btnFechar != null)
            {
                _btnFechar.Click -= BtnFechar_Click;
                _btnFechar.Dispose();
                _btnFechar = null;
            }

            if (_btnMaximizar != null)
            {
                _btnMaximizar.Click -= BtnMaximizar_Click;
                _btnMaximizar.Dispose();
                _btnMaximizar = null;
            }

            if (_btnMinimizar != null)
            {
                _btnMinimizar.Click -= BtnMinimizar_Click;
                _btnMinimizar.Dispose();
                _btnMinimizar = null;
            }

            base.OnFormClosed(e);
        }

        // ==========================================
        // REDIMENSIONAMENTO NATIVO DE BORDAS
        // ==========================================
        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int BORDER_RESIZE_WIDTH = 8;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal)
            {
                Point cursor = PointToClient(Cursor.Position);

                if (cursor.X <= BORDER_RESIZE_WIDTH && cursor.Y <= BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (cursor.X >= ClientSize.Width - BORDER_RESIZE_WIDTH && cursor.Y <= BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (cursor.X <= BORDER_RESIZE_WIDTH && cursor.Y >= ClientSize.Height - BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (cursor.X >= ClientSize.Width - BORDER_RESIZE_WIDTH && cursor.Y >= ClientSize.Height - BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (cursor.X <= BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTLEFT;
                else if (cursor.X >= ClientSize.Width - BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTRIGHT;
                else if (cursor.Y <= BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTTOP;
                else if (cursor.Y >= ClientSize.Height - BORDER_RESIZE_WIDTH)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        // ==========================================
        // BOTÃO BLOG
        // ==========================================
        private void btnBlog_Click(
            object? sender,
            EventArgs e)
        {
            Navegar(
                new BlogUserControl(),
                btnBlog
            );
        }
    }
}