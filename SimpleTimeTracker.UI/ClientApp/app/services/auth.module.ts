import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';

// extends angular2-jwt's AuthHttp to include the authentication bearer token in requests
// see the documentation for angular2-jwt
// todo, see if the tokenGetter can use the auth service as a dependency

export function authHttpServiceFactory(http: Http, options: RequestOptions) {
    return new AuthHttp(new AuthConfig({
        tokenName: 'currentUser',
        tokenGetter: (() => JSON.parse(localStorage.getItem('currentUser')).token),
        globalHeaders: [{ 'Content-Type': 'application/json' }],
    }), http, options);
}

@NgModule({
    providers: [
        {
            provide: AuthHttp,
            useFactory: authHttpServiceFactory,
            deps: [Http, RequestOptions]
        }
    ]
})
export class AuthModule { }

