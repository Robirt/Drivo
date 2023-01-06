import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  public isUserAuthorized(): boolean {
    return this.userService.isUserAuthorized();
  }

  public getUserName(): string | undefined {
    return this.userService.getUser()?.name;
  }
}
