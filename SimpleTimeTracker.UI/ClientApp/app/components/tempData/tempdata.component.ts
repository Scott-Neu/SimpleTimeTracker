import { Component } from '@angular/core';
import { AuthHttp } from 'angular2-jwt';
import { environment } from '../../enviroments/enviroment';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/user.model';

@Component({
    selector: 'tempdata',
    templateUrl: './tempdata.component.html'
})
export class TempDataComponent {
    public values: string[];
    public userModel: UserModel;

    constructor(private authHttp: AuthHttp, private userService: UserService) {
        this.userModel = userService.currentUser;
        console.log(this.userModel.Roles);
        console.log(this.userModel.isSiteAdmin());

        var apiEndpoint = environment.apiUrl + "/temp";

        authHttp.get(apiEndpoint).subscribe(result => {
            this.values = result.json() as string[];
        });
    }
}
