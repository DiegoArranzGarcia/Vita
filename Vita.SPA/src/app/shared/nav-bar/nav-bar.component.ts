import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { faRocket, faCalendarWeek, faLeaf, faAlignLeft } from '@fortawesome/free-solid-svg-icons';
import { NavBarItem } from './nav-bar-item.model';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Subscription } from 'rxjs';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'vita-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.sass'],
  animations: [
    trigger('expandAnimation', [
      state(
        'hide',
        style({
          height: '0px',
          opacity: '0',
          overflow: 'hidden',
        })
      ),
      state(
        'show',
        style({
          height: '*',
          opacity: '1',
        })
      ),
      transition('hide => show', animate('200ms ease-in')),
      transition('show => hide', animate('200ms ease-out')),
    ]),
  ],
})
export class NavBarComponent implements OnInit, OnDestroy {
  options: NavBarItem[];
  openedMenu: boolean;

  currentRoute: string;

  menuIcon = faAlignLeft;
  applicationIcon = faLeaf;

  private subscription: Subscription;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.options = [
      {
        label: 'Goals',
        icon: faRocket,
        navigateTo: '/goals/all',
      },
      {
        label: 'Week View',
        icon: faCalendarWeek,
        navigateTo: '/goals/week',
      },
    ];

    this.subscription = this.router.events
      .pipe(filter(navigationEvent => navigationEvent instanceof NavigationEnd))
      .subscribe((navigationEnd: NavigationEnd) => (this.currentRoute = navigationEnd.urlAfterRedirects));
  }

  ngOnDestroy(): void {
    if (this.subscription && !this.subscription.closed) this.subscription.unsubscribe();
  }

  navigate(navigateTo: string) {
    this.openedMenu = false;
    this.router.navigate([navigateTo]);
  }

  navigateToHome() {
    this.router.navigate(['/']);
  }

  onMenuOptionClick() {
    this.openedMenu = !this.openedMenu;
  }
}
