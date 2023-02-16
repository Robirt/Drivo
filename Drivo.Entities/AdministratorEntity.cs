namespace Drivo.Entities;

public class AdministratorEntity : UserEntity
{
	public AdministratorEntity() : base()
	{

	}

	public AdministratorEntity(string userName, string email, string firstName, string lastName, DateTime birthDate, string phoneNumber) : base(userName, email, firstName, lastName, birthDate, phoneNumber)
	{

	}
}
