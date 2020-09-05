import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable, TimeoutError } from 'rxjs';
import { ConfigurationService } from '../configuration/configuration.service';

@Injectable()
export class ApiAuthInterceptor implements HttpInterceptor {
  constructor(private _configurationService: ConfigurationService, private _oidcSecurityService: OidcSecurityService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.isLocalRequest(request)) return next.handle(request);
    if (!this.isVitaAPIRequest(request)) return next.handle(request);

    const accessToken: string = this._oidcSecurityService.getToken();

    if (!accessToken) return next.handle(request);

    const authRequest = request.clone({
      headers: request.headers.set('Authorization', `Bearer ${accessToken}`),
    });

    return next.handle(authRequest);
  }

  private isVitaAPIRequest(request: HttpRequest<any>) {
    return request.url.startsWith(this._configurationService.getConfiguration().vitaApiEndpoint);
  }

  private isLocalRequest(request: HttpRequest<any>) {
    return request.url.startsWith('/');
  }
}
