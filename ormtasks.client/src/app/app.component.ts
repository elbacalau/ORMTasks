// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from './services/user_services/user.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUserData();
  }

  loadUserData(): void {
    this.userService.loadUserData().subscribe({
      next: (data) => console.log('User data loaded:', data),
      error: (err) => console.error('Error loading user data:', err)
    });
  }
}
