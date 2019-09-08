import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { GoalsModule } from './goals/goals.module';
import { UsersCategoriesModule } from './users-categories/users-categories.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    GoalsModule,
    UsersCategoriesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
