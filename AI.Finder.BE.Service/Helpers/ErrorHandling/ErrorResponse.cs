namespace AI.Finder.BE.Service.Helpers.ErrorHandling
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }

    }
}