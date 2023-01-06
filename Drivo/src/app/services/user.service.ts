import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from 'src/models/user.model';
import { SignInRequest } from 'src/requests/signIn.request';
import { ActionResponse } from 'src/responses/action.response';
import { SignInResponse } from 'src/responses/signIn.response';
export let Buffer = require('buffer').Buffer;

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  public getUser(): UserModel | null {
    var token: string | null = localStorage.getItem("Token");
    if (!token) return null;

    return JSON.parse(Buffer.from(token.split('.')[1], 'base64')) as UserModel;
  }

  public getJwtBearerToken(): string | null {
    return localStorage.getItem("Token");
  }

  public isUserAuthorized(): boolean {
    return localStorage.getItem("Token") != null;
  }

  public async signInAsync(signInRequest: SignInRequest): Promise<SignInResponse> {
    var response: SignInResponse = await firstValueFrom(this.httpClient.post<SignInResponse>(`${environment.apiUri}/Users/SignIn`, signInRequest));

    if (response.isSucceeded) localStorage.setItem("Token", response.jwtBearerToken);

    return response;
  }

  public async signOutAsync(): Promise<ActionResponse> {
    localStorage.removeItem("Token");

    return new ActionResponse({ isSucceeded: true, message: "User successfully logged out." });
  }
}
