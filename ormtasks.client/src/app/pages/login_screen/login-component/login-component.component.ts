import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../services/user_services/auth.service';
import { Component, signal } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-login-component',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule],
  templateUrl: './login-component.component.html',

})
export class LoginComponentComponent {

  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }

  isLoading = signal(false);
  errorMessage = signal("");
  loginForm = signal<FormGroup>(
    new FormGroup({
      email: new FormControl('', Validators.required),
      contrasena: new FormControl('', Validators.required)
    })
  );

   onSubmit(): void{
    if (this.loginForm().invalid) {
      return;
    }

    this.isLoading.set(true);
    const { email, contrasena } = this.loginForm().value;

    this.authService.login(this.loginForm())
    .subscribe({
      next: (token) => {

        // '/dashboard'
        this.router.navigate(['/dashboard']);
        console.log(token);

      },
      error: (error) => {
        console.error("Error en el login", error);
        this.errorMessage.set("Error al crear el usuario")
      },
      complete: () => {
        console.log("Proceso completado");
        this.isLoading.set(false);
      }
    });

   }



}
