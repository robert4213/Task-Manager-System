import { Component, OnInit } from '@angular/core';
import {TaskService} from '../core/services/task.service';
import {ActivatedRoute} from '@angular/router';
import { Task } from '../shared/model/Task';
import { TaskHistory } from '../shared/model/TaskHistory';
import {UserService} from '../core/services/user.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  id = 0;
  tasks: Task[] = [];
  taskHistories: TaskHistory[] = [];
  userName = '';
  deleteFailed = false;
  completeFailed = false;

  constructor(private taskService: TaskService, private userService: UserService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = +params.get('id');
      this.taskService.getUserTask(this.id).subscribe(res => {
        this.tasks = res;
      });
      this.taskService.getUserTaskHistory(this.id).subscribe(res => {
        this.taskHistories = res;
      });
      this.userService.getUserById(this.id).subscribe(res => {
        this.userName = res.fullname;
      });
    });
  }

  private deleteTask(id: number): void{
    this.taskService.deleteTask(id).subscribe(res => {
      this.ngOnInit();
    }, error => {
      this.deleteFailed = true;
    });
  }

  private deleteTaskHistory(id: number): void{
    this.taskService.deleteTaskHistory(id).subscribe(res => {
      this.ngOnInit();
    }, error => {
      this.deleteFailed = true;
    });
  }

  private failedDismiss(): void {
    this.deleteFailed = false;
    this.completeFailed = false;
  }

  private taskComplete(id: number): void {
    this.taskService.taskComplete(id).subscribe(res => {
      this.ngOnInit();
    }, error => {
      this.completeFailed = true;
    });
  }
}
