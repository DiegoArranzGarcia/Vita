import { Component, OnInit, OnDestroy } from "@angular/core";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { Observable } from "rxjs";

@Component({
  selector: "sign-in",
  templateUrl: "./sign-in.component.html",
  styleUrls: ["./sign-in.component.sass"],
})
export class SingInComponent implements OnInit, OnDestroy {
  // userData$: Observable<any>;
  // isAuthenticated$: Observable<boolean>;
  isAuthenticated: boolean;
  userId: string;
  email: string;
  userName: string;

  constructor(public oidcSecurityService: OidcSecurityService) {}

  ngOnInit() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((isAuthenticated) => (this.isAuthenticated = isAuthenticated));

    this.oidcSecurityService.userData$.subscribe((data) => {
      if (!data) return;

      this.email = data.email;
      this.userName = `${data.given_name} ${data.family_name}`;
      this.userId = data.sub;
    });
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  ngOnDestroy() {
    // isAuhenticated$.unsubscribe();
  }
}
