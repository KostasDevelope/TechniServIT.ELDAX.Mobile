import { Component } from '@angular/core';
import { NavController  } from 'ionic-angular';
import { AlertController } from 'ionic-angular';
import { Account } from '../../services/account'
import { EldaxLocalStorage }  from '../../services/localStorage';
import { AuthenticationContext } from '../../interfaces/authenticationContext';
import { config }  from '../../config';
import { String } from 'typescript-string-operations';


@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
  providers: [ Account, EldaxLocalStorage ]
})
export class LoginPage {
  Username: string;
  Password: string;
  
  constructor(
    public navCtrl: NavController,
    private alertCtrl: AlertController,
    private account: Account,
    private eldaxLocalStorage: EldaxLocalStorage
    ) {}

  Login() : void {
    let authenticationContext = {
      ApplicationLogin: this.Username,
      Password: this.Password
    } as AuthenticationContext ;

    this.account.AuthenticateEx(authenticationContext).then(result => {
      if(result != null){
        this.eldaxLocalStorage.SetItemAsync(config.keys.authenticationContext, result)
        .then(result=>{
          if(result){
            this.eldaxLocalStorage.GetItemAsync<any>(config.keys.authenticationContext).then(result => {
              let message :string = String.Format("TOKEN: {0}", result.token); 
              let alert = this.alertCtrl.create({
                title: 'Authentication Context',
                subTitle: message,
                buttons: ['Dismiss']
             });
             alert.present();
            });
          }
        }).catch(result=>{

        });
      }
    })
    .catch(rtesult =>{

    });
  }
}
