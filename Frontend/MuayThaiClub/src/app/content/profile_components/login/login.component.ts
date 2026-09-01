import { Component } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { AuthLoginDto } from '../../../Model/Auth/auth-login-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent {

  loginDto : AuthLoginDto

  constructor(public service : AuthService, private router : Router) {
    this.loginDto = new AuthLoginDto()
  }

  login()
  {
    this.service.login(this.loginDto).subscribe({
      next : response => 
        {
          console.log("Sikeres bejelentkezés", response)
          this.router.navigate(["/home"])
        },
      error : error =>
      {console.log("Hiba történt")}
    })
  }
}
