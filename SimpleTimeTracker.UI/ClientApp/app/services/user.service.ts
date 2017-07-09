import { Injectable } from '@angular/core';
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

    public setCurrentUserByToken(decyptedJwtToken: any): void {
        this.currentUser = new UserModel();
        this.currentUser.Id = decyptedJwtToken.Id;
        this.currentUser.FirstName = decyptedJwtToken.given_name;
        this.currentUser.LastName = decyptedJwtToken.family_name;
        this.currentUser.Email = decyptedJwtToken.sub;
        this.currentUser.IsActive = true;
        this.currentUser.Roles = decyptedJwtToken.Roles;
        
        localStorage.setItem(this.storename, JSON.stringify(this.currentUser));
    }

    public setCurrentUserByModel(user: UserModel): void {

        localStorage.setItem(this.storename, JSON.stringify(user));
    }

    public removeCurrentUser(): void {
        this.currentUser = null;
        localStorage.removeItem(this.storename);
    }
}