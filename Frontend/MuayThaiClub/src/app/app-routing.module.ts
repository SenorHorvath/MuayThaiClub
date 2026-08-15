import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './content/home/home.component';
import { ContactComponent } from './content/contact/contact.component';
import { AboutusComponent } from './content/aboutus/aboutus.component';
import { ProfileComponent } from './content/profile_components/profile/profile.component';
import { LoginComponent } from './content/profile_components/login/login.component';
import { RegisterComponent } from './content/profile_components/register/register.component';


const routes: Routes = [
  { path:'', redirectTo:'home', pathMatch: 'full'},
  { path:'home', component: HomeComponent},
  { path:'contact', component: ContactComponent},
  { path:'aboutus', component: AboutusComponent},
  { path:'profile', component: ProfileComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path:'**', redirectTo:'home', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
