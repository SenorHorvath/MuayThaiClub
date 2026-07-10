import { Injectable } from '@angular/core';
import { Profile } from '../../Model/Profile/profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  isLoggedIn : boolean = false
  profile? : Profile = undefined 
  constructor() { }

  login()
  {}

  register()
  {}
}
