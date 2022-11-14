﻿namespace Drivo.Responses;

public class SignInResponse : ActionResponse
{
	public SignInResponse() : base()
	{

	}

	public SignInResponse(bool isSucceeded, string message) : base(isSucceeded, message)
	{

	}

	public SignInResponse(bool isSucceeded, string message, string jwtBearerToken) : base(isSucceeded, message)
	{

	}

    public string JwtBearerToken { get; set; }
}
