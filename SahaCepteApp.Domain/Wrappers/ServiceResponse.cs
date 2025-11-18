namespace SahaCepteApp.Domain.Wrappers;

public class ServiceResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    public ServiceResponse()
    {
    }

    public ServiceResponse(T data, string message = null)
    {
        Success = true;
        Message = message ?? "İşlem başarılı.";
        Data = data;
        Errors = null;
    }

    public ServiceResponse(string message)
    {
        Success = false;
        Message = message;
        Data = default;
        Errors = null;
    }

    public ServiceResponse(List<string> errors)
    {
        Success = false;
        Message = "Bir veya daha fazla hata oluştu.";
        Data = default;
        Errors = errors;
    }
    
    public static ServiceResponse<T> SuccessResult(T data, string message = "İşlem başarılı.")
    {
        return new ServiceResponse<T>(data, message);
    }

    public static ServiceResponse<T> FailureResult(string message)
    {
        return new ServiceResponse<T>(message);
    }
        
    public static ServiceResponse<T> FailureResult(List<string> errors)
    {
        return new ServiceResponse<T>(errors);
    }

    public static ServiceResponse<T> NotFoundResult(T data, string message = "Kayıt bulunamadı.")
    {
        return new ServiceResponse<T>(data, message);
    }
}