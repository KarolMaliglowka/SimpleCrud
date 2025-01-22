// import { Component } from '@angular/core';
//
// @Component({
//   selector: 'app-phone-book',
//   standalone: true,
//   imports: [],
//   templateUrl: './phone-book.component.html',
//   styleUrl: './phone-book.component.scss'
// })
// export class PhoneBookComponent {
//
// }




import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
// import { Product } from '@/domain/product';
import { PhoneBookService } from './phone-book.service';
import { TableModule } from 'primeng/table';
import { Dialog } from 'primeng/dialog';
import { Ripple } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { FileUpload } from 'primeng/fileupload';
import { Tag } from 'primeng/tag';
import { RadioButton } from 'primeng/radiobutton';
import { Rating } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { InputNumber } from 'primeng/inputnumber';
import { Table } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';

interface Column {
    field: string;
    header: string;
    customExportHeader?: string;
}

interface ExportColumn {
    title: string;
    dataKey: string;
}

@Component({
    selector: 'app-phone-book',
    templateUrl: './phone-book.component.html',
    styleUrl: './phone-book.component.scss',
    standalone: true,
    imports: [TableModule, Dialog, Ripple, SelectModule, ToastModule, ToolbarModule, ConfirmDialog, InputTextModule,  CommonModule, FileUpload, DropdownModule, Tag, RadioButton, Rating, InputTextModule, FormsModule, InputNumber, IconFieldModule, InputIconModule],
    providers: [MessageService, ConfirmationService, PhoneBookService],
    styles: [
        `:host ::ng-deep .p-dialog .product-image {
            width: 150px;
            margin: 0 auto 2rem auto;
            display: block;
        }`
    ]
})
export class PhoneBookComponent implements OnInit{
    productDialog: boolean = false;

    phoneBooks!: PhoneBook[];

    phoneBook!: PhoneBook;

    selectedPhoneBooks!: PhoneBook[] | null;

    submitted: boolean = false;

    statuses!: any[];

    @ViewChild('dt') dt!: Table;

    cols!: Column[];

    exportColumns!: ExportColumn[];

    constructor(
        private phoneBookService: PhoneBookService,
        private messageService: MessageService,
        private confirmationService: ConfirmationService,
        private cd: ChangeDetectorRef
    ) {}

    exportCSV() {
        this.dt.exportCSV();
    }

    loadDemoData() {
        this.phoneBookService.getProducts().then((data) => {
            this.phoneBooks = data;
            this.cd.markForCheck();
        });

        this.statuses = [
            { label: 'INSTOCK', value: 'instock' },
            { label: 'LOWSTOCK', value: 'lowstock' },
            { label: 'OUTOFSTOCK', value: 'outofstock' }
        ];

        this.cols = [
            { field: 'code', header: 'Code', customExportHeader: 'Product Code' },
            { field: 'name', header: 'Name' },
            { field: 'image', header: 'Image' },
            { field: 'price', header: 'Price' },
            { field: 'category', header: 'Category' }
        ];

        this.exportColumns = this.cols.map((col) => ({ title: col.header, dataKey: col.field }));
    }

    openNew() {
        this.phoneBook = {};
        this.submitted = false;
        this.phoneBookDialog = true;
    }

    editPhoneBook(phoneBook: PhoneBook) {
        this.phoneBook = { ...phoneBook };
        this.productDialog = true;
    }

    deleteSelectedPhoneBooks() {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete the selected phoneBooks?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.phoneBooks = this.phoneBooks.filter((val) => !this.selectedPhoneBooks?.includes(val));
                this.selectedPhoneBooks = null;
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Products Deleted',
                    life: 3000
                });
            }
        });
    }

    hideDialog() {
        this.productDialog = false;
        this.submitted = false;
    }

    deletePhoneBook(phoneBook: PhoneBook) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + phoneBook.name + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.phoneBooks = this.phoneBooks.filter((val) => val.id !== phoneBook.id);
                this.phoneBook = {};
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'PhoneBook Deleted',
                    life: 3000
                });
            }
        });
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.phoneBooks.length; i++) {
            if (this.phoneBooks[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        let id = '';
        var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (var i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        return id;
    }

    getSeverity(status: string) {
        switch (status) {
            case 'INSTOCK':
                return 'success';
            case 'LOWSTOCK':
                return 'warning';
            case 'OUTOFSTOCK':
                return 'danger';
        }
    }

    savePhoneBook() {
        this.submitted = true;

        if (this.phoneBook.name?.trim()) {
            if (this.phoneBook.id) {
                this.phoneBooks[this.findIndexById(this.phoneBook.id)] = this.phoneBook;
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'PhoneBook Updated',
                    life: 3000
                });
            } else {
                this.phoneBook.id = this.createId();
                this.phoneBook.image = 'phoneBook-placeholder.svg';
                this.phoneBooks.push(this.phoneBook);
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'PhoneBook Created',
                    life: 3000
                });
            }

            this.phoneBooks = [...this.phoneBooks];
            this.phoneBookDialog = false;
            this.phoneBook = {};
        }
    }
}
