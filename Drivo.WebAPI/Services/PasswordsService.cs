namespace Drivo.WebAPI.Services;

public class PasswordsService
{
    public string GeneratePassword()
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()_-+={[}]:;", 16).Select(password => password[Random.Shared.Next(password.Length)]).ToArray());
    }
}
