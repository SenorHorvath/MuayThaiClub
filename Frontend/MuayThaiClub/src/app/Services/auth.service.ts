import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserRegisterDto } from '../Model/User/user-register-dto';
import { UserLoginDto } from '../Model/User/user-login-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl : string = 'https://localhost:7298/User/'
  constructor(private http : HttpClient) { }

  register(dto : UserRegisterDto)
  {
    return this.http.post(this.apiUrl + "Register", dto)
  }

  login(dto : UserLoginDto)
  {
    return this.http.post(this.apiUrl + "Login", dto)

  }

  getToken() : string | null
  {
    return null
  }

  logout()
  {
    
  }

  
}
