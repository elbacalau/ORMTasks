import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/interfaces/user.interface';
import { UserService } from 'src/app/services/user_services/user.service';

@Component({
  selector: 'app-first-entry',
  standalone: true,
  imports: [],
  templateUrl: './first-entry.component.html',
})
export class FirstEntryComponent implements OnInit{
  userData: User | null = null;
  constructor( private userService: UserService) { }

  ngOnInit(): void {
    this.userService.userData$.subscribe((data) => {
      this.userData = data;
    });
  }



}
