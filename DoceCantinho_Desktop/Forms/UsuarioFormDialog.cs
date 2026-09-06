using DoceCantinho.Desktop.DTOs;
using System.Text.Json;

namespace DoceCantinho.Desktop1.Forms
{
    public partial class UsuarioFormDialog : Form
    {
        public CreateUsuarioDto? UsuarioDto { get; private set; }

        public UpdateUsuarioDto? UsuarioUpdateDto { get; private set; }

        public string? UsuarioId { get; private set; }

        private readonly bool _modoEdicao;

        private bool _formatandoCep = false;
        private bool _formatandoTelefone = false;
        private bool _buscandoCep = false;

        // ============================================================
        // CONSTRUTOR - NOVO USUÁRIO
        // ============================================================

        public UsuarioFormDialog()
        {
            InitializeComponent();

            _modoEdicao = false;

            ConfigurarFormulario();

            txtCep.TextChanged += txtCep_TextChanged;
            txtTelefone.TextChanged += txtTelefone_TextChanged;

            cmbPerfil.Items.Clear();
            cmbPerfil.Items.Add("Admin");
            cmbPerfil.Items.Add("Usuário");

            cmbPerfil.SelectedIndex = 1;
        }

        // ============================================================
        // CONSTRUTOR - EDITAR USUÁRIO
        // ============================================================

        public UsuarioFormDialog(UsuarioResponseDto usuarioExistente)
        {
            InitializeComponent();

            _modoEdicao = true;

            ConfigurarFormulario();

            txtCep.TextChanged += txtCep_TextChanged;
            txtTelefone.TextChanged += txtTelefone_TextChanged;

            cmbPerfil.Items.Clear();
            cmbPerfil.Items.Add("Admin");
            cmbPerfil.Items.Add("Usuário");

            UsuarioId = usuarioExistente.Id;

            // --------------------------------------------------------
            // DADOS PESSOAIS
            // --------------------------------------------------------

            txtNome.Text =
                usuarioExistente.Nome ?? string.Empty;

            txtTelefone.Text =
                FormatarTelefone(
                    usuarioExistente.Telefone ?? string.Empty);

            txtEmail.Text =
                usuarioExistente.Email ?? string.Empty;

            // --------------------------------------------------------
            // ENDEREÇO
            // --------------------------------------------------------

            txtLogradouro.Text =
                usuarioExistente.Logradouro ?? string.Empty;

            txtNumero.Text =
                usuarioExistente.Numero ?? string.Empty;

            txtComplemento.Text =
                usuarioExistente.Complemento ?? string.Empty;

            txtBairro.Text =
                usuarioExistente.Bairro ?? string.Empty;

            txtCidade.Text =
                usuarioExistente.Cidade ?? string.Empty;

            txtCep.Text =
                FormatarCep(
                    usuarioExistente.Cep ?? string.Empty);

            // --------------------------------------------------------
            // ESTADO
            // --------------------------------------------------------

            if (!string.IsNullOrWhiteSpace(usuarioExistente.Estado))
            {
                int indexEstado =
                    cmbEstado.Items.IndexOf(
                        usuarioExistente.Estado.ToUpper());

                if (indexEstado >= 0)
                    cmbEstado.SelectedIndex = indexEstado;
            }

            // --------------------------------------------------------
            // PERFIL
            // --------------------------------------------------------

            if (usuarioExistente.Roles != null &&
                usuarioExistente.Roles.Contains("Admin"))
            {
                cmbPerfil.SelectedItem = "Admin";
            }
            else
            {
                cmbPerfil.SelectedItem = "Usuário";
            }

            // --------------------------------------------------------
            // TEXTOS
            // --------------------------------------------------------

            lblTitulo.Text = "Editar usuário";

            lblSubtitulo.Text =
                "Atualize os dados e as informações de acesso do usuário.";

            btnSalvar.Text = "Salvar alterações";
        }

        // ============================================================
        // CONFIGURAÇÃO DO FORMULÁRIO
        // ============================================================

