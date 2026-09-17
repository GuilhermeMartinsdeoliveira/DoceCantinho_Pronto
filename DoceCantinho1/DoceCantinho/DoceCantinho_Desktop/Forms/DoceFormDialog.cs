using DoceCantinho.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void DoceFormDialog_Load(object sender, EventArgs e)
        {
            //Guard
            if (DesignMode) return;

            // Configura título baseado no modo (criação/edição)
            this.Text = _doceExistente == null ? "Novo Doce" : "Editar Doce";
            lblTitulo.Text = _doceExistente == null ? "➕ Novo Doce" : "✏️ Editar Doce";

            //Popula o ComboBox de categorias
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Selecione uma categoria...");
            foreach (var cat in _categorias)
                cmbCategoria.Items.Add(cat.Name);
            cmbCategoria.SelectedIndex = 0;

            //Preenche campos se estiver no modo edição
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            if (_doceExistente == null) return;

            txtTitulo.Text = _doceExistente.Title;
            txtDescricao.Text = _doceExistente.Description;
            txtUrl.Text = _doceExistente.CoverImageUrl;
            chkDestaque.Checked = _doceExistente.IsFeatured;

            var idx = _categorias.FindIndex(c => c.Id == _doceExistente.CategoryId);
            if (idx >= 0) cmbCategoria.SelectedIndex = idx + 1;

        }


        public DoceFormDialog(List<CategoriaResponseDto> categorias, DoceResponseDto? doce)
        {
            _categorias = categorias;
            _doceExistente = doce;
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show(
                    "Informe o título do doce.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategoria.SelectedIndex <= 0)
            {
                MessageBox.Show(
                 "Selecione uma categoria",
                 "Validação",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            var categoriaIdx = cmbCategoria.SelectedIndex - 1;
            var categoriaId = _categorias[categoriaIdx].Id;

            if (_doceExistente == null)
            {
                DoceDto = new CreateDoceDto
                {
                    Title = txtTitulo.Text.Trim(),
                    Description = txtDescricao.Text.Trim(),
                    CoverImageUrl = txtUrl.Text.Trim(),
                    CategoryId = categoriaId,
                    IsFeatured = chkDestaque.Checked
                };
            }
            else
            {
                UpdateDto = new UpdateDoceDto
                {
                    Title = txtTitulo.Text.Trim(),
                    Description = txtDescricao.Text.Trim(),
                    CoverImageUrl = txtUrl.Text.Trim(),
                    CategoryId = categoriaId,
                    IsFeatured = chkDestaque.Checked
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
