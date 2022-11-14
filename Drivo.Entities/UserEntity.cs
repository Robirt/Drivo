using Microsoft.AspNetCore.Identity;

namespace Drivo.Entities;

public class UserEntity : IdentityUser<int>
{
    public UserEntity() : base()
    {

    }

    public UserEntity(string firstName, string lastName) : base()
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }
}