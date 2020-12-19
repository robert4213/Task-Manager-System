import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TaskComponent } from './task/task.component';
import { HeaderComponent } from './core/layout/header/header.component';
import {HttpClientModule} from '@angular/common/http';
import { UserUpdateComponent } from './user/user-update/user-update.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TaskComponent,
    HeaderComponent,
    UserUpdateComponent,
    UserRegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
