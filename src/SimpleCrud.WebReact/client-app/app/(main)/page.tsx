 'use client';
import React, { useState, useEffect, useRef } from 'react';
import { classNames } from 'primereact/utils';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { PhoneService } from './PhoneService';
import { Toast } from 'primereact/toast';
import { Button } from 'primereact/button';
import { Toolbar } from 'primereact/toolbar';
// import { IconField } from 'primereact/iconfield';
// import { InputIcon } from 'primereact/inputicon';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
 import {InputTextarea} from "primereact/inputtextarea";

export default function Phones() {
    let emptyPhone = {
        id: null,
        name: '',
        phoneNumber: ''
    };

    const [phones, setPhones] = useState();
    const [phoneDialog, setPhoneDialog] = useState(false);
    const [deletePhoneDialog, setDeletePhoneDialog] = useState(false);
    const [deletePhonesDialog, setDeletePhonesDialog] = useState(false);
    const [phone, setPhone] = useState(emptyPhone);
    const [selectedPhones, setSelectedPhones] = useState(null);
    const [submitted, setSubmitted] = useState(false);
    const [globalFilter, setGlobalFilter] = useState(null);
    const toast = useRef(null);
    const dt = useRef(null);

    useEffect(() => {
        PhoneService.getPhones().then((data) => setPhones(data));
    }, []);

    const openNew = () => {
        setPhone(emptyPhone);
        setSubmitted(false);
        setPhoneDialog(true);
    };

    const hideDialog = () => {
        setSubmitted(false);
        setPhoneDialog(false);
    };

    const hideDeletePhoneDialog = () => {
        setDeletePhoneDialog(false);
    };

    const hideDeletePhonesDialog = () => {
        setDeletePhonesDialog(false);
    };

    const savePhone = () => {
        setSubmitted(true);

        if (phone.name.trim()) {
            let _phones = [...phones];
            let _phone = { ...phone };

            if (phone.id) {
                const index = findIndexById(phone.id);

                _phones[index] = _phone;
                toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Phone Updated', life: 3000 });
            } else {
                _phone.id = createId();
                _phone.image = 'product-placeholder.svg';
                _phones.push(_phone);
                toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Phone Created', life: 3000 });
            }

            setPhones(_phones);
            setPhoneDialog(false);
            setPhone(emptyPhone);
        }
    };

    const editPhone = (phone) => {
        setPhone({ ...phone });
        setPhoneDialog(true);
    };

    const confirmDeletePhone = (phone) => {
        setPhone(phone);
        setDeletePhoneDialog(true);
    };

    const deletePhone = () => {
        let _phones = phones.filter((val) => val.id !== phone.id);

        setPhones(_phones);
        setDeletePhoneDialog(false);
        setPhone(emptyPhone);
        toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Phone Deleted', life: 3000 });
    };

    const findIndexById = (id) => {
        let index = -1;

        for (let i = 0; i < phones.length; i++) {
            if (phones[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    };

    const createId = () => {
        let id = '';
        let chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

        for (let i = 0; i < 5; i++) {
            id += chars.charAt(Math.floor(Math.random() * chars.length));
        }

        return id;
    };

    const exportCSV = () => {
        dt.current.exportCSV();
    };

    const confirmDeleteSelected = () => {
        setDeletePhonesDialog(true);
    };

    const deleteSelectedPhones = () => {
        let _phones = phones.filter((val) => !selectedPhones.includes(val));

        setPhones(_phones);
        setDeletePhonesDialog(false);
        setSelectedPhones(null);
        toast.current.show({ severity: 'success', summary: 'Successful', detail: 'Phones Deleted', life: 3000 });
    };

    const onInputChange = (e, name) => {
        const val = (e.target && e.target.value) || '';
        let _phone = { ...phone };

        _phone[`${name}`] = val;

        setPhone(_phone);
    };

    const leftToolbarTemplate = () => {
        return (
            <div className="flex flex-wrap gap-2">
                <Button label="New" icon="pi pi-plus" severity="success" onClick={openNew} />
                <Button label="Delete" icon="pi pi-trash" severity="danger" onClick={confirmDeleteSelected} disabled={!selectedPhones || !selectedPhones.length} />
            </div>
        );
    };

    const rightToolbarTemplate = () => {
        return <Button label="Export" icon="pi pi-upload" className="p-button-help" onClick={exportCSV} />;
    };

    const actionBodyTemplate = (rowData) => {
        return (
            <React.Fragment>
                <Button icon="pi pi-pencil" rounded outlined className="mr-2" onClick={() => editPhone(rowData)} />
                <Button icon="pi pi-trash" rounded outlined severity="danger" onClick={() => confirmDeletePhone(rowData)} />
            </React.Fragment>
        );
    };

    const header = (
        <div className="flex flex-wrap gap-2 align-items-center justify-content-between">
            <h4 className="m-0">Manage phones</h4>
            {/*<IconField iconPosition="left">*/}
            {/*    <InputIcon className="pi pi-search" />*/}
            {/*    <InputText type="search" onInput={(e) => setGlobalFilter(e.target.value)} placeholder="Search..." />*/}
            {/*</IconField>*/}
        </div>
    );
    const phoneDialogFooter = (
        <React.Fragment>
            <Button label="Cancel" icon="pi pi-times" outlined onClick={hideDialog} />
            <Button label="Save" icon="pi pi-check" onClick={savePhone} />
        </React.Fragment>
    );
    const deletePhoneDialogFooter = (
        <React.Fragment>
            <Button label="No" icon="pi pi-times" outlined onClick={hideDeletePhoneDialog} />
            <Button label="Yes" icon="pi pi-check" severity="danger" onClick={deletePhone} />
        </React.Fragment>
    );
    const deletePhonesDialogFooter = (
        <React.Fragment>
            <Button label="No" icon="pi pi-times" outlined onClick={hideDeletePhonesDialog} />
            <Button label="Yes" icon="pi pi-check" severity="danger" onClick={deleteSelectedPhones} />
        </React.Fragment>
    );

    return (
        <div>
            <Toast ref={toast} />
            <div className="card">
                <Toolbar className="mb-4" left={leftToolbarTemplate} right={rightToolbarTemplate}></Toolbar>

                <DataTable ref={dt} value={phones} selection={selectedPhones} showGridlines onSelectionChange={(e) => setSelectedPhones(e.value)}
                           dataKey="id" paginator rows={10} rowsPerPageOptions={[5, 10, 25]}
                           paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                           currentPageReportTemplate="Showing {first} to {last} of {totalRecords} phones" globalFilter={globalFilter} header={header}>
                    <Column selectionMode="multiple" exportable={false}></Column>
                    <Column field="name" header="Name" sortable style={{ minWidth: '26rem' }}></Column>
                    <Column field="phoneNumber" header="Phone Number" sortable style={{ minWidth: '26rem' }}></Column>
                    <Column header="Action" body={actionBodyTemplate} exportable={false} style={{ minWidth: '12rem' }}></Column>
                </DataTable>
            </div>

            <Dialog visible={phoneDialog} style={{width: '32rem'}} breakpoints={{'960px': '75vw', '641px': '90vw'}}
                    header="Phone Details" modal className="p-fluid" footer={phoneDialogFooter} onHide={hideDialog}>
                <div className="field">
                    <label htmlFor="name" className="font-bold">
                        Name
                    </label>
                    <InputText id="name" value={phone.name} onChange={(e) => onInputChange(e, 'name')} required
                               autoFocus className={classNames({'p-invalid': submitted && !phone.name})}/>
                    {submitted && !phone.name && <small className="p-error">Name is required.</small>}
                </div>
                <div className="field">
                    <label htmlFor="phoneNumber" className="font-bold">
                        Phone number
                    </label>
                    <InputText id="phoneNumber" value={phone.phoneNumber} required
                               onChange={(e) => onInputChange(e, 'phoneNumber')}
                               className={classNames({'p-invalid': submitted && !phone.phoneNumber})}/>
                </div>
            </Dialog>

            <Dialog visible={deletePhoneDialog} style={{width: '32rem'}}
                    breakpoints={{'960px': '75vw', '641px': '90vw'}} header="Confirm" modal
                    footer={deletePhoneDialogFooter} onHide={hideDeletePhoneDialog}>
                <div className="confirmation-content">
                    <i className="pi pi-exclamation-triangle mr-3" style={{fontSize: '2rem' }} />
                    {phone && (
                        <span>
                            Are you sure you want to delete <b>{phone.name}</b>?
                        </span>
                    )}
                </div>
            </Dialog>

            <Dialog visible={deletePhonesDialog} style={{ width: '32rem' }} breakpoints={{ '960px': '75vw', '641px': '90vw' }} header="Confirm" modal footer={deletePhonesDialogFooter} onHide={hideDeletePhonesDialog}>
                <div className="confirmation-content">
                    <i className="pi pi-exclamation-triangle mr-3" style={{ fontSize: '2rem' }} />
                    {phone && <span>Are you sure you want to delete the selected phones?</span>}
                </div>
            </Dialog>
        </div>
    );
}

