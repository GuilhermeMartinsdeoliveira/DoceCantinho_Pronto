using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class UsuarioUserControl : UserControl
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================

        private UsuariosApiService? _UsuarioService;

        // ============================================================
        // DADOS
        // ============================================================

        private List<UsuarioResponseDto> _todosUsuarios = new();

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public UsuarioUserControl()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOAD
        // ============================================================

        private async void UsuarioFormDialog_Load(
            object? sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            try
            {
                _UsuarioService =
                    new UsuariosApiService();

                DoceTheme.AplicarEstiloGrid(
                    gridUsuarios);

                ConfigurarPermissões();

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MostrarAvisoUsuario(
                    $"Erro ao iniciar a tela de usuários: {ex.Message}",
                    TipoAvisoUsuario.Erro);
            }
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            if (_UsuarioService == null)
                return;

            try
            {
                Cursor =
                    Cursors.WaitCursor;

                var usuarios =
                    await _UsuarioService
                        .GetAllAsync();

                gridUsuarios.Rows.Clear();

                _todosUsuarios =
                    usuarios ??
                    new List<UsuarioResponseDto>();

                foreach (var u in _todosUsuarios)
                {
                    gridUsuarios.Rows.Add(
                        u.Id,
                        u.Email,
                        u.PerfilPrincipal);
                }

                AtualizarCardsResumo();
            }
            catch (Exception ex)
            {
                MostrarAvisoUsuario(
                    $"Erro ao carregar usuários: {ex.Message}",
                    TipoAvisoUsuario.Erro);
            }
            finally
            {
                Cursor =
                    Cursors.Default;
            }
        }

        // ============================================================
        // CARDS DE RESUMO
        // ============================================================

        private void AtualizarCardsResumo()
        {
            // Os cards atuais são controlados pelo Designer.
        }

        // ============================================================
        // PERMISSÕES
        // ============================================================

        private void ConfigurarPermissões()
        {
            bool isAdmin = false;

            try
            {
                isAdmin =
                    SessionManager.Instance.IsAdmin;
            }
            catch
            {
                isAdmin = true;
            }

            btnNovo.Enabled =
                isAdmin;

            btnExcluir.Enabled =
                isAdmin;
        }

        // ============================================================
        // PESQUISA
        // ============================================================

        private void txtPesquisar_TextChanged(
            object sender,
            EventArgs e)
        {
            FiltrarUsuarios(
                txtPesquisar.Text);
        }

        private void FiltrarUsuarios(
            string filtro)
        {
            filtro =
                filtro.Trim();

            IEnumerable<UsuarioResponseDto>
                usuariosFiltrados;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                usuariosFiltrados =
                    _todosUsuarios;
            }
            else
            {
                usuariosFiltrados =
                    _todosUsuarios
                        .Where(u =>
                            !string.IsNullOrWhiteSpace(
                                u.Email) &&
                            u.Email.Contains(
                                filtro,
                                StringComparison
                                    .OrdinalIgnoreCase));
            }

            gridUsuarios.Rows.Clear();

            foreach (var u in usuariosFiltrados)
            {
                gridUsuarios.Rows.Add(
                    u.Id,
                    u.Email,
                    u.PerfilPrincipal);
            }
        }

        // ============================================================
        // NOVO USUÁRIO
        // ============================================================

        private async void btnNovo_Click(
            object sender,
            EventArgs e)
        {
            if (_UsuarioService == null)
                return;

            using var form =
                new DoceCantinho.Desktop1.Forms
                    .UsuarioFormDialog();

            if (form.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            if (form.UsuarioDto == null)
                return;

            try
            {
                var result =
                    await _UsuarioService
                        .CreateAsync(
                            form.UsuarioDto);

                if (result.Success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoUsuario(
                        "Usuário criado com sucesso!",
                        TipoAvisoUsuario.Sucesso);
                }
                else
                {
                    MostrarAvisoUsuario(
                        result.ErrorMessage ??
                        "Não foi possível criar o usuário.",
                        TipoAvisoUsuario.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoUsuario(
                    $"Erro ao criar usuário: {ex.Message}",
                    TipoAvisoUsuario.Erro);
            }
        }

        // ============================================================
        // EXCLUIR USUÁRIO
        // ============================================================

        private async void btnExcluir_Click(
            object sender,
            EventArgs e)
        {
            if (_UsuarioService == null)
                return;

            var usuario =
                ObterUsuarioSelecionado();

            if (usuario == null)
            {
                MostrarAvisoUsuario(
                    "Selecione um usuário para excluir.",
                    TipoAvisoUsuario.Aviso);

                return;
            }

            // ========================================================
            // CONFIRMAÇÃO PERSONALIZADA
            // ========================================================

            using (var confirmar =
                new DoceCantinho.Desktop.Forms
                    .ConfirmarExclusaoForm(
                        "usuário",
                        usuario.Email))
            {
                var resultado =
                    confirmar.ShowDialog(
                        FindForm());

                if (resultado !=
                    DialogResult.OK)
                {
                    return;
                }
            }

            // ========================================================
            // EXCLUSÃO
            // ========================================================

            try
            {
                var (success, error) =
                    await _UsuarioService
                        .DeleteAsync(
                            usuario.Id);

                if (success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoUsuario(
                        "Usuário excluído com sucesso!",
                        TipoAvisoUsuario.Sucesso);
                }
                else
                {
                    MostrarAvisoUsuario(
                        error ??
                        "Não foi possível excluir o usuário.",
                        TipoAvisoUsuario.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoUsuario(
                    $"Erro ao excluir usuário: {ex.Message}",
                    TipoAvisoUsuario.Erro);
            }
        }

        // ============================================================
        // USUÁRIO SELECIONADO
        // ============================================================

        private UsuarioResponseDto?
            ObterUsuarioSelecionado()
        {
            if (gridUsuarios.SelectedRows.Count == 0)
                return null;

            var row =
                gridUsuarios.SelectedRows[0];

            var id =
                row.Cells["colId"]
                    .Value?
                    .ToString();

            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _todosUsuarios
                .FirstOrDefault(
                    u => string.Equals(
                        u.Id,
                        id,
                        StringComparison
                            .OrdinalIgnoreCase));
        }

        // ============================================================
        // ATUALIZAR
        // ============================================================

        private async void btnAtualizar_Click(
            object sender,
            EventArgs e)
        {
            await CarregarDadosAsync();
        }

        // ============================================================
        // EDITAR
        // ============================================================

        private async void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (_UsuarioService == null)
                return;

            var usuario =
                ObterUsuarioSelecionado();

            if (usuario == null)
            {
                MostrarAvisoUsuario(
                    "Selecione um usuário para editar.",
                    TipoAvisoUsuario.Aviso);

                return;
            }

            using var form =
                new DoceCantinho.Desktop1.Forms
                    .UsuarioFormDialog(
                        usuario);

            if (form.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            if (form.UsuarioUpdateDto == null)
                return;

            try
            {
                var (success, _, error) =
                    await _UsuarioService
                        .UpdateAsync(
                            usuario.Id,
                            form.UsuarioUpdateDto);

                if (success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoUsuario(
                        "Usuário atualizado com sucesso!",
                        TipoAvisoUsuario.Sucesso);
                }
                else
                {
                    MostrarAvisoUsuario(
                        error ??
                        "Não foi possível atualizar o usuário.",
                        TipoAvisoUsuario.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoUsuario(
                    $"Erro ao atualizar usuário: {ex.Message}",
                    TipoAvisoUsuario.Erro);
            }
        }

        // ============================================================
        // TIPOS DE AVISO
        // ============================================================

        private enum TipoAvisoUsuario
        {
            Sucesso,
            Aviso,
            Erro
        }

        // ============================================================
        // AVISO PERSONALIZADO
        // ============================================================

        private void MostrarAvisoUsuario(
            string mensagem,
            TipoAvisoUsuario tipo)
        {
            try
            {
                foreach (
                    Control controle
                    in Controls
                        .OfType<Panel>()
                        .ToList())
                {
                    if (controle.Name ==
                        "pnlAvisoUsuario")
                    {
                        Controls.Remove(
                            controle);

                        controle.Dispose();
                    }
                }

                var pnlAviso =
                    new Guna.UI2.WinForms
                        .Guna2Panel
                    {
                        Name =
                            "pnlAvisoUsuario",

                        Size =
                            new Size(
                                420,
                                62),

                        BorderRadius = 12,

                        Anchor =
                            AnchorStyles.Top |
                            AnchorStyles.Right,

                        FillColor =
                            Color.White,

                        ShadowDecoration =
                        {
                            Enabled = true,
                            Depth = 8,
                            BorderRadius = 12
                        }
                    };

                pnlAviso.Location =
                    new Point(
                        Math.Max(
                            10,
                            Width -
                            pnlAviso.Width -
                            20),
                        20);

                Color corPrincipal;
                string titulo;

                switch (tipo)
                {
                    case TipoAvisoUsuario.Sucesso:

                        corPrincipal =
                            Color.FromArgb(
                                46,
                                160,
                                67);

                        titulo =
                            "Sucesso";

                        break;

                    case TipoAvisoUsuario.Aviso:

                        corPrincipal =
                            Color.FromArgb(
                                230,
                                155,
                                45);

                        titulo =
                            "Atenção";

                        break;

                    default:

                        corPrincipal =
                            Color.FromArgb(
                                200,
                                70,
                                70);

                        titulo =
                            "Erro";

                        break;
                }

                var lblTituloAviso =
                    new Label
                    {
                        AutoSize = false,

                        Location =
                            new Point(
                                18,
                                10),

                        Size =
                            new Size(
                                120,
                                20),

                        Text =
                            titulo,

                        Font =
                            new Font(
                                "Segoe UI",
                                10F,
                                FontStyle.Bold),

                        ForeColor =
                            corPrincipal
                    };

                var lblMensagemAviso =
                    new Label
                    {
                        AutoSize = false,

                        Location =
                            new Point(
                                18,
                                30),

                        Size =
                            new Size(
                                350,
                                24),

                        Text =
                            mensagem,

                        Font =
                            new Font(
                                "Segoe UI",
                                9F),

                        ForeColor =
                            Color.FromArgb(
                                70,
                                70,
                                70),

                        AutoEllipsis =
                            true
                    };

                var btnFechar =
                    new Guna.UI2.WinForms
                        .Guna2Button
                    {
                        Size =
                            new Size(
                                28,
                                28),

                        Location =
                            new Point(
                                380,
                                8),

                        Text =
                            "×",

                        Font =
                            new Font(
                                "Segoe UI",
                                14F),

                        ForeColor =
                            Color.FromArgb(
                                100,
                                100,
                                100),

                        FillColor =
                            Color.Transparent,

                        BorderRadius =
                            8
                    };

                btnFechar.HoverState.FillColor =
                    Color.FromArgb(
                        245,
                        245,
                        245);

                btnFechar.HoverState.ForeColor =
                    Color.Black;

                btnFechar.Click +=
                    (_, __) =>
                    {
                        if (!pnlAviso.IsDisposed)
                        {
                            Controls.Remove(
                                pnlAviso);

                            pnlAviso.Dispose();
                        }
                    };

                pnlAviso.Controls.Add(
                    lblTituloAviso);

                pnlAviso.Controls.Add(
                    lblMensagemAviso);

                pnlAviso.Controls.Add(
                    btnFechar);

                Controls.Add(
                    pnlAviso);

                pnlAviso.BringToFront();

                var timer =
                    new System.Windows.Forms.Timer
                    {
                        Interval = 3500
                    };

                timer.Tick +=
                    (_, __) =>
                    {
                        timer.Stop();

                        timer.Dispose();

                        if (!pnlAviso.IsDisposed)
                        {
                            Controls.Remove(
                                pnlAviso);

                            pnlAviso.Dispose();
                        }
                    };

                timer.Start();
            }
            catch
            {
                // Não interrompe a operação
                // se o aviso visual falhar.
            }
        }
    }
}