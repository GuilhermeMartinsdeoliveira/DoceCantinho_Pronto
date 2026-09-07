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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblTotalPedidos = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();

            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcoes = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnCancelado = new System.Windows.Forms.Button();
            this.btnEntregue = new System.Windows.Forms.Button();
            this.btnPronto = new System.Windows.Forms.Button();
            this.btnPreparo = new System.Windows.Forms.Button();
            this.btnPendente = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();

            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscarIcone = new System.Windows.Forms.Label();

            this.btnNovo = new System.Windows.Forms.Button();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(247, 244, 241);
            this.pnlPrincipal.Controls.Add(this.lblTotalPedidos);
            this.pnlPrincipal.Controls.Add(this.dgvPedidos);
            this.pnlPrincipal.Controls.Add(this.pnlFiltros);
            this.pnlPrincipal.Controls.Add(this.btnNovo);
            this.pnlPrincipal.Controls.Add(this.lblTitulo);
            this.pnlPrincipal.Controls.Add(this.lblSubtitulo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1180, 700);
            this.pnlPrincipal.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI",
                25F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(55, 39, 34);

            this.lblTitulo.Location =
                new System.Drawing.Point(34, 24);

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size =
                new System.Drawing.Size(130, 46);

            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Pedidos";

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.FromArgb(145, 117, 105);

            this.lblSubtitulo.Location =
                new System.Drawing.Point(38, 68);

            this.lblSubtitulo.Name =
                "lblSubtitulo";

            this.lblSubtitulo.Size =
                new System.Drawing.Size(130, 19);

            this.lblSubtitulo.TabIndex = 1;

            this.lblSubtitulo.Text =
                "Pedidos registrados";

            // 
            // btnNovo
            // 
            this.btnNovo.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top |
                  System.Windows.Forms.AnchorStyles.Right)));

            this.btnNovo.BackColor =
                System.Drawing.Color.FromArgb(211, 119, 82);

            this.btnNovo.FlatAppearance.BorderSize = 0;

            this.btnNovo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnNovo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btnNovo.ForeColor =
                System.Drawing.Color.White;

            this.btnNovo.Location =
                new System.Drawing.Point(1060, 24);

            this.btnNovo.Name =
                "btnNovo";

            this.btnNovo.Size =
                new System.Drawing.Size(105, 38);

            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "+  Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top |
                   System.Windows.Forms.AnchorStyles.Left) |
                   System.Windows.Forms.AnchorStyles.Right)));

            this.pnlFiltros.BackColor =
                System.Drawing.Color.White;

            this.pnlFiltros.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlFiltros.Controls.Add(this.btnCancelado);
            this.pnlFiltros.Controls.Add(this.btnEntregue);
            this.pnlFiltros.Controls.Add(this.btnPronto);
            this.pnlFiltros.Controls.Add(this.btnPreparo);
            this.pnlFiltros.Controls.Add(this.btnPendente);
            this.pnlFiltros.Controls.Add(this.btnTodos);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.lblBuscarIcone);

            this.pnlFiltros.Location =
                new System.Drawing.Point(30, 102);

            this.pnlFiltros.Name =
                "pnlFiltros";

            this.pnlFiltros.Size =
                new System.Drawing.Size(1120, 105);

            this.pnlFiltros.TabIndex = 3;

            // 
            // lblBuscarIcone
            // 
            this.lblBuscarIcone.AutoSize = true;

            this.lblBuscarIcone.Font =
                new System.Drawing.Font(
                    "Segoe UI Symbol",
                    12F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.lblBuscarIcone.ForeColor =
                System.Drawing.Color.FromArgb(150, 130, 120);

            this.lblBuscarIcone.Location =
                new System.Drawing.Point(18, 17);

            this.lblBuscarIcone.Name =
                "lblBuscarIcone";

            this.lblBuscarIcone.Size =
                new System.Drawing.Size(25, 21);

            this.lblBuscarIcone.TabIndex = 0;
            this.lblBuscarIcone.Text = "⌕";

            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.txtBuscar.ForeColor =
                System.Drawing.Color.FromArgb(110, 90, 80);

            this.txtBuscar.Location =
                new System.Drawing.Point(46, 13);

            this.txtBuscar.Name =
                "txtBuscar";

            this.txtBuscar.Size =
                new System.Drawing.Size(430, 30);

            this.txtBuscar.TabIndex = 1;

            // 
            // btnTodos
            // 
            this.btnTodos.BackColor =
                System.Drawing.Color.FromArgb(211, 119, 82);

            this.btnTodos.FlatAppearance.BorderSize = 0;

            this.btnTodos.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnTodos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point);

            this.btnTodos.ForeColor =
                System.Drawing.Color.White;

            this.btnTodos.Location =
                new System.Drawing.Point(18, 58);

            this.btnTodos.Name =
                "btnTodos";

            this.btnTodos.Size =
                new System.Drawing.Size(105, 32);

            this.btnTodos.TabIndex = 2;
            this.btnTodos.Text = "Todos  0";
            this.btnTodos.UseVisualStyleBackColor = false;
            this.btnTodos.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // btnPendente
            // 
            this.btnPendente.BackColor =
                System.Drawing.Color.FromArgb(249, 244, 240);

            this.btnPendente.FlatAppearance.BorderSize = 0;

            this.btnPendente.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnPendente.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.btnPendente.ForeColor =
                System.Drawing.Color.FromArgb(130, 91, 75);

            this.btnPendente.Location =
                new System.Drawing.Point(128, 58);

            this.btnPendente.Name =
                "btnPendente";

            this.btnPendente.Size =
                new System.Drawing.Size(115, 32);

            this.btnPendente.TabIndex = 3;
            this.btnPendente.Text = "Pendente  0";
            this.btnPendente.UseVisualStyleBackColor = false;
            this.btnPendente.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // btnPreparo
            // 
            this.btnPreparo.BackColor =
                System.Drawing.Color.FromArgb(249, 244, 240);

            this.btnPreparo.FlatAppearance.BorderSize = 0;

            this.btnPreparo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnPreparo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.btnPreparo.ForeColor =
                System.Drawing.Color.FromArgb(130, 91, 75);

            this.btnPreparo.Location =
                new System.Drawing.Point(248, 58);

            this.btnPreparo.Name =
                "btnPreparo";

            this.btnPreparo.Size =
                new System.Drawing.Size(125, 32);

            this.btnPreparo.TabIndex = 4;
            this.btnPreparo.Text = "Em preparo  0";
            this.btnPreparo.UseVisualStyleBackColor = false;
            this.btnPreparo.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // btnPronto
            // 
            this.btnPronto.BackColor =
                System.Drawing.Color.FromArgb(249, 244, 240);

            this.btnPronto.FlatAppearance.BorderSize = 0;

            this.btnPronto.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnPronto.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.btnPronto.ForeColor =
                System.Drawing.Color.FromArgb(130, 91, 75);

            this.btnPronto.Location =
                new System.Drawing.Point(378, 58);

            this.btnPronto.Name =
                "btnPronto";

            this.btnPronto.Size =
                new System.Drawing.Size(105, 32);

            this.btnPronto.TabIndex = 5;
            this.btnPronto.Text = "Pronto  0";
            this.btnPronto.UseVisualStyleBackColor = false;
            this.btnPronto.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // btnEntregue
            // 
            this.btnEntregue.BackColor =
                System.Drawing.Color.FromArgb(249, 244, 240);

            this.btnEntregue.FlatAppearance.BorderSize = 0;

            this.btnEntregue.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEntregue.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.btnEntregue.ForeColor =
                System.Drawing.Color.FromArgb(130, 91, 75);

            this.btnEntregue.Location =
                new System.Drawing.Point(488, 58);

            this.btnEntregue.Name =
                "btnEntregue";

            this.btnEntregue.Size =
                new System.Drawing.Size(115, 32);

            this.btnEntregue.TabIndex = 6;
            this.btnEntregue.Text = "Entregue  0";
            this.btnEntregue.UseVisualStyleBackColor = false;
            this.btnEntregue.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // btnCancelado
            // 
            this.btnCancelado.BackColor =
                System.Drawing.Color.FromArgb(249, 244, 240);

            this.btnCancelado.FlatAppearance.BorderSize = 0;

            this.btnCancelado.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCancelado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.btnCancelado.ForeColor =
                System.Drawing.Color.FromArgb(130, 91, 75);

            this.btnCancelado.Location =
                new System.Drawing.Point(608, 58);

            this.btnCancelado.Name =
                "btnCancelado";

            this.btnCancelado.Size =
                new System.Drawing.Size(120, 32);

            this.btnCancelado.TabIndex = 7;
            this.btnCancelado.Text = "Cancelado  0";
            this.btnCancelado.UseVisualStyleBackColor = false;
            this.btnCancelado.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToResizeRows = false;

            this.dgvPedidos.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top |
                    System.Windows.Forms.AnchorStyles.Bottom) |
                    System.Windows.Forms.AnchorStyles.Left) |
                    System.Windows.Forms.AnchorStyles.Right)));

            this.dgvPedidos.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvPedidos.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvPedidos.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvPedidos.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvPedidos.ColumnHeadersDefaultCellStyle =
                new System.Windows.Forms.DataGridViewCellStyle
                {
                    Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        System.Drawing.Color.FromArgb(249, 247, 245),

                    Font =
                        new System.Drawing.Font(
                            "Segoe UI",
                            9F,
                            System.Drawing.FontStyle.Bold,
                            System.Drawing.GraphicsUnit.Point),

                    ForeColor =
                        System.Drawing.Color.FromArgb(115, 85, 72),

                    SelectionBackColor =
                        System.Drawing.Color.FromArgb(249, 247, 245),

                    SelectionForeColor =
                        System.Drawing.Color.FromArgb(115, 85, 72),

                    WrapMode =
                        System.Windows.Forms.DataGridViewTriState.False
                };

            this.dgvPedidos.ColumnHeadersHeight = 38;
            this.dgvPedidos.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvPedidos.EnableHeadersVisualStyles = false;

            this.dgvPedidos.DefaultCellStyle =
                new System.Windows.Forms.DataGridViewCellStyle
                {
                    Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,

                    BackColor =
                        System.Drawing.Color.White,

                    Font =
                        new System.Drawing.Font(
                            "Segoe UI",
                            9.5F,
                            System.Drawing.FontStyle.Regular,
                            System.Drawing.GraphicsUnit.Point),

                    ForeColor =
                        System.Drawing.Color.FromArgb(65, 55, 50),

                    SelectionBackColor =
                        System.Drawing.Color.FromArgb(250, 239, 233),

                    SelectionForeColor =
                        System.Drawing.Color.FromArgb(65, 55, 50),

                    WrapMode =
                        System.Windows.Forms.DataGridViewTriState.False
                };

            this.dgvPedidos.GridColor =
                System.Drawing.Color.FromArgb(238, 231, 227);

            this.dgvPedidos.Location =
                new System.Drawing.Point(30, 245);

            this.dgvPedidos.MultiSelect = false;

            this.dgvPedidos.Name =
                "dgvPedidos";

            this.dgvPedidos.ReadOnly = true;

            this.dgvPedidos.RowHeadersVisible = false;

            this.dgvPedidos.RowTemplate.Height = 42;

            this.dgvPedidos.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvPedidos.Size =
                new System.Drawing.Size(1120, 365);

            this.dgvPedidos.TabIndex = 4;

            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "Id";
            this.colNumero.HeaderText = "Nº PEDIDO";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 105;

            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "NomeCliente";
            this.colCliente.HeaderText = "CLIENTE";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Width = 150;

            // 
            // colData
            // 
            this.colData.DataPropertyName = "CreatedAt";
            this.colData.HeaderText = "DATA";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 125;

            // 
            // colProdutos
            // 
            this.colProdutos.DataPropertyName = "Produtos";
            this.colProdutos.HeaderText = "PRODUTOS";
            this.colProdutos.Name = "colProdutos";
            this.colProdutos.ReadOnly = true;
            this.colProdutos.Width = 180;

            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "Total";
            this.colValor.HeaderText = "VALOR";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 110;

            // 
            // colPagamento
            // 
            this.colPagamento.DataPropertyName = "PaymentMethod";
            this.colPagamento.HeaderText = "PAGAMENTO";
            this.colPagamento.Name = "colPagamento";
            this.colPagamento.ReadOnly = true;
            this.colPagamento.Width = 120;

            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 110;

            // 
            // colAcoes
            // 
            this.colAcoes.DataPropertyName = "";
            this.colAcoes.HeaderText = "AÇÕES";
            this.colAcoes.Name = "colAcoes";
            this.colAcoes.ReadOnly = true;
            this.colAcoes.AutoSizeMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAcoes.Width = 170;

            // 
            // dgvPedidos - Columns
            // 
            this.dgvPedidos.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colNumero,
                    this.colCliente,
                    this.colData,
                    this.colProdutos,
                    this.colValor,
                    this.colPagamento,
                    this.colStatus,
                    this.colAcoes
                });

            // 
            // lblTotalPedidos
            // 
            this.lblTotalPedidos.AutoSize = true;

            this.lblTotalPedidos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point);

            this.lblTotalPedidos.ForeColor =
                System.Drawing.Color.FromArgb(145, 117, 105);

            this.lblTotalPedidos.Location =
                new System.Drawing.Point(32, 625);

            this.lblTotalPedidos.Name =
                "lblTotalPedidos";

            this.lblTotalPedidos.Size =
                new System.Drawing.Size(98, 15);

            this.lblTotalPedidos.TabIndex = 5;

            this.lblTotalPedidos.Text =
                "Total de pedidos:";

            // 
            // PedidosUserControl
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(247, 244, 241);

            this.Controls.Add(this.pnlPrincipal);

            this.Name =
                "PedidosUserControl";

            this.Size =
                new System.Drawing.Size(1180, 700);

            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvPedidos)).EndInit();

            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();

            this.ResumeLayout(false);
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