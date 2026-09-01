import { Component, OnInit } from '@angular/core';
import { AuthService } from './Services/auth.service';
import { GetCurrentAuthDto } from './Model/Auth/get-current-auth-dto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})
export class AppComponent implements OnInit  {
  title = 'MuayThaiClub';
  currentUser : GetCurrentAuthDto
  
  constructor(public service : AuthService)
  {
    this.currentUser = new GetCurrentAuthDto()
  }
  ngOnInit(): void {
     this.service.getCurrentUser().subscribe(
      {
        next: user => this.currentUser = user,
        error: () => new GetCurrentAuthDto()
      }
    )
  }
}
