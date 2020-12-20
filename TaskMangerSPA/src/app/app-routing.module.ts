import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {UserUpdateComponent} from './user/user-update/user-update.component';
import {UserRegisterComponent} from './user/user-register/user-register.component';
import {TaskComponent} from './task/task.component';
import {TaskUpdateComponent} from './task/task-update/task-update.component';
import {TaskHistoryUpdateComponent} from './task-history/task-history-update/task-history-update.component';
import {TaskCreateComponent} from './task/task-create/task-create.component';

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
  {
    path: 'task/create',
    component: TaskCreateComponent
  },
  {
    path: 'task/update/:id',
    component: TaskUpdateComponent
  },
  {
    path: 'task/:id',
    component: TaskComponent
  },
  {
    path: 'taskHistory/update/:id',
    component: TaskHistoryUpdateComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
