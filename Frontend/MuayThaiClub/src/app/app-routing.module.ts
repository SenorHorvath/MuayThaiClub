import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './content/home/home.component';
import { ContactComponent } from './content/contact/contact.component';
import { AboutusComponent } from './content/aboutus/aboutus.component';

const routes: Routes = [
  { path:'', redirectTo:'home', pathMatch: 'full'},
  { path:'home', component: HomeComponent},
  { path:'contact', component: ContactComponent},
  { path:'aboutus', component: AboutusComponent},
  { path:'**', redirectTo:'home', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
