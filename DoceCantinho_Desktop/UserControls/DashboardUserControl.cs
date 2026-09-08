using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        // ============================================================
        // SERVIÇOS
        // ============================================================
        private readonly DoceApiService _doceService;
        private readonly CategoriasApiService _categoriasService;
        private readonly PedidosApiService _pedidosService;

        // ============================================================
        // DADOS
        // ============================================================
        private List<DoceResponseDto> _doces = new();
        private List<CategoriaResponseDto> _categorias = new();
        private List<PedidoResponseDto> _pedidos = new();

        // ============================================================
        // VENDAS DOS 7 DIAS
        // ============================================================
        private readonly decimal[] _vendasPorDia =
            new decimal[7];

        // ============================================================
        // CONSTRUTOR
        // ============================================================
        public DashboardUserControl()
        {
            InitializeComponent();

            _doceService =
                new DoceApiService();

            _categoriasService =
                new CategoriasApiService();

            _pedidosService =
                new PedidosApiService();

            // ========================================================
            // O GRÁFICO AGORA É DESENHADO PELO CÓDIGO
            // ========================================================
            OcultarBarrasDoDesigner();

            pnlChart.Paint -=
                PnlChart_Paint;

            pnlChart.Paint +=
                PnlChart_Paint;

            Resize -=
                DashboardUserControl_Resize;

            Resize +=
                DashboardUserControl_Resize;

            Load -=
                DashboardUserControl_Load;

            Load +=
                DashboardUserControl_Load;
        }

        // ============================================================
        // LOAD
        // ============================================================
        private async void DashboardUserControl_Load(
            object? sender,
            EventArgs e)
        {
            if (DesignMode ||
                LicenseManager.UsageMode ==
                LicenseUsageMode.Designtime)
            {
                return;
            }

            // ========================================================
            // USUÁRIO
            // ========================================================
            string nome =
                SessionManager.Instance
                    .GetDisplayName();

            if (string.IsNullOrWhiteSpace(nome))
                nome = "Usuário";

            lblTitulo.Text =
                $"Olá, {nome}!";

            lblSubTitulo.Text =
                $"Bem-vindo ao DoceCantinho - {ObterDataAtualFormatada()}";

            await CarregarDadosAsync();
        }

        // ============================================================
        // DATA
        // ============================================================
        private string ObterDataAtualFormatada()
        {
            CultureInfo cultura =
                CultureInfo.GetCultureInfo(
                    "pt-BR");

            string data =
                DateTime.Now
                    .ToString(
                        "dddd, dd 'de' MMMM 'de' yyyy",
                        cultura);

            if (string.IsNullOrEmpty(data))
                return data;

            return char.ToUpper(data[0]) +
                   data.Substring(1);
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================
        private async Task CarregarDadosAsync()
        {
            try
            {
                SetCarregando(true);

                var tarefaDoces =
                    _doceService.GetAllAsync();

                var tarefaCategorias =
                    _categoriasService.GetAllAsync();

                var tarefaPedidos =
                    _pedidosService.GetAllAsync();

                await Task.WhenAll(
                    tarefaDoces,
                    tarefaCategorias,
                    tarefaPedidos);

                _doces =
                    tarefaDoces.Result ??
                    new List<DoceResponseDto>();

                _categorias =
                    tarefaCategorias.Result ??
                    new List<CategoriaResponseDto>();

                _pedidos =
                    tarefaPedidos.Result ??
                    new List<PedidoResponseDto>();

                // ====================================================
                // ATUALIZAR COMPONENTES
                // ====================================================
                AtualizarCards();

                AtualizarGrafico();

                AtualizarCategorias();

                AtualizarUltimosDoces();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível carregar o dashboard.\n\n{ex.Message}",
                    "Dashboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                SetCarregando(false);
            }
        }

        // ============================================================
        // CARDS
        // ============================================================
        private void AtualizarCards()
        {
            // ========================================================
            // DOCES
            // ========================================================
            int quantidadeDoces =
                _doces.Count;

            cardDoceslblNumero.Text =
                quantidadeDoces.ToString();

            // ========================================================
            // CATEGORIAS
            // ========================================================
            int quantidadeCategorias =
                _categorias.Count;

            cardCategoriaslblNumero.Text =
                quantidadeCategorias.ToString();

            // ========================================================
            // DESTAQUES
            // ========================================================
            int quantidadeDestaques =
                _doces.Count(
                    d => d.IsFeatured);

            CardDestaquesValor.Text =
                quantidadeDestaques.ToString();

            // ========================================================
            // PEDIDOS HOJE
            // ========================================================
            DateTime hoje =
                DateTime.Now.Date;

            var pedidosHoje =
                _pedidos
                    .Where(
                        p =>
                            p.CreatedAt
                                .ToLocalTime()
                                .Date == hoje)
                    .ToList();

            lblCardPedidosNumero.Text =
                pedidosHoje.Count
                    .ToString("00");

            int aguardandoPreparo =
                pedidosHoje.Count(
                    p =>
                    {
                        string status =
                            NormalizarStatus(
                                p.Status);

                        return status ==
                                   "pendente" ||
                               status ==
                                   "preparo";
                    });

            lblCardPedidosDescricao.Text =
                aguardandoPreparo == 1
                    ? "1 aguardando preparo"
                    : $"{aguardandoPreparo} aguardando preparo";

            // ========================================================
            // RECEITA DA SEMANA
            // ========================================================
            decimal receita =
                CalcularReceitaSemana();

            lblVendasValor.Text =
                receita.ToString(
                    "C2",
                    CultureInfo.GetCultureInfo(
                        "pt-BR"));
        }

        // ============================================================
        // RECEITA DOS ÚLTIMOS 7 DIAS
        // ============================================================
        private decimal CalcularReceitaSemana()
        {
            DateTime hoje =
                DateTime.Now.Date;

            DateTime inicio =
                hoje.AddDays(-6);

            return _pedidos
                .Where(
                    p =>
                    {
                        string status =
                            NormalizarStatus(
                                p.Status);

                        if (status ==
                            "cancelado")
                        {
                            return false;
                        }

                        DateTime data =
                            p.CreatedAt
                                .ToLocalTime()
                                .Date;

                        return data >= inicio &&
                               data <= hoje;
                    })
                .Sum(
                    p => p.Total);
        }

        // ============================================================
        // GRÁFICO
        // ============================================================
        private void AtualizarGrafico()
        {
            Array.Clear(
                _vendasPorDia,
                0,
                _vendasPorDia.Length);

            DateTime hoje =
                DateTime.Now.Date;

            DateTime inicio =
                hoje.AddDays(-6);

            // ========================================================
            // SOMAR PEDIDOS
            // ========================================================
            foreach (var pedido in _pedidos)
            {
                string status =
                    NormalizarStatus(
                        pedido.Status);

                if (status ==
                    "cancelado")
                {
                    continue;
                }

                DateTime data =
                    pedido.CreatedAt
                        .ToLocalTime()
                        .Date;

                if (data < inicio ||
                    data > hoje)
                {
                    continue;
                }

                int indice =
                    (int)(
                        data - inicio
                    ).TotalDays;

                if (indice >= 0 &&
                    indice < 7)
                {
                    _vendasPorDia[indice] +=
                        pedido.Total;
                }
            }

            // ========================================================
            // DIAS
            // ========================================================
            Label[] dias =
            {
                lblSeg,
                lblTer,
                lblQua,
                lblQui,
                lblSex,
                lblSab,
                lblDom
            };

            for (int i = 0; i < dias.Length; i++)
            {
                DateTime data =
                    inicio.AddDays(i);

                dias[i].Text =
                    ObterAbreviacaoDia(
                        data.DayOfWeek);
            }

            // ========================================================
            // ESCALA
            // ========================================================
            AtualizarEscalaGrafico();

            // ========================================================
            // REDESENHAR
            // ========================================================
            pnlChart.Invalidate();
        }

        // ============================================================
        // ABREVIAÇÃO DO DIA
        // ============================================================
        private string ObterAbreviacaoDia(
            DayOfWeek dia)
        {
            return dia switch
            {
                DayOfWeek.Monday =>
                    "Seg",

                DayOfWeek.Tuesday =>
                    "Ter",

                DayOfWeek.Wednesday =>
                    "Qua",

                DayOfWeek.Thursday =>
                    "Qui",

                DayOfWeek.Friday =>
                    "Sex",

                DayOfWeek.Saturday =>
                    "Sáb",

                DayOfWeek.Sunday =>
                    "Dom",

                _ =>
                    ""
            };
        }

        // ============================================================
        // ESCALA
        // ============================================================
        private void AtualizarEscalaGrafico()
        {
            decimal maior =
                _vendasPorDia.Length == 0
                    ? 0
                    : _vendasPorDia.Max();

            decimal passo;

            if (maior <= 0)
            {
                passo = 1000;
            }
            else
            {
                decimal teto =
                    Math.Ceiling(
                        maior / 1000m
                    ) * 1000m;

                if (teto < 1000m)
                    teto = 1000m;

                passo =
                    teto / 4m;
            }

            lblChart0.Text =
                "R$ 0";

            lblChart1.Text =
                FormatarEscala(
                    passo);

            lblChart2.Text =
                FormatarEscala(
                    passo * 2);

            lblChart3.Text =
                FormatarEscala(
                    passo * 3);

            lblChart4.Text =
                FormatarEscala(
                    passo * 4);
        }

        private string FormatarEscala(
            decimal valor)
        {
            if (valor >= 1000m)
            {
                decimal milhares =
                    valor / 1000m;

                if (milhares % 1 ==
                    0)
                {
                    return $"R$ {milhares:0}k";
                }

                return $"R$ {milhares:0.#}k";
            }

            return $"R$ {valor:0}";
        }

        // ============================================================
        // DESENHAR GRÁFICO
        // ============================================================
        private void PnlChart_Paint(
            object? sender,
            PaintEventArgs e)
        {
            Graphics g =
                e.Graphics;

            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            g.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            g.PixelOffsetMode =
                PixelOffsetMode.HighQuality;

            g.CompositingQuality =
                CompositingQuality.HighQuality;

            // ========================================================
            // DIMENSÕES
            // ========================================================
            int margemEsquerda =
                45;

            int margemDireita =
                10;

            int topo =
                8;

            int baseGrafico =
                126;

            int largura =
                pnlChart.ClientSize.Width -
                margemEsquerda -
                margemDireita;

            int altura =
                baseGrafico -
                topo;

            if (largura <= 0 ||
                altura <= 0)
            {
                return;
            }

            // ========================================================
            // MAIOR VALOR
            // ========================================================
            decimal maior =
                _vendasPorDia.Max();

            decimal maximo;

            if (maior <= 0)
            {
                maximo = 1000m;
            }
            else
            {
                maximo =
                    Math.Ceiling(
                        maior / 1000m
                    ) * 1000m;

                if (maximo < 1000m)
                    maximo = 1000m;
            }

            // ========================================================
            // LINHAS DO GRÁFICO
            // ========================================================
            using var penLinha =
                new Pen(
                    Color.FromArgb(
                        237,
                        230,
                        226),
                    1f);

            for (int i = 0; i <= 4; i++)
            {
                float y =
                    topo +
                    altura -
                    (
                        altura *
                        i /
                        4f
                    );

                g.DrawLine(
                    penLinha,
                    margemEsquerda,
                    y,
                    pnlChart.ClientSize.Width -
                        margemDireita,
                    y);
            }

            // ========================================================
            // BARRAS
            // ========================================================
            float espaco =
                largura /
                7f;

            int larguraBarra =
                Math.Max(
                    10,
                    Math.Min(
                        24,
                        (int)(
                            espaco *
                            0.20f)));

            using var brushNormal =
                new SolidBrush(
                    Color.FromArgb(
                        221,
                        153,
                        125));

            using var brushHoje =
                new SolidBrush(
                    Color.FromArgb(
                        201,
                        130,
                        107));

            for (int i = 0; i < 7; i++)
            {
                decimal valor =
                    _vendasPorDia[i];

                float proporcao =
                    maximo <= 0
                        ? 0
                        : (float)(
                            valor /
                            maximo);

                proporcao =
                    Math.Max(
                        0,
                        Math.Min(
                            1,
                            proporcao));

                float alturaBarra =
                    proporcao *
                    altura;

                if (valor > 0 &&
                    alturaBarra < 3)
                {
                    alturaBarra = 3;
                }

                float centro =
                    margemEsquerda +
                    espaco *
                    i +
                    espaco / 2f;

                float x =
                    centro -
                    larguraBarra / 2f;

                float y =
                    baseGrafico -
                    alturaBarra;

                RectangleF retangulo =
                    new RectangleF(
                        x,
                        y,
                        larguraBarra,
                        alturaBarra);

                g.FillRectangle(
                    i == 6
                        ? brushHoje
                        : brushNormal,
                    retangulo);
            }
        }

        // ============================================================
        // CATEGORIAS
        // ============================================================
        private void AtualizarCategorias()
        {
            var lista =
                _categorias
                    .OrderByDescending(
                        c => c.DoceCount)
                    .ThenBy(
                        c => c.Name)
                    .Take(4)
                    .ToList();

            Label[] nomes =
            {
                lblCat1,
                lblCat2,
                lblCat3,
                lblCat4
            };

            Label[] quantidades =
            {
                lblCat1Qtd,
                lblCat2Qtd,
                lblCat3Qtd,
                lblCat4Qtd
            };

            Guna2ProgressBar[] barras =
            {
                progressCat1,
                progressCat2,
                progressCat3,
                progressCat4
            };

            int maior =
                lista.Count > 0
                    ? lista.Max(
                        c => c.DoceCount)
                    : 0;

            for (int i = 0; i < 4; i++)
            {
                if (i >= lista.Count)
                {
                    nomes[i].Visible =
                        false;

                    quantidades[i].Visible =
                        false;

                    barras[i].Visible =
                        false;

                    continue;
                }

                var categoria =
                    lista[i];

                nomes[i].Visible =
                    true;

                quantidades[i].Visible =
                    true;

                barras[i].Visible =
                    true;

                nomes[i].Text =
                    string.IsNullOrWhiteSpace(
                        categoria.Name)
                        ? "Sem categoria"
                        : categoria.Name;

                quantidades[i].Text =
                    categoria.DoceCount.ToString();

                int percentual =
                    0;

                if (maior > 0)
                {
                    percentual =
                        (int)Math.Round(
                            categoria.DoceCount /
                            (double)maior *
                            100);
                }

                percentual =
                    Math.Max(
                        0,
                        Math.Min(
                            100,
                            percentual));

                barras[i].Value =
                    percentual;
            }
        }

        // ============================================================
        // ÚLTIMOS DOCES
        // ============================================================
        private void AtualizarUltimosDoces()
        {
            gridUltimosDoces.Rows.Clear();

            var lista =
                _doces
                    .OrderByDescending(
                        d => d.CreatedAt)
                    .Take(10)
                    .ToList();

            foreach (var doce in lista)
            {
                gridUltimosDoces.Rows.Add(
                    doce.Id,

                    string.IsNullOrWhiteSpace(
                        doce.Title)
                        ? "Sem título"
                        : doce.Title,

                    string.IsNullOrWhiteSpace(
                        doce.CategoryName)
                        ? "Sem categoria"
                        : doce.CategoryName,

                    doce.Preco.ToString(
                        "C2",
                        CultureInfo.GetCultureInfo(
                            "pt-BR")),

                    doce.IsFeatured
                        ? "Destaque"
                        : "Normal",

                    doce.CreatedAt
                        .ToLocalTime()
                        .ToString(
                            "dd/MM/yyyy HH:mm"));
            }
        }

        // ============================================================
        // OCULTAR BARRAS ESTÁTICAS
        // ============================================================
        private void OcultarBarrasDoDesigner()
        {
            barra1.Visible = false;
            barra2.Visible = false;
            barra3.Visible = false;
            barra4.Visible = false;
            barra5.Visible = false;
            barra6.Visible = false;
        }

        // ============================================================
        // CARREGANDO
        // ============================================================
        private void SetCarregando(
            bool carregando)
        {
            lblCarregando.Visible =
                carregando;

            if (carregando)
                return;

            pnldash.Visible = true;
            pnlHeader.Visible = true;

            cardDoces.Visible = true;
            cardCategorias.Visible = true;
            pnlCardDestaques.Visible = true;
            cardPedidos.Visible = true;

            pnlVendas.Visible = true;
            pnlCategorias.Visible = true;

            lblUltimosDoces.Visible = true;
            lblUltimosSubtitulo.Visible = true;
            gridUltimosDoces.Visible = true;
            btnVerTodos.Visible = true;
        }

        // ============================================================
        // ATUALIZAÇÃO EXTERNA
        // ============================================================
        public async Task AtualizarDashboardAsync()
        {
            await CarregarDadosAsync();
        }

        // ============================================================
        // RESIZE
        // ============================================================
        private void DashboardUserControl_Resize(
            object? sender,
            EventArgs e)
        {
            if (pnlChart != null)
            {
                pnlChart.Invalidate();
            }
        }

        // ============================================================
        // NORMALIZAR STATUS
        // ============================================================
        private string NormalizarStatus(
            string? status)
        {
            return (status ??
                    string.Empty)
                .Trim()
                .ToLowerInvariant()
                .Replace("á", "a")
                .Replace("à", "a")
                .Replace("ã", "a")
                .Replace("â", "a")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ô", "o")
                .Replace("õ", "o")
                .Replace("ú", "u");
        }
    }
}