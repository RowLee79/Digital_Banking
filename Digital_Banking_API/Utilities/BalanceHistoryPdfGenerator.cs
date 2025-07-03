using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Digital_Banking_API.Models.Dto;

namespace Digital_Banking_API.Utilities
{
    public static class BalanceHistoryPdfGenerator
    {
            public static byte[] Generate(List<BalanceHistoryDto> history, string accountNumber)
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var font = new XFont("Verdana", 12);
                var boldFont = new XFont("Verdana", 12, XFontStyle.Bold);
                var culture = new CultureInfo("en-PH");

                double yPoint = 40;

                // Title
                gfx.DrawString($"Balance History for Account: {accountNumber}", boldFont, XBrushes.Black,
                    new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 30;

                // Table Headers
                gfx.DrawString("Date", boldFont, XBrushes.Black, new XRect(40, yPoint, 100, 20), XStringFormats.TopLeft);
                gfx.DrawString("Balance", boldFont, XBrushes.Black, new XRect(200, yPoint, 100, 20), XStringFormats.TopLeft);
                yPoint += 25;

                decimal totalBalance = 0;

                foreach (var record in history)
                {
                    gfx.DrawString(record.Timestamp.ToString("yyyy-MM-dd HH:mm"), font, XBrushes.Black,
                        new XRect(40, yPoint, 100, 20), XStringFormats.TopLeft);

                    gfx.DrawString(record.Balance.ToString("C2", culture), font, XBrushes.Black,
                        new XRect(200, yPoint, 100, 20), XStringFormats.TopLeft);

                    totalBalance += record.Balance;
                    yPoint += 20;

                    if (yPoint > page.Height - 60)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = 40;
                    }
                }

                // Draw total
                yPoint += 20;
                gfx.DrawString($"Total Balance: {totalBalance.ToString("C2", culture)}", boldFont, XBrushes.Black,
                    new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);

                using var stream = new MemoryStream();
                document.Save(stream, false);
                return stream.ToArray();
            }
        }
    }