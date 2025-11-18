namespace SahaCepteApp.Domain.Dtos.Facility;

public class LoginDto
{
    public string PhoneNumber { get; set; }
}

public class AuthResponse
{
    public string Token { get; set; }
    public string FullName { get; set; }
}