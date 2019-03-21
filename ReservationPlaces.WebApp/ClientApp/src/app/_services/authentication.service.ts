import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { LoginViewModel, RegisterViewModel } from '../_models';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<LoginViewModel>;
    public currentUser: Observable<LoginViewModel>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<LoginViewModel>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): LoginViewModel {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string, rememberMe: boolean ) {
        return this.http.post<any>('/account/login', { email, password, rememberMe })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                }

                return user;
            }));
    }

    register(user: RegisterViewModel) {
      return this.http.post(`/account/register`, user);
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
