import { Injectable } from '@angular/core';
import { Task } from 'src/app/shared/model/Task';
import {ApiService} from './api.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {TaskHistory} from '../../shared/model/TaskHistory';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private apiService: ApiService) { }

  public getUserTask(id: number): Observable<Task[]> {
    return this.apiService.getAll(`task`, id).pipe(map(res => res as Task[]));
  }

  public getUserTaskHistory(id: number): Observable<TaskHistory[]>{
    return this.apiService.getAll(`TaskHistory`, id).pipe(map(res => res as TaskHistory[]));
  }

  public deleteTask(id: number): Observable<any>{
    return this.apiService.delete(`Task/delete`, id).pipe(map(res => res as any));
  }

  public deleteTaskHistory(id: number): Observable<any>{
    return this.apiService.delete(`TaskHistory/delete`, id);
  }

  public taskComplete(id: number): Observable<any> {
    return this.apiService.getOne(`TaskHistory/complete`, id);
  }

  public createTask(task: Task): Observable<any>{
    return this.apiService.create('Task/create', task);
  }

  public getTaskById(id: number): Observable<Task>{
    return this.apiService.getOne('task/id', id).pipe(map(res => res as Task));
  }

  public getTaskHistoryById(id: number): Observable<TaskHistory>{
    return this.apiService.getOne('taskHistory/id', id).pipe(map(res => res as TaskHistory));
  }

  public updateTask(task: Task): Observable<any>{
    return this.apiService.update('task/update', task);
  }

  public updateTaskHistory(taskHistory: TaskHistory): Observable<any>{
    return this.apiService.update('taskHistory/update', taskHistory);
  }
}
