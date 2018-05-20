import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { AlertController } from 'ionic-angular';

@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
  //styleUrls: ['login.scss']
})

export class LoginPage {
  Username: string;
  Password: string;
  
  constructor(public navCtrl: NavController,
     private alertCtrl: AlertController) {

  }
  Login() : void {
     
     let message :string  = "User Name:"+ this.Username; 
     
    let alert = this.alertCtrl.create({
      title: 'Low battery',
      subTitle: message,
      buttons: ['Dismiss']
    });
    alert.present();
  }
}
