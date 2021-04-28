import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Task } from 'src/app/_models/task';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  tasks: Task[] = [];
  user: any = {
    id: 0,
    roleName: ''
  };

  constructor(private route: ActivatedRoute, private adminService: AdminService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user') || '');
    this.getAllTaskByUserId();
  }

  getAllTaskByUserId() {
    this.adminService.getTaskbyUserId(this.user.id).subscribe(res => {
      this.tasks = res;
      console.log(this.tasks);
    }, error => {
      console.log(error);
    });

  }

  completeTask(id: number): void {
    this.adminService.completeTask(id).subscribe( res => {
      this.getAllTaskByUserId();
    }, error => {
      console.log(error);
    });
  }

}
