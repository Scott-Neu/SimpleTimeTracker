import { Injectable } from '@angular/core';
import { Http, Headers, Response, URLSearchParams } from '@angular/http';
import { JwtHelper } from 'angular2-jwt';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from '../enviroments/enviroment';
import { UserService } from './user.service';

@Injectable()
export class AuthService {
    public token: string;

    constructor(private http: Http, private userService: UserService) {
        // set token if saved in local storage
        var currentToken = JSON.parse(localStorage.getItem('token'));
        this.token = currentToken && currentToken.token;
    }

    login(username: string, password: string): Observable<boolean> {
        //return Observable.of(false);

        var apiEndpoint = environment.apiUrl + "/token";

        let data = new URLSearchParams();
        data.append('username', username);
        data.append('password', password);

        return this.http.post(apiEndpoint, data)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let token = response.json() && response.json().access_token;
                if (token) {
                    // set token property
                    this.token = token;

                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('token', JSON.stringify({ username: username, token: token }));

                    // put the user into the user service
                    this.userService.setCurrentUser(new JwtHelper().decodeToken(token));
                    
                    // return true to indicate successful login
                    return true;
                } else {
                    // return false to indicate failed login
                    return false;
                }
            })
            .catch((error: Response) => {
                console.error(error);
                return Observable.of(false);
            });
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('token');
        // clear the user from the user service
        this.userService.removeCurrentUser();
    }

    // Finally, this method will check to see if the user is logged in. We'll be able to tell by checking to see if they have a token and whether that token is valid or not.
    loggedIn() {
        if (localStorage.getItem('token')) {
            // logged in so return true

            return !new JwtHelper().isTokenExpired(this.token);
        } else {
            return false;
        }
    }
}
