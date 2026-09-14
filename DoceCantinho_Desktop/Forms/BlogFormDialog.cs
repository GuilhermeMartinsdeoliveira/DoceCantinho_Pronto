using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using System;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Forms
{
    public partial class BlogFormDialog : Form
    {
        private readonly BlogApiService _service;

        private readonly BlogPostResponseDto? _postExistente;

        private bool _preenchendo;


        public CreateBlogPostDto? CreateDto
        {
            get;
            private set;
        }


        public UpdateBlogPostDto? UpdateDto
        {
            get;
            private set;
        }


        // ============================================================
        // NOVA PUBLICAÇÃO
        // ============================================================

        public BlogFormDialog()
            : this(null)
        {
        }


        // ============================================================
        // NOVA / EDIÇÃO
        // ============================================================

        public BlogFormDialog(
            BlogPostResponseDto? post)
        {
            InitializeComponent();

            _service =
                new BlogApiService();

            _postExistente =
                post;

            ConfigurarEventos();
        }


        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            Load -=
                BlogFormDialog_Load;

            Load +=
                BlogFormDialog_Load;


            txtTitulo.TextChanged -=
                txtTitulo_TextChanged;

            txtTitulo.TextChanged +=
                txtTitulo_TextChanged;


            btnSalvar.Click -=
                btnSalvar_Click;

            btnSalvar.Click +=
                btnSalvar_Click;


            btnCancelar.Click -=
                btnCancelar_Click;

            btnCancelar.Click +=
                btnCancelar_Click;


            btnFechar.Click -=
                btnCancelar_Click;

            btnFechar.Click +=
                btnCancelar_Click;
        }


        // ============================================================
        // LOAD
        // ============================================================

        private void BlogFormDialog_Load(
            object? sender,
            EventArgs e)
        {
            _preenchendo = true;

            try
            {
                bool editando =
                    _postExistente != null;


                lblTituloJanela.Text =
                    editando
                        ? "Editar publicação"
                        : "Nova publicação";


                lblSubtitulo.Text =
                    editando
                        ? "Atualize os dados e o conteúdo do artigo"
                        : "Cadastre uma nova publicação para o blog";


                btnSalvar.Text =
                    editando
                        ? "Salvar alterações"
                        : "Publicar";


                // ====================================================
                // EDITANDO
                // ====================================================

                if (editando)
                {
                    var p =
                        _postExistente!;


                    txtTitulo.Text =
                        p.Title;

                    txtSlug.Text =
                        p.Slug;

                    txtCategoria.Text =
                        p.Category;

                    txtCapa.Text =
                        p.CoverImageUrl;

                    txtResumo.Text =
                        p.Excerpt;

                    txtConteudo.Text =
                        p.Content;

                    txtTags.Text =
                        p.Tags;

                    txtAutor.Text =
                        p.AuthorName;

                    txtCargoAutor.Text =
                        p.AuthorRole;

                    txtAvatarAutor.Text =
                        p.AuthorAvatar;

                    txtBioAutor.Text =
                        p.AuthorBio;


                    dtPublicacao.Value =
                        p.PublishedAt == default
                            ? DateTime.Now
                            : p.PublishedAt.ToLocalTime();


                    chkPublicado.Checked =
                        p.IsPublished;

                    chkDestaque.Checked =
                        p.Featured;
                }


                // ====================================================
                // NOVA
                // ====================================================

                else
                {
                    var usuario =
                        SessionManager.Instance.CurrentUser;


                    txtAutor.Text =
                        usuario?.Nome ??
                        string.Empty;


                    txtCargoAutor.Text =
                        usuario?.IsAdmin == true
                            ? "Administrador"
                            : "Equipe Doce Cantinho";


                    txtAvatarAutor.Text =
                        !string.IsNullOrWhiteSpace(
                            usuario?.FotoPerfil
                        )

                        &&

                        usuario!.FotoPerfil.Length <= 500

                        &&

                        (
                            usuario.FotoPerfil.StartsWith(
                                "http://",
                                StringComparison.OrdinalIgnoreCase
                            )

                            ||

                            usuario.FotoPerfil.StartsWith(
                                "https://",
                                StringComparison.OrdinalIgnoreCase
                            )
                        )

                            ? usuario.FotoPerfil
                            : string.Empty;


                    dtPublicacao.Value =
                        DateTime.Now;


                    chkPublicado.Checked =
                        true;

                    chkDestaque.Checked =
                        false;
                }
            }
            finally
            {
                _preenchendo =
                    false;
            }
        }


        // ============================================================
        // GERAR SLUG
        // ============================================================

        private void txtTitulo_TextChanged(
            object? sender,
            EventArgs e)
        {
            if (_preenchendo ||
                _postExistente != null)
            {
                return;
            }

            txtSlug.Text =
                GerarSlug(
                    txtTitulo.Text
                );
        }


        private static string GerarSlug(
            string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;


            string normalizado =
                texto
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

                    .Replace("ú", "u")
                    .Replace("ü", "u")

                    .Replace("ç", "c");


            var chars =
                new char[
                    normalizado.Length
                ];


            for (
                int i = 0;
                i < normalizado.Length;
                i++)
            {
                chars[i] =
                    char.IsLetterOrDigit(
                        normalizado[i])
                        ? normalizado[i]
                        : '-';
            }


            string slug =
                new string(chars);


            while (
                slug.Contains("--"))
            {
                slug =
                    slug.Replace(
                        "--",
                        "-"
                    );
            }


            return slug.Trim('-');
        }


        // ============================================================
        // SALVAR
        // ============================================================

        private async void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            if (!Validar())
                return;


            SetCarregando(true);


            try
            {
                // ====================================================
                // NOVO
                // ====================================================

                if (_postExistente == null)
                {
                    var dto =
                        CriarCreateDto();


                    var resultado =
                        await _service.CreateAsync(
                            dto
                        );


                    if (!resultado.Success)
                    {
                        MostrarErro(
                            resultado.ErrorMessage
                        );

                        return;
                    }


                    CreateDto =
                        dto;
                }


                // ====================================================
                // EDITAR
                // ====================================================

                else
                {
                    var dto =
                        CriarUpdateDto();


                    var resultado =
                        await _service.UpdateAsync(
                            _postExistente.Id,
                            dto
                        );


                    if (!resultado.Success)
                    {
                        MostrarErro(
                            resultado.ErrorMessage
                        );

                        return;
                    }


                    UpdateDto =
                        dto;
                }


                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MostrarErro(
                    $"Erro ao salvar a publicação:\n\n{ex.Message}"
                );
            }
            finally
            {
                SetCarregando(false);
            }
        }


        // ============================================================
        // CREATE DTO
        // ============================================================

        private CreateBlogPostDto CriarCreateDto()
        {
            return new CreateBlogPostDto
            {
                Title =
                    txtTitulo.Text.Trim(),

                Slug =
                    txtSlug.Text.Trim(),

                Excerpt =
                    txtResumo.Text.Trim(),

                Content =
                    txtConteudo.Text.Trim(),

                CoverImageUrl =
                    txtCapa.Text.Trim(),

                Category =
                    txtCategoria.Text.Trim(),

                Tags =
                    txtTags.Text.Trim(),

                AuthorName =
                    txtAutor.Text.Trim(),

                AuthorRole =
                    txtCargoAutor.Text.Trim(),

                AuthorAvatar =
                    txtAvatarAutor.Text.Trim(),

                AuthorBio =
                    txtBioAutor.Text.Trim(),

                PublishedAt =
                    dtPublicacao.Value,

                IsPublished =
                    chkPublicado.Checked,

                Featured =
                    chkDestaque.Checked
            };
        }


        // ============================================================
        // UPDATE DTO
        // ============================================================

        private UpdateBlogPostDto CriarUpdateDto()
        {
            return new UpdateBlogPostDto
            {
                Title =
                    txtTitulo.Text.Trim(),

                Slug =
                    txtSlug.Text.Trim(),

                Excerpt =
                    txtResumo.Text.Trim(),

                Content =
                    txtConteudo.Text.Trim(),

                CoverImageUrl =
                    txtCapa.Text.Trim(),

                Category =
                    txtCategoria.Text.Trim(),

                Tags =
                    txtTags.Text.Trim(),

                AuthorName =
                    txtAutor.Text.Trim(),

                AuthorRole =
                    txtCargoAutor.Text.Trim(),

                AuthorAvatar =
                    txtAvatarAutor.Text.Trim(),

                AuthorBio =
                    txtBioAutor.Text.Trim(),

                PublishedAt =
                    dtPublicacao.Value,

                IsPublished =
                    chkPublicado.Checked,

                Featured =
                    chkDestaque.Checked
            };
        }


        // ============================================================
        // VALIDAÇÃO
        // ============================================================

        private bool Validar()
        {
            if (
                string.IsNullOrWhiteSpace(
                    txtTitulo.Text))
            {
                MostrarErro(
                    "Informe o título da publicação."
                );

                txtTitulo.Focus();

                return false;
            }


            if (
                txtTitulo.Text.Trim().Length > 200)
            {
                MostrarErro(
                    "O título pode ter no máximo 200 caracteres."
                );

                txtTitulo.Focus();

                return false;
            }


            if (
                string.IsNullOrWhiteSpace(
                    txtCategoria.Text))
            {
                MostrarErro(
                    "Informe a categoria."
                );

                txtCategoria.Focus();

                return false;
            }


            if (
                string.IsNullOrWhiteSpace(
                    txtResumo.Text))
            {
                MostrarErro(
                    "Informe o resumo da publicação."
                );

                txtResumo.Focus();

                return false;
            }


            if (
                txtResumo.Text.Trim().Length > 500)
            {
                MostrarErro(
                    "O resumo pode ter no máximo 500 caracteres."
                );

                txtResumo.Focus();

                return false;
            }


            if (
                string.IsNullOrWhiteSpace(
                    txtConteudo.Text))
            {
                MostrarErro(
                    "Informe o conteúdo da publicação."
                );

                txtConteudo.Focus();

                return false;
            }


            if (
                string.IsNullOrWhiteSpace(
                    txtAutor.Text))
            {
                MostrarErro(
                    "Informe o nome do autor."
                );

                txtAutor.Focus();

                return false;
            }


            return true;
        }


        // ============================================================
        // CARREGANDO
        // ============================================================

        private void SetCarregando(
            bool carregando)
        {
            btnSalvar.Enabled =
                !carregando;

            btnCancelar.Enabled =
                !carregando;

            btnFechar.Enabled =
                !carregando;

            Cursor =
                carregando
                    ? Cursors.WaitCursor
                    : Cursors.Default;
        }


        // ============================================================
        // ERRO
        // ============================================================

        private void MostrarErro(
            string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "Blog",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }


        // ============================================================
        // CANCELAR
        // ============================================================

        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}