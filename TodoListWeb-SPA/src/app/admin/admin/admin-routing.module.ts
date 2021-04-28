import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TodoListComponent } from 'src/app/front-end/todo-list/todo-list.component';
import { TasksResolver } from 'src/app/_resolvers/task.resolver';
import { CompleteTaskListComponent } from '../complete-task-list/complete-task-list.component';
import { CreateTodolistComponent } from '../create-todolist/create-todolist.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { UserListComponent } from '../user-list/user-list.component';
import { AdminComponent } from './admin.component';



const adminRoutes: Routes = [
    {
      path: '',
      component: AdminComponent,
      children: [
        {path: 'dashboard', component: DashboardComponent},
        {path: 'create', component: CreateTodolistComponent},
        {path: 'completetasklist', component: CompleteTaskListComponent},
        {path: 'userlist', component: UserListComponent},
        /* {path: 'dashboard', component: DashboardComponent},

        {path: 'class', component: ClassComponent},
        {path: 'subject', component: SubjectComponent},
        {path: 'subjectsforclass', component: SubjectsForClassComponent},
        {path: 'topic', component: TopicComponent},
        {path: 'video', component: VideoComponent},
        {path: 'banner', component: BannerComponent},
        {path: 'admin-login', component: AdminLoginComponent}, */
        {path: '', redirectTo: 'dashboard', pathMatch: 'full'}
      ]
    }

];

@NgModule({
    imports: [RouterModule.forChild(adminRoutes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
