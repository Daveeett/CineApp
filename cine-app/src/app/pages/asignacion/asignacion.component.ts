import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AsignacionService } from '../../core/services/asignacion.service';
import { SalaService } from '../../core/services/sala.service';
import { PeliculaService } from '../../core/services/pelicula.service';
import { Asignacion } from '../../core/models/asignacion.model';
import { Sala } from '../../core/models/sala.model';
import { Pelicula } from '../../core/models/pelicula.model';

@Component({
  selector: 'app-asignacion',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './asignacion.component.html',
  styleUrl: './asignacion.component.css'
})
export class AsignacionComponent implements OnInit {
  salas: Sala[] = [];
  peliculas: Pelicula[] = [];
  asignaciones: Asignacion[] = [];
  nuevaAsignacion: Asignacion = { id: 0, id_Sala: 0, id_Pelicula: 0 };

  constructor(
    private asignacionService: AsignacionService,
    private salaService: SalaService,
    private peliculaService: PeliculaService
  ) {}

  ngOnInit(): void {
    this.salaService.obtenerTodas().subscribe(res => this.salas = res);
    this.peliculaService.obtenerTodas().subscribe(res => this.peliculas = res);
    this.cargarAsignaciones();
  }

  cargarAsignaciones() {
    this.asignacionService.obtenerTodas().subscribe(res => this.asignaciones = res.data);
  }

  guardar() {
    if (!this.nuevaAsignacion.id_Sala || !this.nuevaAsignacion.id_Pelicula) return;
    this.asignacionService.crear({ ...this.nuevaAsignacion }).subscribe(() => {
      this.nuevaAsignacion = { id: 0, id_Sala: 0, id_Pelicula: 0 };
      this.cargarAsignaciones();
    });
  }

  eliminar(id: number) {
    if (confirm('¿Eliminar asignación?')) {
      this.asignacionService.eliminar(id).subscribe(() => this.cargarAsignaciones());
    }
  }
}
