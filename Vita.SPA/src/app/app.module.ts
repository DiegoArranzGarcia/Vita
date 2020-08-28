import { BrowserModule } from '@angular/platform-browser';
import { NgModule, InjectionToken } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CategoryModule } from './categories/category.module';
import { AuthModule } from 'angular-auth-oidc-client';
import { CoreModule } from './core/core.module';
import { GoalModule } from './goals/goal.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

export let APP_CONFIG = new InjectionToken<AppConfig>('app.config');

export class AppConfig {
  apiEndpoint: string;
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule, // Singletone objects (service, componets that are loaded)
    SharedModule, // Shared (multi-instance) objects
    AuthModule.forRoot(), //login module
    CategoryModule,
    GoalModule,
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
