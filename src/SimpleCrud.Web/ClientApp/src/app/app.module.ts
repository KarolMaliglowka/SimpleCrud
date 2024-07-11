import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import {PhoneBookListComponent} from "./phone-book/phone-book-list/phone-book-list.component";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {InputNumberModule} from "primeng/inputnumber";
import {FormsModule} from "@angular/forms";
import {RippleModule} from "primeng/ripple";
import {RadioButtonModule} from "primeng/radiobutton";
import {TagModule} from "primeng/tag";
import {DropdownModule} from "primeng/dropdown";
import {ToastModule} from "primeng/toast";
import {ToolbarModule} from "primeng/toolbar";
import {FileUploadModule} from "primeng/fileupload";
import {TableModule} from "primeng/table";

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [AppRoutingModule, AppLayoutModule,
        ConfirmDialogModule,
        InputNumberModule,
        FormsModule,
        ConfirmDialogModule,
        RippleModule,
        RadioButtonModule,
        TagModule,
        DropdownModule,
        ToastModule,
        ToolbarModule,
        FileUploadModule,
        InputNumberModule,
        FormsModule,
        ConfirmDialogModule,
        RippleModule,
        RadioButtonModule,
        TagModule,
        DropdownModule,
        ToastModule,
        ToolbarModule,
        FileUploadModule,
        TableModule
    ],
    providers: [
        PhoneBookListComponent
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
