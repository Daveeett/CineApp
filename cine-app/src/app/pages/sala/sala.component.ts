import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SalaCineService } from '../../core/services/sala-cine.service';
import { Sala } from '../../core/models/sala.model';

@Component({
  selector: 'app-sala',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sala.component.html',
  styleUrl: './sala.component.css'
})
export class SalaComponent implements OnInit {
  salas: Sala[] = [];
  nuevaSala: Sala = { id_Sala: 0, nombre: '', capacidad: 0 };
  editando: boolean = false;

  constructor(private service: SalaCineService) {}

  ngOnInit(): void {
    this.cargarSalas();
  }

  cargarSalas() {
    this.service.obtenerTodas().subscribe((res: Sala[]) => this.salas = res);
  }

  guardar() {
    if (this.editando) {
      this.service.editar(this.nuevaSala.id_Sala, this.nuevaSala).subscribe(() => {
        this.editando = false;
        this.nuevaSala = { id_Sala: 0, nombre: '', capacidad: 0 };
        this.cargarSalas();
      });
    } else {
      this.service.agregar(this.nuevaSala).subscribe(() => {
        this.nuevaSala = { id_Sala: 0, nombre: '', capacidad: 0 };
        this.cargarSalas();
      });
    }
  }

  editar(s: Sala) {
    this.nuevaSala = { ...s };
    this.editando = true;
  }

  eliminar(id: number) {
    if (confirm('¿Eliminar sala?')) {
      this.service.eliminar(id).subscribe(() => this.cargarSalas());
    }
  }
}
