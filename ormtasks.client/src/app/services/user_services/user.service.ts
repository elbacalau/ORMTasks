// src/app/services/user.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'enviroment';

import { BehaviorSubject, Observable, of, tap } from 'rxjs';
import { User } from 'src/app/interfaces/user.interface';

@Injectable({ providedIn: 'root' })
export class UserService {
  private readonly baseUrl: string = environment.apiUrl;
  private userDataSubject = new BehaviorSubject<User | null>(null);
  userData$ = this.userDataSubject.asObservable();

  constructor(private http: HttpClient) {}

  loadUserData(): Observable<User> {
    const storedUserData = localStorage.getItem('userData');
    if (storedUserData) {
      const parsedUserData = JSON.parse(storedUserData);
      this.userDataSubject.next(parsedUserData);
      return of(parsedUserData);
    }

    return this.http.get<User>(`${this.baseUrl}/Users/profile`).pipe(
      tap((userData) => {
        this.userDataSubject.next(userData);
        localStorage.setItem('userData', JSON.stringify(userData));
      })
    );
  }

  getUserData(): User | null {
    return this.userDataSubject.value;
  }
}
