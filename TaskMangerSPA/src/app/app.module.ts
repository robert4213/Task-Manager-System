import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule, FormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TaskComponent } from './task/task.component';
import { HeaderComponent } from './core/layout/header/header.component';
import {HttpClientModule} from '@angular/common/http';
import { UserUpdateComponent } from './user/user-update/user-update.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { TaskUpdateComponent } from './task/task-update/task-update.component';
import { TaskHistoryUpdateComponent } from './task-history/task-history-update/task-history-update.component';
import { UserFormComponent } from './shared/component/user-form/user-form.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TaskCreateComponent } from './task/task-create/task-create.component';
import { TaskFormComponent } from './shared/component/task-form/task-form.component';
import { TaskHistoryFormComponent } from './shared/component/task-history-form/task-history-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TaskComponent,
    HeaderComponent,
    UserUpdateComponent,
    UserRegisterComponent,
    TaskUpdateComponent,
    TaskHistoryUpdateComponent,
    UserFormComponent,
    TaskCreateComponent,
    TaskFormComponent,
    TaskHistoryFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
