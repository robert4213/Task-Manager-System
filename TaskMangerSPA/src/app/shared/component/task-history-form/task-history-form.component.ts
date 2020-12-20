import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {User} from '../../model/User';
import {UserService} from '../../../core/services/user.service';
import {TaskHistory} from '../../model/TaskHistory';

@Component({
  selector: 'app-task-history-form',
  templateUrl: './task-history-form.component.html',
  styleUrls: ['./task-history-form.component.css']
})
export class TaskHistoryFormComponent implements OnInit {
  @Input() taskHistory: TaskHistory;
  @Output() res = new EventEmitter<TaskHistory>();
  users: User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(res => {
      this.users = res;
    });
  }
  onSubmit(): void {
    this.res.emit(this.taskHistory);
  }

}
