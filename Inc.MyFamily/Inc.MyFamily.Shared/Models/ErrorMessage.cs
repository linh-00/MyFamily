namespace Inc.MyFamily.Shared.Models
{
    public class ErrorMessage
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

        public ErrorMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
