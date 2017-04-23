import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    showNavigation: boolean = false;
    constructor(private router: Router) {
        this.router.events.subscribe((event) => {

            if (event instanceof NavigationEnd) {
                //debugger;
                if (event.url === '/login') {
                    this.showNavigation = false;
                } else {
                    this.showNavigation = true;
                }
            }
            console.log(event);
            if (event.url) {
                console.log(event.url);
            }
        });
    }
}
