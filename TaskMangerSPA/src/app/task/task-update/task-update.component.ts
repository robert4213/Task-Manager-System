import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/shared/model/Task';
import {TaskService} from '../../core/services/task.service';
import {UserService} from '../../core/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-task-update',
  templateUrl: './task-update.component.html',
  styleUrls: ['./task-update.component.css']
})
export class TaskUpdateComponent implements OnInit {
  noTaskFound = false;
  updateFailed = false;
  task: Task = {} as Task;
  taskId = 0;

  constructor(private taskService: TaskService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(p => {
      this.taskId = + p.get('id');
      this.taskService.getTaskById(this.taskId).subscribe(res => {
        this.task = res;
      }, error => {
        this.noTaskFound = true;
      });
    });
  }

  onSubmit(task: Task): void{
    this.taskService.updateTask(task).subscribe(res => {
      this.router.navigate([`task`, task.userId]);
    },error => {
      this.updateFailed = true;
    });
  }

  failedDismiss():void{
    this.updateFailed = false;
  }

}
