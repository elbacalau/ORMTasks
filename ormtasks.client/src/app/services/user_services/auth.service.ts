import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { environment } from 'enviroment';
import { catchError, delay, map, Observable, throwError } from 'rxjs';
import { LoginResponse } from 'src/app/interfaces/login.interface';
import { User } from 'src/app/interfaces/user.interface';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  createUser(formData: FormGroup): Observable<User> {
    return this.http.post<User>(this.baseUrl + "/Users/crear", formData.value).pipe(
      delay(2000),
      catchError((error) => {
        console.error("Error al crear el usuario:", error);
        return throwError(() => error);
      })
      );
  }

  login(credentials: FormGroup): Observable<String> {
    return this.http.post<LoginResponse>( this.baseUrl + "/Users/login",  credentials.value)
    .pipe(
      map(response => {
        localStorage.setItem('token', response.token);
        return response.token;
      }),
      catchError((error) => {
        console.error("Error en el login", error);
        return throwError(() => error);

      })
    )
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }


}
