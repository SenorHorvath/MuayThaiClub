import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthRegisterDto } from '../Model/Auth/auth-register-dto';
import { AuthLoginDto } from '../Model/Auth/auth-login-dto';
import { GetCurrentAuthDto } from '../Model/Auth/get-current-auth-dto';
import { environment } from '../Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl : string = environment.apiUrl + '/Auth/'
  constructor(private http : HttpClient) { }

  register(dto : AuthRegisterDto)
  {
    return this.http.post(this.apiUrl + "Register", dto)
  }

  login(dto : AuthLoginDto)
  {
    return this.http.post(this.apiUrl + "Login", dto, {withCredentials: true})

  }

  getCurrentUser()
  {
    return this.http.get<GetCurrentAuthDto>(this.apiUrl + "me", 
      { withCredentials: true })
  }

  
}
