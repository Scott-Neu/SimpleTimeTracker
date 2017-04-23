import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRouting } from './app.routing';

// services
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth.guard';

// components
import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule,
        AppRouting
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        LogoutComponent,
        HomeComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
    ],
    providers: [
        AuthService,
        AuthGuard,
    ],
})
export class AppModule {
}
