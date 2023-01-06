import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignInRequest } from 'src/requests/signIn.request';
import { SignInResponse } from 'src/responses/signIn.response';
import { UserService } from '../services/user.service';

@Component({
    selector: 'app-sign-in',
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

    constructor(private router: Router, private userService: UserService) { }

    ngOnInit(): void {
    }

    public signInRequest: SignInRequest = new SignInRequest();

    public signInResponse: SignInResponse = new SignInResponse();

    public async signInAsync(): Promise<void> {
        this.signInResponse = await this.userService.signInAsync(this.signInRequest);

        console.log(this.signInResponse);

        if (this.signInResponse.isSucceeded) this.router.navigate(['']); 
    }
    
}
