import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRouting } from './app.routing';

// services
import { UserService } from './services/user.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth.guard';
import { AuthModule } from './services/auth.module';

// components
import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { EmployeesComponent } from './components/admin/employees.component';


import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TempDataComponent } from './components/tempData/tempdata.component';

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule,
        AppRouting,
        AuthModule,
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        LogoutComponent,
        NavMenuComponent,
        HomeComponent,
        EmployeesComponent,
        CounterComponent,
        FetchDataComponent,
        TempDataComponent,
    ],
    providers: [
        UserService,
        AuthService,
        AuthGuard,
    ],
})
export class AppModule {
}
