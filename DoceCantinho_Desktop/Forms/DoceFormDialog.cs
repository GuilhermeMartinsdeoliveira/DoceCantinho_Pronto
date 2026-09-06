using DoceCantinho.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class DoceFormDialog : Form
    {
        public CreateDoceDto? DoceDto { get; private set; }
        public UpdateDoceDto? UpdateDto { get; private set; }

        private List<CategoriaResponseDto> _categorias = new();
        private DoceResponseDto? _doceExistente;

        public DoceFormDialog()
        {
            InitializeComponent();
        }

        public DoceFormDialog(
            List<CategoriaResponseDto> categorias,
            DoceResponseDto? doce)
        {
            _categorias = categorias ?? new List<CategoriaResponseDto>();
            _doceExistente = doce;

            InitializeComponent();
        }

        private void DoceFormDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            Text = _doceExistente == null
                ? "Novo Doce"
                : "Editar Doce";

            lblTitulo.Text = _doceExistente == null
                ? "➕ Novo Doce"
                : "✏️ Editar Doce";

            ConfigurarCampos();

            CarregarCategorias();

            PreencherCampos();
        }

        private void ConfigurarCampos()
        {
            // Preço
            nudPreco.Minimum = 0;
            nudPreco.Maximum = 999999;
            nudPreco.DecimalPlaces = 2;
            nudPreco.Increment = 0.50M;
            nudPreco.ThousandsSeparator = true;

            // Estoque
            nudEstoque.Minimum = 0;
            nudEstoque.Maximum = 999999;
            nudEstoque.Increment = 1;

            // Cursor
            btnSalvar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
        }

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();

            cmbCategoria.Items.Add("Selecione uma categoria...");

            foreach (var categoria in _categorias)
            {
                cmbCategoria.Items.Add(categoria.Name);
            }

            cmbCategoria.SelectedIndex = 0;
        }

        private void PreencherCampos()
        {
            if (_doceExistente == null)
            {
                nudPreco.Value = 0;
                nudEstoque.Value = 0;
                chkDestaque.Checked = false;
                return;
            }

            txtTitulo.Text = _doceExistente.Title ?? string.Empty;

            txtDescricao.Text =
                _doceExistente.Description ?? string.Empty;

            txtUrl.Text =
                _doceExistente.CoverImageUrl ?? string.Empty;

            // PREÇO
            decimal preco = Convert.ToDecimal(
                _doceExistente.Preco,
                CultureInfo.InvariantCulture);

            if (preco < nudPreco.Minimum)
                preco = nudPreco.Minimum;

            if (preco > nudPreco.Maximum)
                preco = nudPreco.Maximum;

            nudPreco.Value = preco;

            // ESTOQUE
            decimal estoque = _doceExistente.QuantidadeEstoque;

            if (estoque < nudEstoque.Minimum)
                estoque = nudEstoque.Minimum;

            if (estoque > nudEstoque.Maximum)
                estoque = nudEstoque.Maximum;

            nudEstoque.Value = estoque;

            // DESTAQUE
            chkDestaque.Checked = _doceExistente.IsFeatured;

            // CATEGORIA
            int categoriaIndex = _categorias.FindIndex(
                c => c.Id == _doceExistente.CategoryId);

            if (categoriaIndex >= 0)
            {
                cmbCategoria.SelectedIndex = categoriaIndex + 1;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int categoriaIndex = cmbCategoria.SelectedIndex - 1;

            int categoriaId = _categorias[categoriaIndex].Id;

            decimal preco = nudPreco.Value;

            int estoque = (int)nudEstoque.Value;

            // =========================================================
            // NOVO DOCE
            // =========================================================

            if (_doceExistente == null)
            {
                DoceDto = new CreateDoceDto
                {
                    Title = txtTitulo.Text.Trim(),

                    Description = txtDescricao.Text.Trim(),

                    CoverImageUrl = txtUrl.Text.Trim(),

                    Preco = Convert.ToDouble(preco),

                    QuantidadeEstoque = estoque,

                    IsAtivo = true,

                    CategoryId = categoriaId,

                    IsFeatured = chkDestaque.Checked
                };
            }

            // =========================================================
            // EDITAR DOCE
            // =========================================================

            else
            {
                UpdateDto = new UpdateDoceDto
                {
                    Title = txtTitulo.Text.Trim(),

                    Description = txtDescricao.Text.Trim(),

                    CoverImageUrl = txtUrl.Text.Trim(),

                    Preco = Convert.ToDouble(preco),

                    QuantidadeEstoque = estoque,

                    IsAtivo = _doceExistente.IsAtivo,

                    CategoryId = categoriaId,

                    IsFeatured = chkDestaque.Checked
                };
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidarCampos()
        {
            // =========================================================
            // TÍTULO
            // =========================================================

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show(
                    "Informe o título do doce.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitulo.Focus();

                return false;
            }

            // =========================================================
            // CATEGORIA
            // =========================================================

            if (cmbCategoria.SelectedIndex <= 0)
            {
                MessageBox.Show(
                    "Selecione uma categoria.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategoria.Focus();

                return false;
            }

            // =========================================================
            // PREÇO
            // =========================================================

            if (nudPreco.Value <= 0)
            {
                MessageBox.Show(
                    "Informe um preço maior que R$ 0,00.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudPreco.Focus();

                return false;
            }

            // =========================================================
            // ESTOQUE
            // =========================================================

            if (nudEstoque.Value < 0)
            {
                MessageBox.Show(
                    "O estoque não pode ser negativo.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                nudEstoque.Focus();

                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DoceDto = null;
            UpdateDto = null;

            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}