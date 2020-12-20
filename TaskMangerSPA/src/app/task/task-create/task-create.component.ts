import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/shared/model/Task';
import {TaskService} from '../../core/services/task.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-task-create',
  templateUrl: './task-create.component.html',
  styleUrls: ['./task-create.component.css']
})
export class TaskCreateComponent implements OnInit {
  task: Task = {} as Task;
  createFailed = false;

  constructor(private taskService: TaskService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(task: Task): void{
    console.log(task);
    this.taskService.createTask(task).subscribe(res => {
      this.router.navigate([`task`, task.userId]);
    }, error => {
      this.createFailed = true;
    });
  }

  failedDismiss(): void{
    this.createFailed = false;
  }
}
