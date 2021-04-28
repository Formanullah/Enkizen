import { Task } from './../_models/task';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TaskCreationDtos } from '../_models/taskCreationDtos';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl + 'Admin/';

constructor( private http: HttpClient) { }

// tslint:disable-next-line:typedef
createTask(task: TaskCreationDtos) {
  return this.http.post(this.baseUrl, task);
}

// tslint:disable-next-line:typedef
deleteTask(id: number) {
  return this.http.delete(this.baseUrl + 'DeleteTask/' + id);
}

// tslint:disable-next-line:typedef
completeTask(id: number) {
  return this.http.get(this.baseUrl + 'CompleteTask/' + id);
}

getTaskbyUserId(userId: number): Observable<Task[]> {
  return this.http.get<Task[]>(this.baseUrl + 'GetTodaysTaskByUserId/' + userId);
}

getAllUser(): Observable<User[]> {
  return this.http.get<User[]>(this.baseUrl + 'GetUsers');
}

getAllTask(): Observable<Task[]> {
  return this.http.get<Task[]>(this.baseUrl + 'GetTasks');
}

getAllCompletedTask(): Observable<Task[]> {
  return this.http.get<Task[]>(this.baseUrl + 'GetCompletedTasks');
}


}
