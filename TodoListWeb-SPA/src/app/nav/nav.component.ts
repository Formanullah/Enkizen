import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private routes: Router) { }
  user: any = {
    id: 0,
    roleName: ''
  };

  ngOnInit() {
  }

  login() {
     this.authService.login(this.model).subscribe(res => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    }, () => {
      this.user = JSON.parse(localStorage.getItem('user') || '');
      if (this.user.roleName === 'Admin') {
        this.routes.navigate(['/Admin/dashboard']);
      }
      else {
        this.routes.navigate(['/todolist']);
      }
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
   }

   logout(): void {
     localStorage.removeItem('token');
     localStorage.removeItem('user');
     this.routes.navigate(['']);
   }

}
