import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Unauthorized } from './shared/unauthorized-page/unauthorized.component';
import { GoalModule } from './goals/goal.module';
import { AuthGuard } from './core/guard/auth.guard';
import { LoginComponent } from './core/login-component/login.component';
import { InDevelopment } from './shared/in-development/in-development.component';

@NgModule({
  imports: [
    RouterModule.forRoot([
    { path: '', redirectTo: 'goals', pathMatch: 'full' },
    { path: 'goals', loadChildren: () => GoalModule, canActivate: [AuthGuard] },
    { path: 'categories', component: InDevelopment, canActivate: [AuthGuard] },
    { path: 'week', component: InDevelopment, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'unauthorized', component: Unauthorized },
    { path: '**', component: Unauthorized },
], { relativeLinkResolution: 'legacy' }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
