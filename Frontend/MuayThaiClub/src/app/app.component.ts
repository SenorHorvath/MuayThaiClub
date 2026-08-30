import { Component, OnInit } from '@angular/core';
import { AuthService } from './Services/auth.service';
import { GetCurrentUserDto } from './Model/User/get-current-user-dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})
export class AppComponent implements OnInit  {
  title = 'MuayThaiClub';
  currentUser : GetCurrentUserDto
  
  constructor(public service : AuthService)
  {
    this.currentUser = new GetCurrentUserDto()
  }
  ngOnInit(): void {
     this.service.getCurrentUser().subscribe(
      {
        next: user => this.currentUser = user,
        error: () => new GetCurrentUserDto()
      }
    )
  }
}
