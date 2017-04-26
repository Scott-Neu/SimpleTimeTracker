import { Component } from '@angular/core';
import { Response } from '@angular/http';
import { AuthHttp } from 'angular2-jwt';
import { Router } from '@angular/router';
import { environment } from '../../enviroments/enviroment';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';
import { deserialize } from "serializer.ts/Serializer"; //https://www.npmjs.com/package/serializer.ts

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

            authHttp.get(apiEndpoint)
                .map(response => response.json())
                .subscribe(result => {
                    this.employees = deserialize<UsersViewModel[]>(UsersViewModel, result);
                });
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
}