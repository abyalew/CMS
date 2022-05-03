namespace CMS.Host.Controllers.Api
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }

    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse(T content)
        {
            Message = "Operation Successful.";
            Success = true;
            Content = content;
        }
        public SuccessResponse(T content, string message)
        {
            Message = message;
            Success = true;
            Content = content;
        }
    }


    public class FailedResponse<T> : Response<T>
    {
        public FailedResponse()
        {
            Message = "Operation Failed.";
            Success = false;
        }
        public FailedResponse(string message)
        {
            Message = message;
            Success = false;
        }
    }
}