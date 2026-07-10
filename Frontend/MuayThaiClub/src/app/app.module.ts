import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { FooterComponent } from './footer/footer.component';
import { AboutusComponent } from './content/aboutus/aboutus.component';
import { ContactComponent } from './content/contact/contact.component';
import { HomeComponent } from './content/home/home.component';
import { ProfileComponent } from './ProfileComponets/profile/profile.component';
import { RegisterComponent } from './ProfileComponets/register/register.component';
import { LoginComponent } from './ProfileComponets/login/login.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    FooterComponent,
    AboutusComponent,
    ContactComponent,
    HomeComponent,
    ProfileComponent,
    RegisterComponent,
    LoginComponent
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
