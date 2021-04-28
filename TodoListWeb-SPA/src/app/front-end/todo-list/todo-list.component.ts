import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Task } from 'src/app/_models/task';
import { AdminService } from 'src/app/_services/admin.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  tasks: Task[] = [];
  user: any = {
    id: 0,
    roleName: ''
  };

  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user') || '');
    this.getAllTaskByUserId();
  }

  getAllTaskByUserId() {
    this.userService.getTaskbyUserId(this.user.id).subscribe(res =>{
      this.tasks = res;
    }, error => {
      console.log(error);
    });

  }

  completeTask(id: number): void {
    this.userService.completeTask(id).subscribe( res => {
      this.getAllTaskByUserId();
    }, error => {
      console.log(error);
    });
  }


}
