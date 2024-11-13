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
    return this.http.get<User>(`${this.baseUrl}/Users/profile`).pipe(
      tap((userData) => {
        this.userDataSubject.next(userData);
        sessionStorage.setItem('userData', JSON.stringify(userData));
      })
    );
  }

  getUserData(): User | null {
    return this.userDataSubject.value;
  }
}
