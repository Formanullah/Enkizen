import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';

import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Task } from '../_models/task';
import { AdminService } from '../_services/admin.service';


@Injectable()
export class TasksResolver implements Resolve<Task[]> {
    constructor(private adminService: AdminService,
                private router: Router) {}
    resolve(route: ActivatedRouteSnapshot): Observable<Task[]> {
        // tslint:disable-next-line:no-string-literal
        return this.adminService.getTaskbyUserId(route.params['id']).pipe(
            catchError( error => {
                console.log('problem retriving Data');
                this.router.navigate(['']);
                return of<Task[]>();
            })
        );
    }
}
