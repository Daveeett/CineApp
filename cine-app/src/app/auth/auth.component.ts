import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent {
  usuario: string = 'admin';
  contrasena: string = 'admin';

  constructor(private router: Router) {}

  login() {
    if (this.usuario === 'admin' && this.contrasena === 'admin') {
      localStorage.setItem('token', 'true');
      this.router.navigate(['/dashboard']);
    } else {
      alert('Credenciales inválidas');
    }
  }
}

