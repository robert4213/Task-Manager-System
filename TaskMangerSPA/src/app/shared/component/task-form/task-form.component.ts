import {Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { Task } from '../../model/Task';
import {UserService} from '../../../core/services/user.service';
import {User} from '../../model/User';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  @Input() task: Task;
  @Output() res = new EventEmitter<Task>();
  users: User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(res => {
      this.users = res;
    });
  }
  onSubmit(): void {
    this.res.emit(this.task);
  }


}
