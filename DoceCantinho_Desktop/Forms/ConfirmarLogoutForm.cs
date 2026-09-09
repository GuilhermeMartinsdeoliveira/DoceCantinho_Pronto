using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class ConfirmarLogoutForm : Form
    {
        private Guna2Button? _btnFechar;

        public ConfirmarLogoutForm()
        {
            InitializeComponent();

            FormBorderStyle =
                FormBorderStyle.None;

            StartPosition =
                FormStartPosition.CenterParent;

            CriarBotaoFechar();

            pnlCabecalho.MouseDown +=
                PnlCabecalho_MouseDown;

            lblTitulo.MouseDown +=
                PnlCabecalho_MouseDown;
        }

        // ============================================================
        // BOTÃO X
        // ============================================================

        private void CriarBotaoFechar()
        {
            if (_btnFechar != null)
                return;

            _btnFechar =
                new Guna2Button
                {
                    Name = "btnFecharLogout",
                    Text = "×",
                    Size = new Size(36, 32),
                    Location = new Point(
                        ClientSize.Width - 44,
                        8),
                    Anchor =
                        AnchorStyles.Top |
                        AnchorStyles.Right,
                    BorderRadius = 8,
                    FillColor =
                        Color.Transparent,
                    ForeColor =
                        Color.FromArgb(
                            125,
                            100,
                            90),
                    Font =
                        new Font(
                            "Segoe UI",
                            17F),
                    Cursor =
                        Cursors.Hand,
                    TabStop = false
                };

            _btnFechar.HoverState.FillColor =
                Color.FromArgb(
                    245,
                    232,
                    226);

            _btnFechar.HoverState.ForeColor =
                Color.FromArgb(
                    170,
                    75,
                    60);

            _btnFechar.PressedColor =
                Color.FromArgb(
                    235,
                    216,
                    208);

            _btnFechar.Click +=
                BtnFechar_Click;

            Controls.Add(
                _btnFechar);

            _btnFechar.BringToFront();
        }

        // ============================================================
        // FECHAR
        // ============================================================

        private void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // SAIR
        // ============================================================

        private void btnSim_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Yes;

            Close();
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnNao_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.No;

            Close();
        }

        // ============================================================
        // ARRASTAR JANELA
        // ============================================================

        private void PnlCabecalho_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button !=
                MouseButtons.Left)
            {
                return;
            }

            ReleaseCapture();

            SendMessage(
                Handle,
                WM_NCLBUTTONDOWN,
                HTCAPTION,
                0);
        }

        // ============================================================
        // API WINDOWS
        // ============================================================

        private const int WM_NCLBUTTONDOWN =
            0xA1;

        private const int HTCAPTION =
            0x2;

        [System.Runtime.InteropServices.DllImport(
            "user32.dll")]
        private static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport(
            "user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            int lParam);

        // ============================================================
        // REDIMENSIONAMENTO
        // ============================================================

        protected override void OnResize(
            EventArgs e)
        {
            base.OnResize(e);

            if (_btnFechar == null)
                return;

            _btnFechar.Location =
                new Point(
                    ClientSize.Width -
                    _btnFechar.Width -
                    8,
                    8);
        }

        // ============================================================
        // FECHAMENTO
        // ============================================================

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

            base.OnFormClosed(e);
        }
    }
}