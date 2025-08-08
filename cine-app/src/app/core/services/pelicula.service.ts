import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pelicula } from '../models/pelicula.model';
import { environment } from '../../Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PeliculaService {
  private apiUrl = environment.apiUrl + '/Pelicula';

  constructor(private http: HttpClient) {}

  obtenerTodas(): Observable<Pelicula[]> {
    return this.http.get<Pelicula[]>(this.apiUrl);
  }
  obtenerPorId(id: number): Observable<Pelicula> {
    return this.http.get<Pelicula>(`${this.apiUrl}/${id}`);
  }
  crear(pelicula: Pelicula): Observable<Pelicula> {
    return this.http.post<Pelicula>(this.apiUrl, pelicula);
  }

  actualizar(id: number, pelicula: Pelicula): Observable<Pelicula> {
    return this.http.put<Pelicula>(`${this.apiUrl}/${id}`, pelicula);
  }

  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