        private void ConfigurarFormulario()
        {
            StartPosition =
                FormStartPosition.CenterParent;

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            AcceptButton = btnSalvar;
            CancelButton = btnCancelar;

            ActiveControl = txtNome;
        }

        // ============================================================
        // SALVAR
        // ============================================================

        private void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            // --------------------------------------------------------
            // DADOS PRINCIPAIS
            // --------------------------------------------------------

            string nome =
                txtNome.Text.Trim();

            string telefone =
                SomenteNumeros(txtTelefone.Text);

            string email =
                txtEmail.Text.Trim();

            string senha =
                txtSenha.Text;

            string confirmar =
                txtConfirmar.Text;

            // --------------------------------------------------------
            // ENDEREÇO
            // --------------------------------------------------------

            string logradouro =
                txtLogradouro.Text.Trim();

            string numero =
                txtNumero.Text.Trim();

            string complemento =
                txtComplemento.Text.Trim();

            string bairro =
                txtBairro.Text.Trim();

            string cidade =
                txtCidade.Text.Trim();

            string estado =
                cmbEstado.SelectedItem?.ToString() ?? string.Empty;

            string cep =
                SomenteNumeros(txtCep.Text);

            // --------------------------------------------------------
            // PERFIL
            // --------------------------------------------------------

            string perfil =
                cmbPerfil.SelectedItem?.ToString() ?? string.Empty;

            // ========================================================
            // VALIDAÇÃO DO NOME
            // ========================================================

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show(
                    "Informe o nome do usuário.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();
                return;
            }

