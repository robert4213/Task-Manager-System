import { Injectable } from '@angular/core';
import {ApiService} from './api.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {User} from '../../shared/model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  public getAllUsers(): Observable<User[]> {
    return this.apiService.getAll(`user`).pipe(map(res => res as User[]));
  }

  public getUserById(id: number): Observable<User>{
    return this.apiService.getOne('user', id).pipe(map(res => res as User));
  }

  public deleteUser(id: number): Observable<any> {
    return this.apiService.delete(`user/delete`, id).pipe(map(res => res as any));
  }

  public createUser(user: User): Observable<any>{
    return this.apiService.create('user/register', user);
  }

  public updateUser(user: User): Observable<any>{
    return this.apiService.update('user/update', user);
  }
}
