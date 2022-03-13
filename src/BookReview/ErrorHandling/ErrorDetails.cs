using System.Text.Json;

namespace BookReview.ErrorHandling
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorDetails(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occured";
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
