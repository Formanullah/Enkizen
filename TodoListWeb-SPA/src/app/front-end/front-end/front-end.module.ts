import { FrontEndRoutingModule } from './front-end-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FrontEndComponent } from './front-end.component';
import { TodoListComponent } from '../todo-list/todo-list.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavComponent } from 'src/app/nav/nav.component';
import { TasksResolver } from 'src/app/_resolvers/task.resolver';

@NgModule({
  imports: [
    RouterModule,
    CommonModule,
    FrontEndRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    FrontEndComponent,
    TodoListComponent,
    NavComponent
  ],
})
export class FrontEndModule { }
