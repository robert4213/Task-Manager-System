import { Component, OnInit } from '@angular/core';
import {User} from '../../shared/model/User';
import {UserService} from '../../core/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {
  user: User = {} as User;
  userId = 0;
  updateFailed = false;
  noUserFound = false;
  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(p => {
      this.userId = + p.get('id');
      this.userService.getUserById(this.userId).subscribe(res => {
        this.user = res;
      }, error => {
        this.noUserFound = true;
      });
    });
  }

  onSubmit(res: User): void{
    console.log(res);
    this.userService.updateUser(res).subscribe(response => {
      this.router.navigate([`/`]);
    }, error => {
      this.updateFailed = true;
    });
  }

  failedDismiss(): void{
    this.updateFailed = false;
  }

}
