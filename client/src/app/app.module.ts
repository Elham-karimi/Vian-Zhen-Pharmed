import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Forms
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

// CRUD
import { HttpClientModule } from '@angular/common/http';

//Materials
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';

// Fonts
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';

// Components
import { ListProductsComponent } from './components/list-products/list-products.component';
import { MareVitaminSupplementComponent } from './components/mare-vitamin-supplement/mare-vitamin-supplement.component';
import { ColtVitaminSupplementComponent } from './components/colt-vitamin-supplement/colt-vitamin-supplement.component';
import { SportHorsesVitaminSupplementComponent } from './components/sport-horses-vitamin-supplement/sport-horses-vitamin-supplement.component';
import { HoofMakerSupplementComponent } from './components/hoof-maker-supplement/hoof-maker-supplement.component';
import { JointSupplementComponent } from './components/joint-supplement/joint-supplement.component';
import { MushromixComponent } from './components/mushromix/mushromix.component';
import { MultiEnzymeSupplementComponent } from './components/multi-enzyme-supplement/multi-enzyme-supplement.component';
import { VianAmbassadorsComponent } from './components/vian-ambassadors/vian-ambassadors.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { ElementorSpacerComponent } from './components/elementor-spacer/elementor-spacer.component';
import { ImageSliderComponent } from './components/image-slider/image-slider.component';
import { RegisterComponent } from './components/account/register/register.component';
import { LoginComponent } from './components/account/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ListCitiesComponent } from './components/list-cities/list-cities.component';

// import { ShareButtonsModule } from 'ngx-sharebuttons/buttons';
// import { library as legacyLibrary } from '@fortawesome/fontawesome-svg-core';
// import { 	fa-user-alt } from '@fortawesome/free-solid-svg-icons';


@NgModule({
  declarations: [
    AppComponent,
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatMenuModule,

    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatSelectModule,
    FontAwesomeModule,
    // ShareButtonsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
   
    // library.addIconPacks(fa-user-alt);
     }
 }
