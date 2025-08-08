import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../Environments/environment';
import { Sala } from '../models/sala.model';

@Injectable({
  providedIn: 'root'
})
export class SalaCineService {
  private apiUrl = environment.apiUrl + '/SalaCine';

  constructor(private http: HttpClient) {}

  obtenerTodas(): Observable<Sala[]> {
    return this.http.get<Sala[]>(this.apiUrl);
  }

  agregar(sala: Sala): Observable<Sala> {
    return this.http.post<Sala>(this.apiUrl, sala);
  }

  obtenerPorId(id: number): Observable<Sala> {
    return this.http.get<Sala>(`${this.apiUrl}/${id}`);
  }

  editar(id: number, sala: Sala): Observable<Sala> {
    return this.http.put<Sala>(`${this.apiUrl}/${id}`, sala);
  }

  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  obtenerPorEstado(estado: string): Observable<Sala[]> {
    return this.http.get<Sala[]>(`${this.apiUrl}/estado/${estado}`);
  }
}
