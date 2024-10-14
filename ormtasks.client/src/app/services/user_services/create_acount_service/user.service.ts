import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { environment } from 'enviroment';
import { catchError, delay, throwError } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  createUser(formData: FormGroup) {
    return this.http.post(this.baseUrl + "/Users/crear", formData.value).pipe(
      delay(2000),
      catchError((error) => {
        console.error("Error al crear el usuario:", error);
        return throwError(error);

      })

      )
  }

}
