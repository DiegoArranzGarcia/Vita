import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from '../home/home.component';
import { UnauthorizedComponent } from './unauthorized-page/unauthorized.component';
import { UserComponent } from './user/user.component';
import { FooterComponent } from './footer/footer.component';
import { CardComponent } from './card/card.component';
import { LoadingComponent } from './loading/loading.component';
import { MenuComponent } from './menu/menu.component';
import { InDevelopmentComponent } from './in-development/in-development.component';
import { ClickOutsideModule } from 'ng-click-outside';
import { LabelComponent } from './label/label.component';

const declarables = [
  HomeComponent,
  CardComponent,
  UnauthorizedComponent,
  UserComponent,
  NavBarComponent,
  FooterComponent,
  LoadingComponent,
  MenuComponent,
  InDevelopmentComponent,
  LabelComponent,
];

@NgModule({
  declarations: declarables,
  exports: declarables,
  imports: [CommonModule, FontAwesomeModule, ClickOutsideModule],
})
export class SharedModule {}
