using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using DoceCantinho.Desktop.DTOs;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

// Aliases para eliminar conflitos de nomes
using PdfDocument = QuestPDF.Fluent.Document;
using PdfContainer = QuestPDF.Infrastructure.IContainer;

namespace DoceCantinho.Desktop.Services
{
    public static class PedidosPdfService
    {
        // ============================================================
        // GERAR PDF
        // ============================================================

        public static void Gerar(
            IEnumerable<PedidoResponseDto> pedidos,
            string caminho)
        {
            if (pedidos == null)
                throw new ArgumentNullException(
                    nameof(pedidos));

            if (string.IsNullOrWhiteSpace(caminho))
                throw new ArgumentException(
                    "O caminho do arquivo PDF não foi informado.",
                    nameof(caminho));

            List<PedidoResponseDto> lista =
                pedidos.ToList();

            QuestPDF.Settings.License =
                LicenseType.Community;

            PdfDocument
                .Create(document =>
                {
                    document.Page(page =>
                    {
                        // =================================================
                        // CONFIGURAÇÃO DA PÁGINA
                        // =================================================

                        page.Size(
                            PageSizes.A4.Landscape());

                        page.Margin(30);

                        page.PageColor(
                            Colors.White);

                        page.DefaultTextStyle(
                            style =>
                                style.FontSize(9));

                        // =================================================
                        // CABEÇALHO
                        // =================================================

                        page.Header()
                            .Column(column =>
                            {
                                column.Item()
                                    .Text(
                                        "DoceCantinho")
                                    .FontSize(23)
                                    .Bold()
                                    .FontColor(
                                        Colors.Brown.Darken2);

                                column.Item()
                                    .PaddingTop(3)
                                    .Text(
                                        "Relatório de Pedidos")
                                    .FontSize(15)
                                    .SemiBold()
                                    .FontColor(
                                        Colors.Brown.Darken2);

                                column.Item()
                                    .PaddingTop(3)
                                    .Text(
                                        $"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}")
                                    .FontSize(8)
                                    .FontColor(
                                        Colors.Grey.Darken1);
                            });

                        // =================================================
                        // CONTEÚDO
                        // =================================================

                        page.Content()
                            .PaddingTop(20)
                            .Column(column =>
                            {
                                // -----------------------------------------
                                // RESUMO
                                // -----------------------------------------

                                column.Item()
                                    .Text(
                                        $"Total de pedidos: {lista.Count}")
                                    .FontSize(10)
                                    .Bold();

                                decimal valorTotal =
                                    lista.Sum(
                                        pedido =>
                                            pedido.Total);

                                column.Item()
                                    .PaddingTop(4)
                                    .Text(
                                        $"Valor total: {valorTotal.ToString(
                                            "C2",
                                            CultureInfo.GetCultureInfo(
                                                "pt-BR"))}")
                                    .FontSize(10)
                                    .Bold();

                                // -----------------------------------------
                                // TABELA
                                // -----------------------------------------

                                column.Item()
                                    .PaddingTop(15)
                                    .Table(
                                        table =>
                                        {
                                            table.ColumnsDefinition(
                                                columns =>
                                                {
                                                    columns.ConstantColumn(
                                                        55);

                                                    columns.RelativeColumn(
                                                        2);

                                                    columns.ConstantColumn(
                                                        100);

                                                    columns.RelativeColumn(
                                                        1.8f);

                                                    columns.ConstantColumn(
                                                        85);

                                                    columns.RelativeColumn(
                                                        1.5f);

                                                    columns.RelativeColumn(
                                                        1.2f);
                                                });

                                            // ==============================
                                            // CABEÇALHO DA TABELA
                                            // ==============================

                                            table.Header(
                                                header =>
                                                {
                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "Nº PEDIDO");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "CLIENTE");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "DATA");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "PRODUTOS");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "VALOR");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "PAGAMENTO");

                                                    CriarCabecalho(
                                                        header.Cell(),
                                                        "STATUS");
                                                });

                                            // ==============================
                                            // PEDIDOS
                                            // ==============================

                                            foreach (
                                                PedidoResponseDto pedido
                                                in lista)
                                            {
                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.Id.ToString());

                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.NomeCliente);

                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.CreatedAt.ToString(
                                                        "dd/MM/yyyy HH:mm"));

                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.Produtos);

                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.Total.ToString(
                                                        "C2",
                                                        CultureInfo.GetCultureInfo(
                                                            "pt-BR")));

                                                CriarCelula(
                                                    table.Cell(),
                                                    string.IsNullOrWhiteSpace(
                                                        pedido.PaymentMethod)
                                                        ? "Não informado"
                                                        : pedido.PaymentMethod);

                                                CriarCelula(
                                                    table.Cell(),
                                                    pedido.Status);
                                            }
                                        });
                            });

                        // =================================================
                        // RODAPÉ
                        // =================================================

                        page.Footer()
                            .AlignCenter()
                            .Text(
                                text =>
                                {
                                    text.Span(
                                        "DoceCantinho • Página ");

                                    text.CurrentPageNumber();

                                    text.Span(
                                        " de ");

                                    text.TotalPages();
                                });
                    });
                })
                .GeneratePdf(
                    caminho);
        }

        // ============================================================
        // CABEÇALHO DA TABELA
        // ============================================================

        private static void CriarCabecalho(
            PdfContainer container,
            string texto)
        {
            container
                .Background(
                    Colors.Brown.Darken2)
                .Padding(6)
                .Text(
                    texto)
                .FontSize(8)
                .Bold()
                .FontColor(
                    Colors.White);
        }

        // ============================================================
        // CÉLULA DA TABELA
        // ============================================================

        private static void CriarCelula(
            PdfContainer container,
            string? texto)
        {
            container
                .BorderBottom(1)
                .BorderColor(
                    Colors.Grey.Lighten2)
                .Padding(5)
                .Text(
                    texto ??
                    string.Empty)
                .FontSize(8);
        }
    }
}