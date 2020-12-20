import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {User} from '../../model/User';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  @Input() user: User;
  @Output() res = new EventEmitter<User>();

  constructor() { }

  ngOnInit(): void {

  }

  onSubmit(): void{
    this.res.emit(this.user);
  }
}
