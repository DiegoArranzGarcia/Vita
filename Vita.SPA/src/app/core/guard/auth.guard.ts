import { Router, CanActivate } from '@angular/router';
import { UserService } from '../user/user.service';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(public userService: UserService, public router: Router) {}
  canActivate(): boolean {
    if (this.userService.isAuthenticated()) return true;

    this.userService.signIn();
    return false;
  }
}
