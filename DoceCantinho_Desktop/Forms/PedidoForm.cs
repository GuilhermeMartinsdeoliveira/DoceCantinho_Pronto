using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Services;
using DoceCantinho.Desktop.Helpers;

namespace DoceCantinho.Desktop1.Forms
{
    public partial class PedidoForm : Form
    {
        private readonly DoceApiService _doceService;
        private readonly UsuariosApiService _usuarioService;

        private readonly List<DoceResponseDto> _doces = new();
        private readonly List<UsuarioResponseDto> _usuarios = new();

        private decimal _total = 0m;

        public PedidoForm()
        {
            InitializeComponent();

            _doceService = new DoceApiService();
            _usuarioService = new UsuariosApiService();

            ConfigurarEventos();
            ConfigurarGrid();

            nudQuantidade.Minimum = 1;
            nudQuantidade.Maximum = 999;
            nudQuantidade.Value = 1;

            _ = CarregarDadosAsync();
        }

        // ============================================================
        // EVENTOS
        // ============================================================

        private void ConfigurarEventos()
        {
            btnCancelar.Click += BtnCancelar_Click;
            btnAdicionar.Click += BtnAdicionar_Click;
            btnSalvar.Click += BtnSalvar_Click;

            cmbCliente.SelectedIndexChanged += CmbCliente_SelectedIndexChanged;
            cmbDoce.SelectedIndexChanged += CmbDoce_SelectedIndexChanged;

            dgvItens.CellClick += DgvItens_CellClick;
        }

        // ============================================================
        // CARREGAR DADOS
        // ============================================================

        private async Task CarregarDadosAsync()
        {
            btnSalvar.Enabled = false;
            btnAdicionar.Enabled = false;

            try
            {
                await CarregarUsuariosAsync();
                await CarregarDocesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar os dados do pedido.\n\n" +
                    ex.Message,
                    "Doce Cantinho",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSalvar.Enabled = true;
            }
        }

        // ============================================================
        // CARREGAR CLIENTES
        // ============================================================

        private async Task CarregarUsuariosAsync()
        {
            try
            {
                cmbCliente.Enabled = false;

                var usuarios = await _usuarioService.GetAllAsync();

                _usuarios.Clear();

                foreach (var usuario in usuarios)
                {
                    _usuarios.Add(usuario);
                }

                cmbCliente.DataSource = null;

                if (_usuarios.Count == 0)
                {
                    cmbCliente.Items.Clear();

                    LimparDadosCliente();

                    MessageBox.Show(
                        "Nenhum cliente cadastrado foi encontrado.",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                cmbCliente.DataSource = _usuarios;

                /*
                 * Atualmente o cadastro de usuário utiliza o e-mail
                 * como UserName.
                 *
                 * Por isso o ComboBox mostra o e-mail.
                 */
                cmbCliente.DisplayMember = "Email";
                cmbCliente.ValueMember = "Id";

                cmbCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar os clientes.\n\n" +
                    ex.Message,
                    "Erro ao carregar clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cmbCliente.Enabled = true;
            }
        }

        // ============================================================
        // SELECIONAR CLIENTE
        // ============================================================

        private void CmbCliente_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cmbCliente.SelectedItem is not UsuarioResponseDto usuario)
            {
                LimparDadosCliente();
                return;
            }

            /*
             * Como atualmente o sistema não possui um campo Nome
             * separado no cadastro de ApplicationUser, usamos
             * UserName e, caso esteja vazio, o Email.
             */
            txtNomeCliente.Text =
                !string.IsNullOrWhiteSpace(usuario.Nome)
                    ? usuario.Nome
                    : usuario.Email;

            txtTelefone.Text = usuario.Telefone ?? string.Empty;

            txtEndereco.Text = MontarEndereco(usuario);
        }

        // ============================================================
        // MONTAR ENDEREÇO
        // ============================================================

