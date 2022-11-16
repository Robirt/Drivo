using Microsoft.AspNetCore.Identity;

namespace Drivo.Entities;

public class RoleEntity : IdentityRole<int>
{
	public RoleEntity() : base()
	{

	}

	public RoleEntity(string roleName) : base(roleName)
	{

	}
}
