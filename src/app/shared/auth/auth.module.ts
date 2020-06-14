import { NgModule } from "@angular/core";
import { UnauthorizedComponent } from "./unauthorized-page/unauthorized.component";
import { SingInComponent } from "./sign-in/sign-in.component";
import { CommonModule } from "@angular/common";

@NgModule({
  declarations: [UnauthorizedComponent, SingInComponent],
  imports: [CommonModule],
  exports: [UnauthorizedComponent, SingInComponent],
  providers: [],
})
export class AuthModule {}
