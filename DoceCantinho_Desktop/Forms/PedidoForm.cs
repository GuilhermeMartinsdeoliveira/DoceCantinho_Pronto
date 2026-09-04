using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoceCantinho.Desktop1.Forms
{
    public partial class PedidoForm : Form
    {
        private DoceCantinho.Desktop.DTOs.PedidoDetalheDto _pedido;

        public PedidoForm(DoceCantinho.Desktop.DTOs.PedidoDetalheDto pedido)
        {
            InitializeComponent();
            _pedido = pedido;
            
            this.Text = $"Detalhes do Pedido #{_pedido.Id}";
            this.Width = 500;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(253, 246, 237);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            var lblInfo = new Label
            {
                Text = $"Cliente: {_pedido.NomeCliente}\nTelefone: {_pedido.Telefone}\nStatus: {_pedido.Status}\nEndereço: {_pedido.Endereco}",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 24, 16)
            };
            
            var grid = new DataGridView
            {
                Location = new Point(20, 100),
                Width = 440,
                Height = 200,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Doce", Width = 200 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Qtd", Width = 60 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preço", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            
            grid.DataSource = _pedido.Items;
            
            var lblTotal = new Label
            {
                Text = $"Total Geral: {_pedido.Total:C2}",
                AutoSize = true,
                Location = new Point(300, 310),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(212, 112, 74)
            };
            
            this.Controls.Add(lblInfo);
            this.Controls.Add(grid);
            this.Controls.Add(lblTotal);
        }
    }
}
