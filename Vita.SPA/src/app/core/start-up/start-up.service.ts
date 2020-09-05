import { Injectable } from '@angular/core';
import { ConfigurationService } from '../configuration/configuration.service';
import { OidcConfigService, OidcSecurityService, LogLevel } from 'angular-auth-oidc-client';
import { environment } from 'src/environments/environment';
import { concat, from } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

@Injectable()
export class StartUpService {
  constructor(
    private oidcConfigService: OidcConfigService,
    private oidcSecurityService: OidcSecurityService,
    private configurationService: ConfigurationService
  ) {}

  initializeApp(): Promise<any> {
    return this.configurationService
      .loadConfiguration()
      .pipe(
        map((configuration) =>
          this.oidcConfigService.withConfig({
            stsServer: configuration.oidcEndpoint,
            redirectUrl: window.location.origin + '/login',
            postLogoutRedirectUri: window.location.origin + '/login',
            clientId: 'vita.spa',
            scope: 'openid profile api offline_access',
            responseType: 'code',
            silentRenew: false,
            useRefreshToken: false,
            logLevel: LogLevel.Debug,
          })
        ),
        switchMap(() => this.oidcSecurityService.checkAuth())
      )
      .toPromise();
  }
}
