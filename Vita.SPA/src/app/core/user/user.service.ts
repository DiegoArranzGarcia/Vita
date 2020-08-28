import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { User } from './user.model';

@Injectable()
export class UserService {
  private _isAuthenticated: boolean;
  private _currentUser: User = null;

  constructor(private _oidcSecurityService: OidcSecurityService) {
    this._currentUser = null;
    // this._oidcSecurityService.checkAuth().subscribe((isAuthenticated) => (this._isAuthenticated = isAuthenticated));
    this._oidcSecurityService.userData$.subscribe((data) => this.handleOnChangeUserData(data));
  }

  private handleOnChangeUserData(data: any): void {
    if (!data) return;

    this._isAuthenticated = true;
    this._currentUser = {
      id: data.sub,
      email: data.email,
      firstName: data.given_name,
      lastName: data.family_name,
      fullName: `${data.given_name} ${data.family_name}`,
    };
  }

  public getCurrentUser(): User {
    return this._currentUser;
  }

  public isAuthenticated(): boolean {
    return this._isAuthenticated;
  }

  public signIn(redirectUrl?: string): void {
    if (!redirectUrl) redirectUrl = '/goals';

    this._oidcSecurityService.authorize({ customParams: { ReturnUrl: redirectUrl } });
  }

  public signOut(): void {
    this._oidcSecurityService.logoff();
  }
}
