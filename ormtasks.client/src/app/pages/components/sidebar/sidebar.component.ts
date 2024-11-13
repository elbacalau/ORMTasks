import { Tablero } from 'src/app/interfaces/tablero.interface';

import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { TableroService } from 'src/app/services/tablero_service/tablero.service';
import { AuthService } from 'src/app/services/user_services/auth.service';
import { UserService } from 'src/app/services/user_services/user.service';
import { User } from 'src/app/interfaces/user.interface';
import { single } from 'rxjs';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [],
  templateUrl: './sidebar.component.html',

})
export class SidebarComponent implements OnInit{
  userData: User | null = null;
  errorMessage = signal<string>("");
  constructor(private userService: UserService, private authService: AuthService) { }

  ngOnInit(): void {
    // cargamos el user data
    this.userService.loadUserData().subscribe({
      next: (data) => {
        this.userData = data;
      },
      error: (err) => {
        if (this.userData?.tableros.length === 0) {
          this.errorMessage.set("No tienes ningun tablero");
        }

        this.errorMessage.set("Error al cargar los datos del usuario");
      }
    });
    this.userService.userData$.subscribe((data) => {
      this.userData = data;
    });
  }



  logout(): void {
    this.authService.logout();
  }

}
