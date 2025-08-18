import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PhoneDto } from '../models/phone.model';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {
  private apiUrl = 'http://localhost:5000'; // <- Twój backend

  constructor(private http: HttpClient) {}

  getAll(): Observable<PhoneDto[]> {
    console.log('trsttstss', this.apiUrl);
    return this.http.get<PhoneDto[]>(`${this.apiUrl}`);
  }

  getById(id: string): Observable<PhoneDto> {
    return this.http.get<PhoneDto>(`${this.apiUrl}/getById/${id}`);
  }

  create(phone: PhoneDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/create`, phone);
  }

  update(phone: PhoneDto): Observable<any> {
    return this.http.patch(`${this.apiUrl}/update`, phone);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/delete/${id}`);
  }
}
