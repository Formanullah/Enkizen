import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'Admin',
    loadChildren: () => import('./admin/admin/admin.module').then(m => m.AdminModule)
  },
  { path: '',
  loadChildren: () => import('./front-end/front-end/front-end.module').then(m => m.FrontEndModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
