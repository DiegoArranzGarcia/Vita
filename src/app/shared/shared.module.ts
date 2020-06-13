import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { VitaApiClient } from "./vita-api/vita-api-client";
import { HttpClientModule } from "@angular/common/http";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { HomeComponent } from "../home/home.component";
import { UnauthorizedComponent } from "./auth/unauthorized-page/unauthorized.component";
import { SingInComponent } from "./auth/sign-in/sign-in.component";
import { FooterComponent } from "./footer/footer.component";
import { BrowserModule } from "@angular/platform-browser";

@NgModule({
  declarations: [
    HomeComponent,
    UnauthorizedComponent,
    SingInComponent,
    NavBarComponent,
    FooterComponent,
  ],
  imports: [CommonModule, HttpClientModule, FontAwesomeModule],
  exports: [
    HomeComponent,
    UnauthorizedComponent,
    SingInComponent,
    NavBarComponent,
    FooterComponent,
  ],
  providers: [VitaApiClient],
})
export class SharedModule {}
