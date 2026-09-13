using DoceCantinho.Desktop.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class DoceFormDialog : Form
    {
        // ============================================================
        // PROPRIEDADES
        // ============================================================

        public CreateDoceDto? DoceDto { get; private set; }

        public UpdateDoceDto? UpdateDto { get; private set; }

        public string? ImagemArquivoPath { get; private set; }

        // ============================================================
        // CAMPOS
        // ============================================================

        private string? _imagemBase64;

        private bool _preenchendoCampos;

        private readonly List<CategoriaResponseDto> _categorias;

        private readonly DoceResponseDto? _doceExistente;

        // ============================================================
        // CONSTRUTOR - NOVO
        // ============================================================

        public DoceFormDialog()
        {
            _categorias = new List<CategoriaResponseDto>();
            _doceExistente = null;

            InitializeComponent();

            InicializarEventos();
        }

        // ============================================================
        // CONSTRUTOR - NOVO / EDITAR
        // ============================================================

        public DoceFormDialog(
            List<CategoriaResponseDto> categorias,
            DoceResponseDto? doce = null)
        {
            _categorias = categorias ?? new List<CategoriaResponseDto>();
            _doceExistente = doce;

            InitializeComponent();

            InicializarEventos();
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void InicializarEventos()
        {
            // LOAD
            Load -= DoceFormDialog_Load;
            Load += DoceFormDialog_Load;

            // SELECIONAR IMAGEM DO COMPUTADOR
            btnSelecionarImagem.Click -= btnSelecionarImagem_Click;
            btnSelecionarImagem.Click += btnSelecionarImagem_Click;

            // REMOVER IMAGEM
            btnRemoverImagem.Click -= btnRemoverImagem_Click;
            btnRemoverImagem.Click += btnRemoverImagem_Click;

            // ADICIONAR IMAGEM POR URL
            btnAdicionarImagemUrl.Click -= btnAdicionarImagemUrl_Click;
            btnAdicionarImagemUrl.Click += btnAdicionarImagemUrl_Click;

            // SALVAR
            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            // CANCELAR
            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // URL
            txtUrl.TextChanged -= TxtUrl_TextChanged;
            txtUrl.TextChanged += TxtUrl_TextChanged;
        }

        // ============================================================
        // LOAD
        // ============================================================

        private void DoceFormDialog_Load(
            object? sender,
            EventArgs e)
        {
            if (DesignMode)
                return;

            bool editando = _doceExistente != null;

            Text = editando
                ? "Editar Doce"
                : "Novo Doce";

            lblTitulo.Text = editando
                ? "✏️ Editar Doce"
                : "➕ Novo Doce";

            btnSalvar.Text = editando
                ? "✓  Salvar alterações"
                : "✓  Salvar Doce";

            ConfigurarCampos();

            CarregarCategorias();

            PreencherCampos();
        }

        // ============================================================
        // CONFIGURAÇÃO
        // ============================================================

        private void ConfigurarCampos()
        {
            // PREÇO
            nudPreco.Minimum = 0;
            nudPreco.Maximum = 999999;
            nudPreco.DecimalPlaces = 2;
            nudPreco.Increment = 0.50M;
            nudPreco.ThousandsSeparator = true;

            // ESTOQUE
            nudEstoque.Minimum = 0;
            nudEstoque.Maximum = 999999;
            nudEstoque.DecimalPlaces = 0;
            nudEstoque.Increment = 1;

            // CURSORES
            btnSalvar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
            btnSelecionarImagem.Cursor = Cursors.Hand;
            btnRemoverImagem.Cursor = Cursors.Hand;
            cmbCategoria.Cursor = Cursors.Hand;

            // PREVIEW
            pictureImagem.SizeMode =
                PictureBoxSizeMode.Zoom;
        }

        // ============================================================
        // CATEGORIAS
        // ============================================================

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();

            cmbCategoria.Items.Add(
                "Selecione uma categoria...");

            foreach (CategoriaResponseDto categoria in _categorias)
            {
                cmbCategoria.Items.Add(
                    categoria.Name);
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
                // ====================================================
                // NOVO
                // ====================================================

                if (_doceExistente == null)
                {
                    txtTitulo.Clear();
                    txtDescricao.Clear();

                    nudPreco.Value = 0;
                    nudEstoque.Value = 0;

                    chkDestaque.Checked = false;

                    cmbCategoria.SelectedIndex =
                        _categorias.Count > 0
                            ? 0
                            : -1;

                    _imagemBase64 = null;
                    ImagemArquivoPath = null;

                    txtUrl.Clear();

                    lblArquivoImagem.Text =
                        "Nenhum arquivo selecionado";

                    LimparPreview();

                    return;
                }

                // ====================================================
                // EDIÇÃO
                // ====================================================

                txtTitulo.Text =
                    _doceExistente.Title ?? string.Empty;

                txtDescricao.Text =
                    _doceExistente.Description ?? string.Empty;

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
                    Convert.ToDecimal(
                        _doceExistente.QuantidadeEstoque);

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

                cmbCategoria.SelectedIndex = 0;

                int categoriaIndex =
                    _categorias.FindIndex(
                        c => c.Id ==
                             _doceExistente.CategoryId);

                if (categoriaIndex >= 0)
                {
                    cmbCategoria.SelectedIndex =
                        categoriaIndex + 1;
                }

                // ====================================================
                // IMAGEM
                // ====================================================

                string imagem =
                    _doceExistente.CoverImageUrl ??
                    string.Empty;

                if (EhImagemBase64(imagem))
                {
                    _imagemBase64 = imagem;

                    txtUrl.Clear();

                    lblArquivoImagem.Text =
                        "Imagem armazenada no produto";

                    CarregarPreviewBase64(imagem);
                }
                else
                {
                    _imagemBase64 = null;

                    txtUrl.Text = imagem;

                    lblArquivoImagem.Text =
                        string.IsNullOrWhiteSpace(imagem)
                            ? "Nenhum arquivo selecionado"
                            : "Imagem por URL";

                    if (!string.IsNullOrWhiteSpace(imagem))
                    {
                        _ = CarregarPreviewUrlAsync(
                            imagem);
                    }
                    else
                    {
                        LimparPreview();
                    }
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

            string url =
                txtUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
                return;

            _imagemBase64 = null;
            ImagemArquivoPath = null;

            lblArquivoImagem.Text =
                "Imagem por URL";

            _ = CarregarPreviewUrlAsync(url);
        }

        private void btnAdicionarImagemUrl_Click(
    object? sender,
    EventArgs e)
        {
            string url = txtUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(
                    "Digite a URL da imagem.",
                    "Imagem por URL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUrl.Focus();
                return;
            }

            if (!Uri.TryCreate(
                url,
                UriKind.Absolute,
                out Uri? uri) ||
                (uri.Scheme != Uri.UriSchemeHttp &&
                 uri.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show(
                    "Informe uma URL válida da imagem.",
                    "URL inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUrl.Focus();
                return;
            }

            _imagemBase64 = null;
            ImagemArquivoPath = null;

            lblArquivoImagem.Text =
                "Imagem adicionada por URL";

            _ = CarregarPreviewUrlAsync(url);
        }

        // ============================================================
        // SELECIONAR IMAGEM
        // ============================================================

        private void btnSelecionarImagem_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                using OpenFileDialog dialog =
                    new OpenFileDialog();

                dialog.Multiselect = false;

                dialog.Filter =
                    "Imagens|*.jpg;*.jpeg;*.png;*.webp;*.bmp|" +
                    "JPEG|*.jpg;*.jpeg|" +
                    "PNG|*.png|" +
                    "WEBP|*.webp|" +
                    "BMP|*.bmp";

                dialog.Title =
                    "Selecionar imagem do doce";

                if (dialog.ShowDialog(this) !=
                    DialogResult.OK)
                {
                    return;
                }

                string caminho =
                    dialog.FileName;

                if (string.IsNullOrWhiteSpace(caminho))
                    return;

                if (!File.Exists(caminho))
                {
                    MessageBox.Show(
                        "O arquivo selecionado não existe.",
                        "Arquivo inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                FileInfo arquivo =
                    new FileInfo(caminho);

                // ====================================================
                // LIMITE DE 5 MB
                // ====================================================

                if (arquivo.Length >
                    5 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "A imagem não pode ter mais de 5 MB.",
                        "Imagem muito grande",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // ====================================================
                // LER ARQUIVO
                // ====================================================

                byte[] bytes =
                    File.ReadAllBytes(caminho);

                string extensao =
                    Path.GetExtension(caminho)
                        .ToLowerInvariant();

                string mimeType =
                    extensao switch
                    {
                        ".jpg" =>
                            "image/jpeg",

                        ".jpeg" =>
                            "image/jpeg",

                        ".png" =>
                            "image/png",

                        ".webp" =>
                            "image/webp",

                        ".bmp" =>
                            "image/bmp",

                        _ =>
                            "application/octet-stream"
                    };

                _imagemBase64 =
                    $"data:{mimeType};base64," +
                    Convert.ToBase64String(bytes);

                ImagemArquivoPath =
                    caminho;

                // ====================================================
                // LIMPAR URL
                // ====================================================

                _preenchendoCampos = true;

                try
                {
                    txtUrl.Clear();
                }
                finally
                {
                    _preenchendoCampos = false;
                }

                // ====================================================
                // NOME DO ARQUIVO
                // ====================================================

                lblArquivoImagem.Text =
                    Path.GetFileName(caminho);

                // ====================================================
                // PREVIEW
                // ====================================================

                CarregarPreviewBase64(
                    _imagemBase64);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível selecionar a imagem.\n\n" +
                    ex.Message,
                    "Erro ao carregar imagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // REMOVER IMAGEM
        // ============================================================

        private void btnRemoverImagem_Click(
            object? sender,
            EventArgs e)
        {
            _imagemBase64 = null;

            ImagemArquivoPath = null;

            _preenchendoCampos = true;

            try
            {
                txtUrl.Clear();
            }
            finally
            {
                _preenchendoCampos = false;
            }

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
                if (string.IsNullOrWhiteSpace(base64))
                {
                    LimparPreview();
                    return;
                }

                string dados =
                    base64;

                int virgula =
                    dados.IndexOf(',');

                if (virgula >= 0)
                {
                    dados =
                        dados.Substring(
                            virgula + 1);
                }

                byte[] bytes =
                    Convert.FromBase64String(
                        dados);

                using MemoryStream stream =
                    new MemoryStream(bytes);

                using Image original =
                    Image.FromStream(stream);

                Image novaImagem =
                    new Bitmap(original);

                Image? imagemAntiga =
                    pictureImagem.Image;

                pictureImagem.Image =
                    novaImagem;

                pictureImagem.SizeMode =
                    PictureBoxSizeMode.Zoom;

                imagemAntiga?.Dispose();
            }
            catch
            {
                LimparPreview();
            }
        }



        // ============================================================
        // PREVIEW URL
        // ============================================================

        private async Task
            CarregarPreviewUrlAsync(
                string url)
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

                using Image original =
                    Image.FromStream(stream);

                Image novaImagem =
                    new Bitmap(original);

                if (IsDisposed || Disposing)
                {
                    novaImagem.Dispose();
                    return;
                }

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (IsDisposed || Disposing)
                        {
                            novaImagem.Dispose();
                            return;
                        }

                        Image? antiga =
                            pictureImagem.Image;

                        pictureImagem.Image =
                            novaImagem;

                        pictureImagem.SizeMode =
                            PictureBoxSizeMode.Zoom;

                        antiga?.Dispose();
                    }));
                }
                else
                {
                    Image? antiga =
                        pictureImagem.Image;

                    pictureImagem.Image =
                        novaImagem;

                    pictureImagem.SizeMode =
                        PictureBoxSizeMode.Zoom;

                    antiga?.Dispose();
                }
            }
            catch
            {
                // O preview não impede o cadastro.
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

        private static bool EhImagemBase64(
            string? valor)
        {
            return
                !string.IsNullOrWhiteSpace(valor) &&
                valor.StartsWith(
                    "data:image/",
                    StringComparison.OrdinalIgnoreCase);
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            if (!ValidarCampos())
                return;

            // ========================================================
            // CATEGORIA
            // ========================================================

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

                cmbCategoria.Focus();

                return;
            }

            int categoriaId =
                _categorias[categoriaIndex].Id;

            // ========================================================
            // VALORES
            // ========================================================

            decimal preco =
                nudPreco.Value;

            int estoque =
                Convert.ToInt32(
                    nudEstoque.Value);

            // ========================================================
            // IMAGEM
            // ========================================================

            string imagem =
                !string.IsNullOrWhiteSpace(
                    _imagemBase64)
                    ? _imagemBase64
                    : txtUrl.Text.Trim();

            // ========================================================
            // NOVO DOCE
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

                UpdateDto = null;
            }
            // ========================================================
            // EDITAR DOCE
            // ========================================================
            else
            {
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

                DoceDto = null;
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
            if (string.IsNullOrWhiteSpace(
                txtTitulo.Text))
            {
                MessageBox.Show(
                    "Informe o nome do doce.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTitulo.Focus();

                return false;
            }

            if (_categorias.Count == 0)
            {
                MessageBox.Show(
                    "Nenhuma categoria foi carregada.\n\n" +
                    "Cadastre uma categoria ou verifique a conexão com a API.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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
            object? sender,
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
            LimparPreview();

            base.OnFormClosed(e);
        }
    }
}