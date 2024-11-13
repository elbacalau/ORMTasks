import { AuthService } from '../../../services/user_services/auth.service';
import { JsonPipe, NgClass } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "../../components/navbar/navbar/navbar.component";

@Component({
  selector: 'app-register-component',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, JsonPipe, NavbarComponent, NgClass],
  templateUrl: './register.component.html',

})
export class RegisterComponent implements OnInit{
expression: any;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }


  ngOnInit(): void { }


  errorMessage = signal("")
  isLoading = signal(false)
  showPasswordError = signal(false);

  registerForm = signal<FormGroup>(
    new FormGroup({
      nombre: new FormControl('', Validators.required),
      apellido: new FormControl('', Validators.required),
      segundoApellido: new FormControl(''),
      email: new FormControl('', Validators.required),
      contrasena: new FormControl('', [Validators.required, this.passwordValidator]),
      fechaNacimiento: new FormControl('', Validators.required),
      ciudad: new FormControl('', Validators.required),
      poblacion: new FormControl('', Validators.required),
      numeroTelefono: new FormControl('')
    })
  );

  passwordValidator(control: FormControl): { [key: string]: boolean } | null {
    const password: string = control.value;
    const hasMinLength = password && password.length >= 8;
    const hasNumber = /\d/.test(password);
    const hasUpperCase = /[A-Z]/.test(password);
    const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);

    const valid = hasMinLength && hasNumber && hasUpperCase && hasSpecialChar;

    return valid ? null : { invalidPassword: true };
  }

  onPasswordChange(): void {
    const passwordControl = this.registerForm().get('contrasena');
    if (passwordControl) {
      this.showPasswordError.set(passwordControl.errors?.['invalidPassword'] === true);
    }
  }



  onSubmit(): void {
    this.showPasswordError.set(false);

    if (this.registerForm().valid) {
      this.isLoading.set(true);

      this.authService.createUser(this.registerForm())
        .subscribe({
          next: response => {
            console.log('Usuario creado con exito');
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
      if (this.registerForm().get('contrasena')?.errors?.['invalidPassword']) {
        this.showPasswordError.set(true);
      }
      console.error("Formulario no válido:", this.registerForm().errors);
    }
  }
}
