import { Component, OnInit } from '@angular/core';
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
import {Phone} from "../domain/phone";
import {TableModule} from "primeng/table";

@Component({
    selector: 'app-phones-list',
    standalone: true,
    templateUrl: './phones-list.component.html',
    imports: [
        TableModule
    ],
    styleUrl: './phones-list.component.scss'
})
export class PhonesListComponent implements OnInit {

    phoneDialog: boolean = false;
    phones!: Phone[];
    phone!: Phone;
    submitted: boolean = false;
    selectedPhones!: Phone[] | null;

    constructor() {
        }

    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }


    openNew() {
        this.phone = {};
        this.submitted = false;
        this.phoneDialog = true;
    }

    deleteSelectedProducts() {
        // this.confirmationService.confirm({
        //     message: 'Are you sure you want to delete the selected products?',
        //     header: 'Confirm',
        //     icon: 'pi pi-exclamation-triangle',
        //     accept: () => {
        //         this.products = this.products.filter((val) => !this.selectedProducts?.includes(val));
        //         this.selectedProducts = null;
        //         this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
        //     }
        //});
    }
}