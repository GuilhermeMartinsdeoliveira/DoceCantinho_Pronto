using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class PerfilForm : Form
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================

        private readonly AuthApiService _authService;

        // ============================================================
        // FOTO
        // ============================================================

        private Image? _fotoAtual;
        private bool _fotoFoiAlterada;

        // ============================================================
        // SENHAS
        // ============================================================

        private bool _mostrarSenhaAtual;
        private bool _mostrarNovaSenha;
        private bool _mostrarConfirmarSenha;

        // ============================================================
        // ARRASTAR FORM SEM BORDA
        // ============================================================

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public PerfilForm()
        {
            InitializeComponent();

            _authService = new AuthApiService();

            // --------------------------------------------------------
            // FORMULÁRIO
            // --------------------------------------------------------

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            ConfigurarFormulario();
            ConfigurarEventos();
            CarregarPerfil();
        }

        // ============================================================
        // CONFIGURAR FORMULÁRIO
        // ============================================================

        private void ConfigurarFormulario()
        {
            // --------------------------------------------------------
            // FOTO
            // --------------------------------------------------------

            pictureFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureFoto.Visible = false;

            // --------------------------------------------------------
            // SENHAS
            // --------------------------------------------------------

            txtSenhaAtual.UseSystemPasswordChar = true;
            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmarSenha.UseSystemPasswordChar = true;

            _mostrarSenhaAtual = false;
            _mostrarNovaSenha = false;
            _mostrarConfirmarSenha = false;

            // --------------------------------------------------------
            // CURSOR
            // --------------------------------------------------------

            btnAlterarFoto.Cursor = Cursors.Hand;
            btnSalvar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
            btnFechar.Cursor = Cursors.Hand;

            btnMostrarSenha.Cursor = Cursors.Hand;
            btnMostarNovaSenha.Cursor = Cursors.Hand;
            btnMostarConfiSenha.Cursor = Cursors.Hand;

            // --------------------------------------------------------
            // ARRASTAR JANELA
            // --------------------------------------------------------

            pnlCabecalho.MouseDown += PerfilForm_MouseDown;
            lblTitulo.MouseDown += PerfilForm_MouseDown;
            lblSubtitulo.MouseDown += PerfilForm_MouseDown;
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            // --------------------------------------------------------
            // FOTO
            // --------------------------------------------------------

            btnAlterarFoto.Click -= btnAlterarFoto_Click;
            btnAlterarFoto.Click += btnAlterarFoto_Click;

            pictureFoto.Click -= pictureFoto_Click;
            pictureFoto.Click += pictureFoto_Click;

            lblAvatar.Click -= pictureFoto_Click;
            lblAvatar.Click += pictureFoto_Click;

            // --------------------------------------------------------
            // BOTÕES
            // --------------------------------------------------------

            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            btnFechar.Click -= btnFechar_Click;
            btnFechar.Click += btnFechar_Click;

            // --------------------------------------------------------
            // CHECKBOX
            // --------------------------------------------------------

            chkMostrarSenha.CheckedChanged -= chkMostrarSenha_CheckedChanged;
            chkMostrarSenha.CheckedChanged += chkMostrarSenha_CheckedChanged;

            // --------------------------------------------------------
            // OLHOS DAS SENHAS
            // --------------------------------------------------------

            btnMostrarSenha.Click -= btnMostrarSenha_Click;
            btnMostrarSenha.Click += btnMostrarSenha_Click;

            btnMostarNovaSenha.Click -= btnMostarNovaSenha_Click;
            btnMostarNovaSenha.Click += btnMostarNovaSenha_Click;

            btnMostarConfiSenha.Click -= btnMostarConfiSenha_Click;
            btnMostarConfiSenha.Click += btnMostarConfiSenha_Click;
        }

        // ============================================================
        // CARREGAR PERFIL
        // ============================================================

        private void CarregarPerfil()
        {
            var usuario = SessionManager.Instance.CurrentUser;

            if (usuario == null)
            {
                Close();
                return;
            }

            // --------------------------------------------------------
            // DADOS DA CONTA
            // --------------------------------------------------------

            txtNome.Text =
                usuario.Nome ?? string.Empty;

            txtEmail.Text =
                usuario.Email ?? string.Empty;

            // --------------------------------------------------------
            // CABEÇALHO
            // --------------------------------------------------------

            lblNomeUsuario.Text =
                string.IsNullOrWhiteSpace(usuario.Nome)
                    ? "Usuário"
                    : usuario.Nome;

            lblEmail.Text =
                usuario.Email ?? string.Empty;

            lblPerfil.Text =
                usuario.IsAdmin
                    ? "Administrador"
                    : "Usuário Comum";

            lblPerfilValor.Text =
                usuario.IsAdmin
                    ? "Administrador"
                    : "Usuário Comum";

            // --------------------------------------------------------
            // FOTO
            // --------------------------------------------------------

            if (!string.IsNullOrWhiteSpace(usuario.FotoPerfil))
            {
                try
                {
                    Image imagem =
                        ConverterBase64ParaImagem(
                            usuario.FotoPerfil
                        );

                    _fotoAtual = imagem;

                    pictureFoto.Image = imagem;
                    pictureFoto.Visible = true;
                    lblAvatar.Visible = false;
                }
                catch
                {
                    MostrarAvatarPadrao();
                }
            }
            else
            {
                MostrarAvatarPadrao();
            }
        }

        // ============================================================
        // AVATAR PADRÃO
        // ============================================================

        private void MostrarAvatarPadrao()
        {
            if (pictureFoto.Image != null)
            {
                pictureFoto.Image = null;
            }

            if (_fotoAtual != null)
            {
                _fotoAtual.Dispose();
                _fotoAtual = null;
            }

            pictureFoto.Visible = false;
            lblAvatar.Visible = true;

            lblAvatar.Text =
                ObterIniciaisUsuario();

            lblAvatar.BackColor =
                Color.FromArgb(207, 132, 106);

            lblAvatar.ForeColor =
                Color.White;
        }

        // ============================================================
        // OBTER INICIAIS
        // ============================================================

        private string ObterIniciaisUsuario()
        {
            var usuario =
                SessionManager.Instance.CurrentUser;

            if (usuario == null)
                return "U";

            string nome =
                usuario.Nome?.Trim() ?? string.Empty;

            // --------------------------------------------------------
            // SEM NOME
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(nome))
            {
                string email =
                    usuario.Email?.Trim() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(email))
                {
                    return email
                        .Substring(0, 1)
                        .ToUpper();
                }

                return "U";
            }

            // --------------------------------------------------------
            // SEPARAR NOME
            // --------------------------------------------------------

            string[] partes =
                nome.Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries
                );

            // --------------------------------------------------------
            // APENAS UMA PALAVRA
            // --------------------------------------------------------

            if (partes.Length == 1)
            {
                return partes[0]
                    .Substring(0, 1)
                    .ToUpper();
            }

            // --------------------------------------------------------
            // PRIMEIRA + ÚLTIMA
            // --------------------------------------------------------

            return (
                partes[0].Substring(0, 1) +
                partes[^1].Substring(0, 1)
            ).ToUpper();
        }

        // ============================================================
        // BASE64 → IMAGEM
        // ============================================================

        private Image ConverterBase64ParaImagem(string base64)
        {
            string valor =
                base64.Trim();

            // --------------------------------------------------------
            // REMOVE DATA URI
            // --------------------------------------------------------

            if (valor.Contains(","))
            {
                valor =
                    valor.Substring(
                        valor.IndexOf(",") + 1
                    );
            }

            byte[] bytes =
                Convert.FromBase64String(valor);

            using var ms =
                new MemoryStream(bytes);

            using var original =
                Image.FromStream(ms);

            // IMPORTANTE:
            // cria uma cópia independente do MemoryStream.
            return new Bitmap(original);
        }

        // ============================================================
        // ALTERAR FOTO
        // ============================================================

        private void btnAlterarFoto_Click(
            object? sender,
            EventArgs e)
        {
            using OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Title =
                "Selecionar foto de perfil";

            dialog.Filter =
                "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            dialog.Multiselect = false;

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var original =
                    Image.FromFile(
                        dialog.FileName
                    );

                Image novaImagem =
                    RedimensionarImagem(
                        original,
                        512,
                        512
                    );

                // ----------------------------------------------------
                // DESCARTAR FOTO ANTERIOR
                // ----------------------------------------------------

                if (pictureFoto.Image != null)
                {
                    pictureFoto.Image = null;
                }

                if (_fotoAtual != null)
                {
                    _fotoAtual.Dispose();
                    _fotoAtual = null;
                }

                // ----------------------------------------------------
                // NOVA FOTO
                // ----------------------------------------------------

                _fotoAtual =
                    novaImagem;

                pictureFoto.Image =
                    novaImagem;

                pictureFoto.Visible =
                    true;

                lblAvatar.Visible =
                    false;

                _fotoFoiAlterada =
                    true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar a imagem.\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CLIQUE NA FOTO
        // ============================================================

        private void pictureFoto_Click(
            object? sender,
            EventArgs e)
        {
            btnAlterarFoto_Click(
                sender,
                e
            );
        }

        // ============================================================
        // REDIMENSIONAR IMAGEM
        // ============================================================

        private Image RedimensionarImagem(
            Image imagem,
            int larguraMaxima,
            int alturaMaxima)
        {
            double escala =
                Math.Min(
                    (double)larguraMaxima /
                    imagem.Width,

                    (double)alturaMaxima /
                    imagem.Height
                );

            if (escala > 1)
                escala = 1;

            int largura =
                Math.Max(
                    1,
                    (int)(
                        imagem.Width *
                        escala
                    )
                );

            int altura =
                Math.Max(
                    1,
                    (int)(
                        imagem.Height *
                        escala
                    )
                );

            var novaImagem =
                new Bitmap(
                    largura,
                    altura
                );

            using Graphics g =
                Graphics.FromImage(
                    novaImagem
                );

            g.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            g.SmoothingMode =
                SmoothingMode.HighQuality;

            g.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            g.CompositingQuality =
                CompositingQuality.HighQuality;

            g.DrawImage(
                imagem,
                new Rectangle(
                    0,
                    0,
                    largura,
                    altura
                )
            );

            return novaImagem;
        }

        // ============================================================
        // IMAGEM → BASE64
        // ============================================================

        private string ConverterImagemParaBase64(
            Image imagem)
        {
            using var ms =
                new MemoryStream();

            using var bitmap =
                new Bitmap(imagem);

            bitmap.Save(
                ms,
                System.Drawing.Imaging.ImageFormat.Jpeg
            );

            return Convert.ToBase64String(
                ms.ToArray()
            );
        }

        // ============================================================
        // MOSTRAR / OCULTAR SENHA ATUAL
        // ============================================================

        private void btnMostrarSenha_Click(
            object? sender,
            EventArgs e)
        {
            _mostrarSenhaAtual =
                !_mostrarSenhaAtual;

            txtSenhaAtual.UseSystemPasswordChar =
                !_mostrarSenhaAtual;

            btnMostrarSenha.Text =
                _mostrarSenhaAtual
                    ? "◉"
                    : "👁";
        }

        // ============================================================
        // MOSTRAR / OCULTAR NOVA SENHA
        // ============================================================

        private void btnMostarNovaSenha_Click(
            object? sender,
            EventArgs e)
        {
            _mostrarNovaSenha =
                !_mostrarNovaSenha;

            txtNovaSenha.UseSystemPasswordChar =
                !_mostrarNovaSenha;

            btnMostarNovaSenha.Text =
                _mostrarNovaSenha
                    ? "◉"
                    : "👁";
        }

        // ============================================================
        // MOSTRAR / OCULTAR CONFIRMAÇÃO
        // ============================================================

        private void btnMostarConfiSenha_Click(
            object? sender,
            EventArgs e)
        {
            _mostrarConfirmarSenha =
                !_mostrarConfirmarSenha;

            txtConfirmarSenha.UseSystemPasswordChar =
                !_mostrarConfirmarSenha;

            btnMostarConfiSenha.Text =
                _mostrarConfirmarSenha
                    ? "◉"
                    : "👁";
        }

        // ============================================================
        // CHECKBOX - MOSTRAR TODAS
        // ============================================================

        private void chkMostrarSenha_CheckedChanged(
            object? sender,
            EventArgs e)
        {
            bool mostrar =
                chkMostrarSenha.Checked;

            _mostrarSenhaAtual = mostrar;
            _mostrarNovaSenha = mostrar;
            _mostrarConfirmarSenha = mostrar;

            txtSenhaAtual.UseSystemPasswordChar =
                !mostrar;

            txtNovaSenha.UseSystemPasswordChar =
                !mostrar;

            txtConfirmarSenha.UseSystemPasswordChar =
                !mostrar;

            btnMostrarSenha.Text =
                mostrar ? "◉" : "👁";

            btnMostarNovaSenha.Text =
                mostrar ? "◉" : "👁";

            btnMostarConfiSenha.Text =
                mostrar ? "◉" : "👁";
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private async void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            // --------------------------------------------------------
            // VALIDAR NOME
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show(
                    "Informe o nome.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNome.Focus();
                return;
            }

            // --------------------------------------------------------
            // VALIDAR E-MAIL
            // --------------------------------------------------------

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show(
                    "Informe o e-mail.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }

            // --------------------------------------------------------
            // VERIFICAR ALTERAÇÃO DE SENHA
            // --------------------------------------------------------

            bool alterandoSenha =
                !string.IsNullOrWhiteSpace(
                    txtNovaSenha.Text
                );

            // --------------------------------------------------------
            // VALIDAR SENHA
            // --------------------------------------------------------

            if (alterandoSenha)
            {
                if (string.IsNullOrWhiteSpace(
                    txtSenhaAtual.Text))
                {
                    MessageBox.Show(
                        "Informe sua senha atual.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSenhaAtual.Focus();
                    return;
                }

                if (txtNovaSenha.Text.Length < 6)
                {
                    MessageBox.Show(
                        "A nova senha deve possuir pelo menos 6 caracteres.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtNovaSenha.Focus();
                    return;
                }

                if (txtNovaSenha.Text !=
                    txtConfirmarSenha.Text)
                {
                    MessageBox.Show(
                        "A confirmação da nova senha não confere.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtConfirmarSenha.Focus();
                    return;
                }
            }

            // --------------------------------------------------------
            // CARREGANDO
            // --------------------------------------------------------

            SetCarregando(true);

            try
            {
                var usuario =
                    SessionManager.Instance.CurrentUser;

                if (usuario == null)
                {
                    MessageBox.Show(
                        "Sessão do usuário não encontrada.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                // ----------------------------------------------------
                // FOTO ATUAL
                // ----------------------------------------------------

                string? fotoBase64 =
                    usuario.FotoPerfil;

                // ----------------------------------------------------
                // FOTO NOVA
                // ----------------------------------------------------

                if (_fotoFoiAlterada &&
                    _fotoAtual != null)
                {
                    fotoBase64 =
                        ConverterImagemParaBase64(
                            _fotoAtual
                        );
                }

                // ----------------------------------------------------
                // DTO
                //
                // Os campos de endereço e telefone não estão
                // disponíveis nesta tela. Portanto, mantemos
                // os valores existentes.
                // ----------------------------------------------------

                var dto =
                    new UpdateProfileRequestDto
                    {
                        Nome =
                            txtNome.Text.Trim(),

                        Email =
                            txtEmail.Text.Trim(),

                        Telefone =
                            usuario.Telefone ?? string.Empty,

                        Logradouro =
                            usuario.Logradouro ?? string.Empty,

                        Numero =
                            usuario.Numero ?? string.Empty,

                        Complemento =
                            usuario.Complemento,

                        Bairro =
                            usuario.Bairro ?? string.Empty,

                        Cidade =
                            usuario.Cidade ?? string.Empty,

                        Estado =
                            usuario.Estado ?? string.Empty,

                        Cep =
                            usuario.Cep ?? string.Empty,

                        FotoPerfil =
                            fotoBase64,

                        CurrentPassword =
                            alterandoSenha
                                ? txtSenhaAtual.Text
                                : null,

                        NewPassword =
                            alterandoSenha
                                ? txtNovaSenha.Text
                                : null
                    };

                // ----------------------------------------------------
                // ENVIAR PARA API
                // ----------------------------------------------------

                var resultado =
                    await _authService
                        .UpdateProfileAsync(dto);

                // ----------------------------------------------------
                // ERRO DA API
                // ----------------------------------------------------

                if (!resultado.Success ||
                    resultado.User == null)
                {
                    MessageBox.Show(
                        string.IsNullOrWhiteSpace(
                            resultado.ErrorMessage)
                            ? "Não foi possível atualizar o perfil."
                            : resultado.ErrorMessage,

                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // ----------------------------------------------------
                // ATUALIZAR SESSÃO
                // ----------------------------------------------------

                SessionManager.Instance.SetUser(
                    resultado.User
                );

                // ----------------------------------------------------
                // SUCESSO
                // ----------------------------------------------------

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao salvar o perfil:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetCarregando(false);
            }
        }

        // ============================================================
        // ESTADO DE CARREGAMENTO
        // ============================================================

        private void SetCarregando(
            bool carregando)
        {
            btnSalvar.Enabled =
                !carregando;

            btnCancelar.Enabled =
                !carregando;

            btnAlterarFoto.Enabled =
                !carregando;

            btnFechar.Enabled =
                !carregando;

            btnMostrarSenha.Enabled =
                !carregando;

            btnMostarNovaSenha.Enabled =
                !carregando;

            btnMostarConfiSenha.Enabled =
                !carregando;

            Cursor =
                carregando
                    ? Cursors.WaitCursor
                    : Cursors.Default;
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // FECHAR
        // ============================================================

        private void btnFechar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // ARRASTAR FORM SEM BORDA
        // ============================================================

        private void PerfilForm_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ReleaseCapture();

            SendMessage(
                Handle,
                WM_NCLBUTTONDOWN,
                HTCAPTION,
                0
            );
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            int lParam);

        // ============================================================
        // FECHAMENTO
        // ============================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (pictureFoto.Image != null)
            {
                pictureFoto.Image = null;
            }

            _fotoAtual?.Dispose();
            _fotoAtual = null;

            base.OnFormClosed(e);
        }
    }
}