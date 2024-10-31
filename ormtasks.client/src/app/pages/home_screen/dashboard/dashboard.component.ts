import { Component, OnInit } from '@angular/core';

import { RouterModule } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { UserService } from 'src/app/services/user_services/user.service';
import { User } from 'src/app/interfaces/user.interface';
import { FirstEntryComponent } from "../../components/first-entry/first-entry.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [SidebarComponent, RouterModule, FirstEntryComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{
  userData: User | null = null;
  constructor( private userService: UserService) { }

  ngOnInit(): void {
    this.userService.userData$.subscribe((data) => {
      this.userData = data;
    });
  }



}
