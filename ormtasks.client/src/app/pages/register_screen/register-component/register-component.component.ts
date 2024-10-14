import { AuthService } from '../../../services/user_services/create_acount_service/auth.service';
import { JsonPipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-register-component',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, JsonPipe],
  templateUrl: './register-component.component.html',

})
export class RegisterComponent {



  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }


  errorMessage = signal("")
  isLoading = signal(false)
  registerForm = signal<FormGroup>(
    new FormGroup({
      nombre: new FormControl('', Validators.required),
      apellido: new FormControl('', Validators.required),
      segundoApellido: new FormControl(''),
      email: new FormControl('', Validators.required),
      contrasena: new FormControl('', Validators.required),
      fechaNacimiento: new FormControl('', Validators.required),
      ciudad: new FormControl('', Validators.required),
      poblacion: new FormControl('', Validators.required),
      numeroTelefono: new FormControl('')
    })
  );


  onSubmit(): void {
    if (this.registerForm().valid) {
      this.isLoading.set(true);

      this.authService.createUser(this.registerForm())
        .subscribe({
          next: response => {
            console.log('Usuario creado:', response);
            this.router.navigate(['/login']);
          },
          error: error => {
            this.errorMessage.set('Error al crear el usuario');
            console.error('Error al crear usuario:', error);
          },
          complete: () => {
            this.isLoading.set(false);
          }
        });
    } else {
      console.error("Formulario no válido:", this.registerForm().errors);
    }
  }






}
