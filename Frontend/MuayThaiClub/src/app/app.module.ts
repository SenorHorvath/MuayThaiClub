import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { FooterComponent } from './footer/footer.component';
import { AboutusComponent } from './content/aboutus/aboutus.component';
import { ContactComponent } from './content/contact/contact.component';
import { HomeComponent } from './content/home/home.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Profile } from './Model/Profile/profile';
import { ProfileComponent } from './content/profile_components/profile/profile.component';
import { LoginComponent } from './content/profile_components/login/login.component';
import { RegisterComponent } from './content/profile_components/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    FooterComponent,
    AboutusComponent,
    ContactComponent,
    HomeComponent,
    ProfileComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
