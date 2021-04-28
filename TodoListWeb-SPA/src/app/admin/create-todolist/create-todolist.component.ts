import { TaskCreationDtos } from './../../_models/taskCreationDtos';
import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/_services/admin.service';
import { User } from 'src/app/_models/user';
import { Task } from 'src/app/_models/task';

@Component({
  selector: 'app-create-todolist',
  templateUrl: './create-todolist.component.html',
  styleUrls: ['./create-todolist.component.css']
})
export class CreateTodolistComponent implements OnInit {
  task: TaskCreationDtos = {
    taskName: '',
    userId: 0
  };

  users: User[] = [];
  tasks: Task[] = [];

  constructor( private adminservice: AdminService) { }

  ngOnInit(): void {
    this.getAllTasks();
    this.getUsers();
  }

  getUsers(): void {
    this.adminservice.getAllUser().subscribe( res => {
      this.users = res;
    }, error => {
      console.log(error);
    });
  }

  getAllTasks(): void {
    this.adminservice.getAllTask().subscribe( res => {
      this.tasks = res;
    }, error => {
      console.log(error);
    });
  }


  crateTask(): void {
    this.adminservice.createTask(this.task).subscribe( res => {
      console.log(res);
      this.getAllTasks();
    }, error => {
      console.log(error);
    });
  }

  deleteTask(id: any): void {
    this.adminservice.deleteTask(id).subscribe( res => {
      console.log(res);
      this.getAllTasks();
    }, error => {
      console.log(error);
    });
  }

}
