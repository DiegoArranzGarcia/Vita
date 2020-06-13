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
  email: string = "nathan.drake@gmail.com";
  userNamer: string = "Nathan";

  constructor(public oidcSecurityService: OidcSecurityService) {}

  ngOnInit() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((isAuthenticated) => (this.isAuthenticated = isAuthenticated));
    // this.userData$ = this.oidcSecurityService.userData$;
    // this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
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
