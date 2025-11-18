using SahaCepteApp.Domain.Enums;

namespace SahaCepteApp.Domain.Wrappers;

public class ServiceResponse<T>
{
    public ResponseDataTypes ResponseDataType { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
    public DateTime ServerTime { get; set; }
    public int? TotalRowCount { get; set; }

    public ServiceResponse()
    {
    }

    public ServiceResponse(T data, string message = null)
    {
        ResponseDataType = ResponseDataTypes.Success;
        Message = message ?? "İşlem başarılı.";
        Data = data;
        Errors = null;
        ServerTime = DateTime.UtcNow;
        TotalRowCount = null;
    }

    public ServiceResponse(string message, ResponseDataTypes responseDataType)
    {
        ResponseDataType = responseDataType;
        Message = message;
        Data = default;
        Errors = null;
        ServerTime = DateTime.UtcNow;
        TotalRowCount = null;
    }

    public ServiceResponse(List<string> errors)
    {
        ResponseDataType = ResponseDataTypes.ErrorWithList;
        Message = "Bir veya daha fazla hata oluştu.";
        Data = default;
        Errors = errors;
        ServerTime = DateTime.UtcNow;
        TotalRowCount = null;
    }
    
    public static ServiceResponse<T> SuccessResult(T data, string message = "İşlem başarılı.")
    {
        return new ServiceResponse<T>(data, message);
    }

    public static ServiceResponse<T> FailureResult(string message)
    {
        return new ServiceResponse<T>(message, ResponseDataTypes.Error);
    }
    
    public static ServiceResponse<T> WarningResult(string message)
    {
        return new ServiceResponse<T>(message, ResponseDataTypes.Warning);
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