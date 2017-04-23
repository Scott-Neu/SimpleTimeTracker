import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    moduleId: 'logout',
    template: ''
})

export class LogoutComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authService: AuthService) { }

    ngOnInit() {
        // reset login status
        this.authService.logout();
        this.router.navigate(['/']);
    }
}