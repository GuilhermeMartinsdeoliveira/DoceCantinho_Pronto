using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace DoceCantinho.Desktop.Themes
{
    public static class DoceTheme
    {
        // ============================================================
        // CORES PRINCIPAIS
        // ============================================================

        // Fundo geral das telas
        public static readonly Color Fundo =
            Color.FromArgb(248, 245, 242);

        // Branco dos cards
        public static readonly Color Branco =
            Color.FromArgb(255, 255, 255);

        public static readonly Color Card =
            Color.FromArgb(255, 255, 255);

        // Sidebar
        public static readonly Color Sidebar =
            Color.FromArgb(48, 31, 27);

        public static readonly Color SidebarHover =
            Color.FromArgb(68, 45, 39);

        // Cor principal — terracota
        public static readonly Color Primaria =
            Color.FromArgb(207, 132, 106);

        public static readonly Color PrimariaHover =
            Color.FromArgb(193, 111, 87);

        public static readonly Color PrimariaClara =
            Color.FromArgb(250, 237, 231);

        // Textos
        public static readonly Color Texto =
            Color.FromArgb(45, 30, 26);

        public static readonly Color TextoSecundario =
            Color.FromArgb(125, 102, 93);

        public static readonly Color TextoFraco =
            Color.FromArgb(158, 139, 130);

        // Bordas
        public static readonly Color Borda =
            Color.FromArgb(235, 227, 222);

        public static readonly Color BordaEscura =
            Color.FromArgb(224, 214, 208);

        // Campos
        public static readonly Color FundoInput =
            Color.FromArgb(250, 247, 244);

        // ============================================================
        // CORES DE STATUS
        // ============================================================

        public static readonly Color Verde =
            Color.FromArgb(72, 174, 123);

        public static readonly Color VerdeClaro =
            Color.FromArgb(232, 247, 238);

        public static readonly Color Amarelo =
            Color.FromArgb(224, 166, 65);

        public static readonly Color AmareloClaro =
            Color.FromArgb(252, 244, 224);

        public static readonly Color Azul =
            Color.FromArgb(78, 153, 214);

        public static readonly Color AzulClaro =
            Color.FromArgb(231, 242, 252);

        public static readonly Color Roxo =
            Color.FromArgb(137, 112, 205);

        public static readonly Color RoxoClaro =
            Color.FromArgb(240, 235, 252);

        public static readonly Color Vermelho =
            Color.FromArgb(221, 91, 91);

        public static readonly Color VermelhoClaro =
            Color.FromArgb(253, 233, 233);

        // ============================================================
        // CORES DAS CATEGORIAS
        // ============================================================

        public static readonly Color CategoriaBolos =
            Color.FromArgb(207, 132, 106);

        public static readonly Color CategoriaBrigadeiros =
            Color.FromArgb(224, 166, 65);

        public static readonly Color CategoriaBrownies =
            Color.FromArgb(139, 121, 112);

        public static readonly Color CategoriaCupcakes =
            Color.FromArgb(235, 158, 145);

        public static readonly Color CategoriaGourmet =
            Color.FromArgb(65, 180, 125);

        // ============================================================
        // FONTES
        // ============================================================

        // Fonte principal.
        // Segoe UI é usada porque já vem instalada no Windows.
        public static string FonteBase => "Segoe UI";

        // Texto pequeno
        public static Font Fonte8 =>
            new Font(FonteBase, 8f, FontStyle.Regular);

        // Texto padrão
        public static Font Fonte9 =>
            new Font(FonteBase, 9f, FontStyle.Regular);

        // Texto padrão em negrito
        public static Font Fonte9Bold =>
            new Font(FonteBase, 9f, FontStyle.Bold);

        // Texto médio
        public static Font Fonte10 =>
            new Font(FonteBase, 10f, FontStyle.Regular);

        // Texto médio em negrito
        public static Font Fonte10Bold =>
            new Font(FonteBase, 10f, FontStyle.Bold);

        // Títulos das páginas
        //
        // A referência usa um estilo serifado nos títulos.
        // Georgia existe no Windows.
        public static Font FonteTitulo =>
            new Font("Georgia", 19f, FontStyle.Bold);

        public static Font FonteTituloGrande =>
            new Font("Georgia", 21f, FontStyle.Bold);

        // Números dos cards
        public static Font FonteNumero =>
            new Font("Georgia", 17f, FontStyle.Bold);

        // ============================================================
        // MEDIDAS
        // ============================================================

        public const int SidebarWidth = 190;

        public const int PagePadding = 22;

        public const int CardRadius = 12;

        public const int ButtonRadius = 8;

        // ============================================================
        // BOTÕES
        // ============================================================

        public static void AplicarBotaoPrimario(Guna2Button botao)
        {
            if (botao == null)
                return;

            botao.BorderRadius = ButtonRadius;

            botao.FillColor = Primaria;

            botao.ForeColor = Color.White;

            botao.Font = Fonte9Bold;

            botao.BorderThickness = 0;

            botao.Cursor = Cursors.Hand;

            botao.HoverState.FillColor = PrimariaHover;

            botao.HoverState.ForeColor = Color.White;

            botao.PressedColor = PrimariaHover;

            botao.DisabledState.FillColor =
                Color.FromArgb(220, 205, 198);

            botao.DisabledState.ForeColor =
                Color.White;
        }

        public static void AplicarBotaoSecundario(Guna2Button botao)
        {
            if (botao == null)
                return;

            botao.BorderRadius = ButtonRadius;

            botao.FillColor = FundoInput;

            botao.ForeColor = TextoSecundario;

            botao.Font = Fonte9Bold;

            botao.BorderThickness = 0;

            botao.Cursor = Cursors.Hand;

            botao.HoverState.FillColor = PrimariaClara;

            botao.HoverState.ForeColor = Texto;

            botao.PressedColor = BordaEscura;
        }

        // ============================================================
        // LABEL DE TÍTULO
        // ============================================================

        public static void AplicarTitulo(Label label)
        {
            if (label == null)
                return;

            label.AutoSize = true;

            label.Font = FonteTitulo;

            label.ForeColor = Texto;

            label.BackColor = Color.Transparent;
        }

        // ============================================================
        // SUBTÍTULO
        // ============================================================

        public static void AplicarSubtitulo(Label label)
        {
            if (label == null)
                return;

            label.AutoSize = true;

            label.Font = Fonte9;

            label.ForeColor = TextoSecundario;

            label.BackColor = Color.Transparent;
        }

        // ============================================================
        // LABEL PADRÃO
        // ============================================================

        public static void AplicarTexto(Label label)
        {
            if (label == null)
                return;

            label.Font = Fonte9;

            label.ForeColor = Texto;

            label.BackColor = Color.Transparent;
        }

        // ============================================================
        // LABEL PEQUENO
        // ============================================================

        public static void AplicarTextoPequeno(Label label)
        {
            if (label == null)
                return;

            label.Font = Fonte8;

            label.ForeColor = TextoSecundario;

            label.BackColor = Color.Transparent;
        }

        // ============================================================
        // CARD
        // ============================================================

        public static void AplicarCard(Control controle)
        {
            if (controle == null)
                return;

            controle.BackColor = Branco;
        }

        // ============================================================
        // TEXTBOX
        // ============================================================

        public static void AplicarTextBox(TextBox textBox)
        {
            if (textBox == null)
                return;

            textBox.BackColor = FundoInput;

            textBox.ForeColor = Texto;

            textBox.Font = Fonte9;

            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        // ============================================================
        // COMBOBOX
        // ============================================================

        public static void AplicarComboBox(ComboBox comboBox)
        {
            if (comboBox == null)
                return;

            comboBox.BackColor = FundoInput;

            comboBox.ForeColor = Texto;

            comboBox.Font = Fonte9;

            comboBox.FlatStyle = FlatStyle.Flat;
        }

        // ============================================================
        // DATAGRIDVIEW
        // ============================================================

        public static void AplicarEstiloGrid(DataGridView grid)
        {
            if (grid == null)
                return;

            // ----------------------------
            // Fundo
            // ----------------------------

            grid.BackgroundColor = Fundo;

            grid.BorderStyle = BorderStyle.None;

            grid.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            grid.GridColor = Borda;

            // ----------------------------
            // Cabeçalho
            // ----------------------------

            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Branco;

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                TextoSecundario;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    FonteBase,
                    8f,
                    FontStyle.Bold
                );

            grid.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            grid.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(8, 0, 8, 0);

            grid.ColumnHeadersHeight = 38;

            // ----------------------------
            // Células
            // ----------------------------

            grid.DefaultCellStyle.BackColor =
                Branco;

            grid.DefaultCellStyle.ForeColor =
                Texto;

            grid.DefaultCellStyle.Font =
                Fonte9;

            grid.DefaultCellStyle.SelectionBackColor =
                PrimariaClara;

            grid.DefaultCellStyle.SelectionForeColor =
                Texto;

            grid.DefaultCellStyle.Padding =
                new Padding(8, 3, 8, 3);

            grid.DefaultCellStyle.NullValue = "—";

            // ----------------------------
            // Linhas alternadas
            // ----------------------------

            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(253, 251, 249);

            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                PrimariaClara;

            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                Texto;

            // ----------------------------
            // Configuração
            // ----------------------------

            grid.RowHeadersVisible = false;

            grid.RowTemplate.Height = 42;

            grid.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            grid.MultiSelect = false;

            grid.ReadOnly = true;

            grid.AllowUserToAddRows = false;

            grid.AllowUserToDeleteRows = false;

            grid.AllowUserToResizeRows = false;

            grid.AllowUserToResizeColumns = false;

            grid.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Evita que o usuário veja o cursor azul padrão
            // quando a tabela recebe foco.
            grid.ClearSelection();

            // ----------------------------
            // Guna DataGridView
            // ----------------------------

            if (grid is Guna2DataGridView guna)
            {
                guna.ThemeStyle.RowsStyle.BackColor =
                    Branco;

                guna.ThemeStyle.RowsStyle.ForeColor =
                    Texto;

                guna.ThemeStyle.RowsStyle.SelectionBackColor =
                    PrimariaClara;

                guna.ThemeStyle.RowsStyle.SelectionForeColor =
                    Texto;

                guna.ThemeStyle.AlternatingRowsStyle.BackColor =
                    Color.FromArgb(253, 251, 249);

                guna.ThemeStyle.AlternatingRowsStyle.SelectionBackColor =
                    PrimariaClara;

                guna.ThemeStyle.AlternatingRowsStyle.SelectionForeColor =
                    Texto;

                guna.ThemeStyle.HeaderStyle.BackColor =
                    Branco;

                guna.ThemeStyle.HeaderStyle.ForeColor =
                    TextoSecundario;

                guna.ThemeStyle.HeaderStyle.Font =
                    new Font(
                        FonteBase,
                        8f,
                        FontStyle.Bold
                    );
            }
        }

        // ============================================================
        // COR DA CATEGORIA
        // ============================================================

        public static Color ObterCorCategoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return Primaria;

            string categoria =
                nome.Trim().ToLowerInvariant();

            if (categoria.Contains("brigadeiro"))
                return CategoriaBrigadeiros;

            if (categoria.Contains("brownie"))
                return CategoriaBrownies;

            if (categoria.Contains("cupcake"))
                return CategoriaCupcakes;

            if (categoria.Contains("gourmet"))
                return CategoriaGourmet;

            if (categoria.Contains("bolo"))
                return CategoriaBolos;

            return Primaria;
        }

        // ============================================================
        // COR CLARA DA CATEGORIA
        // ============================================================

        public static Color ObterCorClaraCategoria(string nome)
        {
            Color cor = ObterCorCategoria(nome);

            return ControlPaint.LightLight(cor);
        }

        // ============================================================
        // ARREDONDAR CONTROLE
        // ============================================================

        public static void Arredondar(Control controle, int raio)
        {
            if (controle == null)
                return;

            Rectangle area =
                new Rectangle(
                    0,
                    0,
                    controle.Width,
                    controle.Height
                );

            using GraphicsPath path =
                CriarPathArredondado(area, raio);

            controle.Region =
                new Region(path);
        }

        // ============================================================
        // PATH ARREDONDADO
        // ============================================================

        private static GraphicsPath CriarPathArredondado(
            Rectangle area,
            int raio)
        {
            GraphicsPath path = new GraphicsPath();

            int diametro = raio * 2;

            if (diametro > area.Width)
                diametro = area.Width;

            if (diametro > area.Height)
                diametro = area.Height;

            Rectangle arco =
                new Rectangle(
                    area.X,
                    area.Y,
                    diametro,
                    diametro
                );

            path.AddArc(
                arco,
                180,
                90
            );

            arco.X =
                area.Right - diametro;

            path.AddArc(
                arco,
                270,
                90
            );

            arco.Y =
                area.Bottom - diametro;

            path.AddArc(
                arco,
                0,
                90
            );

            arco.X =
                area.X;

            path.AddArc(
                arco,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }

        // ============================================================
        // APLICAR ESTILO GERAL
        // ============================================================

        public static void AplicarEstiloFormulario(Form form)
        {
            if (form == null)
                return;

            form.BackColor = Fundo;

            form.ForeColor = Texto;

            form.Font = Fonte9;

            form.StartPosition =
                FormStartPosition.CenterScreen;

            form.FormBorderStyle =
                FormBorderStyle.Sizable;

            form.AutoScaleMode =
                AutoScaleMode.Dpi;
        }

        // ============================================================
        // COMPATIBILIDADE
        // ============================================================

        public static Color AzulPrimario => Primaria;

        public static Color AzulVariante => Primaria;

        public static Color AzulClaroLegacy => PrimariaClara;

        public static Color LaranjaPrimario => Primaria;

        public static Color LaranjaVariante => PrimariaHover;

        public static Color LaranjaClaro => PrimariaClara;

        public static Color CinzaFundo => Fundo;

        public static Color CinzaClaro => Borda;

        public static Color CinzaMedio => TextoSecundario;

        public static Color GrafiteTexto => Texto;

        public static Color GrafiteEscuro => Texto;

        public static Color Sucesso => Verde;

        public static Color Perigo => Vermelho;

        public static Color Aviso => Amarelo;

        public static Color Info => Azul;

        public static Color SucessoClaro => VerdeClaro;

        public static Color PerigoClaro => VermelhoClaro;

        public static Color AvisoClaro => AmareloClaro;

        public static Color InfoClaro => AzulClaro;

        public static string FonteBaseString => FonteBase;

        public static Font Fonte9Semi =>
            new Font(FonteBase, 9f, FontStyle.Bold);

        public static Font Fonte10Semi =>
            new Font(FonteBase, 10f, FontStyle.Bold);

        public static int Raio => CardRadius;

        // Compatibilidade com código antigo.
        public static void EstilizarBotao(
            Guna2Button botao,
            bool primario = false)
        {
            if (primario)
                AplicarBotaoPrimario(botao);
            else
                AplicarBotaoSecundario(botao);
        }
    }
}