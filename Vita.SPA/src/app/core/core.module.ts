import { Optional, SkipSelf, NgModule, APP_INITIALIZER, InjectionToken } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OidcConfigService, OidcSecurityService, LogLevel } from 'angular-auth-oidc-client';
import { ApiAuthInterceptor } from './interceptors/api-auth.interceptor';
import { environment } from 'src/environments/environment';
import { UserService } from './user/user.service';
import { AuthGuard } from './guard/auth.guard';

// export function initializeApp(startupService: StartUpService) {
//   return () => startupService.initializeApp().toPromise();
// }

export function initializeApp(_oidcConfigService: OidcConfigService, _oidcSecurityService: OidcSecurityService) {
  return () =>
    _oidcConfigService
      .withConfig({
        stsServer: environment.oidcEndpoint,
        redirectUrl: window.location.origin + '/login',
        postLogoutRedirectUri: window.location.origin + '/login',
        clientId: 'vita.spa',
        scope: 'openid profile api offline_access',
        responseType: 'code',
        silentRenew: false,
        useRefreshToken: false,
        logLevel: LogLevel.Debug,
      })
      .then((_) => _oidcSecurityService.checkAuth());
}

@NgModule({
  imports: [HttpClientModule],
  declarations: [],
  providers: [
    OidcConfigService,
    OidcSecurityService,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [OidcConfigService, OidcSecurityService],
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiAuthInterceptor,
      deps: [OidcSecurityService],
      multi: true,
    },
    UserService,
    AuthGuard,
  ],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) throw new Error('Core is already loaded. Import it in the AppModule only');
  }
}
