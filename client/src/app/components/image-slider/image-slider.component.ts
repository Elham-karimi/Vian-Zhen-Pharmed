import { Component } from '@angular/core';
// import { NgImageSliderModule } from 'ng-image-slider';


@Component({
  selector: 'app-image-slider',
  templateUrl: './image-slider.component.html',
  styleUrls: ['./image-slider.component.scss']
})
export class ImageSliderComponent {
  slideConfig = {
    slidesToShow: 1,
    slidesToScroll: 1,
    dots: true,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 3000
  };

  // images = [
  //   url:('../'),
  //   'https://example.com/image2.jpg',
  //   'https://example.com/image3.jpg',
  //   // Add more image URLs as needed
  // ];
}
