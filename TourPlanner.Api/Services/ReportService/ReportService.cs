﻿using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Extensions.Logging;
using TourPlanner.Models;

namespace TourPlanner.Api.Services.ReportService
{
    public class ReportService : IReportService
    {
        // const string TARGET_PDF = "../../../target.pdf";
        const string TARGET_PDF = "./Pdfs/";

        ILogger<ReportService> _logger;

        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        public ReportService() { }

        public void GeneratePdfReport(Tour tour)
        {
            PdfWriter writer = new PdfWriter(TARGET_PDF + $"{ tour.Id }.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph ReportHeader = new Paragraph("Report:")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                    .SetFontSize(14)
                    .SetBold()
                    .SetFontColor(ColorConstants.BLACK);
            document.Add(ReportHeader);
            document.Add(new Paragraph("Tour Summary:"));
            document.Add(new Paragraph(tour.Summary));
            document.Close();

            _logger.LogInformation($"Logging works :)");
            //throw new NotImplementedException();
        }
    }
}
