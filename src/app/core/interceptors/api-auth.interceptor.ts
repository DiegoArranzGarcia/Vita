import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable, NEVER } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiAuthInterceptor implements HttpInterceptor {
  constructor(private _oidcSecurityService: OidcSecurityService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!request.url.startsWith(environment.apiEndpoint)) return next.handle(request);

    const accessToken: string = this._oidcSecurityService.getToken();

    if (!accessToken) return next.handle(request);

    const authRequest = request.clone({
      headers: request.headers.set('Authorization', `Bearer ${accessToken}`),
    });

    return next.handle(authRequest);
  }
}
