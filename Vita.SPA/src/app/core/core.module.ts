import { Optional, SkipSelf, NgModule, APP_INITIALIZER, InjectionToken } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { OidcConfigService, OidcSecurityService, LogLevel } from 'angular-auth-oidc-client';
import { ApiAuthInterceptor } from './interceptors/api-auth.interceptor';
import { UserService } from './user/user.service';
import { AuthGuard } from './guard/auth.guard';
import { StartUpService } from './start-up/start-up.service';
import { ConfigurationService } from './configuration/configuration.service';

@NgModule({
  imports: [HttpClientModule],
  declarations: [],
  providers: [
    OidcConfigService,
    OidcSecurityService,
    ConfigurationService,
    StartUpService,
    {
      provide: APP_INITIALIZER,
      useFactory: (startUpService: StartUpService) => () => startUpService.initializeApp(),
      deps: [StartUpService],
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiAuthInterceptor,
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
