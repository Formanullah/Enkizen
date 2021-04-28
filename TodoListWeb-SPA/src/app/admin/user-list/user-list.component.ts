import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users: User[] = [];
  constructor(private adminService: AdminService) { }

  ngOnInit() {
    this.adminService.getAllUser().subscribe(res => {
      this.users = res;
    }, error => {
      console.log(error);
    });
  }

}
