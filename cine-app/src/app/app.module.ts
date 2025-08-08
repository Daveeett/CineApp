import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AuthComponent } from './auth/auth.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PeliculaComponent } from './pages/pelicula/pelicula.component';
import { SalaComponent } from './pages/sala/sala.component';
import { AsignacionComponent } from './pages/asignacion/asignacion.component';

@NgModule({
  declarations: [
    // No se declaran componentes standalone aquí
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    AuthComponent,
    NavbarComponent,
    LayoutComponent,
    DashboardComponent,
    PeliculaComponent,
    SalaComponent,
    AsignacionComponent
  ],
  providers: [],

})
export class AppModule {}
