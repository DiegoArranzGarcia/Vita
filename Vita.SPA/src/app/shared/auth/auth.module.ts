import { NgModule } from '@angular/core';
import { UnauthorizedComponent } from './unauthorized-page/unauthorized.component';
import { SingInComponent } from './sign-in/sign-in.component';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [UnauthorizedComponent, SingInComponent],
  imports: [CommonModule, FontAwesomeModule],
  exports: [UnauthorizedComponent, SingInComponent],
  providers: [],
})
export class AuthModule {}
