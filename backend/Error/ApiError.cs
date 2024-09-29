using System.Text.Json;

namespace web_api.Error
{
    public class ApiError
    {
        public ApiError() { }
        public ApiError(int errorCode, string errorMessage, string errorDetails = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;    
            ErrorDetails = errorDetails;
        }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public string? ErrorDetails { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
