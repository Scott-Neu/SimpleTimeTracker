import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserModel } from '../models/user.model';

@Injectable()
export class UserService {
    public currentUser: UserModel;
    private storename: string = 'currentUser';

    constructor() {

        if (localStorage[this.storename])
        {
            this.currentUser = Object.assign(new UserModel(), JSON.parse(localStorage.getItem(this.storename)));
        }
    }

    public setCurrentUser(decyptedJwtToken: any): void {
        this.currentUser = new UserModel();
        this.currentUser.FirstName = decyptedJwtToken.given_name;
        this.currentUser.LastName = decyptedJwtToken.family_name;
        this.currentUser.Email = decyptedJwtToken.sub;
        this.currentUser.Roles = decyptedJwtToken.Roles;
        
        localStorage.setItem(this.storename, JSON.stringify(this.currentUser));
    }

    public removeCurrentUser(): void {
        this.currentUser = null;
        localStorage.removeItem(this.storename);
    }
}