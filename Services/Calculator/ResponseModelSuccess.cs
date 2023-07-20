namespace Calculator
{
    public class ResponseModelSuccess<T>
    {
        public T Value { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }

        public ResponseModelSuccess(T data, bool success = true, string? error = null)
        {
            Value = data;
            Success = success;
            Error = error;
        }
    }
}