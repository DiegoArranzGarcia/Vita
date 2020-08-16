import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from '../home/home.component';
import { UnauthorizedComponent } from './auth/unauthorized-page/unauthorized.component';
import { SingInComponent } from './auth/sign-in/sign-in.component';
import { FooterComponent } from './footer/footer.component';
import { CoreModule } from '../core/core.module';

const declarables = [HomeComponent, UnauthorizedComponent, SingInComponent, NavBarComponent, FooterComponent];

@NgModule({
  declarations: declarables,
  exports: declarables,
  imports: [CommonModule, FontAwesomeModule],
})
export class SharedModule {}
