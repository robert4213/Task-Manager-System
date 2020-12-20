import { Component, OnInit } from '@angular/core';
import {TaskHistory} from '../../shared/model/TaskHistory';
import {TaskService} from '../../core/services/task.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-task-history-update',
  templateUrl: './task-history-update.component.html',
  styleUrls: ['./task-history-update.component.css']
})
export class TaskHistoryUpdateComponent implements OnInit {
  noTaskHistoryFound = false;
  updateFailed = false;
  taskHistory: TaskHistory = {} as TaskHistory;
  taskId = 0;

  constructor(private taskService: TaskService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(p => {
      this.taskId = + p.get('id');
      this.taskService.getTaskHistoryById(this.taskId).subscribe(res => {
        this.taskHistory = res;
      }, error => {
        this.noTaskHistoryFound = true;
      });
    });
  }

  failedDismiss(): void{
    this.updateFailed = false;
  }

  onSubmit(taskHistory: TaskHistory): void{
    console.log(taskHistory);
    this.taskService.updateTaskHistory(taskHistory).subscribe(res => {
      this.router.navigate([`task`, taskHistory.userId]);
    },error => {
      this.updateFailed = true;
      console.warn(error);
    });
  }
}
