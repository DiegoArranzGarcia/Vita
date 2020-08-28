import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { MenuOption } from '../menu/menu-option.model';
import { faRocket, faCalendarWeek, faLeaf } from '@fortawesome/free-solid-svg-icons';
import { NavBarItem } from './nav-bar-item.model';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vita-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.sass'],
})
export class NavBarComponent implements OnInit, OnDestroy {
  options: NavBarItem[];
  currentRoute: string;
  applicationIcon = faLeaf;

  private subscription: Subscription;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.options = [
      {
        label: 'Goals',
        icon: faRocket,
        navigateTo: '/goals',
      },
      {
        label: 'Week View',
        icon: faCalendarWeek,
        navigateTo: '/week',
      },
    ];

    this.subscription = this.router.events
      .pipe(filter((navigationEvent) => navigationEvent instanceof NavigationEnd))
      .subscribe((navigationEnd: NavigationEnd) => (this.currentRoute = navigationEnd.urlAfterRedirects));
  }

  ngOnDestroy(): void {
    if (this.subscription && !this.subscription.closed) this.subscription.unsubscribe();
  }

  navigate(navigateTo: string) {
    this.router.navigate([navigateTo]);
  }

  navigateToHome() {
    // this.router.navigate(['/']);
  }
}
