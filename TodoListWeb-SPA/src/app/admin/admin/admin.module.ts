import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { CompleteTaskListComponent } from '../complete-task-list/complete-task-list.component';
import { CreateTodolistComponent } from '../create-todolist/create-todolist.component';
import { UserListComponent } from '../user-list/user-list.component';
import { TasksResolver } from 'src/app/_resolvers/task.resolver';

@NgModule({
  imports: [
    RouterModule,
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
  AdminComponent,
  DashboardComponent,
  CompleteTaskListComponent,
  CreateTodolistComponent,
  UserListComponent
],
providers: [TasksResolver]
})
export class AdminModule { }
