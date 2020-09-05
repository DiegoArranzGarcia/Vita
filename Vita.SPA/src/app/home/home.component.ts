import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/user/user.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  handleOnStartClick() {
    this.userService.signIn();
  }
}
