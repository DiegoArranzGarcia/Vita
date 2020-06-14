import { BrowserModule } from "@angular/platform-browser";
import { APP_INITIALIZER, NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { SharedModule } from "./shared/shared.module";
import { CategoryModule } from "./categories/category.module";
import {
  OidcConfigService,
  LogLevel,
  AuthModule,
} from "angular-auth-oidc-client";
import { UserHomeComponent } from "./users/home/user-home.component";

export function configureAuth(oidcConfigService: OidcConfigService) {
  return () =>
    oidcConfigService.withConfig({
      stsServer: "https://localhost:44360",
      redirectUrl: window.location.origin,
      postLogoutRedirectUri: window.location.origin,
      clientId: "vita.spa",
      scope: "openid profile api offline_access",
      responseType: "code",
      silentRenew: true,
      useRefreshToken: true,
      logLevel: LogLevel.Debug,
    });
}

@NgModule({
  declarations: [AppComponent, UserHomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule.forRoot(),
    SharedModule,
    CategoryModule,
  ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
