import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';
import { AuthService } from './auth.service';

// extends angular2-jwt's AuthHttp to include the authentication bearer token in requests
// see the documentation for angular2-jwt

export function authHttpServiceFactory(http: Http, options: RequestOptions, authService : AuthService) {
    return new AuthHttp(new AuthConfig({
        tokenName: 'currentUser',
        tokenGetter: (() => authService.token),
        globalHeaders: [{ 'Content-Type': 'application/json' }],
    }), http, options);
}

@NgModule({
    providers: [
        {
            provide: AuthHttp,
            useFactory: authHttpServiceFactory,
            deps: [Http, RequestOptions, AuthService]
        }
    ]
})
export class AuthModule { }

