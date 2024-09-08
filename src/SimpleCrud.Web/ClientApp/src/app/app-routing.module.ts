import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import {PhoneBookListComponent} from "./phone-book/phone-book-list/phone-book-list.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', component: PhoneBookListComponent
            },
            //{ path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
