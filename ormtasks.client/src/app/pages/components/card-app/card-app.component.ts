import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-app',
  standalone: true,
  imports: [],
  templateUrl: './card-app.component.html',
})
export class CardAppComponent {
  @Input() title: string = '';
  @Input() description: string = '';
}
