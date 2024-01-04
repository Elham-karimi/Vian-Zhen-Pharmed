import { Component } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  products: string[] = [
  'مکمل های ویتامینه و معدنی مادیان',
  'مکمل های ویتامینه و معدنی کره اسب',
  'مکمل های ویتامینه و معدنی اسب ورزشی',
  'مکمل سم اسب',
  'مکمل مفاصل اسب ',
  'مکمل تقویت سیستم ایمنی اسب',
  'مکمل مولتی آنزیم اسب',
  ];
}
