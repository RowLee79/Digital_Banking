using Digital_Banking_API.Models.Dto;
using Digital_Banking_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Drawing;
using System.Text;

namespace Digital_Banking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //[HttpPost("deposit")]
        //public async Task<IActionResult> Deposit([FromBody] DepositDto dto)
        //{
        //    // Fix: Map DepositDto to TransactionDto before calling the service
        //    var transactionDto = new TransactionDto
        //    {
        //        AccountNumber = dto.AccountNumber,
        //        Amount = dto.Amount,
        //        Description = dto.Description
        //    };

        //    var result = await _transactionService.DepositAsync(transactionDto);
        //    return Ok(result);
        //}
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto dto)
        {
            try
            {

                var transactionDto = new TransactionDto
                {
                    AccountNumber = dto.AccountNumber,
                    Amount = dto.Amount,
                    Description = dto.Description
                };

                var transaction = await _transactionService.DepositAsync(transactionDto);
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                // Log exception, if logger available
                return BadRequest(new { error = ex.Message });
            }
        }



        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto dto)
        {
            // Fix: Map WithdrawDto to TransactionDto before calling the service
            var transactionDto = new TransactionDto
            {
                AccountNumber = dto.AccountNumber,
                Amount = dto.Amount,
                Description = dto.Description
            };

            var result = await _transactionService.WithdrawAsync(transactionDto);
            if (result == null || result.Status != "Success")
                return BadRequest("Transaction failed.");
            return Ok(result);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto dto)
        {
            var result = await _transactionService.TransferAsync(dto);
            if (result == null || result.Status != "Success")
                return BadRequest("Transaction failed.");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var txn = await _transactionService.GetTransactionAsync(id);
            if (txn == null) return NotFound();
            return Ok(txn);
        }

        [HttpGet("/api/accounts/{accountNumber}/transactions")]
        public async Task<IActionResult> GetTransactionHistory(string accountNumber)
        {
            var history = await _transactionService.GetTransactionHistoryAsync(accountNumber);
            return Ok(history);
        }
        [HttpGet("/api/accounts/{accountNumber}/statement")]
        public async Task<IActionResult> GetStatement(string accountNumber, [FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            try
            {
                var result = await _transactionService.GetStatementAsync(accountNumber, from, to);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/accounts/{accountNumber}/statement/download")]
        public async Task<IActionResult> DownloadStatement(
        string accountNumber,
        [FromQuery] DateTime from,
        [FromQuery] DateTime to,
        [FromQuery] string format = "csv") // or "pdf"
        {
            try
            {
                var transactions = await _transactionService.GetStatementAsync(accountNumber, from, to);

                if (format.ToLower() == "csv")
                {
                    var csv = new StringBuilder();
                    csv.AppendLine("Date,Type,Amount,Description,Status");
                    foreach (var t in transactions)
                    {
                        csv.AppendLine($"{t.Timestamp:yyyy-MM-dd HH:mm},{t.TransactionType},{t.Amount:F2},{t.Description},{t.Status}");
                    }

                    var bytes = Encoding.UTF8.GetBytes(csv.ToString());
                    return File(bytes, "text/csv", $"statement_{accountNumber}.csv");
                }

                if (format.ToLower() == "pdf")
                {
                    using var stream = new MemoryStream();
                    var doc = new PdfDocument();
                    var page = doc.AddPage();
                    var gfx = XGraphics.FromPdfPage(page);
                    var font = new XFont("Verdana", 10);

                    int y = 40;
                    gfx.DrawString("Transaction Statement", new XFont("Verdana", 14, XFontStyle.Bold), XBrushes.Black, new XPoint(20, y));
                    y += 30;

                    foreach (var t in transactions)
                    {
                        var line = $"{t.Timestamp:MM/dd/yyyy HH:mm} | {t.TransactionType} | {t.Amount:F2} | {t.Description} | {t.Status}";
                        gfx.DrawString(line, font, XBrushes.Black, new XPoint(20, y));
                        y += 20;
                        if (y > page.Height - 40)
                        {
                            page = doc.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            y = 40;
                        }
                    }

                    doc.Save(stream, false);
                    return File(stream.ToArray(), "application/pdf", $"statement_{accountNumber}.pdf");
                }

                return BadRequest("Invalid format. Use 'csv' or 'pdf'.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("accounts/{accountNumber}/balance-history")]
        public async Task<IActionResult> GetBalanceHistory(string accountNumber)
        {
            var transactions = await _transactionService.GetTransactionHistoryAsync(accountNumber); // Fix method name
            var balanceHistory = transactions.Select(t => new
            {
                t.Timestamp,
                t.TransactionType,
                t.Amount,
                t.Description,
                t.PostBalance
            });
            return Ok(balanceHistory);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTransactions(string accountNumber, decimal? amount, string? description)
        {
            try
            {
                var results = await _transactionService.SearchTransactionsAsync(accountNumber, amount, description);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
