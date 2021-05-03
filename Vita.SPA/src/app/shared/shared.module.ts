import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from '../home/home.component';
import { Unauthorized } from './unauthorized-page/unauthorized.component';
import { UserComponent } from './user/user.component';
import { Footer } from './footer/footer.component';
import { Card } from './card/card.component';
import { Spinner } from './spinner/spinner.component';
import { MenuComponent } from './menu/menu.component';
import { InDevelopment } from './in-development/in-development.component';
import { ClickOutsideModule } from 'ng-click-outside';
import { Label } from './label/label.component';
import { MomentModule } from 'ngx-moment';
import { ModalComponent } from './modal/modal.component';
import { TabPanel } from './tab-panel/tab-panel.component';
import { Tab } from './tab-panel/tab/tab.component';
import { ButtonGroup } from './button-group/button-group.component';
import { Calendar } from './calendar/calendar.component';
import { DatePicker } from './date-picker/date-picker.component';
import { WeekPicker } from './week-picker/week-picker.component';
import { MonthPicker } from './month-picker/month-picker.component';
import { YearPicker } from './year-picker/year-picker.component';

const exportableModules = [CommonModule, FontAwesomeModule, MomentModule];

const declarables = [
  HomeComponent,
  Card,
  Unauthorized,
  UserComponent,
  NavBarComponent,
  Footer,
  Spinner,
  MenuComponent,
  InDevelopment,
  Label,
  ModalComponent,
  TabPanel,
  Tab,
  ButtonGroup,
  Calendar,
  DatePicker,
  WeekPicker,
  MonthPicker,
  YearPicker,
];

@NgModule({
  declarations: declarables,
  exports: [...declarables, ...exportableModules],
  imports: [CommonModule, MomentModule, FontAwesomeModule, ClickOutsideModule],
})
export class SharedModule {}
