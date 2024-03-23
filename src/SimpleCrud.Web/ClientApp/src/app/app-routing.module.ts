import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import {PhonesListComponent} from "./phones-list/phones-list.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', component: PhonesListComponent
            },
            //{ path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
