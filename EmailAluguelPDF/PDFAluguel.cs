﻿using Dominio.AluguelModule;
using EmailAluguelPDF.Properties;
using ExtensionsModule;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Drawing.Imaging;
using System.IO;

namespace EmailAluguelPDF
{
    public class PDFAluguel
    {
        public static void CriaEnvioEmail(Aluguel aluguel)
        {
            var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            writer.SetCloseStream(false);
            var pdfDocument = new PdfDocument(writer);
            var pdf = new Document(pdfDocument);

            #region Estilos
            PdfFont fontCorpo = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont fontHeader = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Style helvetica32b = new();
            helvetica32b.SetFont(fontHeader).SetFontSize(32);

            Style helvetica20b = new();
            helvetica20b.SetFont(fontHeader).SetFontSize(20);

            Style helvetica14r = new();
            helvetica14r.SetFont(fontCorpo).SetFontSize(14);

            Style helvetica14b = new();
            helvetica14b.SetFont(fontHeader).SetFontSize(14);

            Style helvetica24b = new();
            helvetica24b.SetFont(fontHeader).SetFontSize(24);

            SolidLine linha = new SolidLine(1f);
            LineSeparator linhaHorizontal = new LineSeparator(linha);

            #endregion

            #region Parágrafos
            Paragraph header = new Paragraph().SetTextAlignment(TextAlignment.CENTER).AddStyle(helvetica24b);
            header.Add(ImagemItextImage(Resources.logopdf));
            header.Add(new Text($"\nOlá, {aluguel.Cliente}."));
            header.Add(new Text($"\nAqui está o resumo do seu mais novo aluguel na Rech-a-car!"));

            Paragraph body_imagem = new Paragraph().SetTextAlignment(TextAlignment.CENTER).AddStyle(helvetica14r);
            body_imagem.Add(ImagemItextImage(aluguel.Veiculo.Foto));

            Paragraph body_aluguel = new Paragraph().SetTextAlignment(TextAlignment.CENTER).AddStyle(helvetica14r);
            body_aluguel.Add(new Text($"\nVeículo: {aluguel.Veiculo}"));
            body_aluguel.Add(new Text($"\nData de Aluguel: {aluguel.DataAluguel:d}"));
            body_aluguel.Add(new Text($"\nData de Devolução: {aluguel.DataDevolucao:d}"));
            if (aluguel.Cupom != null)
            {
                body_aluguel.Add(new Text($"\nCupom aplicado: {aluguel.Cupom.Nome}"));
            }

            Paragraph body_servicos = new Paragraph().SetTextAlignment(TextAlignment.CENTER).AddStyle(helvetica14r);
            if (aluguel.Servicos.Count > 0)
            {
                body_servicos.Add(new Text($"Serviços alugados:"));
                aluguel.Servicos.ForEach(s => body_servicos.Add(new Text($"\n{s}")));
            }

            Paragraph total = new Paragraph($"\nTotal Parcial: R${aluguel.CalcularTotal()}").SetTextAlignment(TextAlignment.CENTER).AddStyle(helvetica14b);
            #endregion
                
            pdf.Add(header);
            pdf.Add(body_imagem);
            pdf.Add(body_aluguel);
            pdf.Add(linhaHorizontal);
            pdf.Add(body_servicos);
            pdf.Add(total);

            pdf.Close();

            ControladorEmail.InserirParaEnvio(aluguel, ms);
        }

        private static Image ImagemItextImage(System.Drawing.Image imagem)
        {
            var byteArray = imagem.ToByteArray(ImageFormat.Bmp);

            ImageData imageData = ImageDataFactory.Create(byteArray);
            return new Image(imageData);
        }
    }
}
