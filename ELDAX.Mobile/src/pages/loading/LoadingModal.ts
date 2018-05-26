import { Component } from '@angular/core';
 //https://www.joshmorony.com/how-to-create-a-custom-loading-component-in-ionic-2/
@Component({
  selector: 'loading-modal',
  templateUrl: 'loading-modal.html',
  styleUrls:['loading-modal.scss']
})
export class LoadingModal {
  isBusy: boolean;
  constructor() {
    this.isBusy = false;
  }
  show(){
    this.isBusy = true;
  }
  hide(){
    this.isBusy = false;
  }
}