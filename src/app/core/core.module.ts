import { Optional, SkipSelf, NgModule, APP_INITIALIZER, InjectionToken } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OidcConfigService, OidcSecurityService, LogLevel } from 'angular-auth-oidc-client';
import { ApiAuthInterceptor } from './interceptors/api-auth.interceptor';
import { environment } from 'src/environments/environment';
import { UserService } from './user/user.service';

// export function initializeApp(startupService: StartUpService) {
//   return () => startupService.initializeApp().toPromise();
// }

export function initializeApp(_oidcConfigService: OidcConfigService, _oidcSecurityService: OidcSecurityService) {
  return () =>
    _oidcConfigService
      .withConfig({
        stsServer: environment.oidcEndpoint,
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: 'vita.spa',
        scope: 'openid profile api offline_access',
        responseType: 'code',
        silentRenew: true,
        useRefreshToken: true,
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
    UserService,
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
  ],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) throw new Error('Core is already loaded. Import it in the AppModule only');
  }
}
