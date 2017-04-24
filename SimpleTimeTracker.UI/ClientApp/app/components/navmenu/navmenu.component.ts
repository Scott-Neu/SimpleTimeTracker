import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    public userModel: UserModel;

    constructor(private userService: UserService) {
        this.userModel = userService.currentUser;
    }
}
