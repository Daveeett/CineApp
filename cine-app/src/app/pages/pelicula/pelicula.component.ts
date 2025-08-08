import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PeliculaService } from '../../core/services/pelicula.service';
import { Pelicula } from '../../core/models/pelicula.model';

@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class PeliculaComponent implements OnInit {
  peliculas: Pelicula[] = [];
  nuevaPelicula: Pelicula = { id_Pelicula: 0, nombre: '', duracion: 0 };
  editando: boolean = false;

  constructor(private service: PeliculaService) {}

  ngOnInit(): void {
    this.cargarPeliculas();
  }

  cargarPeliculas() {
    this.service.obtenerTodas().subscribe((res: Pelicula[]) => this.peliculas = res);
  }

  guardar() {
    if (this.editando) {
      this.service.actualizar(this.nuevaPelicula.id_Pelicula, this.nuevaPelicula).subscribe(() => {
        this.editando = false;
        this.nuevaPelicula = { id_Pelicula: 0, nombre: '', duracion: 0 };
        this.cargarPeliculas();
      });
    } else {
      this.service.crear(this.nuevaPelicula).subscribe(() => {
        this.nuevaPelicula = { id_Pelicula: 0, nombre: '', duracion: 0 };
        this.cargarPeliculas();
      });
    }
  }

  editar(p: Pelicula) {
    this.nuevaPelicula = { ...p };
    this.editando = true;
  }

  eliminar(id: number) {
    if (confirm('¿Eliminar película?')) {
      this.service.eliminar(id).subscribe(() => this.cargarPeliculas());
    }
  }
}
