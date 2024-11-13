import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { catchError, map, Observable, throwError } from 'rxjs';
import { LoginResponse } from 'src/app/interfaces/login.interface';
import { UserService } from './user.service';
import { User } from 'src/app/interfaces/user.interface';
import { environment } from 'enviroment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient, private userService: UserService, private route: Router) {}

  createUser(formData: FormGroup): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/Users/crear`, formData.value).pipe(
      catchError((error) => {
        console.error("Error al crear el usuario:", error);
        return throwError(() => error);
      })
    );
  }

  login(credentials: FormGroup): Observable<string> {
    return this.http.post<LoginResponse>(`${this.baseUrl}/Users/login`, credentials.value)
      .pipe(
        map(response => {
          localStorage.setItem('token', response.token);
          this.userService.loadUserData().subscribe({
            error: (error) => console.error('Error al cargar datos del usuario:', error)
          });
          return response.token;
        }),
        catchError((error) => {
          console.error("Error en el login", error);
          return throwError(() => error);
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
    // redirect to home
    this.route.navigate(['/']);
    sessionStorage.clear();
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
