import { Component } from '@angular/core';
import { ProfileService } from '../Services/Profile/profile.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.sass'
})
export class NavigationComponent {

  constructor(public service : ProfileService)
  {
  }
}
