import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { DashboardComponent } from "../dashboard/dashboard.component";
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { NavbarComponent } from '../../components/navbar/navbar/navbar.component';

@Component({
  selector: 'app-home-screen',
  standalone: true,
  imports: [RouterOutlet, DashboardComponent, RouterModule, NavbarComponent],
  templateUrl: './home-screen.component.html',
  styleUrl: './home-screen.component.css'

})
export class HomeScreenComponent {

}
