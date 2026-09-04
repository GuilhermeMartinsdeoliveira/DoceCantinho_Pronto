using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        private DoceApiService _doceService;
        private CategoriasApiService _categoriasService;

        public DashboardUserControl()
        {
            InitializeComponent();

            // Evento de carregamento
            this.Load += DashboardUserControl_Load;
        }

        // ============================================================
        // CARREGAMENTO DO DASHBOARD
        // ============================================================

        private async void DashboardUserControl_Load(object sender, EventArgs e)
        {
            // Não executa no Designer do Visual Studio
            if (DesignMode || LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            try
            {
                // Inicializa os serviços
                _doceService = new DoceApiService();
                _categoriasService = new CategoriasApiService();

                // Dados do usuário logado
                string nomeUsuario = SessionManager.Instance.GetDisplayName();

                if (string.IsNullOrWhiteSpace(nomeUsuario))
                    nomeUsuario = "Usuário";

                lblTitulo.Text = $"Olá, {nomeUsuario}!";

                // Data atual
                lblSubTitulo.Text =
                    $"Bem-vindo ao DoceCantinho - {DateTime.Now:dddd, dd 'de' MMMM 'de' yyyy}";

                // Aplica o tema da tabela
                DoceTheme.AplicarEstiloGrid(gridUltimosDoces);

                // Carrega os dados
                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Não foi possível iniciar o dashboard.\n\nErro: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            SetCarregando(true);

            try
            {
                // Busca os dados
                var resultadoDoces = await _doceService.GetAllAsync();
                var resultadoCategorias = await _categoriasService.GetAllAsync();

                // ====================================================
                // CORREÇÃO DO PROBLEMA COM DYNAMIC
                // ====================================================

                // Converte explicitamente para listas.
                // Isso evita os erros CS1977 nas expressões LINQ.
                var doces = ((IEnumerable<dynamic>)resultadoDoces).ToList();
                var categorias = ((IEnumerable<dynamic>)resultadoCategorias).ToList();

                // ====================================================
                // CARDS DO DASHBOARD
                // ====================================================

                // Total de doces
                cardDoceslblNumero.Text = doces.Count.ToString();

                // Total de categorias
                cardCategoriaslblNumero.Text = categorias.Count.ToString();

                // Total de doces em destaque
                int totalDestaques = 0;

                foreach (var doce in doces)
                {
                    try
                    {
                        if (doce.IsFeatured == true)
                            totalDestaques++;
                    }
                    catch
                    {
                        // Caso o objeto não possua IsFeatured
                    }
                }

                CardDestaquesValor.Text = totalDestaques.ToString();

                // ====================================================
                // TABELA DE ÚLTIMOS DOCES
                // ====================================================

                gridUltimosDoces.Rows.Clear();

                // Cria uma lista para ordenar sem gerar erro de
                // expressão lambda em operação dinâmica.
                var listaOrdenada = new List<dynamic>();

                foreach (var doce in doces)
                {
                    listaOrdenada.Add(doce);
                }

                // Ordena pela data de criação
                listaOrdenada.Sort((a, b) =>
                {
                    try
                    {
                        DateTime dataA = Convert.ToDateTime(a.CreatedAt);
                        DateTime dataB = Convert.ToDateTime(b.CreatedAt);

                        return dataB.CompareTo(dataA);
                    }
                    catch
                    {
                        return 0;
                    }
                });

                // Apenas os 10 últimos
                int quantidade = Math.Min(10, listaOrdenada.Count);

                for (int i = 0; i < quantidade; i++)
                {
                    var doce = listaOrdenada[i];

                    string id = "";
                    string titulo = "";
                    string categoria = "";
                    string preco = "R$ 0,00";
                    string destaque = "Normal";
                    string dataCriacao = "";

                    // =================================================
                    // ID
                    // =================================================

                    try
                    {
                        id = Convert.ToString(doce.Id);
                    }
                    catch
                    {
                        id = "";
                    }

                    // =================================================
                    // TÍTULO
                    // =================================================

                    try
                    {
                        titulo = Convert.ToString(doce.Title);
                    }
                    catch
                    {
                        titulo = "Sem título";
                    }

                    // =================================================
                    // CATEGORIA
                    // =================================================

                    try
                    {
                        categoria = Convert.ToString(doce.CategoryName);

                        if (string.IsNullOrWhiteSpace(categoria))
                            categoria = "Sem categoria";
                    }
                    catch
                    {
                        categoria = "Sem categoria";
                    }

                    // =================================================
                    // PREÇO
                    // =================================================

                    try
                    {
                        decimal valor = Convert.ToDecimal(doce.Preco);
                        preco = valor.ToString("C2");
                    }
                    catch
                    {
                        preco = "R$ 0,00";
                    }

                    // =================================================
                    // DESTAQUE
                    // =================================================

                    try
                    {
                        destaque = doce.IsFeatured == true
                            ? "Destaque"
                            : "Normal";
                    }
                    catch
                    {
                        destaque = "Normal";
                    }

                    // =================================================
                    // DATA
                    // =================================================

                    try
                    {
                        DateTime data = Convert.ToDateTime(doce.CreatedAt);
                        dataCriacao = data.ToString("dd/MM/yyyy HH:mm");
                    }
                    catch
                    {
                        dataCriacao = "";
                    }

                    // =================================================
                    // ADICIONA NA GRID
                    // =================================================

                    gridUltimosDoces.Rows.Add(
                        id,
                        titulo,
                        categoria,
                        preco,
                        destaque,
                        dataCriacao
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar os dados do dashboard.\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
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

        private void SetCarregando(bool carregando)
        {
            // Texto de carregamento
            if (lblCarregando != null)
                lblCarregando.Visible = carregando;

            // Card de doces
            if (cardDoces != null)
                cardDoces.Visible = !carregando;

            // Card de categorias
            if (cardCategorias != null)
                cardCategorias.Visible = !carregando;

            // Título da tabela
            if (lblUltimosDoces != null)
                lblUltimosDoces.Visible = !carregando;

            // Grid
            if (gridUltimosDoces != null)
                gridUltimosDoces.Visible = !carregando;
        }

        // ============================================================
        // ATUALIZAR DASHBOARD MANUALMENTE
        // ============================================================

        public async Task AtualizarDashboardAsync()
        {
            if (_doceService == null)
                _doceService = new DoceApiService();

            if (_categoriasService == null)
                _categoriasService = new CategoriasApiService();

            await CarregarDadosAsync();
        }
    }
}