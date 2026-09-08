using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class ConfirmarExclusaoForm : Form
    {
        private readonly string _tipoItem;
        private readonly string _identificacao;

        private Guna2Button? _btnFechar;
        private Guna2BorderlessForm? _borderlessForm;
        private Guna2ShadowForm? _shadowForm;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        // ==========================================================
        // CONSTRUTOR
        // ==========================================================

        public ConfirmarExclusaoForm(
            string tipoItem,
            string identificacao)
        {
            _tipoItem =
                string.IsNullOrWhiteSpace(tipoItem)
                    ? "item"
                    : tipoItem.Trim();

            _identificacao =
                string.IsNullOrWhiteSpace(identificacao)
                    ? "selecionado"
                    : identificacao.Trim();

            InitializeComponent();

            ConfigurarFormulario();
            ConfigurarEventos();
            CriarBotaoFechar();
            ConfigurarJanela();
        }

        // ==========================================================
        // CONFIGURAR JANELA
        // ==========================================================

        private void ConfigurarJanela()
        {
            FormBorderStyle =
                FormBorderStyle.None;

            StartPosition =
                FormStartPosition.CenterParent;

            MaximizeBox = false;
            MinimizeBox = false;

            BackColor =
                Color.FromArgb(
                    248,
                    245,
                    242);

            // ======================================================
            // BORDA ARREDONDADA
            // ======================================================

            _borderlessForm =
                new Guna2BorderlessForm();

            _borderlessForm.ContainerControl =
                this;

            _borderlessForm.BorderRadius =
                18;

            _borderlessForm.TransparentWhileDrag =
                true;

            // ======================================================
            // SOMBRA
            // ======================================================

            _shadowForm =
                new Guna2ShadowForm();

            _shadowForm.TargetForm =
                this;
        }

        // ==========================================================
        // CONFIGURAR FORMULÁRIO
        // ==========================================================

        private void ConfigurarFormulario()
        {
            string tipo = ObterTipoCapitalizado();

            lblTitulo.Text =
                $"Excluir {tipo}";

            lblSubtitulo.Text =
                "Esta ação não poderá ser desfeita.";

            lblPergunta.Text =
                CriarPergunta();

            lblMensagem.Text =
                CriarMensagem();

            // ======================================================
            // ARRASTAR PELO CABEÇALHO
            // ======================================================

            pnlCabecalho.MouseDown +=
                ConfirmarExclusaoForm_MouseDown;

            lblTitulo.MouseDown +=
                ConfirmarExclusaoForm_MouseDown;

            lblSubtitulo.MouseDown +=
                ConfirmarExclusaoForm_MouseDown;
        }

        // ==========================================================
        // TIPO CAPITALIZADO
        // ==========================================================

        private string ObterTipoCapitalizado()
        {
            if (string.IsNullOrWhiteSpace(_tipoItem))
                return "Item";

            return char.ToUpper(
                       _tipoItem[0]) +
                   _tipoItem.Substring(1);
        }

        // ==========================================================
        // ARTIGO
        // ==========================================================

        private string ObterArtigo()
        {
            return _tipoItem.ToLowerInvariant() switch
            {
                "doce" => "o",
                "categoria" => "a",
                "usuário" => "o",
                "usuario" => "o",
                "pedido" => "o",
                _ => "o"
            };
        }

        // ==========================================================
        // IDENTIFICAÇÃO FORMATADA
        // ==========================================================

        private string ObterIdentificacaoFormatada()
        {
            if (_tipoItem.Equals(
                "pedido",
                StringComparison.OrdinalIgnoreCase))
            {
                if (_identificacao.StartsWith("#"))
                    return _identificacao;

                return $"#{_identificacao}";
            }

            return $"\"{_identificacao}\"";
        }

        // ==========================================================
        // PERGUNTA
        // ==========================================================

        private string CriarPergunta()
        {
            string artigo =
                ObterArtigo();

            string tipo =
                _tipoItem.ToLowerInvariant();

            string identificacao =
                ObterIdentificacaoFormatada();

            return
                $"Deseja excluir {artigo} {tipo} {identificacao}?";
        }

        // ==========================================================
        // MENSAGEM
        // ==========================================================

        private string CriarMensagem()
        {
            string artigo =
                ObterArtigo();

            string tipo =
                _tipoItem.ToLowerInvariant();

            string identificacao =
                ObterIdentificacaoFormatada();

            return
                $"{ObterTipoCapitalizado()} " +
                $"{identificacao} será removido permanentemente do " +
                $"sistema.\n" +
                "Essa ação não poderá ser desfeita.";
        }

        // ==========================================================
        // EVENTOS
        // ==========================================================

        private void ConfigurarEventos()
        {
            btnCancelar.Click -=
                btnCancelar_Click;

            btnCancelar.Click +=
                btnCancelar_Click;

            btnExcluir.Click -=
                btnExcluir_Click;

            btnExcluir.Click +=
                btnExcluir_Click;
        }

        // ==========================================================
        // BOTÃO X
        // ==========================================================

        private void CriarBotaoFechar()
        {
            if (_btnFechar != null)
                return;

            _btnFechar =
                new Guna2Button
                {
                    Name =
                        "btnFecharExclusao",

                    Text =
                        "×",

                    Size =
                        new Size(
                            42,
                            36),

                    Location =
                        new Point(
                            ClientSize.Width - 50,
                            7),

                    Anchor =
                        AnchorStyles.Top |
                        AnchorStyles.Right,

                    BorderRadius =
                        8,

                    FillColor =
                        Color.Transparent,

                    ForeColor =
                        Color.FromArgb(
                            225,
                            210,
                            204),

                    Font =
                        new Font(
                            "Segoe UI",
                            18F,
                            FontStyle.Regular),

                    Cursor =
                        Cursors.Hand,

                    Padding =
                        new Padding(
                            0,
                            0,
                            0,
                            3)
                };

            _btnFechar.HoverState.FillColor =
                Color.FromArgb(
                    145,
                    55,
                    55);

            _btnFechar.HoverState.ForeColor =
                Color.White;

            _btnFechar.PressedColor =
                Color.FromArgb(
                    120,
                    45,
                    45);

            _btnFechar.Click +=
                BtnFechar_Click;

            Controls.Add(
                _btnFechar);

            _btnFechar.BringToFront();

            Resize +=
                ConfirmarExclusaoForm_Resize;
        }

        // ==========================================================
        // POSICIONAR X
        // ==========================================================

        private void ConfirmarExclusaoForm_Resize(
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
                    7);

            _btnFechar.BringToFront();
        }

        // ==========================================================
        // X
        // ==========================================================

        private void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ==========================================================
        // CANCELAR
        // ==========================================================

        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ==========================================================
        // CONFIRMAR EXCLUSÃO
        // ==========================================================

        private void btnExcluir_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.OK;

            Close();
        }

        // ==========================================================
        // ARRASTAR
        // ==========================================================

        private void ConfirmarExclusaoForm_MouseDown(
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
                0);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            int lParam);

        // ==========================================================
        // FECHAMENTO
        // ==========================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (_btnFechar != null)
            {
                _btnFechar.Click -=
                    BtnFechar_Click;

                _btnFechar.Dispose();

                _btnFechar = null;
            }

            _shadowForm = null;
            _borderlessForm = null;

            base.OnFormClosed(e);
        }
    }
}