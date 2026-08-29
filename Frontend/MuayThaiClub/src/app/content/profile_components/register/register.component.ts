import { Component } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { UserRegisterDto } from '../../../Model/User/user-register-dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.sass'
})
export class RegisterComponent {

  public RegisterDto : UserRegisterDto
  constructor(private service : AuthService) {
    this.service = service
    this.RegisterDto = new UserRegisterDto()
  }

   Register()
  {
    this.service.register(this.RegisterDto).subscribe({
      next : response => 
        {console.log("Sikeres regisztráció", response)},
      error : error =>
      {console.log("Hiba történt")}
    })
  }

}
