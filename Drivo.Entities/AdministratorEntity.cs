namespace Drivo.Entities;

public class AdministratorEntity : UserEntity
{
	public AdministratorEntity() : base()
	{

	}

	public AdministratorEntity(string userName, string email, string firstName, string lastName, DateTime birthDate) : base(userName, email, firstName, lastName, birthDate)
	{

	}
}
