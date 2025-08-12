import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { PhoneBookComponent } from './phone-book/phone-book.component';

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: '', component: PhoneBookComponent },
            { path: '**', redirectTo: '/notfound' }
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
