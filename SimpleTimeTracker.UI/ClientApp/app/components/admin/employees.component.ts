import { Component } from '@angular/core';
import { Response } from '@angular/http';
import { AuthHttp } from 'angular2-jwt';
import { Router } from '@angular/router';
import { environment } from '../../enviroments/enviroment';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';

@Component({
    selector: 'employees',
    templateUrl: './employees.component.html'
})
export class EmployeesComponent {
    public employees: Array<UsersViewModel>;
    public currentUser: UserModel;

    constructor(private authHttp: AuthHttp, private router: Router, private userService: UserService) {
        this.currentUser = userService.currentUser;

        // validate permissions
        if (!this.currentUser.isUserAdmin())
        {
            this.router.navigate(['/']);
        }
        else
        {
            var apiEndpoint = environment.apiUrl + "/user";

            //authHttp.get(apiEndpoint)
            //    .map(res => {
            //        debugger;
            //        res.json() as UsersViewModel[];
            //    })
            //    .subscribe(result => {
            //        debugger;
            //        //var yyy = Object.assign(new Array<UsersViewModel>(), result());
            //        this.employees = result;
            //    });

            //authHttp.get(apiEndpoint)
            //    .subscribe(result => {
            //    debugger;
            //    var xxx = result.json()
            //    var yyy = Object.assign(new Array<UsersViewModel>(), result.json());

            //    this.employees = Object.assign(new Array<UsersViewModel>(), result.json());

            //    this.employees = result.json() as UsersViewModel[];
            //});


            authHttp.get(apiEndpoint)
                .map(response => response.json())
                //.do(data => console.log(data))
                .subscribe(result => {
                    var xxx = result;
                    var yyy = Object.assign(new Array<UsersViewModel>(), result);
                    this.employees = result;
                    console.log(yyy[0].getId());
                });
                //.do(data => console.log(data)); //debug to console
                //.subscribe(result => this.employees = result);
                //.catch(this.handleError);

            //Object.assign(new Foo(), JSON.parse(fooJson));
        }
    }
}

export class UsersViewModel {
    public id: string;
    public email: string;
    public firstName: string;
    public middleName: string;
    public lastName: string;
    public suffix: string;
    public isActive: boolean;

    getId(): string {
        return this.id;
    }
}