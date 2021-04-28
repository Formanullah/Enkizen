import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  user: any = {
    id: 0,
    roleName: ''
  };

  constructor(private router: Router) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user') || '');
    this.loggedIn();
  }

  loggedIn() {
    if (this.user.roleName !== 'Admin')
    {
      this.router.navigate(['']);
    }
  }

  logout(): void {
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    this.router.navigate(['']);
  }

}
