import { Component, OnInit } from '@angular/core';
import {User} from '../shared/model/User';
import {ApiService} from '../core/services/api.service';
import {UserService} from '../core/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  users: User[];
  deleteFailed = false;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(res => {
      this.users = res;
    });
  }

  private deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe(res => {
      this.ngOnInit();
    }, error => {
      this.deleteFailed = true;
    });
  }

  private failedDismiss(): void{
    this.deleteFailed = false;
  }
}
