import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;


constructor(private http: HttpClient, private router: Router) { }


// tslint:disable-next-line:typedef
login(model: any) {

  return this.http.post(this.baseUrl + 'Auth/login', model)
  .pipe(
    map((response: any) => {
      const user = response;
      console.log(response);
      if (user) {
        localStorage.setItem('token', user.token);
        localStorage.setItem('user', JSON.stringify(user.user));
      }
    })
  );
}

loggedIn(): boolean {
  const token = localStorage.getItem('user');
  if (token) {
    return true;
  }
  return false;
}


}
