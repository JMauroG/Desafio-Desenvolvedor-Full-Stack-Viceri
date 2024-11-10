import { Component } from '@angular/core';
import { HeroisService } from './Services/herois/herois.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SuperHerosFront';

  constructor() {
  }

  ngOnInit(){
  }
}
