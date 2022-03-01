namespace EShop.Domain.Core.Response
{
    public class BaseResponse<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        public List<string> Messages { get; private set; } = new List<string>();
        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public static BaseResponse<T> Success(T data, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = new List<string>()
            };

        public static BaseResponse<T> Success(T data, string message, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = new List<string>() { message }
            };

        public static BaseResponse<T> Success(T data, List<string> messages, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = messages
            };

        public static BaseResponse<T> Fail(T data, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = new List<string>()
            };

        public static BaseResponse<T> Fail(T data, string message, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = new List<string> { message }
            };

        public static BaseResponse<T> Fail(T data, List<string> messages, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = messages
            };
    }
}

