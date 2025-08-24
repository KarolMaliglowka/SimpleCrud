import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../models/phone.model';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {
  private apiUrl = 'http://localhost:5000'; // <- Twój backend

  constructor(private http: HttpClient) {}

  getAll(): Observable<Phone[]> {
    return this.http.get<Phone[]>(`${this.apiUrl}`);
  }

  getById(id: string): Observable<Phone> {
    return this.http.get<Phone>(`${this.apiUrl}/getById/${id}`);
  }

  create(phone: Phone): Observable<any> {
    return this.http.post(`${this.apiUrl}/create`, phone);
  }

  update(phone: Phone): Observable<any> {
    return this.http.patch(`${this.apiUrl}/update`, phone);
  }

  delete(phone: Phone): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete/${phone.id}`);
  }
}
