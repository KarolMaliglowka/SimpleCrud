import { Component, OnInit } from '@angular/core';
import { PhoneService } from './services/phone.service';
import { PhoneDto } from './models/phone.model';
import { MessageService, ConfirmationService } from 'primeng/api';
// PrimeNG
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [MessageService, ConfirmationService],
  imports: [
    HttpClientModule,
    FormsModule,

    // 🔽 wszystkie używane moduły PrimeNG muszą tu być
    TableModule,
    ButtonModule,
    InputTextModule,
    DialogModule,
    ConfirmDialogModule,
    ToastModule,
    ToolbarModule
  ]
})
export class AppComponent implements OnInit {
  phones: PhoneDto[] = [];
  phoneDialog: boolean = false;
  phone: PhoneDto = { id: '', name: '', phoneNumber: '' };
  submitted: boolean = false;
  isEdit: boolean = false;

  constructor(
    private phoneService: PhoneService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadPhones();
  }

  loadPhones() {
    console.log('pobieram dane');
    this.phoneService.getAll().subscribe(data => {
      this.phones = data;
    });
  }

  openNew() {
    this.phone = { id: '', name: '', phoneNumber: '' };
    this.submitted = false;
    this.phoneDialog = true;
    this.isEdit = false;
  }

  editPhone(phone: PhoneDto) {
    this.phone = { ...phone };
    this.phoneDialog = true;
    this.isEdit = true;
  }

  deletePhone(phone: PhoneDto) {
    this.confirmationService.confirm({
      message: `Na pewno chcesz usunąć ${phone.name}?`,
      accept: () => {
        this.phoneService.delete(phone.id).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Usunięto', detail: phone.name });
          this.loadPhones();
        });
      }
    });
  }

  savePhone() {
    this.submitted = true;

    if (this.phone.name && this.phone.phoneNumber) {
      if (this.isEdit) {
        this.phoneService.update(this.phone).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Zaktualizowano', detail: this.phone.name });
          this.loadPhones();
        });
      } else {
        this.phoneService.create(this.phone).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Dodano', detail: this.phone.name });
          this.loadPhones();
        });
      }
      this.phoneDialog = false;
    }
  }
}
