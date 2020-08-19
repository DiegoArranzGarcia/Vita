import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpHeaders } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable, NEVER } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class CorsInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const corsRequest = request.clone({
      headers: request.headers.set('Access-Control-Allow-Origin', '*'),
    });

    return next.handle(corsRequest);
  }
}
