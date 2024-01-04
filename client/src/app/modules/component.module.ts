import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../components/account/login/login.component';
import { RegisterComponent } from '../components/account/register/register.component';
import { ColtVitaminSupplementComponent } from '../components/colt-vitamin-supplement/colt-vitamin-supplement.component';
import { ContactusComponent } from '../components/contactus/contactus.component';
import { ElementorSpacerComponent } from '../components/elementor-spacer/elementor-spacer.component';
import { FooterComponent } from '../components/footer/footer.component';
import { HeaderComponent } from '../components/header/header.component';
import { HomeComponent } from '../components/home/home.component';
import { HoofMakerSupplementComponent } from '../components/hoof-maker-supplement/hoof-maker-supplement.component';
import { ImageSliderComponent } from '../components/image-slider/image-slider.component';
import { JointSupplementComponent } from '../components/joint-supplement/joint-supplement.component';
import { ListCitiesComponent } from '../components/list-cities/list-cities.component';
import { ListProductsComponent } from '../components/list-products/list-products.component';
import { MareVitaminSupplementComponent } from '../components/mare-vitamin-supplement/mare-vitamin-supplement.component';
import { MultiEnzymeSupplementComponent } from '../components/multi-enzyme-supplement/multi-enzyme-supplement.component';
import { MushromixComponent } from '../components/mushromix/mushromix.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { NoAccessComponent } from '../components/no-access/no-access.component';
import { NotFoundComponent } from '../components/not-found/not-found.component';
import { SportHorsesVitaminSupplementComponent } from '../components/sport-horses-vitamin-supplement/sport-horses-vitamin-supplement.component';
import { VianAmbassadorsComponent } from '../components/vian-ambassadors/vian-ambassadors.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { MaterialModule } from './material.module';

const components = [
  NavbarComponent,
  HomeComponent,
  FooterComponent,
  HeaderComponent,
  NotFoundComponent,
  ListCitiesComponent,
  ListProductsComponent,
  MareVitaminSupplementComponent,
  ColtVitaminSupplementComponent,
  SportHorsesVitaminSupplementComponent,
  HoofMakerSupplementComponent,
  JointSupplementComponent,
  MushromixComponent,
  MultiEnzymeSupplementComponent,
  VianAmbassadorsComponent,
  ContactusComponent,
  ElementorSpacerComponent,
  ImageSliderComponent,
  RegisterComponent,
  LoginComponent,
  NoAccessComponent,
];

@NgModule({
  declarations: [components],
  imports: [
    CommonModule,

    ReactiveFormsModule,
    AppRoutingModule, 
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule, 
    HttpClientModule,
    MaterialModule 
  ],
  exports: [components]
})
export class ComponentModule { }
