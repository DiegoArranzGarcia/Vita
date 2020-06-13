import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { UnauthorizedComponent } from "./shared/auth/unauthorized-page/unauthorized.component";
import { UserHomeComponent } from "./users/home/user-home.component";

const routes: Routes = [];

@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: "", redirectTo: "home", pathMatch: "full" },
      { path: "goals", component: UserHomeComponent },
      { path: "home", component: HomeComponent },
      { path: "forbidden", component: UnauthorizedComponent },
      { path: "unauthorized", component: UnauthorizedComponent },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
