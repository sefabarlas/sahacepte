namespace SahaCepteApp.Application.Interfaces.Services;

public interface ICurrentUserService
{
    Guid UserId { get; }
        
    bool IsAuthenticated { get; }
        
    string FullName { get; }
}