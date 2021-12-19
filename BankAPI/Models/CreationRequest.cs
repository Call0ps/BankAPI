namespace BankAPI.Models;

public class UserCreationRequest
{
#pragma warning disable
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class AccountCreationRequest
{
    public string UserId { get; set; }
    public double Balance { get; set; }
    public double Interest { get; set; }
}