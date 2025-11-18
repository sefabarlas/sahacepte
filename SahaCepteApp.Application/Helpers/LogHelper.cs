using Microsoft.AspNetCore.Http;
using SahaCepteApp.API.Extensions;
using SahaCepteApp.Domain.Enums;
using SahaCepteApp.Logger;

namespace SahaCepteApp.Application.Helpers;

public class LogHelper(IHttpContextAccessor httpContextAccessor, ILoggerManager logger)
{
    public void InfoLog(string message)
    {
        logger.LogInfo($"Method: {httpContextAccessor.HttpContext?.Request.Method} Path: {httpContextAccessor.HttpContext?.Request.Path} User: {httpContextAccessor.HttpContext?.User.GetUserId()} Message: {message}");
    }

    public void SuccessLog(string model)
    {
        logger.LogInfo($"SUCCESS    Method: {httpContextAccessor.HttpContext?.Request.Method} Path: {httpContextAccessor.HttpContext?.Request.Path} User: {httpContextAccessor.HttpContext?.User.GetUserId()} ResponseModel: {model}");
    }

    public void WarningLog(string message)
    {
        logger.LogWarn($"Method: {httpContextAccessor.HttpContext?.Request.Method} Path: {httpContextAccessor.HttpContext?.Request.Path} User: {httpContextAccessor.HttpContext?.User.GetUserId()} WarningMessage: {message}");
    }

    public void ErrorLog(string message)
    {
        logger.LogError($"Method: {httpContextAccessor.HttpContext?.Request.Method} Path: {httpContextAccessor.HttpContext?.Request.Path} User: {httpContextAccessor.HttpContext?.User.GetUserId()} ErrorMessage: {message}");
    }

    public void ManagerErrorLog(string model, string errorMessage)
    {
        ErrorLog($"Model: {model} ErrorMessage: {errorMessage}");
    }
    
    public void ManagerWarningLog(string model, string errorMessage)
    {
        WarningLog($"Model: {model} WarningMessage: {errorMessage}");
    }

    public void HandleResult(int resultTypeId, string requestModel, string responseModel, string message)
    {
        if (resultTypeId == (int)ResponseDataTypes.Error)
            ManagerErrorLog(requestModel, message);
        else if (resultTypeId == (int)ResponseDataTypes.Warning)
            ManagerWarningLog(requestModel, message);
        else
            SuccessLog(responseModel);
    }

    public void JobLog(string message)
    {
        logger.LogInfo("JOB    Message : " + message);
    }

    public void AnonymousErrorLog(string message)
    {
        logger.LogInfo("Anonymous  ERROR  Message : " + message);
    }
}