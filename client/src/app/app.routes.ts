import { Routes } from '@angular/router';
import { AboutusComponent } from './components/aboutus/aboutus.component';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { ColtVitaminSupplementComponent } from './components/colt-vitamin-supplement/colt-vitamin-supplement.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { HomeComponent } from './components/home/home.component';
import { HoofMakerSupplementComponent } from './components/hoof-maker-supplement/hoof-maker-supplement.component';
import { JointSupplementComponent } from './components/joint-supplement/joint-supplement.component';
import { ListProductsComponent } from './components/list-products/list-products.component';
import { MareVitaminSupplementComponent } from './components/mare-vitamin-supplement/mare-vitamin-supplement.component';
import { MultiEnzymeSupplementComponent } from './components/multi-enzyme-supplement/multi-enzyme-supplement.component';
import { MushromixComponent } from './components/mushromix/mushromix.component';
import { NoAccessComponent } from './components/no-access/no-access.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { SportHorsesVitaminSupplementComponent } from './components/sport-horses-vitamin-supplement/sport-horses-vitamin-supplement.component';
import { VianAmbassadorsComponent } from './components/vian-ambassadors/vian-ambassadors.component';

export const routes: Routes = [
    {path: '', component: HomeComponent}, 
    {path: 'home', component: HomeComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: 'account/login' , component : LoginComponent},
    {path: 'list-products' , component: ListProductsComponent},
    {path: 'colt-vitamin-supplement', component: ColtVitaminSupplementComponent},
    {path: 'mare-vitamin-supplement', component: MareVitaminSupplementComponent},
    {path: 'sport-horses-vitamin-supplement', component: SportHorsesVitaminSupplementComponent},
    {path: 'hoof-maker-supplement', component : HoofMakerSupplementComponent},
    {path: 'joint-supplement' , component : JointSupplementComponent},
    {path: 'mushromix',component : MushromixComponent},
    {path: 'multi-enzyme-supplement', component : MultiEnzymeSupplementComponent},
    {path: 'vian-ambassadors', component : VianAmbassadorsComponent},
    {path: 'contactus' , component : ContactusComponent},
    {path: 'aboutus',component: AboutusComponent},
    {path: 'no-access', component: NoAccessComponent},
    {path: '**', component: NotFoundComponent}
  ];
