using DoceCantinho.Desktop.DTOs;
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
        private CategoriasApiService? _categoriasService;

        private List<CategoriaResponseDto> _categorias = new();

        private int? _editandoId = null;

        public CategoriasUserControl()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOAD
        // ============================================================

        private async void CategoriasUserControl_Load(
            object sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            _categoriasService = new CategoriasApiService();

            await CarregarDadosAsync();
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
                _categorias =
                    await _categoriasService.GetAllAsync();

                AtualizarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar categorias:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

            pnlCards.Controls.Clear();

            // ========================================================
            // TOTAL
            // ========================================================

            int totalCategorias =
                _categorias.Count;

            int totalProdutos =
                _categorias.Sum(c => c.DoceCount);

            lblSubtitulo.Text =
                $"{totalCategorias} categorias • {totalProdutos} produtos no total";

            // ========================================================
            // RESUMO
            // ========================================================

            AtualizarResumo();

            // ========================================================
            // CARDS DAS CATEGORIAS
            // ========================================================

            foreach (var categoria in _categorias)
            {
                Panel card =
                    CriarCardCategoria(categoria);

                pnlCards.Controls.Add(card);
            }

            // ========================================================
            // CARD NOVA CATEGORIA
            // ========================================================

            pnlCards.Controls.Add(
                CriarCardNovaCategoria());

            pnlCards.ResumeLayout();
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

            // ========================================================
            // LIMPAR TODOS
            // ========================================================

            foreach (Label label in labels)
            {
                label.Text = "";
            }

            // ========================================================
            // NENHUMA CATEGORIA
            // ========================================================

            if (_categorias.Count == 0)
            {
                lblResumoBolos.Text =
                    "•  Nenhuma categoria";

                return;
            }

            // ========================================================
            // ORDENAR PELA QUANTIDADE DE PRODUTOS
            // ========================================================

            var categoriasOrdenadas =
                _categorias
                    .OrderByDescending(c => c.DoceCount)
                    .Take(5)
                    .ToList();

            // ========================================================
            // PREENCHER RESUMO
            // ========================================================

            for (
                int i = 0;
                i < categoriasOrdenadas.Count &&
                i < labels.Length;
                i++)
            {
                var categoria =
                    categoriasOrdenadas[i];

                labels[i].Text =
                    $"•  {categoria.Name}: {categoria.DoceCount}";
            }
        }

        // ============================================================
        // CRIAR CARD DA CATEGORIA
        // ============================================================

        private Panel CriarCardCategoria(
            CategoriaResponseDto categoria)
        {
            Panel card = new Panel();

            card.Width = 270;

            card.Height = 180;

            card.BackColor =
                Color.White;

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Margin =
                new Padding(
                    0,
                    0,
                    16,
                    14);

            // ========================================================
            // COR DA CATEGORIA
            // ========================================================

            Color cor =
                ObterCorCategoria(
                    categoria.Name);

            // ========================================================
            // ÍCONE
            // ========================================================

            Label icone = new Label();

            icone.Text =
                "✦";

            icone.Font =
                new Font(
                    "Segoe UI",
                    15F,
                    FontStyle.Regular);

            icone.ForeColor =
                cor;

            icone.BackColor =
                Color.FromArgb(
                    250,
                    246,
                    243);

            icone.TextAlign =
                ContentAlignment.MiddleCenter;

            icone.Location =
                new Point(
                    15,
                    15);

            icone.Size =
                new Size(
                    40,
                    40);

            // ========================================================
            // QUANTIDADE NO TOPO
            // ========================================================

            Label quantidade = new Label();

            int quantidadeProdutos =
                categoria.DoceCount;

            quantidade.Text =
                quantidadeProdutos == 1
                    ? "1 produto"
                    : $"{quantidadeProdutos} produtos";

            quantidade.Font =
                new Font(
                    "Segoe UI",
                    8F);

            quantidade.ForeColor =
                cor;

            quantidade.BackColor =
                Color.FromArgb(
                    252,
                    247,
                    244);

            quantidade.TextAlign =
                ContentAlignment.MiddleCenter;

            quantidade.Location =
                new Point(
                    178,
                    18);

            quantidade.Size =
                new Size(
                    77,
                    25);

            // ========================================================
            // NOME
            // ========================================================

            Label nome = new Label();

            nome.Text =
                categoria.Name;

            nome.Font =
                new Font(
                    "Georgia",
                    11F,
                    FontStyle.Bold);

            nome.ForeColor =
                Color.FromArgb(
                    50,
                    35,
                    28);

            nome.Location =
                new Point(
                    15,
                    68);

            nome.AutoSize =
                true;

            // ========================================================
            // DESCRIÇÃO
            // ========================================================

            Label descricao = new Label();

            descricao.Text =
                ObterDescricaoCategoria(
                    categoria.Name);

            descricao.Font =
                new Font(
                    "Segoe UI",
                    8F);

            descricao.ForeColor =
                Color.FromArgb(
                    120,
                    100,
                    90);

            descricao.Location =
                new Point(
                    15,
                    91);

            descricao.AutoSize =
                true;

            // ========================================================
            // PRODUTOS CADASTRADOS
            // ========================================================

            Label produtosCadastrados =
                new Label();

            produtosCadastrados.Text =
                "Produtos cadastrados";

            produtosCadastrados.Font =
                new Font(
                    "Segoe UI",
                    7.5F);

            produtosCadastrados.ForeColor =
                Color.FromArgb(
                    130,
                    110,
                    100);

            produtosCadastrados.Location =
                new Point(
                    15,
                    110);

            produtosCadastrados.AutoSize =
                true;

            // ========================================================
            // QUANTIDADE REAL DE PRODUTOS
            // ========================================================

            Label quantidadeProdutosLabel =
                new Label();

            quantidadeProdutosLabel.Text =
                quantidadeProdutos == 1
                    ? "1 produto"
                    : $"{quantidadeProdutos} produtos";

            quantidadeProdutosLabel.Font =
                new Font(
                    "Segoe UI Semibold",
                    8F,
                    FontStyle.Bold);

            quantidadeProdutosLabel.ForeColor =
                cor;

            quantidadeProdutosLabel.TextAlign =
                ContentAlignment.MiddleRight;

            quantidadeProdutosLabel.Location =
                new Point(
                    150,
                    108);

            quantidadeProdutosLabel.Size =
                new Size(
                    105,
                    18);

            // ========================================================
            // LINHA DECORATIVA
            // ========================================================

            Panel linha = new Panel();

            linha.BackColor =
                Color.FromArgb(
                    239,
                    232,
                    228);

            linha.Location =
                new Point(
                    15,
                    132);

            linha.Size =
                new Size(
                    240,
                    1);

            // ========================================================
            // BOTÃO EDITAR
            // ========================================================

            Button btnEditar =
                CriarBotaoCard(
                    "Editar");

            btnEditar.Location =
                new Point(
                    15,
                    143);

            btnEditar.Size =
                new Size(
                    120,
                    25);

            btnEditar.Click +=
                (sender, e) =>
                {
                    MostrarFormulario(
                        categoria);
                };

            // ========================================================
            // BOTÃO EXCLUIR
            // ========================================================

            Button btnExcluirCard =
                CriarBotaoCard(
                    "Excluir");

            btnExcluirCard.Location =
                new Point(
                    135,
                    143);

            btnExcluirCard.Size =
                new Size(
                    120,
                    25);

            btnExcluirCard.Click +=
                async (sender, e) =>
                {
                    await ExcluirCategoriaAsync(
                        categoria);
                };

            // ========================================================
            // ADICIONAR CONTROLES
            // ========================================================

            card.Controls.Add(
                icone);

            card.Controls.Add(
                quantidade);

            card.Controls.Add(
                nome);

            card.Controls.Add(
                descricao);

            card.Controls.Add(
                produtosCadastrados);

            card.Controls.Add(
                quantidadeProdutosLabel);

            card.Controls.Add(
                linha);

            card.Controls.Add(
                btnEditar);

            card.Controls.Add(
                btnExcluirCard);

            return card;
        }

        // ============================================================
        // CARD NOVA CATEGORIA
        // ============================================================

        private Panel CriarCardNovaCategoria()
        {
            Panel card = new Panel();

            card.Width = 270;

            card.Height = 180;

            card.BackColor =
                Color.FromArgb(
                    250,
                    248,
                    246);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Margin =
                new Padding(
                    0,
                    0,
                    16,
                    14);

            card.Cursor =
                Cursors.Hand;

            // ========================================================
            // ÍCONE
            // ========================================================

            Label icone = new Label();

            icone.Text =
                "+";

            icone.Font =
                new Font(
                    "Segoe UI Light",
                    25F);

            icone.ForeColor =
                Color.FromArgb(
                    145,
                    117,
                    106);

            icone.Location =
                new Point(
                    115,
                    35);

            icone.Size =
                new Size(
                    40,
                    40);

            icone.TextAlign =
                ContentAlignment.MiddleCenter;

            // ========================================================
            // TÍTULO
            // ========================================================

            Label titulo = new Label();

            titulo.Text =
                "Nova Categoria";

            titulo.Font =
                new Font(
                    "Georgia",
                    10F,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(
                    94,
                    70,
                    60);

            titulo.Location =
                new Point(
                    55,
                    88);

            titulo.Size =
                new Size(
                    160,
                    25);

            titulo.TextAlign =
                ContentAlignment.MiddleCenter;

            // ========================================================
            // DESCRIÇÃO
            // ========================================================

            Label descricao = new Label();

            descricao.Text =
                "Clique para adicionar";

            descricao.Font =
                new Font(
                    "Segoe UI",
                    8F);

            descricao.ForeColor =
                Color.FromArgb(
                    155,
                    137,
                    129);

            descricao.Location =
                new Point(
                    50,
                    116);

            descricao.Size =
                new Size(
                    170,
                    20);

            descricao.TextAlign =
                ContentAlignment.MiddleCenter;

            // ========================================================
            // EVENTOS
            // ========================================================

            card.Click +=
                (sender, e) =>
                {
                    MostrarFormulario(null);
                };

            icone.Click +=
                (sender, e) =>
                {
                    MostrarFormulario(null);
                };

            titulo.Click +=
                (sender, e) =>
                {
                    MostrarFormulario(null);
                };

            descricao.Click +=
                (sender, e) =>
                {
                    MostrarFormulario(null);
                };

            // ========================================================
            // ADICIONAR
            // ========================================================

            card.Controls.Add(
                icone);

            card.Controls.Add(
                titulo);

            card.Controls.Add(
                descricao);

            return card;
        }

        // ============================================================
        // BOTÃO DOS CARDS
        // ============================================================

        private Button CriarBotaoCard(
            string texto)
        {
            Button botao = new Button();

            botao.Text =
                texto;

            botao.Font =
                new Font(
                    "Segoe UI",
                    8F);

            botao.BackColor =
                Color.FromArgb(
                    247,
                    244,
                    242);

            botao.ForeColor =
                Color.FromArgb(
                    105,
                    85,
                    75);

            botao.FlatStyle =
                FlatStyle.Flat;

            botao.FlatAppearance.BorderSize =
                0;

            botao.Cursor =
                Cursors.Hand;

            return botao;
        }

        // ============================================================
        // MOSTRAR FORMULÁRIO
        // ============================================================

        private void MostrarFormulario(
            CategoriaResponseDto? categoria)
        {
            _editandoId =
                categoria?.Id;

            txtNome.Text =
                categoria?.Name ??
                string.Empty;

            if (categoria == null)
            {
                lblFormTitulo.Text =
                    "Nova Categoria";
            }
            else
            {
                lblFormTitulo.Text =
                    "Editar Categoria";
            }

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
            if (_categoriasService == null)
                return;

            string nome =
                txtNome.Text.Trim();

            // ========================================================
            // VALIDAÇÃO
            // ========================================================

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show(
                    "Informe o nome da categoria.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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
                            .CreateAsync(dto);

                    if (resultado.Success)
                    {
                        MessageBox.Show(
                            "Categoria criada com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        OcultarFormulario();

                        await CarregarDadosAsync();
                    }
                    else
                    {
                        MessageBox.Show(
                            resultado.ErrorMessage,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
                    MessageBox.Show(
                        "Categoria atualizada com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    OcultarFormulario();

                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        updateResultado.ErrorMessage,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao salvar categoria:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            if (_categoriasService == null)
                return;

            // ========================================================
            // VERIFICA PRODUTOS VINCULADOS
            // ========================================================

            if (categoria.DoceCount > 0)
            {
                MessageBox.Show(
                    $"A categoria \"{categoria.Name}\" possui " +
                    $"{categoria.DoceCount} doce(s) vinculado(s).\n\n" +
                    "Remova os doces antes de excluir a categoria.",
                    "Não é possível excluir",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ========================================================
            // CONFIRMAÇÃO
            // ========================================================

            DialogResult confirmacao =
                MessageBox.Show(
                    $"Deseja excluir a categoria \"{categoria.Name}\"?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                var resultado =
                    await _categoriasService
                        .DeleteAsync(
                            categoria.Id);

                if (resultado.Success)
                {
                    MessageBox.Show(
                        "Categoria excluída com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show(
                        resultado.ErrorMessage,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao excluir categoria:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // NOVA CATEGORIA
        // ============================================================

        private void btnNovoCat_Click(
            object sender,
            EventArgs e)
        {
            MostrarFormulario(null);
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
                return Color.FromArgb(
                    198,
                    124,
                    99);

            string nomeLower =
                nome.ToLowerInvariant();

            if (nomeLower.Contains("bolo"))
                return Color.FromArgb(
                    211,
                    126,
                    105);

            if (nomeLower.Contains("brigadeiro"))
                return Color.FromArgb(
                    232,
                    163,
                    35);

            if (nomeLower.Contains("brownie"))
                return Color.FromArgb(
                    139,
                    121,
                    112);

            if (nomeLower.Contains("cupcake"))
                return Color.FromArgb(
                    235,
                    158,
                    145);

            if (nomeLower.Contains("gourmet"))
                return Color.FromArgb(
                    65,
                    180,
                    125);

            return Color.FromArgb(
                198,
                124,
                99);
        }
    }
}