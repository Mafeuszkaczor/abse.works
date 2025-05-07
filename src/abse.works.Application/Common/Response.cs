namespace abse.works.Application.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public bool Warning { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public static Response<T> SuccessResponse() =>
            new Response<T> { Success = true};
        public static Response<T> SuccessResponse(T data) =>
            new Response<T> { Success = true, Data = data };

        public static Response<T> SuccessResponse(string message) =>
            new Response<T> { Success = true, Message = message };

        public static Response<T> BadResponse(string message) =>
            new Response<T> { Success = false, Message = message };

        public static Response<T> BadResponse(string message, T data) =>
            new Response<T> { Success = false, Message = message, Data = data };

        public static Response<T> WarningResponse(string message, T data = default) =>
            new Response<T> { Warning = true, Message = message, Data = data };
    }
}
