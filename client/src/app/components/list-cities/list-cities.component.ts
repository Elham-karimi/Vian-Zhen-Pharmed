import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { City } from '../../models/city.model';

@Component({
  standalone : true,
  selector: 'app-list-cities',
  templateUrl: './list-cities.component.html',
  styleUrls: ['./list-cities.component.scss']
})
export class ListCitiesComponent {

  cities : City[] | undefined;

  constructor(private http : HttpClient){}

  showCities() : void {
    this.http.get<City[]>('http://localhost:5000/api/city/get-all-cities').subscribe(
      {next : response => this.cities = response}
    );
  }
}



