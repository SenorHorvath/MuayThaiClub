import { Component } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { UserLoginDto } from '../../../Model/User/user-login-dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent {

  loginDto : UserLoginDto

  constructor(public service : AuthService, private router : Router) {
    this.loginDto = new UserLoginDto()
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
