using DoceCantinho.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class DoceFormDialog : Form
    {
        public CreateDoceDto? DoceDto { get; private set; }
        public UpdateDoceDto? UpdateDto { get; private set; }

        // Caminho da imagem selecionada no computador
        public string? ImagemArquivoPath { get; private set; }

        // Imagem convertida para Base64
        private string? _imagemBase64;

        private bool _preenchendoCampos;

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

        // ============================================================
        // LOAD
        // ============================================================

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

        // ============================================================
        // CONFIGURAÇÕES
        // ============================================================

        private void ConfigurarCampos()
        {
            nudPreco.Minimum = 0;
            nudPreco.Maximum = 999999;
            nudPreco.DecimalPlaces = 2;
            nudPreco.Increment = 0.50M;
            nudPreco.ThousandsSeparator = true;

            nudEstoque.Minimum = 0;
            nudEstoque.Maximum = 999999;
            nudEstoque.Increment = 1;

            btnSalvar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;

            if (btnSelecionarImagem != null)
                btnSelecionarImagem.Cursor = Cursors.Hand;

            if (btnRemoverImagem != null)
                btnRemoverImagem.Cursor = Cursors.Hand;

            if (txtUrl != null)
                txtUrl.TextChanged += TxtUrl_TextChanged;
        }

        // ============================================================
        // CATEGORIAS
        // ============================================================

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

        // ============================================================
        // PREENCHER CAMPOS
        // ============================================================

        private void PreencherCampos()
        {
            _preenchendoCampos = true;

            try
            {
                if (_doceExistente == null)
                {
                    nudPreco.Value = 0;
                    nudEstoque.Value = 0;
                    chkDestaque.Checked = false;

                    LimparPreview();

                    return;
                }

                txtTitulo.Text =
                    _doceExistente.Title ?? string.Empty;

                txtDescricao.Text =
                    _doceExistente.Description ?? string.Empty;

                string imagem =
                    _doceExistente.CoverImageUrl ?? string.Empty;

                // ====================================================
                // IMAGEM
                // ====================================================

                if (EhImagemBase64(imagem))
                {
                    _imagemBase64 = imagem;

                    txtUrl.Text = string.Empty;

                    CarregarPreviewBase64(imagem);
                }
                else
                {
                    txtUrl.Text = imagem;

                    if (!string.IsNullOrWhiteSpace(imagem))
                        _ = CarregarPreviewUrlAsync(imagem);
                }

                // ====================================================
                // PREÇO
                // ====================================================

                decimal preco;

                try
                {
                    preco = Convert.ToDecimal(
                        _doceExistente.Preco);
                }
                catch
                {
                    preco = 0;
                }

                if (preco < nudPreco.Minimum)
                    preco = nudPreco.Minimum;

                if (preco > nudPreco.Maximum)
                    preco = nudPreco.Maximum;

                nudPreco.Value = preco;

                // ====================================================
                // ESTOQUE
                // ====================================================

                decimal estoque =
                    _doceExistente.QuantidadeEstoque;

                if (estoque < nudEstoque.Minimum)
                    estoque = nudEstoque.Minimum;

                if (estoque > nudEstoque.Maximum)
                    estoque = nudEstoque.Maximum;

                nudEstoque.Value = estoque;

                // ====================================================
                // DESTAQUE
                // ====================================================

                chkDestaque.Checked =
                    _doceExistente.IsFeatured;

                // ====================================================
                // CATEGORIA
                // ====================================================

                int categoriaIndex =
                    _categorias.FindIndex(
                        c => c.Id == _doceExistente.CategoryId);

                if (categoriaIndex >= 0)
                {
                    cmbCategoria.SelectedIndex =
                        categoriaIndex + 1;
                }
            }
            finally
            {
                _preenchendoCampos = false;
            }
        }

        // ============================================================
        // URL ALTERADA
        // ============================================================

        private void TxtUrl_TextChanged(
            object? sender,
            EventArgs e)
        {
            if (_preenchendoCampos)
                return;

            // Se o usuário começou a usar URL,
            // remove a imagem local selecionada.
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                _imagemBase64 = null;
                ImagemArquivoPath = null;

                if (lblArquivoImagem != null)
                    lblArquivoImagem.Text =
                        "Nenhum arquivo selecionado";

                _ = CarregarPreviewUrlAsync(
                    txtUrl.Text.Trim());
            }
        }

        // ============================================================
        // SELECIONAR IMAGEM
        // ============================================================

        private void btnSelecionarImagem_Click(
            object sender,
            EventArgs e)
        {
            using OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Title =
                "Selecionar imagem do doce";

            dialog.Filter =
                "Imagens|*.jpg;*.jpeg;*.png;*.webp;*.bmp|Todos os arquivos|*.*";

            dialog.Multiselect = false;

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            FileInfo arquivo =
                new FileInfo(dialog.FileName);

            // Limite de 5 MB
            if (arquivo.Length > 5 * 1024 * 1024)
            {
                MessageBox.Show(
                    "A imagem não pode ter mais de 5 MB.",
                    "Imagem muito grande",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                byte[] bytes =
                    File.ReadAllBytes(dialog.FileName);

                string extensao =
                    Path.GetExtension(
                        dialog.FileName)
                    .ToLowerInvariant();

                string mimeType =
                    extensao switch
                    {
                        ".jpg" => "image/jpeg",
                        ".jpeg" => "image/jpeg",
                        ".png" => "image/png",
                        ".webp" => "image/webp",
                        ".bmp" => "image/bmp",
                        _ => "application/octet-stream"
                    };

                _imagemBase64 =
                    $"data:{mimeType};base64,{Convert.ToBase64String(bytes)}";

                ImagemArquivoPath =
                    dialog.FileName;

                // Limpa a URL porque o arquivo terá prioridade.
                _preenchendoCampos = true;

                try
                {
                    txtUrl.Text = string.Empty;
                }
                finally
                {
                    _preenchendoCampos = false;
                }

                if (lblArquivoImagem != null)
                {
                    lblArquivoImagem.Text =
                        Path.GetFileName(dialog.FileName);
                }

                CarregarPreviewBase64(_imagemBase64);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar a imagem.\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REMOVER IMAGEM
        // ============================================================

        private void btnRemoverImagem_Click(
            object sender,
            EventArgs e)
        {
            _imagemBase64 = null;
            ImagemArquivoPath = null;

            txtUrl.Text = string.Empty;

            if (lblArquivoImagem != null)
                lblArquivoImagem.Text =
                    "Nenhum arquivo selecionado";

            LimparPreview();
        }

        // ============================================================
        // PREVIEW BASE64
        // ============================================================

        private void CarregarPreviewBase64(
            string base64)
        {
            try
            {
                string dados = base64;

                int virgula =
                    dados.IndexOf(',');

                if (virgula >= 0)
                    dados =
                        dados.Substring(virgula + 1);

                byte[] bytes =
                    Convert.FromBase64String(dados);

                using MemoryStream stream =
                    new MemoryStream(bytes);

                using Image imagemOriginal =
                    Image.FromStream(stream);

                pictureImagem.Image =
                    new Bitmap(imagemOriginal);

                pictureImagem.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }
            catch
            {
                LimparPreview();
            }
        }

        // ============================================================
        // PREVIEW URL
        // ============================================================

        private async System.Threading.Tasks.Task
            CarregarPreviewUrlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            try
            {
                using HttpClient client =
                    new HttpClient();

                client.Timeout =
                    TimeSpan.FromSeconds(10);

                byte[] bytes =
                    await client.GetByteArrayAsync(url);

                using MemoryStream stream =
                    new MemoryStream(bytes);

                using Image imagemOriginal =
                    Image.FromStream(stream);

                Image imagem =
                    new Bitmap(imagemOriginal);

                if (IsDisposed)
                {
                    imagem.Dispose();
                    return;
                }

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        pictureImagem.Image = imagem;
                        pictureImagem.SizeMode =
                            PictureBoxSizeMode.Zoom;
                    }));
                }
                else
                {
                    pictureImagem.Image = imagem;
                    pictureImagem.SizeMode =
                        PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                // URL inválida ou inacessível.
                // Não interrompe o cadastro.
            }
        }

        // ============================================================
        // LIMPAR PREVIEW
        // ============================================================

        private void LimparPreview()
        {
            if (pictureImagem == null)
                return;

            Image? imagem =
                pictureImagem.Image;

            pictureImagem.Image = null;

            imagem?.Dispose();
        }

        // ============================================================
        // VERIFICAR BASE64
        // ============================================================

        private bool EhImagemBase64(
            string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return false;

            return valor.StartsWith(
                       "data:image/",
                       StringComparison.OrdinalIgnoreCase);
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private void btnSalvar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarCampos())
                return;

            int categoriaIndex =
                cmbCategoria.SelectedIndex - 1;

            if (categoriaIndex < 0 ||
                categoriaIndex >= _categorias.Count)
            {
                MessageBox.Show(
                    "Selecione uma categoria.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int categoriaId =
                _categorias[categoriaIndex].Id;

            decimal preco =
                nudPreco.Value;

            int estoque =
                (int)nudEstoque.Value;

            // ========================================================
            // IMAGEM
            // ========================================================

            string imagem;

            if (!string.IsNullOrWhiteSpace(_imagemBase64))
            {
                // Upload local
                imagem = _imagemBase64;
            }
            else
            {
                // URL
                imagem = txtUrl.Text.Trim();
            }

            // ========================================================
            // NOVO
            // ========================================================

            if (_doceExistente == null)
            {
                DoceDto =
                    new CreateDoceDto
                    {
                        Title =
                            txtTitulo.Text.Trim(),

                        Description =
                            txtDescricao.Text.Trim(),

                        CoverImageUrl =
                            imagem,

                        Preco =
                            Convert.ToDouble(preco),

                        QuantidadeEstoque =
                            estoque,

                        IsAtivo =
                            true,

                        CategoryId =
                            categoriaId,

                        IsFeatured =
                            chkDestaque.Checked
                    };
            }
            else
            {
                // ====================================================
                // EDITAR
                // ====================================================

                UpdateDto =
                    new UpdateDoceDto
                    {
                        Title =
                            txtTitulo.Text.Trim(),

                        Description =
                            txtDescricao.Text.Trim(),

                        CoverImageUrl =
                            imagem,

                        Preco =
                            Convert.ToDouble(preco),

                        QuantidadeEstoque =
                            estoque,

                        IsAtivo =
                            _doceExistente.IsAtivo,

                        CategoryId =
                            categoriaId,

                        IsFeatured =
                            chkDestaque.Checked
                    };
            }

            DialogResult =
                DialogResult.OK;

            Close();
        }

        // ============================================================
        // VALIDAÇÃO
        // ============================================================

        private bool ValidarCampos()
        {
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

        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DoceDto = null;
            UpdateDto = null;

            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // FECHAMENTO
        // ============================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (pictureImagem?.Image != null)
            {
                pictureImagem.Image.Dispose();
                pictureImagem.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}