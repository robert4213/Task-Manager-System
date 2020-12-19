import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {UserUpdateComponent} from './user/user-update/user-update.component';
import {UserRegisterComponent} from './user/user-register/user-register.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'user/update/:id',
    component: UserUpdateComponent
  },
  {
    path: 'user/register',
    component: UserRegisterComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
