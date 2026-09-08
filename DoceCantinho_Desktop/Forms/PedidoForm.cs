using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.Services;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.Forms
{
    public partial class PedidoForm : Form
    {
        // ==========================================
        // SERVIÇOS
        // ==========================================
        private readonly DoceApiService _doceService;
        private readonly UsuariosApiService _usuarioService;
        private readonly PedidosApiService _pedidoService;

        // ==========================================
        // DADOS
        // ==========================================
        private readonly List<DoceResponseDto> _doces = new();
        private readonly List<UsuarioResponseDto> _usuarios = new();

        // ==========================================
        // PEDIDO
        // ==========================================
        private decimal _total = 0m;
        private int _pedidoId = 0;
        private bool _modoEdicao = false;

        // ==========================================
        // BOTÃO X
        // ==========================================
        private Guna2Button? _btnFechar;

        // ==========================================
        // ARRASTAR FORM SEM BORDA
        // ==========================================
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public PedidoForm()
        {
            _modoEdicao = false;
            _pedidoId = 0;

            _doceService = new DoceApiService();
            _usuarioService = new UsuariosApiService();
            _pedidoService = new PedidosApiService();

            Text = "Novo Pedido";

            InitializeComponent();

            ConfigurarFormulario();
            ConfigurarEventos();
            CriarBotaoFechar();

            _ = CarregarDadosAsync();
        }

        public PedidoForm(int pedidoId)
        {
            _pedidoId = pedidoId;
            _modoEdicao = true;

            _doceService = new DoceApiService();
            _usuarioService = new UsuariosApiService();
            _pedidoService = new PedidosApiService();

            Text = $"Editar Pedido #{pedidoId}";

            InitializeComponent();

            ConfigurarFormulario();
            ConfigurarEventos();
            CriarBotaoFechar();

            _ = CarregarDadosAsync();
        }

        // ==========================================
        // CONFIGURAR FORMULÁRIO
        // ==========================================
        private void ConfigurarFormulario()
        {
            // ==========================================
            // SEM BORDA DO WINDOWS
            // ==========================================
            FormBorderStyle = FormBorderStyle.None;

            StartPosition = FormStartPosition.CenterParent;

            MaximizeBox = false;
            MinimizeBox = false;

            // ==========================================
            // ARRASTAR PELO CABEÇALHO
            // ==========================================
            pnlHeader.MouseDown -= PedidoForm_MouseDown;
            pnlHeader.MouseDown += PedidoForm_MouseDown;

            lblTitulo.MouseDown -= PedidoForm_MouseDown;
            lblTitulo.MouseDown += PedidoForm_MouseDown;

            lblSubtitulo.MouseDown -= PedidoForm_MouseDown;
            lblSubtitulo.MouseDown += PedidoForm_MouseDown;

            // ==========================================
            // GRID
            // ==========================================
            dgvItens.ReadOnly = true;
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.AllowUserToResizeRows = false;
            dgvItens.MultiSelect = false;
            dgvItens.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }


        // ==========================================
        // CONFIGURAR EVENTOS
        // ==========================================
        private void ConfigurarEventos()
        {
            // ==========================================
            // BOTÕES
            // ==========================================
            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            btnSalvar.Click -= btnSalvar_Click;
            btnSalvar.Click += btnSalvar_Click;

            btnAdicionar.Click -= btnAdicionar_Click;
            btnAdicionar.Click += btnAdicionar_Click;

            // ==========================================
            // COMBOS
            // ==========================================
            cmbCliente.SelectedIndexChanged -=
                cmbCliente_SelectedIndexChanged;

            cmbCliente.SelectedIndexChanged +=
                cmbCliente_SelectedIndexChanged;

            cmbDoce.SelectedIndexChanged -=
                cmbDoce_SelectedIndexChanged;

            cmbDoce.SelectedIndexChanged +=
                cmbDoce_SelectedIndexChanged;

            // ==========================================
            // GRID
            // ==========================================
            dgvItens.CellClick -= dgvItens_CellClick;
            dgvItens.CellClick += dgvItens_CellClick;
        }

        // ==========================================
        // CRIAR X
        // ==========================================
        private void CriarBotaoFechar()
        {
            if (_btnFechar != null)
                return;

            _btnFechar = new Guna2Button
            {
                Name = "btnFecharPedido",
                Text = "×",
                Size = new Size(42, 34),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right,

                Location = new Point(
                    ClientSize.Width - 50,
                    8
                ),

                BorderRadius = 8,

                FillColor =
                    Color.Transparent,

                ForeColor =
                    Color.FromArgb(
                        225,
                        210,
                        204
                    ),

                Font =
                    new Font(
                        "Segoe UI",
                        18F,
                        FontStyle.Regular
                    ),

                Cursor =
                    Cursors.Hand
            };

            _btnFechar.HoverState.FillColor =
                Color.FromArgb(
                    170,
                    65,
                    65
                );

            _btnFechar.HoverState.ForeColor =
                Color.White;

            _btnFechar.Click +=
                BtnFechar_Click;

            Controls.Add(_btnFechar);

            _btnFechar.BringToFront();

            Resize +=
                PedidoForm_Resize;
        }

        // ==========================================
        // POSICIONAR X
        // ==========================================
        private void PedidoForm_Resize(
            object? sender,
            EventArgs e)
        {
            if (_btnFechar == null)
                return;

            _btnFechar.Location =
                new Point(
                    ClientSize.Width -
                    _btnFechar.Width -
                    8,
                    8
                );

            _btnFechar.BringToFront();
        }

        // ==========================================
        // CLIQUE NO X
        // ==========================================
        private void BtnFechar_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        // ==========================================
        // CARREGAR DADOS
        // ==========================================
        private async Task CarregarDadosAsync()
        {
            try
            {
                btnSalvar.Enabled = false;
                btnAdicionar.Enabled = false;

                await CarregarUsuariosAsync();
                await CarregarDocesAsync();

                if (_modoEdicao && _pedidoId > 0)
                {
                    await CarregarPedidoEdicaoAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar os dados do pedido:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnSalvar.Enabled = true;
                btnAdicionar.Enabled = true;
            }
        }

        // ==========================================
        // CARREGAR USUÁRIOS
        // ==========================================
        private async Task CarregarUsuariosAsync()
        {
            _usuarios.Clear();

            var usuarios =
                await _usuarioService.GetAllAsync();

            if (usuarios == null)
                return;

            _usuarios.AddRange(usuarios);

            cmbCliente.DataSource = null;

            cmbCliente.DisplayMember =
                nameof(UsuarioResponseDto.Nome);

            cmbCliente.ValueMember =
                nameof(UsuarioResponseDto.Id);

            cmbCliente.DataSource =
                _usuarios;

            if (_usuarios.Count > 0)
            {
                cmbCliente.SelectedIndex = 0;
            }
        }

        // ==========================================
        // CARREGAR DOCES
        // ==========================================
        private async Task CarregarDocesAsync()
        {
            _doces.Clear();

            var doces =
                await _doceService.GetAllAsync();

            if (doces == null)
                return;

            foreach (var doce in doces)
            {
                if (!doce.IsAtivo)
                    continue;

                if (doce.QuantidadeEstoque <= 0)
                    continue;

                _doces.Add(doce);
            }

            cmbDoce.DataSource = null;

            cmbDoce.DisplayMember =
                nameof(DoceResponseDto.Title);

            cmbDoce.ValueMember =
                nameof(DoceResponseDto.Id);

            cmbDoce.DataSource =
                _doces;
        }

        // ==========================================
        // CARREGAR PEDIDO PARA EDIÇÃO
        // ==========================================
        private async Task CarregarPedidoEdicaoAsync()
        {
            var pedido =
                await _pedidoService
                    .GetByIdAsync(_pedidoId);

            if (pedido == null)
            {
                MessageBox.Show(
                    "Não foi possível localizar o pedido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
                return;
            }

            // ==========================================
            // DADOS DO CLIENTE
            // ==========================================
            txtNomeCliente.Text =
                pedido.NomeCliente ?? string.Empty;

            txtTelefone.Text =
                pedido.Telefone ?? string.Empty;

            txtEndereco.Text =
                pedido.Endereco ?? string.Empty;

            SelecionarClienteDoPedido(pedido);

            // ==========================================
            // TÍTULO
            // ==========================================
            lblTitulo.Text =
                $"Editar Pedido #{pedido.Id}";

            lblSubtitulo.Text =
                "Atualize o cliente e os produtos deste pedido.";

            // ==========================================
            // LIMPAR GRID
            // ==========================================
            dgvItens.Rows.Clear();

            // ==========================================
            // GARANTIR ESTRUTURA DO GRID
            // ==========================================
            if (dgvItens.Columns.Count == 0)
            {
                dgvItens.Columns.Add(
                    "DoceId",
                    "ID"
                );

                dgvItens.Columns.Add(
                    "Nome",
                    "Produto"
                );

                dgvItens.Columns.Add(
                    "Quantidade",
                    "Quantidade"
                );

                dgvItens.Columns.Add(
                    "Preco",
                    "Preço"
                );

                dgvItens.Columns.Add(
                    "Subtotal",
                    "Subtotal"
                );

                dgvItens.Columns[0]
                    .Visible = false;
            }

            // ==========================================
            // ADICIONAR ITENS
            // ==========================================
            foreach (var item in pedido.Items)
            {
                int indice =
                    dgvItens.Rows.Add(
                        item.DoceId,
                        item.Nome,
                        item.Quantidade,
                        item.Preco.ToString("C2"),
                        item.Subtotal.ToString("C2")
                    );

                dgvItens.Rows[indice]
                    .Tag = item.DoceId;
            }

            RecalcularTotal();
        }

        // ==========================================
        // SELECIONAR CLIENTE
        // ==========================================
        private void SelecionarClienteDoPedido(
            PedidoDetalheDto pedido)
        {
            if (_usuarios.Count == 0)
                return;

            int indiceCliente = -1;

            if (!string.IsNullOrWhiteSpace(
                pedido.Telefone))
            {
                indiceCliente =
                    _usuarios.FindIndex(
                        u =>
                            string.Equals(
                                NormalizarTelefone(
                                    u.Telefone
                                ),
                                NormalizarTelefone(
                                    pedido.Telefone
                                ),
                                StringComparison.OrdinalIgnoreCase
                            )
                    );
            }

            if (indiceCliente < 0 &&
                !string.IsNullOrWhiteSpace(
                    pedido.NomeCliente))
            {
                indiceCliente =
                    _usuarios.FindIndex(
                        u =>
                            string.Equals(
                                u.Nome,
                                pedido.NomeCliente,
                                StringComparison.OrdinalIgnoreCase
                            )
                    );
            }

            if (indiceCliente >= 0)
            {
                cmbCliente.SelectedIndex =
                    indiceCliente;
            }
        }

        // ==========================================
        // NORMALIZAR TELEFONE
        // ==========================================
        private string NormalizarTelefone(
            string? telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return string.Empty;

            return new string(
                telefone
                    .Where(char.IsDigit)
                    .ToArray()
            );
        }

        // ==========================================
        // ALTERAÇÃO DO CLIENTE
        // ==========================================
        private void cmbCliente_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cmbCliente.SelectedItem
                is not UsuarioResponseDto usuario)
            {
                return;
            }

            txtNomeCliente.Text =
                usuario.Nome ?? string.Empty;

            txtTelefone.Text =
                usuario.Telefone ?? string.Empty;

            txtEndereco.Text =
                MontarEndereco(usuario);
        }

        // ==========================================
        // MONTAR ENDEREÇO
        // ==========================================
        private string MontarEndereco(
            UsuarioResponseDto usuario)
        {
            var partes =
                new List<string>();

            if (!string.IsNullOrWhiteSpace(
                usuario.Logradouro))
            {
                string logradouro =
                    usuario.Logradouro.Trim();

                if (!string.IsNullOrWhiteSpace(
                    usuario.Numero))
                {
                    logradouro +=
                        $", {usuario.Numero.Trim()}";
                }

                partes.Add(logradouro);
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Complemento))
            {
                partes.Add(
                    usuario.Complemento.Trim()
                );
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Bairro))
            {
                partes.Add(
                    usuario.Bairro.Trim()
                );
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Cidade))
            {
                partes.Add(
                    usuario.Cidade.Trim()
                );
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Estado))
            {
                partes.Add(
                    usuario.Estado.Trim()
                );
            }

            if (!string.IsNullOrWhiteSpace(
                usuario.Cep))
            {
                partes.Add(
                    $"CEP {usuario.Cep.Trim()}"
                );
            }

            return string.Join(
                " - ",
                partes
            );
        }

        // ==========================================
        // ALTERAÇÃO DO DOCE
        // ==========================================
        private void cmbDoce_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (cmbDoce.SelectedItem
                is not DoceResponseDto doce)
            {
                txtPreco.Text = string.Empty;
                return;
            }

            txtPreco.Text =
                doce.Preco.ToString("C2");

            AtualizarLimiteQuantidade(doce);
        }

        // ==========================================
        // LIMITE DE QUANTIDADE
        // ==========================================
        private void AtualizarLimiteQuantidade(
            DoceResponseDto doce)
        {
            decimal estoque =
                Math.Max(
                    1,
                    doce.QuantidadeEstoque
                );

            nudQuantidade.Minimum = 1;

            nudQuantidade.Maximum =
                Math.Min(
                    999,
                    estoque
                );

            if (nudQuantidade.Value >
                nudQuantidade.Maximum)
            {
                nudQuantidade.Value =
                    nudQuantidade.Maximum;
            }
        }

        // ==========================================
        // ADICIONAR PRODUTO
        // ==========================================
        private void btnAdicionar_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbDoce.SelectedItem
                is not DoceResponseDto doce)
            {
                MessageBox.Show(
                    "Selecione um produto.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int quantidade =
                (int)nudQuantidade.Value;

            if (quantidade <= 0)
                return;

            // ==========================================
            // VERIFICAR ESTOQUE
            // ==========================================
            int estoqueDisponivel =
                doce.QuantidadeEstoque;

            if (quantidade >
                estoqueDisponivel)
            {
                MessageBox.Show(
                    $"Estoque disponível: {estoqueDisponivel}.",
                    "Estoque insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ==========================================
            // LOCALIZAR COLUNAS
            // ==========================================
            GarantirColunasGrid();

            // ==========================================
            // VERIFICAR SE JÁ EXISTE
            // ==========================================
            foreach (DataGridViewRow row
                in dgvItens.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Tag is int doceId &&
                    doceId == doce.Id)
                {
                    int quantidadeAtual =
                        Convert.ToInt32(
                            row.Cells["Quantidade"].Value
                        );

                    int novaQuantidade =
                        quantidadeAtual +
                        quantidade;

                    if (novaQuantidade >
                        estoqueDisponivel)
                    {
                        MessageBox.Show(
                            $"A quantidade total de \"{doce.Title}\" ultrapassa o estoque disponível.",
                            "Estoque insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }

                    row.Cells["Quantidade"].Value =
                        novaQuantidade;

                    row.Cells["Subtotal"].Value =
                        (
                            (decimal)doce.Preco *
                            novaQuantidade
                        ).ToString("C2");

                    RecalcularTotal();

                    return;
                }
            }

            // ==========================================
            // ADICIONAR NOVA LINHA
            // ==========================================
            decimal subtotal =
                (decimal)doce.Preco *
                quantidade;

            int indice =
                dgvItens.Rows.Add(
                    doce.Id,
                    doce.Title,
                    quantidade,
                    doce.Preco.ToString("C2"),
                    subtotal.ToString("C2")
                );

            dgvItens.Rows[indice].Tag =
                doce.Id;

            RecalcularTotal();
        }

        // ==========================================
        // GARANTIR COLUNAS
        // ==========================================
        private void GarantirColunasGrid()
        {
            if (dgvItens.Columns.Count > 0)
                return;

            dgvItens.Columns.Add(
                "DoceId",
                "ID"
            );

            dgvItens.Columns.Add(
                "Nome",
                "Produto"
            );

            dgvItens.Columns.Add(
                "Quantidade",
                "Quantidade"
            );

            dgvItens.Columns.Add(
                "Preco",
                "Preço"
            );

            dgvItens.Columns.Add(
                "Subtotal",
                "Subtotal"
            );

            dgvItens.Columns["DoceId"]
                .Visible = false;
        }

        // ==========================================
        // GRID CLICK
        // ==========================================
        private void dgvItens_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Neste momento não removemos automaticamente
            // nenhum item.
        }

        // ==========================================
        // RECALCULAR TOTAL
        // ==========================================
        private void RecalcularTotal()
        {
            _total = 0m;

            foreach (DataGridViewRow row
                in dgvItens.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["Quantidade"].Value == null)
                    continue;

                if (row.Cells["Preco"].Value == null)
                    continue;

                int quantidade =
                    Convert.ToInt32(
                        row.Cells["Quantidade"].Value
                    );

                string precoTexto =
                    row.Cells["Preco"].Value
                        .ToString() ?? "0";

                precoTexto =
                    precoTexto
                        .Replace("R$", "")
                        .Trim();

                if (!decimal.TryParse(
                    precoTexto,
                    System.Globalization.NumberStyles.Currency,
                    new System.Globalization.CultureInfo("pt-BR"),
                    out decimal preco))
                {
                    decimal.TryParse(
                        precoTexto,
                        out preco
                    );
                }

                _total +=
                    preco *
                    quantidade;
            }

            lblTotal.Text =
                _total.ToString("C2");
        }

        // ==========================================
        // SALVAR PEDIDO
        // ==========================================
        private async void btnSalvar_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtNomeCliente.Text))
            {
                MessageBox.Show(
                    "Selecione um cliente.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCliente.Focus();
                return;
            }

            if (dgvItens.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Adicione pelo menos um produto ao pedido.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;

            try
            {
                // ==========================================
                // EDIÇÃO
                // ==========================================
                if (_modoEdicao)
                {
                    var dtoEdicao =
                        new AtualizarPedidoDto
                        {
                            NomeCliente =
                                txtNomeCliente.Text.Trim(),

                            Telefone =
                                txtTelefone.Text.Trim(),

                            Endereco =
                                txtEndereco.Text.Trim()
                        };

                    foreach (DataGridViewRow row
                        in dgvItens.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        if (row.Tag is not int doceId)
                            continue;

                        string nome =
                            row.Cells["Nome"].Value?
                                .ToString() ?? "";

                        int quantidade =
                            Convert.ToInt32(
                                row.Cells["Quantidade"].Value
                            );

                        string precoTexto =
                            row.Cells["Preco"].Value?
                                .ToString() ?? "0";

                        precoTexto =
                            precoTexto
                                .Replace("R$", "")
                                .Trim();

                        decimal.TryParse(
                            precoTexto,
                            System.Globalization.NumberStyles.Currency,
                            new System.Globalization.CultureInfo("pt-BR"),
                            out decimal preco
                        );

                        dtoEdicao.Items.Add(
                            new AtualizarPedidoItemDto
                            {
                                DoceId = doceId,
                                Nome = nome,
                                Preco = preco,
                                Quantidade = quantidade
                            }
                        );
                    }

                    var resultado =
                        await _pedidoService.UpdateAsync(
                            _pedidoId,
                            dtoEdicao
                        );

                    if (!resultado.Success)
                    {
                        MessageBox.Show(
                            resultado.ErrorMessage,
                            "Erro ao atualizar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }

                    MessageBox.Show(
                        $"Pedido #{_pedidoId} atualizado com sucesso!",
                        "Pedido atualizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult =
                        DialogResult.OK;

                    Close();

                    return;
                }

                // ==========================================
                // NOVO PEDIDO
                // ==========================================
                var novoPedido =
                    new CreateOrderRequest
                    {
                        UserId =
                            SessionManager.Instance
                                .CurrentUser?.Id
                            ?? "",

                        NomeCliente =
                            txtNomeCliente.Text.Trim(),

                        Telefone =
                            txtTelefone.Text.Trim(),

                        Endereco =
                            txtEndereco.Text.Trim(),

                        Items =
                            new List<OrderItemRequest>()
                    };

                foreach (DataGridViewRow row
                    in dgvItens.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (row.Tag is not int doceId)
                        continue;

                    string nome =
                        row.Cells["Nome"].Value?
                            .ToString() ?? "";

                    int quantidade =
                        Convert.ToInt32(
                            row.Cells["Quantidade"].Value
                        );

                    string precoTexto =
                        row.Cells["Preco"].Value?
                            .ToString() ?? "0";

                    precoTexto =
                        precoTexto
                            .Replace("R$", "")
                            .Trim();

                    decimal.TryParse(
                        precoTexto,
                        System.Globalization.NumberStyles.Currency,
                        new System.Globalization.CultureInfo("pt-BR"),
                        out decimal preco
                    );

                    novoPedido.Items.Add(
                        new OrderItemRequest
                        {
                            DoceId = doceId,
                            Nome = nome,
                            Preco = preco,
                            Quantidade = quantidade
                        }
                    );
                }

                var http =
                    HttpClientHelper.Instance;

                var resultadoNovo =
                    await http.PostAsync<object>(
                        "/api/orders",
                        novoPedido
                    );

                if (!resultadoNovo.Success)
                {
                    MessageBox.Show(
                        resultadoNovo.ErrorMessage,
                        "Erro ao salvar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    "Pedido criado com sucesso!",
                    "Pedido criado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao salvar o pedido:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        // ==========================================
        // CANCELAR
        // ==========================================
        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        // ==========================================
        // ARRASTAR FORM
        // ==========================================
        private void PedidoForm_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            ReleaseCapture();

            SendMessage(
                Handle,
                WM_NCLBUTTONDOWN,
                HTCAPTION,
                0
            );
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            int lParam
        );

        // ==========================================
        // FECHAMENTO
        // ==========================================
        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (_btnFechar != null)
            {
                _btnFechar.Click -=
                    BtnFechar_Click;

                _btnFechar.Dispose();
                _btnFechar = null;
            }

            base.OnFormClosed(e);
        }

        // ==========================================
        // DTO NOVO PEDIDO
        // ==========================================
        private class CreateOrderRequest
        {
            public string UserId { get; set; } = "";
            public string NomeCliente { get; set; } = "";
            public string Telefone { get; set; } = "";
            public string Endereco { get; set; } = "";
            public List<OrderItemRequest> Items { get; set; } = new();
        }

        private class OrderItemRequest
        {
            public int DoceId { get; set; }
            public string Nome { get; set; } = "";
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
        }
    }
}