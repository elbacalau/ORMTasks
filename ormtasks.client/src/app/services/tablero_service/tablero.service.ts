import { environment } from 'enviroment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tablero } from 'src/app/interfaces/tablero.interface';

@Injectable({providedIn: 'root'})
export class TableroService {
  constructor(private http: HttpClient) { }

  private readonly baseUrl: string = environment.apiUrl;


  getTableros(): Observable<Tablero[]> {
    return this.http.get<Tablero[]>(`${this.baseUrl}/tablero`);
  }

}
