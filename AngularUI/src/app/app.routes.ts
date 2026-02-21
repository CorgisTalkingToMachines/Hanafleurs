import { Routes } from '@angular/router';
import { Login } from '@features/auth/pages/login/login';
import { Register } from '@features/auth/pages/register/register';
import { Home } from '@features/home/home';

export const routes: Routes = [
  {path: 'home', component: Home },
  {path: 'register' , component: Register },
  {path: 'login', component: Login },
  {path: '', redirectTo: 'home', pathMatch: 'full' }
];
