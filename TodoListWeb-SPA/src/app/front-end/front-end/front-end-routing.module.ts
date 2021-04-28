import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TasksResolver } from 'src/app/_resolvers/task.resolver';
import { TodoListComponent } from '../todo-list/todo-list.component';
import { FrontEndComponent } from './front-end.component';



const routes: Routes = [
    {
      path: '',
      component: FrontEndComponent,
      children: [
        { path: 'todolist', component: TodoListComponent}
        /* { path: 'login', component: LoginComponent },
      { path: 'signup', component: RegisterComponent },
      { path: 'subjectsvideo/:id', component: SubjectVideoComponent , resolve: {videos: SubejctVideo}}, */

      ]
    },

   /*  {path: '',
    component: FrontEndComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'subjects/:id', component: SubjectsComponent, resolve: {subjects: SubjectsResolver} },
      { path: 'chapters/:id', component: ChaptersComponent , resolve: {chapters: SubjectsChapter}},
      { path: 'topics/:id', component: SubjectDetailsComponent , resolve: {topics: SubjectsTopicResolver}},
      { path: 'notice', component: NoticeComponent },
      { path: 'profile', component: ProfileComponent },
    ]
  } */
  {path: '**', redirectTo: '', pathMatch: 'full'},
  ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FrontEndRoutingModule { }
