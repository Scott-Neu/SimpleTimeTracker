﻿import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './services/auth.guard';

// remove
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent,  data: { title: 'Login' } },
    { path: 'logout', component: LogoutComponent, data: { title: 'Logoff' } },
    { path: '', component: HomeComponent, canActivate: [AuthGuard], data: { title: 'Simple Time Tracker' } },

    // remove
    { path: 'counter', component: CounterComponent, canActivate: [AuthGuard] },
    { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const AppRouting = RouterModule.forRoot(appRoutes);
