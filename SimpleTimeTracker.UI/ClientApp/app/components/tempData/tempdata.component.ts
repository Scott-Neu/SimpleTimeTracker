import { Component } from '@angular/core';
import { AuthHttp } from 'angular2-jwt';
import { environment } from '../../enviroments/enviroment';

@Component({
    selector: 'tempdata',
    templateUrl: './tempdata.component.html'
})
export class TempDataComponent {
    public values: string[];

    constructor(private authHttp: AuthHttp) {
        var apiEndpoint = environment.apiUrl + "/temp";

        authHttp.get(apiEndpoint).subscribe(result => {
            this.values = result.json() as string[];
        });
    }
}
