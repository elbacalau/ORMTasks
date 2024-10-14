import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { delay } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreateAccountService {

  private readonly baseUrl: string = "http://127.0.0.1:5118/api/Users/crear"
  constructor(private http: HttpClient) { }

  createUser(formData: FormGroup) {
    return this.http.post(this.baseUrl, formData.value).pipe(
      delay(2000)

      )
  }

}
