import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnauthorizedComponent } from './shared/unauthorized-page/unauthorized.component';
import { GoalModule } from './goals/goal.module';
import { AuthGuard } from './core/guard/auth.guard';
import { LoginComponent } from './core/login-component/login.component';
import { InDevelopmentComponent } from './shared/in-development/in-development.component';

@NgModule({
  imports: [
    RouterModule.forRoot([
    { path: '', redirectTo: 'goals', pathMatch: 'full' },
    { path: 'goals', loadChildren: () => GoalModule, canActivate: [AuthGuard] },
    { path: 'categories', component: InDevelopmentComponent, canActivate: [AuthGuard] },
    { path: 'week', component: InDevelopmentComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'unauthorized', component: UnauthorizedComponent },
    { path: '**', component: UnauthorizedComponent },
], { relativeLinkResolution: 'legacy' }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
