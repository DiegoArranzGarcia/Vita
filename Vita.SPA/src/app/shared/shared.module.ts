import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CalendarModule } from 'primeng/calendar';

import { NavBarComponent } from './nav-bar/nav-bar.component';
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
import { MomentModule } from 'ngx-moment';
import { CardModule } from 'primeng/card';
import { ModalComponent } from './modal/modal.component';
import { TabPanelComponent } from './tab-panel/tab-panel.component';
import { TabComponent } from './tab-panel/tab/tab.component';
import { ButtonGroupComponent } from './button-group/button-group.component';

const exportableModules = [CommonModule, FontAwesomeModule, MomentModule, CardModule];

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
  ModalComponent,
  TabPanelComponent,
  TabComponent,
  ButtonGroupComponent,
];

@NgModule({
  declarations: declarables,
  exports: [...declarables, ...exportableModules],
  imports: [CommonModule, MomentModule, FontAwesomeModule, ClickOutsideModule, CardModule],
})
export class SharedModule {}
