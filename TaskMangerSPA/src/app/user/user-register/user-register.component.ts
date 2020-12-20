import { Component, OnInit } from '@angular/core';
import {User} from '../../shared/model/User';
import {UserService} from '../../core/services/user.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {
  user: User = {} as User;
  createFailed = false;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  Submit(res: User): void{
    this.userService.createUser(res).subscribe(response => {
      this.router.navigate([`/`]);
    }, error => {
      this.createFailed = true;
    });
  }

  failedDismiss(): void{
    this.createFailed = false;
  }
}
