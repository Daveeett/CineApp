import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterOutlet } from '@angular/router';
import { DashboardComponent } from '../pages/dashboard/dashboard.component';
import { PeliculaComponent } from '../pages/pelicula/pelicula.component';
import { SalaComponent } from '../pages/sala/sala.component';
import { AsignacionComponent } from '../pages/asignacion/asignacion.component';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [NavbarComponent, RouterOutlet, DashboardComponent, PeliculaComponent, SalaComponent, AsignacionComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {}
