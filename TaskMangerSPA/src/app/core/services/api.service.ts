import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient: HttpClient) { }

  public getAll(path: string): Observable<any[]> {
    return this.httpClient.get(`${environment.apiUrl}${path}`).pipe(map(res => res as any[]));
  }

  public getOne(path: string, id?: number): Observable<any> {
    return typeof(id) !== 'undefined' ? this.httpClient.get(`${environment.apiUrl}${path}/${id}`).pipe(map(res => res as any))
      : this.httpClient.get(`${environment.apiUrl}${path}`).pipe(map(res => res as any));
  }

  public create(path: string, resource: any): Observable<any>{
    return this.httpClient.post(`${environment.apiUrl}${path}`, resource).pipe(map(res => res as any));
  }

  public update(path: string, resource: any): Observable<any> {
    return this.httpClient.put(`${environment.apiUrl}${path}`, resource).pipe(map(res => res as any));
  }

  public delete(path: string, id: number): Observable<any> {
    return this.httpClient.delete(`${environment.apiUrl}${path}/${id}`).pipe(map(res => res as any));
  }
}
