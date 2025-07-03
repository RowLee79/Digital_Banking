namespace Digital_Banking_API.Models.Dto
{
    public class TransactionResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public TransactionResultDto(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