        private string MontarEndereco(UsuarioResponseDto usuario)
        {
            var partes = new List<string>();

            if (!string.IsNullOrWhiteSpace(usuario.Logradouro))
                partes.Add(usuario.Logradouro);

            if (!string.IsNullOrWhiteSpace(usuario.Numero))
                partes.Add($"nº {usuario.Numero}");

            if (!string.IsNullOrWhiteSpace(usuario.Complemento))
                partes.Add(usuario.Complemento);

            if (!string.IsNullOrWhiteSpace(usuario.Bairro))
                partes.Add(usuario.Bairro);

            if (!string.IsNullOrWhiteSpace(usuario.Cidade))
                partes.Add(usuario.Cidade);

            if (!string.IsNullOrWhiteSpace(usuario.Estado))
                partes.Add(usuario.Estado);

            if (!string.IsNullOrWhiteSpace(usuario.Cep))
                partes.Add($"CEP {usuario.Cep}");

            return string.Join(", ", partes);
        }

        private void LimparDadosCliente()
        {
            txtNomeCliente.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
        }

        // ============================================================
        // CONFIGURAÇÃO DO GRID
        // ============================================================

        private void ConfigurarGrid()
        {
            dgvItens.Columns.Clear();

            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colDoceId",
                    HeaderText = "ID",
                    Visible = false
                });

            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colProduto",
                    HeaderText = "Produto",
                    FillWeight = 40
                });

            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colPreco",
                    HeaderText = "Preço",
                    FillWeight = 17
                });

            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colQuantidade",
                    HeaderText = "Quantidade",
                    FillWeight = 17
                });

            dgvItens.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "colSubtotal",
                    HeaderText = "Subtotal",
                    FillWeight = 18
                });

            dgvItens.Columns.Add(
                new DataGridViewButtonColumn
                {
                    Name = "colRemover",
                    HeaderText = "",
                    Text = "Remover",
                    UseColumnTextForButtonValue = true,
                    FillWeight = 16
                });

            dgvItens.Columns["colPreco"]!
                .DefaultCellStyle.Format = "C2";

            dgvItens.Columns["colSubtotal"]!
                .DefaultCellStyle.Format = "C2";

            dgvItens.Columns["colPreco"]!
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

            dgvItens.Columns["colQuantidade"]!
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            dgvItens.Columns["colSubtotal"]!
                .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
        }

        // ============================================================
        // CARREGAR DOCES
        // ============================================================

        private async Task CarregarDocesAsync()
        {
            try
            {
                cmbDoce.Enabled = false;
                btnAdicionar.Enabled = false;

                var doces = await _doceService.GetAllAsync();

                _doces.Clear();

                foreach (var doce in doces)
                {
                    _doces.Add(doce);
                }

                cmbDoce.DataSource = null;

                if (_doces.Count == 0)
                {
                    cmbDoce.Items.Clear();
                    txtPreco.Text = string.Empty;

                    MessageBox.Show(
                        "Nenhum doce ativo com estoque disponível foi encontrado.\n\n" +
                        "Verifique se existem produtos cadastrados e ativos.",
                        "Produtos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                cmbDoce.DataSource = _doces;

                cmbDoce.DisplayMember = "Title";
                cmbDoce.ValueMember = "Id";

                cmbDoce.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível carregar os doces.\n\n" +
                    "Detalhes:\n" +
                    ex.Message,
                    "Erro ao carregar produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cmbDoce.Enabled = true;

                btnAdicionar.Enabled = _doces.Count > 0;
            }
        }

        // ============================================================
        // SELEÇÃO DO DOCE
        // ============================================================

        private void CmbDoce_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cmbDoce.SelectedItem is not DoceResponseDto doce)
            {
                txtPreco.Text = string.Empty;
                return;
            }

            txtPreco.Text =
                ((decimal)doce.Preco).ToString(
                    "C2",
                    CultureInfo.CurrentCulture);

            AtualizarLimiteQuantidade();
        }

        // ============================================================
        // ADICIONAR PRODUTO
        // ============================================================

        private void BtnAdicionar_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbDoce.SelectedItem is not DoceResponseDto doce)
            {
                MessageBox.Show(
                    "Selecione um doce.",
                    "Produto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int quantidade = (int)nudQuantidade.Value;

            if (quantidade <= 0)
                return;

            int quantidadeExistente =
                ObterQuantidadeDoce(doce.Id);

            if (quantidadeExistente + quantidade >
                doce.QuantidadeEstoque)
            {
                int disponivel =
                    doce.QuantidadeEstoque -
                    quantidadeExistente;

                MessageBox.Show(
                    $"Estoque insuficiente para \"{doce.Title}\".\n\n" +
                    $"Disponível: {disponivel}",
                    "Estoque",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Se o produto já estiver na lista,
            // apenas aumenta a quantidade.
            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colDoceId"].Value == null)
                    continue;

                int id =
                    Convert.ToInt32(
                        row.Cells["colDoceId"].Value);

                if (id == doce.Id)
                {
                    int novaQuantidade =
                        Convert.ToInt32(
                            row.Cells["colQuantidade"].Value) +
                        quantidade;

                    decimal subtotal =
                        (decimal)doce.Preco *
                        novaQuantidade;

                    row.Cells["colQuantidade"].Value =
                        novaQuantidade;

                    row.Cells["colSubtotal"].Value =
                        subtotal;

                    RecalcularTotal();
                    AtualizarLimiteQuantidade();

                    return;
                }
            }

            decimal preco =
                (decimal)doce.Preco;

            decimal novoSubtotal =
                preco * quantidade;

            dgvItens.Rows.Add(
                doce.Id,
                doce.Title,
                preco,
                quantidade,
                novoSubtotal,
                "Remover");

            RecalcularTotal();
            AtualizarLimiteQuantidade();
        }

        // ============================================================
        // REMOVER PRODUTO
        // ============================================================

        private void DgvItens_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (dgvItens.Columns[e.ColumnIndex].Name !=
                "colRemover")
                return;

            var resultado =
                MessageBox.Show(
                    "Deseja remover este produto do pedido?",
                    "Remover produto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            dgvItens.Rows.RemoveAt(e.RowIndex);

            RecalcularTotal();
            AtualizarLimiteQuantidade();
        }

        // ============================================================
        // QUANTIDADE DE UM DOCE
        // ============================================================

        private int ObterQuantidadeDoce(int doceId)
        {
            int quantidade = 0;

            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colDoceId"].Value == null)
                    continue;

                int id =
                    Convert.ToInt32(
                        row.Cells["colDoceId"].Value);

                if (id == doceId)
                {
                    quantidade +=
                        Convert.ToInt32(
                            row.Cells["colQuantidade"].Value);
                }
            }

            return quantidade;
        }

        // ============================================================
        // ATUALIZAR LIMITE DO SPINNER
        // ============================================================

        private void AtualizarLimiteQuantidade()
        {
            if (cmbDoce.SelectedItem is not DoceResponseDto doce)
                return;

            int quantidadeJaAdicionada =
                ObterQuantidadeDoce(doce.Id);

            int disponivel =
                doce.QuantidadeEstoque -
                quantidadeJaAdicionada;

            MessageBox.Show(
                $"Produto: {doce.Title}\n" +
                $"Estoque: {doce.QuantidadeEstoque}\n" +
                $"Já adicionado: {quantidadeJaAdicionada}\n" +
                $"Disponível: {disponivel}",
                "DEBUG ESTOQUE");

            if (disponivel <= 0)
            {
                nudQuantidade.Maximum = 1;
                nudQuantidade.Value = 1;
                btnAdicionar.Enabled = false;
                return;
            }

            nudQuantidade.Maximum = disponivel;

            if (nudQuantidade.Value > disponivel)
                nudQuantidade.Value = disponivel;

            if (nudQuantidade.Value < 1)
                nudQuantidade.Value = 1;

            btnAdicionar.Enabled = true;
        }

        // ============================================================
        // CALCULAR TOTAL
        // ============================================================

        private void RecalcularTotal()
        {
            _total = 0m;

            foreach (DataGridViewRow row in dgvItens.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["colSubtotal"].Value == null)
                    continue;

                _total +=
                    Convert.ToDecimal(
                        row.Cells["colSubtotal"].Value);
            }

            lblTotal.Text =
                _total.ToString(
                    "C2",
                    CultureInfo.CurrentCulture);
        }

        // ============================================================
        // SALVAR PEDIDO
        // ============================================================

        private async void BtnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            if (!ValidarPedido())
                return;

            try
            {
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAdicionar.Enabled = false;
                cmbCliente.Enabled = false;
                cmbDoce.Enabled = false;

                var itens =
                    new List<OrderItemRequest>();

                foreach (DataGridViewRow row in dgvItens.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int doceId =
                        Convert.ToInt32(
                            row.Cells["colDoceId"].Value);

                    string nome =
                        Convert.ToString(
                            row.Cells["colProduto"].Value)
                        ?? string.Empty;

                    decimal preco =
                        Convert.ToDecimal(
                            row.Cells["colPreco"].Value);

                    int quantidade =
                        Convert.ToInt32(
                            row.Cells["colQuantidade"].Value);

                    itens.Add(
                        new OrderItemRequest
                        {
                            DoceId = doceId,
                            Nome = nome,
                            Preco = preco,
                            Quantidade = quantidade
                        });
                }

                var dto =
                    new CreateOrderRequest
                    {
                        NomeCliente =
                            txtNomeCliente.Text.Trim(),

                        Telefone =
                            txtTelefone.Text.Trim(),

                        Endereco =
                            string.IsNullOrWhiteSpace(
                                txtEndereco.Text)
                                ? null
                                : txtEndereco.Text.Trim(),

                        Items = itens
                    };

                var http =
                    HttpClientHelper.Instance;

                var resultado =
                    await http.PostAsync<CreateOrderResponse>(
                        "/api/orders",
                        dto);

                if (!resultado.Success)
                {
                    MessageBox.Show(
                        resultado.ErrorMessage,
                        "Erro ao salvar pedido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                string mensagem =
                    resultado.Data != null
                        ? $"Pedido #{resultado.Data.OrderId} criado com sucesso!"
                        : "Pedido criado com sucesso!";

                MessageBox.Show(
                    mensagem,
                    "Pedido criado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao salvar o pedido.\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                cmbCliente.Enabled = true;
                cmbDoce.Enabled = true;

                btnAdicionar.Enabled =
                    _doces.Count > 0;
            }
        }

        // ============================================================
        // VALIDAÇÃO
        // ============================================================

    private bool ValidarPedido()
    {
        if (cmbCliente.SelectedItem
            is not UsuarioResponseDto)
        {
            MessageBox.Show(
                "Selecione um cliente.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cmbCliente.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(
            txtNomeCliente.Text))
        {
            MessageBox.Show(
                "O cliente selecionado não possui nome ou e-mail.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        if (string.IsNullOrWhiteSpace(
            txtTelefone.Text))
        {
            MessageBox.Show(
                "O cliente selecionado não possui telefone cadastrado.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTelefone.Focus();
            return false;
        }

        // ============================================================
        // VERIFICAR SE EXISTE PELO MENOS UM ITEM REAL
        // ============================================================

        bool possuiItens = false;

        foreach (DataGridViewRow row in dgvItens.Rows)
        {
            if (row.IsNewRow)
                continue;

            if (row.Cells["colDoceId"].Value == null)
                continue;

            possuiItens = true;
            break;
        }

        if (!possuiItens)
        {
            MessageBox.Show(
                "Adicione pelo menos um produto ao pedido.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cmbDoce.Focus();
            return false;
        }

        if (_total <= 0)
        {
            MessageBox.Show(
                "O total do pedido deve ser maior que zero.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        return true;
        }

        // ============================================================
        // CANCELAR
        // ============================================================

        private void BtnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // ============================================================
        // DTO - CRIAR PEDIDO
        // ============================================================

        private class CreateOrderRequest
        {
            public string NomeCliente { get; set; }
                = string.Empty;

            public string Telefone { get; set; }
                = string.Empty;

            public string? Endereco { get; set; }

            public List<OrderItemRequest> Items { get; set; }
                = new();
        }

        // ============================================================
        // DTO - ITEM
        // ============================================================

        private class OrderItemRequest
        {
            public int DoceId { get; set; }

            public string Nome { get; set; }
                = string.Empty;

            public decimal Preco { get; set; }

            public int Quantidade { get; set; }
        }

        // ============================================================
        // DTO - RESPOSTA
        // ============================================================

        private class CreateOrderResponse
        {
            public int OrderId { get; set; }

            public string? PaymentPath { get; set; }
        }
    }
}