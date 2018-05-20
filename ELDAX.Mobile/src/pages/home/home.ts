import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  constructor(public navCtrl: NavController) {

  }
  public tapCounter: any = 0;
  buttonTapped() {
    this.tapCounter++;
  }
  reset() {
    this.tapCounter--;
  }


}
