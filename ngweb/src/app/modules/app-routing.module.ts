import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../pages/login/login.component';
import { HomeComponent } from '../pages/home/home.component';
import { UserComponent } from '../pages/user/user.component';
import { AuthGuard } from '../guards/auth.guard';
import { DetailsComponent } from '../pages/details/details.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'user/:username', component: UserComponent, canActivate: [ AuthGuard ]},
  { path: 'channel/:link', component: DetailsComponent },
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
