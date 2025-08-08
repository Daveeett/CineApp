import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Asignacion } from '../models/asignacion.model';

@Injectable({
  providedIn: 'root'
})
export class AsignacionService {
  private asignaciones: Asignacion[] = [];
  private id = 1;

  obtenerTodas(): Observable<{ data: Asignacion[] }> {
    return of({ data: this.asignaciones });
  }

  crear(asignacion: Asignacion): Observable<Asignacion> {
    asignacion.id = this.id++;
    this.asignaciones.push(asignacion);
    return of(asignacion);
  }

  eliminar(id: number): Observable<void> {
    this.asignaciones = this.asignaciones.filter(a => a.id !== id);
    return of();
  }
}
