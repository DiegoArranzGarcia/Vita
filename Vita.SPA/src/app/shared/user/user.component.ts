import { Component, OnInit, OnDestroy } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass'],
})
export class UserComponent implements OnInit {
  isAuthenticated: boolean;
  userId: string;
  email: string;
  userName: string;
  userWithoutAvatarIcon = faUserCircle;
  showUserIcon = false;

  constructor(public oidcSecurityService: OidcSecurityService) {}

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(isAuthenticated => (this.isAuthenticated = isAuthenticated));

    this.oidcSecurityService.userData$.subscribe(data => {
      if (!data) return;

      this.email = data.email;
      this.userName = `${data.given_name} ${data.family_name}`;
      this.userId = data.sub;
    });
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  onProfileImgLoadError(event: Event) {
    this.showUserIcon = true;
  }
}
