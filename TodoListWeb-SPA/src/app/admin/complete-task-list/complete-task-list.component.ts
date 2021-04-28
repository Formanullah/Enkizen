import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/_models/task';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-complete-task-list',
  templateUrl: './complete-task-list.component.html',
  styleUrls: ['./complete-task-list.component.css']
})
export class CompleteTaskListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private AdminSuervice: AdminService) { }

  ngOnInit() {
    this.AdminSuervice.getAllCompletedTask().subscribe( res => {
      this.tasks = res;
    }, error => {
      console.log(error);
    });
  }

}
