import { Component } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { RouterOutlet } from '@angular/router';
import { DashboardComponent } from "../dashboard/dashboard.component";

@Component({
  selector: 'app-home-screen',
  standalone: true,
  imports: [SidebarComponent, RouterOutlet, DashboardComponent],
  templateUrl: './home-screen.component.html',
  styleUrl: './home-screen.component.css'

})
export class HomeScreenComponent {

}
