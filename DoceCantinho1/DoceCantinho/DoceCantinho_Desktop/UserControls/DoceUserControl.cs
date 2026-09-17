using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Forms;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Themes;
using DoceCantinho.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.UserControls
{
    public partial class DoceUserControl : UserControl
    {

        /// =====================================
        /// SERVIÇOS (Inicializados no load) 
        /// =====================================

        private DoceApiService _doceService = null;
        private CategoriasApiService _categoriasService = null;

        /// =====================================
        /// Dados 
        /// =====================================
        private List<DoceResponseDto> _todosDoces = new();
        private List<CategoriaResponseDto> _categorias = new();

        /// =====================================
        /// CONSTRUTOR
        /// =====================================

        public DoceUserControl()
        {
            InitializeComponent();
        }

        private async void DoceUserControl_Load(object sender, EventArgs e)
        {
            //Guard: não executa em tempo de Design
            if (DesignMode) return;

            //Inicializa serviços
            _doceService = new DoceApiService();
            _categoriasService = new CategoriasApiService();

            DoceTheme.AplicarEstiloGrid(gridBanco);

            //Configurar permissões
            ConfigurarPermissões();

            //Reservado para carregarDados

            await CarregarDadosAsync();

        }

        private void ConfigurarPermissões()
        {
            bool isAdmin = SessionManager.Instance.IsAdmin;
            btnNovo.Visible = isAdmin;
            btnEditar.Visible = isAdmin;
            btnExcluir.Visible = isAdmin;
        }

        private async Task CarregarDadosAsync()
        {
            gridBanco.Rows.Clear();

            try
            {
                var tarefaDoces = _doceService.GetAllAsync();
                var tarefaCategorias = _categoriasService.GetAllAsync();
                await Task.WhenAll(tarefaDoces, tarefaCategorias);

                _todosDoces = tarefaDoces.Result;
                _categorias = tarefaCategorias.Result;

                PopularGrid(_todosDoces);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao carregar doces: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
        }
        private void PopularGrid(List<DoceResponseDto> doces)
        {
            gridBanco.Rows.Clear();

            foreach (var doce in doces)
            {
                gridBanco.Rows.Add(
                    doce.Id,
                    doce.Title,
                    doce.CategoryName,
                    doce.IsFeatured,
                    doce.CreatedAt.ToString("dd/MM/yyyy HH:mm"));

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e) => FiltrarDoces();


        private void FiltrarDoces()
        {
            var termo = txtPesquisa.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termo))
            {
                PopularGrid(_todosDoces);
                return;
            }

            var filtrados = _todosDoces
                .Where(d => d.Title.Contains(termo, StringComparison.OrdinalIgnoreCase)
                || d.CategoryName.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            PopularGrid(filtrados);

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => FiltrarDoces();


        private DoceResponseDto? ObterDoceSelecionado()
        {
            if (gridBanco.SelectedRows.Count == 0) return null;
            var row = gridBanco.SelectedRows[0];
            var id = Convert.ToInt32(row.Cells["colId"].Value);
            return _todosDoces.FirstOrDefault(d => d.Id == id);
        }

        private async void btnNovo_Click(object sender, EventArgs e)
        {
            using var form = new DoceFormDialog(_categorias, null);
            if (form.ShowDialog() == DialogResult.OK && form.DoceDto != null)
            {
                var (success, _, error) = await _doceService.CreateAsync(form.DoceDto);
                if (success)
                {
                    MessageBox.Show("✅ Doce criado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var doce = ObterDoceSelecionado();
            if (doce == null)
            {
                MessageBox.Show($"Selecione um doce para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using var form = new DoceFormDialog(_categorias, doce);
            if (form.ShowDialog() == DialogResult.OK && form.UpdateDto != null)
            {
                var (success, _, error) = await _doceService.UpdateAsync(doce.Id, form.UpdateDto);
                if (success)
                {
                    MessageBox.Show("✅ Doce atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    await CarregarDadosAsync();
                }
                else
                {
                    MessageBox.Show($"❌ {error}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                }
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            var doce = ObterDoceSelecionado();
            if (doce == null)
            {
                MessageBox.Show("Selecione um doce para excluir.", "Aviso",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }


            var conf = MessageBox.Show($"Deseja excluir o doce \"{doce.Title}\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (conf != DialogResult.Yes) return;

            var (sucess, error) = await _doceService.DeleteAsync(doce.Id);
            if (sucess)
            {
                MessageBox.Show(
                   "Doce Excluído com sucesso!",
                   "Sucesso",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
            else
            {
                MessageBox.Show(
                   $"{error}", "Erro",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }

        }

        private async void btnAtualizar_Click(object sender, EventArgs e) => await CarregarDadosAsync();



    }
}