            if (nome.Length < 3)
            {
                MessageBox.Show(
                    "O nome deve possuir pelo menos 3 caracteres.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNome.Focus();
                return;
            }

            // ========================================================
            // VALIDAÇÃO DO TELEFONE
            // ========================================================

            if (string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show(
                    "Informe o telefone do usuário.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefone.Focus();
                return;
            }

            if (telefone.Length != 10 &&
                telefone.Length != 11)
            {
                MessageBox.Show(
                    "Informe um telefone válido com DDD.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefone.Focus();
                return;
            }

            // ========================================================
            // VALIDAÇÃO DO E-MAIL
            // ========================================================

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Informe o e-mail do usuário.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            if (!email.Contains("@") ||
                !email.Contains("."))
            {
                MessageBox.Show(
                    "Informe um e-mail válido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // ========================================================
            // VALIDAÇÃO DA SENHA
            // ========================================================

            if (!_modoEdicao)
            {
                // ----------------------------------------------------
                // NOVO USUÁRIO
                // ----------------------------------------------------

                if (string.IsNullOrWhiteSpace(senha))
                {
                    MessageBox.Show(
                        "Informe uma senha.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSenha.Focus();
                    return;
                }

                if (senha.Length < 6)
                {
                    MessageBox.Show(
                        "A senha deve possuir pelo menos 6 caracteres.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSenha.Focus();
                    return;
                }

                if (senha != confirmar)
                {
                    MessageBox.Show(
                        "A confirmação de senha não confere.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtConfirmar.Focus();
                    return;
                }
            }
            else
            {
                // ----------------------------------------------------
                // EDIÇÃO
                //
                // Senha é opcional.
                // Só valida se o usuário informar uma nova senha.
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(senha))
                {
                    if (senha.Length < 6)
                    {
                        MessageBox.Show(
                            "A senha deve possuir pelo menos 6 caracteres.",
                            "Validação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtSenha.Focus();
                        return;
                    }

                    if (senha != confirmar)
                    {
                        MessageBox.Show(
                            "A confirmação de senha não confere.",
                            "Validação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtConfirmar.Focus();
                        return;
                    }
                }
            }

            // ========================================================
            // VALIDAÇÃO DO ENDEREÇO
            // ========================================================

            if (string.IsNullOrWhiteSpace(logradouro))
            {
                MessageBox.Show(
                    "Informe o logradouro.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLogradouro.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(numero))
            {
                MessageBox.Show(
                    "Informe o número.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNumero.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(bairro))
            {
                MessageBox.Show(
                    "Informe o bairro.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBairro.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cidade))
            {
                MessageBox.Show(
                    "Informe a cidade.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCidade.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(estado))
            {
                MessageBox.Show(
                    "Selecione o estado.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEstado.Focus();
                return;
            }

            if (cep.Length != 8)
            {
                MessageBox.Show(
                    "Informe um CEP válido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCep.Focus();
                return;
            }

            // ========================================================
            // VALIDAÇÃO DO PERFIL
            // ========================================================

            if (string.IsNullOrWhiteSpace(perfil))
            {
                MessageBox.Show(
                    "Selecione o perfil do usuário.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPerfil.Focus();
                return;
            }

            string role =
                perfil == "Admin"
                    ? "Admin"
                    : "Usuário";

            // ========================================================
            // MODO EDIÇÃO
            // ========================================================

            if (_modoEdicao)
            {
                UsuarioUpdateDto =
                    new UpdateUsuarioDto
                    {
                        Nome = nome,

                        Telefone = telefone,

                        Email = email,

                        Password =
                            string.IsNullOrWhiteSpace(senha)
                                ? null
                                : senha,

                        ConfirmPassword =
                            string.IsNullOrWhiteSpace(senha)
                                ? null
                                : confirmar,

                        Logradouro = logradouro,

                        Numero = numero,

                        Complemento =
                            string.IsNullOrWhiteSpace(complemento)
                                ? null
                                : complemento,

                        Bairro = bairro,

                        Cidade = cidade,

                        Estado = estado,

                        Cep = cep,

                        Role = role
                    };

                DialogResult =
                    DialogResult.OK;

                Close();

                return;
            }

            // ========================================================
            // MODO NOVO USUÁRIO
            // ========================================================

            UsuarioDto =
                new CreateUsuarioDto
                {
                    Nome = nome,

                    Telefone = telefone,

                    Email = email,

                    Password = senha,

                    ConfirmPassword = confirmar,

                    Logradouro = logradouro,

                    Numero = numero,

                    Complemento =
                        string.IsNullOrWhiteSpace(complemento)
                            ? null
                            : complemento,

                    Bairro = bairro,

                    Cidade = cidade,

                    Estado = estado,

                    Cep = cep,

                    Role = role
                };

            DialogResult =
                DialogResult.OK;

            Close();
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

        // ============================================================
        // TELEFONE - FORMATAÇÃO AUTOMÁTICA
        // ============================================================

        private void txtTelefone_TextChanged(
            object? sender,
            EventArgs e)
        {
            if (_formatandoTelefone)
                return;

            string numeros =
                SomenteNumeros(txtTelefone.Text);

            if (numeros.Length > 11)
                numeros = numeros[..11];

            string formatado =
                FormatarTelefone(numeros);

            if (txtTelefone.Text == formatado)
                return;

            try
            {
                _formatandoTelefone = true;

                txtTelefone.Text =
                    formatado;

                txtTelefone.SelectionStart =
                    txtTelefone.Text.Length;
            }
            finally
            {
                _formatandoTelefone = false;
            }
        }

        private static string FormatarTelefone(
            string telefone)
        {
            string numeros =
                SomenteNumeros(telefone);

            if (numeros.Length > 11)
                numeros = numeros[..11];

            if (numeros.Length <= 2)
                return numeros;

            if (numeros.Length <= 6)
            {
                return $"({numeros[..2]}) " +
                       numeros[2..];
            }

            if (numeros.Length <= 10)
            {
                return $"({numeros[..2]}) " +
                       $"{numeros.Substring(2, 4)}-" +
                       numeros[6..];
            }

            return $"({numeros[..2]}) " +
                   $"{numeros.Substring(2, 5)}-" +
                   numeros[7..];
        }

        // ============================================================
        // CEP - FORMATAÇÃO AUTOMÁTICA
        // ============================================================

        private void txtCep_TextChanged(
            object? sender,
            EventArgs e)
        {
            if (_formatandoCep)
                return;

            string numeros =
                SomenteNumeros(txtCep.Text);

            if (numeros.Length > 8)
                numeros = numeros[..8];

            string formatado =
                FormatarCep(numeros);

            if (txtCep.Text != formatado)
            {
                try
                {
                    _formatandoCep = true;

                    txtCep.Text =
                        formatado;

                    txtCep.SelectionStart =
                        txtCep.Text.Length;
                }
                finally
                {
                    _formatandoCep = false;
                }
            }

            if (numeros.Length == 8 &&
                !_buscandoCep)
            {
                _ = BuscarCepAsync(numeros);
            }
        }

        private static string FormatarCep(
            string cep)
        {
            string numeros =
                SomenteNumeros(cep);

            if (numeros.Length > 8)
                numeros = numeros[..8];

            if (numeros.Length <= 5)
                return numeros;

            return $"{numeros[..5]}-{numeros[5..]}";
        }

        // ============================================================
        // VIA CEP
        // ============================================================

        private async Task BuscarCepAsync(
            string cep)
        {
            if (_buscandoCep)
                return;

            _buscandoCep = true;

            try
            {
                using HttpClient client =
                    new HttpClient();

                client.Timeout =
                    TimeSpan.FromSeconds(8);

                string url =
                    $"https://viacep.com.br/ws/{cep}/json/";

                HttpResponseMessage response =
                    await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return;

                string json =
                    await response.Content.ReadAsStringAsync();

                ViaCepResponse? resultado =
                    JsonSerializer.Deserialize<ViaCepResponse>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (resultado == null ||
                    resultado.Erro)
                {
                    return;
                }

                // ----------------------------------------------------
                // LOGRADOURO
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(
                    resultado.Logradouro))
                {
                    txtLogradouro.Text =
                        resultado.Logradouro;
                }

                // ----------------------------------------------------
                // COMPLEMENTO
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(
                    resultado.Complemento))
                {
                    txtComplemento.Text =
                        resultado.Complemento;
                }

                // ----------------------------------------------------
                // BAIRRO
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(
                    resultado.Bairro))
                {
                    txtBairro.Text =
                        resultado.Bairro;
                }

                // ----------------------------------------------------
                // CIDADE
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(
                    resultado.Localidade))
                {
                    txtCidade.Text =
                        resultado.Localidade;
                }

                // ----------------------------------------------------
                // ESTADO
                // ----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(
                    resultado.Uf))
                {
                    int indexEstado =
                        cmbEstado.Items.IndexOf(
                            resultado.Uf.ToUpper());

                    if (indexEstado >= 0)
                    {
                        cmbEstado.SelectedIndex =
                            indexEstado;
                    }
                }

                txtNumero.Focus();
            }
            catch (TaskCanceledException)
            {
                // Timeout. Não interrompe o usuário.
            }
            catch (HttpRequestException)
            {
                // Erro de conexão. Não interrompe o usuário.
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"[ViaCEP] Erro: {ex.Message}");
            }
            finally
            {
                _buscandoCep = false;
            }
        }

        // ============================================================
        // SOMENTE NÚMEROS
        // ============================================================

        private static string SomenteNumeros(
            string? valor)
        {
            if (string.IsNullOrEmpty(valor))
                return string.Empty;

            return new string(
                valor
                    .Where(char.IsDigit)
                    .ToArray());
        }

        // ============================================================
        // DTO VIA CEP
        // ============================================================

        private class ViaCepResponse
        {
            public string? Cep { get; set; }

            public string? Logradouro { get; set; }

            public string? Complemento { get; set; }

            public string? Bairro { get; set; }

            public string? Localidade { get; set; }

            public string? Uf { get; set; }

            public bool Erro { get; set; }
        }
    }
}