import { Tablero } from 'src/app/interfaces/tablero.interface';

import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { TableroService } from 'src/app/services/tablero_service/tablero.service';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [],
  templateUrl: './sidebar.component.html',

})
export class SidebarComponent implements OnInit{

  constructor(private tableroService: TableroService) { }

  ngOnInit(): void {
    this.getTableros();
  }

  listaTableros: Tablero[] = [];
  errorMessage: WritableSignal<string> = signal("");

  getTableros(): void {
    this.tableroService.getTableros()
    .subscribe({
      next: (data: Tablero[]) => {

        if (this.listaTableros.length === 0) {
          this.errorMessage.set("No tienes ningun tablero")
        }

        this.listaTableros = data;
        console.log(data);

      },
      error: (err) => this.errorMessage.set(err),
    });
  }


}
