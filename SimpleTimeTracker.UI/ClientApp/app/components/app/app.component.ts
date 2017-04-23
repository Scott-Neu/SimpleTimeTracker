import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    showNavigation: boolean = false;
    constructor(private router: Router, private titleService: Title, private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        this.router.events
            .filter(event => event instanceof NavigationEnd)
            .map(() => this.activatedRoute)
            .map(route => {
                while (route.firstChild) route = route.firstChild;
                return route;
            })
            .filter(route => route.outlet === 'primary')
            .mergeMap(route => route.data)
            .subscribe((event) =>  {
                this.titleService.setTitle(event['title']);
            });

        this.router.events
            .filter(event => event instanceof NavigationEnd)
            .subscribe((event) => {
                if (event.url === '/login') {
                    this.showNavigation = false;
                } else {
                    this.showNavigation = true;
                }
            });
    }
}
