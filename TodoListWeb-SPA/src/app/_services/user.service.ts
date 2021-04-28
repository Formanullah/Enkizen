import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Task } from '../_models/task';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl + 'User/';


  constructor(private http: HttpClient, private router: Router) { }

  completeTask(id: number) {
    return this.http.get(this.baseUrl + 'CompleteTask/' + id);
  }


  getTaskbyUserId(userId: number): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + 'GetTodaysTaskByUserId/' + userId);
  }

}
