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

  public deleteUser(id: number): Observable<any> {
    return this.apiService.delete(`user/delete`, id).pipe(map(res => res as any));
  }
}
