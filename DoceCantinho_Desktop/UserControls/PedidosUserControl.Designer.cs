namespace DoceCantinho.Desktop1.UserControls
{
    partial class PedidosUserControl
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se o recurso gerenciado deve ser descartado; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlPrincipal = new Panel();
            lblTotalPedidos = new Label();
            dgvPedidos = new DataGridView();
            colNumero = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            colProdutos = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            colPagamento = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAcoes = new DataGridViewTextBoxColumn();
            pnlFiltros = new Panel();
            btnCancelado = new Button();
            btnEntregue = new Button();
            btnPronto = new Button();
            btnPreparo = new Button();
            btnPendente = new Button();
            btnTodos = new Button();
            txtBuscar = new TextBox();
            lblBuscarIcone = new Label();
            btnNovo = new Button();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            pnlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.FromArgb(247, 244, 241);
            pnlPrincipal.Controls.Add(lblTotalPedidos);
            pnlPrincipal.Controls.Add(dgvPedidos);
            pnlPrincipal.Controls.Add(pnlFiltros);
            pnlPrincipal.Controls.Add(btnNovo);
            pnlPrincipal.Controls.Add(lblTitulo);
            pnlPrincipal.Controls.Add(lblSubtitulo);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 0);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(1180, 700);
            pnlPrincipal.TabIndex = 0;
            // 
            // lblTotalPedidos
            // 
            lblTotalPedidos.AutoSize = true;
            lblTotalPedidos.Font = new Font("Segoe UI", 9F);
            lblTotalPedidos.ForeColor = Color.FromArgb(145, 117, 105);
            lblTotalPedidos.Location = new Point(32, 625);
            lblTotalPedidos.Name = "lblTotalPedidos";
            lblTotalPedidos.Size = new Size(97, 15);
            lblTotalPedidos.TabIndex = 5;
            lblTotalPedidos.Text = "Total de pedidos:";
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AllowUserToResizeRows = false;
            dgvPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.BorderStyle = BorderStyle.None;
            dgvPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPedidos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPedidos.ColumnHeadersHeight = 38;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { colNumero, colCliente, colData, colProdutos, colValor, colPagamento, colStatus, colAcoes });
            dgvPedidos.EnableHeadersVisualStyles = false;
            dgvPedidos.GridColor = Color.FromArgb(238, 231, 227);
            dgvPedidos.Location = new Point(30, 245);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersVisible = false;
            dgvPedidos.RowTemplate.Height = 42;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(1120, 365);
            dgvPedidos.TabIndex = 4;
            // 
            // colNumero
            // 
            colNumero.DataPropertyName = "Id";
            colNumero.HeaderText = "Nº PEDIDO";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            colNumero.Width = 105;
            // 
            // colCliente
            // 
            colCliente.DataPropertyName = "NomeCliente";
            colCliente.HeaderText = "CLIENTE";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            colCliente.Width = 150;
            // 
            // colData
            // 
            colData.DataPropertyName = "CreatedAt";
            colData.HeaderText = "DATA";
            colData.Name = "colData";
            colData.ReadOnly = true;
            colData.Width = 125;
            // 
            // colProdutos
            // 
            colProdutos.DataPropertyName = "Produtos";
            colProdutos.HeaderText = "PRODUTOS";
            colProdutos.Name = "colProdutos";
            colProdutos.ReadOnly = true;
            colProdutos.Width = 180;
            // 
            // colValor
            // 
            colValor.DataPropertyName = "Total";
            colValor.HeaderText = "VALOR";
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            colValor.Width = 110;
            // 
            // colPagamento
            // 
            colPagamento.DataPropertyName = "PaymentMethod";
            colPagamento.HeaderText = "PAGAMENTO";
            colPagamento.Name = "colPagamento";
            colPagamento.ReadOnly = true;
            colPagamento.Width = 120;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "STATUS";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 110;
            // 
            // colAcoes
            // 
            colAcoes.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAcoes.HeaderText = "AÇÕES";
            colAcoes.Name = "colAcoes";
            colAcoes.ReadOnly = true;
            colAcoes.Width = 170;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.BorderStyle = BorderStyle.FixedSingle;
            pnlFiltros.Controls.Add(btnCancelado);
            pnlFiltros.Controls.Add(btnEntregue);
            pnlFiltros.Controls.Add(btnPronto);
            pnlFiltros.Controls.Add(btnPreparo);
            pnlFiltros.Controls.Add(btnPendente);
            pnlFiltros.Controls.Add(btnTodos);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblBuscarIcone);
            pnlFiltros.Location = new Point(30, 102);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1120, 105);
            pnlFiltros.TabIndex = 3;
            // 
            // btnCancelado
            // 
            btnCancelado.BackColor = Color.FromArgb(249, 244, 240);
            btnCancelado.Cursor = Cursors.Hand;
            btnCancelado.FlatAppearance.BorderSize = 0;
            btnCancelado.FlatStyle = FlatStyle.Flat;
            btnCancelado.Font = new Font("Segoe UI", 9F);
            btnCancelado.ForeColor = Color.FromArgb(130, 91, 75);
            btnCancelado.Location = new Point(608, 58);
            btnCancelado.Name = "btnCancelado";
            btnCancelado.Size = new Size(120, 32);
            btnCancelado.TabIndex = 7;
            btnCancelado.Text = "Cancelado  0";
            btnCancelado.UseVisualStyleBackColor = false;
            // 
            // btnEntregue
            // 
            btnEntregue.BackColor = Color.FromArgb(249, 244, 240);
            btnEntregue.Cursor = Cursors.Hand;
            btnEntregue.FlatAppearance.BorderSize = 0;
            btnEntregue.FlatStyle = FlatStyle.Flat;
            btnEntregue.Font = new Font("Segoe UI", 9F);
            btnEntregue.ForeColor = Color.FromArgb(130, 91, 75);
            btnEntregue.Location = new Point(488, 58);
            btnEntregue.Name = "btnEntregue";
            btnEntregue.Size = new Size(115, 32);
            btnEntregue.TabIndex = 6;
            btnEntregue.Text = "Entregue  0";
            btnEntregue.UseVisualStyleBackColor = false;
            // 
            // btnPronto
            // 
            btnPronto.BackColor = Color.FromArgb(249, 244, 240);
            btnPronto.Cursor = Cursors.Hand;
            btnPronto.FlatAppearance.BorderSize = 0;
            btnPronto.FlatStyle = FlatStyle.Flat;
            btnPronto.Font = new Font("Segoe UI", 9F);
            btnPronto.ForeColor = Color.FromArgb(130, 91, 75);
            btnPronto.Location = new Point(378, 58);
            btnPronto.Name = "btnPronto";
            btnPronto.Size = new Size(105, 32);
            btnPronto.TabIndex = 5;
            btnPronto.Text = "Pronto  0";
            btnPronto.UseVisualStyleBackColor = false;
            // 
            // btnPreparo
            // 
            btnPreparo.BackColor = Color.FromArgb(249, 244, 240);
            btnPreparo.Cursor = Cursors.Hand;
            btnPreparo.FlatAppearance.BorderSize = 0;
            btnPreparo.FlatStyle = FlatStyle.Flat;
            btnPreparo.Font = new Font("Segoe UI", 9F);
            btnPreparo.ForeColor = Color.FromArgb(130, 91, 75);
            btnPreparo.Location = new Point(248, 58);
            btnPreparo.Name = "btnPreparo";
            btnPreparo.Size = new Size(125, 32);
            btnPreparo.TabIndex = 4;
            btnPreparo.Text = "Em preparo  0";
            btnPreparo.UseVisualStyleBackColor = false;
            // 
            // btnPendente
            // 
            btnPendente.BackColor = Color.FromArgb(249, 244, 240);
            btnPendente.Cursor = Cursors.Hand;
            btnPendente.FlatAppearance.BorderSize = 0;
            btnPendente.FlatStyle = FlatStyle.Flat;
            btnPendente.Font = new Font("Segoe UI", 9F);
            btnPendente.ForeColor = Color.FromArgb(130, 91, 75);
            btnPendente.Location = new Point(128, 58);
            btnPendente.Name = "btnPendente";
            btnPendente.Size = new Size(115, 32);
            btnPendente.TabIndex = 3;
            btnPendente.Text = "Pendente  0";
            btnPendente.UseVisualStyleBackColor = false;
            // 
            // btnTodos
            // 
            btnTodos.BackColor = Color.FromArgb(211, 119, 82);
            btnTodos.Cursor = Cursors.Hand;
            btnTodos.FlatAppearance.BorderSize = 0;
            btnTodos.FlatStyle = FlatStyle.Flat;
            btnTodos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTodos.ForeColor = Color.White;
            btnTodos.Location = new Point(18, 58);
            btnTodos.Name = "btnTodos";
            btnTodos.Size = new Size(105, 32);
            btnTodos.TabIndex = 2;
            btnTodos.Text = "Todos  0";
            btnTodos.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.ForeColor = Color.FromArgb(110, 90, 80);
            txtBuscar.Location = new Point(46, 13);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(430, 25);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscarIcone
            // 
            lblBuscarIcone.AutoSize = true;
            lblBuscarIcone.Font = new Font("Segoe UI Symbol", 12F);
            lblBuscarIcone.ForeColor = Color.FromArgb(150, 130, 120);
            lblBuscarIcone.Location = new Point(18, 17);
            lblBuscarIcone.Name = "lblBuscarIcone";
            lblBuscarIcone.Size = new Size(22, 21);
            lblBuscarIcone.TabIndex = 0;
            lblBuscarIcone.Text = "⌕";
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovo.BackColor = Color.FromArgb(211, 119, 82);
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(1045, 58);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(105, 38);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "+  Novo";
            btnNovo.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(55, 39, 34);
            lblTitulo.Location = new Point(34, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(146, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Pedidos";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(145, 117, 105);
            lblSubtitulo.Location = new Point(38, 68);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(128, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Pedidos registrados";
            // 
            // PedidosUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 244, 241);
            Controls.Add(pnlPrincipal);
            Name = "PedidosUserControl";
            Size = new Size(1180, 700);
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTotalPedidos;

        private System.Windows.Forms.Button btnNovo;

        private System.Windows.Forms.Panel pnlFiltros;

        private System.Windows.Forms.Label lblBuscarIcone;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnPendente;
        private System.Windows.Forms.Button btnPreparo;
        private System.Windows.Forms.Button btnPronto;
        private System.Windows.Forms.Button btnEntregue;
        private System.Windows.Forms.Button btnCancelado;

        private System.Windows.Forms.DataGridView dgvPedidos;

        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcoes;
    }
}