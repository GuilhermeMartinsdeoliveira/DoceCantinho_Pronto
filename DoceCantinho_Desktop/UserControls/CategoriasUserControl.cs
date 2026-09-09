using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class CategoriasUserControl : UserControl
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================

        private CategoriasApiService? _categoriasService;

        // ============================================================
        // DADOS
        // ============================================================

        private List<CategoriaResponseDto> _categorias = new();

        private int? _editandoId = null;

        // ============================================================
        // CONSTRUTOR
        // ============================================================

        public CategoriasUserControl()
        {
            InitializeComponent();

            ConfigurarPermissoes();
        }

        // ============================================================
        // PERMISSÕES
        // ============================================================

        private void ConfigurarPermissoes()
        {
            bool isAdmin =
                SessionManager.Instance.IsAdmin;

            // Usuário comum pode visualizar categorias,
            // mas somente administrador pode realizar CRUD.
            btnNovoCat.Visible = isAdmin;

            pnlForm.Visible = false;
        }

        // ============================================================
        // LOAD
        // ============================================================

        private async void CategoriasUserControl_Load(
            object? sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            try
            {
                _categoriasService =
                    new CategoriasApiService();

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MostrarAvisoCategoria(
                    $"Erro ao iniciar a tela de categorias: {ex.Message}",
                    TipoAvisoCategoria.Erro);
            }
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            if (_categoriasService == null)
                return;

            try
            {
                Cursor =
                    Cursors.WaitCursor;

                _categorias =
                    await _categoriasService
                        .GetAllAsync();

                AtualizarTela();
            }
            catch (Exception ex)
            {
                MostrarAvisoCategoria(
                    $"Erro ao carregar categorias: {ex.Message}",
                    TipoAvisoCategoria.Erro);
            }
            finally
            {
                Cursor =
                    Cursors.Default;
            }
        }

        // ============================================================
        // ATUALIZAR TELA
        // ============================================================

        private void AtualizarTela()
        {
            if (pnlCards == null)
                return;

            pnlCards.SuspendLayout();

            try
            {
                pnlCards.Controls.Clear();

                int totalCategorias =
                    _categorias.Count;

                int totalProdutos =
                    _categorias.Sum(
                        c => c.DoceCount);

                lblSubtitulo.Text =
                    $"{totalCategorias} categorias • " +
                    $"{totalProdutos} produtos no total";

                AtualizarResumo();

                foreach (var categoria in _categorias)
                {
                    Panel card =
                        CriarCardCategoria(
                            categoria);

                    pnlCards.Controls.Add(
                        card);
                }

                // Somente administrador vê
                // o card de nova categoria.
                if (SessionManager.Instance.IsAdmin)
                {
                    pnlCards.Controls.Add(
                        CriarCardNovaCategoria());
                }
            }
            finally
            {
                pnlCards.ResumeLayout();
            }
        }

        // ============================================================
        // RESUMO
        // ============================================================

        private void AtualizarResumo()
        {
            Label[] labels =
            {
                lblResumoBolos,
                lblResumoBrigadeiros,
                lblResumoBrownies,
                lblResumoCupcakes,
                lblResumoGourmet
            };

            foreach (Label label in labels)
            {
                label.Text = "";
            }

            if (_categorias.Count == 0)
            {
                lblResumoBolos.Text =
                    "•  Nenhuma categoria";

                return;
            }

            var categoriasOrdenadas =
                _categorias
                    .OrderByDescending(
                        c => c.DoceCount)
                    .Take(5)
                    .ToList();

            for (
                int i = 0;
                i < categoriasOrdenadas.Count &&
                i < labels.Length;
                i++)
            {
                var categoria =
                    categoriasOrdenadas[i];

                labels[i].Text =
                    $"•  {categoria.Name}: " +
                    $"{categoria.DoceCount}";
            }
        }

        // ============================================================
        // CRIAR CARD DA CATEGORIA
        // ============================================================

        private Panel CriarCardCategoria(
            CategoriaResponseDto categoria)
        {
            Panel card =
                new Panel
                {
                    Width = 270,
                    Height = 180,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(
                        0,
                        0,
                        16,
                        14)
                };

            Color cor =
                ObterCorCategoria(
                    categoria.Name);

            // ========================================================
            // ÍCONE
            // ========================================================

            Label icone =
                new Label
                {
                    Text = "✦",

                    Font =
                        new Font(
                            "Segoe UI",
                            15F,
                            FontStyle.Regular),

                    ForeColor = cor,

                    BackColor =
                        Color.FromArgb(
                            250,
                            246,
                            243),

                    TextAlign =
                        ContentAlignment.MiddleCenter,

                    Location =
                        new Point(
                            15,
                            15),

                    Size =
                        new Size(
                            40,
                            40)
                };

            // ========================================================
            // QUANTIDADE SUPERIOR
            // ========================================================

            int quantidadeProdutos =
                categoria.DoceCount;

            Label quantidade =
                new Label
                {
                    Text =
                        quantidadeProdutos == 1
                            ? "1 produto"
                            : $"{quantidadeProdutos} produtos",

                    Font =
                        new Font(
                            "Segoe UI",
                            8F),

                    ForeColor = cor,

                    BackColor =
                        Color.FromArgb(
                            252,
                            247,
                            244),

                    TextAlign =
                        ContentAlignment.MiddleCenter,

                    Location =
                        new Point(
                            178,
                            18),

                    Size =
                        new Size(
                            77,
                            25)
                };

            // ========================================================
            // NOME
            // ========================================================

            Label nome =
                new Label
                {
                    Text =
                        categoria.Name,

                    Font =
                        new Font(
                            "Georgia",
                            11F,
                            FontStyle.Bold),

                    ForeColor =
                        Color.FromArgb(
                            50,
                            35,
                            28),

                    Location =
                        new Point(
                            15,
                            68),

                    AutoSize = true
                };

            // ========================================================
            // DESCRIÇÃO
            // ========================================================

            Label descricao =
                new Label
                {
                    Text =
                        ObterDescricaoCategoria(
                            categoria.Name),

                    Font =
                        new Font(
                            "Segoe UI",
                            8F),

                    ForeColor =
                        Color.FromArgb(
                            120,
                            100,
                            90),

                    Location =
                        new Point(
                            15,
                            91),

                    AutoSize = true
                };

            // ========================================================
            // PRODUTOS CADASTRADOS
            // ========================================================

            Label produtosCadastrados =
                new Label
                {
                    Text =
                        "Produtos cadastrados",

                    Font =
                        new Font(
                            "Segoe UI",
                            7.5F),

                    ForeColor =
                        Color.FromArgb(
                            130,
                            110,
                            100),

                    Location =
                        new Point(
                            15,
                            110),

                    AutoSize = true
                };

            // ========================================================
            // QUANTIDADE INFERIOR
            // ========================================================

            Label quantidadeProdutosLabel =
                new Label
                {
                    Text =
                        quantidadeProdutos == 1
                            ? "1 produto"
                            : $"{quantidadeProdutos} produtos",

                    Font =
                        new Font(
                            "Segoe UI Semibold",
                            8F,
                            FontStyle.Bold),

                    ForeColor = cor,

                    TextAlign =
                        ContentAlignment.MiddleRight,

                    Location =
                        new Point(
                            150,
                            108),

                    Size =
                        new Size(
                            105,
                            18)
                };

            // ========================================================
            // LINHA
            // ========================================================

            Panel linha =
                new Panel
                {
                    BackColor =
                        Color.FromArgb(
                            239,
                            232,
                            228),

                    Location =
                        new Point(
                            15,
                            132),

                    Size =
                        new Size(
                            240,
                            1)
                };

            // ========================================================
            // ADICIONAR ELEMENTOS
            // ========================================================

            card.Controls.Add(icone);
            card.Controls.Add(quantidade);
            card.Controls.Add(nome);
            card.Controls.Add(descricao);
            card.Controls.Add(produtosCadastrados);
            card.Controls.Add(quantidadeProdutosLabel);
            card.Controls.Add(linha);

            // ========================================================
            // BOTÕES SOMENTE PARA ADMIN
            // ========================================================

            if (SessionManager.Instance.IsAdmin)
            {
                Button btnEditar =
                    CriarBotaoCard(
                        "Editar");

                btnEditar.Tag =
                    categoria;

                btnEditar.Location =
                    new Point(
                        15,
                        143);

                btnEditar.Size =
                    new Size(
                        120,
                        25);

                btnEditar.Click +=
                    BtnEditarCategoria_Click;

                Button btnExcluir =
                    CriarBotaoCard(
                        "Excluir");

                btnExcluir.Tag =
                    categoria;

                btnExcluir.Location =
                    new Point(
                        135,
                        143);

                btnExcluir.Size =
                    new Size(
                        120,
                        25);

                btnExcluir.Click +=
                    BtnExcluirCategoria_Click;

                card.Controls.Add(
                    btnEditar);

                card.Controls.Add(
                    btnExcluir);
            }

            return card;
        }

        // ============================================================
        // EDITAR CATEGORIA
        // ============================================================

        private void BtnEditarCategoria_Click(
            object? sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            if (sender is not Button botao)
                return;

            if (botao.Tag is not CategoriaResponseDto categoria)
                return;

            MostrarFormulario(
                categoria);
        }

        // ============================================================
        // EXCLUIR CATEGORIA
        // ============================================================

        private async void BtnExcluirCategoria_Click(
            object? sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            if (sender is not Button botao)
                return;

            if (botao.Tag is not CategoriaResponseDto categoria)
                return;

            await ExcluirCategoriaAsync(
                categoria);
        }

        // ============================================================
        // CARD NOVA CATEGORIA
        // ============================================================

        private Panel CriarCardNovaCategoria()
        {
            Panel card =
                new Panel
                {
                    Width = 270,
                    Height = 180,

                    BackColor =
                        Color.FromArgb(
                            250,
                            248,
                            246),

                    BorderStyle =
                        BorderStyle.FixedSingle,

                    Margin =
                        new Padding(
                            0,
                            0,
                            16,
                            14),

                    Cursor =
                        Cursors.Hand
                };

            Label icone =
                new Label
                {
                    Text = "+",

                    Font =
                        new Font(
                            "Segoe UI Light",
                            25F),

                    ForeColor =
                        Color.FromArgb(
                            145,
                            117,
                            106),

                    Location =
                        new Point(
                            115,
                            35),

                    Size =
                        new Size(
                            40,
                            40),

                    TextAlign =
                        ContentAlignment.MiddleCenter
                };

            Label titulo =
                new Label
                {
                    Text =
                        "Nova Categoria",

                    Font =
                        new Font(
                            "Georgia",
                            10F,
                            FontStyle.Bold),

                    ForeColor =
                        Color.FromArgb(
                            94,
                            70,
                            60),

                    Location =
                        new Point(
                            55,
                            88),

                    Size =
                        new Size(
                            160,
                            25),

                    TextAlign =
                        ContentAlignment.MiddleCenter
                };

            Label descricao =
                new Label
                {
                    Text =
                        "Clique para adicionar",

                    Font =
                        new Font(
                            "Segoe UI",
                            8F),

                    ForeColor =
                        Color.FromArgb(
                            155,
                            137,
                            129),

                    Location =
                        new Point(
                            50,
                            116),

                    Size =
                        new Size(
                            170,
                            20),

                    TextAlign =
                        ContentAlignment.MiddleCenter
                };

            card.Click +=
                CardNovaCategoria_Click;

            icone.Click +=
                CardNovaCategoria_Click;

            titulo.Click +=
                CardNovaCategoria_Click;

            descricao.Click +=
                CardNovaCategoria_Click;

            card.Controls.Add(
                icone);

            card.Controls.Add(
                titulo);

            card.Controls.Add(
                descricao);

            return card;
        }

        // ============================================================
        // CLIQUE NOVA CATEGORIA
        // ============================================================

        private void CardNovaCategoria_Click(
            object? sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            MostrarFormulario(
                null);
        }

        // ============================================================
        // BOTÃO DOS CARDS
        // ============================================================

        private Button CriarBotaoCard(
            string texto)
        {
            Button botao =
                new Button
                {
                    Text = texto,

                    Font =
                        new Font(
                            "Segoe UI",
                            8F),

                    BackColor =
                        Color.FromArgb(
                            247,
                            244,
                            242),

                    ForeColor =
                        Color.FromArgb(
                            105,
                            85,
                            75),

                    FlatStyle =
                        FlatStyle.Flat,

                    Cursor =
                        Cursors.Hand
                };

            botao.FlatAppearance.BorderSize =
                0;

            return botao;
        }

        // ============================================================
        // MOSTRAR FORMULÁRIO
        // ============================================================

        private void MostrarFormulario(
            CategoriaResponseDto? categoria)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoCategoria(
                    "Seu perfil não possui permissão para alterar categorias.",
                    TipoAvisoCategoria.Aviso);

                return;
            }

            // ========================================================
            // DEFINIR MODO
            // ========================================================

            _editandoId =
                categoria?.Id;

            // ========================================================
            // PREENCHER CAMPOS
            // ========================================================

            txtNome.Text =
                categoria?.Name ??
                string.Empty;

            // ========================================================
            // TÍTULO
            // ========================================================

            lblFormTitulo.Text =
                categoria == null
                    ? "Nova Categoria"
                    : "Editar Categoria";

            // ========================================================
            // MOSTRAR FORMULÁRIO
            // ========================================================

            pnlForm.Visible =
                true;

            pnlForm.BringToFront();

            // ========================================================
            // CENTRALIZAR
            // ========================================================

            pnlForm.Left =
                (pnlPrincipal.ClientSize.Width -
                 pnlForm.Width) / 2;

            pnlForm.Top =
                (pnlPrincipal.ClientSize.Height -
                 pnlForm.Height) / 2;

            // ========================================================
            // FOCO
            // ========================================================

            txtNome.Focus();

            txtNome.SelectAll();
        }

        // ============================================================
        // OCULTAR FORMULÁRIO
        // ============================================================

        private void OcultarFormulario()
        {
            pnlForm.Visible =
                false;

            _editandoId =
                null;

            txtNome.Clear();
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private async void btnSalvar_Click(
            object sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoCategoria(
                    "Seu perfil não possui permissão para alterar categorias.",
                    TipoAvisoCategoria.Aviso);

                return;
            }

            if (_categoriasService == null)
                return;

            string nome =
                txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MostrarAvisoCategoria(
                    "Informe o nome da categoria.",
                    TipoAvisoCategoria.Aviso);

                txtNome.Focus();

                return;
            }

            try
            {
                // ====================================================
                // NOVA CATEGORIA
                // ====================================================

                if (_editandoId == null)
                {
                    var dto =
                        new CreateCategoriaDto
                        {
                            Name = nome
                        };

                    var resultado =
                        await _categoriasService
                            .CreateAsync(
                                dto);

                    if (resultado.Success)
                    {
                        OcultarFormulario();

                        await CarregarDadosAsync();

                        MostrarAvisoCategoria(
                            "Categoria criada com sucesso!",
                            TipoAvisoCategoria.Sucesso);
                    }
                    else
                    {
                        MostrarAvisoCategoria(
                            resultado.ErrorMessage ??
                            "Não foi possível criar a categoria.",
                            TipoAvisoCategoria.Erro);
                    }

                    return;
                }

                // ====================================================
                // EDITAR CATEGORIA
                // ====================================================

                var updateDto =
                    new UpdateCategoriaDto
                    {
                        Name = nome
                    };

                var updateResultado =
                    await _categoriasService
                        .UpdateAsync(
                            _editandoId.Value,
                            updateDto);

                if (updateResultado.Success)
                {
                    OcultarFormulario();

                    await CarregarDadosAsync();

                    MostrarAvisoCategoria(
                        "Categoria atualizada com sucesso!",
                        TipoAvisoCategoria.Sucesso);
                }
                else
                {
                    MostrarAvisoCategoria(
                        updateResultado.ErrorMessage ??
                        "Não foi possível atualizar a categoria.",
                        TipoAvisoCategoria.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoCategoria(
                    $"Erro ao salvar categoria: {ex.Message}",
                    TipoAvisoCategoria.Erro);
            }
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            OcultarFormulario();
        }

        // ============================================================
        // EXCLUIR
        // ============================================================

        private async Task ExcluirCategoriaAsync(
            CategoriaResponseDto categoria)
        {
            if (!SessionManager.Instance.IsAdmin)
            {
                MostrarAvisoCategoria(
                    "Seu perfil não possui permissão para excluir categorias.",
                    TipoAvisoCategoria.Aviso);

                return;
            }

            if (_categoriasService == null)
                return;

            // ========================================================
            // VERIFICA PRODUTOS VINCULADOS
            // ========================================================

            if (categoria.DoceCount > 0)
            {
                MostrarAvisoCategoria(
                    $"A categoria \"{categoria.Name}\" possui " +
                    $"{categoria.DoceCount} doce(s) vinculado(s). " +
                    "Remova os doces antes de excluir a categoria.",
                    TipoAvisoCategoria.Aviso);

                return;
            }

            // ========================================================
            // CONFIRMAÇÃO
            // ========================================================

            using (var confirmar =
                new DoceCantinho.Desktop.Forms
                    .ConfirmarExclusaoForm(
                        "categoria",
                        categoria.Name))
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
                var resultado =
                    await _categoriasService
                        .DeleteAsync(
                            categoria.Id);

                if (resultado.Success)
                {
                    await CarregarDadosAsync();

                    MostrarAvisoCategoria(
                        "Categoria excluída com sucesso!",
                        TipoAvisoCategoria.Sucesso);
                }
                else
                {
                    MostrarAvisoCategoria(
                        resultado.ErrorMessage ??
                        "Não foi possível excluir a categoria.",
                        TipoAvisoCategoria.Erro);
                }
            }
            catch (Exception ex)
            {
                MostrarAvisoCategoria(
                    $"Erro ao excluir categoria: {ex.Message}",
                    TipoAvisoCategoria.Erro);
            }
        }

        // ============================================================
        // NOVA CATEGORIA
        // ============================================================

        private void btnNovoCat_Click(
            object sender,
            EventArgs e)
        {
            if (!SessionManager.Instance.IsAdmin)
                return;

            MostrarFormulario(
                null);
        }

        // ============================================================
        // TIPO DE AVISO
        // ============================================================

        private enum TipoAvisoCategoria
        {
            Sucesso,
            Aviso,
            Erro
        }

        // ============================================================
        // AVISO PERSONALIZADO
        // ============================================================

        private void MostrarAvisoCategoria(
            string mensagem,
            TipoAvisoCategoria tipo)
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
                        "pnlAvisoCategoria")
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
                            "pnlAvisoCategoria",

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
                    case TipoAvisoCategoria.Sucesso:

                        corPrincipal =
                            Color.FromArgb(
                                46,
                                160,
                                67);

                        titulo =
                            "Sucesso";

                        break;

                    case TipoAvisoCategoria.Aviso:

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

        // ============================================================
        // DESCRIÇÃO
        // ============================================================

        private string ObterDescricaoCategoria(
            string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return "Produtos da categoria";

            string nomeLower =
                nome.ToLowerInvariant();

            if (nomeLower.Contains("bolo"))
                return "Bolos tradicionais e especiais";

            if (nomeLower.Contains("brigadeiro"))
                return "Brigadeiros clássicos e gourmet";

            if (nomeLower.Contains("brownie"))
                return "Brownies irresistíveis";

            if (nomeLower.Contains("cupcake"))
                return "Cupcakes decorados com amor";

            if (nomeLower.Contains("gourmet"))
                return "Criações exclusivas e sofisticadas";

            return "Produtos da categoria";
        }

        // ============================================================
        // COR DA CATEGORIA
        // ============================================================

        private Color ObterCorCategoria(
            string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return Color.FromArgb(
                    198,
                    124,
                    99);
            }

            string nomeLower =
                nome.ToLowerInvariant();

            if (nomeLower.Contains("bolo"))
            {
                return Color.FromArgb(
                    211,
                    126,
                    105);
            }

            if (nomeLower.Contains("brigadeiro"))
            {
                return Color.FromArgb(
                    232,
                    163,
                    35);
            }

            if (nomeLower.Contains("brownie"))
            {
                return Color.FromArgb(
                    139,
                    121,
                    112);
            }

            if (nomeLower.Contains("cupcake"))
            {
                return Color.FromArgb(
                    235,
                    158,
                    145);
            }

            if (nomeLower.Contains("gourmet"))
            {
                return Color.FromArgb(
                    65,
                    180,
                    125);
            }

            return Color.FromArgb(
                198,
                124,
                99);
        }
    }
}