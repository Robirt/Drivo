using Microsoft.AspNetCore.Identity;

namespace Drivo.Entities;

public class UserEntity : IdentityUser<int>
{
    public UserEntity() : base()
    {

    }

    public UserEntity(string userName, string email, string firstName, string lastName, DateTime birthDate, string phoneNumber) : base(userName)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }
}