import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css']
})
export class SignOutComponent implements OnInit {

  constructor(private userService: UserService) { }

  async ngOnInit(): Promise<void> {
    await this.signOutAsync();
  }

  public async signOutAsync(): Promise<void> {
    await this.userService.signOutAsync();
  }
}
