using DoceCantinho.Desktop.Forms;

namespace DoceCantinho.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // ── Tratamento global de exceções ───────────────────────────────
            // Sem isso, uma exceção não tratada em um evento (Click, etc.)
            // pode encerrar a thread de UI silenciosamente, dando a impressão
            // de que "os botões pararam de funcionar".
            System.Windows.Forms.Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show(
                    $"Ocorreu um erro inesperado:\n\n{e.Exception.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                MessageBox.Show(
                    $"Ocorreu um erro crítico inesperado:\n\n{ex?.Message}",
                    "Erro Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            Application.Run(new LoginForm());
        }
    }
}