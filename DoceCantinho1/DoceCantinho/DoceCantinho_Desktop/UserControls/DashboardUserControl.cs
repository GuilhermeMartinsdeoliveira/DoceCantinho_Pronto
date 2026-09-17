using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.UserControls
{
    public partial class DashboardUserControl : UserControl
    {

        private DoceApiService _doceService = null;
        private CategoriasApiService _categoriasService = null;
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private void DashboardUserControl_Load(object sender, EventArgs e)
        {
            //Guard: não execua em tempo design
            if (DesignMode) return;

            //inicializa serviços
            _doceService = new DoceApiService();
            _categoriasService = new CategoriasApiService();

            //Preenche dados dinâmicos da sessão 
            lblTitulo.Text = $"Olá, {SessionManager.Instance.GetDisplayName()!}";
            lblSubTitulo.Text = $"Bem-Vindo ao DoceCantinho - {DateTime.Now:dddd, dd 'de' MMM 'de' yyyy}";

            //Aplica estilo no DataGridView(Tabela)
            DoceTheme.AplicarEstiloGrid(gridUltimosDoces);

            CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            SetCarregando(true);

            try
            {
                var tarefaGames = _doceService.GetAllAsync();
                var tarefaCategorias = _categoriasService.GetAllAsync();
                await Task.WhenAll(tarefaGames, tarefaCategorias);

                var doces = tarefaGames.Result;
                var categorias = tarefaCategorias.Result;

                //Atualiza os dados do card
                //AtualizarNumeroCard(cardGames, games.Count.ToString());
                //AtualizarNumeroCard(cardCategorias, categorias.Count.ToString());

                cardDoceslblNumero.Text = doces.Count.ToString();
                cardCategoriaslblNumero.Text = categorias.Count.ToString();
                CardDestaquesValor.Text = doces.Count(x => x.IsFeatured).ToString();

                //Popula o DataGridView(tabela) com os ultimos 10 doces 
                gridUltimosDoces.Rows.Clear();
                foreach (var doce in doces.OrderByDescending(x => x.CreatedAt).Take(10))
                {
                    gridUltimosDoces.Rows.Add(
                        doce.Id,
                        doce.Title,
                        doce.CategoryName,
                        doce.ReleaseYear,
                        doce.IsFeatured,
                        doce.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            finally
            {
                SetCarregando(false);
            }
        }

        private void SetCarregando(bool carregando)
        {
            lblCarregando.Visible = carregando;
            cardDoces.Visible = !carregando;
            cardCategorias.Visible = !carregando;
            lblUltimosDoces.Visible = !carregando;
            gridUltimosDoces.Visible = !carregando;
        }


    }
}
