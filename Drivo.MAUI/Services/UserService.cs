﻿using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class UserService
{
    public UserService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        return await (await HttpClient.PostAsJsonAsync("/Users/SignIn", request)).Content.ReadFromJsonAsync<SignInResponse>();
    }

    public async Task<StudentEntity> GetUserAsync()
    {
        return await HttpClient.GetFromJsonAsync<StudentEntity>("/Users");
    }

    public async Task SignOutAsync()
    {
        SecureStorage.RemoveAll();
    }
}
