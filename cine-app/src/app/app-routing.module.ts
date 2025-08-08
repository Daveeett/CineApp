import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthComponent } from './auth/auth.component';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PeliculaComponent } from './pages/pelicula/pelicula.component';
import { SalaComponent } from './pages/sala/sala.component';
import { AsignacionComponent } from './pages/asignacion/asignacion.component';

const routes: Routes = [
  { path: '', component: AuthComponent },
  {
    path: 'app',
    component: LayoutComponent,
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'peliculas', component: PeliculaComponent },
      { path: 'salas', component: SalaComponent },
      { path: 'asignacion', component: AsignacionComponent }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
