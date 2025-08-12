import { NgModule } from '@angular/core';
import {  LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { PhoneBookComponent } from './phone-book/phone-book.component';

@NgModule({
    declarations: [AppComponent],
    imports: [AppRoutingModule, AppLayoutModule, PhoneBookComponent],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        PhoneBookComponent
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
